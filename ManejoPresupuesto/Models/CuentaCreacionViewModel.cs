using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManejoPresupuesto.Models
{
    public class CuentaCreacionViewModel : Cuenta
    {
        //SelectListItem es una clase que me permite crear selects facilmente 
        public IEnumerable<SelectListItem> TiposCuentas { get; set; }
    }
}
