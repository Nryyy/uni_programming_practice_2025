using Blazored.LocalStorage;
using HromadaWEB.Web;
using HromadaWEB.Web.Components;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.AddServiceDefaults();

// Add Blazor Server and Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddOutputCache();

// Config BaseAddress for HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7358") });

// Custo service regist AuthenticationStateProvider
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

builder.Services.AddBlazoredLocalStorage();

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

builder.Services.AddAuthorizationCore();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

// Enable CORS before authentication and authorization
app.UseCors("AllowAllOrigins");

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseAntiforgery();
app.UseOutputCache();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();
