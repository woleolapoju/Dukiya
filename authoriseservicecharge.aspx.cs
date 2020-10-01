using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class authoriseservicecharge : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            if (Session["UserID"].ToString() == null || Session["UserID"].ToString() == "")
            {
                Response.Redirect("Default.aspx", true);
            }

            if (FetchUserAccess(Session["UserID"].ToString(), "Authorise Service Charge", Session["Cnn"].ToString()) == false)
                ClientScript.RegisterStartupScript(this.GetType(), "goBack", "history.go(-1);", true);

            if (!Page.IsPostBack)
            {
                bindGrid();
            }

        }
        catch (Exception ex)
        {
            Session["exception"] = ex.Message;
            //"Object reference" not set to an instance of an object"
            if ( ex.Message.StartsWith("Object reference") == true || ex.Message.StartsWith("Thread was being aborted") == true)
                Response.Redirect("Default.aspx");
            else
                Response.Redirect("Error.aspx");
        }
    }

    private void bindGrid()
{
    string dCnStr = Session["Cnn"].ToString();
    SqlDataAdapter da = new SqlDataAdapter("SELECT RefNo,TransDate,Source,Proxy,Amount,OurComponent,Particulars,ContractRef,ClientRefNo,ClientName,ProductGroup,UnitDescription,Beneficiary,PVNo,TransferToContractRef + ' - '+TransferToClientDetails  AS [Transfered To],UserName AS [Entered By] from dServiceCharge WHERE Authorise=0", dCnStr);
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    da.Fill(dt);
    // da.Fill(ds, "dServiceCharge");
    myDataGrid.DataSource = dt; // ds.Tables["dServiceCharge"].DefaultView;
    myDataGrid.DataBind();

    ViewState["dirState"] = dt;
    ViewState["sortdr"] = "Asc";

    foreach (DataGridItem dataGridItem in myDataGrid.Items)
    {

        dataGridItem.Cells[2].Text = Convert.ToDateTime(dataGridItem.Cells[2].Text).ToString("dd/MMM/yyyy");
        dataGridItem.Cells[5].Text = Convert.ToDouble(dataGridItem.Cells[5].Text).ToString("###,###.##");
            dataGridItem.Cells[6].Text = Convert.ToDouble(dataGridItem.Cells[6].Text).ToString("###,###.##");
        }


}

public void authoriseBtn_click(object sender, EventArgs e)
{

        try
        {

            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            cnSQL.Open();

            SqlTransaction myTrans;
            myTrans = cnSQL.BeginTransaction();
            cmSQL.Transaction = myTrans;

            foreach (DataGridItem di in myDataGrid.Items)
            {
                HtmlInputCheckBox chkBx = (HtmlInputCheckBox)di.FindControl("EmpId");
                if (chkBx != null && chkBx.Checked)
                {
                    cmSQL.CommandText = "UPDATE dServiceCharge SET Authorise=1,AuthorisedBy='" + Session["username"].ToString() + "' WHERE RefNo='" + di.Cells[1].Text + "'";
                    cmSQL.CommandType = System.Data.CommandType.Text;
                    cmSQL.ExecuteNonQuery();

                }

            }

            
            myTrans.Commit();

            cmSQL.Dispose();
            cnSQL.Close();

            bindGrid();


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