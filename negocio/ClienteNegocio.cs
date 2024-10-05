using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id,Documento,Nombre,Apellido,Email,Direccion,Ciudad,CP FROM Clientes");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.id = (int)datos.Lector["Id"];
                    aux.documento = (string)datos.Lector["Documento"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.apellido = (string)datos.Lector["Apellido"];
                    aux.email = (string)datos.Lector["Email"];
                    aux.direccion = (string)datos.Lector["Direccion"];
                    aux.ciudad = (string)datos.Lector["Ciudad"];
                    aux.codigoPostal = (int)datos.Lector["CP"];
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool verificarCliente(string dni)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Documento FROM Clientes WHERE Documento = @documento");
                datos.setearParametro("@documento", dni);
                SqlDataReader lector = datos.ejecutarLectura();

                if (!lector.HasRows)
                {
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar el código de cliente.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AgregarCliente(Cliente datos)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO Clientes(Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) VALUES(@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)");
                accesoDatos.setearParametro("@Documento", datos.documento);
                accesoDatos.setearParametro("@Nombre", datos.nombre);
                accesoDatos.setearParametro("@Apellido", datos.apellido);
                accesoDatos.setearParametro("@Email", datos.email);
                accesoDatos.setearParametro("@Direccion", datos.direccion);
                accesoDatos.setearParametro("@Ciudad", datos.ciudad);
                accesoDatos.setearParametro("@CP", datos.codigoPostal);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

    }
}