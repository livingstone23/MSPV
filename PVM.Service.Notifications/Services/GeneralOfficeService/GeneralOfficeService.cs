using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PVM.Service.Notifications.DbContexts;
using PVM.Service.Notifications.Model;
using PVM.Service.Notifications.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Service.Notifications.Services.GeneralOfficeService
{
    public class GeneralOfficeService:IGeneralOfficeService
    {


        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GeneralOfficeService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<GeneralOfficeDto>>> GetGeneralOfficesAsync()
        {

            var response = new ServiceResponse<List<GeneralOfficeDto>> { };

            try
            {

                List<GeneralOffice> GeneralOfficeList = await _db.GeneralOffices.ToListAsync();
                var responseDto = _mapper.Map<List<GeneralOfficeDto>>(GeneralOfficeList);
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



        public async Task<ServiceResponse<GeneralOfficeDto>> GetGeneralOfficeById(Guid id)
        {

            var response = new ServiceResponse<GeneralOfficeDto> { };

            try
            {

                GeneralOffice generalOffice = await _db.GeneralOffices.Where(x => x.Oid == id).FirstOrDefaultAsync();
                var responseDto = _mapper.Map<GeneralOfficeDto>(generalOffice);
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
