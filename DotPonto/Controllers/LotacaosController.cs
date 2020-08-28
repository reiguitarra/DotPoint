using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotPonto.Data;
using DotPonto.Models;

namespace DotPonto.Controllers
{
    public class LotacaosController : Controller
    {
        private readonly DotPontoContext _context;

        public LotacaosController(DotPontoContext context)
        {
            _context = context;
        }

        // GET: Lotacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lotacao.ToListAsync());
        }

        // GET: Lotacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lotacao = await _context.Lotacao
                .FirstOrDefaultAsync(m => m.LotId == id);
            if (lotacao == null)
            {
                return NotFound();
            }

            return View(lotacao);
        }

        // GET: Lotacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lotacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LotId,LotNome")] Lotacao lotacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lotacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lotacao);
        }

        // GET: Lotacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lotacao = await _context.Lotacao.FindAsync(id);
            if (lotacao == null)
            {
                return NotFound();
            }
            return View(lotacao);
        }

        // POST: Lotacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LotId,LotNome")] Lotacao lotacao)
        {
            if (id != lotacao.LotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lotacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LotacaoExists(lotacao.LotId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lotacao);
        }

        // GET: Lotacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lotacao = await _context.Lotacao
                .FirstOrDefaultAsync(m => m.LotId == id);
            if (lotacao == null)
            {
                return NotFound();
            }

            return View(lotacao);
        }

        // POST: Lotacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lotacao = await _context.Lotacao.FindAsync(id);
            _context.Lotacao.Remove(lotacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LotacaoExists(int id)
        {
            return _context.Lotacao.Any(e => e.LotId == id);
        }
    }
}
