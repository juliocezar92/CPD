
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPD.Data;
using CPD.Dominio.Entidades;
using CPD.Dominio.Enum;
using System.Globalization;

namespace CPD.Controllers
{
    public class ContribuicaoController : Controller
    {
        private readonly Context _context;

        public ContribuicaoController(Context context)
        {
            _context = context;
        }

        // GET: Contribuicao
        public async Task<IActionResult> Index()
        {
            return _context.Contribuicao != null ?
                        View(await _context.Contribuicao.ToListAsync()) :
                        Problem("Entity set 'Context.Contribuicao'  is null.");
        }


        // GET: Contribuicao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contribuicao == null)
            {
                return NotFound();
            }

            var contribuicao = await _context.Contribuicao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contribuicao == null)
            {
                return NotFound();
            }

            return View(contribuicao);
        }
        // GET: Contribuicao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contribuicao == null)
            {
                return NotFound();
            }

            var contribuicao = await _context.Contribuicao.FindAsync(id);
            if (contribuicao == null)
            {
                return NotFound();
            }
            return View(contribuicao);
        }

        // GET: Contribuicao/Create
        public IActionResult Create(int id, string valor)
        {
            var contribuinte = _context.Contribuinte.Include(x => x.Pessoa).FirstOrDefault(x => x.Id == id);

            var model = new CreateContribuicaoDto
            {
                NomeContribuinte = contribuinte.Pessoa.Nome,
                ContribuinteId = contribuinte.Id,
                Valor = contribuinte.ValorContribuicao,
                ValorLiquido = 0, // Preencha com um valor padrão ou necessário
            };

            return View(model);
        }

        // POST: Contribuicao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContribuinteId,NomeContribuinte,Valor,ValorLiquido,DataContribuicao,TipoContribuicao")] CreateContribuicaoDto request)
        {
            if (ModelState.IsValid)
            {
                var contribuicao = new Contribuicao
                {
                    ContribuinteId = request.ContribuinteId,
                    Valor = request.Valor,
                    DataContribuicao = DateTime.Now,
                    TipoContribuicao = request.TipoContribuicao,
                    ValorLiquido = request.ValorLiquido
                };
                _context.Contribuicao.Add(contribuicao);
                await _context.SaveChangesAsync();
                TempData["MensagemSucesso"] = "Contribuição foi salva com sucesso.";
                // return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // POST: Contribuicao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor,ValorLiquido,DataContribuicao,TipoContribuicao")] Contribuicao contribuicao)
        {
            if (id != contribuicao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contribuicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContribuicaoExists(contribuicao.Id))
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
            return View(contribuicao);
        }

        // GET: Contribuicao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contribuicao == null)
            {
                return NotFound();
            }

            var contribuicao = await _context.Contribuicao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contribuicao == null)
            {
                return NotFound();
            }

            return View(contribuicao);
        }

        // POST: Contribuicao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contribuicao == null)
            {
                return Problem("Entity set 'Context.Contribuicao'  is null.");
            }
            var contribuicao = await _context.Contribuicao.FindAsync(id);
            if (contribuicao != null)
            {
                _context.Contribuicao.Remove(contribuicao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContribuicaoExists(int id)
        {
            return (_context.Contribuicao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
