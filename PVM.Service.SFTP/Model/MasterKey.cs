using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.SFTP.Model
{
    /// <summary>
    /// Estructura para definicion de llave de envio en el Mensaje
    /// </summary>
    public class MasterKey
    {

        [Key]
        public  Guid Id { get; set; }

        public string Name { get; set; }


        public string Description { get; set; }
        public DateTime UntilValid { get; set; }

        //Campos de control
        [ForeignKey("Client")]
        public Guid IdClient { get; set; }
        public Client Client { get; set; }

    }
}
