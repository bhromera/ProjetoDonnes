using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PesquisaSatisfacao.API.Services.Interfaces;
using PesquisaSatisfacao.Application.Data.Models;

namespace PesquisaSatisfacao.API.Controllers.v1
{
    [Authorize]
    [Route("/v1/[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoServices _avaliacaoService;

        public AvaliacaoController(IAvaliacaoServices avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpGet]        
        public async Task<ActionResult> Get([FromQuery] int id)
        {
            var user = User.Identity.Name;
            return await _avaliacaoService.GetAsync(id);
        }

        [HttpGet("GetByCliente")]
        public async Task<ActionResult> GetByCliente([FromQuery] int clienteId)
        {
            return await _avaliacaoService.GetByClienteAsync(clienteId);
        }

        [HttpGet("GetResult")]
        public async Task<ActionResult> GetResult()
        {
            return await _avaliacaoService.GetResultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Avaliacao avaliacao)
        {
            return await _avaliacaoService.CreateAsync(avaliacao);
        }

        [HttpDelete]
        [Authorize(Roles = "administrador")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            return await _avaliacaoService.DeleteAsync(id);
        }
    }
}
