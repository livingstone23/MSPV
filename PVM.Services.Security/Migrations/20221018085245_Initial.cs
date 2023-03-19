using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVM.Services.Security.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "Action",
                schema: "Security",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "Applicative",
                schema: "Security",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicative", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "PolicyRole",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyUser",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangePasswordOnFirstLogon = table.Column<bool>(type: "bit", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyUserClaims",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "View",
                schema: "Security",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicativeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssemblyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parent = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: true),
                    ActionOid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_View", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_View_Action_ActionOid",
                        column: x => x.ActionOid,
                        principalSchema: "Security",
                        principalTable: "Action",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_View_Applicative_ApplicativeId",
                        column: x => x.ApplicativeId,
                        principalSchema: "Security",
                        principalTable: "Applicative",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyRoleClaims",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyRoleClaims_PolicyRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "PolicyRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyUserLogins",
                schema: "Security",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_PolicyUserLogins_PolicyUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "PolicyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyUserRol",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true),
                    PolicyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyUserRol", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_PolicyUserRol_PolicyRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "PolicyRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyUserRol_PolicyUser_PolicyUserId",
                        column: x => x.PolicyUserId,
                        principalSchema: "Security",
                        principalTable: "PolicyUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PolicyUserRol_PolicyUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "PolicyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyUserTokens",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_PolicyUserTokens_PolicyUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "PolicyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleHistory",
                schema: "Security",
                columns: table => new
                {
                    UserRoleHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserRoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicyUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionRoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleHistory", x => x.UserRoleHistoryId);
                    table.ForeignKey(
                        name: "FK_UserRoleHistory_PolicyUser_CreatedId",
                        column: x => x.CreatedId,
                        principalSchema: "Security",
                        principalTable: "PolicyUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleAction",
                schema: "Security",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAction", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_RoleAction_Action_ActionId",
                        column: x => x.ActionId,
                        principalSchema: "Security",
                        principalTable: "Action",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAction_View_ViewId",
                        column: x => x.ViewId,
                        principalSchema: "Security",
                        principalTable: "View",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViewAction",
                schema: "Security",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActiondId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ViewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: true),
                    ApplicativeOid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewAction", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_ViewAction_Action_ActiondId",
                        column: x => x.ActiondId,
                        principalSchema: "Security",
                        principalTable: "Action",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViewAction_Applicative_ApplicativeOid",
                        column: x => x.ApplicativeOid,
                        principalSchema: "Security",
                        principalTable: "Applicative",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_ViewAction_View_ViewId",
                        column: x => x.ViewId,
                        principalSchema: "Security",
                        principalTable: "View",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "PolicyRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "212695e5-c009-4add-816c-01468ba2a287", "78fb1b2e-818a-455f-b646-ba38be3e9fc2", "Admin", "Admin" });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "PolicyUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c1738f1f-5c2c-43e0-add4-e5d833fff4fe", 0, "3d0fa1d7-fc8b-41fd-8100-628d42272973", "IdentityUser", "livingstone23@gmail.com", false, false, null, "livingstone23@gmail.com", "livingstone23@gmail.com", "AQAAAAEAACcQAAAAEBhDQjwb3dmQbkTIbJZCmoOzVhA2hPLG7RX0AyjUxiwFdAaE8VoNhiyJ3l/Xge/xbA==", null, false, "7ccb38ab-b46c-4c22-a032-aedb82d05e61", false, "livingstone23@gmail.com" });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "PolicyUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin", "c1738f1f-5c2c-43e0-add4-e5d833fff4fe" });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Security",
                table: "PolicyRole",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRoleClaims_RoleId",
                schema: "Security",
                table: "PolicyRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Security",
                table: "PolicyUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyUser_Email",
                schema: "Security",
                table: "PolicyUser",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Security",
                table: "PolicyUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyUserLogins_UserId",
                schema: "Security",
                table: "PolicyUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyUserRol_PolicyUserId",
                schema: "Security",
                table: "PolicyUserRol",
                column: "PolicyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyUserRol_RoleId",
                schema: "Security",
                table: "PolicyUserRol",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAction_ActionId",
                schema: "Security",
                table: "RoleAction",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAction_ViewId",
                schema: "Security",
                table: "RoleAction",
                column: "ViewId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleHistory_CreatedId",
                schema: "Security",
                table: "UserRoleHistory",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_View_ActionOid",
                schema: "Security",
                table: "View",
                column: "ActionOid");

            migrationBuilder.CreateIndex(
                name: "IX_View_ApplicativeId",
                schema: "Security",
                table: "View",
                column: "ApplicativeId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewAction_ActiondId",
                schema: "Security",
                table: "ViewAction",
                column: "ActiondId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewAction_ApplicativeOid",
                schema: "Security",
                table: "ViewAction",
                column: "ApplicativeOid");

            migrationBuilder.CreateIndex(
                name: "IX_ViewAction_ViewId",
                schema: "Security",
                table: "ViewAction",
                column: "ViewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyRoleClaims",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "PolicyUserClaims",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "PolicyUserLogins",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "PolicyUserRol",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "PolicyUserTokens",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "RoleAction",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserRoleHistory",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "ViewAction",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "PolicyRole",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "PolicyUser",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "View",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Action",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Applicative",
                schema: "Security");
        }
    }
}
