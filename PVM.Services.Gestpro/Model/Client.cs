using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PVM.Services.Gestpro.Model
{
    /// <summary>
    /// Tabla para el manejo de los clientes.
    /// </summary>
    [Table("Cli", Schema = "dbo")]
    public class Client
    {
        [Key]
        public int IdCli { get; set; }

        public string RaoSocial { get; set; }

        public String Cognom1 { get; set; }

        public String Cognom2 { get; set; }

        public int? CodiFact { get; set; }


        public string CIF { get; set; }
        public string Adr { get; set; }
        public string CP { get; set; }
        public int? IdProv { get; set; }
        public int? IdPob { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string PersonaCte { get; set; }
        public string ValorIdioma { get; set; }


        public int? IdFormaP { get; set; }
        public string NCEntitat { get; set; }
        public string NCOficina { get; set; }
        public string NCDC { get; set; }
        public string NCCompte { get; set; }

        public int? ValorPeriodFact { get; set; }
        public int? ValorIntFormatFactura { get; set; }
        public short? swIRPF { get; set; }
        public short? swCobrarFoto { get; set; }
        public short? swComandaUnica { get; set; }
        public short? swFactSoli { get; set; }
        public short? swLlistaPrevi { get; set; }
        public short? swVerificarInf { get; set; }
        public short? swSegonaFact { get; set; }
        public short? swN19 { get; set; }
        public int? IdEmpAux { get; set; }
        public short? swCopiar { get; set; }
        public int? ValorFormatCopia { get; set; }
        public short? PlacDies { get; set; }
        public short? PlacDiesUrgent { get; set; }



        ////bY HELPER
        //public short swRapel;
        //public decimal Rapel;
        //public short swPreuEspecial;
        //public int IdTar;
        //public int ComUltTrim;
        //public int ComUltSem;
        //public int ComTotal;
        //public string Obs;
        //public short swEsperarComandesAcabades;
        //public short swNoEnviarEmailIndex;
        //public int ModelInforme;
        //public short swNoImprimirComandes;
        //public short swDel;
        //public DateTime tzInsDate;
        //public DateTime tzUpdDate;
        //public DateTime tzDelDate;
        //public string tzInsUser;
        //public string tzUpdUser;
        //public string tzDelUser;
        //public byte[] tzTimeStamp;
        //public int OptimisticLockField;
        //public int GCRecord;
        //public short PlacDiesCert;
        //public short PlacDiesCertUrgent;
        //public short EnviarPubli;
        //public short Actiu;
        //public int TipusClient;
        //public int IdDBF;
        //public string SerieFacturacio;
        //public string ReferenciaWeb;
        //public string EstilWebeNotifica;
        //public bool UsuarisVeuenDadesTotaOficina;
        //public bool AgruparAlbaransPerOficina;
        //public bool swEnviarComandesPerMail;
        //public string CodiProv;
        //public bool swDomiciliacioBancaria;
        //public Guid ArxiuAutoritzacio;
        //public string CodiAssociat;
        //public string TextoRemitenteBurofax;
        //public bool swActivarTramitacion;
        //public string CarpetaClienteTramitacion;
        //public bool swActivarTramitacio;
        //public string CarpetaClientTramitacio;
        //public int RegistreMercantil;
        //public int DomiciliCorpme;
        //public int ClientETramitacio;
        //public string CodiAssociatCorpme;
        //public string NomPresentantCorpme;
        //public string NumeroDocumentoPresentantCorpme;
        //public Guid TipusViaPresentantCorpme;
        //public string NomViaPresentantCorpme;
        //public string NumeroViaPresentantCorpme;
        //public double ProvinciaPresentantCorpme;
        //public Guid MunicipioPresentantCorpme;
        //public string CodigoPostalPresentantCorpme;
        //public string CorreuElectronicPresentantCorpme;
        //public string TelefonPresentantCorpme;
        //public string FaxPresentantCorpme;
        //public string PaisPresentantCorpme;
        //public string ApellidoPresentantCorpme;
        //public string NumeroViaCli;
        //public double IRPFCorpme;
        //public bool ActivarSubCarpeta;
        //public double SLA;
        //public double SLAUrgent;
        //public bool EstadistiquesPerExpedient;
        //public bool EnviarEstadistiquesEmail;
        //public string EmailEnviamentEstadistiques;
        //public bool VeureEstadistiques;
        //public bool GestionarIncidencies;
        //public bool TotesComandes;
        //public string CSS;
        //public string PatternFicheroMail;
        //public bool IncluirInformacionTercero;
        //public int RelatedCli;
        //public string PasswordCertificado;
        //public string CodCliCorreos;
        //public string NumSerieCertificat;
        //public bool GenerarXML;
        //public bool ServicioCSVHabilitado;
        //public Guid FormatoReporteCancelacion;
        //public int OpcionAcreditacionCSV;
        //public int CanalNotificacionCSV;
        //public bool ModuloEsperaTramHabilitado;
        //public int DiasEsperaTramPresentacion;
        //public int DiasEsperaTramAplazado;
        //public int DiasEsperaTramCancelado;
        //public int DiasEsperaTramEliminado;
        //public bool FacturacionExterna;
        //public int OrigenAltaTramitacion;
        //public int TipoVersionWebPrestelRBM;
        //public string PartnerReference;
        //public string CodigoEntidadCorpme;
        //public bool GenerarInformePrestel;
        //public int ClienteFacturacionRBM;
        //public bool FirmaYEnvioCORPMEAutomatico;
        //public string EmailContactoWebPrestelRBM;
        //public string CPFlotiReqUserId;
        //public string CPFlotiProjectCode;
        //public int TiempoValidezToken;
        //public short TiempoValidezClaves;




    }

}
