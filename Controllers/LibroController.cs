using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BibliotecaMVC.Models;

namespace BibliotecaMVC.Controllers
{
    public class LibroController : Controller
    {
        // Lista en memoria para almacenar los libros (Simulación de BD)
        private static List<Libro> listaLibros = new List<Libro>
        {
            new Libro { Codigo = "L001", Titulo = "El Quijote", Autor = "Miguel de Cervantes", FechaPublicacion = new DateTime(1605, 1, 1) },
            new Libro { Codigo = "L002", Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", FechaPublicacion = new DateTime(1967, 5, 30) },
            new Libro { Codigo = "L003", Titulo = "La Odisea", Autor = "Homero", FechaPublicacion = new DateTime(800, 1, 1) }
        };

        // GET: Libro/Index  — Consultar/Listar libros
        [HttpGet]
        public ActionResult Index(string filtro)
        {
            var libros = listaLibros.AsEnumerable();

            if (!string.IsNullOrEmpty(filtro))
            {
                string f = filtro.ToLower();
                libros = libros.Where(l =>
                    l.Codigo.ToLower().Contains(f) ||
                    l.Titulo.ToLower().Contains(f));
            }

            ViewBag.Filtro = filtro;
            return View(libros.ToList());
        }

        // GET: Libro/Registrar  — Mostrar formulario de registro
        [HttpGet]
        [ActionName("Registrar")]
        public ActionResult RegistrarGet()
        {
            return View("Registrar", new Libro());
        }

        // POST: Libro/Registrar  — Procesar el registro del libro
        [HttpPost]
        [ActionName("Registrar")]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarPost(Libro nuevoLibro)
        {
            if (ModelState.IsValid)
            {
                // Verificar si el código ya existe
                if (listaLibros.Any(l => l.Codigo.Equals(nuevoLibro.Codigo, StringComparison.OrdinalIgnoreCase)))
                {
                    ModelState.AddModelError("Codigo", "Este código de libro ya está registrado.");
                    return View("Registrar", nuevoLibro);
                }

                listaLibros.Add(nuevoLibro);
                TempData["Mensaje"] = "✔ Libro \"" + nuevoLibro.Titulo + "\" registrado exitosamente.";
                return RedirectToAction("Index");
            }

            return View("Registrar", nuevoLibro);
        }

        // GET: Libro/VerDetalle/{id}  — Ver información completa de un libro
        [HttpGet]
        public ActionResult VerDetalle(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Error = "No se proporcionó un código de libro válido.";
                return View("ErrorDetalle");
            }

            var libro = listaLibros.FirstOrDefault(l => l.Codigo == id);
            if (libro == null)
            {
                ViewBag.Error = "El libro con código \"" + id + "\" no se encuentra en el sistema.";
                return View("ErrorDetalle");
            }

            return View(libro);
        }

        // POST: Libro/Eliminar  — Eliminar un libro de la lista
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(string codigo)
        {
            var libro = listaLibros.FirstOrDefault(l => l.Codigo == codigo);
            if (libro != null)
            {
                string titulo = libro.Titulo;
                listaLibros.Remove(libro);
                TempData["Mensaje"] = "✔ El libro \"" + titulo + "\" fue eliminado correctamente.";
            }
            else
            {
                TempData["Error"] = "✘ No se encontró el libro para eliminar.";
            }

            return RedirectToAction("Index");
        }

        // Método auxiliar interno — no accesible como acción HTTP
        [NonAction]
        public bool ExisteLibro(string codigo)
        {
            return listaLibros.Any(l => l.Codigo == codigo);
        }
    }
}
