using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVM.SharedLibrary.Models
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;

        private int registerByPage = 10;

        private readonly int maxRegisterByPage = 50;

        public int RegisterByPage
        {
            get => registerByPage;
            set
            {
                registerByPage = (value > maxRegisterByPage) ? maxRegisterByPage : value;
            }
        }

    }
}
