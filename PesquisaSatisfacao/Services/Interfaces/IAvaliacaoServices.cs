using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PesquisaSatisfacao.Application.Data.Models;

namespace PesquisaSatisfacao.API.Services.Interfaces
{
    public interface IAvaliacaoServices
    {
        Task<ActionResult> GetAsync(int id);
        Task<ActionResult> GetByClienteAsync(int id);
        Task<ActionResult> CreateAsync(Avaliacao avaliacao);
        Task<ActionResult> DeleteAsync(int id);
        Task<ActionResult> GetResultAsync();
    }
}
