using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotPonto.Models.ViewModels
{
    public class FuncionariosViewModel
    {
        public Funcionarios Funcionarios { get; set; }
        public ICollection<Empresas> Empresas { get; set; }
        public ICollection<Filiais> Filiais { get; set; }
        public ICollection<Lotacao> Lotacao { get; set; }


        public int CalculaIdade()
        {
            TimeSpan ida = DateTime.Now.Subtract(Funcionarios.Nascimento);

            int res = ida.Days / 365;

            return res;

        }
    }
}
