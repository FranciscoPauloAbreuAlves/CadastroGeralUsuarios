using CadastroGeral.Filters;
using CadastroGeral.Helper;
using CadastroGeral.Interfaces;
using CadastroGeral.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace CadastroGeral.Controllers
{
    [PaginaUsuarioLogado]
    
    public class TarefaController : Controller //Declarar dependências de interfaces de banco de dados
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        private readonly ISessaoUsuario _sessaoUsuario;

        public TarefaController(ITarefaRepositorio tarefaRepositorio, ISessaoUsuario sessaoUsuario)
        {
            _tarefaRepositorio = tarefaRepositorio;
            _sessaoUsuario = sessaoUsuario;
        }

        public IActionResult Index() //Recuperar usuário do banco de dados após relacionemto
        {
            UsuarioModel usuarioLogado = _sessaoUsuario.BuscarSessaoUsuario();//Inserido após relacionamento
            List<TarefaModel> ListaTarefas = _tarefaRepositorio.BuscarTodasTarefas(usuarioLogado.Id);
            return View(ListaTarefas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(TarefaModel criarTarefa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessaoUsuario.BuscarSessaoUsuario();
                    criarTarefa.UsuarioId = usuarioLogado.Id;

                    criarTarefa = _tarefaRepositorio.Adicionar(criarTarefa);
                    TempData["MensagemSucesso"] = "Tarefa adicionada com sucesso";
                    return RedirectToAction("Index");
                }
                return View(criarTarefa);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, a tarefa não foi cadastrada! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }  
        }

        public IActionResult Editar(int id)
        {
            TarefaModel tarefa = _tarefaRepositorio.ListarPorId(id);
            return View(tarefa);
        }
      
        public IActionResult Alterar(TarefaModel alterarTarefa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessaoUsuario.BuscarSessaoUsuario();
                    alterarTarefa.UsuarioId = usuarioLogado.Id;

                    alterarTarefa = _tarefaRepositorio.Atualizar(alterarTarefa);
                    TempData["MensageSucesso"] = "Tarefa alterada com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", alterarTarefa); //Cai na view de editar, pois não tem view alterar.
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, a tarefa não foi alterada! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            TarefaModel tarefa = _tarefaRepositorio.ListarPorId(id);
            return View(tarefa);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagar = _tarefaRepositorio.Apagar(id);

                if (apagar)
                {
                    TempData["MensagemSucesso"] = "Tarefa excluída com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops! a tarefa não foi excluída!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, a tarefa não foi excluída! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
