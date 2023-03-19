using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PVM.Services.Gestpro.DbContexts;
using PVM.Services.Gestpro.Model;
using PVM.Services.Gestpro.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Services.Gestpro.Services.EstatTramitacioService
{
    public class EstatTramitacioService : IEstatTramitacioService
    {


        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public EstatTramitacioService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<EstatTramitacioDto>>> GetEstatTramitaciosAsync()
        {
            var response = new ServiceResponse<List<EstatTramitacioDto>> { };

            try
            {

                List<EstatTramitacio> EstatTramitacioList = await _db.EstatTramitacios.ToListAsync();
                var responseDto = _mapper.Map<List<EstatTramitacioDto>>(EstatTramitacioList);
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


        public async Task<ServiceResponse<EstatTramitacioDto>> GetEstatTramitacioById(int IdEstatTramitacio)
        {

            var response = new ServiceResponse<EstatTramitacioDto> { };

            try
            {

                EstatTramitacio estatTramitacio = await _db.EstatTramitacios.Where(x => x.IdEstatTramitacio == IdEstatTramitacio).FirstOrDefaultAsync();
                var responseDto = _mapper.Map<EstatTramitacioDto>(estatTramitacio);
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
