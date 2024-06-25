namespace Order.Dominio.Dto
{
    public class EntregaDto
    {
        public required string NumeroOrdem { get; set; }
        public DateTime DataHoraEntrega { get; set; }
        public required User User { get; set; }
    }
}
