using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotPonto.Models
{
    public class Empresas
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string EmpEndereco { get; set; }
        public string EmpEndNumero { get; set; }
        public string EmpEndBairro { get; set; }
        public string EmpEndCidade { get; set; }
        public string EmpEndUF { get; set; }
        public string EmpEndCEP { get; set; }
        public string CNAE { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string InscricaoEstadual { get; set; }
        public ICollection<Filiais> Filial { get; set; }



        public Empresas()
        {

        }

        public Empresas(int id, string razaoSocial, string empEndereco, string empEndNumero,
            string empEndBairro, string empEndCidade, string empEndUF, string empEndCEP,
            string cNAE, string inscricaoMunicipal, string inscricaoEstadual)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            EmpEndereco = empEndereco;
            EmpEndNumero = empEndNumero;
            EmpEndBairro = empEndBairro;
            EmpEndCidade = empEndCidade;
            EmpEndUF = empEndUF;
            EmpEndCEP = empEndCEP;
            CNAE = cNAE;
            InscricaoMunicipal = inscricaoMunicipal;
            InscricaoEstadual = inscricaoEstadual;
        }

        public int ContaRegistros()
        {
            List<int> reg = new List<int>();
            reg.Add(Id);

            int res = reg.Count();

            return res;
        }
    }
}
