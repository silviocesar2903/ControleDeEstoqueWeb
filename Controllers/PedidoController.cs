using System.Linq;
using System.Threading.Tasks;
using ControleDeEstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoqueWeb.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ControleDeEstoqueWebContext _context;

        public PedidoController(ControleDeEstoqueWebContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
           return View(await _context.Pedidos.OrderBy(x => x.IdPedido).AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? id)
        {
            var produtos = _context.Produtos.OrderBy(x => x.Nome).AsNoTracking().ToList();
            var produtosSelectList = new SelectList(produtos, 
                nameof(ProdutoModel.IdProduto), nameof(ProdutoModel.Nome));
            ViewBag.Produtos = produtosSelectList;
            if(id.HasValue)
            {
                var pedido = await _context.Pedidos.FindAsync(id);
                if(pedido == null)
                {
                    return NotFound();
                }
                return View(pedido);
            }
            return View(new PedidoModel());
        }

        private bool PedidoExiste(int id)
        {
            return _context.Pedidos.Any(e => e.IdPedido == id);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(int? id,[FromForm]PedidoModel pedido)
        {
            if(ModelState.IsValid)
            {
                if(id.HasValue)
                {
                    if(PedidoExiste(id.Value))
                    {
                        _context.Update(pedido);
                        if(await _context.SaveChangesAsync() > 0)
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Pedido alterado com sucesso!!");
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao alterar pedido!!", TipoMensagem.Erro);
                        }
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Pedido não encontrado!!!", TipoMensagem.Erro);
                    }
                }
                else
                {
                    pedido.ItemPedido.NomeProduto = pedido.ItemPedido.Produto.Nome;
                    _context.Add(pedido);
                    if(await _context.SaveChangesAsync() > 0)
                    {
                            TempData["mensagem"] = MensagemModel.Serializar("Pedido cadastrado com sucesso!!");
                    }
                    else
                    {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar pedido", TipoMensagem.Erro);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(pedido);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            if(!id.HasValue)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Pedido não informado!!", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
            var pedido = await _context.Pedidos.FindAsync(id);
            if(pedido == null)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Pedido não informado!!", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }
        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if(pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                if(await _context.SaveChangesAsync() > 0)
                {
                   TempData["mensagem"] = MensagemModel.Serializar("Pedido excluido com sucesso!!");
                }
                else
                {
                    TempData["mensagem"] = MensagemModel.Serializar("Não foi possivel exlcuir o pedido!!", TipoMensagem.Erro);
                }
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Pedido não encontrado!!!", TipoMensagem.Erro);
            }
            return RedirectToAction(nameof(Index));

        }
    }
}