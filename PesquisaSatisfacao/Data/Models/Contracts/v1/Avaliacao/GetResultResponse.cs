using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisaSatisfacao.API.Contracts.v1.Avaliacao
{
    public class GetResultResponse
    {
        public string MesAno { get; set; }
        public decimal NPS { get; set; }
    }
}
