using EstudosEntity.Data;
using EstudosEntity.Dto.Autor;
using EstudosEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace EstudosEntity.Services.Autor
{
    public class AutorService : IAutorinterface
    {
        private readonly AppDbContext _context;
        // construtor para injetar o contexto do banco de dados
        public AutorService(AppDbContext context)
        {
            _context = context;
        }

        // método para buscar um autor por id, retornando um objeto de resposta com os dados do autor encontrado
        //ou uma mensagem de erro caso o autor não seja encontrado
        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);
                if (autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = autor;
                resposta.Mensagem = "Autor encontrado com sucesso.";
                return resposta;

            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        // método para buscar um autor por id do livro, retornando um objeto de resposta com os dados do autor encontrado
        //ou uma mensagem de erro caso o autor não seja encontrado para o livro especificado
        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
                if (livro == null)
                {
                    resposta.Mensagem = "Autor não encontrado para o livro especificado.";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Autor encontrado com sucesso para o livro especificado.";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        // método para criar um novo autor, recebendo um objeto de criação de autor e retornando um objeto de resposta com a lista atualizada de autores
        // ou uma mensagem de erro caso ocorra algum problema durante a criação
        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = new AutorModel
                {
                    Nome = autorCriacaoDto.Nome,
                    Sobrenome = autorCriacaoDto.Sobrenome
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor criado com sucesso.";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        // método para editar um autor existente, recebendo um objeto de edição de autor e retornando um objeto de resposta com a lista atualizada de autores
        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autoEdicaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
               var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == autoEdicaoDto.Id);
                if (autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }
                autor.Nome = autoEdicaoDto.Nome;
                autor.Sobrenome = autoEdicaoDto.Sobrenome;
                _context.Update(autor);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor editado com sucesso.";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        // método para excluir um autor por id, retornando um objeto de resposta com a lista atualizada de autores ou uma mensagem de erro caso o autor não seja encontrado
        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            { 
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);
                if (autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor excluído com sucesso.";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        // método para listar todos os autores, retornando um objeto de resposta com a lista de autores ou uma mensagem de erro caso ocorra algum problema durante a consulta
        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try 
            {
                var autores = await _context.Autores.ToListAsync();
                resposta.Dados = autores;
                resposta.Mensagem = "Autores listados com sucesso.";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
          
        }
    }
}
