using FirstOne.Data;
using FirstOne.Models;
using Microsoft.EntityFrameworkCore;
using Sprint3.Models;
using Sprint3.Repository.Inteface;

namespace Sprint3.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly dbContext dbContext;
        public ProdutoRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Produto> AddProduto(Produto produto)
        {
            var result = await dbContext.Produtos.AddAsync(produto);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteProduto(int id)
        {
            var result = await dbContext.Produtos.FirstOrDefaultAsync(
                x => x.ProdutoId == id);
            if (result != null)
            {
                dbContext.Produtos.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Produto> GetProdutoById(int id)
        {
            return await dbContext.Produtos.FirstOrDefaultAsync(
                x => x.ProdutoId == id);
        }

        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            return await dbContext.Produtos.ToListAsync();
        }

        public async Task<Produto> UpdateProduto(Produto produto)
        {
            var result = await dbContext.Produtos.FirstOrDefaultAsync(
                x => x.ProdutoId == produto.ProdutoId);
            if (result != null)
            {
                result.NomeProduto = produto.NomeProduto;
                result.DescricaoProduto = produto.DescricaoProduto;
                result.PrecoProduto = produto.PrecoProduto;
                result.EstoqueProduto = produto.EstoqueProduto;
                result.CategoriaId = produto.CategoriaId;
                await dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
