using Laboratorio4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio4.Controllers
{
    public class ProductosController : Controller
    {
        // Muestra la lista de productos
        public IActionResult Index()
        {
            var lista = ProductoRepositorio.ObtenerTodos();
            return View(lista);
        }

        // Muestra los detalles de un producto específico
        public IActionResult Detalles(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // Muestra el formulario para crear un producto
        public IActionResult Crear()
        {
            return View();
        }

        // Procesa la creación de un nuevo producto
        [HttpPost]
        public IActionResult Crear(Producto p)
        {
            if (!ModelState.IsValid)
                return View(p);

            ProductoRepositorio.Agregar(p);
            return RedirectToAction("Index");
        }

        // Muestra el formulario para editar un producto existente
        public IActionResult Editar(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // Procesa la edición de un producto
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

            if (producto == null)
            {
                return NotFound();
            }

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
