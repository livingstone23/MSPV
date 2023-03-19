using AutoMapper;
using PVM.Services.Gestpro.Model;
using PVM.Services.Gestpro.Model.Dto;

namespace PVM.Services.Gestpro
{
    public class AutoMapperProfiles : Profile
    {


        public AutoMapperProfiles()
        {



            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();


            CreateMap<EstatTramitacio, EstatTramitacioDto>();
            CreateMap<EstatTramitacioDto, EstatTramitacio>();


            CreateMap<EstatTramitacioMestre, EstatTramitacioMestreDto>();
            CreateMap<EstatTramitacioMestreDto, EstatTramitacioMestre>();


            CreateMap<ETramitacio, ETramitacioDto>();
            CreateMap<ETramitacioDto, ETramitacio>();


            CreateMap<Register, RegisterDto>();
            CreateMap<RegisterDto, Register>();

            

        }


    }
}
