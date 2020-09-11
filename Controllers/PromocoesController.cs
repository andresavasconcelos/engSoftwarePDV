using System.Linq;
using Microsoft.AspNetCore.Mvc;
using engSoftPDV.Data;
using engSoftPDV.DTO;
using engSoftPDV.Models;


namespace engSoftPDV.Controllers
{
    public class PromocoesController : Controller
    {        
        private readonly ApplicationDbContext database;

        public PromocoesController(ApplicationDbContext database){
            this.database = database;
        }
        
        [HttpPost]
        public IActionResult Salvar(PromocaoDTO promocaoTemporaria){
            if(ModelState.IsValid){ 
                Promocao promocao = new Promocao();
                promocao.Name = promocaoTemporaria.Name;
                promocao.Produto = database.Produtos.First(prod => prod.Id == promocaoTemporaria.ProdutoID);
                promocao.Porcentagem = promocaoTemporaria.Porcentagem;
                promocao.Status = true;
                database.Promocoes.Add(promocao);
                database.SaveChanges();
                return RedirectToAction("Promocoes","Gestao");
            }else{
                ViewBag.Produtos = database.Produtos.ToList();
                return View("../Gestao/NovaPromocao");
            }

        }
    }

               
    }