using CadastroGeral.Interfaces;
using CadastroGeral.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroGeral.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessaoUsuario _sessaoUsuario;
        //private readonly ISessaoMembro _sessaoMembro;

        public AlterarSenhaController(
            IUsuarioRepositorio usuarioRepositorio,
            ISessaoUsuario sessaoUsuario)//,
            //ISessaoMembro sessaoMembro)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessaoUsuario = sessaoUsuario;
            //_sessaoMembro = sessaoMembro;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                //pegando usuário logado
                UsuarioModel usuarioLogado = _sessaoUsuario.BuscarSessaoUsuario();
                alterarSenhaModel.Id = usuarioLogado.Id;

                ////pegando membro logado
                //MembroModel membroLogado = _sessaoMembro.BuscarSessaoMembro();
                //alterarSenhaModel.Id = membroLogado.Id;


                if(ModelState.IsValid)
                {
                    _usuarioRepositorio.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarSenhaModel);
                }

                return View("Index", alterarSenhaModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar sua senha, tente novamente, detalhes do erro: {erro.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}
