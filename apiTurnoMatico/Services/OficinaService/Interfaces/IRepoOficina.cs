using apiTurnoMatico.Model.DTO;
using apiTurnoMatico.Tools;

namespace apiTurnoMatico.Services.OficinaService.Interfaces
{
    public interface IRepoOficina
    {
        Task<ApiResponse<List<DTOOficina>>> Get();
    }
}
 