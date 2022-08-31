using CadastroGeral.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace CadastroGeral.Filters
{
//    public class PaginaMembroLogado : ActionFilterAttribute
//    {
//        public override void OnActionExecuting(ActionExecutingContext context)
//        {
//            string sessaoMembro = context.HttpContext.Session.GetString("sessaoMembroLogado");

//            if (string.IsNullOrEmpty(sessaoMembro))
//            {
//                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "login" }, { "action", "Index" } });
//            }
//            else
//            {
//                MembroModel membro = JsonConvert.DeserializeObject<MembroModel>(sessaoMembro);

//                if (membro == null)
//                {
//                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "login" }, { "action", "Index" } });
//                }
//            }

//            base.OnActionExecuting(context);
//        }
//    }
}
