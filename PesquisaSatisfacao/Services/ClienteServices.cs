using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PesquisaSatisfacao.API.Services.Interfaces;
using PesquisaSatisfacao.Application.Data.Models;
using PesquisaSatisfacao.Application.Data.Repositories.Interfaces;

namespace PesquisaSatisfacao.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ActionResult> CreateAsync(Cliente cliente)
        {
            if (cliente.Id == 0 && _clienteRepository.CnpjExists(cliente.Cnpj))
                return new BadRequestObjectResult(new { Erro = "CNPJ já cadastrado" });

            if (string.IsNullOrEmpty(cliente.RazaoSocial))
                return new BadRequestObjectResult(new { Erro = "Razão Social não pode ser vazio" });

            if (string.IsNullOrEmpty(cliente.Contato))
                return new BadRequestObjectResult(new { Erro = "Contato não pode ser vazio" });

            var response = _clienteRepository.InsertOrUpdate(cliente);

            if (response == null)
                return new BadRequestResult();

            return new OkResult();
        }

        public async Task<ActionResult> DeleteAsync(int id)
        {
            var response = _clienteRepository.Delete(id);

            if (response == 0)
                return new BadRequestResult();

            return new OkResult();
        }

        public async Task<ActionResult> GetAllAsync()
        {
            var clientes = _clienteRepository.GetAll();

            if (clientes == null)
                return new BadRequestResult();

            return new OkObjectResult(clientes);
        }

        public async Task<ActionResult> GetEnabledToAvaliationAsync()
        {
            var clientes = _clienteRepository.GetEnabledToAvaliation();

            if (clientes == null)
                return new BadRequestResult();

            return new OkObjectResult(clientes);
        }

        public async Task<ActionResult> GetAsync(int id)
        {
            var cliente = _clienteRepository.GetById(id);

            if (cliente == null)
                return new BadRequestResult();

            return new OkObjectResult(cliente);
        }

        public async Task<ActionResult> GetByNameAsync(string name)
        {
            var clientes = _clienteRepository.GetByName(name);

            if (clientes == null)
                return new BadRequestResult();

            return new OkObjectResult(clientes);
        }
    }
}
