<%@ Page Language="C#" AutoEventWireup="true" CodeFile="workorderlistings.aspx.cs" Inherits="Workorderlisting" %>

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
<link href="css/Dashboard/style.css" rel='stylesheet' type='text/css' />
<link href="css/Dashboard/style-responsive.css" rel="stylesheet"/>
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
}
</style>
</head>

<body  onload="getclientdate()">

    <!--header start-->

     
   <%-- class="header fixed-top clearfix"--%>
         
<header  style="margin:0px;position: fixed; top: 0; width: 100%; background-color:black;z-index:100"  >

    <div class="brand" style="background-color:black;display:none">
    <a href="Default.aspx" title="click to sign out" >
        <img src="images/applogo_black.png" style="margin-right:20px;margin-top:5px;padding:0px" />
    </a>
    <%--<div class="sidebar-toggle-box">
        <div class="fa fa-bars"><span style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"> MENU1111</span></div>
    </div>--%>
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
    <section id="main-content"  style="margin-left:5px;margin-top:50px; z-index:90">
	<section class="wrapper">
    <form id="form1" runat="server" style="margin-top:20px;">


        	<div class="agileits-w3layouts-stats">

                         <div class="col-md-8 stats-info stats-last widget-shadow" id="WorkOrderList" runat="server">
						<div class="stats-last-agile">
                            <div class="stats-title">
								<h4 class="title">Work Order Listings</h4>
							</div>
							<table class="table stats-table ">
								<thead>
									<tr>
										<th>Ref.No</th>
										<th>PROPERTY</th>
										<th>STATUS</th>
										<th>PROGRESS</th>
                                        <th>Order Age</th>
									</tr>
								</thead>
								<tbody id="tblBody" runat="server">
									<%--<tr>
										<th scope="row" style="font-size:small;font-weight:400""><a href="workorder.aspx"> COM_001</a></th>
										<td>Palm Terraces-House 4</td>
										<td><span class="label label-success">Adv. Progress</span></td>
										<td><h5>85% <i class="fa fa-level-up"></i></h5></td>
                                        <td>2 days Ago</td>
                                            
									</tr>--%>
									
								</tbody>
							</table>
						</div>
					</div>


                <div class="col-md-4 stats-info widget">
					
                      <div id="complaintdetails" class="modal-content" >  <%--style="display:none"--%>
      <div class="modal-header" style="background-color:crimson;color:white">
        <h5 class="modal-title" id="exampleModalLabel">Workorder Details</h5>
       <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>--%>

      </div>
      <div class="modal-body">
          <div id="divComplaintDetails">
    
           <div class="form-group">
            <label for="dproperty" class="col-form-label">Property:</label>
            <input type="text"  readonly="true" class="form-control" id="dproperty" runat="server"/>
          </div>
           <div class="form-group">
            <label for="Contract_Details" class="col-form-label">Contract Details:</label>
            <input type="text"  readonly="true" class="form-control" id="Contract_Details" runat="server"/>
          </div>
               <div class="form-group"  id="divComplaintRef" runat="server" style="margin-top:0px;padding-top:0px" >
                    <label for="complaint_Ref" class="col-form-label">Complaint RefNo:</label>
                    <input type="text"  readonly="true" class="form-control" id="complaint_Ref" runat="server"/>
                 </div>

             <div class="form-group" style="display:inline-block">
               <table style="width:100%">
                   <tr>
                       <td>
                             <label for="startdate" class="col-form-label">Expected Startdate</label>
                            <input type="text"  readonly="true" class="form-control" id="startdate" runat="server"/>
                       </td>
                       <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                       <td >
                            <label for="enddate" class="col-form-label">Expected Enddate</label>
                            <input  type="text"  readonly="true" class="form-control" id="enddate"/>
                       </td>
                   </tr>
               </table>
         </div>
           <div class="form-group">
            <label for="TermOfService" class="col-form-label">Terms of Service:</label>
            <textarea class="form-control"  readonly="true" rows="3" id="TermOfService"></textarea>
          </div>
        <div class="form-group">
            <label for="workdetails" class="col-form-label">Work Description:</label>
            <textarea class="form-control"  readonly="true" rows="4" id="workdetails"></textarea>
         </div>

        <div class="form-group">
              <label for="supervisionteam" class="col-form-label">supervision Team:</label>
            <input type="text"  readonly="true" class="form-control" id="supervisionteam" runat="server"/>
         </div>
          
     
          <div class="form-group" style="display:inline-block">
               <table style="width:100%">
                   <tr>
                       <td>
                           
                          <label for="attentionlevel" class="col-form-label">Attention Level:</label>
                        <input type="text"  readonly="true" class="form-control" id="attentionlevel" runat="server"/>

                       </td>
                       <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                       <td >
                            <label for="workscope" class="col-form-label">Work Scope</label>
                            <input  type="text"  readonly="true" class="form-control" id="workscope" runat="server"/>
                       </td>
                   </tr>
               </table>
         </div>
        
           <br />
    <div style="overflow-x:auto;width:auto">
    <asp:GridView ID="gvCustomers" CssClass = "table" runat="server"  AutoGenerateColumns="false" BorderStyle="Solid" ShowFooter="true" SelectedRowStyle-Wrap="true" >
    <Columns>
        <asp:TemplateField HeaderText="Labour Description" ItemStyle-Width="525px" HeaderStyle-Font-Bold="true"   ItemStyle-Wrap="true">
            
            <ItemTemplate>
             <%# Eval("LabourDescr") %>
        
            </ItemTemplate>
              
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Hours" ItemStyle-Width="50px"  HeaderStyle-Font-Bold="true">
            <ItemTemplate>
                <%# Eval("HoursRequired")%>
            </ItemTemplate>
              
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount" ItemStyle-Width="80px"  HeaderStyle-Font-Bold="true">
            <ItemTemplate>
                <%# Eval("AmountRequired")%>
            </ItemTemplate>
             
        </asp:TemplateField>

    </Columns>
       
</asp:GridView>
   </div>


 <%--   </form>--%>
              </div>
          <div id="divPhoto" style="display:none">
              <img  style="width:100%;height:100%;max-height:410px"  id ="complaintPhoto" />

          </div>
            <div class="form-group" style="margin-top:5px">
                           <button type="button" onclick="showpicture()" id="showImage" class="btn btn-primary">View Image</button> 
               
                    <asp:Button ID="btnNewjoblog" runat="server" OnClick="btnNewjoblog_Click" class="btn btn-danger" Text="Create a Activity Log" />
                     
           
            </div>
      </div>
      <%--  <form runat="server">--%>
                  <div class="modal-footer">
                      <div style="display:none">
                            <label for="recipient-name" class="col-form-label">Ref No:</label>
                            <input type="text" runat="server" readonly="true" class="form-control" id="workorder_refno"/>
                    </div>
          
                  </div>
       <%-- </form>--%>
    </div>

					</div>
					<div class="clearfix"> </div>
				</div>

    </form>
        </section>
        </section>


 

</body>

    

     <script>
        function showpicture() {
            var x = document.getElementById("divPhoto");
            var y = document.getElementById("divComplaintDetails");
            if (x.style.display === "none") {
                x.style.display = "block";
                y.style.display = "none";
                document.getElementById("showImage").innerText = "Hide Image";
            } else {
                x.style.display = "none";
                y.style.display = "block";
                document.getElementById("showImage").innerText = "View Image";
            }
        }

      

    </script>


      <script type='text/javascript'>
 
        function getclientdate() {
         
            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth(); //January is 0!
            var yyyy = today.getFullYear();
            var hours = today.getHours();
            var minutes = today.getMinutes();
            var seconds = today.getSeconds();

            if (dd < 10) {
                dd = '0' + dd
            }

            var months = new Array(12);
            months[0] = "January";
            months[1] = "February";
            months[2] = "March";
            months[3] = "April";
            months[4] = "May";
            months[5] = "June";
            months[6] = "July";
            months[7] = "August";
            months[8] = "September";
            months[9] = "October";
            months[10] = "November";
            months[11] = "December";

            var formatted = dd + "-" + months[mm] + "-" + yyyy + " " + hours + ":" + minutes + ":" + seconds;
            setCookie("currentclientdate", formatted, 365);          
        }

        function setCookie(cname, cvalue, exdays) {
            var d = new Date();
            d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
            var expires = "expires=" + d.toGMTString();
            document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
        }

  
</script>

    <script>

     
        $("#tblBody").click(function (event) {

           // var x = document.getElementById("complaintdetails");
            // x.style.display = "block";
        
            var button = event.target;
            var recipient = button.title;  
            if (recipient = button.id) {
              //document.getElementById("RefNo").Text = recipient;
                //   button.click();


                document.getElementById("exampleModalLabel").innerHTML = "Workorder RefNo: " + recipient + " (made by:-" + document.getElementById(recipient + "k").value + ")";

                document.getElementById("workorder_refno").value = recipient;
              
                document.getElementById("dproperty").value = document.getElementById(recipient + "a").value;
               
                document.getElementById("Contract_Details").value = document.getElementById(recipient + "d").value;
                document.getElementById("startdate").value = document.getElementById(recipient + "f").value;
                document.getElementById("enddate").value = document.getElementById(recipient + "g").value;
                document.getElementById("TermOfService").value = document.getElementById(recipient + "i").value;
                document.getElementById("workdetails").value = document.getElementById(recipient + "b").value;
                document.getElementById("supervisionteam").value = document.getElementById(recipient + "h").value;
                document.getElementById("attentionlevel").value = document.getElementById(recipient + "j").value;
                document.getElementById("workscope").value = document.getElementById(recipient + "c").value;
                document.getElementById("complaint_Ref").value = document.getElementById(recipient + "m").value;

                if (document.getElementById(recipient + "m").value == "") 
                    document.getElementById("divComplaintRef").style.display = "none";
                else
                    document.getElementById("divComplaintRef").style.display = "block";

             
               $("#complaintPhoto").attr("src", document.getElementById(recipient + "l").value);
              
            }
            else
                return;

        });


    </script>
 

</html>
