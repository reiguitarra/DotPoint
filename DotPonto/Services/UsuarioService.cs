using DotPonto.Data;
using DotPonto.Models;
using DotPonto.Services.Exception;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DotPonto.Services
{
    public class UsuarioService
    {
        private readonly DotPontoContext _context;

        public UsuarioService(DotPontoContext context)
        {
            _context = context;
        }

        public async Task<List<Usuarios>> FindAllAsync()
        {
            return await _context.Usuarios.OrderBy(x => x.Usuario).ToListAsync();
        }


        public async Task InsertAsync(Usuarios obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }


        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Usuarios.FindAsync(id);
                _context.Usuarios.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {

                throw new IntegrityException("Não foi possível remover o usuário, o mesmo possui registros " + e.Message);

            }
        }

        public async Task UpddateAsync(Usuarios obj)
        {
            bool hasAny = await _context.Usuarios.AnyAsync(x => x.UsuId == obj.UsuId);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {

                throw new DbConcurrencyException("Erro de concorrência! " + e.Message);
            }
        }
    }
}
