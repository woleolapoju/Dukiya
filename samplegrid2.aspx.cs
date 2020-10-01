using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class samplegrid2 : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter adp;
    SqlDataReader rd;
    DataSet ds;
    string query;

    public void dbcon()
    {
        string connn = (System.Configuration.ConfigurationManager.ConnectionStrings["CnStr"].ToString());
        con = new SqlConnection(connn);
        con.Open();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind11();
        }
    }


    protected void bind11()
    {
        dbcon();
   
        string query = "";
            query = "SELECT LabourDescr, HoursRequired ,AmountRequired FROM dWorkorderDetails where RefNo='WKO_004'";
      
     //   string constr = Session["Cnn"].ToString();

        cmd = new SqlCommand(query, con);
        adp = new SqlDataAdapter(cmd);
        ds = new DataSet();
        adp.Fill(ds);
        rd = cmd.ExecuteReader();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Gridview1.DataSource = ds;
            Gridview1.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            Gridview1.DataSource = ds;
            Gridview1.DataBind();
            int columncount = Gridview1.Rows[0].Cells.Count;
            Gridview1.Rows[0].Cells.Clear();
            // GridView1.FooterRow.Cells.Clear();
            Gridview1.Rows[0].Cells.Add(new TableCell());
            Gridview1.Rows[0].Cells[0].ColumnSpan
 = columncount;
            Gridview1.Rows[0].Cells[0].Text = "No Records Found";
        }
    }


    protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {

//        TextBox txtNamee = (TextBox)Gridview1.FooterRow.
//FindControl("txtName");
//        TextBox txtEmaill = (TextBox)Gridview1.FooterRow.
//FindControl("txtEmailID");
//        TextBox txtCity = (TextBox)Gridview1.FooterRow.
//FindControl("txtCity");

//        dbcon();
//        query = "insert into grid (name,email,city)values('" + txtNamee.Text + "',
//'"+txtEmaill.Text+"','"+txtCity.Text+"')";
//        cmd = new SqlCommand(query, con);
//        cmd.ExecuteNonQuery();
//        con.Close();

//        bind11();
    }

}
