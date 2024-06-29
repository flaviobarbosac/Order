namespace Order.Dominio.Dto
{
    public class EntregaItemDto
    {
        public required string Descricao { get; set; }
        public required string PrecoUnitario { get; set; }
        public required Decimal Quantidade { get; set; }
        public required Decimal PrecoTotal { get; set; }        
    }
}
