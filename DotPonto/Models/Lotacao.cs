using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotPonto.Models
{
    public class Lotacao
    {
        public int LotId { get; set; }
        public string LotNome { get; set; }

        public Lotacao()
        {

        }

        public Lotacao(int lotId, string lotNome)
        {
            LotId = lotId;
            LotNome = lotNome;
        }
    }
}
