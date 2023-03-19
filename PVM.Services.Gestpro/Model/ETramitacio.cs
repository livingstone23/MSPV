using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Services.Gestpro.Model
{

    /// <summary>
    /// Clase para la gestion de los tramites
    /// </summary>
    [Table("ETramitacio", Schema = "dbo")]
    public class ETramitacio
    {

        [Key]
        public int IdETramitacio { get; set; }
        public string NombreOperacio { get; set; }
        public DateTime? DataCreacio { get; set; }
        public string NomAsociacio { get; set; }
        public int? NombreExemplar { get; set; }
        public string ModelContracte { get; set; }
        public string NomDocument { get; set; }
        public string AprovatDGRN { get; set; }
        public string NombreImpres { get; set; }
        
        public string Observacions { get; set; }



        public int? DadaFinancera { get; set; }
        public int? CondicionesGenerales { get; set; }
        public int? CondicionesPartirculares { get; set; }
        public int? idCli { get; set; }
        public string NumEntradaCorpme { get; set; }
        public int? OrigenETramitacio { get; set; }
        public int? DadesRegistreMercantil { get; set; }
        public int? DadaFinanceraFinanciacio { get; set; }
        public int? TipuseTramitacio { get; set; }
        public bool? Finalitzat { get; set; }
        public DateTime? DataEstatFacturacio { get; set; }
        public int? RelatedFacLin { get; set; }
        public int? EFactura { get; set; }
        public string TipusEntrada { get; set; }
        public string TipusOperacio { get; set; }
        public int? RelatedEtramitacio { get; set; }
        public int? TipusFacturacioCorpme { get; set; }
        
        public string NumAsiento { get; set; }
        public DateTime? FechaAsiento { get; set; }
        public int? NumPresentacio { get; set; }
        public string IDTramite { get; set; }
        public string TextoSolicitudDesistimiento { get; set; }
        public string LugarDesistimiento { get; set; }
        public DateTime? FechaDesistimiento { get; set; }
        public string LugarFirma { get; set; }
        public DateTime? FechaFirma { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaVencimientoAsiento { get; set; }
        public string NombreFicheroOriginal { get; set; }
        public int? Servicio { get; set; }
        public bool? TieneDefecto { get; set; }
        public bool? EsDesistimiento { get; set; }
        public int? TipusFirma { get; set; }
        public string CodigoIdenfiticativo { get; set; }
        public int? TipusAccio { get; set; }
        public string NombreAsiento { get; set; }
        public string CodigoRBM { get; set; }
        public string Diario { get; set; }
        public string Folio { get; set; }
        public bool? EsBienInmatriculado { get; set; }
        public int? IdCargaTramitacion { get; set; }
        public bool? GestionadoCanalPresencial { get; set; }
        public string PartnerReference { get; set; }
        public bool? PreparadoEnviar { get; set; }
        public bool? ErrorEnEnvio { get; set; }
        public DateTime? FechaTramiteFinalizado { get; set; }
        public DateTime? FechaRefEnvioPartner { get; set; }



        ////Campos de control

        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public string tzDelUser { get; set; }
        public string tzUpdUser { get; set; }
        public string tzInsUser { get; set; }
        public DateTime? tzDelDate { get; set; }
        public DateTime? tzUpdDate { get; set; }
        public DateTime? tzInsDate { get; set; }




        //Relaciones

        [ForeignKey("Register")]
        public Guid? RegistroPresentado { get; set; }
        public Register Register { get; set; }


        [ForeignKey("EstatTramitacioMestre")]
        public int? Estat { get; set; }
        public EstatTramitacioMestre EstatTramitacioMestre { get; set; }






        public ICollection<EstatTramitacio> EstatTramitacio { get; set; }





    }
}
