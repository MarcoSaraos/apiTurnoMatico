using System;
using Microsoft.AspNetCore.Mvc;
using apiTurnoMatico.Services;
using apiTurnoMatico.Services.OficinaService.Interfaces;


namespace apiTurnoMatico.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OficinaController : Controller
    {
        private readonly ILogger<OficinaController> _logger;
        private readonly IRepoOficina _repo;
        private readonly IConfiguration _config;

        public OficinaController(ILogger<OficinaController> logger, IRepoOficina repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var res = await this._repo.Get();
            return (res.Success) ?
                Ok(res) :
                NotFound(res);
        }


    }
}
