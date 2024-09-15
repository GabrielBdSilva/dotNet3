using Sprint3.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MinimalAPI.Models
{
    public class Carrinho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarrinhoId { get; set; }
        public List<int> Produtos { get; set; }
        public bool Status { get; set; } = false;
    }
}
