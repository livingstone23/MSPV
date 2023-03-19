using PVM.Services.Gestpro.Model;

namespace PVM.Service.Gestpro.Model.Dto
{
    public class ETramitacioSearchResult
    {
        public List<ETramitacio> ETramitacios { get; set; } = new List<ETramitacio>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
