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
    public class FilialService
    {
        private readonly DotPontoContext _context;

        public FilialService(DotPontoContext context)
        {
            _context = context;
        }

        public async Task<List<Filiais>> FindAllAsync()
        {
            return await _context.Filiais.OrderBy(x => x.RazaoSocial).ToListAsync();
        }

        public async Task<Filiais> FindById(int id)
        {
            return await _context.Filiais.FirstOrDefaultAsync(obj => obj.Id == id);
        }


        public async Task InsertAsync(Filiais obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(Filiais obj)
        {
            bool hasAny = await _context.Filiais.AnyAsync(x => x.Id == obj.Id);
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
                var obj = await _context.Filiais.FindAsync(id);
                _context.Filiais.Remove(obj);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Não foi possível excluir a Filial, a mesma já está sendo usada. " + e.Message);

            }

        }
    }
}
