using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sprint3.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public double PrecoProduto { get; set; }
        public int EstoqueProduto { get; set; }
        public int CategoriaId { get; set; }
    }
}
