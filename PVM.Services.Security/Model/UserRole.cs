using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PVM.Services.Security.Model
{

    [Table("PolicyUserRol", Schema = "Security")]
    public class PolicyUserRol: IdentityUserRole<string>
    {





        //Campos de control
        public bool IsActive { get; set; }
        public int? OptimisticLockField { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int? GCRecord { get; set; }



    }
}
