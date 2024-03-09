using Microsoft.AspNetCore.Mvc;
using Projeto.GTI.Domain.Entities;
using Projeto.GTI.Web.Controllers.Base;
using Projeto.GTI.Web.Models;
using System;
using System.Net;

namespace Projeto.GTI.Web.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly string _url;

        public ClientesController(IConfiguration configuration) : base(configuration)
        {
            _url = $"{GetConfiguration.GetSection("ApiGti").Value}Cliente/";
        }
        public async Task<IActionResult> Index()
        {
            var retorno = await GetApi<IEnumerable<ClienteViewModelResponse>>($"{_url}Listar");

            return View(retorno);
        }
        public async Task<IActionResult> Details(int id) 
        {
            var retorno = await GetApi<ClienteViewModelResponse>($"{_url}ConsultarCliente?idCliente={id}");

            return View(retorno);
        }
        public async Task<IActionResult> Edit(int id) 
        {
            var retorno = await GetApi<ClienteViewModelResponse>($"{_url}ConsultarCliente?idCliente={id}");

            return View(retorno);
        }
        

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] ClienteViewModel cliente)
        {
            try
            {
                var retorno = await PostApi<object,Cliente>($"{_url}Adicionar", cliente.MontarObjetoRequest());

                return Json(cliente);

            }
            catch (Exception ex)
            {

                return Json(ex);//new ResponsePadrao<CoberturaDTO> { IsOk = false, MensagemRetorno = $"Erro ao inserir cobertura . Erro Técnico [{ex.Message}]." });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Alterar([FromBody] ClienteViewModel cliente)
        {
            try
            {
                var retorno = await PostApi<object, Cliente>($"{_url}Adicionar", cliente.MontarObjetoRequest());

                return Json(cliente);

            }
            catch (Exception ex)
            {

                return Json(ex);//new ResponsePadrao<CoberturaDTO> { IsOk = false, MensagemRetorno = $"Erro ao inserir cobertura . Erro Técnico [{ex.Message}]." });
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            await DeleteApi<object>($"{_url}Deletar?idCliente={id}");
            return RedirectToAction("Index");
        }
    }
}
