using proyectoRegistrarInicioSesion.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoRegistrarInicioSesion.Negocio
{
    internal class Usuario
    {
        private string nombre;
        private string password;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        // agregamos prop de todos las columnas de la BD
        public int IdUsuaruaio { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public bool Borrado { get; set; }
        public int IdPerfil { get; set; }
        

        public Usuario()
        {
            nombre = password = string.Empty;

        }
        public Usuario(string nombre, string password)
        {
            this.nombre = nombre;
            this.password = password;
        }
        
        public int validar()
        {
            string consultaSQL = "SELECT * FROM Usuarios WHERE usuario='"
                                + this.Nombre + "' AND password='" 
                                + this.Password+"'";
            DBhelper oDB = new DBhelper();

            // genera la data table
            DataTable tabla = new DataTable();
            tabla = oDB.consultarDB(consultaSQL);

            // verifica la data table se genero sin datos
            if (tabla.Rows.Count == 0)
                // retorna 0 si la data table esta vacia
                return 0;
            else
                // retorna la id del usuario que esta en la primera columna de la BD
                return (int)tabla.Rows[0][0];
        }

        public DataTable RecuperarTodo()
        {
            DataTable tabla = new DataTable();
            string consultaSQL = "SELECT * FROM Usuarios WHERE borrado=0";
            DBhelper oDB = new DBhelper();
            tabla = oDB.consultarDB(consultaSQL);

            return tabla;
        }

    }
}
