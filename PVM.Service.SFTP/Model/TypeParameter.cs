using System.ComponentModel.DataAnnotations;

namespace PVM.Service.SFTP.Model
{
    public class TypeParameter
    {

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
        //Campos de control




        //En esta seccion puedo defini los tipos de parametros
        //Logitud de fichero
        //tipos de ficheros
        //ruta a registrar por llave
    }
}
