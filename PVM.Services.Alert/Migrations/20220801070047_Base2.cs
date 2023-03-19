using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVM.Services.Alert.Migrations
{
    public partial class Base2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Base-Subscriptions",
                schema: "dbo",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Namen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: false),
                    URLLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PGestBaseObjectType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base-Subscriptions", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "FileData",
                schema: "dbo",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    size = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileData", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "PrefijoPais",
                schema: "dbo",
                columns: table => new
                {
                    Oid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PGestBaseObjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefijo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombrePais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrefijoPais", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                schema: "dbo",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PGestBaseObjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "dbo",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreosOnlineCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Building = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Portal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Block = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stairs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoorNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_Cliente_Base-Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "dbo",
                        principalTable: "Base-Subscriptions",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notificacion",
                schema: "dbo",
                columns: table => new
                {
                    Oid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenciaEnvio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenciaIdClienteU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenciaIdClienteD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenciaIdContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenciaIdCuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenciaIdClaveFactura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlazoJuridico = table.Column<int>(type: "int", nullable: false),
                    BuzonRecepcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAlternativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoFichero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AceptarDocumento = table.Column<bool>(type: "bit", nullable: false),
                    CodigoCSV = table.Column<bool>(type: "bit", nullable: false),
                    TipoEnvio = table.Column<int>(type: "int", nullable: false),
                    ModoEnvio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Movil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proveedor = table.Column<int>(type: "int", nullable: false),
                    ClienteOid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Canal = table.Column<int>(type: "int", nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenciaOperador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Producto = table.Column<int>(type: "int", nullable: false),
                    NumeroContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoNotificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Causa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<int>(type: "int", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Poblacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoVia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bloque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Escalera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Planta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puerta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoEnvio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoOperador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oficina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacion", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_Notificacion_Base-Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "dbo",
                        principalTable: "Base-Subscriptions",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificacion_Cliente_ClienteOid",
                        column: x => x.ClienteOid,
                        principalSchema: "dbo",
                        principalTable: "Cliente",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_Notificacion_FileData_ArchivoId",
                        column: x => x.ArchivoId,
                        principalSchema: "dbo",
                        principalTable: "FileData",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_SubscriptionId",
                schema: "dbo",
                table: "Cliente",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacion_ArchivoId",
                schema: "dbo",
                table: "Notificacion",
                column: "ArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacion_ClienteOid",
                schema: "dbo",
                table: "Notificacion",
                column: "ClienteOid");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacion_SubscriptionId",
                schema: "dbo",
                table: "Notificacion",
                column: "SubscriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificacion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PrefijoPais",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Provincia",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FileData",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Base-Subscriptions",
                schema: "dbo");
        }
    }
}
