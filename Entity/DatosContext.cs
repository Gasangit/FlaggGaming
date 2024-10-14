using FlaggGaming.Model.apiSteamJuego;
using FlaggGaming.Model.apiSteamListaJuegosTotal;
using FlaggGaming.Model.apiEpic.apiEpicListaJuegosTotal;
using FlaggGaming.Model.juegoFlagg;
using Microsoft.EntityFrameworkCore;
using FlaggGaming.Model.usuarios;
using FlaggGaming.Model.tienda;
using FlaggGaming.Model;

namespace FlaggGaming.Entity
{
    public class DatosContext : DbContext
    {
        public DbSet<ItemListaJuegoSteam> listaJuegos { get; set; }
        public DbSet<JuegoFlagg> listaJuegosData { get; set; }
        public DbSet<Oferta> listaOfertas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        public virtual DbSet<Model.juegoFlagg.ReleaseDate> ReleaseDates { get; set; }
        public virtual DbSet<Tienda> Tiendas { get; set; }

        public virtual DbSet<UsuariosTienda> UsuariosTiendas { get; set; }

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
            //modelBuilder.Entity<Juego>(entity => entity.HasNoKey());
            modelBuilder.Entity<ItemListaJuegoEpic>(entity => entity.HasNoKey());
            modelBuilder.Entity<Juego>(entity => entity.HasNoKey());

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria).HasName("PK__categori__CD54BC5A900ED068");

                entity.ToTable("categorias");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
                entity.Property(e => e.DescCategoria)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("desc_categoria");
                entity.Property(e => e.ImagenUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("imagen_url");
            });

            /*modelBuilder.Entity<EpicList>(entity =>
            {
                entity.HasKey(e => e.Appid).HasName("PK__EpicList__C00F024DAFCA64ED");

                entity.ToTable("EpicList");

                entity.Property(e => e.Appid)
                    .ValueGeneratedNever()
                    .HasColumnName("appid");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });*/

            modelBuilder.Entity<JuegoFlagg>(entity =>
            {
                entity.HasKey(e => e.idFlagg).HasName("PK__juegos__E007760D83E62722");

                entity.ToTable("juegos");

                entity.Property(e => e.idFlagg)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("idFlagg");
                entity.Property(e => e.contadorVistas).HasColumnName("contadorVistas");
                entity.Property(e => e.descripcionCorta).HasColumnName("descripcionCorta");
                entity.Property(e => e.estudio)
                    .HasMaxLength(250)
                    .HasColumnName("estudio");
                entity.Property(e => e.idJuegoTienda).HasColumnName("idJuegoTienda");
                entity.Property(e => e.idOferta)
                    .IsUnicode(false)
                    .HasColumnName("idOferta");
                entity.Property(e => e.imagen).HasColumnName("imagen");
                entity.Property(e => e.imagenMini).HasColumnName("imagenMini");
                entity.Property(e => e.nombre)
                    .HasMaxLength(200)
                    .HasColumnName("nombre");
                entity.Property(e => e.ofertaidOferta).HasColumnName("ofertaidOferta");
                entity.Property(e => e.requisitos).HasColumnName("requisitos");
                entity.Property(e => e.tienda)
                    .HasMaxLength(50)
                    .HasColumnName("tienda");
                entity.Property(e => e.urlEpic)
                    .HasMaxLength(255)
                    .HasColumnName("urlEpic");
                entity.Property(e => e.urlTienda).HasColumnName("urlTienda");
            });

            modelBuilder.Entity<Oferta>(entity =>
            {
                entity.HasKey(e => e.idOferta);

                entity.ToTable("ofertas");

                entity.Property(e => e.idOferta)
                    .ValueGeneratedNever()
                    .HasColumnName("idOferta");
                entity.Property(e => e.discount_percent).HasColumnName("discount_percent");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdInternoProducto).HasName("PK__producto__A83A1C380111D261");

                entity.ToTable("productos");

                entity.Property(e => e.IdInternoProducto).HasColumnName("id_interno_producto");
                entity.Property(e => e.DescTienda)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("desc_tienda");
                entity.Property(e => e.Estatus).HasColumnName("estatus");
                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
                entity.Property(e => e.IdTienda).HasColumnName("id_tienda");
                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca");
                entity.Property(e => e.PrecioVta)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio_vta");
                entity.Property(e => e.SkuTienda)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sku_tienda");

                entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__productos__id_ca__4D94879B");

                entity.HasOne(d => d.IdTiendaNavigation).WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdTienda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__productos__id_ti__4E88ABD4");
            });

            modelBuilder.Entity<Model.juegoFlagg.ReleaseDate>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("release_date");

                entity.Property(e => e.ComingSoon).HasColumnName("coming_soon");
                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");
                entity.Property(e => e.IdFlagg).HasColumnName("idFlagg");

                entity.HasOne(d => d.IdFlaggNavigation).WithMany()
                    .HasForeignKey(d => d.IdFlagg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_release_date_juegos");
            });

            /*modelBuilder.Entity<SteamList>(entity =>
            {
                entity.HasKey(e => e.Appid);

                entity.ToTable("SteamList");

                entity.Property(e => e.Appid)
                    .ValueGeneratedNever()
                    .HasColumnName("appid");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });*/

            modelBuilder.Entity<Tienda>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__tiendas__3213E83F70A355A0");

                entity.ToTable("tiendas");

                entity.HasIndex(e => e.RazonSocial, "UQ__tiendas__17BADCA0552EA015").IsUnique();

                entity.HasIndex(e => e.Cuit, "UQ__tiendas__2CDD9897AFA3BFAE").IsUnique();

                entity.HasIndex(e => e.Mail, "UQ__tiendas__7A21290479191779").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Cuit)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cuit");
                entity.Property(e => e.Days)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("days");
                entity.Property(e => e.Dir)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("dir");
                entity.Property(e => e.Hr)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("hr");
                entity.Property(e => e.Insta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("insta");
                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mail");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
                entity.Property(e => e.Premium).HasColumnName("premium");
                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("razonSocial");
                entity.Property(e => e.Tel)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tel");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__usuarios__3213E83F26EBE7FB");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.mail, "UQ__usuarios__410EDA2FD624E763").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.mail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("eMail");
                entity.Property(e => e.nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");
                entity.Property(e => e.apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");
                entity.Property(e => e.password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");
                entity.Property(e => e.rolTienda).HasColumnName("rolTienda");
            });

            modelBuilder.Entity<UsuariosTienda>(entity =>
            {
                entity.HasKey(e => new { e.IdU, e.IdT }).HasName("PK__usuarios__01951BBA4021FFF4");

                entity.ToTable("usuarios_tiendas", tb => tb.HasTrigger("ActualizarRolTienda"));

                entity.Property(e => e.IdU).HasColumnName("idU");
                entity.Property(e => e.IdT).HasColumnName("idT");
                entity.Property(e => e.Active).HasColumnName("active");

                entity.HasOne(d => d.IdTNavigation).WithMany(p => p.UsuariosTienda)
                    .HasForeignKey(d => d.IdT)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarios_ti__idT__5070F446");

                entity.HasOne(d => d.IdUNavigation).WithMany(p => p.UsuariosTienda)
                    .HasForeignKey(d => d.IdU)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarios_ti__idU__5165187F");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__usuarios__3213E83F26EBE7FB");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.mail, "UQ__usuarios__410EDA2FD624E763").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.mail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("eMail");
                entity.Property(e => e.nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");
                entity.Property(e => e.apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");
                entity.Property(e => e.password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");
                entity.Property(e => e.rolTienda).HasColumnName("rolTienda");
            });

            modelBuilder.Entity<ItemListaJuegoSteam>()
                .ToTable("SteamList")
                .HasKey(juego => juego.appid);

            modelBuilder.Entity<ItemListaJuegoEpic>()
                .ToTable("EpicList")
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


            //Relación OFERTA JUEGOS
            modelBuilder.Entity<Oferta>()
                .HasMany(oferta => oferta.juegos)
                .WithOne(juego => juego.oferta);
            modelBuilder.Entity<JuegoFlagg>()
                .HasOne(juego => juego.oferta)
                .WithMany(oferta => oferta.juegos);

            modelBuilder.Entity<ItemListaJuegoSteam>(
                    juego =>
                    {
                        juego.Property(j => j.name).HasColumnType("varchar(500)");
                        juego.Property(j => j.created_at).HasColumnType("datetime");
                    }
                );

            modelBuilder.Entity<ItemListaJuegoEpic>(
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
                        juego.Property(j => j.idJuegoTienda).HasColumnType("int");
                        juego.Property(j => j.nombre).HasColumnType("varchar(max)");
                        juego.Property(j => j.descripcionCorta).HasColumnType("varchar(max)");
                        juego.Property(j => j.tienda).HasColumnType("varchar(max)");
                        juego.Property(j => j.imagen).HasColumnType("varchar(max)");
                        juego.Property(j => j.imagenMini).HasColumnType("varchar(max)");
                        juego.Property(j => j.urlTienda).HasColumnType("varchar(max)");
                        juego.Property(j => j.urlEpic).HasColumnType("varchar(max)");
                        //juego.Property(j => j.precio).HasColumnType("varchar(max)");
                        juego.Property(j => j.contadorVistas).HasColumnType("int");
                        juego.Property(j => j.idOferta).HasColumnType("varchar(max)");
                        juego.Property(j => j.estudio).HasColumnType("varchar(max)");
                        juego.Property(j => j.requisitos).HasColumnType("varchar(max)");
                        juego.Property(j => j.ofertaidOferta).HasColumnType("uniqueidentifier");
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
                    oferta.Property(o => o.discount_percent).HasColumnType("int");
                }
                );

        }*/
    }
}