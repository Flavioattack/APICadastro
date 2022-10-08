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

        Metodos SupAPI;

        public ClienteController(DbContext clienteContext)
        {
            API = new APIProjetoUpd8.Controllers.ClienteController(clienteContext);
            SupAPI = new Metodos(clienteContext);
            _clienteContext = clienteContext;
        }


        public IActionResult Cadastro()
        {
            return View();//Como vai tá em branco para criar
        }

        public IActionResult Editar()
        {
            
            var str = SupAPI.RetornaSeasson();
            var obj = JsonConvert.DeserializeObject<List<APIProjetoUpd8.Models.Cliente>>(str);

            return View (obj);

        }

        ////Ao entrar na view esses comandos serão chamados


        [HttpPost]

        public IActionResult Cadastro(APIProjetoUpd8.Models.Cliente cliente)
        {
            try
            {
                API.InsertClientes(cliente);
                return RedirectToAction("Editar",cliente);
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro ao cadastrar Cliente!";
                return RedirectToAction("Cadastro");
            }
        }

        [HttpPost]

        public IActionResult Alterar(APIProjetoUpd8.Models.Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    API.UpdateCliente(cliente);

                    TempData["MensagemSucesso"] = "Cliente atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", cliente);
            }

            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro ao atualizar o Cliente!";
                return RedirectToAction("Index");
            }
        }

    }
}


