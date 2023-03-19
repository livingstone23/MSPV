using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Services.Security.Model
{
    [Table("UserRoleHistory", Schema = "Security")]
    public class UserRoleHistory
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserRoleHistoryId { get; set; }
        //Registro creado por 

        public PolicyUser CreatedUser { get; set; }
        [ForeignKey("CreatedUser")]
        public string CreatedId { get; set; }


        public string UserRoleId { get; set; }

        //public PolicyUser PolicyUser { get; set; }

        //[ForeignKey("PolicyUser")]
        public Guid PolicyUserId { get; set; }

        //public PermissionRole PermissionRole { get; set; }

        //[ForeignKey("PermissionRole")]
        public string PermissionRoleId { get; set; }




        //Campos de control
        public bool IsActive { get; set; }
        public int? OptimisticLockField { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int GCRecord { get; set; }



    }
}
