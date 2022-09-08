using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Datos
{
    class BDHelper
    {
        private static BDHelper instancia;
        private SqlConnection conexion;
        private SqlCommand comando;
        private string cadenaConexion;

        private BDHelper()
        {
            conexion = new SqlConnection();
            comando = new SqlCommand();
            cadenaConexion = Properties.Resources.StringConexion;
                // @"Data Source=maquis;Initial Catalog=BugTracker;User ID=avisuales1;password=Pav1#2020Maquis";
        }
        public static BDHelper obtenerInstancia()
        {
            if (instancia == null)
                instancia = new BDHelper();
            return instancia;
        }
        public DataTable consultar(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            conexion.ConnectionString = cadenaConexion;
            conexion.Open();

            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());
            
            conexion.Close();
            return tabla;
        }
    }
}
