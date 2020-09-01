using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotPonto.Models
{
    public class Funcionarios
    {
        [Key]
        public int FuId { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        [DataType(DataType.Date)]
        public DateTime Admissao { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Demissao { get; set; }
        public char Sexo { get; set; } 
        public string Mae { get; set; }
        public string Pai { get; set; }
        public string RG { get; set; }
        public string PIS { get; set; }
        public string CPF { get; set; }
        [Display(Name ="Rua")]
        public string FuEndRua { get; set; }

        [Display(Name = "Número")]
        public string FuEndNumero { get; set; }

        [Display(Name = "Bairro")]
        public string FuEndBairro { get; set; }

        [Display(Name = "Cidade")]
        public string FuEndCidade { get; set; }

        [Display(Name = "UF")]
        public string FuEndUF { get; set; }

        [Display(Name = "Empresa")]
        public Empresas Empresas { get; set; }

        
        public int EmpresasId { get; set; }

        [Display(Name = "Filial")]
        public Filiais Filiais { get; set; }

        
        public int FiliaisId { get; set; }

        [Display(Name = "Lotação")]
        public Lotacao Lotacao { get; set; }
        public int LotacaoId  { get; set; }

        public Funcionarios()
        {

        }

        public Funcionarios(int fuId, string nome, DateTime nascimento, DateTime admissao, DateTime demissao, char sexo, string mae, string pai, string rG, 
            string pIS, string cPF, string fuEndRua, string fuEndNumero, string fuEndBairro, 
            string fuEndCidade, string fuEndUF, 
            Empresas empresas, Filiais filiais, Lotacao lotacao)
        {
            FuId = fuId;
            Nome = nome;
            Nascimento = nascimento;
            Admissao = admissao;
            Demissao = demissao;
            Sexo = sexo;
            Mae = mae;
            Pai = pai;
            RG = rG;
            PIS = pIS;
            CPF = cPF;
            FuEndRua = fuEndRua;
            FuEndNumero = fuEndNumero;
            FuEndBairro = fuEndBairro;
            FuEndCidade = fuEndCidade;
            FuEndUF = fuEndUF;
            Empresas = empresas;
            Filiais = filiais;
            Lotacao = lotacao;
        }


        
    }
}
