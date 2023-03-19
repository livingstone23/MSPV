using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Models;

namespace WebApiTemplate.Context
{
    /// <summary>
    /// lcano-07.01 en la configuracion del Identity, habilita el trabajar con el contexto
    /// </summary>
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            SeedData(builder);

            //Importante si se ha escrito el OnModelCreating para que funcione el Identity
            base.OnModelCreating(builder);

        }

        public DbSet<Author> Autores { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Comentary> Comentaries { get; set; }




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


            //var userAdmin = new IdentityUser()
            //{
            //    Id = usuarioAdminId,
            //    UserName = userName,
            //    NormalizedUserName = userName,
            //    Email = userName,
            //    NormalizedEmail = userName,
            //    PasswordHash = passwordHasher.HashPassword(null, "Aa123456!")
            //};


            //modelBuilder.Entity<IdentityUser>()
            //    .HasData(userAdmin);

            //modelBuilder.Entity<IdentityRole>()
            //    .HasData(rolAdmin);


            //modelBuilder.Entity<IdentityUserClaim<String>>()
            //    .HasData(new IdentityUserClaim<string>
            //    {
            //        Id = 1,
            //        ClaimType = ClaimTypes.Role,
            //        UserId = usuarioAdminId,
            //        ClaimValue = "Admin"
            //    });


        }

    }



    

}
