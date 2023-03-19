using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PVM.Services.Gestpro.Model;

namespace PVM.Services.Gestpro.DbContexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{

        //    //Importante si se ha escrito el OnModelCreating para que funcione el Identity
        //    base.OnModelCreating(builder);

        //}





        //public DbSet<EstatTramitacio> EstatTramitacios { get; set; }

        

        //public DbSet<ETramitacio> ETramitacios { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<EstatTramitacio> EstatTramitacios { get; set; }

        public DbSet<EstatTramitacioMestre> EstatTramitacioMestres { get; set; }

        public DbSet<ETramitacio> ETramitacios { get; set; }

        public DbSet<Register> Registers { get; set; }
        


    }
}
