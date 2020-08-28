using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotPonto.Models
{
    public class Lotacao
    {
        [Key]
        public int LotId { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "{0} é Requerido!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "O nome {0} deve ter de {2} a {1} Caracteres!")]
        public string LotNome { get; set; }

        public Lotacao()
        {

        }

        public Lotacao(int lotId, string lotNome)
        {
            LotId = lotId;
            LotNome = lotNome;
        }

        public int ContaRegistros()
        {
            List<int> reg = new List<int>();
            reg.Add(LotId);

            int res = reg.Count();

            return res;
        }
    }
}
