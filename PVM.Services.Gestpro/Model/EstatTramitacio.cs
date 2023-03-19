using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Services.Gestpro.Model
{


    /// <summary>
    /// Tabla transaccional para el manejo de los estados por tramite.
    /// </summary>
    [Table("EstatTramitacio", Schema = "dbo")]
    public class EstatTramitacio
    {

        [Key]
        public int IdEstatTramitacio { get; set; }


        [ForeignKey("EstatTramitacioMestre")]
        public int? Estat { get; set; }
        public DateTime? Data { get; set; }
        public bool? JustificantRecepcio { get; set; }
        public Guid? Arxiu { get; set; }
        public Guid? ArxiuXML { get; set; }
        public string Observacions { get; set; }
        

        public string TextWS { get; set; }
        public bool? Enviado { get; set; }
        public bool? GenerarTxt { get; set; }
        public int? RelatedCancelacio { get; set; }
        public bool? GeneradoTxt { get; set; }
        public bool? Validat { get; set; }
        public int? Resultat { get; set; }
        public bool? Facturat { get; set; }
        public DateTime? DataEstatFacturacio { get; set; }
        public bool? Subsanado { get; set; }
        public int? NumObjetosPresentados { get; set; }
        public int? Factura { get; set; }
        public int? RelatedFacLin { get; set; }
        public string Avisos { get; set; }
        public string ValorIdMotivoDefecto { get; set; }
        public string OtrosMotivos { get; set; }
        public bool? Enviar { get; set; }
        public bool? Descartado { get; set; }
        public int? RBMFactura { get; set; }
        public bool? ReqRegistroAppExterna { get; set; }
        public string ReferenciaAppExterna { get; set; }
        public int? EstadoPrevioRef { get; set; }
        public Guid? ClaveAlterna { get; set; }
        public bool? InformadoPartner { get; set; }
        public DateTime? FechaCalificacion { get; set; }
        public bool? ErrorEnvioAcuse { get; set; }
        public bool? AcuseFehacienteEnviado { get; set; }
        public string CodigoRetornoAcuse { get; set; }
        public string DescripcionRetornoAcuse { get; set; }
        public bool? PreparadoEnviarAcuse { get; set; }
        public DateTime? FechaRefEnvioPartner { get; set; }
        public string RefEnvioParter { get; set; }



        //Campos de control
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }

        public string tzDelUser { get; set; }
        public string tzUpdUser { get; set; }
        public string tzInsUser { get; set; }
        public DateTime? tzDelDate { get; set; }
        public DateTime? tzUpdDate { get; set; }
        public DateTime? tzInsDate { get; set; }



        //Relaciones

        [ForeignKey("ETramitacio")]
        public int? RelatedETramitacio { get; set; }
        public ETramitacio ETramitacio { get; set; }


        
        public EstatTramitacioMestre EstatTramitacioMestre { get; set; }


    }


}
