using FlaggGaming.Services;
using FlaggGaming.Services.APISteam;
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
using FlaggGaming.Services.APIEpic;
using FlaggGaming.Services.CargaBaseDeDatos;
using Microsoft.IdentityModel.Tokens;
using FluentScheduler;
using System.Runtime.Serialization.DataContracts;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatosContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserContext"));
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<juegosIndexService>();
builder.Services.AddScoped<JuegosListaTotalService>();
builder.Services.AddScoped<JuegoSteamService>();
builder.Services.AddScoped<ScrapWebEpicService>();
builder.Services.AddScoped<EpicGameStoreNetService>();
builder.Services.AddScoped<JuegosEpicListaParcialService>();
builder.Services.AddScoped<CargaListaSteamEnBaseDeDatos>();
builder.Services.AddHttpClient("scrapWebEpic");
//builder.Services.AddScoped<IJSRuntime>();

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
app.MapFallbackToPage("/_Host");

/*JobManager.Initialize();

JobManager.AddJob(
    () =>
    {
        CargaListaSteamEnBaseDeDatos carga = new CargaListaSteamEnBaseDeDatos();
        carga.insertListaSteamEnBD();
        Console.WriteLine("Ingreso de datos");
    },
    s => s.ToRunEvery(5).Seconds()
);*/

app.Run();