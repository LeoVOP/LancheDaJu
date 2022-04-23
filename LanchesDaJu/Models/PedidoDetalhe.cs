using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesDaJu.Models
{
    public class PedidoDetalhe
    {
        public int PedidoDetalheId { get; set; }
        public int PedidoId { get; set; }
        public int LancheId { get; set; }
        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        //Propriedade de navegação que irá gerar um relacionamento um para muitos e gerar as chaves estrangeiras
        public virtual Lanche Lanche { get; set; }
        //Propriedade de navegação que irá gerar um relacionamento um para muitos e gerar as chaves estrangeiras
        public virtual Pedido Pedido { get; set; }
    }
}
