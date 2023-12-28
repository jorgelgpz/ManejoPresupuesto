using Dapper;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace ManejoPresupuesto.Controllers
{
    public class TiposCuentasController : Controller
    {
        private readonly IRepositorioTiposCuentas repostorioTiposCuentas;

        public TiposCuentasController(IRepositorioTiposCuentas repostorioTiposCuentas)
        {
            this.repostorioTiposCuentas = repostorioTiposCuentas;
        }

        public IActionResult Crear()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(TipoCuenta tipoCuenta)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoCuenta);
            }


            tipoCuenta.UsuarioId = 1;

            var yaExisteTipoCuenta = await repostorioTiposCuentas.Existe(tipoCuenta.Nombre, tipoCuenta.UsuarioId);

            if (yaExisteTipoCuenta)
            {
                ModelState.AddModelError(nameof(tipoCuenta.Nombre),
                    $"El nombre {tipoCuenta.Nombre} ya exite.");
                return View(tipoCuenta);
            }

            await repostorioTiposCuentas.Crear(tipoCuenta);


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VerificarExisteTipoCuenta(string nombre)
        {
            var usuarioId = 1;
            var yaExiteTipoCuenta = await repostorioTiposCuentas.Existe(nombre, usuarioId);
            
            if (yaExiteTipoCuenta)
            {
                return Json($"El nombre {nombre} ya existe");
            }

            return Json(true);
        }

    }
}
