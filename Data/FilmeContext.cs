using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    // Realizada a criação dessa classe para separar os Dados do projeto, seguindo o princípio de responsabilidade única
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts)
            : base(opts)
        {
            
        }

        public DbSet<Filme> Filmes { get; set; }

    }
}

