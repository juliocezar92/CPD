using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CPD.Data;
using CPD.Dominio.Entidades;
using CPD.Dtos;

namespace CPD.Controllers
{
    public class ProjetosController : Controller
    {
        private readonly Context _context;

        public ProjetosController(Context context)
        {
            _context = context;
        }

        // GET: Projetos
        public async Task<IActionResult> Index()
        {
            var projetos = await _context.Projeto.Select(x => new ProjetoDto
            {
                DataFim = x.DataFim,
                ComunidadeId = x.ComunidadeId,
                DataInicio = x.DataInicio,
                Id = x.Id,
                Name = x.Name,
                ValorEstimado = x.ValorEstimado,
                NomeComunidade = x.Comunidade.Nome
                
            }).ToListAsync();

            foreach (var projeto in projetos)
            {
                var contribuicoes = (from c in _context.Contribuinte
                                     join co in _context.Contribuicao on c.Id equals co.ContribuinteId
                                     where c.ProjetoId == projeto.Id
                                     select co.ValorLiquido).ToList();
                projeto.ValorArrecadado = contribuicoes.Sum();
            }

            return View(projetos);
        }

        // GET: Projetos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projeto == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // GET: Projetos/Create
        public IActionResult Create()
        {
            var model = new ProjetoDto
            {
                ListadeComunidades = _context.Comunidade.Select(x => new ComunidadeDto { Id = x.Id, Nome = x.Nome }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjetoDto projeto)
        {
            if (ModelState.IsValid)
            {
                var projetos = new Projeto
                {
                    Id = projeto.Id,
                    Name = projeto.Name,
                    ValorEstimado = projeto.ValorEstimado,
                    ComunidadeId = projeto.ComunidadeId,
                    DataFim = projeto.DataFim,
                    DataInicio = projeto.DataInicio
                };
                _context.Add(projetos);
                await _context.SaveChangesAsync();
            }
            TempData["MensagemSucesso"] = "Salvo com sucesso.";

            return View(projeto);
        }

        // GET: Projetos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null || _context.Projeto == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }
            var projetoDto = new ProjetoDto
            {
                Id = projeto.Id,
                Name = projeto.Name,
                ComunidadeId = projeto.ComunidadeId,
                DataInicio = projeto.DataInicio,
                DataFim = projeto.DataFim,
                ValorEstimado = projeto.ValorEstimado,
                ListadeComunidades = _context.Comunidade.Select(x => new ComunidadeDto { Id = x.Id, Nome = x.Nome }).ToList()
            };
            return View(projetoDto);
        }

        // POST: Projetos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjetoDto projetoDto)
        {
            if (id != projetoDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var projeto = await _context.Projeto.FindAsync(projetoDto.Id);

                    if (projeto == null)
                    {
                        return NotFound();
                    }

                    // Atualize as propriedades do objeto "projeto" com os valores do "projetoDto"
                    projeto.Name = projetoDto.Name;
                    projeto.ComunidadeId = projetoDto.ComunidadeId;
                    projeto.DataInicio = projetoDto.DataInicio;
                    projeto.DataFim = projetoDto.DataFim;
                    projeto.ValorEstimado = projetoDto.ValorEstimado;

                    _context.Update(projeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoExists(projetoDto.Id))
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
            return View(projetoDto);
        }

        // GET: Projetos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projeto == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projeto == null)
            {
                return NotFound();
            }

            var projetoDto = new ProjetoDto
            {
                Id = projeto.Id,
                Name = projeto.Name,
                ComunidadeId = projeto.ComunidadeId,
                DataInicio = projeto.DataInicio,
                DataFim = projeto.DataFim,
                ValorEstimado = projeto.ValorEstimado
            };

            return View(projetoDto);
        }

        // POST: Projetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Projeto == null)
            {
                return Problem("Entity set 'Context.Projeto'  is null.");
            }

            var projeto = await _context.Projeto.FindAsync(id);
            if (projeto != null)
            {
                _context.Projeto.Remove(projeto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetoExists(int id)
        {
            return (_context.Projeto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
