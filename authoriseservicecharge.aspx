<%@ Page Language="C#" AutoEventWireup="true" CodeFile="authoriseservicecharge.aspx.cs" Inherits="authoriseservicecharge" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Dukiya-Property Manager</title>
<link rel="shortcut icon" href="/images/appicon.ico"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" content="Property Management System" />
<meta name="keywords" content="Dukiya,MegaHit Systems,StackLogic Systems,Property Management Solution," />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<!-- bootstrap-css -->
<link rel="stylesheet" href="css/Dashboard/bootstrap.min.css"/>
<!-- //bootstrap-css -->
<!-- Custom CSS -->
<%--<link href="css/Dashboard/style.css" rel='stylesheet' type='text/css' />
<link href="css/Dashboard/style-responsive.css" rel="stylesheet"/>--%>
<!-- font CSS -->
<link href='//fonts.googleapis.com/css?family=Roboto:400,100,100italic,300,300italic,400italic,500,500italic,700,700italic,900,900italic' rel='stylesheet' type='text/css'/>
<!-- font-awesome icons -->
<link rel="stylesheet" href="css/Dashboard/font.css" type="text/css"/>
<link href="css/Dashboard/font-awesome.css" rel="stylesheet"/> 
<link rel="stylesheet" href="css/Dashboard/morris.css" type="text/css"/>

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>

<!-- //calendar -->
<!-- //font-awesome icons -->
<script src="js/Dashboard/jquery2.0.3.min.js"></script>
<script src="js/Dashboard/raphael-min.js"></script>
<script src="js/Dashboard/morris.js"></script>


    <style>
 body {
    font-family: 'Arsenal', sans-serif; 
	background:#fff; 
	background: url(images/bg.jpg)repeat 0px 0px;   
    background-size: cover;
    -webkit-background-size: cover;
    -moz-background-size: cover;
    -o-background-size: cover; 
	background-attachment: fixed;
    height:100%;
}
</style>

<%--for navbar--%>
<style>


.topnav {
  overflow: hidden;
  background-color: #333;
  position: relative;
}

.topnav #myLinks {
  display: none;
}

.topnav a {
  color: white;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
  display: block;
}

.topnav a.icon {
  background: black;
  display: block;
  position: absolute;
  right: 0;
  top: 0;
}

.topnav a:hover {
  background-color: #ddd;
  color: black;
}

.active {
  background-color: #4CAF50;
  color: white;
}

</style>

   

</head>

<body>
 



<header  style="margin:0px;position: fixed; top: 0; width: 100%; background-color:black;z-index:100"  >

    <div class="brand" style="background-color:black;display:none">
    <a href="Default.aspx" title="click to sign out" >
        <img src="images/applogo_black.png" style="margin-right:20px;margin-top:5px;padding:0px" />
    </a>

        </div>
        
<div class="nav notify-row" id="top_menu" style="margin:0px; " >
    <table>
        <tr>
            <td>
                 <img src="images/applogo_black.png" style="margin-right:20px" />
            </td>
        

            <td >
                <a  style="font-size:xx-large"   href="MainStaff.aspx"><%-- class="dropdown-toggle col-md-3 "--%>
                    <h4 style="color:yellow">
                        <i class="fa fa-bars" ><span style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif">  MENU </span> </i>
                    </h4>
            </a>
            </td>
       
        </tr>
    </table>
  
   
</div>

</header >
<!--header end-->
    <section id="main-content"  style="margin-left:5px;margin-top:80px; z-index:90">
	<section class="wrapper">
    <form id="form1" runat="server" style="margin-top:10px;">


        	<%--<div class="agileits-w3layouts-stats">--%>

                       <%--  <div class="col-md-8 stats-info stats-last widget-shadow" id="WorkOrderList" runat="server">
                             	
					</div>--%>
<div>
     <div id="complaintdetails" class="modal-content" >  <%--style="display:none"--%>

                          <!-- Top Navigation Menu -->
<div class="topnav">
  <a href="#" id="SC" class="active">Service Charge Authorisation</a>
<%--  <div id="myLinks">
    <a href="#" id="ut" style="color:red">Utilization</a>
    <a href="#" id="OB">Opening Balance</a>
    <a href="#" id="RC">Receipt from Client</a>
    <a href="#" id="P2P">Payment to Proxy</a>
    <a href="#" id="PfromP">Payment From Proxy</a>
    <a href="#" id="BT">Balance Transfer</a>
    <a href="authoriseservicecharge.aspx" id="authorise">Authorise Transactions</a>
  </div>--%>
  <a href="javascript:void(0);" class="icon"  style="background-color:crimson">
    <i  style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;font-size:large" runat="server" onclick="myFunction()">Authorise</i>
  </a>
</div>


<script>
    function myFunction() {
        document.getElementById("authorisetrans").click();
    }
</script>

<div  style="vertical-align: top; height: 100%; overflow:auto;width:100%">

<ASP:DATAGRID id="myDataGrid" runat="server" HeaderStyle-BackColor="#aaaadd" Font-Size="8pt" Font-Name="Verdana" CellPadding="40" ItemStyle-Height="10px" ItemStyle-Wrap="true" ShowFooter="True" Width="100%"  AllowSorting="True"  OnSorting="myDataGrid_Sorting" ForeColor="#333333" GridLines="both">
				<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
				<EditItemStyle BackColor="#999999" />
				<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
				<AlternatingItemStyle BackColor="White" ForeColor="#284775" />
				<Columns>
					<asp:TemplateColumn HeaderText="contract">
						<HeaderTemplate >
							<input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll"/>
						</HeaderTemplate>
						<ItemTemplate >
							<input type="checkbox" runat="server" id="EmpId" onclick="CheckChanged();" checked='false' name="EmpId" />
						</ItemTemplate>
					</asp:TemplateColumn>
					<%--<asp:TemplateColumn HeaderText="Id">
						<ItemTemplate>
							<asp:Label id="Id" Text='<%# DataBinder.Eval(Container.DataItem, "RefNo") %>' runat="server" />
						</ItemTemplate>
					</asp:TemplateColumn>--%>
				<%--	<asp:BoundColumn DataField="FirstName" HeaderText="FirstName"></asp:BoundColumn>
					<asp:BoundColumn DataField="LastName" HeaderText="LastName"></asp:BoundColumn>
					<asp:BoundColumn DataField="Designation" HeaderText="Designation"></asp:BoundColumn>--%>
				</Columns>
			    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
			</ASP:DATAGRID>
              </div>
          
            <div class="form-group" style="margin-top:5px; display:none">

               <asp:Button id="authorisetrans" runat="server" OnClick="authoriseBtn_click" class="btn btn-danger"  Width="150px" style="margin-left:10px" Text="SAVE" />
                   
                <button type="button" onclick="showpicture()" id="showImage" class="btn btn-primary" style="float:right;margin-right:10px;width:70px">CLEAR</button>

            </div>
      </div>

    </div>

				<%--	</div>--%>

    </form>
        </section>
        
    <%--<div>
			<p style="text-align:center;  font-size:small;margin-right: auto;margin-left: auto; margin-top: 1em; margin-bottom: 0em">  <a href="http://www.stacklogicsystems.com" target="=_blank"> &copy; 2018 | Design by StackLogic Systems, Ltd.</a> <a href="http://w3layouts.com" target="=_blank" style="color:rgba(0, 0, 0, 0)">W3layouts</a></p>
	</div>--%>

        </section>


</body>

<script type="text/javascript" language="javascript">
function CheckAll(chk)
{

    all = document.getElementsByTagName("input");
   
for(i=0;i<all.length;i++)
{
      if(all[i].type=="checkbox" )
      {
        all[i].checked = chk.checked;
      }
    }
}
</script>


</html>
