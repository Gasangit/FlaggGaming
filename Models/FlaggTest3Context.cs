using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FlaggGaming.Models;

public partial class FlaggTest3Context : DbContext
{
    public FlaggTest3Context()
    {
    }

    public FlaggTest3Context(DbContextOptions<FlaggTest3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<EpicList> EpicLists { get; set; }

    public virtual DbSet<Juego> Juegos { get; set; }

    public virtual DbSet<Oferta> Ofertas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ReleaseDate> ReleaseDates { get; set; }

    public virtual DbSet<SteamList> SteamLists { get; set; }

    public virtual DbSet<Tienda> Tiendas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuariosTienda> UsuariosTiendas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=13.50.158.9\\\\\\\\SQLEXPRESS,1433;Database=flagg_test3;User Id=sa;Password=Flagg2024;TrustServerCertificate=true;Encrypt=false;Max Pool Size=200;Connection Timeout=300");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<EpicList>(entity =>
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
        });

        modelBuilder.Entity<Juego>(entity =>
        {
            entity.HasKey(e => e.IdFlagg).HasName("PK__juegos__E007760D83E62722");

            entity.ToTable("juegos");

            entity.Property(e => e.IdFlagg)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idFlagg");
            entity.Property(e => e.ContadorVistas).HasColumnName("contadorVistas");
            entity.Property(e => e.DescripcionCorta).HasColumnName("descripcionCorta");
            entity.Property(e => e.Estudio)
                .HasMaxLength(250)
                .HasColumnName("estudio");
            entity.Property(e => e.IdJuegoTienda).HasColumnName("idJuegoTienda");
            entity.Property(e => e.IdOferta)
                .IsUnicode(false)
                .HasColumnName("idOferta");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.ImagenMini).HasColumnName("imagenMini");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
            entity.Property(e => e.OfertaidOferta).HasColumnName("ofertaidOferta");
            entity.Property(e => e.Requisitos).HasColumnName("requisitos");
            entity.Property(e => e.Tienda)
                .HasMaxLength(50)
                .HasColumnName("tienda");
            entity.Property(e => e.UrlEpic)
                .HasMaxLength(255)
                .HasColumnName("urlEpic");
            entity.Property(e => e.UrlTienda).HasColumnName("urlTienda");
        });

        modelBuilder.Entity<Oferta>(entity =>
        {
            entity.HasKey(e => e.IdOferta);

            entity.ToTable("ofertas");

            entity.Property(e => e.IdOferta)
                .ValueGeneratedNever()
                .HasColumnName("idOferta");
            entity.Property(e => e.DiscountPercent).HasColumnName("discount_percent");
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

        modelBuilder.Entity<ReleaseDate>(entity =>
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

        modelBuilder.Entity<SteamList>(entity =>
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
        });

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

            entity.HasIndex(e => e.EMail, "UQ__usuarios__410EDA2FD624E763").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EMail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("eMail");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RolTienda).HasColumnName("rolTienda");
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
