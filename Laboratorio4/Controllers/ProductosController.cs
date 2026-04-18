using Laboratorio4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio4.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            var lista = ProductoRepositorio.ObtenerTodos();
            return View(lista);
        }

        public IActionResult Detalles(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);
            return View(producto);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Producto p)
        {
            if (!ModelState.IsValid)
                return View(p);

            ProductoRepositorio.Agregar(p);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);
            return View(producto);
        }

        [HttpPost]
        public IActionResult Editar(Producto p)
        {
            if (!ModelState.IsValid)
                return View(p);

            ProductoRepositorio.Actualizar(p);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);
            return View(producto);
        }

        [HttpPost]
        public IActionResult EliminarConfirmado(int id)
        {
            ProductoRepositorio.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
