using Microsoft.EntityFrameworkCore;
using EstudosEntity.Models;

namespace EstudosEntity.Data    
{
    // classe de contexto do banco de dados, responsável por mapear os modelos para as tabelas do banco de dados
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        { 

        }

        // modelos que serão mapeados para a criação das tabelas no banco de dados
        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
    }
}
