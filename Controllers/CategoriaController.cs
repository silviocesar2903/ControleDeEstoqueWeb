using System.Linq;
using System.Threading.Tasks;
using ControleDeEstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoqueWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ControleDeEstoqueWebContext _context;

        public CategoriaController(ControleDeEstoqueWebContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
           return View(await _context.Categorias.OrderBy(x => x.Nome).AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? id)
        {
            if(id.HasValue)
            {
                var categoria = await _context.Categorias.FindAsync(id);
                if(categoria == null)
                {
                    return NotFound();
                }
                return View(categoria);
            }
            return View(new CategoriaModel());
        }

        private bool CategorExiste(int id)
        {
            return _context.Categorias.Any(e => e.IdCategoria == id);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(int? id,[FromForm]CategoriaModel categoria)
        {
            if(ModelState.IsValid)
            {
                if(id.HasValue)
                {
                    if(CategorExiste(id.Value))
                    {
                        _context.Update(categoria);
                        if(await _context.SaveChangesAsync() > 0)
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Categoria alterada com sucesso!!");
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao alterar categoria!!", TipoMensagem.Erro);
                        }
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Categoria não encontrada!!!", TipoMensagem.Erro);
                    }
                }
                else
                {
                    _context.Add(categoria);
                    if(await _context.SaveChangesAsync() > 0)
                    {
                            TempData["mensagem"] = MensagemModel.Serializar("Categoria cadastrada com sucesso!!");
                    }
                    else
                    {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar categoria", TipoMensagem.Erro);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(categoria);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            if(!id.HasValue)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Categoria não informada!!", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
            var categoria = await _context.Categorias.FindAsync(id);
            if(categoria == null)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Categoria não informada!!", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }
        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if(categoria != null)
            {
                _context.Categorias.Remove(categoria);
                if(await _context.SaveChangesAsync() > 0)
                {
                   TempData["mensagem"] = MensagemModel.Serializar("Categoria excluida com sucesso!!");
                }
                else
                {
                    TempData["mensagem"] = MensagemModel.Serializar("Não foi possivel exlcuir a categoria!!", TipoMensagem.Erro);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Categoria não encontrada!!!", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}