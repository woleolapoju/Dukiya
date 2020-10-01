<%@ Page Language="C#" AutoEventWireup="true" CodeFile="complaintlistforinspection.aspx.cs" Inherits="complaintlistforinspection" %>


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

<body onload="getclientdate()">

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
	                 <div class="col-md-6 w3agile-notifications" id="complaintList" runat="server">
                         <div class="notifications" style="opacity:0.9">
				<!--notification start-->
				
					<header class="panel-heading">
					Complaints for Inspections
					</header>
					<div class="notify-w3ls" id="divComplaints" runat="server">
					<%--	<div class="alert alert-info clearfix">
							<span class="alert-icon"><i class="fa fa-envelope-o"></i></span>
							<div class="notification-info">
								<ul class="clearfix notification-meta">
									<li class="pull-left notification-sender"><span><a href="#">Jonathan Smith</a></span> send you a mail </li>
									<li class="pull-right notification-time">1 min ago</li>
								</ul>
								<p>
									Urgent meeting for next proposal
                                   
								</p>
							</div>
						</div>--%>
					</div>
				</div>
				<!--notification end-->
				</div>

                <div class="col-md-4 stats-info widget">
					
                      <div id="complaintdetails" class="modal-content" >  <%--style="display:none"--%>
      <div class="modal-header" style="background-color:crimson;color:white">
        <h5 class="modal-title" id="exampleModalLabel">Complaint Details</h5>
       <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>--%>

      </div>
      <div class="modal-body">
          <div id="divComplaintDetails">
     <%--   <form>--%>
           <div class="form-group">
              <label for="contract_ref" class="col-form-label">Contract RefNo:</label>
            <input type="text"  readonly="true" class="form-control" id="contract_ref" runat="server"/>
          </div>
          <div class="form-group">
              <label for="client_name" class="col-form-label">Client:</label>
            <input type="text"  readonly="true" class="form-control" id="client_name" runat="server"/>
          </div>
     
           <div class="form-group">
            <label for="property_name" class="col-form-label">Property:</label>
            <input type="text"  readonly="true" class="form-control" id="property_name" runat="server"/>
          </div>
          <div class="form-group">
            <label for="complaint_text" class="col-form-label">Complaints:</label>
            <textarea class="form-control"  readonly="true" rows="6" id="complaint_text"></textarea>
          </div>
           <div class="form-group" style="display:inline-block">
               <table style="width:100%">
                   <tr>
                       <td>
                             <label for="Scope_name" class="col-form-label">Scope:</label>
                            <input type="text"  readonly="true" class="form-control" id="Scope_name" runat="server"/>
                       </td>
                       <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                       <td >
                            <label for="time_date" class="col-form-label">Date/Time:</label>
                            <input  type="text"  readonly="true" class="form-control" id="time_date"/>
                       </td>
                   </tr>
               </table>
          
            
          </div>
          
       <%-- </form>--%>
              </div>
          <div id="divPhoto" style="display:none">
              <img  style="width:100%;height:100%;max-height:410px"  id ="complaintPhoto" />

          </div>
            <div class="form-group" style="margin-top:5px">
                           <button type="button" onclick="showpicture()" id="showImage" class="btn btn-primary">View Image</button> <br /> <br />
                          <asp:Button ID="btnNewInspection" runat="server" OnClick="btnNewInspection_Click" class="btn btn-danger" Text="Inspection of Complaint" />
                          <asp:Button ID="btnBasicInspection" runat="server" OnClick="btnBasicInspection_Click" class="btn btn-danger" Text="Basic Inspection" />
             
            </div>
      </div>
      <%--  <form runat="server">--%>
                  <div class="modal-footer">
                      <div style="display:none">
                            <label for="recipient-name" class="col-form-label">Ref No:</label>
                            <input type="text" runat="server" readonly="true" class="form-control" id="Complaint_refno"/>
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

     
        $("#divComplaints").click(function (event) {

           // var x = document.getElementById("complaintdetails");
            // x.style.display = "block";

            var elmnt = document.getElementById("complaintdetails");
            elmnt.scrollIntoView();

            var button = event.target;
            var recipient = button.title;  //.id
    
            document.getElementById("exampleModalLabel").innerHTML = "Complaint RefNo: " + recipient + " (made by:-" + document.getElementById(recipient + "c").value + ")";

            document.getElementById("Complaint_refno").value = recipient;

            //document.getElementById("Complaint_name").value = document.getElementById(recipient + "c").value;
            document.getElementById("client_name").value = document.getElementById(recipient + "b").value;
            document.getElementById("Scope_name").value = document.getElementById(recipient + "a").value;
            document.getElementById("complaint_text").value = document.getElementById(recipient + "f").value;
            document.getElementById("property_name").value = document.getElementById(recipient + "g").value;
            document.getElementById("time_date").value = document.getElementById(recipient + "d").value;
            document.getElementById("contract_ref").value = document.getElementById(recipient + "h").value;

            $("#complaintPhoto").attr("src", document.getElementById(recipient + "e").value);
            //alert(document.getElementById(recipient + "e").value);

            //modal.find('.modal-body input').val(recipient)

        });


    </script>
 

</html>
