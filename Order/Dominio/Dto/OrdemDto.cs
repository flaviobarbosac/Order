namespace Order.Dominio.Dto
{
    public class OrdemDto
    {           
        public required string NumeroOrdem { get; set; }
        public required string Descricao { get; set; }
        public decimal Valor { get; set; }
        public required Cliente Cliente { get; set; }
    }
}