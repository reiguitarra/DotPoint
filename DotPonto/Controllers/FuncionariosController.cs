using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotPonto.Models;
using DotPonto.Models.ViewModels;
using DotPonto.Services;
using DotPonto.Services.Exception;
using System.Diagnostics;

namespace DotPonto.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly FuncionarioService _funcionarioService;
        private readonly EmpresaService _empresaService;
        private readonly FilialService _filialService;
        private readonly LotacaoService _lotacaoService;

        public FuncionariosController(FuncionarioService funcionarioService, EmpresaService empresaService, FilialService filialService, LotacaoService lotacaoService)
        {
            _funcionarioService = funcionarioService;
            _empresaService = empresaService;
            _filialService = filialService;
            _lotacaoService = lotacaoService;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            var fuList = await _funcionarioService.FindAllAsync();
            return View(fuList);
                
                /*_context.Funcionarios.Include(f => f.Empresas).Include(f => f.Filiais).Include(f => f.Lotacao);
            return View(await dotPontoContext.ToListAsync());*/
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foenecido" });
            }

            var funcionarios = await _funcionarioService.FindByIdAsync(id.Value);
               
            if (funcionarios == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foenecido" });
            }

            return View(funcionarios);
        }

        // GET: Funcionarios/Create
        public async Task<IActionResult> Create()
        {
            /* ViewData["EmpresasId"] = new SelectList(_context.Empresas, "Id", "RazaoSocial");
             ViewData["FiliaisId"] = new SelectList(_context.Filiais, "Id", "Id");
             ViewData["LotacaoId"] = new SelectList(_context.Lotacao, "LotId", "LotNome");*/

            var emp = await _empresaService.FindAllAsync();
            var fil = await _filialService.FindAllAsync();
            var lot = await _lotacaoService.FindAllAsync();

            var func = new FuncionariosViewModel { Empresas = emp, Filiais = fil, Lotacao = lot };
            return View(func);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Funcionarios funcionarios)
        {
            if (!ModelState.IsValid)
            {
                var empresas = await _empresaService.FindAllAsync();
                var fil = await _filialService.FindAllAsync();
                var lot = await _lotacaoService.FindAllAsync();
                var viewModel = new FuncionariosViewModel { Funcionarios = funcionarios, Empresas = empresas, Filiais = fil, Lotacao = lot };

                return View(viewModel);
                

             }

            await _funcionarioService.InsertAsync(funcionarios);
            return RedirectToAction(nameof(Index));

           /* ViewData["EmpresasId"] = new SelectList(_context.Empresas, "Id", "RazaoSocial", funcionarios.EmpresasId);
            ViewData["FiliaisId"] = new SelectList(_context.Filiais, "Id", "Id", funcionarios.FiliaisId);
            ViewData["LotacaoId"] = new SelectList(_context.Lotacao, "LotId", "LotNome", funcionarios.LotacaoId);*/
            
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido! " });
            }

            var funcionarios = await _funcionarioService.FindByIdAsync(id.Value);
            if (funcionarios == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido! " });
            }
           
            /*ViewData["EmpresasId"] = new SelectList(_context.Empresas, "Id", "RazaoSocial", funcionarios.EmpresasId);
            ViewData["FiliaisId"] = new SelectList(_context.Filiais, "Id", "Id", funcionarios.FiliaisId);
            ViewData["LotacaoId"] = new SelectList(_context.Lotacao, "LotId", "LotNome", funcionarios.LotacaoId);*/
            return View(funcionarios);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , Funcionarios funcionarios)
        {

            if (!ModelState.IsValid)
            {
                var emp = await _empresaService.FindAllAsync();
                var fil = await _filialService.FindAllAsync();
                var lot = await _lotacaoService.FindAllAsync();
                var viewModel = new FuncionariosViewModel { Funcionarios = funcionarios, Empresas = emp, Filiais = fil, Lotacao = lot };

                return View(viewModel);
            }

            if (id != funcionarios.FuId)
            {
                return RedirectToAction(nameof(Error), new { message = "Os Ids não correspondem!" });
            }


            try
            {
                await _funcionarioService.UpdateAsync(funcionarios);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {

                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido! " });
            }

            var obj = await _funcionarioService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado no objeto! " });
            }

            return View(obj);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _funcionarioService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));

            }
            catch (IntegrityException e)
            {

                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        private Task FuncionariosExists(int id)
        {
            return _funcionarioService.FindByIdAsync(id);
        }


        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
