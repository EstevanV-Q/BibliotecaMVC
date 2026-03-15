using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BibliotecaMVC.Models;
using BibliotecaMVC.Data;

namespace BibliotecaMVC.Controllers
{
    public class LibroController : Controller
    {
        private BibliotecaContext db = new BibliotecaContext();

        // 1. CONSULTAR (GET: Libro/Index)
        [HttpGet]
        public ActionResult Index(string filtro)
        {
            var libros = from l in db.Libros
                        select l;

            if (!string.IsNullOrEmpty(filtro))
            {
                libros = libros.Where(l => l.Titulo.ToLower().Contains(filtro.ToLower()) ||
                                         l.Codigo.ToLower().Contains(filtro.ToLower()));
            }

            ViewBag.Filtro = filtro;
            return View(libros.ToList());
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
                // Verificar si el código ya existe
                if (db.Libros.Any(l => l.Codigo == nuevoLibro.Codigo))
                {
                    ModelState.AddModelError("Codigo", "Ya existe un libro registrado con ese código.");
                    return View(nuevoLibro);
                }

                db.Libros.Add(nuevoLibro);
                db.SaveChanges();

                TempData["Mensaje"] = "¡Libro registrado con éxito en la base de datos!";
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

            var libro = db.Libros.Find(id);

            if (libro == null)
            {
                ViewBag.Error = "El libro con código [" + id + "] no fue encontrado en la base de datos.";
                return View("ErrorDetalle");
            }

            return View(libro);
        }

        // 4. ELIMINAR (POST: Libro/Eliminar)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(string codigo)
        {
            var libro = db.Libros.Find(codigo);
            if (libro != null)
            {
                db.Libros.Remove(libro);
                db.SaveChanges();
                TempData["Mensaje"] = "El libro ha sido eliminado de la base de datos.";
            }
            else
            {
                TempData["Error"] = "No se pudo encontrar el libro para eliminar.";
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
