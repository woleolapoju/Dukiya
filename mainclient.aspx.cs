using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class MainClient : System.Web.UI.Page
{

    public static string dClientname = "";
    public static string dClientRef = "";
    public static string dUnitDesc = "";
    public static string dProductGroup = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        Session["ProductGroup"] = "";
        Session["UnitDescription"] = "";

        try {

            if (Session["UserID"].ToString() == null || Session["UserID"].ToString() == "")
            {
                Response.Redirect("Default.aspx", true);
            }

            lblusername.InnerText = Session["UserName"].ToString();

           
            GetClientDetails(Session["ContractRefNo"].ToString(), Session["Cnn"].ToString());



            Session["ClientRef"] =  dClientRef;
            Session["ClientName"] = dClientname;

            Session["ProductGroup"] = dProductGroup;
            Session["UnitDescription"] = dUnitDesc;

       

            lblclientname.InnerText = dClientRef + " - " + dClientname;
            lblproperty.InnerText = dProductGroup + " - " + dUnitDesc;

        }
        catch (Exception ex)
        {
            Session["exception"] = ex.Message;
            //"Object reference" not set to an instance of an object"
            if (ex.Message.StartsWith("Object reference") == true || ex.Message.StartsWith("Thread was being aborted") == true)
                Response.Redirect("Default.aspx");
            else
                Response.Redirect("Error.aspx");
        }
    }


    private static void GetClientDetails(string contractRef, string dCnStr)
    {
        {
           
            try
            {
                
              
                if (contractRef == null || dCnStr == null)
                {

                    //Response.Write("<script language=javascript>alert('Login details not entered!');</script>");
              

                    dClientname = "";
                    dProductGroup = "";
                    dClientRef = "";
                    dUnitDesc = "";


                    return;

                }


                SqlConnection cnSQL = new SqlConnection(dCnStr);
                SqlCommand cmSQL = cnSQL.CreateCommand();
                SqlDataReader drSQL = null;

                cnSQL.Open();
                cmSQL.CommandText = "SELECT * FROM dTransaction WHERE RefNo='" + contractRef + "' And Active=1";
                cmSQL.CommandType = System.Data.CommandType.Text;
                drSQL = cmSQL.ExecuteReader();

                if (drSQL.HasRows == false)
                {
                    dClientname = "";
                    dProductGroup = "";
                    dClientRef = "";
                    dUnitDesc = "";
                }
                else
                {
                    if (drSQL.Read())
                    {
                        dClientRef = drSQL["ClientRefNo"].ToString();
                        dClientname = drSQL["ClientName"].ToString();
                        dProductGroup =drSQL["ProductGroup"].ToString();
                        dUnitDesc = drSQL["UnitDescription"].ToString();

                    }
                }
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();

            }

            catch (Exception ex)
            {

                //Session["exception"] = ex.Message;
                //Response.Redirect("Error.aspx");

                //HttpContext.Session["exception"] = ex.Message;
                HttpContext.Current.Response.Write("<script language=javascript>alert('" + ex.Message + "');</script>");
                //Response.Redirect("Error.aspx");



            }
        }
    }



}