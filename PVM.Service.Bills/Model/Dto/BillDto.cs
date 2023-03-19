using System.ComponentModel.DataAnnotations;

namespace PVM.Service.Bills.Model.Dto
{
    //public class BillDto1
    //{
    //    public Guid Oid { get; set; }
    //    public String Code { get; set; }
    //    public string Name { get; set; }
    //    public string Type { get; set; }




    //    //Campos de control
    //    public bool IsActive { get; set; }
    //    public int? OptimisticLockField { get; set; }
    //    public DateTime DateCreated { get; set; }
    //    public DateTime DateModified { get; set; }
    //    public int? GCRecord { get; set; }

    //}

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
