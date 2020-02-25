using System;

namespace engSoftPDV.Models
{

    //DTO (Data Transfer Object) nao queremos mexer na entidade que está no banco de dados
    public class Categoria
    {
       public int Id {get; set;}
       public string Name {get; set;}
       public bool Status {get; set;} // como atualizamos um campo na entidade Categoria, então precisamos atualizar essa entidade usando o comando dotnet ef migrations add AtualizarCategoria

    }
}
