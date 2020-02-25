using System;
using Microsoft.AspNetCore.Mvc;
using engSoftPDV.DTO;
using engSoftPDV.Models;
using engSoftPDV.Data;

namespace engSoftPDV.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext database;
        public CategoriasController(ApplicationDbContext database){
            this.database = database; // recebendo o contexto de bando de dados
        }
        [HttpPost] // só ocnseguimos acessar através de um metodo post
        public IActionResult Salvar (CategoriaDTO CategoriaTemporaria)
        {
            if(ModelState.IsValid)
            {
                Categoria categoria = new Categoria();
                categoria.Name = CategoriaTemporaria.Name;
                categoria.Status = true;
                database.Categorias.Add(categoria);  // adicionar nova categoria no banco de dados
                database.SaveChanges(); //criar uma nova categorua na lista de categorias no banco de dados. Salvar essa nova categoria
                return RedirectToAction("categorias", "Gestao");
            } else {
                return View("../Gestao/NovaCategoria");
            }
        }
    }
}