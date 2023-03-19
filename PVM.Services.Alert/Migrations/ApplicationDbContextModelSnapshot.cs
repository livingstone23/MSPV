﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PVM.Services.Alert.DbContexts;

#nullable disable

namespace PVM.Services.Alert.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PVM.Services.Alert.FileData", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GCRecord")
                        .HasColumnType("int");

                    b.Property<int>("OptimisticLockField")
                        .HasColumnType("int");

                    b.Property<int>("size")
                        .HasColumnType("int");

                    b.HasKey("Oid");

                    b.ToTable("FileData", "dbo");
                });

            modelBuilder.Entity("PVM.Services.Alert.Gestion.Cliente", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Block")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Building")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreosOnlineCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoorNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Floor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GCRecord")
                        .HasColumnType("int");

                    b.Property<string>("IdentificationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificationType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OptimisticLockField")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Portal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stairs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Oid");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Cliente", "dbo");
                });

            modelBuilder.Entity("PVM.Services.Alert.Gestion.PrefijoPais", b =>
                {
                    b.Property<string>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("GCRecord")
                        .HasColumnType("int");

                    b.Property<string>("NombrePais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OptimisticLockField")
                        .HasColumnType("int");

                    b.Property<string>("PGestBaseObjectType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prefijo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Oid");

                    b.ToTable("PrefijoPais", "dbo");
                });

            modelBuilder.Entity("PVM.Services.Alert.Gestion.Provincia", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GCRecord")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OptimisticLockField")
                        .HasColumnType("int");

                    b.Property<string>("PGestBaseObjectType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Oid");

                    b.ToTable("Provincia", "dbo");
                });

            modelBuilder.Entity("PVM.Services.Alert.Gestion.Subscription", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GCRecord")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastChange")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Namen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OptimisticLockField")
                        .HasColumnType("int");

                    b.Property<string>("PGestBaseObjectType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URLLogo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Oid");

                    b.ToTable("Base-Subscriptions", "dbo");
                });

            modelBuilder.Entity("PVM.Services.Alert.Notificacion", b =>
                {
                    b.Property<string>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("AceptarDocumento")
                        .HasColumnType("bit");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ArchivoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bloque")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuzonRecepcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Calle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Canal")
                        .HasColumnType("int");

                    b.Property<string>("Causa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ClienteOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CodigoCSV")
                        .HasColumnType("bit");

                    b.Property<string>("CodigoPostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAlternativo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Escalera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoEnvio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoOperador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaEntrada")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GCRecord")
                        .HasColumnType("int");

                    b.Property<string>("KM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModoEnvio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Movil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroContrato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oficina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OptimisticLockField")
                        .HasColumnType("int");

                    b.Property<int>("Pais")
                        .HasColumnType("int");

                    b.Property<string>("Planta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlazoJuridico")
                        .HasColumnType("int");

                    b.Property<string>("Poblacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Producto")
                        .HasColumnType("int");

                    b.Property<int>("Proveedor")
                        .HasColumnType("int");

                    b.Property<string>("Provincia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Puerta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenciaEnvio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenciaIdClaveFactura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenciaIdClienteD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenciaIdClienteU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenciaIdContrato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenciaIdCuenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenciaOperador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TipoEnvio")
                        .HasColumnType("int");

                    b.Property<string>("TipoFichero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoNotificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoVia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Oid");

                    b.HasIndex("ArchivoId");

                    b.HasIndex("ClienteOid");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Notificacion", "dbo");
                });

            modelBuilder.Entity("PVM.Services.Alert.Gestion.Cliente", b =>
                {
                    b.HasOne("PVM.Services.Alert.Gestion.Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("PVM.Services.Alert.Notificacion", b =>
                {
                    b.HasOne("PVM.Services.Alert.FileData", "Archivo")
                        .WithMany()
                        .HasForeignKey("ArchivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PVM.Services.Alert.Gestion.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteOid");

                    b.HasOne("PVM.Services.Alert.Gestion.Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Archivo");

                    b.Navigation("Cliente");

                    b.Navigation("Subscription");
                });
#pragma warning restore 612, 618
        }
    }
}
