using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class workorderprofile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"].ToString() == null || Session["UserID"].ToString() == "")
            {
                Response.Redirect("Default.aspx", true);
            }


            if (FetchUserAccess(Session["UserID"].ToString(), "Workorder", Session["Cnn"].ToString()) == false)
                ClientScript.RegisterStartupScript(this.GetType(), "goBack", "history.go(-1);", true);
       
      
            Session["Contract_Details"] = "";
            Session["ProductInfo"] = "";
            Session["workscope"] = "";

            if (!IsPostBack)
            {
                workorder_refno.Value = "";
            }

            FetchWorkOrderOutstandingDetails();

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
                    dp = drSQL["ProductGroup"].ToString() + " - " + drSQL["UnitDescription"].ToString() + " - (" + drSQL["ContractRef"].ToString() + ")";


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

                createHTMLelements(drSQL["Refno"].ToString(), dp, durate, dpercent, drSQL["AttentionLevel"].ToString(), drSQL["Username"].ToString()); // Convert.ToDouble(drSQL["Progress"]));


                if (drSQL["ContractRef"].ToString() == "")
                    client = "";
                else
                    client = drSQL["ContractRef"].ToString() + " - (" + drSQL["ClientRefNo"].ToString() + " - " + drSQL["ClientName"].ToString() + ")";

                string dRefNo = drSQL["Refno"].ToString();

                HtmlGenericControl dynDiv2 = new HtmlGenericControl("DIV");
                dynDiv2.Style.Add("display", "none");
                dynDiv2.Attributes.Add("title", dRefNo);
                tblBody.Controls.Add(dynDiv2);

                HtmlInputText myInput1 = new HtmlInputText();
                myInput1.ID = dRefNo + "a";
                myInput1.Value = dp;
                dynDiv2.Controls.Add(myInput1);

                HtmlInputText myInput2 = new HtmlInputText();
                myInput2.ID = dRefNo + "b";
                myInput2.Value = drSQL["WorkDetails"].ToString();
                dynDiv2.Controls.Add(myInput2);

                HtmlInputText myInput3 = new HtmlInputText();
                myInput3.ID = dRefNo + "c";
                myInput3.Value = drSQL["WorkScope"].ToString();
                dynDiv2.Controls.Add(myInput3);

                HtmlInputText myInput4 = new HtmlInputText();
                myInput4.ID = dRefNo + "d";
                myInput4.Value = client;
                dynDiv2.Controls.Add(myInput4);


                HtmlInputText myInput5 = new HtmlInputText();
                myInput5.ID = dRefNo + "e";
                myInput5.Value = drSQL["TransDate"].ToString();
                dynDiv2.Controls.Add(myInput5);

                HtmlInputText myInput6 = new HtmlInputText();
                myInput6.ID = dRefNo + "f";
                myInput6.Value = Convert.ToDateTime(drSQL["ExpectedStartDate"]).ToString("dd-MMM-yyyy");
                dynDiv2.Controls.Add(myInput6);

                HtmlInputText myInput7 = new HtmlInputText();
                myInput7.ID = dRefNo + "g";
                myInput7.Value = Convert.ToDateTime(drSQL["ExpectedEndDate"]).ToString("dd-MMM-yyyy");
                dynDiv2.Controls.Add(myInput7);

                HtmlInputText myInput8 = new HtmlInputText();
                myInput8.ID = dRefNo + "h";
                myInput8.Value = drSQL["SupervisionTeam"].ToString();
                dynDiv2.Controls.Add(myInput8);

                HtmlInputText myInput9 = new HtmlInputText();
                myInput9.ID = dRefNo + "i";
                myInput9.Value = drSQL["TermOfService"].ToString();
                dynDiv2.Controls.Add(myInput9);

                HtmlInputText myInput10 = new HtmlInputText();
                myInput10.ID = dRefNo + "j";
                myInput10.Value = drSQL["AttentionLevel"].ToString();
                dynDiv2.Controls.Add(myInput10);

                HtmlInputText myInput11 = new HtmlInputText();
                myInput11.ID = dRefNo + "k";
                myInput11.Value = drSQL["username"].ToString();
                dynDiv2.Controls.Add(myInput11);

                HtmlInputText myInput12 = new HtmlInputText();
                myInput12.ID = dRefNo + "l";
                myInput12.Value = Session["ImagePath4Display"] + dRefNo + ".png";
                dynDiv2.Controls.Add(myInput12);

                HtmlInputText myInput13 = new HtmlInputText();
                myInput13.ID = dRefNo + "m";
                myInput13.Value = drSQL["ComplaintRef"].ToString();
                dynDiv2.Controls.Add(myInput13);

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



    private void createHTMLelements(string RefNo, string dProduct, string dDuration, double dPerCentComplete,string attentionlevel, string teamlead)
    {
        
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
        myAnchor1.HRef = "#";
        myAnchor1.InnerHtml = RefNo;
        myAnchor1.Attributes.Add("data-toggle", "modal");
        myAnchor1.Attributes.Add("data-target", "#exampleModal");
        myAnchor1.Attributes.Add("data-whatever", RefNo);
        myAnchor1.Style.Add("color", "crimson");
        //myAnchor1.Attributes.Add("onClick", "oLoad");
        dynTh.Controls.Add(myAnchor1);


        //HtmlButton myAnchor1 = new HtmlButton();
        //myAnchor1.ID = RefNo;
        ////myAnchor1.Title = RefNo;
        //myAnchor1.InnerText = RefNo;
        //myAnchor1.Attributes.Add("data-toggle", "modal");
        //myAnchor1.Attributes.Add("data-target", "#exampleModal");
        //myAnchor1.Attributes.Add("data-whatever", RefNo);
        ////myAnchor1.Style.Add("color", "crimson");
        //// myAnchor1.Attributes.Add("runat", "server");
        ////myAnchor1.Attributes.Add("Onclick", "Button2_Click");
        //dynTh.Controls.Add(myAnchor1);




        HtmlGenericControl dynTd = new HtmlGenericControl("td");
        dynTd.Attributes.Add("title", RefNo);
        dynTd.InnerHtml = dProduct;
        dynTr.Controls.Add(dynTd);


        HtmlGenericControl dynTd1 = new HtmlGenericControl("td");
        dynTd1.Attributes.Add("title", RefNo);
        dynTr.Controls.Add(dynTd1);

        HtmlGenericControl dynSpan = new HtmlGenericControl("span");


        if (attentionlevel == "Critical") dynSpan.Attributes.Add("class", "label label-danger");
        if (attentionlevel == "Severe") dynSpan.Attributes.Add("class", "label label-warning");
        if (attentionlevel == "Controlled") dynSpan.Attributes.Add("class", "label label-info");
        if (attentionlevel == "Resolved") dynSpan.Attributes.Add("class", "label label-success");


        dynSpan.Attributes.Add("title", RefNo);
        dynSpan.InnerHtml = attentionlevel;
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

        HtmlGenericControl dynTd4 = new HtmlGenericControl("td");
        dynTd4.Attributes.Add("title", RefNo);
        dynTd4.InnerHtml = teamlead;
        dynTr.Controls.Add(dynTd4);


        HtmlGenericControl dynDiv2 = new HtmlGenericControl("DIV");
        dynDiv2.Style.Add("display", "none");
        dynDiv2.Attributes.Add("title", RefNo);
        dynTr.Controls.Add(dynDiv2);

    }



    protected void btnNewjoblog_Click(object sender, EventArgs e)
    {
        if (workorder_refno.Value == "")
        {
            HttpContext.Current.Response.Write("<script language=javascript>alert('Pls. select a workorder');</script>");
            return;
        }
        //Session["Contract_Details"] = Contract_Details.Value;
        Session["WorkorderRefno"] = workorder_refno.Value;
        //Session["ProductInfo"] = dproperty.Value;
        //Session["workscope"] = workscope.Value;
        Session["dAction"]="Edit";
        Response.Redirect("workorder.aspx", true);
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