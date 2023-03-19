using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PVM.Service.SFTP.Model
{
    public class CentralRegistryDetail
    {

        [Key]
        public int Id { get; set; }


        //Campos de control
        [ForeignKey("CentralRegistry")]
        public Guid IdCentralRegistry { get; set; }
        
        public CentralRegistry CentralRegistry { get; set; }

        
        [MaxLength(500)]
        [Required]
        public string FileName { get; set; }

        [MaxLength(400)]
        [Required]
        public string RouteFile { get; set; }


        public bool IsActive { get; set; }

    }
}
