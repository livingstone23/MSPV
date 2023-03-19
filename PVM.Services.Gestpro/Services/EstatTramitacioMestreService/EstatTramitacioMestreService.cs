using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PVM.Services.Gestpro.DbContexts;
using PVM.Services.Gestpro.Model;
using PVM.Services.Gestpro.Model.Dto;
using PVM.Services.Gestpro.Services.EstatTramitacioMestre;
using PVM.SharedLibrary.Models;

namespace PVM.Services.Gestpro.Services.EstatTramitacioMestreService
{
    public class EstatTramitacioMestreService : IEstatTramitacioMestreService
    {


        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;


        public EstatTramitacioMestreService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<EstatTramitacioMestreDto>>> GetEstatTramitacioMestresAsync()
        {

            var response = new ServiceResponse<List<EstatTramitacioMestreDto>> { };

            try
            {

                List<Model.EstatTramitacioMestre> EstatTramitacioMestreList = await _db.EstatTramitacioMestres.ToListAsync();
                var responseDto = _mapper.Map<List<EstatTramitacioMestreDto>>(EstatTramitacioMestreList);
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


        public async Task<ServiceResponse<EstatTramitacioMestreDto>> GetEstatTramitacioMestreById(int IdEstatTramitacio)
        {

            var response = new ServiceResponse<EstatTramitacioMestreDto> { };

            try
            {

                Model.EstatTramitacioMestre estatTramitacioMestre = await _db.EstatTramitacioMestres.Where(x => x.IdEstatTramitacio == IdEstatTramitacio).FirstOrDefaultAsync();
                var responseDto = _mapper.Map<EstatTramitacioMestreDto>(estatTramitacioMestre);
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
