using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Datos.Interfaces
{
    interface IUsuario
    {
        int validarUsuario(string nombre, string clave);
        DataTable RecuperarTodos();
        DataTable RecuperarPorId(int idUsuario);
    }
}
