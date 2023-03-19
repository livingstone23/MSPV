namespace PVM.Web.Models.Notifications
{
    public class BillDto
    {
        public string NumFactura { get; set; }

        public DateTime FechaFactura { get; set; }

        public DateTime FechaEnvioCXB { get; set; }

        public string EstadoFactura { get; set; }

        public decimal BaseImponible { get; set; }

        public string TipoRepercutido { get; set; }

        public decimal ImporteRepercutido { get; set; }

        public decimal TotalCobrar { get; set; }

    }
}
