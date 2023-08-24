using PesquisaSatisfacao.Application.Data.Models;

namespace PesquisaSatisfacao.Application.Data.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario GetByEmail(string email);
    }
}