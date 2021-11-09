using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Cadastro()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario l)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

            l.senha = Criptografo.TextoCriptografado(l.senha);

            UsuarioService usuarioService = new UsuarioService();

            if(l.Id == 0)
            {
                usuarioService.Inserir(l);
            }
            else
            {
                usuarioService.Atualizar(l);
            }

            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            UsuarioService usuarioService = new UsuarioService();
            return View(usuarioService.ListarTodos());
        }

        public IActionResult Edicao(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            UsuarioService ls = new UsuarioService();
            Usuario l = ls.ObterPorId(id);
            return View(l);
        }
        public IActionResult Exclusao(Usuario l)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            ViewData["Mensagem"] = "Usuario Excluido";
            new UsuarioService().ExcluirUsuario(l);
            
            return View("Listagem", new UsuarioService().ListarTodos());
        }
        public IActionResult NeedAdmin()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }
    }
}