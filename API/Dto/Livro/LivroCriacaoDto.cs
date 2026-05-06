using EstudosEntity.Models;

namespace EstudosEntity.Dto.Livro
{
    public class LivroCriacaoDto
    {
        public string Titulo { get; set; }

        public AutorModel Autor { get; set; }
    }
}
