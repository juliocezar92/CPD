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
    public class ComunidadesController : Controller
    {
        private readonly Context _context;

        public ComunidadesController(Context context)
        {
            _context = context;
        }

        // GET: Comunidades
        public async Task<IActionResult> Index()
        {
            var comunidade = _context.Comunidade;

            var listaComunidades = comunidade.Select(comunidade => new ComunidadeDto
            {
                Id = comunidade.Id,
                Nome = comunidade.Nome,
                Endereco = comunidade.Endereco,
            }).ToList();
            return View(listaComunidades);  
        }

        // GET: Comunidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comunidade == null)
            {
                return NotFound();
            }

            var comunidade = await _context.Comunidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comunidade == null)
            {
                return NotFound();
            }

            return View(comunidade);
        }

        // GET: Comunidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comunidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Endereco")] Comunidade comunidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comunidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comunidade);
        }

        // GET: Comunidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comunidade == null)
            {
                return NotFound();
            }

            var comunidade = await _context.Comunidade.FindAsync(id);
            if (comunidade == null)
            {
                return NotFound();
            }
            var comunidadeDto = new ComunidadeDto
            {
                Id = comunidade.Id,
                Nome = comunidade.Nome,
                Endereco = comunidade.Endereco
            };
            return View(comunidadeDto);
        }

        // POST: Comunidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Endereco")] Comunidade comunidade)
        {
            if (id != comunidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comunidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComunidadeExists(comunidade.Id))
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
            return View(comunidade);
        }

        // GET: Comunidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comunidade == null)
            {
                return NotFound();
            }

            var comunidade = await _context.Comunidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comunidade == null)
            {
                return NotFound();
            }
            var comunidadeDto = new ComunidadeDto
            {
                Id = comunidade.Id,
                Nome = comunidade.Nome,
                Endereco = comunidade.Endereco
            };

            return View(comunidadeDto);
        }

        // POST: Comunidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comunidade == null)
            {
                return Problem("Entity set 'Context.Comunidade'  is null.");
            }
            var comunidade = await _context.Comunidade.FindAsync(id);
            if (comunidade != null)
            {
                _context.Comunidade.Remove(comunidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComunidadeExists(int id)
        {
          return (_context.Comunidade?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
