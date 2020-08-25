using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotPonto.Entities
{
    public class Filial : Empresa
    {
        public Filial(int id, string razaoSocial, string empEndereco, string empEndNumero,
            string empEndBairro, string empEndCidade, string empEndUF, string empEndCEP,
            string cNAE, string inscricaoMunicipal, string inscricaoEstadual) 
            : base(id, razaoSocial, empEndereco, empEndNumero, 
                  empEndBairro, empEndCidade,empEndUF,empEndCEP, cNAE, inscricaoMunicipal,inscricaoEstadual)
        {

        }

    }
}
