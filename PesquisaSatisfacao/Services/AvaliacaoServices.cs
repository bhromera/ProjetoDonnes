using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PesquisaSatisfacao.API.Services.Interfaces;
using PesquisaSatisfacao.Application.Data.Models;
using PesquisaSatisfacao.Application.Data.Repositories.Interfaces;
using PesquisaSatisfacao.API.Data.Enums;
using System.Collections.Generic;

namespace PesquisaSatisfacao.Services
{
    public class AvaliacaoServices : IAvaliacaoServices
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly IClienteRepository _clienteRepository;

        public AvaliacaoServices(IAvaliacaoRepository avaliacaoRepository, IClienteRepository clienteRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<ActionResult> CreateAsync(Avaliacao avaliacao)
        {
            if (avaliacao.MesAno == null)
                return new BadRequestObjectResult(new { Erro = "Data deve ser preenchida." });

            if (avaliacao.ClienteId == null)
                return new BadRequestObjectResult(new { Erro = "Cliente deve ser informado." });

            var cliente = _clienteRepository.GetById(avaliacao.ClienteId);

            if (avaliacao.Nota == null)
                return new BadRequestObjectResult(new { Erro = "Nota deve ser informada." });

            if (string.IsNullOrEmpty(avaliacao.Motivo))
                return new BadRequestObjectResult(new { Erro = "Motivo deve ser informado." });

            if (_avaliacaoRepository.AvaliacaoExists(avaliacao.ClienteId, avaliacao.MesAno))
                return new BadRequestObjectResult(new { Erro = $"Já existe uma avaliação para o cliente {cliente.RazaoSocial} no mês." });            

            var response = _avaliacaoRepository.InsertOrUpdate(avaliacao);

            if (response == null)
                return new BadRequestResult();

            // Alterar categoria cliente
            if (avaliacao.Nota >= 0 && avaliacao.Nota <= 6)
                cliente.Categoria = CategoriaCliente.Detrator;
            else if (avaliacao.Nota >= 7 && avaliacao.Nota <= 8)
                cliente.Categoria = CategoriaCliente.Neutro;
            else if (avaliacao.Nota >= 9 && avaliacao.Nota <= 10)
                cliente.Categoria = CategoriaCliente.Promotor;

            var responseCliente = _clienteRepository.InsertOrUpdate(cliente);

            return new OkResult();
        }

        public async Task<ActionResult> DeleteAsync(int id)
        {
            var response = _avaliacaoRepository.Delete(id);

            if (response == 0)
                return new BadRequestResult();

            return new OkResult();
        }

        public async Task<ActionResult> GetAsync(int id)
        {
            var response = _avaliacaoRepository.GetById(id);

            if (response == null)
                return new BadRequestResult();

            return new OkObjectResult(response);
        }

        public async Task<ActionResult> GetByClienteAsync(int id)
        {
            var response = _avaliacaoRepository.GetByCliente(id);

            if (response == null)
                return new BadRequestResult();

            return new OkObjectResult(response);
        }

        public async Task<ActionResult> GetResultAsync()
        {
            var response = _avaliacaoRepository.GetResults();

            if (response == null)
                return new BadRequestResult();

            return new OkObjectResult(response);
        }
    }
}
