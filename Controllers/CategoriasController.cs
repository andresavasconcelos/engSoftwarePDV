using System;
using Microsoft.AspNetCore.Mvc;
using engSoftPDV.DTO;
using engSoftPDV.Models;
using engSoftPDV.Data;
using System.Linq; //metodo first

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

        [HttpPost] //acessado via post
        public IActionResult Atualizar(CategoriaDTO categoriaTemporaria)
        {
            if (ModelState.IsValid)
            {
                var categoria = database.Categorias.First(cat => cat.Id == categoriaTemporaria.Id);
                categoria.Name = categoriaTemporaria.Name;
                database.SaveChanges();
                return RedirectToAction("Categorias", "Gestao");
            }
            else
            {
                return View("../Gestao/EditarCategoria");
            }
        }

        public IActionResult Deletar(int id)
        {
            if(id > 0)
            {
                var categoria = database.Categorias.First(cat => cat.Id == id);
                categoria.Status = false;
                database.SaveChanges();
            }

            return RedirectToAction("Categorias", "Gestao");

        }
    }
}