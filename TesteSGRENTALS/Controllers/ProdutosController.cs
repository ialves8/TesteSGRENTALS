using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteSGRENTALS.Contexts;
using TesteSGRENTALS.Entities;
using X.PagedList;

namespace TesteSGRENTALS.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly Contexto _context;

        [TempData]
        public string Message { get; set; }

        public ProdutosController(Contexto context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index(int? pagina)
        {
            const int itensPorPagina = 3;
            int numeroPagina = (pagina ?? 1);
            return View(await _context.Produtos.ToPagedListAsync(numeroPagina, itensPorPagina));
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar, int? pagina)
        {

            const int itensPorPagina = 3;
            int numeroPagina = (pagina ?? 1);

            if (!String.IsNullOrEmpty(txtProcurar))
            {
                return View(await _context.Produtos.Where(x => x.Nome.ToUpper().Contains(txtProcurar.ToUpper())).ToList().ToPagedListAsync(numeroPagina, itensPorPagina));
            }

            return View(await _context.Produtos.ToList().ToPagedListAsync(numeroPagina, itensPorPagina));
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,Nome,Descricao,Preco")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();

                Message = "Produto cadastrado com sucesso...";

                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,Nome,Descricao,Preco")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();

                    Message = "Produto atualizado com sucesso...";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoId))
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
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            
            Message = "Produto excluído com sucesso...";

            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }
    }
}
