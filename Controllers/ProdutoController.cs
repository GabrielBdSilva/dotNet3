using FirstOne.Models;
using Microsoft.AspNetCore.Mvc;
using Sprint3.Models;
using Sprint3.Repository;
using Sprint3.Repository.Inteface;

namespace Sprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {   
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoController(IProdutoRepository produto)
        {
            _produtoRepository = produto;
        }

        /// <summary>
        /// Função responsável por buscar um todos os produtos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Produto>> GetProdutos()
        {
            try
            {
                return Ok(await _produtoRepository.GetProdutos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter produto");
            }
        }

        /// <summary>
        /// Função responsável por buscar Produto por id.
        /// </summary>
        /// <param name="id">id do produto a ser buscado</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Produto>> GetProdutoById(int id)
        {
            try
            {
                var result = await _produtoRepository.GetProdutoById(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter produto");
            }
        }

        /// <summary>
        /// Função responsável por adicionar uma produto.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Produto>> AddProduto([FromBody] Produto produto)
        {
            try
            {
                if (produto == null) return BadRequest();

                var createProduto = await _produtoRepository.AddProduto(produto);

                return CreatedAtAction(nameof(GetProdutos),
                    new { id = createProduto.ProdutoId }, createProduto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar produto");
            }
        }

        /// <summary>
        /// Função responsável por atualizar o produto.
        /// </summary>
        /// <param name="produto"> id do produto a ser atualizado</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Produto>> UpdateProduto([FromBody] Produto produto)
        {
            try
            {
                var DptToUpdate = await _produtoRepository.GetProdutoById(produto.ProdutoId);

                if (DptToUpdate == null) return NotFound($"Produto com id {produto.ProdutoId} não encontrado");

                return await _produtoRepository.UpdateProduto(produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar produto");
            }
        }

        /// <summary>
        /// Função responsável por atualizar a produto.
        /// </summary>
        /// <param name="id"> id do produto a ser atualizado</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            try
            {
                var produtoDelete = await _produtoRepository.GetProdutoById(id);

                if (produtoDelete == null) return NotFound($"Produto com id {id} não encontrado");

                _produtoRepository.DeleteProduto(id);

                return Ok($"Produto com id {id} deletado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar produto");
            }
        }
    }
}
