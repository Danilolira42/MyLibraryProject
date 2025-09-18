using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyLibrary.API.ModelDTO;

namespace Library.Infraestructure
{
    public class BooksDbContext : DbContext
    {

        private IConfiguration _configuration;

        public DbSet<Books> Books { get; set; }

        public BooksDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var typeDatabase = _configuration["TypeDatabase"];

            var connectionString = _configuration.GetConnectionString(typeDatabase);

            if (typeDatabase == "MySql")
            {
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

    }

}
