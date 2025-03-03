using SyncfusionBlazorApp1.Data;
using Syncfusion.Blazor;
using SyncfusionBlazorApp1;
using SyncfusionBlazorApp1.Components;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddSignalR(o => { o.MaximumReceiveMessageSize = 102400000; });
builder.Services.AddSyncfusionBlazor();
            builder.Services.AddSingleton<PowerPointService>();
            builder.Services.AddSingleton<WordService>();
            builder.Services.AddSingleton<PdfService>();
            builder.Services.AddSingleton<ExcelService>();
builder.Services.AddMemoryCache();

var app = builder.Build();
//Register Syncfusion license https://help.syncfusion.com/common/essential-studio/licensing/how-to-generate
var licenseKey = configuration["SyncfusionLicensing"];

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(licenseKey);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();
