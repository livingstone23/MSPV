using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Services.Alert.Gestion
{
    [Table("Provincia", Schema = "dbo")]
    public class Provincia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Oid { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
    }
}
