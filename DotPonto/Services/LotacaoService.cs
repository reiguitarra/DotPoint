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
    public class LotacaoService
    {
        private readonly DotPontoContext _context;

        public LotacaoService(DotPontoContext context)
        {
            _context = context;
        }


        public async Task<List<Lotacao>> FindAllAsync()
        {
            return await _context.Lotacao.OrderBy(x => x.LotNome).ToListAsync();
        }

        public async Task InsertAsync(Lotacao obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(Lotacao obj)
        {
            bool hasAny = await _context.Lotacao.AnyAsync(x => x.LotId == obj.LotId);
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

                throw new DbUpdateException("Erro de concorrência! "+ e.Message);
            }


        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Lotacao.FindAsync(id);
                _context.Lotacao.Remove(obj);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Não foi possível excluir a Lotação, a mesma já está sendo usada. " + e.Message);

            }

        }
            
    }
}
