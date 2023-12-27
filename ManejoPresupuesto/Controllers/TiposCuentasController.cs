using Dapper;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace ManejoPresupuesto.Controllers
{
    public class TiposCuentasController: Controller
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
        public IActionResult Crear(TipoCuenta tipoCuenta)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoCuenta);
            }


            tipoCuenta.UsuarioId = 1;
            repostorioTiposCuentas.Crear(tipoCuenta);


            return View();
        }

    }
}
