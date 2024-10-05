using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class voucherNegocio
    {
        public List<Voucher> listar()
        {
            List<Voucher> lista = new List<Voucher>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers"); // Asegúrate de que la consulta sea correcta
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Voucher aux = new Voucher();
                    aux.codigoVoucher = (string)datos.Lector["CodigoVoucher"];
                    aux.idCliente = (int)datos.Lector["IdCliente"];

                    // Manejar el valor nulo de IdArticulo
                    if (datos.Lector["IdArticulo"] != DBNull.Value) // Verifica si el valor no es nulo
                    {
                        aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    }
                    else
                    {
                        aux.IdArticulo = -1; // O cualquier valor que tenga sentido para tu lógica
                    }

                    aux.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex) // Captura la excepción y puedes registrar el error
            {
                // Manejo de errores: puedes registrar el error aquí o lanzar una nueva excepción
                throw new Exception("Error al listar vouchers", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public enum EstadoVoucher
        {
            Inexistente,
            Utilizado,
            Valido
        }

        public EstadoVoucher verificarCodigo(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Consulta SQL para verificar si el voucher existe y su estado
                datos.setearConsulta("SELECT IdArticulo FROM Vouchers WHERE CodigoVoucher = @codigo");
                datos.setearParametro("@codigo", codigo);

                // Ejecutar la consulta y leer los resultados
                SqlDataReader lector = datos.ejecutarLectura();

                // Si no hay registros, el voucher no existe
                if (!lector.HasRows)
                {
                    return EstadoVoucher.Inexistente;
                }

                // Si existe, leer el IdArticulo para determinar su estado
                lector.Read(); // Mover el lector al primer resultado
                int idArticulo = lector["IdArticulo"] != DBNull.Value ? (int)lector["IdArticulo"] : -1;

                // Verificar si el IdArticulo indica que el voucher ha sido utilizado
                if (idArticulo != -1)
                {
                    return EstadoVoucher.Utilizado;
                }

                // Si el IdArticulo es -1, el voucher es valido
                return EstadoVoucher.Valido;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar el código de voucher.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
