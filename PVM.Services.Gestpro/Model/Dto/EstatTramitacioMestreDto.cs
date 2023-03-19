namespace PVM.Services.Gestpro.Model.Dto
{
    public class EstatTramitacioMestreDto
    {

        public int IdEstatTramitacio { get; set; }
        public int? Estat { get; set; }
        public bool? GenerarTxt { get; set; }

        public bool? Validacio { get; set; }
        public bool? Habilitada { get; set; }
        public string Cos { get; set; }
        public string Subject { get; set; }
        public string MailFrom { get; set; }
        public string MailCC { get; set; }
        public string MailCCO { get; set; }
        public string Nombre { get; set; }
        public bool? InformarPartner { get; set; }
        public bool? Facturable { get; set; }
        public bool? InformarCliente { get; set; }



        //Campos de control
        public string tzDelUser { get; set; }
        public string tzUpdUser { get; set; }
        public string tzInsUser { get; set; }
        public DateTime? tzDelDate { get; set; }
        public DateTime? tzUpdDate { get; set; }
        public DateTime? tzInsDate { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }

    }
}
