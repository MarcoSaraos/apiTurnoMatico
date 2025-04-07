using apiTurnoMatico.Model.DB;
using apiTurnoMatico.Model.DTO;
using apiTurnoMatico.Tools;
using apiTurnoMatico.Services.OficinaService.Interfaces;
using Microsoft.EntityFrameworkCore;
using apiTurnoMatico.Data;

namespace apiTurnoMatico.Services.OficinaService.Services
{
    public class RepoOficina : IRepoOficina
    {
        private readonly AppDbContext _context;

        public RepoOficina(AppDbContext context) 
        { 
            _context = context;
        }


        async Task<ApiResponse<List<DTOOficina>>> IRepoOficina.Get()
        {
            try
            {
                var res = await _context.Oficinas
                .Where(x => x.status == 1)
                 .Select(x => new DTOOficina
                 {
                     Id = x.Id,
                     Nombre = x.Nombre,
                     Aforo = x.Aforo,
                     CajasDisponibles = x.CajasDisponibles,
                     Latitud = x.Latitud,
                     Longitud = x.Longitud,
                     esMoto = x.esMoto
                 })
                .ToListAsync();

                return res.Count > 0 ?
                    new ApiResponse<List<DTOOficina>>(200, res, "OK") :
                    new ApiResponse<List<DTOOficina>>(404, "NotFound");
            }
            catch (Exception)
            {
                return new ApiResponse<List<DTOOficina>>(500, "Error interno");
            }
        }
    }
}
