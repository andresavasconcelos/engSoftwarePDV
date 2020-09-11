 using System;

namespace engSoftPDV.Models
{
    public class Promocao
    {
       public int Id {get; set;}
       public string Name {get; set;}
       public Produto Produto {get; set;}
       public float Porcentagem {get; set;}
       public bool Status {get; set;}
    }
}
