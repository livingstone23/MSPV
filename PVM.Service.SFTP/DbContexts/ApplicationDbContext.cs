using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PVM.Service.SFTP.DbContexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }








    }
}
