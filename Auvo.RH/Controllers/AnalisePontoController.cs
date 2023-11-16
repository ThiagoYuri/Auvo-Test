using Auvo.RH.Models;
using Auvo.RH.Services;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection.PortableExecutable;

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

    }
}
