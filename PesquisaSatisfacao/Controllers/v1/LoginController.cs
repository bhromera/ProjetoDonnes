using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PesquisaSatisfacao.API.Contracts.v1.Login;
using PesquisaSatisfacao.API.Services.Interfaces;
using PesquisaSatisfacao.Application.Data.Models;

namespace PesquisaSatisfacao.API.Controllers.v1
{
    [Route("/v1/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;

        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] GetResultResponse request)
        {
            return await _loginServices.AuthenticateAsync(request);
        }
    }


}
