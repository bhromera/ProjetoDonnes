using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PesquisaSatisfacao.Application.Data.Models;

namespace PesquisaSatisfacao.API.Services.Interfaces
{
    public interface IClienteServices
    {
        Task<ActionResult> GetAsync(int id);
        Task<ActionResult> GetAllAsync();
        Task<ActionResult> GetEnabledToAvaliationAsync();
        Task<ActionResult> GetByNameAsync(string name);
        Task<ActionResult> CreateAsync(Cliente cliente);
        Task<ActionResult> DeleteAsync(int id);
    }
}
