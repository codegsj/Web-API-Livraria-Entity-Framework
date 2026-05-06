namespace EstudosEntity.Dto.Autor
{
    // DTO para edição de autor, contendo as propriedades necessárias para atualizar um autor existente
    public class AutorEdicaoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }
    }
}
