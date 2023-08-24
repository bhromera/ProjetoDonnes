using PesquisaSatisfacao.Application.Data.Models;
using System.Collections.Generic;

namespace PesquisaSatisfacao.Application.Data.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Cliente GetById(int id);
        List<Cliente> GetAll();
        List<Cliente> GetEnabledToAvaliation();
        List<Cliente> GetByName(string name);
        bool CnpjExists(string cnpj);
        int InsertOrUpdate(Cliente cliente);
        int Delete(int id);
    }
}