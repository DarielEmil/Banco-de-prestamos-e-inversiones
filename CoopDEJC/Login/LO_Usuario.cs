
using CoopDEJC.Models.CoopDBModels;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CoopDEJC.Login
{
    //login de la conexion para el usuario
    public class LO_Usuario
    {
        //Metodo para buscar usuarios y autenticar al momento de loguearse
        public Cliente SearchUser(string email, string password)
        {
            Cliente obje = new Cliente();


            using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-F4P216H\\SQLEXPRESS01; Initial Catalog=CoopDB; Integrated Security=true; TrustServerCertificate=True"))
            {

                string query = "Select Nombre,Correo,Clave from Clientes where Correo = @pcorreo And Clave = @pclave";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pcorreo", email);
                cmd.Parameters.AddWithValue("@pclave", password);
                cmd.CommandType = CommandType.Text;

                conexion.Open();
                
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        obje = new Cliente() 
                        {
                            Nombre = dr["Nombre"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Clave  = dr["Clave"].ToString(),
                    };
                    }
                   
                }
            }

            return obje;
        }

    }
}
