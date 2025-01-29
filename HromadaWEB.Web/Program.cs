using HromadaWEB.Web;
using HromadaWEB.Web.Components;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Додаємо підтримку контролерів та стандартні сервіси
builder.Services.AddControllers();
builder.AddServiceDefaults();

// Налаштовуємо Blazor Server та Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddOutputCache();

// **Виправлено: Правильний BaseAddress**
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7358") });

// **(За потреби) Авторизація**
// builder.Services.AddScoped<AuthService>();
// builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
// builder.Services.AddAuthorizationCore();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

// **(Опціонально) Прибрати, якщо HTTPS не використовується**
app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.MapControllers(); // **Це важливо!**
app.UseAntiforgery();
app.UseOutputCache();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();
