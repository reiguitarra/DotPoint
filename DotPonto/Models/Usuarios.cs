using DotPonto.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [Display(Name = "Usuário")]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name ="E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string UsuTelefone { get; set; }

        [Display(Name = "Celular")]
        public string UsuCelular { get; set; }
        public bool Ativo { get; set; }

       
        [Display(Name = "Tipo")]
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
