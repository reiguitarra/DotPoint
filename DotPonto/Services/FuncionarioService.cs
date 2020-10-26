using DotPonto.Data;
using DotPonto.Models;
using DotPonto.Models.ViewModels;
using DotPonto.Services.Exception;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DotPonto.Services
{
    public class FuncionarioService
    {
        private readonly DotPontoContext _context;


        public FuncionarioService(DotPontoContext context)
        {
            _context = context;
        }

        public async Task<List<Funcionarios>> FindAllAsync()
        {
            return await _context.Funcionarios.OrderBy(x => x.Nome)
                
                .Include(x => x.Empresas)
                .Include(x => x.Filiais)
                .Include(x => x.Lotacao)
                .ToListAsync();
        }

        public async Task<Funcionarios> FindByIdAsync(int id)
        {
            return await _context.Funcionarios.FirstOrDefaultAsync(obj => obj.FuId == id);
        }


        public async Task InsertAsync(Funcionarios obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(Funcionarios obj)
        {
            bool hasAny = await _context.Funcionarios.AnyAsync(x => x.FuId == obj.FuId);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado! ");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {

                throw new DbUpdateException("Erro de concorrência! " + e.Message);
            }


        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Funcionarios.FindAsync(id);
                _context.Funcionarios.Remove(obj);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Não foi possível excluir a Lotação, a mesma já está sendo usada. " + e.Message);

            }

        }

        public int CalculoIdade(DateTime dt)
        {
            TimeSpan ida = DateTime.Now.Subtract(dt);

            int res = ida.Days / 365;

            return res;

        }

    }
}
