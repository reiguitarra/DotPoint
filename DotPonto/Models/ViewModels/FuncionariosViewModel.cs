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

    }
}
