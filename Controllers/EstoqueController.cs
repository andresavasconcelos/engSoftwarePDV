using Microsoft.AspNetCore.Mvc;
using engSoftPDV.Data;
using engSoftPDV.Models;

namespace engSoftPDV.Controllers
{
    public class EstoqueController : Controller
    {        
       
        private readonly ApplicationDbContext database;

        public EstoqueController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(Estoque estoqueTemp){
            database.Estoques.Add(estoqueTemp);
            database.SaveChanges();
            return RedirectToAction("Estoque","Gestao");
        }
    }
}