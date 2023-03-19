using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PVM.Service.SFTP.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string Equivalence { get; set; }




        //Campos de control
        [ForeignKey("Client")]
        public Guid IdClient { get; set; }
        public Client Client { get; set; }

        

    }
}
