using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class servicechargeacctsmt : System.Web.UI.Page
{

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

            if (!Page.IsPostBack)
            {
              
               FetchPropertyGroup();
                FetchProxy();

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
    private void bindGrid()
    {
      
       
        string dcontractref = "";
     string dCnStr = Session["Cnn"].ToString();
        string thStart = Convert.ToDateTime(startdate.Value).ToString("dd/MMM/yyyy");
        string dstr = "";
        if (PropertyGroup.Text == "ALL" && dboContracts.Text == "ALL")
            dstr = "SELECT RefNo,TransDate,[Source],Proxy,DR as [Debit], CR AS [Credit],Particulars,ProductGroup + ' - ' + UnitDescription AS Property,ContractRef + ' - (' + ClientRefNo + ' - ' + ClientName+ ')' AS [Contract Details] from dServiceChargeTransactionLedger WHERE (Proxy <> 'Client') AND TransDate>='" + Convert.ToDateTime(startdate.Value) + "' AND TransDate<='" + Convert.ToDateTime(enddate.Value) + "' ORDER BY ProductGroup, ContractRef,TransDate,RefNo";
        else if  (dboContracts.Text == "ALL")
        {
            dstr = "SELECT RefNo,TransDate,[Source],Proxy,DR as [Debit], CR AS [Credit],Particulars,ProductGroup + ' - ' + UnitDescription AS Property,ContractRef + ' - (' + ClientRefNo + ' - ' + ClientName+ ')' AS [Contract Details] from dServiceChargeTransactionLedger WHERE (Proxy <> 'Client') AND TransDate>='" + Convert.ToDateTime(startdate.Value) + "' AND TransDate<='" + Convert.ToDateTime(enddate.Value) + "' AND   ProductGroup ='" + PropertyGroup.Text + "' order by TransDate,RefNo";
        }
        else
            {
            if (dboContracts.Text.Trim() == "")
                dcontractref ="SSSAAS@HHD!!!!!!:";
            else
                dcontractref = GetIt4Me(dboContracts.Text, " - (");
            dstr = "SELECT 'BAL' AS RefNo,'" + thStart + "' AS TransDate,'Balance B/F' AS [Source],'' AS Proxy,ISNULL(SUM(DR),0) AS [Debit], ISNULL(SUM(CR),0) AS [Credit],'Balance B/F' AS Particulars,'' AS Property from dServiceChargeTransactionLedger WHERE (Proxy <> 'Client') AND TransDate <'" + Convert.ToDateTime(startdate.Value) + "' AND   ContractRef ='" + dcontractref + "' HAVING ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0)<>0";
            dstr = dstr +" UNION SELECT RefNo,TransDate,[Source],Proxy,DR as [Debit], CR AS [Credit],Particulars,ProductGroup + ' - ' + UnitDescription AS Property from dServiceChargeTransactionLedger WHERE (Proxy <> 'Client') AND TransDate>='" + Convert.ToDateTime(startdate.Value) + "' AND TransDate<='" + Convert.ToDateTime(enddate.Value) + "' AND   ContractRef ='" + dcontractref + "' order by TransDate,RefNo";
        }


      //  HttpContext.Current.Response.Write("<script language=javascript>alert('" + dcontractref + "');</script>");

        SqlDataAdapter da = new SqlDataAdapter(dstr, dCnStr);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(dt);
        // da.Fill(ds, "dServiceCharge");
        myDataGrid.DataSource = dt; // ds.Tables["dServiceCharge"].DefaultView;
        myDataGrid.DataBind();

        ViewState["dirState"] = dt;
        ViewState["sortdr"] = "Asc";

        FetchClientBalance();
        FetchBalanceWithUS();
        FetchBalanceWithProxy();

        bindGridUs();
        bindGridProxy();

        try
        {
            double dDr = 0;
        double dCr = 0;

        for (int i = 0; i < myDataGrid.Rows.Count; i++)
            {
            dDr = dDr + Convert.ToDouble(myDataGrid.Rows[i].Cells[4].Text);
            dCr = dCr + Convert.ToDouble(myDataGrid.Rows[i].Cells[5].Text);

            myDataGrid.Rows[i].Cells[1].Text = Convert.ToDateTime(myDataGrid.Rows[i].Cells[1].Text).ToString("dd/MMM/yyyy");
                myDataGrid.Rows[i].Cells[4].Text = Convert.ToDouble(myDataGrid.Rows[i].Cells[4].Text).ToString("###,###.##");
                myDataGrid.Rows[i].Cells[5].Text = Convert.ToDouble(myDataGrid.Rows[i].Cells[5].Text).ToString("###,###.##");
        
        }
        if (myDataGrid.Rows.Count > 0)
        {
            myDataGrid.FooterRow.Cells[3].Text = "TOTALS:";
            myDataGrid.FooterRow.Cells[4].Text = dDr.ToString("###,###.##");
            myDataGrid.FooterRow.Cells[5].Text = dCr.ToString("###,###.##");
            myDataGrid.FooterRow.Cells[6].Text = "Balance: " + (dDr - dCr).ToString("###,###.##");
        }
        }
        catch { }
    }

    private void bindGridUs()
    {
        string dcontractref = "";
        string dCnStr = Session["Cnn"].ToString();
        string thStart = Convert.ToDateTime(startdate.Value).ToString("dd/MMM/yyyy");
        string dstr = "";
        if (PropertyGroup.Text == "ALL" && dboContracts.Text == "ALL")
        {
           // dstr = "SELECT 'BAL' AS RefNo,'" + thStart + "' AS TransDate,'Balance B/F' AS [Source],'' AS Proxy,SUM(DR) as [Debit], SUM(CR) AS [Credit],'Balance B/F' AS Particulars,'' AS Property,'' AS [Contract Details] from dServiceChargeTransactionLedger WHERE (Proxy = 'US') AND TransDate<'" + Convert.ToDateTime(startdate.Value) + "'";
            dstr = "SELECT RefNo,TransDate,[Source],Proxy,DR as [Debit], CR AS [Credit],Particulars,ProductGroup + ' - ' + UnitDescription AS Property,ContractRef + ' - (' + ClientRefNo + ' - ' + ClientName+ ')' AS [Contract Details] from dServiceChargeTransactionLedger WHERE (Proxy = 'US') AND TransDate>='" + Convert.ToDateTime(startdate.Value) + "' AND TransDate<='" + Convert.ToDateTime(enddate.Value) + "' ORDER BY ProductGroup, ContractRef,TransDate,RefNo";
        }
        else if (dboContracts.Text == "ALL")
        {
            dstr = "SELECT RefNo,TransDate,[Source],Proxy,DR as [Debit], CR AS [Credit],Particulars,ProductGroup + ' - ' + UnitDescription AS Property,ContractRef + ' - (' + ClientRefNo + ' - ' + ClientName+ ')' AS [Contract Details] from dServiceChargeTransactionLedger WHERE (Proxy = 'US') AND TransDate>='" + Convert.ToDateTime(startdate.Value) + "' AND TransDate<='" + Convert.ToDateTime(enddate.Value) + "' AND   ProductGroup ='" + PropertyGroup.Text + "' order by TransDate,RefNo";
        }
        else
        {
            if (dboContracts.Text.Trim() == "")
                dcontractref = "SSSAAS@HHD!!!!!!:";
            else
                dcontractref = GetIt4Me(dboContracts.Text, " - (");
             dstr =  "SELECT 'BAL' AS RefNo,'" + thStart + "' AS TransDate,'Balance B/F' AS [Source],'' AS Proxy,ISNULL(SUM(DR),0) AS [Debit], ISNULL(SUM(CR),0) AS [Credit],'Balance B/F' AS Particulars,'' AS Property from dServiceChargeTransactionLedger WHERE (Proxy = 'US') AND TransDate <'" + Convert.ToDateTime(startdate.Value) + "' AND   ContractRef ='" + dcontractref + "' HAVING ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0)<>0";
            dstr = dstr +" UNION SELECT RefNo,TransDate,[Source],Proxy,DR as [Debit], CR AS [Credit],Particulars,ProductGroup + ' - ' + UnitDescription AS Property from dServiceChargeTransactionLedger WHERE (Proxy = 'US') AND TransDate>='" + Convert.ToDateTime(startdate.Value) + "' AND TransDate<='" + Convert.ToDateTime(enddate.Value) + "' AND   ContractRef ='" + dcontractref + "' order by TransDate,RefNo";
        }


        //  HttpContext.Current.Response.Write("<script language=javascript>alert('" + dcontractref + "');</script>");

        SqlDataAdapter da = new SqlDataAdapter(dstr, dCnStr);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(dt);
        // da.Fill(ds, "dServiceCharge");
        myDataGridUs.DataSource = dt; // ds.Tables["dServiceCharge"].DefaultView;
        myDataGridUs.DataBind();

        //ViewState["dirState"] = dt;
        //ViewState["sortdr"] = "Asc";


        try
        {
            double dDr = 0;
        double dCr = 0;

        for (int i = 0; i < myDataGridUs.Rows.Count; i++)
        {
            dDr = dDr + Convert.ToDouble(myDataGridUs.Rows[i].Cells[4].Text);
            dCr = dCr + Convert.ToDouble(myDataGridUs.Rows[i].Cells[5].Text);

            myDataGridUs.Rows[i].Cells[1].Text = Convert.ToDateTime(myDataGridUs.Rows[i].Cells[1].Text).ToString("dd/MMM/yyyy");
            myDataGridUs.Rows[i].Cells[4].Text = Convert.ToDouble(myDataGridUs.Rows[i].Cells[4].Text).ToString("###,###.##");
            myDataGridUs.Rows[i].Cells[5].Text = Convert.ToDouble(myDataGridUs.Rows[i].Cells[5].Text).ToString("###,###.##");

        }
        if (myDataGridUs.Rows.Count > 0)
        {
            myDataGridUs.FooterRow.Cells[3].Text = "TOTALS:";
            myDataGridUs.FooterRow.Cells[4].Text = dDr.ToString("###,###.##");
            myDataGridUs.FooterRow.Cells[5].Text = dCr.ToString("###,###.##");
            myDataGridUs.FooterRow.Cells[6].Text = "Balance: " + (dDr - dCr).ToString("###,###.##");
        }
        }
        catch { }
    }

    private void bindGridProxy()
    {
        string dcontractref = "";
        string dCnStr = Session["Cnn"].ToString();
        string thStart = Convert.ToDateTime(startdate.Value).ToString("dd/MMM/yyyy");
        string dstr = "";
    //  HttpContext.Current.Response.Write("<script language=javascript>alert('" + cboProxy.Text + "');</script>");
        if (!(cboProxy.Text=="ALL" || cboProxy.Text.Trim() == ""))
        {
            if (PropertyGroup.Text == "ALL" && dboContracts.Text == "ALL")
                dstr = "SELECT RefNo,TransDate,[Source],Proxy,DR as [Debit], CR AS [Credit],Particulars,ProductGroup + ' - ' + UnitDescription AS Property,ContractRef + ' - (' + ClientRefNo + ' - ' + ClientName+ ')' AS [Contract Details] from dServiceChargeTransactionLedger WHERE Proxy = '" + cboProxy.Text + "' AND TransDate>='" + Convert.ToDateTime(startdate.Value) + "' AND TransDate<='" + Convert.ToDateTime(enddate.Value) + "' ORDER BY ProductGroup, ContractRef,Proxy,TransDate,RefNo";
            else if (dboContracts.Text == "ALL")
            {
                dstr = "SELECT RefNo,TransDate,[Source],Proxy,DR as [Debit], CR AS [Credit],Particulars,ProductGroup + ' - ' + UnitDescription AS Property,ContractRef + ' - (' + ClientRefNo + ' - ' + ClientName+ ')' AS [Contract Details] from dServiceChargeTransactionLedger WHERE Proxy = '" + cboProxy.Text + "' AND TransDate>='" + Convert.ToDateTime(startdate.Value) + "' AND TransDate<='" + Convert.ToDateTime(enddate.Value) + "' AND   ProductGroup ='" + PropertyGroup.Text + "' order by Proxy, TransDate,RefNo";
            }
            else
            {
                if (dboContracts.Text.Trim() == "")
                    dcontractref = "SSSAAS@HHD!!!!!!:";
                else
                    dcontractref = GetIt4Me(dboContracts.Text, " - (");
                dstr = "SELECT 'BAL' AS RefNo,'" + thStart + "' AS TransDate,'Balance B/F' AS [Source],'' AS Proxy,ISNULL(SUM(DR),0) AS [Debit], ISNULL(SUM(CR),0) AS [Credit],'Balance B/F' AS Particulars,'' AS Property from dServiceChargeTransactionLedger WHERE Proxy = '" + cboProxy.Text + "' AND TransDate <'" + Convert.ToDateTime(startdate.Value) + "' AND   ContractRef ='" + dcontractref + "' HAVING ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0)<>0";

                dstr = dstr + " UNION SELECT RefNo,TransDate,[Source],Proxy,DR as [Debit], CR AS [Credit],Particulars,ProductGroup + ' - ' + UnitDescription AS Property from dServiceChargeTransactionLedger WHERE Proxy = '" + cboProxy.Text + "' AND TransDate>='" + Convert.ToDateTime(startdate.Value) + "' AND TransDate<='" + Convert.ToDateTime(enddate.Value) + "' AND   ContractRef ='" + dcontractref + "' order by Proxy, TransDate,RefNo";
            }

        }
        else
        {
            if (PropertyGroup.Text == "ALL" && dboContracts.Text == "ALL")
                dstr = "SELECT RefNo,TransDate,[Source],Proxy,DR as [Debit], CR AS [Credit],Particulars,ProductGroup + ' - ' + UnitDescription AS Property,ContractRef + ' - (' + ClientRefNo + ' - ' + ClientName+ ')' AS [Contract Details] from dServiceChargeTransactionLedger WHERE NOT (Proxy = 'US' or Proxy='Client') AND TransDate>='" + Convert.ToDateTime(startdate.Value) + "' AND TransDate<='" + Convert.ToDateTime(enddate.Value) + "' ORDER BY ProductGroup, ContractRef,Proxy,TransDate,RefNo";
            else if (dboContracts.Text == "ALL")
            {
                dstr = "SELECT RefNo,TransDate,[Source],Proxy,DR as [Debit], CR AS [Credit],Particulars,ProductGroup + ' - ' + UnitDescription AS Property,ContractRef + ' - (' + ClientRefNo + ' - ' + ClientName+ ')' AS [Contract Details] from dServiceChargeTransactionLedger WHERE NOT (Proxy = 'US' or Proxy='Client') AND TransDate>='" + Convert.ToDateTime(startdate.Value) + "' AND TransDate<='" + Convert.ToDateTime(enddate.Value) + "' AND   ProductGroup ='" + PropertyGroup.Text + "' order by Proxy, TransDate,RefNo";
            }
            else
            {
                if (dboContracts.Text.Trim() == "")
                    dcontractref = "SSSAAS@HHD!!!!!!:";
                else
                    dcontractref = GetIt4Me(dboContracts.Text, " - (");
                dstr = "SELECT 'BAL' AS RefNo,'" + thStart + "' AS TransDate,'Balance B/F' AS [Source],'' AS Proxy,ISNULL(SUM(DR),0) AS [Debit], ISNULL(SUM(CR),0) AS [Credit],'Balance B/F' AS Particulars,'' AS Property from dServiceChargeTransactionLedger WHERE NOT (Proxy = 'US' or Proxy='Client') AND TransDate <'" + Convert.ToDateTime(startdate.Value) + "' AND   ContractRef ='" + dcontractref + "' HAVING ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0)>0";

                dstr = dstr + "UNION SELECT RefNo,TransDate,[Source],Proxy,DR as [Debit], CR AS [Credit],Particulars,ProductGroup + ' - ' + UnitDescription AS Property from dServiceChargeTransactionLedger WHERE NOT (Proxy = 'US' or Proxy='Client') AND TransDate>='" + Convert.ToDateTime(startdate.Value) + "' AND TransDate<='" + Convert.ToDateTime(enddate.Value) + "' AND   ContractRef ='" + dcontractref + "' order by Proxy, TransDate,RefNo";
            }
        }

        SqlDataAdapter da = new SqlDataAdapter(dstr, dCnStr);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(dt);
        // da.Fill(ds, "dServiceCharge");
        myDataGridProxy.DataSource = dt; // ds.Tables["dServiceCharge"].DefaultView;
        myDataGridProxy.DataBind();

        //ViewState["dirState"] = dt;
        //ViewState["sortdr"] = "Asc";

        try
        {

            double dDr = 0;
            double dCr = 0;

            for (int i = 0; i < myDataGridProxy.Rows.Count; i++)
            {
                dDr = dDr + Convert.ToDouble(myDataGridProxy.Rows[i].Cells[4].Text);
                dCr = dCr + Convert.ToDouble(myDataGridProxy.Rows[i].Cells[5].Text);

                myDataGridProxy.Rows[i].Cells[1].Text = Convert.ToDateTime(myDataGridProxy.Rows[i].Cells[1].Text).ToString("dd/MMM/yyyy");
                myDataGridProxy.Rows[i].Cells[4].Text = Convert.ToDouble(myDataGridProxy.Rows[i].Cells[4].Text).ToString("###,###.##");
                myDataGridProxy.Rows[i].Cells[5].Text = Convert.ToDouble(myDataGridProxy.Rows[i].Cells[5].Text).ToString("###,###.##");

            }
            if (myDataGridProxy.Rows.Count > 0)
            {
                myDataGridProxy.FooterRow.Cells[3].Text = "TOTALS:";
                myDataGridProxy.FooterRow.Cells[4].Text = dDr.ToString("###,###.##");
                myDataGridProxy.FooterRow.Cells[5].Text = dCr.ToString("###,###.##");
                myDataGridProxy.FooterRow.Cells[6].Text = "Balance: " + (dDr - dCr).ToString("###,###.##");
            }
        }
        catch { }

    }

    public void load_click(object sender, EventArgs e)
    {

            bindGrid();

    }


    protected void myDataGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["dirState"];
        if (dtrslt.Rows.Count > 0)
        {
            if (Convert.ToString(ViewState["sortdr"]) == "Asc")
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                ViewState["sortdr"] = "Desc";
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                ViewState["sortdr"] = "Asc";
            }
            myDataGrid.DataSource = dtrslt;
            myDataGrid.DataBind();


        }

        //  HttpContext.Current.Response.Write("<script language=javascript>alert('" + e.SortExpression + "');</script>");

    }


    private void FetchContractsInPropertyGroup(string dPropertyGroup)
    {
        try
        {


          //   HttpContext.Current.Response.Write("<script language=javascript>alert('" + dPropertyGroup + "');</script>");

            dboContracts.Items.Clear();
            if (dPropertyGroup == "") return;

            if (!Page.IsPostBack)
                dboContracts.Items.Add("");

          //  dboContracts.Items.Add("ALL");

            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            string dp="";

            // cmSQL.CommandText = "SELECT * FROM dTransaction where RefNo IN (SELECT DISTINCT ContractRef FROM dServiceChargeTransactionLedger) AND (Active=1 OR RefNo IN (SELECT ContractRef FROM dServiceChargeBalances WHERE DR<>CR)) AND ProductGroup='" + dPropertyGroup + "' ORDER BY RefNo ASC";
            cmSQL.CommandText = "SELECT DISTINCT ContractRef,ClientRefNo,ClientName FROM dServiceChargeTransactionLedger where ProductGroup='" + dPropertyGroup + "' ORDER BY ContractRef ASC";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            while (drSQL.Read() == true)
            {
                dp = drSQL["ContractRef"].ToString() + " - (" + drSQL["ClientRefNo"].ToString() + " - " + drSQL["ClientName"].ToString() + ")";
                dboContracts.Items.Add(dp);

            }
            cmSQL.Connection.Close();
            cmSQL.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();
            if (PropertyGroup.Text == "ALL")
            {
                dboContracts.Items.Clear();
                dboContracts.Items.Add("ALL");
            }
            else
            {
                dboContracts.Items.Add("ALL");
            }
            try
            {
                dboContracts.SelectedIndex = 0;
            }
            catch { }

             //bindGrid();
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
            PropertyGroup.Items.Clear();
            dboContracts.Items.Clear();

            cmSQL.CommandText = "SELECT DISTINCT ProductGroup FROM dServiceChargeTransactionLedger  order by ProductGroup ASC";
           // cmSQL.CommandText = "SELECT DISTINCT ProductGroup FROM dTransaction where ProductGroup IN (SELECT DISTINCT ProductGroup FROM dServiceChargeTransactionLedger) AND (Active=1 OR ProductGroup IN (SELECT DISTINCT ProductGroup FROM dServiceChargeBalances WHERE DR<>CR))  order by ProductGroup ASC"; 
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

            PropertyGroup.Items.Add("ALL");

            FetchContractsInPropertyGroup(PropertyGroup.Text);



        }
        catch (Exception ex)
        {
            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
        }
    }


    private void FetchProxy()
    {
        try
        {
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;

            cboProxy.Items.Clear();
            cboProxy.Items.Add("ALL");
            cmSQL.CommandText = "SELECT DISTINCT Proxy FROM dServiceChargeTransactionLedger WHERE Proxy<>'Us' and Proxy<>'Client' order by Proxy ASC";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            while (drSQL.Read() == true)
            {
              
                cboProxy.Items.Add(drSQL["Proxy"].ToString());

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



    private void FetchClientBalance()
    {
        try
        {
         
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;


            if (PropertyGroup.Text == "ALL" && dboContracts.Text == "ALL")
                cmSQL.CommandText = "SELECT ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0) AS [Balance] FROM dServiceChargeBalances";
            else if (dboContracts.Text == "ALL")
            {
                  cmSQL.CommandText = "SELECT ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0) AS [Balance] FROM dServiceChargeBalances WHERE ProductGroup ='" + PropertyGroup.Text + "'";
            }
         else
            {
                string dcontractref = "";

                if (dboContracts.Text.Trim() == "")
                    dcontractref = "SSSAAS@HHD!!!!!!:";
                else
                    dcontractref = GetIt4Me(dboContracts.Text, " - (");

                cmSQL.CommandText = "SELECT ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0) AS [Balance] FROM dServiceChargeBalances where ContractRef='" + dcontractref + "'";
            }
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();

            if (drSQL.HasRows)
            {
                if (drSQL.Read())
                {
                    if (Convert.ToDecimal(drSQL["Balance"]) == 0)
                        ClientAcct.InnerText = "0.0";
                    else
                   ClientAcct.InnerText =Convert.ToDecimal( drSQL["Balance"]).ToString("###,###.##");
              
                }
            }
            else
            {
                ClientAcct.InnerText =  "0.0";
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

    private void FetchBalanceWithUS()
    {
        try
        {

            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;


            if (PropertyGroup.Text == "ALL" && dboContracts.Text == "ALL")
                cmSQL.CommandText = "SELECT ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0) AS [Balance] FROM dServiceChargeTransactionLedger WHERE Proxy='Us'";
            else if (dboContracts.Text == "ALL")
            {
                cmSQL.CommandText = "SELECT ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0) AS [Balance] FROM dServiceChargeTransactionLedger WHERE Proxy='Us' AND ProductGroup ='" + PropertyGroup.Text + "'";
            }
            else
            {
                string dcontractref = "";

                if (dboContracts.Text.Trim() == "")
                    dcontractref = "SSSAAS@HHD!!!!!!:";
                else
                    dcontractref = GetIt4Me(dboContracts.Text, " - (");

                cmSQL.CommandText = "SELECT ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0) AS [Balance] FROM dServiceChargeTransactionLedger where Proxy='Us' AND ContractRef='" + dcontractref + "'";
            }
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();

            if (drSQL.HasRows)
            {
                if (drSQL.Read())
                {
                    if (Convert.ToDecimal(drSQL["Balance"]) == 0)
                        OurAcct.InnerText = "0.0";
                    else
                        OurAcct.InnerText = Convert.ToDecimal(drSQL["Balance"]).ToString("###,###.##");

                }
            }
            else
            {
                OurAcct.InnerText = "0.0";
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

    private void FetchBalanceWithProxy()
    {
        try
        {

            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;

            if (cboProxy.Text == "ALL" || cboProxy.Text.Trim() == "")
            {

                if (PropertyGroup.Text == "ALL" && dboContracts.Text == "ALL")
                    cmSQL.CommandText = "SELECT ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0) AS [Balance] FROM dServiceChargeTransactionLedger WHERE NOT (Proxy = 'US' or Proxy='Client') ";
                else if (dboContracts.Text == "ALL")
                {
                    cmSQL.CommandText = "SELECT ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0) AS [Balance] FROM dServiceChargeTransactionLedger WHERE NOT (Proxy = 'US' or Proxy='Client')  AND ProductGroup ='" + PropertyGroup.Text + "'";
                }
                else
                {
                    string dcontractref = "";

                    if (dboContracts.Text.Trim() == "")
                        dcontractref = "SSSAAS@HHD!!!!!!:";
                    else
                        dcontractref = GetIt4Me(dboContracts.Text, " - (");

                    cmSQL.CommandText = "SELECT ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0) AS [Balance] FROM dServiceChargeTransactionLedger where NOT (Proxy = 'US' or Proxy='Client')  AND ContractRef='" + dcontractref + "'";
                }
            }
            else
            {
                if (PropertyGroup.Text == "ALL" && dboContracts.Text == "ALL")
                    cmSQL.CommandText = "SELECT ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0) AS [Balance] FROM dServiceChargeTransactionLedger WHERE Proxy='" + cboProxy.Text + "'";
                else if (dboContracts.Text == "ALL")
                {
                    cmSQL.CommandText = "SELECT ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0) AS [Balance] FROM dServiceChargeTransactionLedger WHERE Proxy='" + cboProxy.Text + "' AND ProductGroup ='" + PropertyGroup.Text + "'";
                }
                else
                {
                    string dcontractref = "";

                    if (dboContracts.Text.Trim() == "")
                        dcontractref = "SSSAAS@HHD!!!!!!:";
                    else
                        dcontractref = GetIt4Me(dboContracts.Text, " - (");

                    cmSQL.CommandText = "SELECT ISNULL(SUM(DR),0)-ISNULL(SUM(CR),0) AS [Balance] FROM dServiceChargeTransactionLedger where Proxy='" + cboProxy.Text + "' AND ContractRef='" + dcontractref + "'";
                }
            }

            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();

            if (drSQL.HasRows)
            {
                if (drSQL.Read())
                {
                    if (Convert.ToDecimal(drSQL["Balance"]) == 0)
                        ProxyAcct.InnerText = "0.0";
                    else
                        ProxyAcct.InnerText = Convert.ToDecimal(drSQL["Balance"]).ToString("###,###.##");

                }
            }
            else
            {
                ProxyAcct.InnerText = "0.0";
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

    protected void dboContracts_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindGrid();
       
    }

    protected void PropertyGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        FetchContractsInPropertyGroup(PropertyGroup.Text);
        bindGrid();
    }



    protected void cboProxy_SelectedIndexChanged(object sender, EventArgs e)
    {

        bindGridProxy();
        FetchBalanceWithProxy();
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