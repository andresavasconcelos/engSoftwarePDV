using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using engSoftPDV.Models;
using engSoftPDV.Data;
using engSoftPDV.DTO;

namespace engSoftPDV.Controllers
{
    public class GestaoController : Controller
    {
        private readonly ApplicationDbContext database;

        public GestaoController(ApplicationDbContext database){
            this.database = database;
        }
        public IActionResult Index(){ //vai até a pasta gestao e pegar arquivo index
            return View();
        }

        public IActionResult Categorias(){
            var categorias = database.Categorias.ToList(); //conseigueremos listas esse dados no html
            return View(categorias);
        }

        public IActionResult NovaCategoria(){
            return View();
        }

        public IActionResult EditarCategoria(int id){
            var categoria = database.Categorias.First(cat => cat.Id == id);
            CategoriaDTO categoriaView = new CategoriaDTO();
            categoriaView.Id = categoria.Id; 
            categoriaView.Name = categoria.Name;
            return View(categoriaView);
        }


        public IActionResult Fornecedores(){
            return View();
        }
        public IActionResult NovoFornecedor(){
            return View();
        }

        public IActionResult Produtos(){
            return View();
        }

        public IActionResult NovoProduto(){
            ViewBag.Categorias = database.Categorias.ToList(); //buscar todas em uma categoria e trnsformando em uma lista
            ViewBag.Fornecedores = database.Fornecedores.ToList(); 
            return View(); 
        }

    }
}
