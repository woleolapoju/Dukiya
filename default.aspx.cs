using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    public static string dUserName = "";
    public static string dCategory = "";
    public static string dContractRefNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        Session["UserName"] = "";
        Session["UserID"] = "";
        Session["Pwd"] = "";
        Session["Category"] = "";
        Session["Cnn"] = "";
        Session["exception"] = "";
        Session["ContractRefNo"] = "";
        Session["ComplaintRefno"] = "";
        Session["Owner"] = "";
        Session["Cnn"] = ConfigurationManager.ConnectionStrings["CnStr"].ConnectionString;

        getSettings(Session["Cnn"].ToString());

       

    }

    private void getSettings(string dCnStr)
    {
        try
        {

            Session["ImagePath"] = "";
            Session["ImagePath4Display"] = "";
             Session["TimeDiff"] = "0";
            Session["Owner"] = "StackLogic Systems";

            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
     
            cnSQL.Open();
            cmSQL.CommandText = "SELECT * FROM dSettings";
            cmSQL.CommandType = System.Data.CommandType.Text;

            drSQL = cmSQL.ExecuteReader();

            if (drSQL.HasRows == false)
            {
                Session["ImagePath"] ="";
                Session["ImagePath4Display"] = "";
               //Session["Owner"] = "";

            }
            else
            {
                if (drSQL.Read())
                {
                    Session["ImagePath"] = drSQL["ImagePath"].ToString();
                    Session["ImagePath4Display"] = drSQL["ImagePath4Display"].ToString();
                    Session["TimeDiff"] = drSQL["TimeDiff"].ToString();
                    Session["Owner"] = drSQL["Owner"].ToString();
                }
            }
            cmSQL.Dispose();
            drSQL.Close();
            cnSQL.Close();

      
        }

        catch (Exception ex)
        {
           // HttpContext.Current.Response.Write("<script language=javascript>alert('Image Path not set....please set!');</script>");

            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");

        }
    }

    private static Boolean AuthenticateUser(string dUserID, string dPwd, string dCnStr)
    {
        {
            Boolean tempAuthenticateUser = false;

            try
            {


                //if (!IsPostBack)
                //{
                //Session["Username"] = Request.Form["uname"];
                //Session["Password"] = Request.Form["psw"];

                if (dUserID == null || dPwd == null)
                {

                    //Response.Write("<script language=javascript>alert('Login details not entered!');</script>");


                }



                SqlConnection cnSQL = new SqlConnection(dCnStr);
                SqlCommand cmSQL = new SqlCommand("dFetchUserAccessByPwd", cnSQL);
                SqlDataReader drSQL;

                int i = 0;
                cnSQL.Open();
                cmSQL.CommandText = "dFetchUserAccessByPwd";
                cmSQL.CommandType = System.Data.CommandType.StoredProcedure;
                cmSQL.Parameters.AddWithValue("@UserID", dUserID);
                cmSQL.Parameters.AddWithValue("@UserPwd", dPwd);

                drSQL = cmSQL.ExecuteReader();

                if (drSQL.HasRows == false)
                {
                    i = 1;
                }
                else
                {
                    if (drSQL.Read())
                    {
                        dUserName = drSQL["Username"].ToString();
                        dCategory = drSQL["Category"].ToString();
                        dContractRefNo = drSQL["ContractRefNo"].ToString();
                        i = 10;
                    }
                }
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();



                if (i == 1)
                {
                    tempAuthenticateUser = false;
                }

                if (i == 10)
                {
                    tempAuthenticateUser = true;
                }

                return tempAuthenticateUser;

            }

            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script language=javascript>alert('" + ex.Message +"');</script>");

       
                HttpContext.Current.Session["exception"] = ex.Message;
                HttpContext.Current.Response.Redirect("Error.aspx");

                return false;

            }
        }
    }


          protected void btnLogin_Click(object sender, EventArgs e)
    {

        if (AuthenticateUser(userID.Value, userPwd.Value, Session["Cnn"].ToString()) == true)
        {
            Session["UserName"] = dUserName;
            Session["UserID"] = userID.Value; 
            Session["Pwd"] = userPwd.Value;
            Session["Category"] = dCategory;
            Session["ContractRefNo"] = dContractRefNo;

          //  Response.Write("<script language=javascript>alert('Welcome!');</script>");

            if (dCategory == "Staff")
            {
                //Response.Redirect("MainStaff.aspx", true);
                Response.Redirect("Dashboard.aspx", true);
            }
            else
            {
                Response.Redirect("MainClient.aspx", true);
            }
        }
        else
        {
            Session["UserName"] = "";
            Session["UserID"] = "";
            Session["Pwd"] = "";
            Session["Category"] = "";
            Session["ContractRefNo"] = "";
            //HttpContext.Current.Response.Write("<script language=javascript>alert('Invalid User Login Information!');</script>");
   
        }

    }





    
}
