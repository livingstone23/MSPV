using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PVM.Services.Security.Model;
using PVM.Services.Security.Model.Dto;
using Action = PVM.Services.Security.Model.Action;

namespace PVM.Services.Security.DbContexts;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
       
        base.OnModelCreating(builder);
        builder.Ignore<IdentityUserClaim<string>>();

        SeedData(builder);
        
        builder.Entity<IdentityUser>().ToTable("PolicyUser", "Security");
        builder.Entity<IdentityRole>().ToTable("PolicyRole", "Security");
        builder.Entity<IdentityUserClaim<string>>().ToTable("PolicyUserClaims", "Security");
        builder.Entity<IdentityUserRole<string>>().ToTable("PolicyUserRol", "Security");
        builder.Entity<IdentityUserLogin<string>>().ToTable("PolicyUserLogins", "Security");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("PolicyRoleClaims", "Security");
        builder.Entity<IdentityUserToken<string>>().ToTable("PolicyUserTokens", "Security");

    }


    #region TablasIdentity



    #endregion


    public DbSet<Action> Actions { get; set; }
    public DbSet<Applicative> Applicatives { get; set; }
    public DbSet<RoleAction> RoleActions { get; set; }
    public DbSet<UserRoleHistory> UserRoleHistories { get; set; }
    public DbSet<View> Views { get; set; }
    public DbSet<ViewAction> ViewActions { get; set; }

    public DbSet<PolicyUser> ApplicationUser { get; set; }
    public DbSet<PolicyUserRol> PolicyUserRoles { get; set; }


    private void SeedData(ModelBuilder modelBuilder)
    {
        var rolAdminId = "212695e5-c009-4add-816c-01468ba2a287";
        var usuarioAdminId = "c1738f1f-5c2c-43e0-add4-e5d833fff4fe";


        var rolAdmin = new IdentityRole()
        {
            Id = rolAdminId,
            Name = "Admin",
            NormalizedName = "Admin"
        };


        var passwordHasher = new PasswordHasher<IdentityUser>();

        var userName = "livingstone23@gmail.com";


        var userAdmin = new IdentityUser()
        {
            Id = usuarioAdminId,
            UserName = userName,
            NormalizedUserName = userName,
            Email = userName,
            NormalizedEmail = userName,
            PasswordHash = passwordHasher.HashPassword(null, "Aa123456!")
        };


        modelBuilder.Entity<IdentityUser>()
            .HasData(userAdmin);

        modelBuilder.Entity<IdentityRole>()
            .HasData(rolAdmin);


        modelBuilder.Entity<IdentityUserClaim<String>>()
            .HasData(new IdentityUserClaim<string>
            {
                Id = 1,
                ClaimType = ClaimTypes.Role,
                UserId = usuarioAdminId,
                ClaimValue = "Admin"
            });


    }


}

