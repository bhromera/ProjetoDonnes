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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PesquisaSatisfacaoContext _db;
        public UsuarioRepository(PesquisaSatisfacaoContext db)
        {
            _db = db;
        }

        public Usuario GetByEmail(string email)
        {
            try
            {
                return _db.Usuario.Where(x => x.Email.ToLower() == email).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
