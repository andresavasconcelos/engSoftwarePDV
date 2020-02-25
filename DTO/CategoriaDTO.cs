using System.ComponentModel.DataAnnotations;

namespace engSoftPDV.DTO
{
    public class CategoriaDTO //somente trabsmite dados
    {
        [Required] //estamos fazendo uma validação de informações requeridas pelo usuário
        public int Id {get; set;}
        
        [Required(ErrorMessage="Nome de categoria é obrigatorio")]
        [StringLength(100, ErrorMessage="Nome muito grande, tente um nome menor!")]
        [MinLength(2, ErrorMessage="Nome de categoria muito pequeno, tente um nome maior")]
       public string Name {get; set;}
    }
}