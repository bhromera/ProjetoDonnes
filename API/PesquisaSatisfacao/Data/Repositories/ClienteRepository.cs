using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PesquisaSatisfacao.API.Data;
using PesquisaSatisfacao.Application.Data.Models;
using PesquisaSatisfacao.Application.Data.Repositories.Interfaces;

namespace PesquisaSatisfacao.Application.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PesquisaSatisfacaoContext _db;
        public ClienteRepository(PesquisaSatisfacaoContext db)
        {
            _db = db;
        }

        public int Delete(int id)
        {
            try
            {
                _db.Cliente.Remove(_db.Cliente.FirstOrDefault(t => t.Id == id));
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Cliente GetById(int id)
        {
            try
            {
                return _db.Cliente.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> GetAll()
        {
            try
            {
                return _db.Cliente.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> GetEnabledToAvaliation()
        {
            try
            {
                var data = $"{DateTime.Now.Month}/{DateTime.Now.Year}";
                var customers = _db.Avaliacao.Where(x => x.MesAno == data).Select(x => x.ClienteId).ToList();

                return _db.Cliente.Where(x => !customers.Contains(x.Id)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> GetByName(string name)
        {
            try
            {
                return _db.Cliente.Where(x => x.RazaoSocial == name).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CnpjExists(string cnpj)
        {
            try
            {
                return _db.Cliente.Where(x => x.Cnpj == cnpj).Count() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertOrUpdate(Cliente cliente)
        {
            try
            {
                if (cliente.Id > 0)
                    _db.Entry(cliente).State = EntityState.Modified;
                else
                    _db.Entry(cliente).State = EntityState.Added;

                _db.SaveChanges();

                return cliente.Id;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
