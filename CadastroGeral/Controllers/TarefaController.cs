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
    public class TarefaController : Controller
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        private readonly ISessaoUsuario _sessaoUsuario;

        //Injetar dependências das interfaces
        public TarefaController(
            ITarefaRepositorio tarefaRepositorio, 
            ISessaoUsuario sessaoUsuario)
        {
            _tarefaRepositorio = tarefaRepositorio;
            _sessaoUsuario = sessaoUsuario;
        }

        //Recuperar usuário do banco de dados após relacionemto
        public IActionResult Index()
        {
            UsuarioModel usuarioLogado = _sessaoUsuario.BuscarSessaoUsuario();//Inserido após relacionamento
            List<TarefaModel> ListaTarefas = _tarefaRepositorio.BuscarTodasTarefas(usuarioLogado.Id);
            return View(ListaTarefas);
        }

        //Método criar
        public IActionResult Criar()
        {
            return View();
        }

        //Método criar
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

        //Método Editar
        public IActionResult Editar(int id)
        {
            TarefaModel tarefa = _tarefaRepositorio.ListarPorId(id);
            return View(tarefa);
        }

        //Método editar após relacionamento
        [HttpPost]
        public IActionResult Editar(TarefaModel editarTarefa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessaoUsuario.BuscarSessaoUsuario();
                    editarTarefa.UsuarioId = usuarioLogado.Id;

                    editarTarefa = _tarefaRepositorio.Atualizar(editarTarefa);
                    TempData["MensageSucesso"] = "Tarefa alterada com sucesso";
                    return RedirectToAction("Index");
                }
                return View(editarTarefa);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, a tarefa não foi alterada! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
       
        //Método editar após relacionamento
        [HttpPost]
        public IActionResult Alterar(TarefaModel postarTarefa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessaoUsuario.BuscarSessaoUsuario();
                    postarTarefa.UsuarioId = usuarioLogado.Id;

                    postarTarefa = _tarefaRepositorio.Atualizar(postarTarefa);
                    TempData["MensageSucesso"] = "Tarefa alterada com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", postarTarefa);
                //return View(postarTarefa);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, a tarefa não foi alterada! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        //Método confirmar exclusão
        public IActionResult ApagarConfirmacao(int id)
        {
            TarefaModel tarefa = _tarefaRepositorio.ListarPorId(id);
            return View(tarefa);
        }

        //Método apagar
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
