using Auvo.RH.Services;
using Microsoft.AspNetCore.Mvc;

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
            _analisePontoServices.UpdateData(files);

            //ViewBag.Message = "Arquivos enviados com sucesso!";

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Relatorio()
        {


            return Ok("teste");
        }

    }


}
