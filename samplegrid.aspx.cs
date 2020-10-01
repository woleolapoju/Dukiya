using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.SqlClient;

public partial class samplegrid : System.Web.UI.Page
{

    SqlDataAdapter da = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("ID"), new DataColumn("ProductName"), new DataColumn("Price"), new DataColumn("Quantity") });
            dt.Rows.Add(1, "FootBall", 500, 10);
            dt.Rows.Add(2, "T-Shirt", 400, 0);
            dt.Rows.Add(3, "Jeans", 1200, 25);
            dt.Rows.Add(4, "Shirt", 650, 15);
            dt.Rows.Add(5, "VolleyBall", 700, 0);
            dt.Rows.Add(6, "X-Box", 25000, 36);
            dt.Rows.Add(7, "PlayStation 4", 50000, 20);
            dt.Rows.Add(8, "Oven", 12000, 30);
            dt.Rows.Add(9, "Cricket-Bat", 3200, 0);
            dt.Rows.Add(10, "Cricket-Ball", 530, 15);
            gvData.DataSource = dt;
            gvData.DataBind();
        }
    }

   
}