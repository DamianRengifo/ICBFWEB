using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICBFWEB2.modelo
{
    public class Nivel
    {
        ORMDataContext bd = new ORMDataContext(@"Data Source=DESKTOP-DVTF0L7\SQLEXPRESS;Initial Catalog=ICBF;Integrated Security=True");
        public Object consultarTodos()
        {
            return (from j in bd.nivel select j).ToList();
        }
    }
}