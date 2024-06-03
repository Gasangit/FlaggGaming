using FlaggGaming.Model.apiSteamJuego;
using FlaggGaming.Model.apiSteamListaJuegosTotal;
using FlaggGaming.Model.juegoFlagg;
using Microsoft.EntityFrameworkCore;

namespace FlaggGaming.Entity
{
    public class DatosContext: DbContext
    {
        public DbSet<ItemListaJuegoSteam> listaJuegos { get; set; }

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

            modelBuilder.Entity<Juego>()
                .ToTable('juegos')
                .HasKey(juego => juego.idFlagg);

            modelBuilder.Entity<ItemListaJuegoSteam>(
                    juego =>
                    {
                        juego.Property(j => j.name).HasColumnType("varchar(500)");
                    }                
                );

            modelBuilder.Entity<Juego>(
                    juego =>
                    {
                        juego.Property(j => j.idFlagg).HasColumnType("uniqueidentifier");
                        juego.Property(j => j.idJuegoTienda).HasColumnType("varchar(max)");
                        juego.Property(j => j.nombre).HasColumnType("varchar(max)");
                        juego.Property(j => j.descripcionCorta).HasColumnType("varchar(max)");
                        juego.Property(j => j.tienda).HasColumnType("varchar(max)");
                        juego.Property(j => j.imagen).HasColumnType("varchar(max)");
                        juego.Property(j => j.imagenMini).HasColumnType("varchar(max)");
                        juego.Property(j => j.urlTienda).HasColumnType("varchar(max)");
                        juego.Property(j => j.precio).HasColumnType("varchar(max)");
                        juego.Property(j => j.contadorVistas).HasColumnType("varchar(max)");
                        juego.Property(j => j.idOferta).HasColumnType("varchar(max)");
                        juego.Property(j => j.estudio).HasColumnType("varchar(max)");
                        juego.Property(j => j.requisitos).HasColumnType("varchar(max)");
                    }
                );

        }
    }
}