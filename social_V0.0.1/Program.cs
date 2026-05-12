using social_V0._0._1.Components;
using Radzen;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// 1. Aggiungi i servizi per i componenti Razor e Interactive Server
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Aggiungi i servizi Radzen (necessari per i componenti grafici)
builder.Services.AddRadzenComponents();

// 3. Configura la connessione al Database per Dapper
// Nota: viene iniettato uno scope che apre la connessione usando la stringa in appsettings.json
builder.Services.AddScoped(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

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

// Protezione Antiforgery (standard in .NET 8/9+)
app.UseAntiforgery();

// Mappatura degli asset statici (ottimizzazione .NET 9)
app.MapStaticAssets();

// Configura i componenti Razor per girare in modalità InteractiveServer
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();