using Microsoft.AspNetCore.Mvc;

using CRUDContactos.Datos;
using CRUDContactos.Models;

namespace CRUDContactos.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            //LA VISTA MOSTRARÁ UNA LISTA DE CONTACTOS
            var oLista = _ContactoDatos.Listar();
            
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN BD

            var respuesta = _ContactoDatos.Guardar(oContacto);

            if(respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
