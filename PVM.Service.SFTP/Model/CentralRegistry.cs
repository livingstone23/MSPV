using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.SFTP.Model
{
    public class CentralRegistry
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        //Llave enviada por el cliente para definir el parametro donde carga del proyecto
        //En ella se puede definir hasta la ruta de almacenaje.
        [MaxLength(50)]
        public string KeyRegister { get; set; }


        //Campos de control
        [ForeignKey("Client")]
        public int IdClient { get; set; }
        public Client Client { get; set; }

        [ForeignKey("User")]
        public Guid IdUser { get; set; }
        public User User { get; set; }


    }
}
