using System.ComponentModel.DataAnnotations;

namespace engSoftPDV.DTO
{
    public class FornecedorDTO //somente trabsmite dados
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Nome Fornecedor é obrigatório!")]
        [StringLength(100, ErrorMessage="Nome de Fornecedor muito grande, tente um nome menor!")]
        [MinLength(2, ErrorMessage="Nome muito pequeno, tente maior!")]
        public string Name {get; set;}

        [Required(ErrorMessage="Email do Fornecedor é obrigatório!")]
        [EmailAddress(ErrorMessage="Email inválido")]
        public string Email {get; set;}

        [Required(ErrorMessage="Telefone do Fornecedor é obrigatório!")]
        [Phone(ErrorMessage="Telefone inválido")]
        public string Tel {get; set;}
        
    }
}