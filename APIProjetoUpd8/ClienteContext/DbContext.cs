using APIProjetoUpd8.Models;
using Microsoft.EntityFrameworkCore;


namespace APIProjetoUpd8.Data
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {

        }

        public DbSet<Cliente> clientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true).Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));


        }
    }
}
