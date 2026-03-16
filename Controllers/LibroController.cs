using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BibliotecaMVC.Models;

namespace BibliotecaMVC.Controllers
{
    public class LibroController : Controller
    {
        // Lista estática en memoria (simula una base de datos)
        private static List<Libro> libros = new List<Libro>
        {
            new Libro { Codigo = "L001", Titulo = "El Quijote", Autor = "Miguel de Cervantes", FechaPublicacion = new DateTime(1605, 1, 16) },
            new Libro { Codigo = "L002", Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", FechaPublicacion = new DateTime(1967, 5, 30) },
            new Libro { Codigo = "L003", Titulo = "1984", Autor = "George Orwell", FechaPublicacion = new DateTime(1949, 6, 8) }
        };

        // 1. CONSULTAR (GET: Libro/Index)
        [HttpGet]
        public ActionResult Index(string filtro)
        {
            var resultado = libros.AsEnumerable();

            if (!string.IsNullOrEmpty(filtro))
            {
                resultado = libros.Where(l =>
                    l.Titulo.ToLower().Contains(filtro.ToLower()) ||
                    l.Codigo.ToLower().Contains(filtro.ToLower()));
            }

            ViewBag.Filtro = filtro;
            return View(resultado.ToList());
        }

        // 2. REGISTRAR - VISTA (GET: Libro/Registrar)
        [HttpGet]
        [ActionName("Registrar")]
        public ActionResult RegistrarGet()
        {
            return View();
        }

        // 2. REGISTRAR - PROCESAR (POST: Libro/Registrar)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Registrar")]
        public ActionResult RegistrarPost(Libro nuevoLibro)
        {
            if (ModelState.IsValid)
            {
                if (libros.Any(l => l.Codigo == nuevoLibro.Codigo))
                {
                    ModelState.AddModelError("Codigo", "Ya existe un libro registrado con ese código.");
                    return View(nuevoLibro);
                }

                libros.Add(nuevoLibro);
                TempData["Mensaje"] = "¡Libro registrado con éxito!";
                return RedirectToAction("Index");
            }

            return View(nuevoLibro);
        }

        // 3. VER DETALLE (GET: Libro/VerDetalle/id)
        [HttpGet]
        public ActionResult VerDetalle(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var libro = libros.FirstOrDefault(l => l.Codigo == id);

            if (libro == null)
            {
                ViewBag.Error = "El libro con código [" + id + "] no fue encontrado.";
                return View("ErrorDetalle");
            }

            return View(libro);
        }

        // 4. ELIMINAR (POST: Libro/Eliminar)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(string codigo)
        {
            var libro = libros.FirstOrDefault(l => l.Codigo == codigo);
            if (libro != null)
            {
                libros.Remove(libro);
                TempData["Mensaje"] = "El libro ha sido eliminado.";
            }
            else
            {
                TempData["Error"] = "No se pudo encontrar el libro para eliminar.";
            }

            return RedirectToAction("Index");
        }
    }
}
