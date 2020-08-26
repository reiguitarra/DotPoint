using DotPonto.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotPonto.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuId { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public Usuarios()
        {

        }

        public Usuarios(int usuId, string usuario, string senha, string email, TipoUsuario tipoUsuario, bool ativo)
        {
            UsuId = usuId;
            Usuario = usuario;
            Senha = senha;
            Email = email;
            TipoUsuario = tipoUsuario;
            Ativo = true;

        }


    }
}
