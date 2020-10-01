using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try {

            lblError.InnerText = Session["exception"].ToString();
 }
        catch
        {

        }
    }
}