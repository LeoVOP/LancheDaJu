using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesDaJu.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]   
        public int LancheId { get; set; }

        [Required(ErrorMessage ="O nome do lanche deve ser informado!")]
        [Display(Name ="Nome do Lanche")]
        [StringLength(80,MinimumLength =10,ErrorMessage ="O {0} deve ter no minimo {1} e no maximo")]  
        //Utilização do Data Annotations para atribuir validações no modelo e modelagem de dados
        public string Nome { get; set; }

        [Required(ErrorMessage ="Insira uma descrição do lanche!")]
        [Display(Name = "Descrição do Lanche")]
        [MinLength(20,ErrorMessage ="Descrição minima de {1} caracteres")]
        [MaxLength(200,ErrorMessage ="Descrição pode exceder de {1} caracteres")]
        //Utilização do Data Annotations para atribuir validações no modelo e modelagem de dados
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "Insira uma descrição detalhada do lanche!")]
        [Display(Name = "Descrição detalhada do lanche")]
        [MinLength(20, ErrorMessage = "Descrição detalhada minima de {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada pode exceder de {1} caracteres")]
        //Utilização do Data Annotations para atribuir validações no modelo e modelagem de dados
        public string DescricaoDetalhada { get; set; }

        [Display(Name = "Caminho Imagem")]        
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnaiUrl { get; set; }

        [Display(Name ="Caminho Imagem")]
        [Required]
        [StringLength(200,ErrorMessage ="O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }

        [Required]
        [Display(Name ="Preço")]
        [Column(TypeName ="decimal(10,2)")]
        [Range(1,999.99,ErrorMessage ="O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }

        [Display(Name ="Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        [NotMapped]
        public DateTime DataDeCriacao { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

    }
}
