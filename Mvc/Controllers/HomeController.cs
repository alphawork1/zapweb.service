using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using zapweb.Lib;
using zapweb.Lib.Mvc;
using zapweb.Models;

namespace zapweb.Controllers
{
    [zapweb.Lib.Filters.IsAuthenticate]
    public class HomeController : zapweb.Lib.Mvc.Controller
    {
        //
        // GET: /Home/
        [zapweb.Lib.Filters.IsAuthenticate]
        public ActionResult Index()
        {
            var usuario = UsuarioRepositorio.FetchOne(zapweb.Lib.Session.GetInstance().Account.UsuarioId);
            
            usuario.Permissoes = GrupoPermissaoRepositorio.FetchOne(zapweb.Lib.Session.GetInstance().Account.GrupoPermissaoId);
            
            ViewData["usuario"] = usuario;

            return View();
        }

    }
}
