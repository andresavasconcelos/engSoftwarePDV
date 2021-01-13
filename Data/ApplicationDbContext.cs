using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using engSoftPDV.Models;

namespace engSoftPDV.Data
{
    public class ApplicationDbContext : IdentityDbContext //vamos dar upload nessas models para o banco de dados
    {
        public DbSet<Categoria> Categorias {get; set;} // seguir essa ordem porque existe tabelas que dependem uma da outra
        public DbSet<Fornecedor> Fornecedores {get; set;}
        public DbSet<Produto> Produtos  {get; set;}
        public DbSet<Promocao> Promocoes  {get; set;}
        public DbSet<Estoque> Estoques  {get; set;}
        public DbSet<Saida> Saidas  {get; set;}
        public DbSet<Venda> Vendas  {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
    }
}
