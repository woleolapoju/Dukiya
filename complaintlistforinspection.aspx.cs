using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class complaintlistforinspection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Session["UserID"].ToString() == null || Session["UserID"].ToString() == "")
            {
                Response.Redirect("Default.aspx", true);
            }

            if (FetchUserAccess(Session["UserID"].ToString(), "Inspections", Session["Cnn"].ToString()) == false)
                ClientScript.RegisterStartupScript(this.GetType(), "goBack", "history.go(-1);", true);



            FetchComplaintOutstandingDetails();
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


    private void FetchComplaintOutstandingDetails()
    {
        try
        {
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;

               cmSQL.CommandText = "SELECT * FROM dComplaint where not(OwnedBy='' or OwnedBy is null) and RefNo NOT IN (SELECT ComplaintRef FROM dInspection) order by TransDate ASC";
             cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            string dp = "";
            string durate = "";
            int colorstatus = 0;
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
                dp = drSQL["ProductGroup"].ToString() + " - " + drSQL["UnitDescription"].ToString(); ;

                date1 = Convert.ToDateTime(drSQL["TransDate"]);

                int daysDiff = ((TimeSpan)(date2 - date1)).Days;

                if (daysDiff == 0)
                {
                    daysDiff = ((TimeSpan)(date2 - date1)).Hours;
                    if (daysDiff == 0)
                    {
                        daysDiff = ((TimeSpan)(date2 - date1)).Minutes;
                        if (daysDiff>1) 
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


                createHTMLelements(drSQL["Refno"].ToString(), drSQL["Complaint"].ToString(), dp, durate, colorstatus, drSQL["ComplaintScope"].ToString(), drSQL["ClientRefNo"].ToString() + " - " + drSQL["ClientName"].ToString(), drSQL["Username"].ToString(), date1, drSQL["ContractRef"].ToString());

            }


            cmSQL.Connection.Close();
            cmSQL.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();

        if(s == -1)  complaintList.Visible = false;


        }
        catch (Exception ex)
        {
            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
        }
    }

    private void createHTMLelements(string RefNo, string dComment, string dProduct, string dDuration, int colorScheme, string dscope, string client, string complainBy, DateTime complainDate, string dcontractRef)
    {

        HtmlAnchor myAnchor = new HtmlAnchor();
        myAnchor.ID = RefNo;
        myAnchor.Title = RefNo;
        myAnchor.HRef = "#";
   //  myAnchor.InnerHtml = dComment;
        myAnchor.Attributes.Add("data-toggle", "modal");
        myAnchor.Attributes.Add("data-target", "#exampleModal");
        myAnchor.Attributes.Add("data-whatever", RefNo);
        //myAnchor.Attributes.Add("onclick", "opendetailscreen()");
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
        //divComplaints.Controls.Add(dynDiv);
       // dynDiv.ID = RefNo;
        dynDiv.Attributes.Add("title",RefNo);
        myAnchor.Controls.Add(dynDiv);


        HtmlGenericControl dynSpan = new HtmlGenericControl("span");
        dynSpan.Attributes.Add("class", "alert-icon");
       // dynSpan.ID = RefNo;
        dynSpan.Attributes.Add("title", RefNo);
        dynDiv.Controls.Add(dynSpan);

        HtmlGenericControl dyni = new HtmlGenericControl("i");
        dyni.Attributes.Add("class", "fa fa-comments-o");
       // dyni.ID = RefNo;
        dyni.Attributes.Add("title", RefNo);
        dynSpan.Controls.Add(dyni);


        HtmlGenericControl dynDiv1 = new HtmlGenericControl("DIV");
        dynDiv1.Attributes.Add("class", "notification-info");
        // dynDiv1.ID = RefNo;
        dynDiv1.Attributes.Add("title", RefNo);
        dynDiv.Controls.Add(dynDiv1);


        HtmlGenericControl dynUl = new HtmlGenericControl("ul");
        dynUl.Attributes.Add("class", "clearfix notification-meta");
        //dynUl.Style.Add("list-style", "none");
       // dynUl.ID = RefNo;
        dynUl.Attributes.Add("title", RefNo);
        dynDiv1.Controls.Add(dynUl);

        HtmlGenericControl dynLi = new HtmlGenericControl("li");
        dynLi.ID = RefNo + "div";
        dynLi.Attributes.Add("class", "pull-left notification-sender");
        dynLi.InnerHtml = dProduct;
       // dynLi.ID = RefNo;
        dynLi.Attributes.Add("title", RefNo);
        dynUl.Controls.Add(dynLi);

        HtmlGenericControl dynLi1 = new HtmlGenericControl("li");
        dynLi1.Attributes.Add("class", "pull-right notification-time");
        dynLi1.InnerHtml = dDuration;
       // dynLi1.ID = RefNo;
        dynLi1.Attributes.Add("title", RefNo);
        dynUl.Controls.Add(dynLi1);


        HtmlGenericControl dynP = new HtmlGenericControl("p");
        //dynP.Style.Add("line-height", "6px");
        //dynP.ID = RefNo;
        dynP.Attributes.Add("title", RefNo);
        dynDiv1.Controls.Add(dynP);

        
        HtmlAnchor myAnchor1 = new HtmlAnchor();
       // myAnchor1.ID = RefNo;
        myAnchor1.Title = RefNo;
        myAnchor1.HRef = "#";
        myAnchor1.InnerHtml = dComment;
        myAnchor1.Attributes.Add("data-toggle", "modal");
        myAnchor1.Attributes.Add("data-target", "#exampleModal");
        myAnchor1.Attributes.Add("data-whatever", RefNo);
        dynP.Controls.Add(myAnchor1);


        HtmlGenericControl dynDiv2 = new HtmlGenericControl("DIV");
        dynDiv2.Style.Add("display", "none");
        //dynDiv2.ID = RefNo;
        dynDiv2.Attributes.Add("title", RefNo);
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
        myInput8.Value = dcontractRef;
        dynDiv2.Controls.Add(myInput8);

        


    }


    protected void btnNewInspection_Click(object sender, EventArgs e)
    {
    
          Session["ComplaintRefno"] = Complaint_refno.Value;
        Session["ClientInfo"] = client_name.Value;
            Session["ProductInfo"] = property_name.Value;
        Session["ComplaintScope"] = Scope_name.Value;
        Session["ContractRefNo"] = contract_ref.Value;
        Response.Redirect("inspection.aspx", true);
    }

    protected void btnBasicInspection_Click(object sender, EventArgs e)
    {

        Session["ComplaintRefno"] = "";
        Session["ClientInfo"] = "";
        Session["ProductInfo"] = "";
        Session["ComplaintScope"] = "";
        Session["ContractRefNo"] = "";
        Response.Redirect("inspection.aspx", true);
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