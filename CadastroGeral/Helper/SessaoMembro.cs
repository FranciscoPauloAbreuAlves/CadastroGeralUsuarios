using CadastroGeral.Interfaces;
using CadastroGeral.Models;
using Newtonsoft.Json;

namespace CadastroGeral.Helper
{
    //public class SessaoMembro : ISessaoMembro
    //{
    //    public readonly IHttpContextAccessor _httpContextAccessor;

    //    public SessaoMembro(IHttpContextAccessor httpContextAccessor)
    //    {
    //        _httpContextAccessor = httpContextAccessor;
    //    }

    //    public MembroModel BuscarSessaoMembro()
    //    {
    //        string sessaoMembro = _httpContextAccessor.HttpContext.Session.GetString("sessaoMembroLogado");
    //        if (string.IsNullOrEmpty(sessaoMembro)) return null;
    //        return JsonConvert.DeserializeObject<MembroModel>(sessaoMembro);
    //    }

    //    public void CriarSessaoMembro(MembroModel membro)
    //    {
    //        string valor = JsonConvert.SerializeObject(membro);
    //        _httpContextAccessor.HttpContext.Session.SetString("sessaoMembroLogado", valor);
    //    }

    //    public void RemoverSessaoMembro()
    //    {
    //        _httpContextAccessor.HttpContext.Session.Remove("sessaoMembroLogado");
    //    }
    //}
}
