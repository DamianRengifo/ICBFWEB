using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICBFWEB2.modelo
{
    public class TipoSangreDao
    {
        ORMDataContext bd = new ORMDataContext(@"Data Source=CHECHOPC\SQLEXPRESS;Initial Catalog=ICBF;Integrated Security=True");
        public Object consultarTodos()
        {
            return (from j in bd.tipo_sangre select j).ToList();
        }
    }
}