using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.SFTP.Model
{
    /// <summary>
    /// Estructura para definir detalles de la llave a enviar 
    /// </summary>
    public class MasterKeyDetail
    {
        [Key]
        public int Id { get; set; }


        //Campos de control
        [ForeignKey("MasterKey")]
        public Guid IdMasterKey { get; set; }
        public MasterKey MasterKey { get; set; }


        //Campos de control
        [ForeignKey("TypeParameter")]
        public Guid IdTypeParameter { get; set; }
        public TypeParameter TypeParameter { get; set; }


        public string Value { get; set; }
       

        public bool IsActive { get; set; }


        //Campos de control
    }
}
