using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PVM.Service.Notifications.DbContexts;
using PVM.Service.Notifications.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Service.Notifications.Services.GeneralSubservice
{
    public class GeneralSubserviceService: IGeneralSubserviceService
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GeneralSubserviceService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GeneralSubserviceDto>>> GetGeneralSubservicesAsync()
        {

            var response = new ServiceResponse<List<GeneralSubserviceDto>> { };

            try
            {

                List<Model.GeneralSubservice> GeneralSubserviceList = await _db.GeneralSubservices.ToListAsync();
                var responseDto = _mapper.Map<List<GeneralSubserviceDto>>(GeneralSubserviceList);
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

        public async Task<ServiceResponse<GeneralSubserviceDto>> GetGeneralSubserviceById(Guid id)
        {

            var response = new ServiceResponse<GeneralSubserviceDto> { };

            try
            {

                Model.GeneralSubservice generalSubservice = await _db.GeneralSubservices.Where(x => x.Oid == id).FirstOrDefaultAsync();
                var responseDto = _mapper.Map<GeneralSubserviceDto>(generalSubservice);
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
