using APIProjetoUpd8.Controllers;
using APIProjetoUpd8.Data;
using APIProjetoUpd8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Net.WebSockets;
using System.Web.Providers.Entities;
using DbContext = APIProjetoUpd8.Data.DbContext;

namespace APIProjetoUpd8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

   

    public class ClienteController : ControllerBase
    {
        private readonly DbContext _dbContext;

        public ClienteController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> ListaClientes()
        {
            List<Cliente> listaCliente = _dbContext.clientes.ToList<Cliente>();
            
            var str = JsonConvert.SerializeObject(listaCliente);
            

            return Ok(new
            {
                success = true,
                data = await _dbContext.clientes.ToListAsync(),
                dados = str

            });

        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> ListaClientes(Int64 codigo) 
        {
            var _id = codigo;
            return Ok(new
            {
                success = true,
                data = await _dbContext.clientes.FirstOrDefaultAsync(e => e.Id == _id)
            });
        }
    
        [HttpPost]
        public async Task<IActionResult> InsertClientes(Cliente cliente) 
        {
            _dbContext.clientes.Add(cliente);
            await _dbContext.SaveChangesAsync();
            return Ok(new 
            {
                Success = true,
                data = cliente
            });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCliente (Cliente cliente)
        {
            _dbContext.clientes.Update(cliente);
            await _dbContext.SaveChangesAsync();
            return Ok(new
            {
                Sucess = true,
                data = cliente
            }); ;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCliente(Cliente cliente)
        {
            _dbContext.clientes.Remove(cliente);
            await _dbContext.SaveChangesAsync();
            return Ok(new
            {
                Sucess = true,
                data = cliente
            }); ;
        } 
    }
    public class Metodos : ControllerBase
    {
        private readonly DbContext _dbContext;
        public Metodos(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string RetornaSeasson()
        {
            List<Cliente> listaCliente = _dbContext.clientes.ToList<Cliente>();
            var str = JsonConvert.SerializeObject(listaCliente);
            return str;

        }
    }
}

