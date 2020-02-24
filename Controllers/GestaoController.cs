using System;
using Microsoft.AspNetCore.Mvc;

namespace engSoftPDV.Controllers
{
    public class GestaoController : Controller
    {
        public IActionResult Index(){ //vai até a pasta gestao e pegar arquivo index
            return View();
        }
    }
}
