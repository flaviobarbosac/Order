namespace Order.Dominio.Dto
{
    public class OrdemDto
    {           
        public required string NumeroOrdem { get; set; }
        public required string Descricao { get; set; }
        public decimal ValorTotalOrdem { get; set; }
        public required Cliente Cliente { get; set; }
        public List<ItemOrdem>? Items { get; set; }
    }
}