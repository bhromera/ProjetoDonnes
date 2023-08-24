using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using PesquisaSatisfacao.API.Contracts.v1.Login;
using PesquisaSatisfacao.API.Services;
using PesquisaSatisfacao.API.Services.Interfaces;
using PesquisaSatisfacao.Application.Data.Models;
using PesquisaSatisfacao.Application.Data.Repositories.Interfaces;

namespace PesquisaSatisfacao.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ActionResult<dynamic>> AuthenticateAsync(GetResultResponse request)
        {
            var usuario = _usuarioRepository.GetByEmail(request.Email);

            if (usuario == null || request.Senha != usuario.Senha)
                return new BadRequestObjectResult(new { message = "Usuário ou senha inválidos" });

            var token = TokenServices.GenerateToken(usuario, out var dataExpiracao);

            var response = new
            {
                usuario = usuario.Nome,
                token = token,
                dataExpiracao = dataExpiracao
            };

            return new OkObjectResult(response);
        }
    }
}
