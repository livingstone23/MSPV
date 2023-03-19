namespace WebApiTemplate.DTOs
{
    public class DataHATEOAS
    {

        public string _link { get; set; }
        public string _description { get; set; }
        public string _method { get; set; }


        public DataHATEOAS(string link,string description, string method)
        {
             _link = link;
             _description = description;
             _method = method;

        }



    }


}
