using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PVM.Service.Gestpro.Model.Dto;
using PVM.Services.Gestpro.DbContexts;
using PVM.Services.Gestpro.Model;
using PVM.Services.Gestpro.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Services.Gestpro.Services.ETramitacioService
{
    public class ETramitacioService : IETramitacioService
    {


        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public ETramitacioService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<ServiceResponse<List<ETramitacioDto>>> GetEtramitaciosAsync()
        {

            var response = new ServiceResponse<List<ETramitacioDto>> { };

            try
            {

                List<ETramitacio> ETramitacioList = await _context.ETramitacios.ToListAsync();
                var responseDto = _mapper.Map<List<ETramitacioDto>>(ETramitacioList);
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



        public async Task<ServiceResponse<ETramitacioDto>> GetEtramitacioById(int IdEtramitacio)
        {

            var response = new ServiceResponse<ETramitacioDto>();

            try
            {

                ETramitacio eTramitacio = await _context.ETramitacios.Where(x => x.IdETramitacio == IdEtramitacio).FirstOrDefaultAsync();
                var responseDto = _mapper.Map<ETramitacioDto>(eTramitacio);
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

        public async Task<ServiceResponse<ETramitacioSearchResult>> SearchETramitacio(PaginationDTO paginationDto)
        {
            try
            {
                //var pageResults = 20f;
                var pageCount = Math.Round(((double)_context.ETramitacios.Where(e=>e.GCRecord == null).Count() / paginationDto.RegisterByPage),0);
                var eTramitacios = await _context.ETramitacios.Where(e => e.GCRecord == null)
                                                                                .Include(p => p.EstatTramitacio.Where(et => et.GCRecord == null))
                                                                                .Include(r => r.Register)
                                                                                .Skip(((paginationDto.Page - 1)* (int)paginationDto.RegisterByPage))
                                                                                .Take((int)paginationDto.RegisterByPage)
                                                                                .ToListAsync();



                var response = new ServiceResponse<ETramitacioSearchResult>
                {
                    Data = new ETramitacioSearchResult
                    {
                        ETramitacios = eTramitacios,
                        CurrentPage = paginationDto.Page,
                        Pages = (int)pageCount
                    }
                };

                return response;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //public void AddEtramitacio(ETramitacioDto eTramitacio)
        //{

        //    var dataToSave = _mapper.Map<ETramitacio>(eTramitacio);
        //    _context.ETramitacios.Add(dataToSave);
        //}
    }
}
