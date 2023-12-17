using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICBFWEB2.modelo
{
    public class CiudadDAO
    {
        ORMDataContext bd = new ORMDataContext(@"Data Source=DESKTOP-DVTF0L7\SQLEXPRESS;Initial Catalog=ICBF;Integrated Security=True");
        public Object consultarTodos()
        {
            return (from j in bd.ciudad_nacimiento select j).ToList();
        }

        public int consultarId(String nomCiudad) {
            int resultado = (from j in bd.ciudad_nacimiento where j.nomCiudad == nomCiudad select j.idCiudad).FirstOrDefault();
            return resultado;
        }
    }
}