using SchoolDirectoryApp.Components;
using SchoolDirectoryApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Typed HttpClient for the Edutots School API.
// Change "ApiBaseUrl" in appsettings.json to a wrong URL to test the error state.
var baseUrl = builder.Configuration["ApiBaseUrl"] ?? "https://edutots.net/";
builder.Services.AddHttpClient<SchoolService>(client =>
{
    client.BaseAddress = new Uri(baseUrl);
    client.Timeout = TimeSpan.FromSeconds(15);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();