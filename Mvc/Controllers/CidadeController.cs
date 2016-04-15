﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using zapweb.Lib.Mvc;
using zapweb.Models;

namespace zapweb.Controllers
{

    [zapweb.Lib.Filters.IsAuthenticate]
    public class CidadeController : zapweb.Lib.Mvc.Controller
    {
        public string Search(string nome) {
            return Success(CidadeRepositorio.Fetch(nome));
        }
    }
}
