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

        public void agregarCliente(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) VALUES (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @Cp)");
                datos.setearParametro("@Documento", cliente.documento);
                datos.setearParametro("@Nombre", cliente.nombre);
                datos.setearParametro("@Apellido", cliente.apellido);
                datos.setearParametro("@Email", cliente.email);
                datos.setearParametro("@Direccion", cliente.direccion);
                datos.setearParametro("@Ciudad", cliente.ciudad);
                datos.setearParametro("@Cp", cliente.codigoPostal);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Cliente buscarCliente(string dni) { 
            Cliente cliente = new Cliente();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @documento");
                datos.setearParametro("@documento", dni);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    cliente.id = (int)datos.Lector["Id"];
                    cliente.documento = (string)datos.Lector["Documento"];
                    cliente.nombre = (string)datos.Lector["Nombre"];
                    cliente.apellido = (string)datos.Lector["Apellido"];
                    cliente.email = (string)datos.Lector["Email"];
                    cliente.direccion = (string)datos.Lector["Direccion"];
                    cliente.ciudad = (string)datos.Lector["Ciudad"];
                    cliente.codigoPostal = (int)datos.Lector["CP"];
                }
                return cliente;

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

    }
}