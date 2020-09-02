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
    public class FiliaisController : Controller
    {
        private readonly DotPontoContext _context;

        public FiliaisController(DotPontoContext context)
        {
            _context = context;
        }

        // GET: Filiais
        public async Task<IActionResult> Index()
        {
            var dotPontoContext = _context.Filiais.Include(f => f.Empresas);
            return View(await dotPontoContext.ToListAsync());
        }

        // GET: Filiais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiais = await _context.Filiais
                .Include(f => f.Empresas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filiais == null)
            {
                return NotFound();
            }

            return View(filiais);
        }

        // GET: Filiais/Create
        public IActionResult Create()
        {
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "Id", "RazaoSocial");
            return View();
        }

        // POST: Filiais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RazaoSocial,EmpEndereco,EmpEndNumero,EmpEndBairro,EmpEndCidade,EmpEndUF,EmpEndCEP,CNAE,InscricaoMunicipal,InscricaoEstadual,EmpresasId")] Filiais filiais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filiais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "Id", "RazaoSocial", filiais.EmpresasId);
            return View(filiais);
        }

        // GET: Filiais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiais = await _context.Filiais.FindAsync(id);
            if (filiais == null)
            {
                return NotFound();
            }
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "Id", "RazaoSocial", filiais.EmpresasId);
            return View(filiais);
        }

        // POST: Filiais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RazaoSocial,EmpEndereco,EmpEndNumero,EmpEndBairro,EmpEndCidade,EmpEndUF,EmpEndCEP,CNAE,InscricaoMunicipal,InscricaoEstadual,EmpresasId")] Filiais filiais)
        {
            if (id != filiais.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filiais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiliaisExists(filiais.Id))
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
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "Id", "RazaoSocial", filiais.EmpresasId);
            return View(filiais);
        }

        // GET: Filiais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiais = await _context.Filiais
                .Include(f => f.Empresas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filiais == null)
            {
                return NotFound();
            }

            return View(filiais);
        }

        // POST: Filiais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filiais = await _context.Filiais.FindAsync(id);
            _context.Filiais.Remove(filiais);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiliaisExists(int id)
        {
            return _context.Filiais.Any(e => e.Id == id);
        }
    }
}
