using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DotPonto.Models
{
    public class Empresas
    {
        public int Id { get; set; }

        [Display(Name ="Empresa")]
        [Required]
        public string RazaoSocial { get; set; }
        [Display(Name = "Endereço")]
        public string EmpEndereco { get; set; }
        [Display(Name = "Nº")]
        public string EmpEndNumero { get; set; }
        [Display(Name = "Bairro")]
        public string EmpEndBairro { get; set; }
        [Display(Name = "Cidade")]
        public string EmpEndCidade { get; set; }
        [Display(Name = "UF")]
        public string EmpEndUF { get; set; }
        [Display(Name = "CEP")]
        public string EmpEndCEP { get; set; }
        [Display(Name = "CNAE")]
        public string CNAE { get; set; }
        [Display(Name = "I.M")]
        public string InscricaoMunicipal { get; set; }
        [Display(Name = "I.E")]
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
