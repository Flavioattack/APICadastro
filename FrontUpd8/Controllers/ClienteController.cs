using Microsoft.AspNetCore.Mvc;
//using FrontUpd8.Models;
using APIProjetoUpd8;
using APIProjetoUpd8.Controllers;
using DbContext = APIProjetoUpd8.Data.DbContext;
using FrontUpd8.Models;
using System.Collections.Generic;
using FluentAssertions;
using Newtonsoft.Json;

namespace FrontUpd8.Controllers
{

    public class ClienteController : Controller
    {

        private readonly DbContext _clienteContext;
        APIProjetoUpd8.Controllers.ClienteController API;

        //Metodos SupAPI;

        public ClienteController(DbContext clienteContext)
        {
            API = new APIProjetoUpd8.Controllers.ClienteController(clienteContext);
            //SupAPI = new Metodos(clienteContext);
            _clienteContext = clienteContext;
        }

        public IActionResult Editar()
        {
            return View ();
        }

        ////Ao entrar na view esses comandos serão chamados


        [HttpPost]

        public JsonResult Cadastro(APIProjetoUpd8.Models.Cliente cliente)
        {
                var obj = API.InsertClientes(cliente);
                return new JsonResult(new {obj });

        }

        [HttpPut]

        public JsonResult Alterar(APIProjetoUpd8.Models.Cliente cliente)
        {
            var obj = API.UpdateCliente(cliente);
            return new JsonResult (new {obj});
        }
        [HttpDelete]

        public JsonResult Deletar(int id)
        {
            var obj = API.DeleteCliente(id);
            return new JsonResult(new { obj });
        }
    }
}


