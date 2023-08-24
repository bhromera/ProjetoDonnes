using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PesquisaSatisfacao.Application.Data.Models;

namespace PesquisaSatisfacao.API.Services.Interfaces
{
    public interface IUsuarioServices
    {
        Task<ActionResult<Usuario>> GetByEmailAsync(string email);
        
    }
}
