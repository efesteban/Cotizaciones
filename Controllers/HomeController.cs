using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cotizaciones.Data;
using Cotizaciones.Models;

namespace Cotizaciones.Controllers
{
    public class HomeController : Controller
    {
        private readonly CotizacionesContext _context;

        public HomeController(CotizacionesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login(string email, string pass)
        {
            //Validar Inicio de sesion

            if (email == null)
            {
                ViewData["Message"] = "No hay correo";
                return NotFound();
            }

            var persona = _context.Personas.Where(m => m.Email == email);
            
            if (persona == null)
            {
                return NotFound();
            }else
            {   

                

                ViewData["persona"] = persona.First();
                return View("~/Views/Home/Inicio.cshtml"); 
            }



               
        }





    }
}
