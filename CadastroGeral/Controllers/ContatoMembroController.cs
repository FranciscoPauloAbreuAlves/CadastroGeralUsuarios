using CadastroGeral.Filters;
using CadastroGeral.Interfaces;
using CadastroGeral.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroGeral.Controllers
{
    //[PaginaMembroLogado]
    //public class ContatoMembroController : Controller
    //{
    //    //Declarar dependências de interfaces de banco de dados
    //    private readonly IContatoRepositorio _contatoRepositorio;
    //    private readonly ISessaoMembro _sessaoMembro;


    //    //Injetar dependências das interfaces
    //    public ContatoMembroController(
    //        IContatoRepositorio contatoRepositorio,
    //        ISessaoMembro sessaoMembro)
    //    {
    //        _contatoRepositorio = contatoRepositorio;
    //        _sessaoMembro = sessaoMembro;
    //    }


    //    //Recuperar usuário do banco de dados após relacionemto
    //    public IActionResult Index()
    //    {
    //        MembroModel membroLogado = _sessaoMembro.BuscarSessaoMembro();//Inserido após relacionamento
    //        List<ContatoModel> ListaContatos = _contatoRepositorio.BuscarTodosContatosMembros(membroLogado.Id);
    //        return View(ListaContatos);
    //    }

    //    public IActionResult Criar()
    //    {
    //        return View();
    //    }


    //    //Adicionar contato pelo método 'HttpPost'
    //    [HttpPost]
    //    public IActionResult Criar(ContatoModel contato)
    //    {
    //        try
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                MembroModel membroLogado = _sessaoMembro.BuscarSessaoMembro();
    //                contato.MembroModelId = membroLogado.Id;
    //                contato = _contatoRepositorio.Adicionar(contato);
    //                TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
    //                return RedirectToAction("Index");
    //            }
    //            return View(contato);
    //        }
    //        catch (Exception erro)
    //        {
    //            TempData["MensagemErro"] = $"Ops, o contato não foi cadastrado! Detalhe do erro: {erro.Message}";
    //            return RedirectToAction("Index");
    //        }
    //    }

    //    public IActionResult Editar(int id)
    //    {
    //        ContatoModel contato = _contatoRepositorio.BuscarPorId(id);
    //        return View(contato);
    //    }


    //    [HttpPost]
    //    public IActionResult Editar(ContatoModel contato)
    //    {
    //        try
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                MembroModel membroLogado = _sessaoMembro.BuscarSessaoMembro();
    //                contato.MembroModelId = membroLogado.Id;
    //                contato = _contatoRepositorio.Atualizar(contato);
    //                TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
    //                return RedirectToAction("Index");
    //            }
    //            return View(contato);
    //        }
    //        catch (Exception erro)
    //        {
    //            TempData["MensagemErro"] = $"Ops, o contato não foi alterado, tente novamente, detalhes do erro: {erro.Message}";
    //            return RedirectToAction("Index");
    //        }
    //    }


    //    [HttpPost]
    //    public IActionResult Alterar(ContatoModel contato)
    //    {
    //        try
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                _contatoRepositorio.Atualizar(contato);
    //                TempData["MensagemSucesso"] = "Contato alterado com sucesso";
    //                return RedirectToAction("Index");
    //            }
    //            return View("Editar", contato);//Vai cair na view de editar, pois não tem view alterar.
    //        }
    //        catch (Exception erro)
    //        {
    //            TempData["MensagemErro"] = $"Ops, o contato não foi alterado! Detalhe do erro: {erro.Message}";
    //            return RedirectToAction("Index");
    //        }
    //    }

    //    public IActionResult ApagarConfirmacao(int id)
    //    {
    //        ContatoModel contato = _contatoRepositorio.BuscarPorId(id);
    //        return View(contato);
    //    }

    //    public IActionResult Apagar(int id)
    //    {
    //        try
    //        {
    //            bool apagado = _contatoRepositorio.Apagar(id);

    //            if (apagado)
    //            {
    //                TempData["MensagemSucesso"] = "Contato excluído com sucesso";
    //            }
    //            else
    //            {
    //                TempData["MensagemErro"] = "Ops! o contato não foi excluído!";
    //            }

    //            return RedirectToAction("Index");
    //        }
    //        catch (Exception erro)
    //        {
    //            TempData["MensagemErro"] = $"Ops, o contato não foi excluído! Detalhe do erro: {erro.Message}";
    //            return RedirectToAction("Index");
    //        }
    //    }
    //}
}
