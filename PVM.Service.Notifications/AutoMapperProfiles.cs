using AutoMapper;
using PVM.Service.Notifications.Model;
using PVM.Service.Notifications.Model.Dto;
using PVM.Service.Notifications.Services.GeneralOfficeUserService;

namespace PVM.Service.Notifications
{
    public class AutoMapperProfiles : Profile
    {


        public AutoMapperProfiles()
        {


            CreateMap<GeneralOffice, GeneralOfficeDto>();
            CreateMap<GeneralOfficeDto, GeneralOffice>();

            CreateMap<GeneralOfficeUser, GeneralOfficeUserDto>();
            CreateMap<GeneralOfficeUserDto, GeneralOfficeUser>();

            CreateMap<GeneralService, GeneralServiceDto>();
            CreateMap<GeneralServiceDto, GeneralService>();

            CreateMap<GeneralSubservice, GeneralSubserviceDto>();
            CreateMap<GeneralSubserviceDto, GeneralSubservice>();





        }


    }
}
