using FirstOne.Data;
using FirstOne.Models;
using FirstOne.Reposotory.Inteface;
using Microsoft.EntityFrameworkCore;
using Sprint3.Models;

namespace FirstOne.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {   
        private readonly dbContext dbContext;

        public CategoriaRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Categoria> AddCategoria(Categoria categoria)
        {
            var result = await dbContext.Categorias.AddAsync(categoria);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteCategoria(int categoriaId)
        {
            var result = await dbContext.Categorias.FirstOrDefaultAsync(
                x => x.CategoriaId == categoriaId);
            if (result != null)
            {
                dbContext.Categorias.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Categoria> GetCategoriaById(int id)
        {
            return await dbContext.Categorias.FirstOrDefaultAsync(
                x => x.CategoriaId == id);
        }

        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            return await dbContext.Categorias.ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetProdutoByCategoria(int categoriaId)
        {
            return await dbContext.Produtos
                .Where(e => e.CategoriaId == categoriaId)
                .ToListAsync();
        }

        public async Task<Categoria> UpdateCategoria(Categoria categoria)
        {
            var result = await dbContext.Categorias.FirstOrDefaultAsync(
                x => x.CategoriaId == categoria.CategoriaId);
            if (result != null)
            {
                result.NomeCategoria = categoria.NomeCategoria;
                await dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
