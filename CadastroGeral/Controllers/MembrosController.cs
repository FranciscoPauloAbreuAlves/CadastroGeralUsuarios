using CadastroGeral.Filters;
using CadastroGeral.Interfaces;
using CadastroGeral.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroGeral.Controllers
{
    //[PaginaRestritaSomenteAdmin]
    //public class MembroController : Controller
    //{
    //    private readonly IMembroRepositorio _membroRepositorio;
    //    public MembroController(IMembroRepositorio membroRepositorio)
    //    {
    //        _membroRepositorio = membroRepositorio;
    //    }

    //    public IActionResult Index()
    //    {
    //        //Inserir os dados do banco na tabela:
    //        List<MembroModel> ListaMembros = _membroRepositorio.BuscarTodosMembros();
    //        return View(ListaMembros);
    //    }

    //    public IActionResult Criar()
    //    {
    //        return View();
    //    }

    //    //Sobrecargas de métodos com parâmetros diferentes
    //    //HttpPost indica que o método é para inserção de dados:
    //    [HttpPost]
    //    public IActionResult Criar(MembroModel membro)
    //    {
    //        try
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                membro = _membroRepositorio.Adicionar(membro);

    //                TempData["MensagemSucesso"] = "Membro cadastrado com sucesso";
    //                return RedirectToAction("Index");
    //            }
    //            return View(membro);
    //        }
    //        catch (Exception erro)
    //        {
    //            TempData["MensagemErro"] = $"Ops, o membro não foi cadastrado! Detalhe do erro: {erro.Message}";
    //            return RedirectToAction("Index");
    //        }
    //    }

    //    public IActionResult Editar(int id)
    //    {
    //        MembroModel membro = _membroRepositorio.ListarPorId(id);
    //        return View(membro);
    //    }

    //    public IActionResult ApagarConfirmacao(int id)
    //    {
    //        MembroModel membro = _membroRepositorio.ListarPorId(id);
    //        return View(membro);
    //    }

    //    public IActionResult Apagar(int id)
    //    {
    //        try
    //        {
    //            bool apagar = _membroRepositorio.Apagar(id);

    //            if (apagar)
    //            {
    //                TempData["MensagemSucesso"] = "Membro excluído com sucesso";
    //            }
    //            else
    //            {
    //                TempData["MensagemErro"] = "Ops! o membro não foi excluído!";
    //            }
    //            return RedirectToAction("Index");
    //        }
    //        catch (Exception erro)
    //        {
    //            TempData["MensagemErro"] = $"Ops, o membro não foi excluído! Detalhe do erro: {erro.Message}";
    //            return RedirectToAction("Index");
    //        }  
    //    }

    //    [HttpPost]
    //    public IActionResult Alterar(MembroModel membro)
    //    {
    //        try
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                _membroRepositorio.Atualizar(membro);
    //                TempData["MensagemSucesso"] = "Membro alterado com sucesso";
    //                return RedirectToAction("Index");
    //            }
    //            return View("Editar", membro);//Vai cair na view de editar, pois não tem view alterar.
    //        }
    //        catch (Exception erro)
    //        {
    //            TempData["MensagemErro"] = $"Ops, o membro não foi alterado! Detalhe do erro: {erro.Message}";
    //            return RedirectToAction("Index");
    //        }
    //    }

    //    [HttpPost]
    //    public IActionResult Editar(MembroSemSenhaModel membroSemSenhaModel)
    //    {
    //        try
    //        {
    //            MembroModel membro = null;

    //            if (ModelState.IsValid)
    //            {
    //                membro = new MembroModel()
    //                {
    //                    Id = membroSemSenhaModel.Id,
    //                    Nome = membroSemSenhaModel.Nome,
    //                    Login = membroSemSenhaModel.Login,
    //                    Email = membroSemSenhaModel.Email,
    //                    Perfil = membroSemSenhaModel.Perfil
    //                };

    //                membro = _membroRepositorio.Atualizar(membro);

    //                TempData["MensagemSucesso"] = "Membro alterado com sucesso";
    //                return RedirectToAction("Index");
    //            }
    //            return View(membro);

    //        }
    //        catch (Exception erro)
    //        {
    //            TempData["MensagemErro"] = $"Ops, o membro não foi alterado! Detalhe do erro: {erro.Message}";
    //            return RedirectToAction("Index");
    //        }
    //    }
    //}
}
