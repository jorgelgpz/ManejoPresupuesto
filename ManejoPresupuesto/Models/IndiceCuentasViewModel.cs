namespace ManejoPresupuesto.Models
{
    public class IndiceCuentasViewModel
    {
        public string TipoCuenta { get; set; }
        public IEnumerable<Cuenta> Cuentas { get; set; }
        // Balance es una sumatoria de las "Cuentas" que pertenecen al "TipoCuenta"
        public decimal Balance => Cuentas.Sum(x => x.Balance);
    }
}
