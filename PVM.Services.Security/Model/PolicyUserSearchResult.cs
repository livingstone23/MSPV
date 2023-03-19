using System.ComponentModel.DataAnnotations;

namespace PVM.Services.Security.Model;

public class PolicyUserSearchResult
{


    public int Pages { get; set; }
    public int CurrentPage { get; set; }


    public List<PolicyUser> PolicyUsers { get; set; } = new List<PolicyUser>();


}