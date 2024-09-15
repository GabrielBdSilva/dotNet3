using FirstOne.Models;
using Sprint3.Models;

namespace Sprint3.Repository.Inteface
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetProdutos();
        Task<Produto> GetProdutoById(int id);
        Task<Produto> AddProduto(Produto produto);
        Task<Produto> UpdateProduto(Produto produto);
        void DeleteProduto(int id);
    }
}
 