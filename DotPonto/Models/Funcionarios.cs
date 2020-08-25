using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotPonto.Models
{
    public class Funcionarios
    {
        public int FuId { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public char Sexo { get; set; }
        public string Mae { get; set; }
        public string Pai { get; set; }
        public string RG { get; set; }
        public string PIS { get; set; }
        public string CPF { get; set; }
        public string FuEndRua { get; set; }
        public string FuEndNumero { get; set; }
        public string FuEndBairro { get; set; }
        public string FuEndCidade { get; set; }
        public string FuEndUF { get; set; }
        public Empresas EmpresasId { get; set; }
        public Filiais FiliaisId { get; set; }
        public Lotacao LotacaoId { get; set; }

        public Funcionarios()
        {

        }

        public Funcionarios(int fuId, string nome, DateTime nascimento, char sexo, string mae, string pai, string rG, 
            string pIS, string cPF, string fuEndRua, string fuEndNumero, string fuEndBairro, string fuEndCidade, string fuEndUF, 
            Empresas empresasId, Filiais filiaisId, Lotacao lotacaoId)
        {
            FuId = fuId;
            Nome = nome;
            Nascimento = nascimento;
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
            EmpresasId = empresasId;
            FiliaisId = filiaisId;
            LotacaoId = lotacaoId;
        }
    }
}
