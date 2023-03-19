using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PVM.Service.Notifications.DbContexts;
using PVM.Service.Notifications.Model;
using PVM.Service.Notifications.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Service.Notifications.Services.GeneralOfficeUserService
{
    public class GeneralOfficeUserService: IGeneralOfficeUserService
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GeneralOfficeUserService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }



        public async Task<ServiceResponse<List<GeneralOfficeUserDto>>> GetGeneralOfficeUsersAsync()
        {

            var response = new ServiceResponse<List<GeneralOfficeUserDto>> { };

            try
            {

                List<GeneralOfficeUser> GeneralOfficeUserList = await _db.GeneralOfficeUsers.ToListAsync();
                var responseDto = _mapper.Map<List<GeneralOfficeUserDto>>(GeneralOfficeUserList);
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



        public async Task<ServiceResponse<GeneralOfficeUserDto>> GetGeneralOfficeUserById(Guid id)
        {

            var response = new ServiceResponse<GeneralOfficeUserDto> { };

            try
            {

                GeneralOfficeUser generalOfficeUser = await _db.GeneralOfficeUsers.Where(x => x.Oid == id).FirstOrDefaultAsync();
                var responseDto = _mapper.Map<GeneralOfficeUserDto>(generalOfficeUser);
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
