using social_V0._0._1.Components;
using social_V0._0._1.Models;

var builder = WebApplication.CreateBuilder(args);

// Aggiungi i servizi per Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Permette di leggere la stringa di connessione da appsettings.json
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddScoped<UserSession>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();