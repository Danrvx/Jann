using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using BuscarDatos.Models;
using Dapper;
using System.Data;
using Newtonsoft.Json;

namespace BuscarDatos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(ClientesBuscar modelo, int pagina = 1)
        {
            var cantidadRegistrosPorPagina = 10; // parámetro
            using (var db = new DatosClientesEntities())
            {
                Func<Clientes, bool> predicado = c =>
                    c.nombre.ToLower().Contains(modelo.Nombre.ToLower()) ||
                    c.apellidop.ToLower().Contains(modelo.Apellidop.ToLower()) ||
                    c.apellidom.ToLower().Contains(modelo.Apellidom.ToLower());

                var clientes = db.Clientes.Where(predicado).OrderBy(x => x.id)
                    .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                    .Take(cantidadRegistrosPorPagina).ToList();

                var totalDeRegistros = string.IsNullOrWhiteSpace(modelo.Nombre)
                    && string.IsNullOrWhiteSpace(modelo.Apellidop)
                    && string.IsNullOrWhiteSpace(modelo.Apellidom)
                    ? db.Clientes.Count()
                    : db.Clientes.Where(predicado).Count();

                var viewModelo = new IndexViewModel();
                viewModelo.Clientes = clientes;
                viewModelo.PaginaActual = pagina;
                viewModelo.TotalDeRegistros = totalDeRegistros;
                viewModelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

                return View(modelo);
            }
        }

        [HttpPost]
        public JsonResult Clientes(ClientesBuscar modelo)
        {
            using (var context = new DatosClientesEntities())
            {
                var clientes = context.Clientes
                    .Where(
                    c => c.nombre.ToLower().Contains(modelo.Nombre.ToLower()) ||
                    c.apellidop.ToLower().Contains(modelo.Apellidop.ToLower()) ||
                    c.apellidom.ToLower().Contains(modelo.Apellidom.ToLower())
                    )
                    .ToList();

                List<ListaClientesF> listafinal = clientes.Select(x => new ListaClientesF
                {
                    Nombre = x.nombre,
                    Apellidop = x.apellidop,
                    Apellidom = x.apellidom,
                    Telefono = x.telefono,
                    Direccion = x.direccion,
                    Asesor = x.asesor,
                    Fraccionamiento = x.fraccionamiento,
                    Financiamiento = x.financiamiento,
                    Estatus = x.estatus,
                    Ultimo_seguimiento = x.ultimo_seguimiento,
                    Ver_expediente = x.ver_expediente,
                }).ToList();

                return Json(clientes, JsonRequestBehavior.AllowGet);
            }
        }
    }
}