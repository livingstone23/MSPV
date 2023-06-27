namespace PVM.Web
{
    public static class SD
    {

        //public static string SecurityApiBase { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }



        //Seccion de Roles
        public const string Role_Admin = "Admin";
        public const string Role_Customer = "Customer";
        public const string Role_Employee = "Employee";


        //Seccion de LocalStorage
        public const string Local_InitialLoading = "InitiaProvimadInfo";
        //public const string Local_RoomOrderDetails = "RoomOrderDetails";
        public const string Local_Token = "JWT Token";
        public const string Local_UserDetails = "User Details";


        public static string ApiNotifications = "https://localhost:7040";
        public static string ApiSecurity = "https://localhost:7010";

    }
}
