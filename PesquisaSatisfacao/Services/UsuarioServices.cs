using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PesquisaSatisfacao.API.Services.Interfaces;
using PesquisaSatisfacao.Application.Data.Models;
using PesquisaSatisfacao.Application.Data.Repositories.Interfaces;

namespace PesquisaSatisfacao.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ActionResult<Usuario>> GetByEmailAsync(string email)
        {
            var usuario = _usuarioRepository.GetByEmail(email);

            if (usuario == null)
                return new BadRequestResult();

            return new OkObjectResult(usuario);
        }
    }
}
