using Microsoft.EntityFrameworkCore;
using PesquisaSatisfacao.API.Contracts.v1.Avaliacao;
using PesquisaSatisfacao.API.Data;
using PesquisaSatisfacao.Application.Data.Models;
using PesquisaSatisfacao.Application.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PesquisaSatisfacao.Application.Data.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly PesquisaSatisfacaoContext _db;
        public AvaliacaoRepository(PesquisaSatisfacaoContext db)
        {
            _db = db;
        }

        public int Delete(int id)
        {
            try
            {
                _db.Avaliacao.Remove(_db.Avaliacao.FirstOrDefault(t => t.Id == id));
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Avaliacao GetById(int id)
        {
            try
            {
                return _db.Avaliacao.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Avaliacao> GetByCliente(int id)
        {
            try
            {
                return _db.Avaliacao.Where(x => x.ClienteId == id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AvaliacaoExists(int clienteId, string mesAno)
        {
            try
            {
                return _db.Avaliacao.Where(x => x.ClienteId == clienteId && x.MesAno == mesAno).Count() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertOrUpdate(Avaliacao avaliacao)
        {
            try
            {
                if (avaliacao.Id > 0)
                    _db.Entry(avaliacao).State = EntityState.Modified;
                else
                    _db.Entry(avaliacao).State = EntityState.Added;

                _db.SaveChanges();

                return avaliacao.Id;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<GetResultResponse> GetResults()
        {
            try
            {
                List<GetResultResponse> results = new List<GetResultResponse>();

                var avaliacoes = _db.Avaliacao.Select(x => x.MesAno).ToList();
                var meses = avaliacoes.Distinct();

                foreach (var mes in meses)
                {
                    GetResultResponse resultado = new GetResultResponse();

                    decimal promotores = _db.Avaliacao.Where(x => x.Nota >= 9 && x.MesAno == mes).Count();
                    decimal detratores = _db.Avaliacao.Where(x => x.Nota <= 6 && x.MesAno == mes).Count();
                    var participantes = _db.Avaliacao.Where(x => x.MesAno == mes).Count();

                    decimal nps = ((promotores - detratores) / participantes) * 100;

                    resultado.MesAno = mes;
                    resultado.NPS = nps;

                    results.Add(resultado);
                }

                return results.OrderBy(x => x.MesAno).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
