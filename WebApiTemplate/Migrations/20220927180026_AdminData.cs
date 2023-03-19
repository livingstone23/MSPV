using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiTemplate.Migrations
{
    public partial class AdminData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
                
            BEGIN TRANSACTION;
            GO


            IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
                SET IDENTITY_INSERT [AspNetRoles] ON;
            INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
            VALUES (N'212695e5-c009-4add-816c-01468ba2a287', N'd53c8878-5435-42ae-b24d-0ace38eedeed', N'Admin', N'Admin');
            IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
                SET IDENTITY_INSERT [AspNetRoles] OFF;
            GO

            IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
                SET IDENTITY_INSERT [AspNetUsers] ON;
            INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
            VALUES (N'c1738f1f-5c2c-43e0-add4-e5d833fff4fe', 0, N'3fa09d4c-d1cf-4ada-93f0-ee3f04de6544', N'livingstone23@gmail.com', CAST(0 AS bit), CAST(0 AS bit), NULL, N'livingstone23@gmail.com', N'livingstone23@gmail.com', N'AQAAAAEAACcQAAAAEOJuCEc3CG0oxTTvBpNzoO0oU2mLYx1kX3mDoq5y0F2UoDtafkvWoDY6fLorHB6MxQ==', NULL, CAST(0 AS bit), N'29844671-a2bd-4897-8e13-a3f2f98de338', CAST(0 AS bit), N'livingstone23@gmail.com');
            IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
                SET IDENTITY_INSERT [AspNetUsers] OFF;
            GO

            IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClaimType', N'ClaimValue', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserClaims]'))
                SET IDENTITY_INSERT [AspNetUserClaims] ON;
            INSERT INTO [AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId])
            VALUES (1, N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'Admin', N'c1738f1f-5c2c-43e0-add4-e5d833fff4fe');
            IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClaimType', N'ClaimValue', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserClaims]'))
                SET IDENTITY_INSERT [AspNetUserClaims] OFF;
            GO


            COMMIT;
            GO

            ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "212695e5-c009-4add-816c-01468ba2a287");

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1738f1f-5c2c-43e0-add4-e5d833fff4fe");

        }
    }
}
