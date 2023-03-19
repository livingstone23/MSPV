using Microsoft.EntityFrameworkCore;
using PVM.Service.Notifications.Model;

namespace PVM.Service.Notifications.DbContexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }



        public DbSet<GeneralOffice> GeneralOffices { get; set; }

        public DbSet<GeneralOfficeUser> GeneralOfficeUsers { get; set; }
        public DbSet<GeneralService> GeneralServices { get; set; }
        public DbSet<GeneralSubservice> GeneralSubservices { get; set; }


    }
}
