using Microsoft.EntityFrameworkCore;
using PVM.Services.Alert.Gestion;


namespace PVM.Services.Alert.DbContexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PrefijoPais> PrefijosPaises { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<FileData> FilesData { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        //public DbSet<Proveedor> Proveedores { get; set; }




    }
}
