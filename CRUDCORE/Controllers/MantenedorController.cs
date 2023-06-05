using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Datos;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _contactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            // La lista mostrara una lista de contactos
            var oLIsta = _contactoDatos.Listar();
            return View(oLIsta);
        }

        // Mostrar el formulario
        public IActionResult Guardar()
        {
            // Método devuelve la vista
            return View();
        }

        // Recibe el objeto que se quiere guardar
        [HttpPost]
        public IActionResult Guardar(ContactoModelo oContacto)
        {
            // Método recibe el objeto para guardar en la BDD
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _contactoDatos.Guardar(oContacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
            
        }

        // Visualizar el formulario
        public IActionResult Editar(int IdContacto)
        {
            // Método devuelve la vista
            var ocontacto = _contactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }

        // Método recibe el objeto que se ha modificado
        [HttpPost]
        public IActionResult Editar(ContactoModelo oContacto)
        {
            // Método recibe el objeto para guardar en la BDD
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _contactoDatos.Editar(oContacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int IdContacto)
        {
            // Método devuelve la vista
            var ocontacto = _contactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }

        // Método recibe el objeto que se ha modificado
        [HttpPost]
        public IActionResult Eliminar(ContactoModelo oContacto)
        {
            var respuesta = _contactoDatos.Eliminar(oContacto.IdContacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
