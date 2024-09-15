using FirstOne.Models;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models;
using Sprint3.Models;

namespace FirstOne.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
    }
}
