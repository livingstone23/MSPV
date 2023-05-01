using AutoMapper;
using PVM.Services.Gestpro.Model.Dto;
using PVM.Services.Gestpro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVM.Service.Gestpro.Test
{
    public  class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<ETramitacio, ETramitacioDto>();
        }


    }
}
