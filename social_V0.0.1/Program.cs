using Microsoft.Data.SqlClient; // Necessario per SqlConnection
using Radzen;
using social_V0._0._1.Components;
using social_V0._0._1.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Aggiungi i servizi per i componenti Razor e Interactive Server
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Aggiungi i servizi Radzen (necessari per i componenti grafici)
builder.Services.AddRadzenComponents();

// 3. Configura la connessione al Database
// Assicurati che nel file appsettings.json ci sia la stringa "DefaultConnection"
builder.Services.AddScoped(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// 4. Registra il tuo servizio PostService
builder.Services.AddScoped<PostService>();

var app = builder.Build();

// Configurazione della pipeline delle richieste HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

// Importante per le immagini e i file CSS/JS di Radzen
app.UseStaticFiles();

// Protezione Antiforgery
app.UseAntiforgery();

// Mappatura degli asset statici (Nuova feature .NET 9/10)
app.MapStaticAssets();

// Configura i componenti Razor per girare in modalità InteractiveServer
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();