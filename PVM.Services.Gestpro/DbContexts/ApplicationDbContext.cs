using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PVM.Services.Gestpro.Model;

namespace PVM.Services.Gestpro.DbContexts
{
    public class ApplicationDbContext : DbContext
    {

        //Constructor requerido para las pruebas unitarias.
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        //public ApplicationDbContext(DbContextOptions options) : base(options)
        //{
        //}

        //public ApplicationDbContext(ApplicationDbContext context, DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{

        //    //Importante si se ha escrito el OnModelCreating para que funcione el Identity
        //    base.OnModelCreating(builder);

        //}





        //public DbSet<EstatTramitacio> EstatTramitacios { get; set; }

        

        //public DbSet<ETramitacio> ETramitacios { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<EstatTramitacio> EstatTramitacios { get; set; }

        public virtual DbSet<EstatTramitacioMestre> EstatTramitacioMestres { get; set; }

        public virtual DbSet<ETramitacio> ETramitacios { get; set; }

        public virtual DbSet<Register> Registers { get; set; }
        


    }
}
