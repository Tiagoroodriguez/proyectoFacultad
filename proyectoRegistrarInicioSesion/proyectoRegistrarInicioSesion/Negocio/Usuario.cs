using proyectoRegistrarInicioSesion.Datos;
using System;
using System.Collections.Generic;
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
        public Usuario()
        {
            nombre = password = string.Empty;

        }
        public Usuario(string nombre, string password)
        {
            this.nombre = nombre;
            this.password = password;
        }
        
        public bool validar()
        {
            string consultaSQL = "Select * from Usuarios where usuario='" + this.Nombre + "' AND password='" + this.Password+"'";
            DBhelper oDB = new DBhelper();
            if (oDB.consultarDB(consultaSQL).Rows.Count == 0)
                return false;
            else
                return true;
        }
    }
}
