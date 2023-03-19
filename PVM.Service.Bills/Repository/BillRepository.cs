using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PVM.Service.Bills.Interface;
using PVM.Service.Bills.Model.Dto;
using PVM.SharedLibrary.Models;


namespace PVM.Service.Bills.Repository
{
    public  class BillRepository:IBillRepository
    {
        private readonly IDbConnection _dbConnection;

        public BillRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<BillDto>> GetAll()
        {

            //var sql = @"Select Oid, Code, Name,  Type, IsActive, OptimisticLockField, DateCreated, DateModified, GCRecord from [Security].[Action] order by Code";

            var sql = @"Select NumFactura, FechaFactura, FechaEnvioCXB, EstadoFactura, BaseImponible, TipoRepercutido, ImporteRepercutido, TotalCobrar from [dbo].[VW_PGest_FacturaProvimad] order by FechaFactura desc";

            return await _dbConnection.QueryAsync<BillDto>(sql, new { });

        }

        public async Task<PagingResponseModel<List<BillDto>>> GetBillsByPagination(int currentPageNumber, int pageSize)
        {

            int maxPagSize = 50;
            pageSize = (pageSize > 0 && pageSize <= maxPagSize) ? pageSize : maxPagSize;

            int skip = (currentPageNumber - 1) * pageSize;
            int take = pageSize;

            var sql = @"SELECT 
                        COUNT(*)
                        FROM [dbo].[VW_PGest_FacturaProvimad] 

                        Select NumFactura, FechaFactura, FechaEnvioCXB, EstadoFactura, BaseImponible, TipoRepercutido, ImporteRepercutido, TotalCobrar 
                        from [dbo].[VW_PGest_FacturaProvimad] 
                        order by FechaFactura desc
                        OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";

            var reader = _dbConnection.QueryMultiple(sql, new { Skip = skip, Take = take });

            int count = reader.Read<int>().FirstOrDefault();
            List<BillDto> allTodos = reader.Read<BillDto>().ToList();

            //return await _dbConnection.QueryAsync<POSPay>(sql, new { });
            var result = new PagingResponseModel<List<BillDto>>(allTodos, count, currentPageNumber, pageSize);
            return result;

        }

        //public async Task<BillDto> GetById(Guid id)
        //{

        //    var sql = @"Select Oid, Code, Name,  Type, IsActive, OptimisticLockField, DateCreated, DateModified, GCRecord
        //                from [Security].[Action]
        //                Where  Oid = @Oid ";

        //    return await _dbConnection.QueryFirstOrDefaultAsync<BillDto>(sql, new { Oid = id });

        //}

        public async Task<BillDto> GetByNumFactura(string numFactura)
        {

            var sql = @"Select NumFactura, FechaFactura, FechaEnvioCXB, EstadoFactura, BaseImponible, TipoRepercutido, ImporteRepercutido, TotalCobrar 
                        from [dbo].[VW_PGest_FacturaProvimad]
                        Where  NumFactura = @NumFactura ";

            return await _dbConnection.QueryFirstOrDefaultAsync<BillDto>(sql, new { NumFactura = numFactura });

        }
    }
}
