using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PVM.Service.Notifications.DbContexts;
using PVM.Service.Notifications.Model;
using PVM.Service.Notifications.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Service.Notifications.Services.GeneralService
{
    public class GeneralServiceService:IGeneralServiceService 
    {


        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;


        public GeneralServiceService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }



        public async Task<ServiceResponse<List<GeneralServiceDto>>> GetGeneralServicesAsync()
        {

            var response = new ServiceResponse<List<GeneralServiceDto>> { };

            try
            {

                List<Model.GeneralService> GeneralServiceList = await _db.GeneralServices.ToListAsync();
                var responseDto = _mapper.Map<List<GeneralServiceDto>>(GeneralServiceList);
                response.Data = responseDto;

                return response;

            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessages = new List<string>() { e.ToString() };
                return response;
            }

        }



        public async Task<ServiceResponse<GeneralServiceDto>> GetGeneralServiceById(Guid id)
        {

            var response = new ServiceResponse<GeneralServiceDto> { };

            try
            {

                Model.GeneralService generalService = await _db.GeneralServices.Where(x => x.Oid == id).FirstOrDefaultAsync();
                var responseDto = _mapper.Map<GeneralServiceDto>(generalService);
                response.Data = responseDto;
                return response;

            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessages = new List<string>() { e.ToString() };
                return response;
            }

        }



    }
}
