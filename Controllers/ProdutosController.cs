using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using engSoftPDV.Data;
using engSoftPDV.DTO;
using engSoftPDV.Models;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public IActionResult Atualizar(ProdutoDTO produtoTemporario){
            if(ModelState.IsValid){
                var produto = database.Produtos.First(prod => prod.Id == produtoTemporario.Id);
                produto.Name = produtoTemporario.Name;
                produto.PrecoDeCusto = produtoTemporario.PrecoDeCusto;
                produto.PrecoDeVenda = produtoTemporario.PrecoDeVenda;
                produto.Medicao = produtoTemporario.Medicao;
                produto.Categoria = database.Categorias.First(categoria => categoria.Id == produtoTemporario.Id);
                produto.Fornecedor = database.Fornecedores.First(fornecedor => fornecedor.Id == produtoTemporario.Id);
                database.SaveChanges();
                return RedirectToAction("Produtos", "Gestao");
           } else {
               return RedirectToAction("Produtos", "Gestao");
           }
        }

        public IActionResult Deletar(int id){
            if(id > 0){
                var produto = database.Produtos.First(prod => prod.Id == id);
                produto.Status = false;
                database.SaveChanges();
            } 

            return RedirectToAction("Produtos", "Gestao");
        }
      

         [HttpPost]
        public IActionResult Retornar(int id){
            return Json("Olá mundo");            
        }  
    }
}