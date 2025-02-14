using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Components.Authorization;
using HromadaWEB.DB.Data;
using HromadaWEB.Core.Services;
using HromadaWEB.Core.Repositories;
using HromadaWEB.Service.Handlers.User;
using HromadaWEB.Infrastructure.Interfaces.Role;
using HromadaWEB.Infrastructure.Services.Role;
using HromadaWEB.Service.Handlers.Role;
using HromadaWEB.Infrastructure.Repositories.Role;
using HromadaWEB.Infrastructure.Interfaces.Auth;
using HromadaWEB.Infrastructure.Services.Auth;
using HromadaWEB.Infrastructure.Interfaces.Templates;
using HromadaWEB.Infrastructure.Services.Templates;
using HromadaWEB.Infrastructure.Repositories.Templates;
using HromadaWEB.Service.Handlers.Templates;
using HromadaWEB.Service.Handlers.EvaluationDirections;
using HromadaWEB.Infrastructure.Services.EvaluationDirections;
using HromadaWEB.Infrastructure.Repositories.EvaluationDirections;
using HromadaWEB.Infrastructure.Interfaces.EvaluationDirections;
using HromadaWEB.Service.Handlers.Indicators;
using HromadaWEB.Infrastructure.Interfaces.Indicators;
using HromadaWEB.Infrastructure.Services.Indicators;
using HromadaWEB.Infrastructure.Repositories.Indicators;
using HromadaWEB.Infrastructure.Interfaces.IndicatorAnswer;
using HromadaWEB.Infrastructure.Services.IndicatorAnswer;
using HromadaWEB.Infrastructure.Repositories.IndicatorAnswer;
using HromadaWEB.Service.Handlers.IndicatorAswer;
using HromadaWEB.Service.Handlers.Review;
using HromadaWEB.Infrastructure.Interfaces.Review;
using HromadaWEB.Infrastructure.Services.Review;
using HromadaWEB.Infrastructure.Repositories.Review;

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

    configuration.RegisterServicesFromAssembly(typeof(GetAllTemplatesHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(GetTemplateByIdHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(CreateTemplateHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(UpdateTemplateHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(DeleteTemplateHandler).Assembly);

    configuration.RegisterServicesFromAssembly(typeof(GetAllEvaluationDirectionsHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(GetEvaluationDirectionByIdHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(CreateEvaluationDirectionHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(UpdateEvaluationDirectionHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(DeleteEvaluationDirectionHandler).Assembly);

    configuration.RegisterServicesFromAssembly(typeof(GetAllIndicatorsHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(GetIndicatorByIdHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(CreateIndicatorHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(UpdateIndicatorHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(DeleteIndicatorHandler).Assembly);

    configuration.RegisterServicesFromAssembly(typeof(GetAllIndicatorAnswersHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(GetIndicatorAnswersHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(CreateIndicatorAnswerHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(UpdateIndicatorAnswerHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(DeleteIndicatorAnswerHandler).Assembly);

    configuration.RegisterServicesFromAssembly(typeof(GetAllReviewsHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(GetReviewByIdHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(CreateReviewHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(UpdateReviewHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(DeleteReviewHandler).Assembly);
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

builder.Services.AddScoped<ITemplateService, TemplateService>();
builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();

builder.Services.AddScoped<IEvaluationDirectionService, EvaluationDirectionService>();
builder.Services.AddScoped<IEvaluationDirectionRepository, EvaluationDirectionRepository>();

builder.Services.AddScoped<IIndicatorService, IndicatorService>();
builder.Services.AddScoped<IIndicatorRepository, IndicatorRepository>();

builder.Services.AddScoped<IIndicatorAnswersService, IndicatorAnswersService>();
builder.Services.AddScoped<IIndicatorAnswersRepository, IndicatorAnswersRepository>();

builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

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
