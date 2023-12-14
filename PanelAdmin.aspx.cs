using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICBFWEB2
{
    public partial class PanelAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] != null && Session["fk_idRol"].Equals(3))
            {
                if (!IsPostBack)
                {
                    lblUser.Text = Session["nombre"].ToString();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnIrAJardines_Click(object sender, EventArgs e)
        {
            Response.Redirect("Jardines.aspx");
        }
    }
}