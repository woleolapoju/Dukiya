using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;

public partial class joblog : System.Web.UI.Page
{
    public int eAutoID;
    public string eRefno;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["UserID"].ToString() == null || Session["UserID"].ToString() == "") Response.Redirect("Default.aspx", true);


            if (FetchUserAccess(Session["UserID"].ToString(), "Activity Log", Session["Cnn"].ToString()) == false)
                ClientScript.RegisterStartupScript(this.GetType(), "goBack", "history.go(-1);", true);


            if (Session["WorkorderRefno"].ToString() == null || Session["WorkorderRefno"].ToString() == "") Response.Redirect("workorderlistings.aspx", true);


            if (Session["ImagePath"].ToString() == "")
            {
                start_camera.Disabled = true;
                HttpContext.Current.Response.Write("<script language=javascript>alert('Image Path not set....photo cannot be taken!');</script>");
            }


          workorder_ref.Value = Session["WorkorderRefno"].ToString();
            Contract_Details.Value= Session["Contract_Details"].ToString() ;
            dProperty.Value= Session["ProductInfo"].ToString();
            RadioScopeList.SelectedValue =  Session["workscope"].ToString();


            string dd = GetIt4Me(dProperty.Value, " - (");
          //  HttpContext.Current.Response.Write("<script language=javascript>alert('" + dd + "');</script>");

            if (dd != "")
                dProperty.Value = GetIt4Me(dProperty.Value, " - (");
            //else
            //     dProperty.Value=dd;



            FetchCurrentMaxCompletionlevel();

            if (!IsPostBack)
            {
                BindGrid();
                DateClosed_datepicker.Value = DateTime.Now.ToString("dd-MMMM-yyyy");
              
            }


            if (Session["Contract_Details"].ToString() == null || Session["Contract_Details"].ToString() == "") divContract_Details.Visible = false;

           
        }
        catch (Exception ex)
        {

            // HttpContext.Current.Response.Write("<script language=javascript>alert('" + ex.Message + "');</script>");

            Session["exception"] = ex.Message;

            //  "Object reference" not set to an instance of an object"
            if (ex.Message.StartsWith("Object reference") == true || ex.Message.StartsWith("Thread was being aborted") == true)
                Response.Redirect("Default.aspx");
            else
                Response.Redirect("Error.aspx");
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

    protected bool CheckDate(String date)

    {
        try
        {
            DateTime dt = DateTime.Parse(date);
            return true;
        }
        catch
        {
            return false;
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




        try
        {
            string dContract = "";
            string dClientRef = "";
            string dClientName = "";
            string dp = "";
            string dpunit = "";
            if (Contract_Details.Value != "")
            {
                //string dd = GetIt4Me(Contract_Details.Value, " - (");

                //HttpContext.Current.Response.Write("<script language=javascript>alert('" + dd + "');</script>");

                //if (GetIt4Me(Contract_Details.Value, " - (") != "")
                //    {
                    dContract = GetIt4Me(Contract_Details.Value, " - ");
                    dClientRef = GetIt4Me(Mid(Contract_Details.Value, dContract.Length + 3, -1), " - ");
                    dClientRef = Right(dClientRef, dClientRef.Length - 1);
                    dClientName = GetIt4Me(Mid(Contract_Details.Value, dContract.Length + 3 + dClientRef.Length + 3, -1), " - ");
                    dClientName = Left(dClientName, dClientName.Length - 1);
                //}

            }
            else
            {
                RadioScopeList.SelectedValue = "Entire Estate";
            }

            if (dProperty.Value != "")
            {
                int dd = dProperty.Value.IndexOf( " - ");



                if (dd > 0)
                {
                    dp = GetIt4Me(dProperty.Value, " - ");
                    dpunit = Mid(dProperty.Value, dp.Length + 3, -1);
                }
                else
                    dp = dProperty.Value;


            }

            FetchNextNo();


            string refno = "";
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            cnSQL.Open();

            //SqlTransaction myTrans;
            //myTrans = cnSQL.BeginTransaction();
            //cmSQL.Transaction = myTrans;

            if (tDetails.Value=="")
            {
                HttpContext.Current.Response.Write("<script language=javascript>alert('Incomplete record!!!!!');</script>");
                return;
            }
            cmSQL.CommandText = "dInsertJoblog";
            cmSQL.CommandType = System.Data.CommandType.StoredProcedure;
            cmSQL.Parameters.AddWithValue("@RefNo", eRefno);
            cmSQL.Parameters.AddWithValue("@WorkorderRefNo", workorder_ref.Value);
            cmSQL.Parameters.AddWithValue("@ContractRef", dContract);
            cmSQL.Parameters.AddWithValue("@ClientRefNo", dClientRef);
            cmSQL.Parameters.AddWithValue("@ClientName", dClientName);
            cmSQL.Parameters.AddWithValue("@ProductGroup",dp);
            cmSQL.Parameters.AddWithValue("@UnitDescription",dpunit);
            cmSQL.Parameters.AddWithValue("@JobDetails", tDetails.Value);
            cmSQL.Parameters.AddWithValue("@JobScope", RadioScopeList.SelectedValue);
            cmSQL.Parameters.AddWithValue("@Username", Session["username"].ToString());
            cmSQL.Parameters.AddWithValue("@AutoID", eAutoID);
            cmSQL.Parameters.AddWithValue("@TransDate", clientdate.Value); // DateTime.Now.ToString());
            cmSQL.Parameters.AddWithValue("@DateCompleted", Convert.ToDateTime(DateClosed_datepicker.Value));
            cmSQL.Parameters.AddWithValue("@CompletionLevel",Convert.ToInt16(hiddenRangeMonitor.Value));
            cmSQL.Parameters.AddWithValue("@AttentionLevel", ActionLevel.SelectedValue);
            cmSQL.Parameters.AddWithValue("@RepairBy", JobTeam.Value);
            cmSQL.Parameters.AddWithValue("@CostOfJob", costofjob.Value);
            cmSQL.Parameters.AddWithValue("@CostOfSupply", costofsupply.Value);
            cmSQL.Parameters.AddWithValue("@ClientUpdate", tClientUpdate.Value);
            cmSQL.ExecuteNonQuery();

            //myTrans.Commit();

            cmSQL.Dispose();
            cnSQL.Close();



            if (dImgPath.Value != "") UploadImage(refno);

            JobTeam.Value = "";
            tDetails.Value = "";
            dImgPath.Value = "";
            costofjob.Value = "0";
            costofsupply.Value = "0";
            RadioScopeList.SelectedIndex = 0;
            tClientUpdate.Value = "";

            //  HttpContext.Current.Response.Write("<script language=javascript>alert('Saved!!!!');</script>");
            //Response.Redirect("complaintlistforworkorder.aspx", true);


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
            cmSQL.CommandText = "SELECT ISNULL(MAX(AutoID),0)+1 AS NewAutoID FROM dJoblog";
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



            eRefno = "JOB_" + str3;
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


    private void FetchCurrentMaxCompletionlevel()
    {
        try
        {
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            ////cmSQL.CommandText = "SELECT TOP 1 ISNULL(MAX(CompletionLevel),0) AS CompletionLevel,MAX(TransDate) AS TransDate FROM dJoblog WHERE WorkorderRefNo='" + workorder_ref.Value + "' ORDER BY TransDate DESC";
           //  cmSQL.CommandText = "SELECT TOP 1 ISNULL(CompletionLevel,0) AS CompletionLevel FROM dJoblog WHERE WorkorderRefNo='" + Session["WorkorderRefno"].ToString() + "' ORDER BY TransDate DESC";
            cmSQL.CommandText = "SELECT TOP 1 ISNULL(CompletionLevel,0) AS CompletionLevel FROM WorkorderCompletionLevel WHERE RefNo='" + Session["WorkorderRefno"].ToString() + "'";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();

            hiddenCurrentLevel.Value = "50";


            if (drSQL.HasRows)
            {
                if (drSQL.Read())
                        hiddenCurrentLevel.Value = drSQL["CompletionLevel"].ToString();
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


    private void BindGrid()
    {


        System.Data.DataTable dt = new System.Data.DataTable();
        string query = "SELECT LabourDescr, HoursRequired ,AmountRequired FROM dWorkorderDetails where RefNo='" + Session["WorkorderRefno"].ToString() + "'";
        string constr = Session["Cnn"].ToString();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
        }

        if (dt.Rows.Count == 0)
        {
            //If no records then add a dummy row.
            dt.Rows.Add();

        }

        gvCustomers.DataSource = dt;
        gvCustomers.DataBind();

        //gvCustomers.Columns[1].ItemStyle.Width = 50;
        //gvCustomers.Columns[1].ItemStyle.Wrap = true;
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