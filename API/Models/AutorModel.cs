using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;



namespace EstudosEntity.Models
{
    // modelo de autor, com as propriedades Id, Nome e Sobrenome, onde Id é a chave primária e Nome e Sobrenome são campos obrigatórios.
    //Além disso, o modelo de autor tem uma coleção de livros, que é uma referência para o modelo de livro
    public class AutorModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }
        [JsonIgnore]

        public ICollection<LivroModel> Livros { get; set; }
    }
}
