using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class MainStaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            Session["ComplaintRefno"] = "";
            Session["WorkorderRefno"] = "";
            Session["Contract_Details"] = "";
            Session["ProductInfo"] = "";
            Session["workscope"] = "";
            Session["dAction"] = "New";
            if (Session["UserID"].ToString() == null || Session["UserID"].ToString() == "")
            {
                Response.Redirect("Default.aspx", true);
            }

            lblusername.InnerText = Session["UserName"].ToString();

        }
        catch (Exception ex)
        {
            Session["exception"] = ex.Message;
            //"Object reference" not set to an instance of an object"
            if ( ex.Message.StartsWith("Thread was being aborted") == true) //(ex.Message.StartsWith("Object reference") == true ||
                Response.Redirect("Default.aspx");
            else
                Response.Redirect("Error.aspx");
        }

    }



}