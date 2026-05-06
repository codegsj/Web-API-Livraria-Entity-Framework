using EstudosEntity.Models;
using EstudosEntity.Services.Autor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstudosEntity.Dto.Autor;

namespace EstudosEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorinterface _autorinterface;
        public AutorController(IAutorinterface autorinterface)
        {
            _autorinterface = autorinterface;
        }
        
        [HttpGet("ListarAutores")]
        // método para listar todos os autores
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorinterface.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId/{idAutor}")]
        // método para buscar um autor por id
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var autor = await _autorinterface.BuscarAutorPorId(idAutor);
            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
        // método para buscar um autor por id do livro
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        {   
            var autor = await _autorinterface.BuscarAutorPorIdLivro(idLivro);
            return Ok(autor);
        }

            [HttpPost("CriarAutor")]
        // método para criar um novo autor
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autores = await _autorinterface.CriarAutor(autorCriacaoDto);
            return Ok(autores);
        }

            [HttpPut("EditarAutor")]
        // método para editar um autor existente

        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            var autores = await _autorinterface.EditarAutor(autorEdicaoDto  );
            return Ok(autores);
        }

        [HttpDelete("ExcluirAutor/{idAutor}")]
        // método para excluir um autor existente
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ExcluirAutor(int idAutor)
        {
            var autores = await _autorinterface.ExcluirAutor(idAutor);
            return Ok(autores);
        }
    }
}
