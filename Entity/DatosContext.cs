using FlaggGaming.Model.apiSteamJuego;
using FlaggGaming.Model.apiSteamListaJuegosTotal;
using Microsoft.EntityFrameworkCore;

namespace FlaggGaming.Entity
{
    public class DatosContext: DbContext
    {
        public DbSet<ItemListaJuegoSteam> listaJuegosMinima { get; set; }

        public DatosContext() { } //Constructor vacio
        public DatosContext(DbContextOptions<DatosContext> optionsBuilder) : base(optionsBuilder) 
        { } //Constructor que necesita MVC para interfaces.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var connectionString = configuration.GetConnectionString("UserContext");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemListaJuegoSteam>()
                .ToTable("ItemListaJuegoSteam")
                .HasKey(juego => juego.appid);

            modelBuilder.Entity<ItemListaJuegoSteam>(
                    juego =>
                    {
                        juego.Property(j => j.name).HasColumnType("varchar(500)");
                    }                
                );


        }
    }
}