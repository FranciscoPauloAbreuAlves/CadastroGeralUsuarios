using CadastroGeral.Filters;
using CadastroGeral.Interfaces;
using CadastroGeral.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroGeral.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            //Inserir os dados do banco na tabela:
            List<UsuarioModel> ListaUsuarios = _usuarioRepositorio.BuscarTodosUsuarios();
            return View(ListaUsuarios);
        }

        //Método criar
        public IActionResult Criar()
        {
            return View();
        }

        //Método criar
        [HttpPost]
        public IActionResult Criar(UsuarioModel criarUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    criarUsuario = _usuarioRepositorio.Adicionar(criarUsuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(criarUsuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, o usuário não foi cadastrado! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        //Método alterar
        [HttpPost]
        public IActionResult Alterar(UsuarioModel postarUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Atualizar(postarUsuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", postarUsuario);//Vai cair na view de editar, pois não tem view alterar.
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, o usuário não foi alterado! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        //Método editar
        public IActionResult Editar(int id)
        {
            UsuarioModel editarUsuario = _usuarioRepositorio.BuscarPorId(id);
            return View(editarUsuario);
        }

        [HttpPost]//Trocar por usuarioSemSenha depois
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel editarUsuarioSemSenha = null;

                if (ModelState.IsValid)
                {
                    editarUsuarioSemSenha = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil
                    };

                    editarUsuarioSemSenha = _usuarioRepositorio.Atualizar(editarUsuarioSemSenha);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(editarUsuarioSemSenha);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, o usuário não foi alterado! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        //Método confirmar exclusão
        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorId(id);
            return View(usuario);
        }

        //Método apagar
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagar = _usuarioRepositorio.Apagar(id);

                if (apagar)
                {
                    TempData["MensagemSucesso"] = "Usuario excluído com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops! o usuário não foi excluído!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, o usuário não foi excluído! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
