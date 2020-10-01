using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class servicecharge : System.Web.UI.Page
{
    public int eAutoID;
    public string eRefno;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"].ToString() == null || Session["UserID"].ToString() == "")
            {
                Response.Redirect("Default.aspx", true);
            }

            if (FetchUserAccess(Session["UserID"].ToString(), "Service Charge", Session["Cnn"].ToString()) == false)
                ClientScript.RegisterStartupScript(this.GetType(), "goBack", "history.go(-1);", true);

            if (!IsPostBack)
            {
                FetchPropertyGroup();
                loadProxy();
            }
            TransDate_datepicker.Value = DateTime.Now.ToString("dd-MMMM-yyyy");

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

    private void FetchServiceChargeBalance(string ProductGroup)
    {
        try
        {

            Contract_Details.Value = "";
            dproperty.Value = "";

            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            if (ProductGroup=="ALL")
                cmSQL.CommandText = "SELECT dTransaction.*, (ISNULL(dServiceChargeBalances.DR,0)-ISNULL(dServiceChargeBalances.CR,0)) AS Balance FROM dTransaction LEFT OUTER JOIN dbo.dServiceChargeBalances ON dbo.dTransaction.RefNo = dbo.dServiceChargeBalances.ContractRef order by RefNo"; //where Teminated = false
            else
                cmSQL.CommandText = "SELECT dTransaction.*, (ISNULL(dServiceChargeBalances.DR,0)-ISNULL(dServiceChargeBalances.CR,0)) AS Balance FROM dTransaction LEFT OUTER JOIN dbo.dServiceChargeBalances ON dbo.dTransaction.RefNo = dbo.dServiceChargeBalances.ContractRef WHERE dTransaction.ProductGroup='" + ProductGroup + "' order by RefNo"; //where Teminated = false
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            string dp = "";
            string client = "";
            string dRefNo = "";
            int s = -1;
            while (drSQL.Read() == true)
            {
                s++;
 
                dp = drSQL["ProductGroup"].ToString() + " - " + drSQL["UnitDescription"].ToString();

                client = drSQL["RefNo"].ToString() + " - (" + drSQL["ClientRefNo"].ToString() + " - " + drSQL["ClientName"].ToString() + ")";

                 dRefNo = drSQL["Refno"].ToString();

                createHTMLelements(dRefNo, client, dp, Convert.ToDouble(drSQL["Balance"]));

            }


            cmSQL.Connection.Close();
            cmSQL.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();

            if (ProductGroup == "ALL")
            {
            }
            else
            {
                dRefNo = "GP/xxx";
                client = "GP/xxx - (Cxxxxx - " + Session["Owner"].ToString() + ")";
                dp = ProductGroup + " - ALL";

                createHTMLelements(dRefNo, client, dp, 0.0);

            }

            if (s == -1) WorkOrderList.Visible = false;


        }
        catch (Exception ex)
        {
            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
        }
    }

    private void createHTMLelements(string RefNo, string dContract, string dProduct, double dAmount)
    {
        string dStatus = "";
        if (dAmount <= 0)
            dStatus = "Not Started";
        else
            dStatus = "Resolved";

        HtmlAnchor myAnchor = new HtmlAnchor();
        //myAnchor.ID = RefNo;
        //myAnchor.Title = RefNo;
        myAnchor.HRef = "#";
        myAnchor.Attributes.Add("data-toggle", "modal");
        myAnchor.Attributes.Add("data-target", "#exampleModal");
        myAnchor.Attributes.Add("data-whatever", RefNo);
        tblBody.Controls.Add(myAnchor);

        HtmlGenericControl dynTr = new HtmlGenericControl("tr");
        dynTr.Attributes.Add("title", RefNo);
        myAnchor.Controls.Add(dynTr);


        HtmlGenericControl dynTh = new HtmlGenericControl("th");
        dynTh.Attributes.Add("scope", "row");
        dynTh.Style.Add("font-size", "small");
        dynTh.Style.Add("font-weight", "400");
        dynTh.Attributes.Add("title", RefNo);
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
        dynTh.Controls.Add(myAnchor1);


        HtmlGenericControl dynTd = new HtmlGenericControl("td");
        dynTd.Attributes.Add("title", RefNo);
        dynTd.InnerHtml = dContract;
        dynTr.Controls.Add(dynTd);


        HtmlGenericControl dynTd1 = new HtmlGenericControl("td");
        dynTd1.Attributes.Add("title", RefNo);
        dynTr.Controls.Add(dynTd1);

        HtmlGenericControl dynSpan = new HtmlGenericControl("span");
        dynSpan.Attributes.Add("title", RefNo);
        dynSpan.InnerHtml = dProduct;
        dynTd1.Controls.Add(dynSpan);


        HtmlGenericControl dynTd2 = new HtmlGenericControl("td");
        dynTd2.Attributes.Add("title", RefNo);
        dynTr.Controls.Add(dynTd2);

        HtmlGenericControl dynH = new HtmlGenericControl("h5");
        dynH.Attributes.Add("title", RefNo);
        dynH.InnerHtml = dAmount.ToString("###,###.##");
        dynH.Style.Add("color", "white");
        if (dAmount < 0)
            dynH.Attributes.Add("class", "label label-danger");
        else
            dynH.Attributes.Add("class", "label label-success");
        dynTd2.Controls.Add(dynH);


        HtmlGenericControl dynDiv2 = new HtmlGenericControl("DIV");
        dynDiv2.Style.Add("display", "none");
        dynDiv2.Attributes.Add("title", RefNo);
        dynTr.Controls.Add(dynDiv2);

        HtmlInputText myInput2 = new HtmlInputText();
        myInput2.ID = RefNo + "a";
        myInput2.Value = dContract;
        dynDiv2.Controls.Add(myInput2);

        HtmlInputText myInput1 = new HtmlInputText();
        myInput1.ID = RefNo + "b";
        myInput1.Value = dProduct;
        dynDiv2.Controls.Add(myInput1);

    


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

    protected void btnNewjoblog_Click(object sender, EventArgs e)
    {

     
        try
        {


             if (Contract_Details.Value == "" || dproperty.Value=="")
            {
                 HttpContext.Current.Response.Write("<script language=javascript>alert('Incomplete Record');</script>");
                FetchServiceChargeBalance(dboproduct.Text);
                FetchTransferToAbleContract(dboproduct.Text);
                return;
            }


            if (hiddenSource.Value == "Utilization")
            {
                if (particulars.Value == "" || Convert.ToDouble(amount.Value) == 0) { 
                    HttpContext.Current.Response.Write("<script language=javascript>alert('Incomplete Record');</script>");
                    FetchServiceChargeBalance(dboproduct.Text);
                    FetchTransferToAbleContract(dboproduct.Text);
                    return;
                }
            }
            if (hiddenSource.Value == "Opening Balance")
            {
                if (particularsob.Value == "" || Convert.ToDouble(amountob.Value) == 0)
                {
                    HttpContext.Current.Response.Write("<script language=javascript>alert('Incomplete Record');</script>");
                    FetchServiceChargeBalance(dboproduct.Text);
                    FetchTransferToAbleContract(dboproduct.Text);
                    return;
                }
            }
            if (hiddenSource.Value == "Receipt from Client")
            {
                if (particularsrc.Value == "" || Convert.ToDouble(amountrc.Value) == 0)
                {
                    HttpContext.Current.Response.Write("<script language=javascript>alert('Incomplete Record');</script>");
                    FetchServiceChargeBalance(dboproduct.Text);
                    FetchTransferToAbleContract(dboproduct.Text);
                    return;
                }

            }
            if (hiddenSource.Value == "Payment to Proxy")
            {
                if (particularsp2p.Value == "" || Convert.ToDouble(amountp2p.Value) == 0 )
                {
                    HttpContext.Current.Response.Write("<script language=javascript>alert('Incomplete Record');</script>");
                    FetchServiceChargeBalance(dboproduct.Text);
                    FetchTransferToAbleContract(dboproduct.Text);
                    return;
                }

            }
            if (hiddenSource.Value == "Payment From Proxy")
            {
                if (particularspfromp.Value == "" || Convert.ToDouble(amountpfromp.Value) == 0)
                {
                    HttpContext.Current.Response.Write("<script language=javascript>alert('Incomplete Record');</script>");
                    FetchServiceChargeBalance(dboproduct.Text);
                    FetchTransferToAbleContract(dboproduct.Text);
                    return;
                }
            }
            if (hiddenSource.Value == "Balance Transfer")
            {
                if (particularsbt.Value == "" || Convert.ToDouble(amountbt.Value) == 0 || TransferTo.Text == "")
                {
                    HttpContext.Current.Response.Write("<script language=javascript>alert('Incomplete Record');</script>");
                    FetchServiceChargeBalance(dboproduct.Text);
                    FetchTransferToAbleContract(dboproduct.Text);
                    return;
                }

                if (Contract_Details.Value == TransferTo.Text)
                {
                    HttpContext.Current.Response.Write("<script language=javascript>alert('Source Account cannot be same as Destination Account');</script>");
                    FetchServiceChargeBalance(dboproduct.Text);
                    FetchTransferToAbleContract(dboproduct.Text);
                    return;
                }

            }

              
            string dContract = "";
            string dClientRef = "";
            string dClientName = "";
            string dp = "";
            string dpunit = "";
            string TranTo = "";
            string TranToDesc = "";
            if (Contract_Details.Value != "")
            {
                dContract = GetIt4Me(Contract_Details.Value, " - ");
                dClientRef = GetIt4Me(Mid(Contract_Details.Value, dContract.Length + 3, -1), " - ");
                dClientRef = Right(dClientRef, dClientRef.Length - 1);
                dClientName = GetIt4Me(Mid(Contract_Details.Value, dContract.Length + 3 + dClientRef.Length + 3, -1), " - ");
                dClientName = Left(dClientName, dClientName.Length - 1).Trim();

       
            }
            
            if (dproperty.Value != "")
            {
                dp = GetIt4Me(dproperty.Value, " - ");
                dpunit = Mid(dproperty.Value, dp.Length + 3, -1);

            }

            if (TransferTo.Text != "")
            {
               // TransferTo.Text=Mid(Contract_Details.Value, dContract.Length + 3, -1),
                TranTo = GetIt4Me(TransferTo.Text, " - ");
                TranToDesc = Mid(TransferTo.Text, TranTo.Length + 4, -1);
                TranToDesc = Mid(TranToDesc,0, TranToDesc.Length-1);

            }
            

            FetchNextNo();


            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            cnSQL.Open();

            SqlTransaction myTrans;
            myTrans = cnSQL.BeginTransaction();
            cmSQL.Transaction = myTrans;


            cmSQL.CommandText = "dInsertServiceCharge";
            cmSQL.CommandType = System.Data.CommandType.StoredProcedure;
            cmSQL.Parameters.AddWithValue("@RefNo", eRefno );
            cmSQL.Parameters.AddWithValue("@ContractRef", dContract );
            cmSQL.Parameters.AddWithValue("@ClientRefNo", dClientRef );
            cmSQL.Parameters.AddWithValue("@ClientName", dClientName );
            cmSQL.Parameters.AddWithValue("@ProductGroup", dp );
            cmSQL.Parameters.AddWithValue("@UnitDescription", dpunit);
            cmSQL.Parameters.AddWithValue("@TransDate",Convert.ToDateTime(TransDate_datepicker.Value));
            cmSQL.Parameters.AddWithValue("@UserName", Session["username"].ToString());
            cmSQL.Parameters.AddWithValue("@Source", hiddenSource.Value);
            cmSQL.Parameters.AddWithValue("@Authorise", 0);
            cmSQL.Parameters.AddWithValue("@AuthorisedBy", "");
            cmSQL.Parameters.AddWithValue("@AutoID", eAutoID);

          

            if (hiddenSource.Value == "Utilization")
            {
                cmSQL.Parameters.AddWithValue("@Particulars", particulars.Value);
                cmSQL.Parameters.AddWithValue("@Amount", amount.Value);
                cmSQL.Parameters.AddWithValue("@Beneficiary", "");
                cmSQL.Parameters.AddWithValue("@PVNo", "");
                cmSQL.Parameters.AddWithValue("@TransferToContractRef", "");
                cmSQL.Parameters.AddWithValue("@TransferToClientDetails", "");
                cmSQL.Parameters.AddWithValue("@Proxy", Proxyut.Text);
                cmSQL.Parameters.AddWithValue("@OurComponent", amount1.Value);
                
            }
            if (hiddenSource.Value == "Opening Balance")
            {
                cmSQL.Parameters.AddWithValue("@Particulars", particularsob.Value);
                if (chknegativeob.Checked.ToString() == "False")
                    cmSQL.Parameters.AddWithValue("@Amount", amountob.Value);
                else
                    cmSQL.Parameters.AddWithValue("@Amount", 0-Convert.ToDouble(amountob.Value));
                cmSQL.Parameters.AddWithValue("@Beneficiary", "");
                cmSQL.Parameters.AddWithValue("@PVNo", "");
                cmSQL.Parameters.AddWithValue("@TransferToContractRef", "");
                cmSQL.Parameters.AddWithValue("@TransferToClientDetails", "");
                cmSQL.Parameters.AddWithValue("@Proxy", Proxyob.Text);
                cmSQL.Parameters.AddWithValue("@OurComponent", 0);
            }
            if (hiddenSource.Value == "Receipt from Client")
            {
                cmSQL.Parameters.AddWithValue("@Particulars", particularsrc.Value);
                cmSQL.Parameters.AddWithValue("@Amount", amountrc.Value);
                cmSQL.Parameters.AddWithValue("@Beneficiary", "");
                cmSQL.Parameters.AddWithValue("@PVNo", PVrc.Value);
                cmSQL.Parameters.AddWithValue("@TransferToContractRef", "");
                cmSQL.Parameters.AddWithValue("@TransferToClientDetails", "");
                cmSQL.Parameters.AddWithValue("@Proxy", Proxyrc.Text);
                cmSQL.Parameters.AddWithValue("@OurComponent", 0);
            }
            if (hiddenSource.Value == "Payment to Proxy")
            {
                cmSQL.Parameters.AddWithValue("@Particulars", particularsp2p.Value);
                cmSQL.Parameters.AddWithValue("@Amount", amountp2p.Value);
                cmSQL.Parameters.AddWithValue("@Beneficiary", Beneficiaryp2p.Text);
                cmSQL.Parameters.AddWithValue("@PVNo", PVp2p.Value);
                cmSQL.Parameters.AddWithValue("@TransferToContractRef", "");
                cmSQL.Parameters.AddWithValue("@TransferToClientDetails", "");
                cmSQL.Parameters.AddWithValue("@Proxy", Proxyp2p.Text);
                cmSQL.Parameters.AddWithValue("@OurComponent", 0);
            }
            if (hiddenSource.Value == "Payment From Proxy")
            {
                cmSQL.Parameters.AddWithValue("@Particulars", particularspfromp.Value);
                cmSQL.Parameters.AddWithValue("@Amount", amountpfromp.Value);
                cmSQL.Parameters.AddWithValue("@Beneficiary", Beneficiarypfromp.Text);
                cmSQL.Parameters.AddWithValue("@PVNo", PVNopFromp.Value);
                cmSQL.Parameters.AddWithValue("@TransferToContractRef", "");
                cmSQL.Parameters.AddWithValue("@TransferToClientDetails", "");
                cmSQL.Parameters.AddWithValue("@Proxy", Proxypfromp.Text);
                cmSQL.Parameters.AddWithValue("@OurComponent", 0);
            }
            if (hiddenSource.Value == "Balance Transfer")
            {
                cmSQL.Parameters.AddWithValue("@Particulars", particularsbt.Value);
                if (chknegativebt.Checked.ToString() == "False")
                    cmSQL.Parameters.AddWithValue("@Amount", amountbt.Value);
                else
                    cmSQL.Parameters.AddWithValue("@Amount", 0 - Convert.ToDouble(amountbt.Value));
                cmSQL.Parameters.AddWithValue("@Beneficiary", Beneficiarybt.Text);
                cmSQL.Parameters.AddWithValue("@PVNo", "");
                cmSQL.Parameters.AddWithValue("@TransferToContractRef", TranTo);
                cmSQL.Parameters.AddWithValue("@TransferToClientDetails", TranToDesc);
                cmSQL.Parameters.AddWithValue("@Proxy", Proxybt.Text);
                cmSQL.Parameters.AddWithValue("@OurComponent", 0);
            }
            cmSQL.ExecuteNonQuery();

            myTrans.Commit();

            cmSQL.Dispose();
            cnSQL.Close();


            Contract_Details.Value = "";
            dproperty.Value = "";
            particulars.Value = "";
            amount.Value = "0";
            particularsob.Value = "";
            amountob.Value = "0";

            //hiddenSource.Value ="";
            particularsrc.Value = "";
            amountrc.Value = "0";
            particularsp2p.Value = "";
            amountp2p.Value = "0";
            particularspfromp.Value = "";
            amountpfromp.Value = "0";
            particularsbt.Value = "";
            amountbt.Value = "0";
            amount1.Value = "0";
            //  TransferTo.Text = "";
            
            FetchServiceChargeBalance(dboproduct.Text);
            FetchTransferToAbleContract(dboproduct.Text);

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
            cmSQL.CommandText = "SELECT ISNULL(MAX(AutoID),0)+1 AS NewAutoID FROM dServiceCharge";
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



            eRefno = "CS_" + str3;
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
    private void FetchPropertyGroup()
    {
        try
        {
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            string dp;
            dboproduct.Items.Clear();
            dboproduct.Items.Add("ALL");
            cmSQL.CommandText = "SELECT DISTINCT ProductGroup FROM dTransaction where Active=1 order by ProductGroup ASC";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            while (drSQL.Read() == true)
            {
                dp = drSQL["ProductGroup"].ToString();
                dboproduct.Items.Add(drSQL["ProductGroup"].ToString());
              

            }
            cmSQL.Connection.Close();
            cmSQL.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();

            FetchServiceChargeBalance(dboproduct.Text);
            FetchTransferToAbleContract(dboproduct.Text);

        }
        catch (Exception ex)
        {
            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
        }
    }

    protected void dboproduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        // FetchServiceChargeBalance(dboproduct.Text);
        //FetchTransferToAbleContract(dboproduct.Text);
    }

    protected void dboproduct_TextChanged(object sender, EventArgs e)
    {
        FetchServiceChargeBalance(dboproduct.Text);
        FetchTransferToAbleContract(dboproduct.Text);
    }

    private void FetchTransferToAbleContract(string ProductGroup)
    {
        try
        {
            TransferTo.Items.Clear();
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            if (ProductGroup == "ALL")
                cmSQL.CommandText = "SELECT * FROM dTransaction Where Active=1 order by RefNo"; 
            else
                cmSQL.CommandText = "SELECT * FROM dTransaction WHERE Active=1 AND ProductGroup='" + ProductGroup + "' order by RefNo"; 
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
       while (drSQL.Read() == true)
            { 
          TransferTo.Items.Add(drSQL["RefNo"].ToString() + " - (" + drSQL["ClientRefNo"].ToString() + " - " + drSQL["ClientName"].ToString() + ")");
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

    private void loadProxy()
    {
        try
        {

            Proxyob.Items.Clear();
            Proxyut.Items.Clear();
            Proxyrc.Items.Clear();
            Proxyp2p.Items.Clear();
            Proxypfromp.Items.Clear();
            Proxybt.Items.Clear();
            Beneficiarybt.Items.Clear();

            Proxyob.Items.Add("Us");
            Proxyrc.Items.Add("Us");
            //Proxyp2p.Items.Add("Us");
            //Proxyp2p.Items.Add("Client");
            Proxybt.Items.Add("Us");
           

            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
           cmSQL.CommandText = "SELECT * FROM dProxyInfor order by Sn"; 
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
         
            while (drSQL.Read() == true)
            {
                Proxyob.Items.Add(drSQL["Proxyname"].ToString());
                Proxyut.Items.Add(drSQL["Proxyname"].ToString());
                Proxyrc.Items.Add(drSQL["Proxyname"].ToString());
                Proxypfromp.Items.Add(drSQL["Proxyname"].ToString());
                Proxybt.Items.Add(drSQL["Proxyname"].ToString());
                Proxyp2p.Items.Add(drSQL["Proxyname"].ToString());
                Beneficiarybt.Items.Add(drSQL["Proxyname"].ToString());
            }

            Proxyut.Items.Add("Us");
            Beneficiarybt.Items.Add("Us");

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