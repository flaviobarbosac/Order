using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Order.Dominio;
using Order.Dominio.Dto;
using System.Collections.Generic;
using System.Net;

namespace Order.Services
{
    public class EntregaService : IEntregaService
    {
        private readonly IMongoCollection<Entrega> _entrega;
        private readonly IMongoCollection<ItemOrdem> _itemOrdem;

        public EntregaService(IMongoClient entrega)
        {
            var database = entrega.GetDatabase("TechsysLogDB");
            _entrega = database.GetCollection<Entrega>("Entregas");
            _itemOrdem = database.GetCollection<ItemOrdem>("ItemOrdem");
        }

        public async Task<Entrega> CreateEntrega(Entrega entrega)
        {
            await _entrega.InsertOneAsync(entrega);
            return entrega;
        }

        public async Task<Entrega> GetEntregaById(ObjectId id)
        {
            return await _entrega.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<object>> GetAllEntregas()
        {
            List<object> lstEntrega = new List<object>();

            var entregas = await _entrega.Find(c => true).ToListAsync();

            foreach (var entrega in entregas)
            {
                var master = ConverteParaDto(entrega);
                var itens = ConverteEntrega(entrega);

                lstEntrega.Add(new { Entrega = master, Itens = itens });
            }

            return lstEntrega;
        }

        public async Task<bool> UpdateEntrega(Entrega client)
        {
            var result = await _entrega.ReplaceOneAsync(c => c.Id == client.Id, client);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteEntrega(ObjectId id)
        {
            var result = await _entrega.DeleteOneAsync(c => c.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public List<EntregaItemDto> ConverteEntrega(Entrega entrega)
        {
            var lstItens = _itemOrdem.Find(c => c.Ordem == entrega.Ordem).ToList();
            return lstItens.Select(item => new EntregaItemDto
            {
                Descricao = item.Produto.Descricao,
                PrecoUnitario = item.PrecoVenda.ToString(),
                Quantidade = item.Quantidade,
                PrecoTotal = item.ValorTotal
            }).ToList();
        }

        public EntregaDto ConverteParaDto(Entrega entrega)
        {
            return new EntregaDto
            {
                NumeroOrdem = entrega.NumeroOrdem,
                DataHoraEntrega = entrega.DataHoraEntrega,
                Entregador = entrega.User.Nome,
                ValorTotalOrdem = entrega.Ordem.ValorTotalOrdem.ToString(),
                NomeCliente = entrega.Ordem.Cliente.Nome,
                Telefone = entrega.Ordem.Cliente.Telefone,
                CEP = entrega.Ordem.Cliente.CEP,
                Rua = entrega.Ordem.Cliente.Endereco.Logradouro,
                Numero = entrega.Ordem.Cliente.Endereco.Unidade,
                Bairro = entrega.Ordem.Cliente.Endereco.Bairro,
                Cidade = string.Empty,
                Estado = entrega.Ordem.Cliente.Endereco.Uf
            }; 
        }
    }
}