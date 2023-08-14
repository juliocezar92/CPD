using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CPD.Data;
using CPD.Dominio.Entidades;
using CPD.Dominio.Enum;




namespace CPD.Controllers
{
    public class ContribuintesController : Controller
    {
        private readonly Context _context;

        public ContribuintesController(Context context)
        {
            _context = context;
        }

        // GET: Contribuintes
        public IActionResult Index()
        {
            var contribuintes = _context.Contribuinte;


            var listaDeContribuintes = contribuintes.Select(contribuinte => new ContribuinteDto
            {
                Id = contribuinte.Id,
                PessoaId = contribuinte.PessoaId,
                PessoaResponsavelId = contribuinte.PessoaResponsavelId,
                ProjetoId = contribuinte.ProjetoId,
                ValorContribuicao = contribuinte.ValorContribuicao,
                Periodicidade = contribuinte.Periodicidade,
                DataInicio = contribuinte.DataInicio,
                DataFim = contribuinte.DataFim,
                NomePessoa = contribuinte.Pessoa.Nome,
                NomeProjeto = contribuinte.Projeto.Name,
                NomeResponsavel = contribuinte.PessoaResponsavel.Nome
            }).ToList();

            return View(listaDeContribuintes);
        }
        public IActionResult Create()
        {
            // Filtrar as pessoas com TipoPessoa.Devoto
            var pessoasResponsaveis = _context.Pessoa.Where(x => x.TipoPessoa == TipoPessoa.Responsavel).Select(x => new PessoaSimplesDto { Id = x.Id, Nome = x.Nome }).ToList();
            var pessoasDevotos = _context.Pessoa.Where(x => x.TipoPessoa == TipoPessoa.Devoto).Select(x => new PessoaSimplesDto { Id = x.Id, Nome = x.Nome }).ToList();
            var model = new ContribuinteDto
            {
                ListaDePessoas = pessoasDevotos,
                ListaDepessoasResponsavel = pessoasResponsaveis,
                ListaDeProjetos = _context.Projeto.Select(x => new ProjetoSimplesDto { Id = x.Id, Nome = x.Name }).ToList(),
            };

            return View(model);
        }


        // GET: Contribuintes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contribuinte == null)
            {
                return NotFound();
            }

            var contribuinte = await _context.Contribuinte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contribuinte == null)
            {
                return NotFound();
            }

            return View(contribuinte);
        }

        // POST: Contribuintes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreatePessoaDto CreatePessoaDto)
        {

            if (ModelState.IsValid) 
            {
                
                var contribuinte = new Contribuinte
                {
                    PessoaId = CreatePessoaDto.PessoaId,
                    PessoaResponsavelId = CreatePessoaDto.PessoaResponsavelId,
                    ProjetoId = CreatePessoaDto.ProjetoId,
                    ValorContribuicao = CreatePessoaDto.ValorContribuicao,
                    Periodicidade = CreatePessoaDto.Periodicidade,
                    DataInicio = CreatePessoaDto.DataInicio,
                    DataFim = CreatePessoaDto.DataFim,
                    // Preencha as outras propriedades da entidade Contribuinte, se houver
                };
                _context.Add(contribuinte);
                
                await _context.SaveChangesAsync();
              
                TempData["MensagemSucesso"] = "Doação foi salva com sucesso.";

            }

            return RedirectToAction("Create");
        }

        // GET: Contribuintes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contribuinte == null)
            {
                return NotFound();
            }

            var contribuinte = await _context.Contribuinte.FindAsync(id);
            if (contribuinte == null)
            {
                return NotFound();
            }
            return View(contribuinte);
        }

        // POST: Contribuintes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ValorContribuicao,Periodicidade,DataInicio,DataFim")] Contribuinte contribuinte)
        {
            if (id != contribuinte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contribuinte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContribuinteExists(contribuinte.Id))
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
            return View(contribuinte);
        }

        // GET: Contribuintes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contribuinte == null)
            {
                return NotFound();
            }

            var contribuinte = await _context.Contribuinte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contribuinte == null)
            {
                return NotFound();
            }

            return View(contribuinte);
        }

        // POST: Contribuintes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contribuinte == null)
            {
                return Problem("Entity set 'Context.Contribuinte'  is null.");
            }
            var contribuinte = await _context.Contribuinte.FindAsync(id);
            if (contribuinte != null)
            {
                _context.Contribuinte.Remove(contribuinte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContribuinteExists(int id)
        {
          return (_context.Contribuinte?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
