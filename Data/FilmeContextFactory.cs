using System;
using System.IO;
using FilmesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace FilmesApi.Data
{
    //Realizada a criação dessa classe para permitir que as migrações sejam executadas corretamente,
    //pois o Entity Framework precisa de uma maneira de criar uma instância do contexto
    //de banco de dados durante o processo de migração. A implementação da interface
    //IDesignTimeDbContextFactory<FilmeContext> fornece um método CreateDbContext que é
    //chamado pelo Entity Framework para criar uma instância do contexto de banco de dados
    //durante as migrações.
    public class FilmeContextFactory : IDesignTimeDbContextFactory<FilmeContext>
    {
        public FilmeContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("FilmeConnection");

            var optionsBuilder = new DbContextOptionsBuilder<FilmeContext>();
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 27)));

            return new FilmeContext(optionsBuilder.Options);
        }
    }
}
