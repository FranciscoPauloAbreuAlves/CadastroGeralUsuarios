using CadastroGeral.Filters;
using CadastroGeral.Helper;
using CadastroGeral.Interfaces;
using CadastroGeral.Models;
using CadastroGeral.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CadastroGeral.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        //Declarar dependências de interfaces de banco de dados
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessaoUsuario _sessaoUsuario;//Inserir após relacionamento

        //private readonly IUsuarioRepositorio _usuarioRepositorio;
        //public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        //{
        //    _usuarioRepositorio = usuarioRepositorio;
        //}

        public UsuarioController(
           IUsuarioRepositorio usuarioRepositorio,
           ISessaoUsuario sessaoUsuario)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessaoUsuario = sessaoUsuario;
        }

        public IActionResult Index()
        {
            UsuarioModel usuarioLogado = _sessaoUsuario.BuscarSessaoUsuario();//Inserido após relacionamento
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos(usuarioLogado.Id);
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }


        //[HttpPost]
        ////public IActionResult Criar(UsuarioModel Usuario)
        ////{
        ////    try
        ////    {
        ////        if (ModelState.IsValid)
        ////        {
        ////            Usuario = _usuarioRepositorio.Criar(Usuario);
        ////            TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
        ////            return RedirectToAction("Index");
        ////        }
        ////        return View(Usuario);
        ////    }
        ////    catch (Exception erro)
        ////    {
        ////        TempData["MensagemErro"] = $"Ops, o usuário não foi cadastrado! Detalhe do erro: {erro.Message}";
        ////        return RedirectToAction("Index");
        ////    }
        ////}

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessaoUsuario.BuscarSessaoUsuario(); //Inserir após relacionamento
                    usuario.Id = usuarioLogado.Id; //Inserir após relacionamento
                    usuario = _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, o usuário não foi cadastrado! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }




        [HttpPost]
        public IActionResult Alterar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", usuario);//Vai cair na view de editar, pois não tem view alterar.
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, o usuário não foi alterado! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorId(id);
            return View(usuario);
        }

        [HttpPost]//Trocar por usuarioSemSenha depois
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuarioSemSenha = null;

                if (ModelState.IsValid)
                {
                    usuarioSemSenha = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil
                    };

                    usuarioSemSenha = _usuarioRepositorio.Atualizar(usuarioSemSenha);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuarioSemSenha);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, o usuário não foi alterado! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

       
        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel buscaUsuario = _usuarioRepositorio.BuscarPorId(id);
            return View(buscaUsuario);
        }

        
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagaUsuario = _usuarioRepositorio.Apagar(id);

                if (apagaUsuario)
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
