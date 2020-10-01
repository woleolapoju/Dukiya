using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Configuration;

public partial class sample7 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

                if (Session["UserID"].ToString() == null || Session["UserID"].ToString() == "")
            {
                Response.Redirect("Default.aspx", true);
            }

            //  lblusername.InnerText = Session["UserName"].ToString();


            FetchComplaintNewDetails();

            totalnotification.InnerHtml = "0";

            nL1.Visible = false;
            nL2.Visible = false;
            nL3.Visible = false;
            nL4.Visible = false;
            nL5.Visible = false;

          

            AttentionLevelStatus();
            int sc4payment = serviceCharge4Payment();
            if (sc4payment == 0)
                serviceChargeRequirePayment.InnerHtml = "0";
            else
                serviceChargeRequirePayment.InnerHtml = sc4payment.ToString("###,###.##");

            int sc4approval = serviceCharge4Approval();
           if (sc4approval==0)
                servicecharge.InnerHtml ="0";
           else
             servicecharge.InnerHtml = sc4approval.ToString("###,###.##");

            if (CriticalJobs.InnerHtml == "0")
            {
                //    CritcalDiv.Visible = false;
                Critcali.Attributes.Remove("class");
                Critcali.Attributes.Add("class", "fa fa-warning");
            }
            else
                //Critcali.Visible = true;
                Critcali.Attributes.Add("class", "fa fa-warning fa-spin");


            FetchComplaintOutstandingDetails();

            FetchWorkOrderOutstandingDetails();
            FetchComplaintStats();
            FetchComplaintStatsGraph();


            if (FetchUserAccess(Session["UserID"].ToString(), "Workorder", ConfigurationManager.ConnectionStrings["CnStr"].ConnectionString) == false)
                assignworkorder.Visible = false;
            else
            {
                assignworkorder.Visible = true;
                if (!IsPostBack)
                    loadStaff();
            }
               

        

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

    public static Int16 serviceCharge4Payment()
    {
        try
        {
            Int16 result = 0;

            string dCnStr = ConfigurationManager.ConnectionStrings["CnStr"].ConnectionString;
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            cmSQL.CommandText = "SELECT COUNT(ContractRef) AS NoAvailableForPayment FROM dServiceChargeBalances LEFT OUTER JOIN dTransaction ON dServiceChargeBalances.ContractRef = dTransaction.RefNo where (dTransaction.Active=1 AND DR <= CR)  OR (dTransaction.Active=0 AND DR < CR)";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            if (drSQL.HasRows)
            {
                if (drSQL.Read())
                    result = Convert.ToInt16(drSQL["NoAvailableForPayment"].ToString());
                else
                    result = 0;
            }

            cmSQL.Connection.Close();
            cmSQL.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();

            return result;

        }
        catch (Exception ex)
        {

            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
            return 0;
        }

    }

    public static Int16 serviceCharge4Approval()
    {
        try
        {
            Int16 result = 0;

            string dCnStr = ConfigurationManager.ConnectionStrings["CnStr"].ConnectionString;
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            cmSQL.CommandText = "SELECT isnull(COUNT(RefNo),0) AS NoAvailableForApproval FROM dServiceCharge where Authorise<>1";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            if (drSQL.HasRows)
            {
                if (drSQL.Read())
                    result = Convert.ToInt16(drSQL["NoAvailableForApproval"].ToString());
                else
                    result = 0;
            }

            cmSQL.Connection.Close();
            cmSQL.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();
            if (result < 0)
                result = 0;
            return result;

        }
        catch (Exception ex)
        {

            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
            return 0;
        }

    }


    public void AttentionLevelStatus()
    {
        try
        {
            //Int16 severe = 0;
            //Int16 critical = 0;

            string dCnStr = ConfigurationManager.ConnectionStrings["CnStr"].ConnectionString;
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            cmSQL.CommandText = "SELECT  SUM([ItsIndex]) AS NoOfCount,[AttentionLevel] FROM [AttentionLevelStatus] Group by [AttentionLevel]";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            while (drSQL.Read() == true)
            {
                if (drSQL["AttentionLevel"].ToString().ToUpper() == "SEVERE")
                    SevereJobs.InnerHtml = Convert.ToInt16(drSQL["NoOfCount"]).ToString("###,###.##");
                if (drSQL["AttentionLevel"].ToString().ToUpper() == "CRITICAL")
                    CriticalJobs.InnerHtml = Convert.ToInt16(drSQL["NoOfCount"]).ToString("###,###.##");
            }

            cmSQL.Connection.Close();
            cmSQL.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();

            //CriticalJobs.InnerHtml = critical.ToString("###,###.##");
            //SevereJobs.InnerHtml = severe.ToString("###,###.##");
            //ControlledJobs.InnerHtml = "7";



        }
        catch (Exception ex)
        {

            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");

        }

    }

    private void FetchComplaintNewDetails()
    {
        int i = 0;
        try
        {
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;

            cmSQL.CommandText = "SELECT * FROM dComplaint where (seenby='' or seenby is null) order by TransDate ASC";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();

            while (drSQL.Read() == true)
            {
                i++;
                if (i == 1)
                {
                    lbl1a.InnerHtml = drSQL["ProductGroup"].ToString() + " - " + drSQL["UnitDescription"].ToString();
                    lbl1b.InnerHtml = drSQL["TransDate"].ToString(); //.ToString("dddd, dd MMMM yyyy HH: mm:ss");
                                                                     // lbl1b.InnerHtml = DateTime.ParseExact(drSQL["TransDate"].ToString(), "dddd, dd MMMM yyyy HH: mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString();
                    aNewComplaint1.Attributes.Add("data-whatever", drSQL["RefNo"].ToString());

                }
                if (i == 2)
                {
                    lbl2a.InnerHtml = drSQL["ProductGroup"].ToString() + " - " + drSQL["UnitDescription"].ToString();
                    lbl2b.InnerHtml = drSQL["TransDate"].ToString();
                    aNewComplaint2.Attributes.Add("data-whatever", drSQL["RefNo"].ToString());
                }
                if (i == 3)
                {
                    lbl3a.InnerHtml = drSQL["ProductGroup"].ToString() + " - " + drSQL["UnitDescription"].ToString();
                    lbl3b.InnerHtml = drSQL["TransDate"].ToString();
                    aNewComplaint3.Attributes.Add("data-whatever", drSQL["RefNo"].ToString());
                }
                if (i == 4)
                {
                    lbl4a.InnerHtml = drSQL["ProductGroup"].ToString() + " - " + drSQL["UnitDescription"].ToString();
                    lbl4b.InnerHtml = drSQL["TransDate"].ToString();
                    aNewComplaint4.Attributes.Add("data-whatever", drSQL["RefNo"].ToString());
                }
            }


            TpendingComplaint1.InnerHtml = i.ToString();
            TpendingComplaint2.InnerHtml = i.ToString();
            if (i == 0)
            {
                i1.Visible = false;
                i2.Visible = false;
                i3.Visible = false;
                i4.Visible = false;
                i5.Visible = false;
            }
            if (i == 1)
            {
                i2.Visible = false;
                i3.Visible = false;
                i4.Visible = false;
                i5.Visible = false;
            }
            if (i == 2)
            {
                i3.Visible = false;
                i4.Visible = false;
                i5.Visible = false;
            }
            if (i == 3)
            {
                i4.Visible = false;
                i5.Visible = false;
            }
            if (i == 4)
            {
                i5.Visible = false;
            }
            if (i > 4)
            {

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


    private void FetchComplaintOutstandingDetails()
    {
        try
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "getclientdate()", true);

            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alertScript", "<script language=javascript>var a=getclientdate();alert(a);</script>");

            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;

            cmSQL.CommandText = "SELECT * FROM dComplaint where (OwnedByAccepted=0 or OwnedByAccepted is null) order by TransDate ASC";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            string dp = "";
            string durate = "";
            int colorstatus = 0;
            DateTime date1 = DateTime.Today;
            DateTime date2 = DateTime.Today.AddHours(Convert.ToDouble(Session["TimeDiff"]));
            string cookie = "";

            try
            {
                cookie = Request.Cookies["currentclientdate"].Value.ToString();
            }
            catch
            { }
            if (cookie != "") date2 = Convert.ToDateTime(cookie);

            while (drSQL.Read() == true)
            {
                dp = drSQL["ProductGroup"].ToString() + " - " + drSQL["UnitDescription"].ToString(); ;

                date1 = Convert.ToDateTime(drSQL["TransDate"]);

                int daysDiff = ((TimeSpan)(date2 - date1)).Days;

                if (daysDiff == 0)
                {
                    daysDiff = ((TimeSpan)(date2 - date1)).Hours;
                    if (daysDiff == 0)
                    {
                        daysDiff = ((TimeSpan)(date2 - date1)).Minutes;
                        if (daysDiff > 1)
                            durate = daysDiff.ToString() + " Mins Ago";
                        else
                            durate = daysDiff.ToString() + " Min Ago";

                    }
                    else
                    {
                        if (daysDiff > 1)
                            durate = daysDiff.ToString() + " Hours Ago";
                        else
                            durate = daysDiff.ToString() + " Hour Ago";

                    }
                    colorstatus = 0; //ok
                }
                else
                {
                    if (daysDiff > 1)
                        durate = daysDiff.ToString() + " Days Ago";
                    else
                        durate = daysDiff.ToString() + " Day Ago";


                    if (daysDiff >= 30)
                        colorstatus = 3; //Danger
                    if (daysDiff >= 15 && daysDiff <= 29)
                        colorstatus = 2; //warning
                    if (daysDiff >= 8 && daysDiff <= 14)
                        colorstatus = 1; //mild
                    if (daysDiff < 8)
                        colorstatus = 0; //ok
                }
                bool itsme = false;
                if (drSQL["OwnedByID"].ToString()=="")
                    createHTMLelements(drSQL["Refno"].ToString(), drSQL["Complaint"].ToString(), dp, durate, colorstatus, drSQL["ComplaintScope"].ToString(), drSQL["ClientRefNo"].ToString() + " - " + drSQL["ClientName"].ToString(), drSQL["Username"].ToString(), date1,"noblink","", itsme);
                else
                {
                    string assignUserDetails = drSQL["OwnedByID"].ToString() + " - " + GetIt4Me(drSQL["OwnedBy"].ToString(), " (");
                    if (drSQL["OwnedByID"].ToString().ToUpper() == Session["UserID"].ToString().ToUpper())
                    {
                        itsme = true;
                        createHTMLelements(drSQL["Refno"].ToString(), drSQL["Complaint"].ToString(), dp, durate, colorstatus, drSQL["ComplaintScope"].ToString(), drSQL["ClientRefNo"].ToString() + " - " + drSQL["ClientName"].ToString(), drSQL["Username"].ToString(), date1, "blink", assignUserDetails, itsme);
                       
                    }
                    else
                        createHTMLelements(drSQL["Refno"].ToString(), drSQL["Complaint"].ToString(), dp, durate, colorstatus, drSQL["ComplaintScope"].ToString(), drSQL["ClientRefNo"].ToString() + " - " + drSQL["ClientName"].ToString(), drSQL["Username"].ToString(), date1, "noblink", assignUserDetails, itsme);

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

    private void createHTMLelements(string RefNo, string dComment, string dProduct, string dDuration, int colorScheme, string dscope, string client, string complainBy, DateTime complainDate,string shldItBlink,string assignto, bool itsme)
    {

        HtmlAnchor myAnchor = new HtmlAnchor();
        myAnchor.ID = RefNo;
        myAnchor.HRef = "#";
        //myAnchor.title = dComment;
        myAnchor.Attributes.Add("data-toggle", "modal");
        myAnchor.Attributes.Add("data-target", "#exampleModal");
        myAnchor.Attributes.Add("data-whatever", RefNo);
        myAnchor.Attributes.Add("data-backdrop", "static");
        myAnchor.Attributes.Add("data-keyboard", "false");

        divComplaints.Controls.Add(myAnchor);


        HtmlGenericControl dynDiv = new HtmlGenericControl("DIV");
        //dynDiv.Style.Add("class", "alert alert-info clearfix");
        if (colorScheme == 0)
            dynDiv.Attributes.Add("class", "alert alert-info");
        if (colorScheme == 1)
            dynDiv.Attributes.Add("class", "alert alert-success");
        if (colorScheme == 2)
            dynDiv.Attributes.Add("class", "alert alert-warning");
        if (colorScheme == 3)
            dynDiv.Attributes.Add("class", "alert alert-danger");
        dynDiv.ID = RefNo;
        //divComplaints.Controls.Add(dynDiv);
        myAnchor.Controls.Add(dynDiv);

        HtmlGenericControl dynSpan = new HtmlGenericControl("span");
        dynSpan.ID = RefNo;
        dynSpan.Attributes.Add("class", "alert-icon");

        dynDiv.Controls.Add(dynSpan);

        HtmlGenericControl dyni = new HtmlGenericControl("i");
        dyni.Attributes.Add("class", "fa fa-comments-o");
        dyni.ID = RefNo;
        dynSpan.Controls.Add(dyni);


        HtmlGenericControl dynDiv1 = new HtmlGenericControl("DIV");
        dynDiv1.Attributes.Add("class", "notification-info");
        dynDiv1.ID = RefNo;
        dynDiv.Controls.Add(dynDiv1);


        HtmlGenericControl dynUl = new HtmlGenericControl("ul");
        dynUl.Attributes.Add("class", "clearfix notification-meta");
        //dynUl.Style.Add("list-style", "none");
        dynUl.ID = RefNo;
        dynDiv1.Controls.Add(dynUl);

        HtmlGenericControl dynLi = new HtmlGenericControl("li");
        dynLi.ID = RefNo + "div";
        dynLi.Attributes.Add("class", "pull-left notification-sender");
        dynLi.InnerHtml = dProduct;
        if (shldItBlink=="blink")
            dynLi.Attributes.Add("class", "myblink");
        dynLi.ID = RefNo;
        dynUl.Controls.Add(dynLi);

        HtmlGenericControl dynLi1 = new HtmlGenericControl("li");
        dynLi1.Attributes.Add("class", "pull-right notification-time");
        dynLi1.InnerHtml = dDuration;
        dynLi1.ID = RefNo;
        dynUl.Controls.Add(dynLi1);


        HtmlGenericControl dynP = new HtmlGenericControl("p");
        //dynP.Style.Add("line-height", "6px");
        //dynP.Style.Add("width", "auto");
        dynP.ID = RefNo;
        dynDiv1.Controls.Add(dynP);



        HtmlAnchor myAnchor1 = new HtmlAnchor();
        myAnchor1.ID = RefNo;
        myAnchor1.HRef = "#";
        myAnchor1.InnerHtml = dComment;
        myAnchor1.Attributes.Add("data-toggle", "modal");
        myAnchor1.Attributes.Add("data-target", "#exampleModal");
        myAnchor1.Attributes.Add("data-whatever", RefNo);
        dynP.Controls.Add(myAnchor1);


        HtmlGenericControl dynDiv2 = new HtmlGenericControl("DIV");
        dynDiv2.Style.Add("display", "none");
        dynDiv2.ID = RefNo;
        dynP.Controls.Add(dynDiv2);

        HtmlInputText myInput1 = new HtmlInputText();
        myInput1.ID = RefNo + "a";
        myInput1.Value = dscope;
        dynDiv2.Controls.Add(myInput1);

        HtmlInputText myInput2 = new HtmlInputText();
        myInput2.ID = RefNo + "b";
        myInput2.Value = client;
        dynDiv2.Controls.Add(myInput2);

        HtmlInputText myInput3 = new HtmlInputText();
        myInput3.ID = RefNo + "c";
        myInput3.Value = complainBy;
        dynDiv2.Controls.Add(myInput3);

        HtmlInputText myInput4 = new HtmlInputText();
        myInput4.ID = RefNo + "d";
        myInput4.Value = complainDate.ToString();
        dynDiv2.Controls.Add(myInput4);


        HtmlInputText myInput5 = new HtmlInputText();
        myInput5.ID = RefNo + "e";
        myInput5.Value = Session["ImagePath4Display"] + RefNo + ".png";
        dynDiv2.Controls.Add(myInput5);


        HtmlInputText myInput6 = new HtmlInputText();
        myInput6.ID = RefNo + "f";
        myInput6.Value = dComment;
        dynDiv2.Controls.Add(myInput6);

        HtmlInputText myInput7 = new HtmlInputText();
        myInput7.ID = RefNo + "g";
        myInput7.Value = dProduct;
        dynDiv2.Controls.Add(myInput7);

        HtmlInputText myInput8 = new HtmlInputText();
        myInput8.ID = RefNo + "h";
        myInput8.Value = assignto;
        dynDiv2.Controls.Add(myInput8);

        HtmlInputText myInput9 = new HtmlInputText();
        myInput9.ID = RefNo + "i";
        myInput9.Value = itsme.ToString().ToUpper();
        dynDiv2.Controls.Add(myInput9);




        //file://C:/Applications/Dukiya/images/edoc/
        //http:\\localhost\Applications\Dukiya\images\edoc\

    }


    protected void btnOwnComplaint_Click(object sender, EventArgs e)
    {

       string dOwnedBy= GetIt4Me(cboAssignTo.SelectedValue," - ");
        string dOwnedbyname= Mid(cboAssignTo.SelectedValue, dOwnedBy.Length + 3, -1);

        //HttpContext.Current.Response.Write("<script language=javascript>alert('" + dOwnedBy + "');</script>");

        string dCnStr = Session["Cnn"].ToString();
        SqlConnection cnSQL = new SqlConnection(dCnStr);
        SqlCommand cmSQL = cnSQL.CreateCommand();
        cnSQL.Open();
        cmSQL.CommandText = "dUpdateComplaint4Ownership";
        cmSQL.CommandType = System.Data.CommandType.StoredProcedure;
        cmSQL.Parameters.AddWithValue("@RefNo", Complaint_refno.Value);
        cmSQL.Parameters.AddWithValue("@OwnedBy", dOwnedBy); // Session["username"].ToString());
        cmSQL.Parameters.AddWithValue("@OwnedByDetail", dOwnedbyname + " (" + clientdate.Value + ")"); // DateTime.Now.ToString()
        if (dOwnedBy.ToUpper() == Session["UserID"].ToString().ToUpper())
            cmSQL.Parameters.AddWithValue("@OwnedByAccepted", true);
        else
            cmSQL.Parameters.AddWithValue("@OwnedByAccepted", false);

        cmSQL.ExecuteNonQuery();

        cmSQL.Dispose();
        cnSQL.Close();

        Complaint_refno.Value = "";
    }

    protected void btnComplaintSeen_Click(object sender, EventArgs e)
    {
        string dCnStr = Session["Cnn"].ToString();
        SqlConnection cnSQL = new SqlConnection(dCnStr);
        SqlCommand cmSQL = cnSQL.CreateCommand();
        cnSQL.Open();
        cmSQL.CommandText = "dUpdateComplaint4Seen";
        cmSQL.CommandType = System.Data.CommandType.StoredProcedure;
        cmSQL.Parameters.AddWithValue("@RefNo", Complaint_refno.Value);
        cmSQL.Parameters.AddWithValue("@SeenBy", Session["username"].ToString());
        cmSQL.Parameters.AddWithValue("@SeenByDetail", Session["username"].ToString() + " (" + clientdate.Value + ")"); // DateTime.Now.ToString()
        cmSQL.ExecuteNonQuery();

        cmSQL.Dispose();
        cnSQL.Close();
    }



    private void FetchWorkOrderOutstandingDetails()
    {
        try
        {
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            //  cmSQL.CommandText = "SELECT *,0.5 AS Progress FROM dWorkorder  order by TransDate ASC"; //where Teminated = false
            cmSQL.CommandText = "SELECT  dbo.dWorkorder.*,WorkorderCompletionLevel.CompletionLevel AS Progress FROM  dWorkorder LEFT OUTER JOIN WorkorderCompletionLevel ON dWorkorder.RefNo = WorkorderCompletionLevel.RefNo  order by TransDate ASC";

            //string str= "SELECT * FROM WorkOrderWithJoblog  WHERE CompletionLevel=-1";

            //   str=str + "UNION SELECT TOP 1 ISNULL(CompletionLevel, 0) AS CompletionLevel FROM dJoblog WHERE WorkorderRefNo = '" + Session["WorkorderRefno"].ToString() + "' ORDER BY TransDate DESC";

            //       = '" + Session["WorkorderRefno"].ToString() + "' ORDER BY TransDate DESC";


            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            string dp = "";
            string durate = "";
            string client = "";
            DateTime date1 = DateTime.Today;
            DateTime date2 = DateTime.Today.AddHours(Convert.ToDouble(Session["TimeDiff"]));
            int s = -1;

            string cookie = "";
            try
            {
                cookie = Request.Cookies["currentclientdate"].Value.ToString();
            }
            catch
            { }
            if (cookie != "") date2 = Convert.ToDateTime(cookie);

            while (drSQL.Read() == true)
            {
                s++;
                if (drSQL["UnitDescription"].ToString() == "")
                    dp = drSQL["ProductGroup"].ToString();
                else
                    dp = drSQL["ProductGroup"].ToString() + " - " + drSQL["UnitDescription"].ToString() + " - (" + drSQL["ContractRef"].ToString() + ")"; ;


                date1 = Convert.ToDateTime(drSQL["TransDate"]);

                int daysDiff = ((TimeSpan)(date2 - date1)).Days;

                if (daysDiff == 0)
                {
                    daysDiff = ((TimeSpan)(date2 - date1)).Hours;
                    if (daysDiff == 0)
                    {
                        daysDiff = ((TimeSpan)(date2 - date1)).Minutes;
                        if (daysDiff > 1)
                            durate = daysDiff.ToString() + " Mins Ago";
                        else
                            durate = daysDiff.ToString() + " Min Ago";
                    }
                    else
                    {
                        if (daysDiff > 1)
                            durate = daysDiff.ToString() + " Hours Ago";
                        else
                            durate = daysDiff.ToString() + " Hour Ago";
                    }

                }
                else
                {
                    if (daysDiff > 1)
                        durate = daysDiff.ToString() + " Days Ago";
                    else
                        durate = daysDiff.ToString() + " Day Ago";

                }


                int dpercent = 0;

                //   dpercent=FetchCurrentMaxCompletionlevel(drSQL["Refno"].ToString(), dCnStr);
                dpercent = Convert.ToInt16(drSQL["Progress"].ToString());


                if (dpercent == 100) goto skipItload;

                createHTMLelements(drSQL["Refno"].ToString(), dp, durate, dpercent); // Convert.ToDouble(drSQL["Progress"]));



                skipItload:;

            }


            cmSQL.Connection.Close();
            cmSQL.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();

            if (s == -1) WorkOrderList.Visible = false;


        }
        catch (Exception ex)
        {
            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
        }
    }


    //private static int FetchCurrentMaxCompletionlevel(string workOrderRef, string dCnstr)
    //{
    //    try
    //    {
    //        int tempFetchCurrentMaxCompletionlevel = 0;

    //        //string dCnStr = Session["Cnn"].ToString();
    //        SqlConnection cnSQL1 = new SqlConnection(dCnstr);
    //        SqlCommand cmSQL1 = cnSQL1.CreateCommand();
    //        SqlDataReader drSQL1 = null;
    //        //  cmSQL1.CommandText = "SELECT TOP 1 ISNULL(CompletionLevel,0) AS CompletionLevel FROM dJoblog WHERE WorkorderRefNo='" + workOrderRef + "' ORDER BY TransDate DESC";
    //        cmSQL1.CommandText = "SELECT TOP 1 ISNULL(CompletionLevel,0) AS CompletionLevel FROM WorkorderCompletionLevel WHERE RefNo='" + workOrderRef + "'";
    //        cmSQL1.CommandType = System.Data.CommandType.Text;
    //        cnSQL1.Open();
    //        drSQL1 = cmSQL1.ExecuteReader();

    //        if (drSQL1.HasRows)
    //        {
    //            if (drSQL1.Read())
    //                tempFetchCurrentMaxCompletionlevel = Convert.ToInt16(drSQL1["CompletionLevel"].ToString());
    //        }


    //        cmSQL1.Connection.Close();
    //        cmSQL1.Dispose();
    //        cnSQL1.Close();
    //        cnSQL1.Dispose();

    //        return tempFetchCurrentMaxCompletionlevel;

    //    }
    //    catch (Exception ex)
    //    {

    //        HttpContext.Current.Session["exception"] = ex.Message;
    //        HttpContext.Current.Response.Redirect("Error.aspx");
    //        return 0;
    //    }
    //}


    private void createHTMLelements(string RefNo, string dProduct, string dDuration, double dPerCentComplete)
    {
        string dStatus = "";
        if (dPerCentComplete <= 0) dStatus = "Not Started";
        if (dPerCentComplete >= 80 && dPerCentComplete < 100) dStatus = "Adv Progress";
        if (dPerCentComplete == 100) dStatus = "Completed";
        if (dPerCentComplete > 30 && dPerCentComplete < 80) dStatus = "Progress";
        if (dPerCentComplete > 0 && dPerCentComplete <= 30) dStatus = "Begining";
        if (dPerCentComplete == 30) dStatus = "Resolved";

        HtmlAnchor myAnchor = new HtmlAnchor();
        //myAnchor.ID = RefNo;
        //myAnchor.Title = RefNo;
        myAnchor.HRef = "#";
        myAnchor.Attributes.Add("data-toggle", "modal");
        myAnchor.Attributes.Add("data-target", "#exampleModal");
        myAnchor.Attributes.Add("data-whatever", RefNo);
        //myAnchor.InnerHtml = RefNo;
        tblBody.Controls.Add(myAnchor);

        HtmlGenericControl dynTr = new HtmlGenericControl("tr");
        dynTr.Attributes.Add("title", RefNo);

        myAnchor.Controls.Add(dynTr);



        HtmlGenericControl dynTh = new HtmlGenericControl("th");
        dynTh.Attributes.Add("scope", "row");
        // dynSpan.ID = RefNo;
        dynTh.Style.Add("font-size", "small");
        dynTh.Style.Add("font-weight", "400");
        dynTh.Attributes.Add("title", RefNo);
        //dynTh.InnerHtml = RefNo;
        dynTr.Controls.Add(dynTh);


        HtmlAnchor myAnchor1 = new HtmlAnchor();
        myAnchor1.ID = RefNo;
        myAnchor1.Title = RefNo;
        //myAnchor1.HRef = "workorderprofile.aspx";
        myAnchor1.Attributes.Add("href", "workorderprofile.aspx");
        myAnchor1.InnerHtml = RefNo;
        myAnchor1.Attributes.Add("data-toggle", "modal");
        myAnchor1.Attributes.Add("data-target", "#exampleModal");
        myAnchor1.Attributes.Add("data-whatever", RefNo);
        myAnchor1.Style.Add("color", "crimson");
        //myAnchor1.Attributes.Add("onClick", "oLoad");
        dynTh.Controls.Add(myAnchor1);


        HtmlGenericControl dynTd = new HtmlGenericControl("td");
        dynTd.Attributes.Add("title", RefNo);
        dynTd.InnerHtml = dProduct;
        dynTr.Controls.Add(dynTd);


        HtmlGenericControl dynTd1 = new HtmlGenericControl("td");
        dynTd1.Attributes.Add("title", RefNo);
        dynTr.Controls.Add(dynTd1);

        HtmlGenericControl dynSpan = new HtmlGenericControl("span");





        if (dStatus == "Not Started") dynSpan.Attributes.Add("class", "label label-danger");
        if (dStatus == "Progress") dynSpan.Attributes.Add("class", "label label-warning");
        if (dStatus == "Adv Progress") dynSpan.Attributes.Add("class", "label label-success");
        if (dStatus == "Resolved") dynSpan.Attributes.Add("class", "label label-info");
        if (dStatus == "Begining") dynSpan.Attributes.Add("class", "label label-danger");
        if (dStatus == "Completed") dynSpan.Attributes.Add("class", "label label-success");

        dynSpan.Attributes.Add("title", RefNo);
        dynSpan.InnerHtml = dStatus;
        dynTd1.Controls.Add(dynSpan);


        HtmlGenericControl dynTd2 = new HtmlGenericControl("td");
        dynTd2.Attributes.Add("title", RefNo);
        dynTr.Controls.Add(dynTd2);


        HtmlGenericControl dynH = new HtmlGenericControl("h5");
        dynH.Attributes.Add("title", RefNo);
        dynH.InnerHtml = dPerCentComplete.ToString() + "%";
        dynTd2.Controls.Add(dynH);


        HtmlGenericControl dynI = new HtmlGenericControl("i");
        if (dPerCentComplete < 50)
            dynI.Attributes.Add("class", "fa fa-level-down");
        else
            dynI.Attributes.Add("class", "fa fa-level-up");

        dynI.Attributes.Add("title", RefNo);
        dynH.Controls.Add(dynI);


        HtmlGenericControl dynTd3 = new HtmlGenericControl("td");
        dynTd3.Attributes.Add("title", RefNo);
        dynTd3.InnerHtml = dDuration;
        dynTr.Controls.Add(dynTd3);



    }



    private void FetchComplaintStats()
    {
        try
        {
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            double totalComplaint = FetchtotalComplaint(dCnStr);
            double dpercent = 0;
            string dpercenttext = "0%";
            cmSQL.CommandText = "SELECT  COUNT(ProductGroup) AS NoOfComplaint,ProductGroup FROM  dComplaint GROUP BY ProductGroup";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
         
            while (drSQL.Read() == true)
            {
                dpercent=(Convert.ToDouble(drSQL["NoOfComplaint"]) / totalComplaint) * 100;
                dpercenttext = dpercent.ToString("###.##") + "%";

                HtmlGenericControl dynLi = new HtmlGenericControl("li");
                dynLi.InnerHtml = drSQL["ProductGroup"].ToString();
                dStat.Controls.Add(dynLi);

                HtmlGenericControl dynLi1 = new HtmlGenericControl("Span");
                dynLi1.Attributes.Add("class", "pull-right");
                dynLi1.InnerHtml = dpercenttext;
                dynLi.Controls.Add(dynLi1);

                HtmlGenericControl dynDiv = new HtmlGenericControl("DIV");
                dynDiv.Attributes.Add("class", "progress progress-striped active progress-right");
                dynLi.Controls.Add(dynDiv);

                HtmlGenericControl dynDiv1 = new HtmlGenericControl("DIV");
                if (dpercent>=85)  dynDiv1.Attributes.Add("class", "bar red");
                if (dpercent > 70 && dpercent<85) dynDiv1.Attributes.Add("class", "bar orange");
                if (dpercent > 60 && dpercent <= 70) dynDiv1.Attributes.Add("class", "bar yellow");
                if (dpercent > 40 && dpercent <= 60) dynDiv1.Attributes.Add("class", "bar blue");
                if (dpercent > 30 && dpercent <= 40) dynDiv1.Attributes.Add("class", "bar light-blue");
                if (dpercent <= 30) dynDiv1.Attributes.Add("class", "bar green");

                dynDiv1.Style.Add("width",  dpercenttext );
                dynDiv.Controls.Add(dynDiv1);

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


    private void FetchComplaintStatsGraph()
    {
        try
        {


            DateTime date2 = DateTime.Today.AddHours(Convert.ToDouble(Session["TimeDiff"]));
            string cookie = "";

            try
            {
                cookie = Request.Cookies["currentclientdate"].Value.ToString();
            }
            catch
            { }
            if (cookie != "") date2 = Convert.ToDateTime(cookie);
            yearInfocus.InnerHtml = date2.Year.ToString();
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            cmSQL.CommandText = "SELECT  COUNT(RefNo) AS NoOfComplaint,ProductGroup,Month(TransDate) As dMonth FROM dComplaint WHERE YEAR(TransDate)=" + date2.Year + " GROUP BY ProductGroup,Month(TransDate)";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();

            while (drSQL.Read() == true)
            {

                if (Convert.ToInt16(drSQL["dMonth"]) == 1) jan1.Value = drSQL["NoOfComplaint"].ToString();
                if (Convert.ToInt16(drSQL["dMonth"]) == 2) feb1.Value = drSQL["NoOfComplaint"].ToString();
                if (Convert.ToInt16(drSQL["dMonth"]) == 3) mar1.Value = drSQL["NoOfComplaint"].ToString();
                if (Convert.ToInt16(drSQL["dMonth"]) == 4) apr1.Value = drSQL["NoOfComplaint"].ToString();
                if (Convert.ToInt16(drSQL["dMonth"]) == 5) may1.Value = drSQL["NoOfComplaint"].ToString();
                if (Convert.ToInt16(drSQL["dMonth"]) == 6) jun1.Value = drSQL["NoOfComplaint"].ToString();
                if (Convert.ToInt16(drSQL["dMonth"]) == 7) jul1.Value = drSQL["NoOfComplaint"].ToString();
                if (Convert.ToInt16(drSQL["dMonth"]) == 8) aug1.Value = drSQL["NoOfComplaint"].ToString();
                if (Convert.ToInt16(drSQL["dMonth"]) == 9) sep1.Value = drSQL["NoOfComplaint"].ToString();
                if (Convert.ToInt16(drSQL["dMonth"]) == 10) oct1.Value = drSQL["NoOfComplaint"].ToString();
                if (Convert.ToInt16(drSQL["dMonth"]) == 11) nov1.Value = drSQL["NoOfComplaint"].ToString();
                if (Convert.ToInt16(drSQL["dMonth"]) == 12) dec1.Value = drSQL["NoOfComplaint"].ToString();


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


    private static double FetchtotalComplaint(string dCnstr)
    {
        try
        {
            double tempFetchtotalComplaint = 0;

           SqlConnection cnSQL1 = new SqlConnection(dCnstr);
            SqlCommand cmSQL1 = cnSQL1.CreateCommand();
            SqlDataReader drSQL1 = null;
            cmSQL1.CommandText = "SELECT  COUNT(ProductGroup) AS NoOfComplaint FROM  dComplaint";
            cmSQL1.CommandType = System.Data.CommandType.Text;
            cnSQL1.Open();
            drSQL1 = cmSQL1.ExecuteReader();

            if (drSQL1.HasRows)
            {
                if (drSQL1.Read())
                    tempFetchtotalComplaint = Convert.ToInt16(drSQL1["NoOfComplaint"].ToString());
            }


            cmSQL1.Connection.Close();
            cmSQL1.Dispose();
            cnSQL1.Close();
            cnSQL1.Dispose();

            return tempFetchtotalComplaint;

        }
        catch (Exception ex)
        {

            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
            return 0;
        }
    }

    public void loadStaff()
    {
        try
        {
            cboAssignTo.Items.Clear();

            string dCnStr = ConfigurationManager.ConnectionStrings["CnStr"].ConnectionString;
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            cmSQL.CommandText = "SELECT dUserAccess.UserID, UserName,AllowModule FROM dUserAccess INNER JOIN dUserAccessModule ON dUserAccess.UserID = dUserAccessModule.UserID WHERE AllowModule='Workorder' AND Suspend=0";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            while (drSQL.Read() == true)
            {
                cboAssignTo.Items.Add(drSQL["UserID"].ToString() + " - " + drSQL["UserName"].ToString() );
            }

            cmSQL.Connection.Close();
            cmSQL.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();

            try {

                cboAssignTo.SelectedIndex = 0;
            }
            catch
            { }

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

   

}
