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
            try
            { 
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
            }
            catch 
            {
                optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Clientes; Data Source=DESKTOP-OOI83AP");
            }
        }
    }
}
