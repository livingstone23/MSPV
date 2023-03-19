namespace PVM.Service.SFTP.Model
{
    /// <summary>
    /// Estructura que permite definir si el tipo de transaccion es un
    /// Tramite, Cancelacion o Pedido.
    /// </summary>
    public class TypeTransaction
    {
        public Guid id { get; set; }
        public string name { get; set; }

        public string Code { get; set; }

        public string description { get; set; }


        /// <summary>
        /// Codigo de equivalencia en la aplicacion a mapear.
        /// </summary>
        public string Equivalence { get; set; }

    }
}
