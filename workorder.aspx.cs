using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;

public partial class workorder : System.Web.UI.Page
{
    public int eAutoID;
    public string eRefno;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["UserID"].ToString() == null || Session["UserID"].ToString() == "") Response.Redirect("Default.aspx", true);

            if (!IsPostBack)
            {
                FetchPropertyGroup();
                BindGrid();

                //start_datepicker.Value = DateTime.Now.ToString("dd-MMMM-yyyy");
                //end_datepicker.Value = DateTime.Now.ToString("dd-MMMM-yyyy");
            }
          
            if (Session["ImagePath"].ToString() == "")
            {
                start_camera.Disabled = true;
                HttpContext.Current.Response.Write("<script language=javascript>alert('Image Path not set....photo cannot be taken!');</script>");
            }

            if (Session["dAction"].ToString() == "Edit")
            {
                if (!IsPostBack)
                {
                    daction.Value = Session["dAction"].ToString();
                    oloadworkorder();
                }
            }
            else
            {
                supervisionteam.Value = Session["username"].ToString();

                complaint_Ref.InnerHtml = Session["ComplaintRefno"].ToString();
                //  InspectionClient_name.Value = Session["ClientInfo"].ToString();
                RadioScopeList.SelectedValue = Session["ComplaintScope"].ToString();

                UnitDecription.Attributes.Add("readonly", "");


                if (Session["ComplaintRefno"].ToString() == null || Session["ComplaintRefno"].ToString() == "")

                {
                    divComplaintRef.Visible = false;
                    if (Session["dsource"].ToString() == "Complaint")
                        complaintlabel.InnerText = "COMPLAINT REFNO:";
                    else
                        complaintlabel.InnerText = "INSPECTION REFNO:";
                }
                else
                {
                    if (Session["ContractRefNo"].ToString() == "")
                    {
                        UnitDecription.Items.Clear();
                        dboContracts.Items.Clear();
                    }
                }
            }

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

            if (Session["ProductInfo"].ToString() != "")
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

    private void FetchContractsInPropertyGroup(string dPropertyGroup )
    {
        try
        {

            dboContracts.Items.Clear();
            UnitDecription.Items.Clear();
            if (dPropertyGroup == "") return;

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
            if (dboContracts.Text != "")
            {
                dContract = GetIt4Me(dboContracts.Text, " - ");
                dClientRef = GetIt4Me(Mid(dboContracts.Text, dContract.Length + 3, -1), " - ");
                dClientRef = Right(dClientRef, dClientRef.Length - 1);
                dClientName = GetIt4Me(Mid(dboContracts.Text, dContract.Length + 3 + dClientRef.Length + 3, -1), " - ");
                dClientName = Left(dClientName, dClientName.Length - 1);

            }
            else
            {
                RadioScopeList.SelectedValue = "Entire Estate";
            }

      
        //if (start_datepicker.Value !="" && end_datepicker.Value !="")
        //      {
        //    if (CheckDate(start_datepicker.Value.ToString()) && CheckDate(end_datepicker.Value.ToString()))
        //        {
        //        if ((Convert.ToDateTime(end_datepicker.Value) - Convert.ToDateTime(start_datepicker.Value)).TotalDays < 0)
        //            {
        //            HttpContext.Current.Response.Write("<script language=javascript>alert('Start date should not be greater than End date');</script>");
        //            return;
        //        }
        //    }
        //}


        if (Session["dAction"].ToString() != "Edit")
                FetchNextNo();

    


        string refno = "";
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            cnSQL.Open();

            SqlTransaction myTrans;
            myTrans = cnSQL.BeginTransaction();
            cmSQL.Transaction = myTrans;

            if (daction.Value == "Edit")
            {


                cmSQL.CommandText = "dUpdateWorkorder";
                cmSQL.CommandType = System.Data.CommandType.StoredProcedure;
                cmSQL.Parameters.AddWithValue("@RefNo", workorder_ref.Value);
                cmSQL.Parameters.AddWithValue("@ContractRef", dContract);
                cmSQL.Parameters.AddWithValue("@ClientRefNo", dClientRef);
                cmSQL.Parameters.AddWithValue("@ClientName", dClientName);
                cmSQL.Parameters.AddWithValue("@ProductGroup", PropertyGroup.Text);
                cmSQL.Parameters.AddWithValue("@UnitDescription", UnitDecription.Text);
                cmSQL.Parameters.AddWithValue("@WorkDetails", tDetails.Value);
                cmSQL.Parameters.AddWithValue("@WorkScope", RadioScopeList.SelectedValue);
                cmSQL.Parameters.AddWithValue("@ModifiedBy", Session["username"].ToString());
                cmSQL.Parameters.AddWithValue("@ModifiedDate", clientdate.Value); // DateTime.Now.ToString());
                cmSQL.Parameters.AddWithValue("@ExpectedStartDate", Convert.ToDateTime(start_datepicker.Value));
                cmSQL.Parameters.AddWithValue("@ExpectedEndDate", Convert.ToDateTime(end_datepicker.Value));
                cmSQL.Parameters.AddWithValue("@TermOfService", txtserviceterm.Value);
                cmSQL.Parameters.AddWithValue("@AttentionLevel", ActionLevel.SelectedValue);
                cmSQL.Parameters.AddWithValue("@supervisionteam", supervisionteam.Value);
                cmSQL.ExecuteNonQuery();

                cmSQL.CommandText = "DELETE FROM dWorkorderDetails WHERE RefNo='" + workorder_ref.Value + "'";
                cmSQL.CommandType = System.Data.CommandType.Text;
                cmSQL.ExecuteNonQuery();

                eRefno = workorder_ref.Value;
            }
            else
            {
                cmSQL.CommandText = "dInsertWorkorder";
                cmSQL.CommandType = System.Data.CommandType.StoredProcedure;
                cmSQL.Parameters.AddWithValue("@RefNo", eRefno);
                cmSQL.Parameters.AddWithValue("@ComplaintRef", complaint_Ref.InnerText);
                cmSQL.Parameters.AddWithValue("@ContractRef", dContract);
                cmSQL.Parameters.AddWithValue("@ClientRefNo", dClientRef);
                cmSQL.Parameters.AddWithValue("@ClientName", dClientName);
                cmSQL.Parameters.AddWithValue("@ProductGroup", PropertyGroup.Text);
                cmSQL.Parameters.AddWithValue("@UnitDescription", UnitDecription.Text);
                cmSQL.Parameters.AddWithValue("@WorkDetails", tDetails.Value);
                cmSQL.Parameters.AddWithValue("@WorkScope", RadioScopeList.SelectedValue);
                cmSQL.Parameters.AddWithValue("@Username", Session["username"].ToString());
                cmSQL.Parameters.AddWithValue("@AutoID", eAutoID);
                cmSQL.Parameters.AddWithValue("@TransDate", clientdate.Value); // DateTime.Now.ToString());
                cmSQL.Parameters.AddWithValue("@ExpectedStartDate", Convert.ToDateTime(start_datepicker.Value));
                cmSQL.Parameters.AddWithValue("@ExpectedEndDate", Convert.ToDateTime(end_datepicker.Value));
                cmSQL.Parameters.AddWithValue("@TermOfService", txtserviceterm.Value);
                cmSQL.Parameters.AddWithValue("@AttentionLevel", ActionLevel.SelectedValue);
                cmSQL.Parameters.AddWithValue("@supervisionteam", supervisionteam.Value);
                cmSQL.Parameters.AddWithValue("@source", Session["dsource"].ToString());
                cmSQL.ExecuteNonQuery();
            }

                string theLabourDescr = hiddenTextforGrid.Value;
                string theLabour = "";
                string theHour = "";
                string theAmt = "";
                string temptheLabourDescr = "";

                if (hiddenTextforGrid.Value != "")

                {
                    plsrepeat:

                    if (theLabourDescr != "")
                    {

                        temptheLabourDescr = GetIt4Me(theLabourDescr, " @ ");
                        if (temptheLabourDescr == "") temptheLabourDescr = theLabourDescr;

                        theLabour = GetIt4Me(temptheLabourDescr, " - ");
                        theHour = GetIt4Me(Mid(temptheLabourDescr, theLabour.Length + 3, -1), " ** ");
                        theAmt = Mid(temptheLabourDescr, theLabour.Length + 3 + theHour.Length + 4, -1);

                        cmSQL.Parameters.Clear();
                        cmSQL.CommandText = "dInsertWorkOrderDetails";
                        cmSQL.CommandType = System.Data.CommandType.StoredProcedure;
                        cmSQL.Parameters.AddWithValue("@RefNo", eRefno);
                        cmSQL.Parameters.AddWithValue("@LabourDescr", theLabour);
                        cmSQL.Parameters.AddWithValue("@HoursRequired", Convert.ToDouble(theHour));
                        cmSQL.Parameters.AddWithValue("@AmountRequired", Convert.ToDouble(theAmt));
                        cmSQL.ExecuteNonQuery();

                        if (theLabourDescr.Length > temptheLabourDescr.Length + 3)
                            theLabourDescr = Mid(theLabourDescr, temptheLabourDescr.Length + 3, -1);
                        else
                            theLabourDescr = "";

                        goto plsrepeat;

                    }
                }
           
         myTrans.Commit();

     

        cmSQL.Dispose();
         cnSQL.Close();

        if (dImgPath.Value != "") UploadImage(refno);
            hiddenTextforGrid.Value = "";
            txtserviceterm.Value = "";
            tDetails.Value = "";
            dImgPath.Value = "";
            RadioScopeList.SelectedIndex = 0;

        //  HttpContext.Current.Response.Write("<script language=javascript>alert('Saved!!!!');</script>");
        //Response.Redirect("complaintlistforworkorder.aspx", true);


    }
        catch (Exception ex)
        {

            //    HttpContext.Current.Response.Write("<script language=javascript>alert('" + ex.Message + "');</script>");
    
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
            cmSQL.CommandText = "SELECT ISNULL(MAX(AutoID),0)+1 AS NewAutoID FROM dWorkorder";
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



            eRefno = "WKO_" + str3;
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


    private void BindGrid()
    {


        //System.Data.DataTable dt = new System.Data.DataTable();
        string query = "";
        if (Session["dAction"].ToString() == "Edit")
        {
             query = "SELECT LabourDescr, HoursRequired ,AmountRequired FROM dWorkorderDetails where RefNo='" + Session["WorkorderRefno"].ToString()  + "'";
            FetchWorkorderdetails(query);
        }
        else
        {
            query = "SELECT LabourDescr, HoursRequired ,AmountRequired FROM dWorkorderDetails where RefNo='@@####!123'";
        }
        string constr = Session["Cnn"].ToString();
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    using (SqlCommand cmd = new SqlCommand(query))
        //    {
        //        cmd.Connection = con;
        //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //        {
        //            sda.SelectCommand = cmd;
        //            sda.Fill(dt);
        //        }
        //    }
        //}

        SqlDataAdapter da = new SqlDataAdapter(query, constr);
        System.Data.DataSet ds = new System.Data.DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();
        da.Fill(dt);

        if (dt.Rows.Count == 0)
        {
            //If no records then add a dummy row.
            dt.Rows.Add();

        }

        gvCustomers.DataSource = dt;
        gvCustomers.DataBind();



    }


    private void oloadworkorder()
    {
        try
        {

            divrefno.Style.Remove("display");
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            cmSQL.CommandText = "SELECT * FROM dWorkorder where Refno='" + Session["WorkorderRefno"].ToString() + "'";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();

            string dp = "";
            string contractRef = "";
            UnitDecription.Items.Clear();
            dboContracts.Items.Clear();
            PropertyGroup.Items.Clear();

            if (drSQL.HasRows)
            {
                if (drSQL.Read())
                {

                     if (drSQL["ContractRef"].ToString() != "") {
                        dp = drSQL["ContractRef"].ToString() + " - (" + drSQL["ClientRefNo"].ToString() + " - " + drSQL["ClientName"].ToString() + ")";
                        contractRef = drSQL["ContractRef"].ToString();
                        }
                    workorder_ref.Value = drSQL["RefNo"].ToString();
                  
                    complaint_Ref.InnerText= drSQL["ComplaintRef"].ToString();
                    PropertyGroup.Items.Add(drSQL["ProductGroup"].ToString());
                    PropertyGroup.Text = drSQL["ProductGroup"].ToString();
                    dboContracts.Items.Add(dp);
                    dboContracts.Items.Add("");
                    dboContracts.Text = dp;
                    UnitDecription.Items.Add(drSQL["UnitDescription"].ToString());
                    UnitDecription.Items.Add("");
                    UnitDecription.Text = drSQL["UnitDescription"].ToString();
                    tDetails.Value = drSQL["WorkDetails"].ToString();
                    RadioScopeList.SelectedValue = drSQL["WorkScope"].ToString();
                    start_datepicker.Value =Convert.ToDateTime( drSQL["ExpectedStartDate"]).ToString("dd-MMMM-yyyy");
                    end_datepicker.Value = Convert.ToDateTime(drSQL["ExpectedEndDate"]).ToString("dd-MMMM-yyyy");
                    txtserviceterm.Value=drSQL["TermOfService"].ToString();
                    ActionLevel.Text = drSQL["AttentionLevel"].ToString();
                    supervisionteam.Value = drSQL["supervisionteam"].ToString();
                    dImgPath.Value = ""; // Session["ImagePath4Display"] + drSQL["RefNo"].ToString() + ".png";
                   // dImgPath.Attributes.Add("src",  Session["ImagePath4Display"] + drSQL["RefNo"].ToString() + ".png");
                  //  btnshowphoto.Style.Remove("visibility");

                     //$("#complaintPhoto").attr("src", document.getElementById(recipient + "l").value);
                }
            }
            else
            {
                workorder_ref.Value = "";
            }


            cmSQL.Connection.Close();
            cmSQL.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();

       
           // FetchContractsInPropertyGroup(PropertyGroup.Text);
           
           ////dboContracts.Text = dp;
           //// supervisionteam.Value = dp;


           // FetchUnitOfPropertyGroup(contractRef);
           // UnitDecription.Text = Session["UnitDecription"].ToString();
        }
        catch (Exception ex)
        {
            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
        }
    }

    private void FetchWorkorderdetails(string dstrQry)
    {
        try
        {


            if (dstrQry == "") return;
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;

            hiddenTextforGrid.Value = "";
            cmSQL.CommandText = dstrQry;
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            while (drSQL.Read() == true)
            {
               
                if (hiddenTextforGrid.Value == "")
                    {

                        hiddenTextforGrid.Value = drSQL["LabourDescr"].ToString() + " - " + drSQL["HoursRequired"].ToString() + " ** " + drSQL["AmountRequired"].ToString();
                    }
                    else
                    {
                        hiddenTextforGrid.Value = hiddenTextforGrid.Value + " @ " + drSQL["LabourDescr"].ToString() + " - " + drSQL["HoursRequired"].ToString() + " ** " + drSQL["AmountRequired"].ToString();
                    }

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




}