using System.ComponentModel.DataAnnotations;

namespace engSoftPDV.DTO
{
    public class PromocaoDTO //somente trabsmite dados
    {
        [Required]
        public int Id{get; set;}

        [StringLength(100)]
        [MinLength(3)]
        public string Name {get; set;}

        [Required]
        public int ProdutoID {get; set;}

        [Required]
        [Range(0,100)]
        public float Porcentagem {get; set;}
    }
}