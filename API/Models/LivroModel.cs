using EstudosEntity.Models;

namespace EstudosEntity.Models
{
    // modelo de livro, com as propriedades Id, Titulo e Autor, onde Autor é uma referência para o modelo de autor
    public class LivroModel
    {
       public int Id { get; set; }
        public string Titulo { get; set; }

        public AutorModel Autor { get; set; }

    }
}
