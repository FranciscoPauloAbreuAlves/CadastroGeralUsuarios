﻿using CadastroGeral.Filters;
using CadastroGeral.Helper;
using CadastroGeral.Interfaces;
using CadastroGeral.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroGeral.Controllers
{
    //Privilégios de acesso
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
            List<ContatoModel> Contatos = _contatoRepositorio.BuscarTodos(usuarioLogado.Id);
            return View(Contatos);
        }

        
        public IActionResult Criar()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessaoUsuario.BuscarSessaoUsuario();
                    contato.UsuarioId = usuarioLogado.Id;
                    contato = _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
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

        [HttpPost]
        public IActionResult Editar(int id)
        {
            ContatoModel editarContato = _contatoRepositorio.BuscarPorId(id);
            return View(editarContato);
        }
               
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessaoUsuario.BuscarSessaoUsuario();
                    contato.UsuarioId = usuarioLogado.Id;

                    contato = _contatoRepositorio.Atualizar(contato);
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
                    TempData["MensagemSucesso"] = "Contato excluído com sucesso!";
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

