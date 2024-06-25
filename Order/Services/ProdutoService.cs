using MongoDB.Bson;
using MongoDB.Driver;
using Order.Dominio;
using Order.Services.Interfaces;

namespace Order.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMongoCollection<Produto> _produtos;

        public ProdutoService(IMongoClient Produto)
        {
            var database = Produto.GetDatabase("TechsysLogDB");
            _produtos = database.GetCollection<Produto>("Produtos");
        }

        public async Task<Produto> CreateProduto(Produto produto)
        {
            await _produtos.InsertOneAsync(produto);
            return produto;
        }

        public async Task<Produto> GetProdutoById(ObjectId id)
        {
            return await _produtos.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Produto>> GetAllProdutos()
        {
            return await _produtos.Find(c => true).ToListAsync();
        }

        public async Task<bool> UpdateProduto(Produto Produto)
        {
            var result = await _produtos.ReplaceOneAsync(c => c.Id == Produto.Id, Produto);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduto(ObjectId id)
        {
            var result = await _produtos.DeleteOneAsync(c => c.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }       
    }
}