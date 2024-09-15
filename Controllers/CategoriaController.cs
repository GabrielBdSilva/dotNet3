using FirstOne.Models;
using FirstOne.Reposotory.Inteface;
using Microsoft.AspNetCore.Mvc;
using Sprint3.Models;

namespace FirstOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoria)
        {
            _categoriaRepository = categoria;
        }

        /// <summary>
        /// Função responsável por buscar um todas as categorias.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Categoria>> GetCategorias()
        {
            try
            {
                return Ok(await _categoriaRepository.GetCategorias());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter categoria");
            }
        }
        /// <summary>
        /// Função responsável por buscar Categoria por id.
        /// </summary>
        /// <param name="id">id da categoria a ser buscado</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categoria>> GetCategoriaById(int id)
        {
            try
            {
                var result = await _categoriaRepository.GetCategoriaById(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter categoria");
            }
        }
        /// <summary>
        /// Função responsável por adicionar uma categoria.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Categoria>> AddCategoria([FromBody] Categoria categoria)
        {
            try
            {
                if (categoria == null) return BadRequest();

                var createCategoria = await _categoriaRepository.AddCategoria(categoria);

                return CreatedAtAction(nameof(GetCategorias),
                    new { id = createCategoria.CategoriaId }, createCategoria);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar categoria");
            }
        }
        /// <summary>
        /// Função responsável por atualizar a categoria.
        /// </summary>
        /// <param name="categoria"> id da categoria a ser atualizado</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Categoria>> UpdateCategoria([FromBody] Categoria categoria)
        {
            try
            {
                var DptToUpdate = await _categoriaRepository.GetCategoriaById(categoria.CategoriaId);

                if (DptToUpdate == null) return NotFound($"Categoria com id {categoria.CategoriaId} não encontrado");

                return await _categoriaRepository.UpdateCategoria(categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar categoria");
            }
        }
        /// <summary>
        /// Função responsável por atualizar a categoria.
        /// </summary>
        /// <param name="id"> id da categoria a ser atualizado</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCategoria(int id)
        {
            try
            {
                var categoriaDelete = await _categoriaRepository.GetCategoriaById(id);

                if (categoriaDelete == null) return NotFound($"Categoria com id {id} não encontrado");

                _categoriaRepository.DeleteCategoria(id);

                return Ok($"Categoria com id {id} deletado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar categoria");
            }
        }
        /// <summary>
        /// Função responsável por buscar produtos por categoria.
        /// </summary>
        /// <param name="categoriaId">id da categoria a ser buscado</param>
        /// <returns></returns>
        [HttpGet]
        [Route("busca-produtos-por-departamento/{categoriaId}")]

        public async Task<ActionResult<IEnumerable<Produto>>> GetEmpregadosPorDepartamento(int categoriaId)
        {
            try
            {
                var produtos = await _categoriaRepository.GetProdutoByCategoria(categoriaId);
                if (produtos == null)
                {
                    return NotFound("Nenhum Produto encontrado para esta categoria");
                }
                return Ok(produtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter produto da categoria");
            }
        }
    }
}
