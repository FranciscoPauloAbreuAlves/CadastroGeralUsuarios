using CadastroGeral.Filters;
using CadastroGeral.Helper;
using CadastroGeral.Interfaces;
using CadastroGeral.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroGeral.Controllers
{
    //Privigérios de acesso
    [PaginaUsuarioLogado] 
    //[PaginaMembroLogado]

    //Declarar dependências de interfaces de banco de dados
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly ISessaoUsuario _sessaoUsuario;

        //Injetar dependências das interfaces
        public ContatoController(
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
            List<ContatoModel> ListaContatos = _contatoRepositorio.BuscarTodosContatosUsuarios(usuarioLogado.Id);
            return View(ListaContatos);
        }

        //Método criar
        public IActionResult Criar()
        {
            return View();
        }

        //Método criar
        [HttpPost]
        public IActionResult Criar(ContatoModel criarContato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessaoUsuario.BuscarSessaoUsuario();
                    criarContato.UsuarioId = usuarioLogado.Id;
                    criarContato = _contatoRepositorio.Adicionar(criarContato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(criarContato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, o contato não foi cadastrado! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        //Método editar
        public IActionResult Editar(int id)
        {
            ContatoModel editarContato = _contatoRepositorio.BuscarPorId(id);
            return View(editarContato);
        }

        //Método alterar
        [HttpPost]
        public IActionResult Alterar(ContatoModel postarContato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(postarContato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", postarContato);//Vai cair na view de editar, pois não tem view alterar.
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, o contato não foi alterado! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        //Método confirmar exclusão
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscarPorId(id);
            return View(contato);
        }

        //Método apagar
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

