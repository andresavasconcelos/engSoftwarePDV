using System;

namespace engSoftPDV.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public string Email {get; set;}
        public string Tel {get; set;}
        public bool Status {get; set;} //dotnet ef migrations add AtualizandoFornecedor (vai criar um arquivo na pasta de migrations para fazer a migração) || dotnet ef database update (vai atualizar o campo la no banco de dados)
       
    }
}
