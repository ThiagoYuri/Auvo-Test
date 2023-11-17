using Auvo.RH.Models;
using Auvo.RH.Models.Dto.Analise;
using Auvo.RH.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Xml;

namespace Auvo.RH.Controllers
{

    public class AnalisePontoController : Controller
    {
        private AnalisePontoServices _analisePontoServices;

        public AnalisePontoController(AnalisePontoServices analisePontoServices)
        {
            _analisePontoServices = analisePontoServices;
        }

        public IActionResult Index() { return View(); }


        [HttpPost]
        public async Task<IActionResult> Index(List<IFormFile> files)
        {
            try
            {
                //_analisePontoServices.AdicionarCSVBanco(files);
            }catch (Exception ex)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = "Erro: "+ ex.Message
                };
                // Redirect to the shared error view with the ErrorViewModel
                return View("Error", errorViewModel);
            }


            //ViewBag.Message = "Arquivos enviados com sucesso!";

            return View();
        }

        public ActionResult Error(ErrorViewModel model)
        {
            // Display the error view with the ErrorViewModel
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Relatorio()
        {
            IEnumerable<AnaliseDepartamentoDto> result = _analisePontoServices.Relatorio();
            string jsonString = JsonSerializer.Serialize(result); 
            return Ok(jsonString);
        }

    }


}
