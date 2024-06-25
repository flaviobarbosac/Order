using Easyweb.Site.Core.Entities;
using MongoDB.Bson;
using Order.Dominio;
using Order.Dominio.Dto;

namespace Order.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto> CreateProduto(Produto produto);
        Task<Produto> GetProdutoById(ObjectId id);
        Task<IEnumerable<Produto>> GetAllProdutos();
        Task<bool> UpdateProduto(Produto client);
        Task<bool> DeleteProduto(ObjectId id);
    }
}
