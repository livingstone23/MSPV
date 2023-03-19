using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Services.Alert
{
    [Table("FileData", Schema = "dbo")]
    public class FileData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Oid { get; set; }
        public int size { get; set; }
        public string FileName { get; set; }
        public Byte[] Content { get; set; }
        public int OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
    }
}
