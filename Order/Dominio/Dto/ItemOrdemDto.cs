namespace Order.Dominio.Dto
{
    public class ItemOrdemDto
    {
        public required Ordem Ordem { get; set; }
        public required Produto Produto { get; set; }
        public required Double Quantidade { get; set; }
        public required Double PrecoVenda { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
