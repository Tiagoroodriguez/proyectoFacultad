using AppBTS.Datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Datos.Daos
{
    class PerfilDao : IPerfil
    {
        public DataTable RecuperarTodos()
        {
            string consulta = "SELECT * FROM Perfiles WHERE borrado = 0 order by 2";
            return BDHelper.obtenerInstancia().consultar(consulta);
        }
    }
}
