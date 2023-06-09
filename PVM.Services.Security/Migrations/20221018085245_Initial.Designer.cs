﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PVM.Services.Security.DbContexts;

#nullable disable

namespace PVM.Services.Security.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221018085245_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("PolicyRole", "Security");

                    b.HasData(
                        new
                        {
                            Id = "212695e5-c009-4add-816c-01468ba2a287",
                            ConcurrencyStamp = "78fb1b2e-818a-455f-b646-ba38be3e9fc2",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("PolicyRoleClaims", "Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("PolicyUser", "Security");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.HasData(
                        new
                        {
                            Id = "c1738f1f-5c2c-43e0-add4-e5d833fff4fe",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3d0fa1d7-fc8b-41fd-8100-628d42272973",
                            Email = "livingstone23@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "livingstone23@gmail.com",
                            NormalizedUserName = "livingstone23@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEBhDQjwb3dmQbkTIbJZCmoOzVhA2hPLG7RX0AyjUxiwFdAaE8VoNhiyJ3l/Xge/xbA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7ccb38ab-b46c-4c22-a032-aedb82d05e61",
                            TwoFactorEnabled = false,
                            UserName = "livingstone23@gmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PolicyUserClaims", "Security");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "Admin",
                            UserId = "c1738f1f-5c2c-43e0-add4-e5d833fff4fe"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("PolicyUserLogins", "Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("PolicyUserRol", "Security");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<string>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("PolicyUserTokens", "Security");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.Action", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GCRecord")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OptimisticLockField")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Oid");

                    b.ToTable("Action", "Security");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.Applicative", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GCRecord")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OptimisticLockField")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Oid");

                    b.ToTable("Applicative", "Security");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.Dto.View", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ActionOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicativeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssemblyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GCRecord")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OptimisticLockField")
                        .HasColumnType("int");

                    b.Property<Guid?>("Parent")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Oid");

                    b.HasIndex("ActionOid");

                    b.HasIndex("ApplicativeId");

                    b.ToTable("View", "Security");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.RoleAction", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("GCRecord")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("OptimisticLockField")
                        .HasColumnType("int");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ViewId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Oid");

                    b.HasIndex("ActionId");

                    b.HasIndex("ViewId");

                    b.ToTable("RoleAction", "Security");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.UserRoleHistory", b =>
                {
                    b.Property<int>("UserRoleHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRoleHistoryId"), 1L, 1);

                    b.Property<string>("CreatedId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("GCRecord")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("OptimisticLockField")
                        .HasColumnType("int");

                    b.Property<string>("PermissionRoleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PolicyUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserRoleId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleHistoryId");

                    b.HasIndex("CreatedId");

                    b.ToTable("UserRoleHistory", "Security");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.ViewAction", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActiondId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicativeOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GCRecord")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("OptimisticLockField")
                        .HasColumnType("int");

                    b.Property<Guid>("ViewId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Oid");

                    b.HasIndex("ActiondId");

                    b.HasIndex("ApplicativeOid");

                    b.HasIndex("ViewId");

                    b.ToTable("ViewAction", "Security");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.PolicyUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<bool>("ChangePasswordOnFirstLogon")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GCRecord")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OptimisticLockField")
                        .HasColumnType("int");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("PolicyUser", "Security");

                    b.HasDiscriminator().HasValue("PolicyUser");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.PolicyUserRol", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<string>");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GCRecord")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("OptimisticLockField")
                        .HasColumnType("int");

                    b.Property<string>("PolicyUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("PolicyUserId");

                    b.ToTable("PolicyUserRol", "Security");

                    b.HasDiscriminator().HasValue("PolicyUserRol");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PVM.Services.Security.Model.Dto.View", b =>
                {
                    b.HasOne("PVM.Services.Security.Model.Action", null)
                        .WithMany("Views")
                        .HasForeignKey("ActionOid");

                    b.HasOne("PVM.Services.Security.Model.Applicative", "Applicative")
                        .WithMany("Views")
                        .HasForeignKey("ApplicativeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicative");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.RoleAction", b =>
                {
                    b.HasOne("PVM.Services.Security.Model.Action", "Action")
                        .WithMany("RoleAction")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PVM.Services.Security.Model.Dto.View", "View")
                        .WithMany("RoleAction")
                        .HasForeignKey("ViewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("View");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.UserRoleHistory", b =>
                {
                    b.HasOne("PVM.Services.Security.Model.PolicyUser", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedId");

                    b.Navigation("CreatedUser");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.ViewAction", b =>
                {
                    b.HasOne("PVM.Services.Security.Model.Action", "Action")
                        .WithMany()
                        .HasForeignKey("ActiondId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PVM.Services.Security.Model.Applicative", null)
                        .WithMany("ViewActions")
                        .HasForeignKey("ApplicativeOid");

                    b.HasOne("PVM.Services.Security.Model.Dto.View", "View")
                        .WithMany()
                        .HasForeignKey("ViewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("View");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.PolicyUserRol", b =>
                {
                    b.HasOne("PVM.Services.Security.Model.PolicyUser", null)
                        .WithMany("Roles")
                        .HasForeignKey("PolicyUserId");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.Action", b =>
                {
                    b.Navigation("RoleAction");

                    b.Navigation("Views");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.Applicative", b =>
                {
                    b.Navigation("ViewActions");

                    b.Navigation("Views");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.Dto.View", b =>
                {
                    b.Navigation("RoleAction");
                });

            modelBuilder.Entity("PVM.Services.Security.Model.PolicyUser", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
