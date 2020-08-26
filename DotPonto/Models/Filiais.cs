using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotPonto.Models
{
    public class Filiais 
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
        public Empresas Empresas { get; set; }
        public int EmpresasId { get; set; }


        public Filiais()
        {

        }

        public Filiais(int id, string razaoSocial, string empEndereco, string empEndNumero, 
            string empEndBairro, string empEndCidade, string empEndUF, string empEndCEP, 
            string cNAE, string inscricaoMunicipal, string inscricaoEstadual, Empresas empresas)
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
            Empresas = empresas;
           
        }
    }
}
