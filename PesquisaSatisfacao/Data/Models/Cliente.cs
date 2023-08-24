using PesquisaSatisfacao.API.Data.Enums;
using System;

namespace PesquisaSatisfacao.Application.Data.Models
{
    public class Cliente : Base
    {
        public string RazaoSocial { get; set; }
        public string Contato { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataCadastro { get; set; }
        public CategoriaCliente Categoria { get; set; }
    }
}
