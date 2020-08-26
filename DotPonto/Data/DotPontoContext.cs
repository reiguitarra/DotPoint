using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotPonto.Models;
using Microsoft.EntityFrameworkCore;

namespace DotPonto.Data
{
    public class DotPontoContext : DbContext
    {

        public DotPontoContext(DbContextOptions<DotPontoContext> options) : base(options)
        {

        }

        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Filiais> Filiais { get; set; }
        public DbSet<Lotacao> Lotacao { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }

    }
}
