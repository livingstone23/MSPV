using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Services.Gestpro.Model
{
    /// <summary>
    /// Catalogo para el manejo de los registros
    /// </summary>
    [Table("CORPME_Registros", Schema = "dbo")]
    public class Register
    {
        [Key]
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


        //Relaciones 
        public ICollection<ETramitacio> ETramitacios { get; set;}
    }
}
