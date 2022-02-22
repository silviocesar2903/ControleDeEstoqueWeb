using System.Linq;
using System.Threading.Tasks;
using ControleDeEstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoqueWeb.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ControleDeEstoqueWebContext _context;

        public ClienteController(ControleDeEstoqueWebContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
           return View(await _context.Clientes.OrderBy(x => x.Nome).AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? id)
        {
            if(id.HasValue)
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if(cliente == null)
                {
                    return NotFound();
                }
                return View(cliente);
            }
            return View(new ClienteModel());
        }

        private bool ClienteExiste(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(int? id,[FromForm]ClienteModel cliente)
        {
            if(ModelState.IsValid)
            {
                if(id.HasValue)
                {
                    if(ClienteExiste(id.Value))
                    {
                        _context.Update(cliente);
                        if(await _context.SaveChangesAsync() > 0)
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Cliente alterado com sucesso!!");
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao alterar cliente!!", TipoMensagem.Erro);
                        }
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Cliente não encontrado!!!", TipoMensagem.Erro);
                    }
                }
                else
                {
                    _context.Add(cliente);
                    if(await _context.SaveChangesAsync() > 0)
                    {
                            TempData["mensagem"] = MensagemModel.Serializar("Cliente cadastrado com sucesso!!");
                    }
                    else
                    {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar cliente", TipoMensagem.Erro);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(cliente);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            if(!id.HasValue)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Cliente não informado!!", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if(cliente == null)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Cliente não informado!!", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }
        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if(cliente != null)
            {
                _context.Clientes.Remove(cliente);
                if(await _context.SaveChangesAsync() > 0)
                {
                   TempData["mensagem"] = MensagemModel.Serializar("Cliente excluido com sucesso!!");
                }
                else
                {
                    TempData["mensagem"] = MensagemModel.Serializar("Não foi possivel exlcuir o cliente!!", TipoMensagem.Erro);
                }
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Cliente não encontrado!!!", TipoMensagem.Erro);
            }
            return RedirectToAction(nameof(Index));

        }
    }
}