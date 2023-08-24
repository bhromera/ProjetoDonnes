using PesquisaSatisfacao.API.Contracts.v1.Avaliacao;
using PesquisaSatisfacao.Application.Data.Models;
using System;
using System.Collections.Generic;

namespace PesquisaSatisfacao.Application.Data.Repositories.Interfaces
{
    public interface IAvaliacaoRepository
    {
        Avaliacao GetById(int id);
        List<Avaliacao> GetByCliente(int id);
        bool AvaliacaoExists(int clienteId, string mesAno);
        int InsertOrUpdate(Avaliacao avaliacao);
        int Delete(int id);

        List<GetResultResponse> GetResults();
    }
}