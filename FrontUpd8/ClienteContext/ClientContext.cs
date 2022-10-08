using FrontUpd8.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontUpd8.ClienteContext
{
    public class ClientContext : DbContext
    {

        public DbSet<Cliente> clientes { get; set; }
    }
}
