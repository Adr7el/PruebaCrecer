using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DB;
using AccesoDatos.Models;
using System.Xml;
using Newtonsoft.Json;

namespace AccesoDatos.Servicios
{
    public class ServiciosUsuario
    {
        readonly Database db = new Database();

        #region GetData
        public List<Afiliado> LlenarDatos()
        {
            //modelo
            Afiliado[] AfiliadoArray = null;
            //lista
            List<Afiliado> lista = new List<Afiliado>();
            var select = ("SELECT NUP,Nombres,Apellidos,Edad,NIT,DUI FROM AFILIADO;");
            //Obteniendo la conexion
            var con = new SqlConnection(db.ObtenerConexion());
            //Abriendo la conexion a la BD
            con.Open();

            var cmd = new SqlCommand(select, con);

            using (var reader = cmd.ExecuteReader())
            {
                lista = new List<Afiliado>();
                while (reader.Read())
                    lista.Add(new Afiliado
                    {
                        NUP = reader.GetString(0),
                        Nombres = reader.GetString(1),
                        Apellidos = reader.GetString(2),
                        Edad = reader.GetInt32(3),
                        NIT = reader.GetString(4),
                        DUI = reader.GetString(5)
                    });
                //convirtiendo el array a lista
                //AfiliadoArray = list.ToArray();
                //response = JsonConvert.SerializeObject(AfiliadoArray, Formatting.Indented);
            }
            con.Close();
            return lista;
        }
        #endregion

        #region AData
        public string ADatos(string NUP, string Nombres, string Apellidos, int Edad, string NIT, string DUI)
        {
            //modelo
            Afiliado[] AfiliadoArray = null;
            //lista
            List<Afiliado> lista = new List<Afiliado>();
            var insert = ($"INSERT INTO AFILIADO(NUP,Nombres,Apellidos,Edad,NIT,DUI) VALUES ('{NUP}','{Nombres}','{Apellidos}','{Edad}','{NIT}','{DUI}');");
            //Obteniendo la conexion
            var con = new SqlConnection(db.ObtenerConexion());
            //Abriendo la conexion a la BD
            con.Open();

            var cmd = new SqlCommand(insert, con);
            con.Close();
            return "Datos ingresados exitosamente";
        }
        #endregion
    }
}
