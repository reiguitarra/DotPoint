using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotPonto.Models
{
    public class Filiais : Empresas
    {
        public Filiais(int id, string razaoSocial, string empEndereco, string empEndNumero,
            string empEndBairro, string empEndCidade, string empEndUF, string empEndCEP,
            string cNAE, string inscricaoMunicipal, string inscricaoEstadual) 

            : base(id, razaoSocial, empEndereco, empEndNumero, 
                  empEndBairro, empEndCidade,empEndUF,empEndCEP, cNAE, inscricaoMunicipal,inscricaoEstadual)
        {

        }

    }
}
