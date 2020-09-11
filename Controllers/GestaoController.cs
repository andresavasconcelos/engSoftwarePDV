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
            var categorias = database.Categorias.Where(cat => cat.Status == true).ToList(); //conseigueremos listas esse dados no html
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
            var fornecedores = database.Fornecedores.Where(forne => forne.Status == true).ToList();
            return View(fornecedores);
        }
        public IActionResult NovoFornecedor(){
            return View();
        }

        public IActionResult EditarFornecedor(int id){
            var fornecedor = database.Fornecedores.First(forne => forne.Id == id);
            FornecedorDTO fornecedorView = new FornecedorDTO();
            fornecedorView.Id = fornecedor.Id;
            fornecedorView.Name = fornecedor.Name;
            fornecedorView.Email = fornecedor.Email;
            fornecedorView.Tel = fornecedor.Tel;
            return View(fornecedorView);
        }

        public IActionResult Produtos(){
            var produtos = database.Produtos.Where(prod => prod.Status == true).ToList();            
            return View(produtos);
        }

        public IActionResult NovoProduto(){
            ViewBag.Categorias = database.Categorias.ToList(); //buscar todas em uma categoria e trnsformando em uma lista
            ViewBag.Fornecedores = database.Fornecedores.ToList(); 
            return View(); 
        }

        public IActionResult EditarProduto(int id){
            var produto = database.Produtos.Include(prod => prod.Categoria).Include(prod => prod.Fornecedor).First(prod => prod.Id == id);
            ProdutoDTO produtoView = new ProdutoDTO();
            produtoView.Id = produto.Id;
            produtoView.Name = produto.Name;
            produtoView.PrecoDeCusto = produto.PrecoDeCusto;
            produtoView.PrecoDeVenda = produto.PrecoDeVenda;
            produtoView.Medicao = produto.Medicao;
            produtoView.CategoriaId = produto.Categoria.Id;
            produtoView.FornecedorId = produto.Fornecedor.Id;
            ViewBag.Categorias = database.Categorias.ToList();
            ViewBag.Fornecedores = database.Fornecedores.ToList();
            return View(produtoView);
        }

        public IActionResult Promocoes(int id){
            //var promocao = database.Produtos.Where(promo => promo.Id == id).ToList()
            //return View(promocao);
            return View();
        }

        public IActionResult NovaPromocao(int id){
            ViewBag.Produtos = database.Produtos.ToList();
            return View();
        }

    }
}
