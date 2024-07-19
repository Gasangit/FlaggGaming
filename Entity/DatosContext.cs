using FlaggGaming.Model.apiSteamJuego;
using FlaggGaming.Model.apiSteamListaJuegosTotal;
using FlaggGaming.Model.juegoFlagg;
using Microsoft.EntityFrameworkCore;

namespace FlaggGaming.Entity
{
    public class DatosContext: DbContext
    {
        public DbSet<ItemListaJuegoSteam> listaJuegos { get; set; }
        public DbSet<JuegoFlagg> listaJuegosData { get; set; }

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
                .ToTable("SteamList")
                .HasKey(juego => juego.appid);

            modelBuilder.Entity<FechaLanzamiento>()
                .ToTable("release_date")
                .HasKey(fecha => fecha.idFecha);

            modelBuilder.Entity<JuegoFlagg>()
                .ToTable("juegos")
                .HasKey(juego => juego.idFlagg);

            modelBuilder.Entity<Oferta>()
                .ToTable("ofertas")
                .HasKey(oferta => oferta.idOferta);

            modelBuilder.Entity<ItemListaJuegoSteam>(
                    juego =>
                    {
                        juego.Property(j => j.name).HasColumnType("varchar(500)");
                        juego.Property(j => j.created_at).HasColumnType("datetime");
                    }                
                );

            modelBuilder.Entity<JuegoFlagg>(
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

            modelBuilder.Entity<FechaLanzamiento>(
                   fecha =>
                   {
                       fecha.Property(j => j.idFecha).HasColumnType("uniqueidentifier");
                       fecha.Property(j => j.proximamente).HasColumnType("BIT");
                       fecha.Property(j => j.fecha).HasColumnType("varchar(max)");
                   }
               );

            modelBuilder.Entity<Oferta>(
                oferta =>
                {
                    oferta.Property(o => o.idOferta).HasColumnType("uniqueidentifier");
                    /*oferta.Property(o => o.idFlagg).HasColumnType("uniqueidentifier");*/
                    oferta.Property(o => o.discount_percent).HasColumnType("int");
                }
                );
        }
    }
}