using AutoMapper;
using PVM.Services.Security.Model;
using PVM.Services.Security.Model.dto;
using PVM.Services.Security.Model.Dto;
using Action = PVM.Services.Security.Model.Action;


namespace PVM.Services.Security
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            //CreateMap<ActionDto, Action>().ReverseMap();

            //De donde y hacia donde
            CreateMap<Action, ActionDto>();
            CreateMap<ActionDto, Action>();

            CreateMap<ViewDto, View>();
            CreateMap<View, ViewDto>();


            CreateMap<RoleActionDto, RoleAction>();
            CreateMap<RoleAction, RoleActionDto>();
        }


    }




    //public class MappingConfig
    //{

    //    public static MapperConfiguration RegisterMaps()
    //    {

    //        var mappingConfig = new MapperConfiguration(config =>
    //        {
    //            config.CreateMap<ActionDto, Action>();
    //            config.CreateMap<Action, ActionDto>();

    //            config.CreateMap<ViewDto, View>();
    //            config.CreateMap<View, ViewDto>();

    //            config.CreateMap<ActionDto, Action>();
    //            config.CreateMap<Action, ActionDto>();

    //            config.CreateMap<RoleActionDto, RoleAction>();
    //            config.CreateMap<RoleAction, RoleActionDto>();

    //        });

    //        return mappingConfig;
    //    }
    //}

}
