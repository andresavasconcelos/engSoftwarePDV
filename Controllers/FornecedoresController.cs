using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using engSoftPDV.Data;
using engSoftPDV.DTO;
using engSoftPDV.Models;

namespace engSoftPDV.Controllers
{
    public class FornecedoresController : Controller
    {        
        private readonly ApplicationDbContext database;

        public FornecedoresController(ApplicationDbContext database){
            this.database = database;
        }

        public IActionResult Salvar (FornecedorDTO FornecedorTemporario)
        {
           if(ModelState.IsValid){ // verfificando se a validação está ok
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.Name = FornecedorTemporario.Name;
                fornecedor.Email = FornecedorTemporario.Email;
                fornecedor.Tel = FornecedorTemporario.Tel;
                fornecedor.Status = true;
                database.Fornecedores.Add(fornecedor);
                database.SaveChanges();
                return RedirectToAction("Fornecedores", "Gestao");
           }else {
               return View("../Gestao/NovoFornecedor");
           }
        }

        [HttpPost]
        public IActionResult Atualizar(FornecedorDTO fornecedorTemporario){
            if(ModelState.IsValid){
                var fornecedor = database.Fornecedores.First(forne => forne.Id == fornecedorTemporario.Id);
                fornecedor.Name = fornecedorTemporario.Name;
                fornecedor.Email = fornecedorTemporario.Email;
                fornecedor.Tel = fornecedorTemporario.Tel;
                database.SaveChanges();
                return RedirectToAction("Fornecedores","Gestao");
            }else{
                return View("../Gestao/EditarFornecedor");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id){
            if(id > 0){
                var fornecedor = database.Fornecedores.First(forne => forne.Id == id);
                fornecedor.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Fornecedores","Gestao");
        }
    }
}