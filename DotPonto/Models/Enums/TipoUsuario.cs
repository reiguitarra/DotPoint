using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotPonto.Models.Enums
{
    public enum TipoUsuario : int
    {
        Geral = 0,
        Admnistrador = 1,
        Gerente = 2,
        Analista = 3,
        Digitador = 4,
        Relatorio = 5
    }
}
