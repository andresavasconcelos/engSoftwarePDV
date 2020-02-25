using System;
using Microsoft.AspNetCore.Mvc;
using engSoftPDV.DTO;
using engSoftPDV.Models;
using engSoftPDV.Data;

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
    }
}