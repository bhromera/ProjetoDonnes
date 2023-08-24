using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisaSatisfacao.API.Contracts.v1.Login
{
    public class GetResultResponse
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
