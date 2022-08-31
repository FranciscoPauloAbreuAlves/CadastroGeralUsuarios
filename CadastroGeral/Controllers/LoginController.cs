using CadastroGeral.Interfaces;
using CadastroGeral.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroGeral.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IEmail _email;
        private readonly ISessaoUsuario _sessaoUsuario;
        //private readonly ISessaoMembro _sessaoMembro;


        public LoginController(
            IUsuarioRepositorio usuarioRepositorio, 
            IEmail email,
            ISessaoUsuario sessaoUsuario)//, 
            //ISessaoMembro sessaoMembro)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _email = email;
            _sessaoUsuario = sessaoUsuario;
            //_sessaoMembro = sessaoMembro;
        }

        //Direcionando para a tela de login (Se logado direcionar para home)
        public IActionResult Index()
        {
            if(_sessaoUsuario.BuscarSessaoUsuario() != null) 
            return RedirectToAction("Index","Home"); 
            return View();
        }

        //Método entrar com usuário
        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessaoUsuario.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha inválida, tente novamente!";
                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente!";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        //Método para enviar link de redefinição de senha
        [HttpPost] 
        public IActionResult EnviarLinkRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é: {novaSenha}";
                        bool emailEnviado = _email.Enviar(usuario.Email, "Sistema de Cadastro - Nova Senha", mensagem);

                        if(emailEnviado)
                        {
                            //_usuarioRepositorio.Atualizar(usuario);
                            _usuarioRepositorio.Atualizar(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para seu e-mail cadastrado uma nova senha.";
                            return RedirectToAction("Index", "Login");
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar o e-mail. Por favor, tente novamente!";
                        }
                        return RedirectToAction("Index", "Login");
                    }
                    TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha. Por favor, verifique os dados informados!";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos redefinir a sua senha, tente novamente, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        //Redefir senhar
        public IActionResult RedefinirSenha()
        {
            return View();
        }

        //Método sair
        public IActionResult Sair()
        {
            _sessaoUsuario.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }
        //Conteúdo entrará aqui!
    }
}
