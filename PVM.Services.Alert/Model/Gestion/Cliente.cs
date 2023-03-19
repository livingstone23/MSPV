using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Services.Alert.Gestion
{
    [Table("Cliente", Schema = "dbo")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Oid { get; set; }
        public Subscription Subscription { get; set; }
        [ForeignKey("Subscription")]
        public Guid SubscriptionId { get; set; }
        public string Code { get; set; }
		public string Name { get; set; }
		public string IdentificationNumber { get; set; }
		public string IdentificationType { get; set; }
		public string CompanyCode { get; set; }
		public string CorreosOnlineCode { get; set; }
		public string ClientDetail { get; set; }
		public string StreetType { get; set; }
		public string StreetName { get; set; }
		public string StreetNumber { get; set; }
		public string Building { get; set; }
		public string Floor { get; set; }
		public string Portal { get; set; }
		public string Block { get; set; }
		public string Stairs { get; set; }
		public string DoorNumber { get; set; }
		public string Province { get; set; }
		public string Town { get; set; }
		public string PostalCode { get; set; }
		public string Phone { get; set; }
		public string Fax { get; set; }
		//public string PlantillaWord { get; set; }
		//public string URL { get; set; }
		//public string ModeloPassword { get; set; }
		public int OptimisticLockField { get; set; }
		public int? GCRecord { get; set; }



    }
}
