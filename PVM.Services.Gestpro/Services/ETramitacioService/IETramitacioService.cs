using PVM.Service.Gestpro.Model.Dto;
using PVM.Services.Gestpro.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Services.Gestpro.Services.ETramitacioService
{
    public interface IETramitacioService
    {

        Task<ServiceResponse<List<ETramitacioDto>>> GetEtramitaciosAsync();

        Task<ServiceResponse<ETramitacioDto>> GetEtramitacioById(int IdEtramitacio);

        /// <summary>
        /// Metodo para busqueda de tramites por paginacion.
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<ServiceResponse<ETramitacioSearchResult>> SearchETramitacio(PaginationDTO paginationDto);



        ///// <summary>
        ///// Method for Testing Etramitacio
        ///// </summary>
        ///// <param name="eTramitacio"></param>
        //void AddEtramitacio(ETramitacioDto eTramitacio);

    }
}