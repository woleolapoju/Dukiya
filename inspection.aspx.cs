using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;

public partial class inspection : System.Web.UI.Page
{
public int eAutoID;
    public string eRefno;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

     
            if (Session["ImagePath"].ToString() == "")
            {
                start_camera.Disabled = true;
                HttpContext.Current.Response.Write("<script language=javascript>alert('Image Path not set....photo cannot be taken!');</script>");
            }

            if (FetchUserAccess(Session["UserID"].ToString(), "Inspections", Session["Cnn"].ToString()) == false)
                ClientScript.RegisterStartupScript(this.GetType(), "goBack", "history.go(-1);", true);

            if (Session["UserID"].ToString() == null || Session["UserID"].ToString() == "") Response.Redirect("Default.aspx", true);

            if (Session["ComplaintRefno"].ToString() == null || Session["ComplaintRefno"].ToString() == "")  divComplaintRef.Visible = false;

            if (! IsPostBack)  FetchPropertyGroup();

      
            inspectionteam.Value= Session["username"].ToString();

            complaint_Ref.InnerHtml = Session["ComplaintRefno"].ToString();
            //  InspectionClient_name.Value = Session["ClientInfo"].ToString();
            if  (Session["ComplaintScope"].ToString() == "My Compound")
                  RadioScopeList.SelectedValue = "In Compound";
            else
                RadioScopeList.SelectedValue=Session["ComplaintScope"].ToString();
            
            UnitDecription.Attributes.Add("readonly", "");

            //datepicker.Value = DateTime.Now.ToString("dd/MM/yyyy");

            //if (complaint_Ref.InnerHtml != "")
            //{
            //    InspectionClient_name.Attributes.Add("readonly", "");
            //    InpectionProperty_name.Attributes.Add("readonly", "");
            //}
            //else
            //{
            //    InspectionClient_name.Attributes.Remove("readonly");
            //    InpectionProperty_name.Attributes.Remove("readonly");
            //}


        }
        catch (Exception ex)
        {

            // HttpContext.Current.Response.Write("<script language=javascript>alert('" + ex.Message + "');</script>");
            Session["exception"] = ex.Message;
            //"Object reference" not set to an instance of an object"
            if (ex.Message.StartsWith("Object reference") == true || ex.Message.StartsWith("Thread was being aborted") == true)
                Response.Redirect("Default.aspx");
            else
                Response.Redirect("Error.aspx");
        }
    }


    private void FetchPropertyGroup()
    {
        try
        {
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            string dp;
            PropertyGroup.Items.Clear();
            dboContracts.Items.Clear();
            UnitDecription.Items.Clear();

            if (Session["ProductInfo"].ToString()!="")
                cmSQL.CommandText = "SELECT DISTINCT ProductGroup FROM dTransaction where Active=1 AND ProductGroup='" + GetIt4Me(Session["ProductInfo"].ToString(), " - ") + "' order by ProductGroup ASC";
            else
                cmSQL.CommandText = "SELECT DISTINCT ProductGroup FROM dTransaction where Active=1 order by ProductGroup ASC";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            while (drSQL.Read() == true)
            {
                dp = drSQL["ProductGroup"].ToString();
                PropertyGroup.Items.Add(drSQL["ProductGroup"].ToString()); // (new ListItem(dp, id.ToString()));

            }
            cmSQL.Connection.Close();
            cmSQL.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();


    
               FetchContractsInPropertyGroup(PropertyGroup.Text);

        }
        catch (Exception ex)
        {
            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
        }
    }

    protected void PropertyGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
      //  FetchContractsInPropertyGroup(PropertyGroup.Text);
    }

    protected void PropertyGroup_TextChanged(object sender, EventArgs e)
    {
        FetchContractsInPropertyGroup(PropertyGroup.Text);
    }

    private void FetchContractsInPropertyGroup(string dPropertyGroup)
    {
        try
        {

            dboContracts.Items.Clear();
            UnitDecription.Items.Clear();
            if (dPropertyGroup == "")  return;

            if (Session["ComplaintRefno"].ToString() == null || Session["ComplaintRefno"].ToString() == "") dboContracts.Items.Add("");

            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            string dp;
            if (Session["ContractRefNo"].ToString() != "")
                cmSQL.CommandText = "SELECT * FROM dTransaction where Active=1 AND RefNo='" + Session["ContractRefNo"].ToString() + "' ORDER BY RefNo ASC";
            else
                cmSQL.CommandText = "SELECT * FROM dTransaction where Active=1 AND ProductGroup='" + dPropertyGroup + "' ORDER BY RefNo ASC";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            while (drSQL.Read() == true)
            {
                dp = drSQL["RefNo"].ToString() + " - (" + drSQL["ClientRefNo"].ToString() + " - " + drSQL["ClientName"].ToString() + ")";
                dboContracts.Items.Add(dp); 

            }
            cmSQL.Connection.Close();
            cmSQL.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();


        


            FetchUnitOfPropertyGroup(GetIt4Me(dboContracts.Text, " - "));

        }
        catch (Exception ex)
        {
            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
        }
    }


    protected void dboContracts_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void dboContracts_TextChanged(object sender, EventArgs e)
    {
        UnitDecription.Items.Clear();
        FetchUnitOfPropertyGroup(GetIt4Me(dboContracts.Text, " - "));
    }

    private void FetchUnitOfPropertyGroup(string dRefNo )
    {
        try
        {

    
            if (dRefNo == "") return;
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;

            UnitDecription.Items.Clear();

            cmSQL.CommandText = "SELECT * FROM dTransaction where Active=1 AND RefNo='" + dRefNo + "'  ORDER BY RefNo ASC";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            while (drSQL.Read() == true)
            {
                UnitDecription.Items.Add(drSQL["UnitDescription"].ToString());
            }
            cmSQL.Connection.Close();
            cmSQL.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();

        }
        catch (Exception ex)
        {
            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
        }
    }



    public static string GetIt4Me(string TheStr, string LocStr)
    {
        string tempGetIt4Me = null;
        try
        {
            tempGetIt4Me = "";
            if (string.IsNullOrEmpty(TheStr) || string.IsNullOrEmpty(LocStr))
            {
                return tempGetIt4Me;
            }
            tempGetIt4Me = TheStr;
            int TheLen = TheStr.IndexOf(LocStr) + 1; //InStr(Trim(TheStr), LocStr) -----REMOVING TRIM
            if (TheLen != 0) // Trim(Mid$(Trim(TheStr), 1, TheLen - 1))
            {
                tempGetIt4Me = TheStr.Substring(0, TheLen - 1);
            }
            return tempGetIt4Me;
        }
        catch
        {
            return "";
        }
    }

    public static string Mid(string param, int startIndex, int length)
    {
        string result;
        if (length == -1)
        {
            result = param.Substring(startIndex);
        }
        else
        {
            result = param.Substring(startIndex, length);
        }
        return result;
    }

    public static string Left(string param, int length)
    {
        string result = param.Substring(0, length);
        return result;
    }
    public static string Right(string param, int length)
    {
        string result = param.Substring(param.Length - length, length);
        return result;
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        FetchNextNo();

        try
        {
            string dContract = "";
            string dClientRef = "";
            string dClientName = "";
            if (dboContracts.Text != "")
            {
                dContract = GetIt4Me(dboContracts.Text, " - ");
                dClientRef = GetIt4Me(Mid(dboContracts.Text, dContract.Length+3,-1), " - ");
                dClientRef = Right(dClientRef, dClientRef.Length - 1);
                dClientName = GetIt4Me(Mid(dboContracts.Text, dContract.Length + 3 + dClientRef.Length+3, -1), " - ");
                dClientName = Left(dClientName, dClientName.Length - 1);
        
            }
            else
            {
                RadioScopeList.SelectedValue = "Entire Estate";
            }

          

            string refno = "";
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
       
            cnSQL.Open();
            cmSQL.CommandText = "dInsertInspection";
            cmSQL.CommandType = System.Data.CommandType.StoredProcedure;
            cmSQL.Parameters.AddWithValue("@RefNo", eRefno);
            cmSQL.Parameters.AddWithValue("@ComplaintRef", complaint_Ref.InnerText);
            cmSQL.Parameters.AddWithValue("@ContractRef", dContract);
            cmSQL.Parameters.AddWithValue("@ClientRefNo", dClientRef);
            cmSQL.Parameters.AddWithValue("@ClientName", dClientName);
            cmSQL.Parameters.AddWithValue("@ProductGroup", PropertyGroup.Text);
            cmSQL.Parameters.AddWithValue("@UnitDescription", UnitDecription.Text);
            cmSQL.Parameters.AddWithValue("@InspectionDetails", tDetails.Value);
            cmSQL.Parameters.AddWithValue("@InspectionScope", RadioScopeList.SelectedValue);
            cmSQL.Parameters.AddWithValue("@Username", Session["username"].ToString());
            cmSQL.Parameters.AddWithValue("@AutoID", eAutoID);
            cmSQL.Parameters.AddWithValue("@TransDate", DateTime.Now.ToString());
            cmSQL.Parameters.AddWithValue("@InitialActionTaken", tAction.Value);
            cmSQL.Parameters.AddWithValue("@AttentionLevel", ActionLevel.SelectedValue);
            cmSQL.Parameters.AddWithValue("@inspectionteam", inspectionteam.Value);
            cmSQL.Parameters.AddWithValue("@ClientUpdate", tClientUpdate.Value);

            cmSQL.ExecuteNonQuery();

            cmSQL.Dispose();
            cnSQL.Close();

        
            if (dImgPath.Value != "") UploadImage(refno);
          

            tDetails.Value = "";
            dImgPath.Value = "";
            RadioScopeList.SelectedIndex = 0;

            //  HttpContext.Current.Response.Write("<script language=javascript>alert('Saved!!!!');</script>");
            //Response.Redirect("complaintlistforinspection.aspx", true);


        }
        catch (Exception ex)
        {

        //    HttpContext.Current.Response.Write("<script language=javascript>alert('" + ex.Message + "');</script>");
            //Response.Redirect("Error.aspx");
            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
        }
    }


    private void FetchNextNo()
    {
        try
        {
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            cmSQL.CommandText = "SELECT ISNULL(MAX(AutoID),0)+1 AS NewAutoID FROM dInspection";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();

            string str3 = null;

            str3 = "";

            if (drSQL.HasRows)
            {
                if (drSQL.Read())
                {
                    if (drSQL["NewAutoID"].ToString().Length > 3)
                    {
                        str3 = drSQL["NewCode"].ToString();
                    }
                    else
                    {
                        str3 = new string('0', 3 - ((string)(Convert.ToInt64(drSQL["NewAutoID"]).ToString())).Length) + Convert.ToInt64(drSQL["NewAutoID"]).ToString();
                    }
                }
            }
            else
            {
                str3 = "001";
            }



            eRefno = "INS_" + str3;
            eAutoID = Convert.ToInt16(str3);

            cmSQL.Connection.Close();
            cmSQL.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();

        }
        catch (Exception ex)
        {
            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
        }
    }


    protected void UploadImage(string refno)
    {

        try
        {

            //string filePath = HttpContext.Current.Server.MapPath("images\\edoc\\MyPicture.png");
            //  G:\\PleskVhosts\\mhschoolmate.com\\httpdocs\\App_Data\\
            string filePath = Session["ImagePath"] + eRefno + ".png";
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(dImgPath.Value);
                    bw.Write(data);
                    bw.Close();
                }

            }
        }
        catch (Exception ex)
        {
            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
        }

    }

    private static bool FetchUserAccess(string duserid, string dmodule, string dCnstr)
    {
        try
        {

            bool tempFetchUserAccess = false;

            SqlConnection cnSQL1 = new SqlConnection(dCnstr);
            SqlCommand cmSQL1 = cnSQL1.CreateCommand();
            SqlDataReader drSQL1 = null;
            cmSQL1.CommandText = "SELECT dUserAccess.UserID, UserName,AllowModule FROM dUserAccess INNER JOIN dUserAccessModule ON dUserAccess.UserID = dUserAccessModule.UserID WHERE Suspend=0 AND dUserAccess.UserID='" + duserid + "' AND AllowModule='" + dmodule + "'";
            cmSQL1.CommandType = System.Data.CommandType.Text;
            cnSQL1.Open();
            drSQL1 = cmSQL1.ExecuteReader();

            if (drSQL1.HasRows)
            {
                if (drSQL1.Read())
                    tempFetchUserAccess = true;
            }


            cmSQL1.Connection.Close();
            cmSQL1.Dispose();
            cnSQL1.Close();
            cnSQL1.Dispose();

            return tempFetchUserAccess;

        }
        catch (Exception ex)
        {

            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
            return false;
        }
    }

}