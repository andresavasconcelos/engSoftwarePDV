using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using engSoftPDV.Data;
using engSoftPDV.DTO;
using engSoftPDV.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace engSoftPDV.Controllers
{
    public class ProdutosController : Controller
    {        
        private readonly ApplicationDbContext database;

        public ProdutosController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(ProdutoDTO produtoTemporario){
            if(ModelState.IsValid){
                Produto produto = new Produto();
                produto.Name = produtoTemporario.Name;
                produto.Categoria = database.Categorias.First(categoria => categoria.Id == produtoTemporario.CategoriaId); //a categoria desse produto criado será o mesmo que o objeto categoria que está no banco de dados 
                produto.Fornecedor = database.Fornecedores.First(fornecedor => fornecedor.Id == produtoTemporario.FornecedorId);
                produto.PrecoDeCusto = float.Parse(produtoTemporario.PrecoDeCustoString, CultureInfo.InvariantCulture.NumberFormat);
                produto.PrecoDeVenda = float.Parse(produtoTemporario.PrecoDeVendaString, CultureInfo.InvariantCulture.NumberFormat);
                produto.Medicao = produtoTemporario.Medicao;
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
        public JsonResult Retornar(int id){
            if(id > 0){
            var produto = database.Produtos.Where(p => p.Status == true).Include(p => p.Categoria).Include(p => p.Fornecedor).First(p => p.Id == id);

            if(produto != null){
                var estoque = database.Estoques.First(e => e.Produto.Id == produto.Id);
                if(estoque == null){
                    produto = null;
                }
            }

            if(produto != null){
                
                Promocao promocao;
                try{
                    promocao = database.Promocoes.First(p => p.Produto.Id == produto.Id && p.Status == true);
                }catch(Exception e){
                    promocao = null;
                }
    
                if(promocao != null){
                    produto.PrecoDeVenda -= (produto.PrecoDeVenda * (promocao.Porcentagem/100));
                }
                
                Response.StatusCode = 200; //OK
                return Json(produto);
            }else{
                Response.StatusCode = 404; // Falha
                return Json(null);
            }
            }else{
                Response.StatusCode = 404; // Falha
                return Json(null);
            }
        }

        //  [HttpPost]
        // public IActionResult Retornar(int id){
        //     return Json("Olá mundo");            
        // }  
    }
}