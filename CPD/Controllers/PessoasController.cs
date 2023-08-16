using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPD.Data;
using CPD.Dominio.Entidades;
using CPD.Dtos;

namespace CPD.Controllers
{
    public class PessoasController : Controller
    {
        private readonly Context _context;

        public PessoasController(Context context)
        {
            _context = context;
        }

        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            var  pessoa = _context.Pessoa;

            var listaDePessoas = pessoa.Select(pessoa => new PessoaDto
            {
                Id = pessoa.Id,
                ComunidadeId = pessoa.ComunidadeId,
                Nome = pessoa.Nome,
                Telefone = pessoa.Telefone,
                Email = pessoa.Email,
                Endereco = pessoa.Endereco,
                TipoPessoa = pessoa.TipoPessoa,
                NomeComunidade = pessoa.Comunidade.Nome
            }
            ).ToList();
            return View(listaDePessoas);          
        }

        // GET: Pessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pessoa == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            
            var model = new PessoaDto
            {
                ListadeComunidades = _context.Comunidade.Select(x => new ComunidadeDto { Id = x.Id, Nome = x.Nome }).ToList()
            };
            return View(model);
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( PessoaDto pessoa)
        {
            if (ModelState.IsValid)
            {
                var pessoaModel = new Pessoa
                {
                    Nome = pessoa.Nome,
                    ComunidadeId = pessoa.ComunidadeId,
                    Email = pessoa.Email,
                    Endereco = pessoa.Endereco,
                    Telefone = pessoa.Telefone,
                    TipoPessoa = pessoa.TipoPessoa
                };
                _context.Add(pessoaModel);

                await _context.SaveChangesAsync();

                TempData["MensagemSucesso"] = "Salvo com sucesso.";

            }
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pessoa == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            var pessoaDto = new PessoaDto
            {
                Nome = pessoa.Nome,
                ComunidadeId = pessoa.ComunidadeId,
                Email = pessoa.Email,
                Endereco = pessoa.Endereco,
                Telefone = pessoa.Telefone,
                TipoPessoa = pessoa.TipoPessoa,
                ListadeComunidades = _context.Comunidade.Select(x => new ComunidadeDto { Id = x.Id, Nome = x.Nome }).ToList()
            };

            return View(pessoaDto);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Telefone,Email,Endereco,TipoPessoa")] Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.Id))
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
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pessoa == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            var pessoaDto = new PessoaDto
            {
                Nome = pessoa.Nome,
                ComunidadeId = pessoa.ComunidadeId,
                Email = pessoa.Email,
                Endereco = pessoa.Endereco,
                Telefone = pessoa.Telefone,
                TipoPessoa = pessoa.TipoPessoa
            };

            return View(pessoaDto);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pessoa == null)
            {
                return Problem("Entity set 'Context.Pessoa'  is null.");
            }
            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa != null)
            {
                _context.Pessoa.Remove(pessoa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(int id)
        {
          return (_context.Pessoa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
