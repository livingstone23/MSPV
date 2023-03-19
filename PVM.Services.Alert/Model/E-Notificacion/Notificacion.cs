using PVM.Services.Alert.Gestion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Services.Alert
{
    [Table("Notificacion", Schema = "dbo")]
    public class Notificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Oid { get; set; }
        public Subscription Subscription { get; set; }
        [ForeignKey("Subscription")]
        public Guid SubscriptionId { get; set; }
        public string ReferenciaEnvio { get; set; }
        public string ReferenciaIdClienteU { get; set; }
        public string ReferenciaIdClienteD { get; set; }
		public string ReferenciaIdContrato  { get; set; }
		public string ReferenciaIdCuenta { get; set; }
		public string ReferenciaIdClaveFactura { get; set; }
		public int PlazoJuridico { get; set; }
        public string BuzonRecepcion { get; set; } //D
		public string EmailAlternativo { get; set; }
        public string TipoFichero { get; set; }
        public FileData Archivo { get; set; } ///
        [ForeignKey("Archivo")]
        public Guid ArchivoId { get; set; }
        public bool AceptarDocumento { get; set; }
		public bool CodigoCSV { get; set; }
		public int TipoEnvio { get; set; }
		public string ModoEnvio { get; set; }
		public DateTime? FechaEntrada { get; set; }
		public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Movil { get; set; }
        public string Email { get; set; }
        public int Proveedor { get; set; }
        public Cliente Cliente { get; set; } //D
        //[ForeignKey("Cliente")]
        //public Guid ClienteId { get; set; }
        public int Canal { get; set; }
        public string Empresa { get; set; }
        public string ReferenciaOperador { get; set; }
        public int Producto { get; set; }
        public string NumeroContrato { get; set; }
        public string TipoNotificacion { get; set; }
        public string Causa { get; set; }
        public int Pais { get; set; }
        public string Provincia { get; set; }
        public string Poblacion { get; set; }
        public string TipoVia { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Bloque { get; set; }
        public string Escalera { get; set; }
        public string Planta { get; set; }
        public string Puerta { get; set; }
        public string KM { get; set; }
        public string CodigoPostal { get; set; }
        public string EstadoEnvio { get; set; }
        public string EstadoOperador { get; set; }
        public string Oficina { get; set; }
        //public bool Enviado { get; set; }
        //public string Identificador { get; set; }
        //public string Usuario { get; set; }
        //public int Idioma { get; set; }
        //public DateTime? FechaSolicitud { get; set; }
        //public int Trato { get; set; }
        //public PrefijoPais PrefijoPais { get; set; }
        //public bool AdjuntarPDF { get; set; }
        //public bool AdjuntarZIP { get; set; }
        //public PaisISO PaisISO { get; set; }
        //public bool Acuse { get; set; }
        //public bool Copia { get; set; }
        //public bool EntregaExclusiva { get; set; }
        //public bool EntregaExclusivaPass { get; set; }
        //public string ReferenciaGeneral { get; set; }
        //public int NumeroEnvio { get; set; }
        //public string CausaCancelacion { get; set; }
        //public string ComentarioCausaCancelacion { get; set; }
        //public string ReferenciaFactura { get; set; }
        public int OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
    }
}
