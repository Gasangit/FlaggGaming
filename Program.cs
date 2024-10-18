using FlaggGaming.Services;
using FlaggGaming.Services.ServiciosAPISteam;
using FlaggGaming.Entity;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
//using Microsoft.JSInterop;
//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using FlaggGaming.Model.apiSteamListaJuegosTotal;
//using Microsoft.IdentityModel.Tokens;
using FlaggGaming.Services.ScrapEpic;
using FlaggGaming.Services.EpicGameStoreNet;
using FlaggGaming.Services.ServiciosAPIEpic;
using FlaggGaming.Services.CargaBaseDeDatos;
using Microsoft.IdentityModel.Tokens;
using FluentScheduler;
using System.Runtime.Serialization.DataContracts;
using FlaggGaming.Services.ServiciosConTimer;
using FlaggGaming.Services.ServiciosParaCalculos;
using FlaggGaming.Services.ServicioUsuario;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatosContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserContext"));
});

builder.Logging.ClearProviders(); //limpia la consola de los mensajes internos de .net

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthentication(); //para identity
//builder.Services.AddHostedService<TimerDescargaListaTotalSteam>();
//builder.Services.AddHostedService<TimerDescargaListaTotalEpic>();
//builder.Services.AddHostedService<TimerDescargaInfoJuegoSteam>();
builder.Services.AddScoped<juegosIndexService>();
builder.Services.AddScoped<JuegosListaTotalService>();
builder.Services.AddScoped<JuegoSteamService>();
builder.Services.AddScoped<JuegoEpicService>();
builder.Services.AddScoped<ScrapWebEpicService>();
builder.Services.AddScoped<EpicGameStoreNetService>();
builder.Services.AddScoped<JuegosEpicListaParcialService>();
builder.Services.AddScoped<CargaListaSteamEnBaseDeDatos>();
builder.Services.AddScoped<CargaInfoJuegoSteamEnBAseDeDatos>();
builder.Services.AddScoped<CargaInfoJuegoEpicEnBAseDeDatos>();
builder.Services.AddScoped<ServicioDolar>();
builder.Services.AddScoped<ServicioIPC>();
builder.Services.AddScoped<ServicioUsurioLogin>();
builder.Services.AddHttpClient("scrapWebEpic");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.UseAuthentication(); //para identity
app.UseAuthorization(); //para identity
app.MapFallbackToPage("/_Host");

app.Run();