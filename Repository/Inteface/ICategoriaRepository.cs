using FirstOne.Models;
using Sprint3.Models;

namespace FirstOne.Reposotory.Inteface
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetCategorias();
        Task<Categoria> GetCategoriaById(int id);
        Task<Categoria> AddCategoria(Categoria categoria);
        Task<Categoria> UpdateCategoria(Categoria categoria);
        void DeleteCategoria(int id);
        Task<IEnumerable<Produto>> GetProdutoByCategoria(int categoriaId);
    }
}
