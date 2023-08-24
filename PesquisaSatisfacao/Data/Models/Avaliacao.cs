using System;

namespace PesquisaSatisfacao.Application.Data.Models
{
    public class Avaliacao : Base
    {
        public int ClienteId { get; set; }
        public string MesAno { get; set; }
        public int Nota { get; set; }
        public string Motivo { get; set; }
    }
}
