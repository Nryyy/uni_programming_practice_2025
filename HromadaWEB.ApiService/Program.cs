using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HromadaWEB.Core.Services;
using HromadaWEB.Core.Repositories;
using HromadaWEB.Service.Handlers.User;
using HromadaWEB.Infrastructure.Interfaces.Role;
using HromadaWEB.Infrastructure.Services.Role;
using HromadaWEB.Service.Handlers.Role;
using HromadaWEB.Infrastructure.Repositories.Role;
using Microsoft.AspNetCore.Components.Authorization;
using HromadaWEB.DB.Data;
using HromadaWEB.Infrastructure.Interfaces.Auth;
using HromadaWEB.Infrastructure.Services.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Swagger configuration for JWT
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Id = "Bearer",
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

// DataBase configuration
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(GetAllUsersHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(GetUserByIdHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(UpdateUserHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(DeleteUserHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(GetRolesHandler).Assembly);
});

var secret = builder.Configuration.GetValue<string>("AppSettings:Token");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["AppSettings:Issuer"],
        ValidAudience = builder.Configuration["AppSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
    };
});

builder.Services.AddAuthorization();

builder.Services.AddScoped<AuthenticationStateProvider, HromadaWEB.Web.ApiAuthenticationStateProvider>();

// Add services to the container
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

// Enable CORS before authentication and authorization
app.UseCors("AllowAllOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
