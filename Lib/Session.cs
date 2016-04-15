﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

using zapweb.Models;

namespace zapweb.Lib
{
    public class Session
    {
        public readonly Account Account;

        public string Presence
        {
            get
            {
                return HttpContext.Current.User.Identity.Name;
            }
        }

        public Session()
        {
            if (Presence.Length > 0)
            {
                Account = AccountRepositorio.FetchBySession(Presence);
                Account.Permissao = GrupoPermissaoRepositorio.FetchOne(Account.GrupoPermissaoId);
                Account.Permissao.Permissoes = PermissaoRepositorio.Fetch(Account.GrupoPermissaoId);
            }
            
        }

        public static Session GetInstance()
        {
            if (HttpContext.Current.Items["SessionContext"] == null)
            {
                HttpContext.Current.Items["SessionContext"] = (Session)new Session();
            }

            return (Session)HttpContext.Current.Items["SessionContext"];
        }        

        public void Create(string uuid)
        {
            FormsAuthentication.SetAuthCookie(uuid, true);
        }

        public bool Exist()
        {
            return Presence.Length > 0;
        }

        public void Destroy()
        {
            FormsAuthentication.SignOut();
        }
    }
}