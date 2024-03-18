﻿// <auto-generated />
using FlaggGaming.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlaggGaming.Migrations
{
    [DbContext(typeof(DatosContext))]
    [Migration("20240315235345_inicial")]
    partial class inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlaggGaming.Model.apiSteamListaJuegosTotal.ItemListaJuegoSteam", b =>
                {
                    b.Property<int>("appid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("appid"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("appid");

                    b.ToTable("ItemListaJuegoSteam", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
