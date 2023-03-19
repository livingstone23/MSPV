using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Services.Alert.Gestion
{
    [Table("PrefijoPais", Schema = "dbo")]
    public class PrefijoPais
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Oid { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string Prefijo { get; set; }
        public string NombrePais { get; set; }
        public int OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }

    }
}
