using System.ComponentModel.DataAnnotations;

namespace engSoftPDV.DTO
{
    public class ProdutoDTO //somente trabsmite dados
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="O nome do produto é obrigatório")]
        [StringLength(100, ErrorMessage="Nome muito grande, coloque um nome menor")]
        [MinLength(2, ErrorMessage="Nome muito peqqueno, favor colcoar um nome com maiores caracteres")]
        public string Name {get; set;}

        [Required(ErrorMessage="Favor inserir a categoria do produto")]
        public int CategoriaId {get; set;} // porque pegaremos o id de cada relacioanmento

        [Required(ErrorMessage="Favor inserir o fornecedor do produto")]
        public int FornecedorId {get; set;}

        [Required(ErrorMessage="Favor inserir o preço de custo do produto")]
        public float PrecoDeCusto {get; set;}

        [Required(ErrorMessage="Favor inserir o preço de venda do produto")]
        public float PrecoDeVenda {get; set;}

        [Required(ErrorMessage="Favor inserir a medicao do produto")]
        [Range(0,2, ErrorMessage="Medição Inválida")] //representa litro ou kilo  
        public int Medicao {get; set;}      
    }
}