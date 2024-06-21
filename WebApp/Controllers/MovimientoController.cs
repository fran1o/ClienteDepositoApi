
using Infraestructura.LogicaAccesoDatos.Dtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefacesServicios;
using LogicaNegocio.IntefazServicios;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using WebApp.Filter;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MovimientoController : Controller
    {

        private IAlta<MovimientoDto> _altaMovimiento;
        private IEliminar<Movimiento> _eliminarMovimiento;
        private IEditar<MovimientoDto> _editarMovimiento;
        private IObtener<Movimiento> _obtenerMovimiento;
        private IObtenerDto<MovimientoDto> _obtenerMovimientoDto;
        private IObtenerTodos<Movimiento> _obtenerMovimientos;
        private ICantidadTotal<Movimiento> _cantidadTotal;
        private IObtenerFiltroDobleString<Movimiento> _obtenerMovimientosPorTipoPorArticulo;
        private IObtenerRangoFecha<Articulo> _obtenerMovimientosFechas;
        private IObtenerElementos<string> _obtenerMovimientosCantidades;

        private int pageSize = 0;
        private int totalItems = 0;

        public MovimientoController(
            IAlta<MovimientoDto> altaMovimiento,
            IEliminar<Movimiento> eliminarMovimiento,
            IEditar<MovimientoDto> editarMovimiento,
            IObtener<Movimiento> obtenerMovimiento,
            IObtenerDto<MovimientoDto> obtenerMovimientoDto,
            IObtenerTodos<Movimiento> obtenerMovimientos,
            ICantidadTotal<Movimiento> cantidadTotal,
            IObtenerFiltroDobleString<Movimiento> obtenerMovimientosPorTipoPorArticulo,
            IObtenerRangoFecha<Articulo> obtenerMovimientosFechas,
            IObtenerElementos<string> obtenerMovimientosCantidades
        )
        {
            _altaMovimiento = altaMovimiento;
            _eliminarMovimiento = eliminarMovimiento;
            _editarMovimiento = editarMovimiento;
            _obtenerMovimiento = obtenerMovimiento;
            _obtenerMovimientoDto = obtenerMovimientoDto;
            _obtenerMovimientos = obtenerMovimientos;
            _cantidadTotal = cantidadTotal;
            _obtenerMovimientosPorTipoPorArticulo = obtenerMovimientosPorTipoPorArticulo;
            _obtenerMovimientosFechas = obtenerMovimientosFechas;
            _obtenerMovimientosCantidades = obtenerMovimientosCantidades;

            pageSize = 10;
        }


        [EncargadoAutorizado]
        public IActionResult Index(int pageNumber)
        {

            PageMovimientoViewModel movimientos = _obtenerMovimientos.Ejecutar(pageNumber);


            return View(movimientos);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [EncargadoAutorizado]
        public IActionResult Create(MovimientoDto movDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Debe completar la informacion");
                }

                movDto.Id = 0;

                _altaMovimiento.Ejecutar(movDto);
                TempData["Message"] = "Movimiento creado con éxito.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                ViewBag.Message = e.Message;
            }

            return View();
        }

        [EncargadoAutorizado]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            MovimientoDto unMovimientoDto = _obtenerMovimientoDto.Ejecutar((int)id);
            if (unMovimientoDto == null)
            {
                return RedirectToAction("Index");
            }

            return View(unMovimientoDto);
        }


        [HttpPost]
        [EncargadoAutorizado]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MovimientoDto movDto)
        {
            try
            {
                if (movDto == null)
                {
                    throw new Exception("Debe completar la informacion");
                }
                if (!ModelState.IsValid)
                {
                    throw new Exception("Debe completar la informacion");
                }


                _editarMovimiento.Ejecutar((int)id, movDto);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }


        [EncargadoAutorizado]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Movimiento unMovimiento = _obtenerMovimiento.Ejecutar((int)id);
            if (unMovimiento == null)
            {
                return RedirectToAction("Index");
            }
            return View(unMovimiento);
        }

        [HttpPost]
        [EncargadoAutorizado]
        public IActionResult Delete(int id)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                _eliminarMovimiento.Ejecutar((int)id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ViewBag.Message = e.Message;
            }
            return View();
        }

        


        [EncargadoAutorizado]
        public IActionResult TipoYArticulo(string tipoMov = "", string articuloId = "", int page = 0)
        {
            if(tipoMov != "" && articuloId != "") { 
                PageMovimientoViewModel movimientos = _obtenerMovimientosPorTipoPorArticulo.Ejecutar(articuloId, tipoMov, page);
                return View(movimientos);
            } else
            {
                PageMovimientoViewModel vacio = new PageMovimientoViewModel() { };
                vacio.TotalPages = 0;
                vacio.TotalItems = 0;
                vacio.Items = [];
                vacio.PageNumber = 0;
                return View(vacio);
            }
             
            
        }

        [EncargadoAutorizado]
        public IActionResult ArtPorFechas(DateTime desde, DateTime hasta, int page = 0)
        {
            PageViewModel<Articulo> articulos = new PageViewModel<Articulo>() { };
            articulos.TotalPages = 0;
            articulos.TotalItems = 0;
            articulos.Items = [];
            articulos.PageNumber = 0;

            DateTime fechaMinima = new DateTime(1900, 1, 1);
            if (desde > fechaMinima && hasta > fechaMinima) {
                articulos = _obtenerMovimientosFechas.Ejecutar(desde, hasta, page);
            }
            return View(articulos);
        }

        [EncargadoAutorizado]
        public IActionResult CantidadesPorAnio()
        {
            IEnumerable<string> res = _obtenerMovimientosCantidades.Ejecutar();


            return View(res);
        }
    }
}
