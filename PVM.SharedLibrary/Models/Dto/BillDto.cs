using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVM.SharedLibrary.Models.Dto
{
    public class BillDto
    {
        public Guid Oid { get; set; }
        public String Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }




        //Campos de control
        public bool IsActive { get; set; }
        public int? OptimisticLockField { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int? GCRecord { get; set; }
    }
}
