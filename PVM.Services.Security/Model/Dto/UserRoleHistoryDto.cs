using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Services.Security.Model
{

    public class UserRoleHistoryDto
    {


        public int UserRoleHistoryId { get; set; }
        //Registro creado por 

        public int CreatedId { get; set; }


        public int UserRoleId { get; set; }


        public int PolicyUserId { get; set; }

        //public PermissionRole PermissionRole { get; set; }

        //[ForeignKey("PermissionRole")]
        public Guid PermissionRoleId { get; set; }




        //Campos de control
        public bool IsActive { get; set; }
        public int? OptimisticLockField { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int GCRecord { get; set; }



    }
}
