using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PVM.Services.Gestpro.DbContexts;
using PVM.Services.Gestpro.Model;
using PVM.Services.Gestpro.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Services.Gestpro.Services.RegisterService
{
    public class RegisterService : IRegisterService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;


        public RegisterService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<RegisterDto>>> GetRegisterAsync()
        {
            var response = new ServiceResponse<List<RegisterDto>> { };

            try
            {

                List<Register> RegisterList = await _db.Registers.ToListAsync();
                var responseDto = _mapper.Map<List<RegisterDto>>(RegisterList);
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

        public async Task<ServiceResponse<RegisterDto>> GetRegisterById(Guid actionId)
        {
            var response = new ServiceResponse<RegisterDto> { };

            try
            {

                Register register = await _db.Registers.Where(x => x.Oid == actionId).FirstOrDefaultAsync();
                var responseDto = _mapper.Map<RegisterDto>(register);
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

        //public async Task<ServiceResponse<RegisterDto>> CreateUpdateRegister(RegisterDto actionDto)
        //{
        //    var response = new ServiceResponse<RegisterDto> { };

        //    try
        //    {
        //        Register register = _mapper.Map<RegisterDto, Register>(actionDto);

        //        if (register is not null)
        //        {
        //            _db.Registers.Update(register);
        //        }
        //        else
        //        {
        //            _db.Registers.Add(register);
        //        }

        //        await _db.SaveChangesAsync();
        //        var responseDto = _mapper.Map<Register, RegisterDto>(register);
        //        response.Data = responseDto;
        //        return response;
        //    }
        //    catch (Exception e)
        //    {
        //        response.Success = false;
        //        response.ErrorMessages = new List<string>() { e.ToString() };
        //        return response;
        //    }
        //}

        //public async Task<ServiceResponse<bool>> DeleteRegister(Guid actionId)
        //{
        //    var response = new ServiceResponse<bool> { };

        //    try
        //    {

        //        Register register = await _db.Registers.FirstOrDefaultAsync(u => u.Oid == actionId);
        //        if (register == null)
        //        {
        //            response.Data = false;
        //        }
        //        _db.Registers.Remove(register);
        //        await _db.SaveChangesAsync();
        //        response.Data = true;
        //        return response;

        //    }
        //    catch (Exception e)
        //    {
        //        response.Success = false;
        //        response.ErrorMessages = new List<string>() { e.ToString() };
        //        return response;
        //    }
        //}




    }
}