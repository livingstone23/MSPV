using PVM.Services.Security.Model.Dto;

namespace PVM.Services.Security.Services.ApplicativeService;

public interface IApplicativeService
{

    Task<IEnumerable<ApplicativeDto>> GetApplicatives();
    Task<ApplicativeDto> GetApplicativeById(int productId);
    Task<ApplicativeDto> CreateUpdateApplicative(ApplicativeDto applicativeDto);
    Task<bool> DeleteApplicative(int applicativeId);

}