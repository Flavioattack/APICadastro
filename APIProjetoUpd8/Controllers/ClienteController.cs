using APIProjetoUpd8.Controllers;
using APIProjetoUpd8.Data;
using APIProjetoUpd8.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Security.Cryptography;
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
        public async Task<JsonResult> ListaClientes()
        {
            var data = await _dbContext.clientes.ToListAsync();
            return new JsonResult(new { data });
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
        public async Task<JsonResult> InsertClientes([FromBody] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.clientes.AddAsync(cliente);
                await _dbContext.SaveChangesAsync();

                return new JsonResult(new { cliente });
            }
            return new JsonResult(new { ModelState });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCliente(Cliente cliente)
        {
            _dbContext.clientes.Update(cliente);
            await _dbContext.SaveChangesAsync();
            return Ok(new
            {
                Sucess = true,
                data = cliente
            });
        }

        [HttpDelete("{codigo}")]
        public async Task<JsonResult> DeleteCliente(int _id)
        {
            var remove = _dbContext.clientes.FirstOrDefault(e => e.Id == _id);
            _dbContext.clientes.Remove(remove);
            await _dbContext.SaveChangesAsync();

            return new JsonResult(new { remove });
        }
    }
    //public class Metodos : ControllerBase
    //{
    //    private readonly DbContext _dbContext;
    //    public Metodos(DbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }


    //}
}

