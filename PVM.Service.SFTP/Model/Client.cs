using System.ComponentModel.DataAnnotations;

namespace PVM.Service.SFTP.Model
{
    public class Client
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string CodeEquivalence { get; set; }

    }
}
