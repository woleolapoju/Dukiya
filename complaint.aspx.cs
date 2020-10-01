using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class Complaint : System.Web.UI.Page
{
    public int eAutoID;
    public string eRefno;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {


            

            if (Session["ImagePath"].ToString() == "")
            {
                start_camera.Disabled = true;
                HttpContext.Current.Response.Write("<script language=javascript>alert('Image Path not set....photo cannot be taken!');</script>");
            }


            if (Session["UserID"].ToString() == null || Session["UserID"].ToString() == "")
            {
                Response.Redirect("Default.aspx", true);
            }


            //tclientref.Value = Session["ClientRef"].ToString() + " - " + Session["ClientName"].ToString();
            //tproperty.Value = Session["ClientProp"].ToString();
            lblusername.InnerText = Session["username"].ToString();
            lblClient.InnerText = Session["ClientRef"].ToString() + " - " + Session["ClientName"].ToString();
            lblproperty.InnerText = Session["ProductGroup"].ToString() + " - " + Session["UnitDescription"].ToString();


            //datepicker.Value = DateTime.Now.ToString("dd/MM/yyyy");

            FetchComplaintList();

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

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        FetchNextNo();

        try
        {

            if (tSelectedCom.Value == "" && tcomplaint.Value == "")
            {
                HttpContext.Current.Response.Write("<script language=javascript>alert('Pls choose or enter complaint details');</script>");
                return;
            }

            string selectedstr = "";
            if (tSelectedCom.Value != "")
            {
                selectedstr = tSelectedCom.Value;
                selectedstr = selectedstr + " @ " + '\r' + tcomplaint.Value;
            }

            string refno = "";
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
          
            cnSQL.Open();
            cmSQL.CommandText = "dInsertComplaint";
            cmSQL.CommandType = System.Data.CommandType.StoredProcedure;
            cmSQL.Parameters.AddWithValue("@RefNo", eRefno);
            cmSQL.Parameters.AddWithValue("@ContractRef", Session["ContractRefNo"].ToString());
            cmSQL.Parameters.AddWithValue("@ClientRefNo", Session["ClientRef"].ToString());
            cmSQL.Parameters.AddWithValue("@ClientName", Session["ClientName"].ToString());
            cmSQL.Parameters.AddWithValue("@ProductGroup", Session["ProductGroup"].ToString());
            cmSQL.Parameters.AddWithValue("@UnitDescription", Session["UnitDescription"].ToString());
            cmSQL.Parameters.AddWithValue("@Complaint", selectedstr);
            cmSQL.Parameters.AddWithValue("@ComplaintScope", RadioScopeList.SelectedValue);
            cmSQL.Parameters.AddWithValue("@AttentionLevel", ActionLevel.SelectedValue);
            
            cmSQL.Parameters.AddWithValue("@Username", Session["username"].ToString());
            cmSQL.Parameters.AddWithValue("@AutoID", eAutoID);

            cmSQL.Parameters.AddWithValue("@TransDate", DateTime.Now.ToString());
            cmSQL.ExecuteNonQuery();

           
            cmSQL.Dispose();
            cnSQL.Close();



            if (dImgPath.Value != "")  UploadImage(refno);

            tcomplaint.Value = "";
            dImgPath.Value = "";
            tSelectedCom.Value = "";
            RadioScopeList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
  
            HttpContext.Current.Response.Write("<script language=javascript>alert('" + ex.Message + "');</script>");
            //Response.Redirect("Error.aspx");
            //HttpContext.Current.Session["exception"] = ex.Message;
            //HttpContext.Current.Response.Redirect("Error.aspx");
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
            cmSQL.CommandText = "SELECT ISNULL(MAX(AutoID),0)+1 AS NewAutoID FROM dComplaint"; 
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



            eRefno = "COM_" + str3;
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



    private void FetchComplaintList()
    {
        try
        {
            string dCnStr = Session["Cnn"].ToString();
            SqlConnection cnSQL = new SqlConnection(dCnStr);
            SqlCommand cmSQL = cnSQL.CreateCommand();
            SqlDataReader drSQL = null;
            cmSQL.CommandText = "SELECT * FROM  dComplaintDesc order by Sn";
            cmSQL.CommandType = System.Data.CommandType.Text;
            cnSQL.Open();
            drSQL = cmSQL.ExecuteReader();
            string dDesc = "";
            int s = 0;
            while (drSQL.Read() == true)
            {
                s++;

                dDesc = drSQL["ComplaintDesc"].ToString();
                HtmlGenericControl ddiv = new HtmlGenericControl("DIV");
                ddiv.Attributes.Add("class", "checkbox");
                complaintlist.Controls.Add(ddiv);

                HtmlGenericControl dlabel = new HtmlGenericControl("label");
                dlabel.InnerText = dDesc;
                dlabel.ID = s.ToString() + "l";
                ddiv.Controls.Add(dlabel);


                HtmlGenericControl dinput = new HtmlGenericControl("input"); 
                dinput.Attributes.Add("type", "checkbox");
                dinput.Attributes.Add("name", "comcheck");
                dinput.Attributes.Add("onclick", "LoadSelection()");
                dinput.Attributes.Add("value", "");
                dinput.ID = s.ToString();
                dinput.Attributes.Add("title", dDesc);
                dlabel.Controls.Add(dinput);

                //HtmlGenericControl dlabel1 = new HtmlGenericControl("label");
                //dlabel1.InnerText = dDesc;
                //dinput.Controls.Add(dlabel1);

                HtmlGenericControl dynSpan = new HtmlGenericControl("span");
                dynSpan.Attributes.Add("class", "cr");
                dlabel.Controls.Add(dynSpan);


                HtmlGenericControl di = new HtmlGenericControl("i");
                di.Attributes.Add("class", "cr-icon glyphicon glyphicon-ok");
                //di.Attributes.Add("onclick", "LoadSelection()");
                dynSpan.Controls.Add(di);

            }


            cmSQL.Connection.Close();
            cmSQL.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();

            if (s == -1) complaintlist.Visible = false;


        }
        catch (Exception ex)
        {
            HttpContext.Current.Session["exception"] = ex.Message;
            HttpContext.Current.Response.Redirect("Error.aspx");
        }
    }

}