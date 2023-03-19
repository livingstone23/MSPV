namespace PVM.Services.Security.Model
{
    //Clase para manejo de respuesta del token
    public class AuthenticationAnswer
    {
        //Cadena del token
        public string Token { get; set; }

        //Fecha de caducidad del token
        public DateTime Expiration { get; set; }
    }
}
