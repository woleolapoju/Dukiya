<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="sample7" %>

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

<!-- calendar -->
<%--<link rel="stylesheet" href="css/Dashboard/monthly.css"/>--%>
<!-- //calendar -->
<!-- //font-awesome icons -->
<script src="js/Dashboard/jquery2.0.3.min.js"></script>
<script src="js/Dashboard/raphael-min.js"></script>
<script src="js/Dashboard/morris.js"></script>


    <style>

	.myblink{
		/*font-size: 25px;
		font-family: cursive;*/
        line-height: 0px;	
		color: black;
		animation: blink 1s linear infinite;
	}
    @keyframes blink{
        0%{opacity: 0;}
        50%{opacity: .5;}
        100%{opacity: 1;}
    }

    </style>
    
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



<section id="container1">

<!--header start-->

<%--<header class="header fixed-top clearfix" style="margin:0px; background-color:black;" >--%>
    <header class="clearfix" style="margin:0px;position: fixed; top: 0;padding:0px; width: 100%; background-color:black;z-index:100"  >

    <div class="brand" style="background-color:black;display:none">
    <a href="Default.aspx" title="click to sign out" style="margin-top:0px;" >
        <img src="images/applogo_black.png" style="margin-right:20px;margin-top:0px;padding:0px" />
    </a>
    <%--<div class="sidebar-toggle-box">
        <div class="fa fa-bars"><span style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"> MENU1111</span></div>
    </div>--%>
        </div>
        
<div class="nav notify-row" id="top_menu"  style="margin:0px; ">
    <table>
        <tr>
            <td>
                 <img src="images/applogo_black.png" style="margin-right:20px" />
            </td>
            <td>
                 <!--  notification start -->
    <ul class="nav top-menu">

        <!-- settings start -->
        <li class="dropdown">
            <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                <i class="fa fa-tasks"></i>
                <span class="badge bg-success"> <label id="TpendingComplaint1" runat="server">0</label></span>
            </a>
            <ul class="dropdown-menu extended tasks-bar">
                <li>
                    <p class="">You have <label id="TpendingComplaint2" runat="server">0</label> New Complaints</p>
                </li>
                <li id="i1" runat="server">
                    <a href="#" id="aNewComplaint1" runat="server" data-toggle="modal" data-target="#exampleModal">
                        <div class="task-info clearfix">
                            <div class="desc pull-left">
                                <h5><label id="lbl1a" runat="server">Target Sell</label></h5>
                                <p><label id="lbl1b" runat="server">25% , Deadline  12 June’13</label></p>
                            </div>
                            <span class="notification-pie-chart pull-right" data-percent="45">
                            <span class="percent"></span>
                            </span>
                        </div>
                    </a>
                </li>
                <li id="i2" runat="server">
                    <a href="#" id="aNewComplaint2" runat="server" data-toggle="modal" data-target="#exampleModal">
                        <div class="task-info clearfix">
                            <div class="desc pull-left">
                                   <h5><label id="lbl2a" runat="server">Target Sell</label></h5>
                                <p><label id="lbl2b" runat="server">25% , Deadline  12 June’13</label></p>
                            </div>
                                    <span class="notification-pie-chart pull-right" data-percent="78">
                            <span class="percent"></span>
                            </span>
                        </div>
                    </a>
                </li>
                <li id="i3" runat="server">
                    <a href="#" id="aNewComplaint3" runat="server" data-toggle="modal" data-target="#exampleModal">
                        <div class="task-info clearfix">
                            <div class="desc pull-left">
                                    <h5><label id="lbl3a" runat="server">Target Sell</label></h5>
                                <p><label id="lbl3b" runat="server">25% , Deadline  12 June’13</label></p>
                            </div>
                                    <span class="notification-pie-chart pull-right" data-percent="60">
                            <span class="percent"></span>
                            </span>
                        </div>
                    </a>
                </li>
                <li id="i4" runat="server">
                    <a href="#" id="aNewComplaint4" runat="server" data-toggle="modal" data-target="#exampleModal" >
                        <div class="task-info clearfix">
                            <div class="desc pull-left">
                                  <h5><label id="lbl4a" runat="server">Target Sell</label></h5>
                                <p><label id="lbl4b" runat="server">25% , Deadline  12 June’13</label></p>
                            </div>
                                    <span class="notification-pie-chart pull-right" data-percent="90">
                            <span class="percent"></span>
                            </span>
                        </div>
                    </a>
                </li>

                <li id="i5" runat="server" class="external">
                    <a href="#lastline">See All Complaint</a>
                </li>
            </ul>
        </li>
     
       
        <!-- notification dropdown start-->
        <li id="header_notification_bar" class="dropdown">
            <a data-toggle="dropdown" class="dropdown-toggle" href="#">

                <i class="fa fa-bell-o"></i>
                <span class="badge bg-warning"><label id="totalnotification" runat="server">0</label></span>
            </a>
            <ul class="dropdown-menu extended notification">
                <li>
                    <p>Notifications</p>
                </li>
                <li id="nL1" runat="server">
                    <div class="alert alert-info clearfix">
                        <span class="alert-icon"><i class="fa fa-bolt"></i></span>
                        <div class="noti-info">
                            <a href="#"> Server #1 overloaded.</a>
                        </div>
                    </div>
                </li>
                <li id="nL2" runat="server">
                    <div class="alert alert-danger clearfix">
                        <span class="alert-icon"><i class="fa fa-bolt"></i></span>
                        <div class="noti-info">
                            <a href="#"> Server #2 overloaded.</a>
                        </div>
                    </div>
                </li>
                <li id="nL3" runat="server">
                    <div class="alert alert-success clearfix">
                        <span class="alert-icon"><i class="fa fa-bolt"></i></span>
                        <div class="noti-info">
                            <a href="#"> Server #3 overloaded.</a>
                        </div>
                    </div>
                </li>
                 <li id="nL4" runat="server">
                    <div class="alert alert-success clearfix">
                        <span class="alert-icon"><i class="fa fa-bolt"></i></span>
                        <div class="noti-info">
                            <a href="#"> Server #3 overloaded.</a>
                        </div>
                    </div>
                </li>
                    <li id="nL5" runat="server">
                    <div class="alert alert-success clearfix">
                        <span class="alert-icon"><i class="fa fa-bolt"></i></span>
                        <div class="noti-info">
                            <a href="#">See All Notices</a>
                        </div>
                    </div>
                    </li>
            </ul>
        </li>
        <!-- notification dropdown end -->
    </ul>
    <!--  notification end -->
            </td>
           

            <td >
                <a class="dropdown-toggle col-md-3 " style="font-size:xx-large"   href="MainStaff.aspx">
                    <h4 style="color:yellow">
                <i class="fa fa-bars" ><span style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif">  MENU </span> </i>
                    </h4>
            </a>
            </td>
       
        </tr>
    </table>
  
   
</div>



    <%-- <div class="top-nav clearfix pull-right">
  
     <label id="lblusername" runat="server" style="color:white;font-size:small">Wole: </label> <br />  <a style="color:yellow;font-size:small" href="Default.aspx"></i> Log Out</a>

</div>--%>
</header>
<!--header end-->



<!--main content start-->
<section id="main-content" style="margin-left:5px;margin-top:50px;">
	<section class="wrapper">
		<!-- //market-->
		<div class="market-updates">
             <a href="workorderprofile.aspx">
			<div class ="col-md-3 market-update-gd">
				<div class="market-update-block clr-block-2">
					<div class="col-md-4 market-update-right">
						<i  id="Critcali"  runat="server" class="fa fa-warning  fa-spin" style="font-size:48px;color:white"> </i>
					</div>
					 <div class="col-md-8 market-update-left">
					 <h4>Critical Workorder</h4>
					<h3><label id="CriticalJobs" runat="server">1</label></h3>
					<p style="line-height:1em">Urgent action required</p>
                         <p></p>
				  </div>
				  <div class="clearfix"> </div>
				</div>
			</div>
            </a>
             <a href="workorderprofile.aspx">
			<div class="col-md-3 market-update-gd">
				<div class="market-update-block clr-block-1">
					<div class="col-md-4 market-update-right">
						<i class="fa fa-exclamation-circle " style="font-size:48px;color:white" ></i>
					</div>
					<div class="col-md-8 market-update-left">
					<h4>Severe Workorder</h4>
						<h3><label id="SevereJobs" runat="server">1</label></h3>
						<p style="line-height:1em">immidiate action required</p>
                       
					</div>
				  <div class="clearfix"> </div>
				</div>
			</div>
            </a>
             <a href="servicechargeacctsmt.aspx">
			<div class="col-md-3 market-update-gd">
				<div class="market-update-block clr-block-3" style="background-color:lightsalmon">
					<div class="col-md-4 market-update-right">
						<i class="fa fa-clock-o"  style="font-size:48px;color:white"></i>
					</div>
					<div class="col-md-8 market-update-left">
						<h4>Service Charge</h4>
						<h3><label id="serviceChargeRequirePayment" runat="server">0</label></h3>
						<p style="line-height:1em">Require payment</p>
					</div>
				  <div class="clearfix"> </div>
				</div>
			</div>
           </a>
            <a href="authoriseservicecharge.aspx">
			<div class="col-md-3 market-update-gd">
				<div class="market-update-block clr-block-4">
					<div class="col-md-4 market-update-right">
						<i class="fa fa-flag" style="font-size:48px;color:cadetblue" aria-hidden="true"></i>
					</div>
					<div class="col-md-8 market-update-left">
						<h4>Service Charge</h4>
						<h3><label id="servicecharge" runat="server">0</label></h3>
						<p style="line-height:1em">Available for Approval</p>
					</div>
				  <div class="clearfix"> </div>
				</div>
			</div>
                </a>
		   <div class="clearfix"> </div>
		</div>	
	
  <div id="forGraph" style="display:none">

    <input type="text"  id="jan1"  runat="server" value="0" />
    <input type="text"  id="feb1" runat="server" value="0" />
    <input type="text"  id="mar1"  runat="server" value="0" />
    <input type="text"  id="apr1" runat="server" value="0" />
    <input type="text"  id="may1"  runat="server" value="0" />
    <input type="text"  id="jun1" runat="server" value="0" />
    <input type="text"  id="jul1"  runat="server" value="0" />
    <input type="text"  id="aug1" runat="server" value="0" />
    <input type="text"  id="sep1"  runat="server" value="0" />
    <input type="text"  id="oct1" runat="server" value="0" />
    <input type="text"  id="nov1"  runat="server" value="0" />
    <input type="text"  id="dec1" runat="server" value="0" />

                                   
 </div>   
        
    


			<!-- tasks -->
			<div class="agile-last-grids">

                	
				<div class="col-md-6 agile-last-left agile-last-right" style="overflow:auto">
					<div class="agile-last-grid">
						<div class="area-grids-heading">
							<h3><label id="yearInfocus" runat="server">2018</label> Complaint Statistics</h3>
						</div>
						<div id="graph9"></div>
						<script>
						var day_data = [
						  { "elapsed": "Jan", "value": document.getElementById("jan1").value },
						  { "elapsed": "Feb", "value": document.getElementById("feb1").value },
						  { "elapsed": "Mar", "value": document.getElementById("mar1").value },
						  { "elapsed": "Apr", "value": document.getElementById("apr1").value },
						  { "elapsed": "May", "value": document.getElementById("may1").value },
						  { "elapsed": "Jun", "value": document.getElementById("jun1").value },
						  { "elapsed": "Jul", "value": document.getElementById("jul1").value },
						  { "elapsed": "Aug", "value": document.getElementById("aug1").value },
						  { "elapsed": "Sep", "value": document.getElementById("sep1").value },
						  { "elapsed": "Oct", "value": document.getElementById("oct1").value },
                          { "elapsed": "Nov", "value": document.getElementById("nov1").value },
						  { "elapsed": "Dec", "value": document.getElementById("dec1").value}
						];
						Morris.Line({
						  element: 'graph9',
						  data: day_data,
						  xkey: 'elapsed',
						  ykeys: ['value'],
						  labels: ['value'],
						  parseTime: false
						});
						</script>

					</div>
				</div>
				<%--<div class="clearfix"> </div>--%>

                <div class="col-md-6 w3agile-notifications">
			<div class="notifications">
				<!--notification start-->
				
					<header class="panel-heading">
						Complaints 
					</header>
					<div class="notify-w3ls" id="divComplaints" runat="server">
<%--						<div class="alert alert-info clearfix">
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
						</div>
						<div class="alert alert-danger">
							<span class="alert-icon"><i class="fa fa-facebook"></i></span>
							<div class="notification-info">
								<ul class="clearfix notification-meta">
									<li class="pull-left notification-sender"><span><a href="#">Jonathan Smith</a></span> mentioned you in a post </li>
									<li class="pull-right notification-time">7 Hours Ago</li>
								</ul>
								<p>
									Very cool photo jack
								</p>
							</div>
						</div>
						<div class="alert alert-success ">
							<span class="alert-icon"><i class="fa fa-comments-o"></i></span>
							<div class="notification-info">
								<ul class="clearfix notification-meta">
									<li class="pull-left notification-sender">You have 5 message unread</li>
									<li class="pull-right notification-time">1 min ago</li>
								</ul>
								<p>
									<a href="#">Anjelina Mewlo, Jack Flip</a> and <a href="#">3 others</a>
								</p>
							</div>
						</div>
						<div class="alert alert-warning ">
							<span class="alert-icon"><i class="fa fa-bell-o"></i></span>
							<div class="notification-info">
								<ul class="clearfix notification-meta">
									<li class="pull-left notification-sender">Domain Renew Deadline 7 days ahead</li>
									<li class="pull-right notification-time">5 Days Ago</li>
								</ul>
								<p>
									Next 5 July Thursday is the last day
								</p>
							</div>
						</div>
						<div class="alert alert-info clearfix">
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
						</div>
						
                        <div class="alert alert-info clearfix">
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
						</div>
                        <div class="alert alert-info clearfix">
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
				
				<!--notification end-->
				</div>
			</div>
			<div id="lastline" class="clearfix"> </div>
	
			</div>
		<!-- //tasks -->
		<div class="agileits-w3layouts-stats">
					<div class="col-md-4 stats-info widget">
						<div class="stats-info-agileits">
							<div class="stats-title">
								<h4 class="title">Property Complaint Stats</h4>
							</div>
							<div class="stats-body">
								<ul class="list-unstyled" id="dStat" runat="server">
									<%--<li>Harbour Place <span class="pull-right">85%</span>  
										<div class="progress progress-striped active progress-right">
											<div class="bar green" style="width:85%;"></div> 
										</div>
									</li>
									 --%>
								</ul>
							</div>
						</div>
					</div>
					    <div class="col-md-8 stats-info stats-last widget-shadow" id="WorkOrderList" runat="server">

						<div class="stats-last-agile">
                            <div class="stats-title">
								<h4 class="title">Work Order Listings</h4>
							</div>
							<table class="table stats-table ">
								<thead>
									<tr>
										<th>Ref.No</th>
										<th>Property</th>
										<th>Status</th>
										<th>Progress</th>
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
					<div class="clearfix"> </div>
				</div>
</section>
 <!-- footer -->
		  <div >
			<div>
					<p style="text-align:center;  font-size:small;margin-right: auto;margin-left: auto; margin-top: 1em; margin-bottom: 0em">  <a href="http://www.stacklogicsystems.com" target="=_blank"> &copy; 2018 | Design by StackLogic Systems, Ltd.</a> <a href="http://w3layouts.com" target="=_blank" style="color:rgba(0, 0, 0, 0)">W3layouts</a></p>
			</div>
		  </div>
  <!-- / footer -->
</section>
<!--main content end-->
</section>
<script src="js/Dashboard/bootstrap.js"></script>
<script src="js/Dashboard/jquery.dcjqaccordion.2.7.js"></script>
<script src="js/Dashboard/scripts.js"></script>
<script src="js/Dashboard/jquery.slimscroll.js"></script>
<script src="js/Dashboard/jquery.nicescroll.js"></script>
<!--[if lte IE 8]><script language="javascript" type="text/javascript" src="js/flot-chart/excanvas.min.js"></script><![endif]-->
<script src="js/jquery.scrollTo.js"></script>
<!-- morris JavaScript -->	
<script>
	$(document).ready(function() {
		//BOX BUTTON SHOW AND CLOSE
	   jQuery('.small-graph-box').hover(function() {
		  jQuery(this).find('.box-button').fadeIn('fast');
	   }, function() {
		  jQuery(this).find('.box-button').fadeOut('fast');
	   });
	   jQuery('.small-graph-box .box-close').click(function() {
		  jQuery(this).closest('.small-graph-box').fadeOut(200);
		  return false;
	   });
	   
	    //CHARTS
	    function gd(year, day, month) {
			return new Date(year, month - 1, day).getTime();
		}
		
		graphArea2 = Morris.Area({
			element: 'hero-area',
			padding: 10,
        behaveLikeLine: true,
        gridEnabled: false,
        gridLineColor: '#dddddd',
        axes: true,
        resize: true,
        smooth:true,
        pointSize: 0,
        lineWidth: 0,
        fillOpacity:0.85,
			data: [
				{period: '2015 Q1', iphone: 2668, ipad: null, itouch: 2649},
				{period: '2015 Q2', iphone: 15780, ipad: 13799, itouch: 12051},
				{period: '2015 Q3', iphone: 12920, ipad: 10975, itouch: 9910},
				{period: '2015 Q4', iphone: 8770, ipad: 6600, itouch: 6695},
				{period: '2016 Q1', iphone: 10820, ipad: 10924, itouch: 12300},
				{period: '2016 Q2', iphone: 9680, ipad: 9010, itouch: 7891},
				{period: '2016 Q3', iphone: 4830, ipad: 3805, itouch: 1598},
				{period: '2016 Q4', iphone: 15083, ipad: 8977, itouch: 5185},
				{period: '2017 Q1', iphone: 10697, ipad: 4470, itouch: 2038},
			
			],
			lineColors:['#eb6f6f','#926383','#eb6f6f'],
			xkey: 'period',
            redraw: true,
            ykeys: ['iphone', 'ipad', 'itouch'],
            labels: ['All Visitors', 'Returning Visitors', 'Unique Visitors'],
			pointSize: 2,
			hideHover: 'auto',
			resize: true
		});
		
	   
	});
	</script>



    <div class="modal fade" id="myphotoModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header" style="padding:10px 10px;">
          <button type="button" id="closeMyModal" class="close" data-dismiss="modal" >&times;</button> 
          <h5> Picture taken </h5>
        </div>
        <div class="modal-body" style="width:auto; height:auto;margin:0px;padding:0"> <%-- style="padding:40px 50px;"--%>

            <img src="" id="myImg"  style="width:auto; height:auto;margin:0px;" />

      </div>
      
    </div>
  </div> 
 </div>

 <%--<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo">Open modal for @mdo</button>
<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" data-whatever="@fat">Open modal for @fat</button>
<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" data-whatever="@getbootstrap">Open modal for @getbootstrap</button>--%>

<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header" style="background-color:crimson;color:white">
        <h5 class="modal-title" id="exampleModalLabel">Complaint Details</h5>
       <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>--%>

      </div>
      <div class="modal-body">
          <div id="divComplaintDetails">
        <form>
          <div class="form-group">
              <label for="client_name" class="col-form-label">Client:</label>
            <input type="text"  readonly="true" class="form-control" id="client_name"/>
          </div>
     
           <div class="form-group">
            <label for="property_name" class="col-form-label">Property:</label>
            <input type="text"  readonly="true" class="form-control" id="property_name"/>
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
                            <input type="text"  readonly="true" class="form-control" id="Scope_name"/>
                       </td>
                       <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                       <td >
                            <label for="time_date" class="col-form-label">Date/Time:</label>
                            <input  type="text"  readonly="true" class="form-control" id="time_date"/>
                       </td>
                   </tr>
               </table>
          
           
          </div>
          
        </form>
              </div>
          <div id="divPhoto" style="display:none">
              <img  style="width:100%;height:100%;max-height:410px"  id ="complaintPhoto" />

          </div>
            <div class="form-group" style="margin-top:5px">
                <button type="button" onclick="showpicture()" id="showImage" class="btn btn-primary">View Image</button>

                   <button type="button"  class="btn btn-danger" data-dismiss="modal" style="float:right" onclick="closemarkasseen()">Close</button>

          </div>
      </div>
        <form runat="server">

                    
            
                  <div class="modal-footer">
                <div style="display:none">
                            <label for="recipient-name" class="col-form-label">Ref No:</label>
                            <input type="text" runat="server" readonly="true" class="form-control" id="Complaint_refno"/>
                    </div>
                      <div id="assignworkorder" class="form-group"  runat="server" style="float:left">
                       <label for="recipient-name" class="col-form-label">Assign To:</label>
                        <asp:DropDownList ID="cboAssignTo"  AutoPostBack="false" runat="server"/> 
                       <asp:Button ID="btnOwnComplaint" runat="server" OnClick="btnOwnComplaint_Click" class="btn btn-primary" Text="Assign" />
                          <asp:Button ID="btnReAssign" runat="server" OnClick="btnOwnComplaint_Click" class="btn btn-primary" Text="Re-Assign" Style="display:none" />
                        <asp:Button ID="btnAccept" runat="server" OnClick="btnOwnComplaint_Click" class="btn btn-danger" Text="Accept" Style="display:none" />
                  </div>

                    <input type="text"  id="clientdate" runat="server" style="display:none"/>
                        <asp:Button ID="btnComplaintSeen" runat="server" OnClick="btnComplaintSeen_Click" class="btn btn-primary" Text="Mark As Seen" style="display:none" />
                      
               </div>


     

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
            document.getElementById("clientdate").value = formatted;
            setCookie("currentclientdate", formatted, 365);          
        }

        function setCookie(cname, cvalue, exdays) {
            var d = new Date();
            d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
            var expires = "expires=" + d.toGMTString();
            document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
        }

  
</script>

  

        </form>
    </div>
  </div>
</div>
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
    <script>

        function closemarkasseen()
        {
            document.getElementById("btnComplaintSeen").click();
        }
        $('#exampleModal').on('show.bs.modal', function (event) {

            var x = document.getElementById("divPhoto");
            var y = document.getElementById("divComplaintDetails");
            x.style.display = "none";
            y.style.display = "block";
            document.getElementById("showImage").innerText = "View Image";
        
            var button = $(event.relatedTarget) // Button that triggered the modal
            var recipient = button.data('whatever') // Extract info from data-* attributes
            // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
            // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
            var modal = $(this)

            modal.find('.modal-title').text('Complaint RefNo: ' + recipient + ' (made by:-' + document.getElementById(recipient + "c").value + ')');

            document.getElementById("Complaint_refno").value = recipient;

            //document.getElementById("Complaint_name").value = document.getElementById(recipient + "c").value;
            document.getElementById("client_name").value = document.getElementById(recipient + "b").value;
            document.getElementById("Scope_name").value = document.getElementById(recipient + "a").value;
            document.getElementById("complaint_text").value = document.getElementById(recipient + "f").value;
            document.getElementById("property_name").value = document.getElementById(recipient + "g").value;
            document.getElementById("time_date").value = document.getElementById(recipient + "d").value;
            

            $("#complaintPhoto").attr("src", document.getElementById(recipient + "e").value);


            document.getElementById("cboAssignTo").value = document.getElementById(recipient + "h").value;
           

            var y = document.getElementById("btnAccept");
            var x = document.getElementById("btnOwnComplaint");
            var z = document.getElementById("btnReAssign");
            
            if (document.getElementById(recipient + "i").value == "TRUE") {
             //  x.innerText= "Re-assign";
                    y.style.display= "inline";
                    x.style.display = "none";
                    z.style.display = "inline";

            }
            else
                document.getElementById("btnAccept").visible=true;
            
            //alert(document.getElementById(recipient + "e").value);
            //modal.find('.modal-body input').val(recipient)
        })
    </script>
</body>
</html>
