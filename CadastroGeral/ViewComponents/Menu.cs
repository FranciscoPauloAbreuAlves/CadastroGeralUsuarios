using CadastroGeral.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CadastroGeral.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
            return View(usuario);
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    string sessaoMembro = HttpContext.Session.GetString("sessaoMembroLogado");

        //    if (string.IsNullOrEmpty(sessaoMembro)) return null;
        //    MembroModel membro = JsonConvert.DeserializeObject<MembroModel>(sessaoMembro);
        //    return View(membro);
        //}
    }
}
