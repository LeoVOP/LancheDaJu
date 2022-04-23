using LanchesDaJu.Context;
using LanchesDaJu.Models;

namespace LanchesDaJu.Repositories
{
    public class PedidoRepository :  IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);
            _appDbContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;
            
            foreach ( var itemCarrinho in carrinhoCompraItens)
            {
                var pedidoDetalhe = new PedidoDetalhe()
                {
                    Quantidade = itemCarrinho.Quantidade,
                    LancheId = itemCarrinho.Lanche.LancheId,
                    PedidoId = pedido.PedidoId,
                    Preco = itemCarrinho.Lanche.Preco
                };
                _appDbContext.PedidoDetalhes.Add(pedidoDetalhe);
            }
            _appDbContext.SaveChanges();

        }
    }
}
