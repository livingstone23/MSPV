using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Services.Gestpro.Model.Dto
{
    public class RegisterDto
    {
        public Guid Oid { get; set; }

        public String Tipo { get; set; }

        [Column("Código")]
        public double? Codigo { get; set; }

        public string Nombre { get; set; }

        public string Dirección { get; set; }

        public string Municipio { get; set; }

        [Column("Código Provincia")]
        public double? ProvinceCode { get; set; }

        [Column("Código Postal")]
        public double? PostalCode { get; set; }

        public string Email { get; set; }

        public double? Fax { get; set; }

        [Column("Teléfono")]
        public double? Telephone { get; set; }

        public string Observaciones { get; set; }

        public string DescRegistroTitular { get; set; }

        public string Cif { get; set; }

    }
}
