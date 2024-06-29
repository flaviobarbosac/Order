namespace Order.Dominio.Dto
{
    public class EntregaDto
    {
        public required string NumeroOrdem { get; set; }
        public required string DataHoraEntrega { get; set; }
        public required string Entregador { get; set; }
        public required string ValorTotalOrdem { get; set; }
        public required string NomeCliente { get; set; }
        public required string Telefone { get; set; }
        public required string CEP { get; set; }
        public required string Rua { get; set; }
        public required string Numero { get; set; }
        public required string Bairro { get; set; }
        public required string Cidade { get; set; }
        public required string Estado { get; set; }
    }
}
