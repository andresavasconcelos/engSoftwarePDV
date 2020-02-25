using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using engSoftPDV.Data;
using engSoftPDV.DTO;
using engSoftPDV.Models;

namespace engSoftPDV.Controllers
{
    public class ProdutosController : Controller
    {        
        private readonly ApplicationDbContext database;

        public ProdutosController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(ProdutoDTO ProdutoTemporario){
            if(ModelState.IsValid){
                Produto produto = new Produto();
                produto.Name = ProdutoTemporario.Name;
                produto.Categoria = database.Categorias.First(categoria => categoria.Id == ProdutoTemporario.CategoriaId); //a categoria desse produto criado será o mesmo que o objeto categoria que está no banco de dados 
                produto.Fornecedor = database.Fornecedores.First(fornecedor => fornecedor.Id == ProdutoTemporario.FornecedorId);
                produto.PrecoDeCusto = ProdutoTemporario.PrecoDeCusto;
                produto.PrecoDeVenda = ProdutoTemporario.PrecoDeVenda;
                produto.Medicao = ProdutoTemporario.Medicao;
                produto.Status = true;
                database.Produtos.Add(produto);
                database.SaveChanges();
                return RedirectToAction("Produtos", "Gestao");

            }else{
                ViewBag.Categorias = database.Categorias.ToList(); //buscar todas em uma categoria e trnsformando em uma lista
                ViewBag.Fornecedores = database.Fornecedores.ToList(); 
                return View("../Gestao/NovoProduto");
            }
        }
    }
}