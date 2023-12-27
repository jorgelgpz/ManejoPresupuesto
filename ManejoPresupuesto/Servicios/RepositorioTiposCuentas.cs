using Dapper;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{
    public interface IRepositorioTiposCuentas
    {
        //asignaturas
        Task Crear(TipoCuenta tipoCuenta);
        Task<bool> Existe(string Nombre, int UsuarioId);
    }
    public class RepositorioTiposCuentas: IRepositorioTiposCuentas
    {
        private readonly string connectionString;

        public RepositorioTiposCuentas(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(TipoCuenta tipoCuenta)
        {


            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>(@"INSERT INTO TiposCuentas (Nombre,UsuarioId, Orden) VALUES (@Nombre, @UsuarioId, 0);
                                                    SELECT SCOPE_IDENTITY();",tipoCuenta);
            //SELECT SCOPE_IDENTITY me retorna el id del registro recien creado

            tipoCuenta.Id = id;
        }

        public async Task<bool> Existe(string Nombre,int UsuarioId)
        {
            using var connection = new SqlConnection(connectionString);
            var existe = await connection.QueryFirstOrDefaultAsync<int>(@"SELECT 1 
                                                                        FROM TiposCuentas
                                                                        WHERE Nombre = @Nombre AND UsuarioId = @UsuarioId;",
                                                                        new {Nombre, UsuarioId});

            return existe == 1;
        }
    }
}
