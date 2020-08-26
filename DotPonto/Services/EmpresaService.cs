using DotPonto.Data;
using DotPonto.Models;
using DotPonto.Services.Exception;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotPonto.Services
{
    public class EmpresaService
    {
        private readonly DotPontoContext _context;

        public EmpresaService(DotPontoContext context)
        {
            _context = context;
        }


        public async Task<List<Empresas>> FindAllAsync()
        {
            return await _context.Empresas.OrderBy(x => x.RazaoSocial).ToListAsync();
        }

        public async Task<Empresas> FindById(int id)
        {
            return await _context.Empresas.FirstOrDefaultAsync(obj => obj.Id == id);
        }


        public async Task InsertAsync(Empresas obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(Empresas obj)
        {
            bool hasAny = await _context.Empresas.AnyAsync(x => x.Id == obj.Id);
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
                var obj = await _context.Empresas.FindAsync(id);
                _context.Empresas.Remove(obj);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Não foi possível excluir a Empresa, a mesma já está sendo usada. " + e.Message);

            }

        }



    }
}
