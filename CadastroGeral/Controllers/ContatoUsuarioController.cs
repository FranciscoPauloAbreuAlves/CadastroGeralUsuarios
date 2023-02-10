using CadastroGeral.Filters;
using CadastroGeral.Interfaces;
using CadastroGeral.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroGeral.Controllers
{
    [PaginaUsuarioLogado]
    //[PaginaMembroLogado]
    public class ContatoUsuarioController : Controller
    {
        //Declarar dependências de interfaces de banco de dados
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly ISessaoUsuario _sessaoUsuario;//Inserir após relacionamento


        //Injetar dependências das interfaces
        public ContatoUsuarioController(
            IContatoRepositorio contatoRepositorio,
            ISessaoUsuario sessaoUsuario)
        {
            _contatoRepositorio = contatoRepositorio;
            _sessaoUsuario = sessaoUsuario;
        }


        //Recuperar usuário do banco de dados após relacionemto
        public IActionResult Index()
        {
            UsuarioModel usuarioLogado = _sessaoUsuario.BuscarSessaoUsuario();//Inserido após relacionamento
            List<ContatoModel> ListaContatos = _contatoRepositorio.BuscarTodos(usuarioLogado.Id);
            return View(ListaContatos);
        }

        public IActionResult Criar()
        {
            return View();
        }


        //Adicionar contato pelo método 'HttpPost'
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessaoUsuario.BuscarSessaoUsuario(); //Inserir após relacionamento
                    contato.UsuarioId = usuarioLogado.Id; //Inserir após relacionamento
                    contato = _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, o contato não foi cadastrado! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscarPorId(id);
            return View(contato);
        }


        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessaoUsuario.BuscarSessaoUsuario(); //Inserir após relacionamento
                    contato.UsuarioId = usuarioLogado.Id; //Inserir após relacionamento
                    contato = _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, o contato não foi alterado, tente novamente, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);//Vai cair na view de editar, pois não tem view alterar.
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, o contato não foi alterado! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato excluído com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops! o contato não foi excluído!";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, o contato não foi excluído! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
