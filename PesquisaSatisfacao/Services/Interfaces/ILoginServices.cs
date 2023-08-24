using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PesquisaSatisfacao.API.Contracts.v1.Login;
using PesquisaSatisfacao.Application.Data.Models;

namespace PesquisaSatisfacao.API.Services.Interfaces
{
    public interface ILoginServices
    {
        Task<ActionResult<dynamic>> AuthenticateAsync(GetResultResponse request);
    }
}
