using Blazored.LocalStorage;
using HromadaWEB.BL.Services;
using HromadaWEB.Web;
using HromadaWEB.Web.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Додавання контролерів
builder.Services.AddControllers();
builder.AddServiceDefaults();

// Додавання Blazor Server і Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Додавання кешування виводу
builder.Services.AddOutputCache();

// Налаштування BaseAddress для HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7358") });

// Регістрація кастомного AuthenticationStateProvider
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

// Додавання авторизації та інших сервісів
builder.Services.AddAuthorizationCore();

// Підготовка для реєстрації додаткових сервісів, якщо потрібно
// builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

var app = builder.Build();

// Конфігурація для середовища
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

// Налаштування HTTPS редиректу
app.UseHttpsRedirection();

// Enable CORS before authentication and authorization
app.UseCors("AllowAllOrigins");

app.UseRouting();
app.UseAuthorization();
app.MapControllers(); // Додання мапування контролерів
app.UseAntiforgery();
app.UseOutputCache();

// Мапування статичних файлів
app.MapStaticAssets();

// Мапування Razor Components для Blazor Server
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();
