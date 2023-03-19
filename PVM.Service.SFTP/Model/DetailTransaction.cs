using System.ComponentModel.DataAnnotations;

namespace PVM.Service.SFTP.Model
{
    /// <summary>
    /// Estructura principal que permite mapear un Registro Gespro
    /// Un registro es equivalente a un Tramite, Cancelacion o Pedido.
    /// LCANO 2023/03/14
    /// </summary>
    public class DetailTransaction
    {
        [Key]
        public Guid Id { get; set; }




    }
}
