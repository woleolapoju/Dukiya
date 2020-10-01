<%@ Page Language="C#" AutoEventWireup="true" CodeFile="servicechargeacctsmt.aspx.cs" Inherits="servicechargeacctsmt" %>

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
<%--<link href="css/Dashboard/style.css" rel='stylesheet' type='text/css' />--%>
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
        .market-update-block {
    padding: 2em 2em;
    background: #999;
}
.market-update-block h3 {
    color: #fff;
    font-size: 2em;
}
.market-update-block h4 {
	font-size: 1.2em;
    color: #fff;
    margin: 0.3em 0em;
}
.market-update-block p {
    color: #fff;
    font-size: 0.8em;
    line-height: 1.8em;
}
.market-update-block.clr-block-1 {
    background: #53d769;
    box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
    transition: 0.5s all;
  -webkit-transition: 0.5s all;
  -moz-transition: 0.5s all;
  -o-transition: 0.5s all;
}
.market-update-block.clr-block-2 {
    background:#fc3158;
    box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
    transition: 0.5s all;
  -webkit-transition: 0.5s all;
  -moz-transition: 0.5s all;
  -o-transition: 0.5s all;
}
.market-update-block.clr-block-3 {
    background:#147efb;
    box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
    transition: 0.5s all;
  -webkit-transition: 0.5s all;
  -moz-transition: 0.5s all;
  -o-transition: 0.5s all;
}
.market-update-block.clr-block-4 {
    background:#2a2727;
    box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
    transition: 0.5s all;
  -webkit-transition: 0.5s all;
  -moz-transition: 0.5s all;
  -o-transition: 0.5s all;
}
.market-update-block.clr-block-1:hover {
    background: #8b5c7e;
   transition: 0.5s all;
  -webkit-transition: 0.5s all;
  -moz-transition: 0.5s all;
  -o-transition: 0.5s all;
}
.market-update-block.clr-block-2:hover {
    background: #8b5c7e;
   transition: 0.5s all;
  -webkit-transition: 0.5s all;
  -moz-transition: 0.5s all;
  -o-transition: 0.5s all;
}
.market-update-block.clr-block-3:hover {
    background:#8b5c7e;
    transition: 0.5s all;
  -webkit-transition: 0.5s all;
  -moz-transition: 0.5s all;
  -o-transition: 0.5s all;
}
.market-update-block.clr-block-4:hover {
    background:#8b5c7e;
    transition: 0.5s all;
  -webkit-transition: 0.5s all;
  -moz-transition: 0.5s all;
  -o-transition: 0.5s all;
}
.market-update-right i.fa.fa-users {
    font-size: 3em;
    color:#fff;
   text-align: left;
}
.market-update-right i.fa.fa-eye {
     font-size: 3em;
    color:#fff;
   text-align: left;
}
.market-update-right i.fa.fa-usd {
     font-size:3em;
    color:#fff;
    text-align: left;
}
.market-update-right i.fa.fa-shopping-cart{
     font-size:3em;
    color:#fff;
    text-align: left;
}
.market-update-left {
    padding: 0px;
}
.market-update-right {
    padding-left: 0;
}
.market-updates {
    margin: 1.5em 0;
}
/*--market--*/


        @media (max-width: 320px) {
            .market-update-gd {
                padding: 0;
            }

            .market-update-gd {
                margin: 0.8em 0;
            }

            .market-update-right {
                width: 30%;
            }
        }
        @media (max-width: 414px) {
            .market-update-gd {
                float: left;
                width: 100%;
            }

            .market-update-left {
                margin-left: 0;
                text-align: left;
                width: 63%;
            }

            .market-update-right {
                width: 26%;
                padding: 0;
                text-align: left;
            }
        }
        @media (max-width: 1080px) {

            .market-update-gd {
                float: left;
                width: 50%;
                margin: 1em 0;
            }

            .market-updates {
                margin: 0em 0;
            }
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

<body onload="getclientdate()">
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


    <section id="main-content"  style="margin-left:5px;margin-top:100px; z-index:90">
	<section class="wrapper">
          <form id="form1" runat="server" style="margin-top:10px;">
                
        	<div class="market-updates">
                <a href="#" onclick="divclient()">
			<div class ="col-md-3 market-update-gd">
				<div class="market-update-block clr-block-2">
						 <div class="col-md-8 market-update-left">
					<h4>Client Balance</h4>
					<h3><label id="ClientAcct" runat="server">0</label></h3>
					<%--<p style="line-height:1em">Urgent action required</p>--%>
                         <p></p>
				  </div>
				  <div class="clearfix"> </div>
				</div>
			</div>
                </a>

                  <a href="#"  onclick="divUS()">
			<div class="col-md-3 market-update-gd">
				<div class="market-update-block clr-block-1">
				<div class="col-md-8 market-update-left">
					<h4>Balance with Us</h4>
						<h3><label id="OurAcct" runat="server">0</label></h3>
					<%--	<p style="line-height:1em">immidiate action required</p>--%>
                       
					</div>
				  <div class="clearfix"> </div>
				</div>
			</div>
			</a>
            <a href="#"  onclick="divproxy()">
			<div class="col-md-3 market-update-gd">
				<div class="market-update-block clr-block-4">
					<div class="col-md-8 market-update-left">
						<h4>Proxy Balance</h4>
						<h3><label id="ProxyAcct" runat="server">0</label></h3>
					<%--	<p style="line-height:1em">Available for Approval</p>--%>
					</div>
				  <div class="clearfix"> </div>
				</div>
			</div>
                </a>

                <div class="col-md-3 market-update-gd">
				<div class="market-update-block clr-block-3" style="background-color:lightsalmon;padding:18px">
			<table>
            <tr>
              <td>
             Startdate: <input type="text"  id="startdate" runat="server" required="required" style="width:130px;margin-bottom:5px;font-size:small" autocomplete="off" readonly="" />
            </td>
                </tr>
              <tr> 
                 <td>
                   Enddate:&nbsp  <input type="text"  id="enddate" runat="server" required="required" style="width:130px;margin-bottom:5px;font-size:small" autocomplete="off" readonly="" />
                      &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button id="load" runat="server" OnClick="load_click" class="btn btn-danger"  Width="130px" style="margin-left:10px" Text="LOAD" />
            </td>
                              </tr>
                          <tr>
                <td>
                 
                </td>
</tr>
           
        </table>

    <script>
        function divclient() {
            document.getElementById("WithClient").style.display = "block";
            document.getElementById("WithUs").style.display = "none";
            document.getElementById("WithProxy").style.display = "none";
            document.getElementById("SC").innerHTML = "CLIENT ACCOUNT STATEMENT"
            //document.getElementById("SC").style.color = "crimson";
           

        }
        function divproxy() {
            document.getElementById("WithClient").style.display = "none";
            document.getElementById("WithUs").style.display = "none";
            document.getElementById("WithProxy").style.display = "block";
            document.getElementById("SC").innerHTML = "PROXY ACCOUNT STATEMENT"
            //document.getElementById("SC").style.color = "Darkgrey";
        }
        function divUS() {
            document.getElementById("WithClient").style.display = "none";
            document.getElementById("WithUs").style.display = "block";
            document.getElementById("WithProxy").style.display = "none";
            document.getElementById("SC").innerHTML = "OUR ACCOUNT STATEMENT"
            //document.getElementById("SC").style.color = "#333";
        }
    </script>


                     <script>
              $( function() {
                  //$("#start_datepicker").datepicker();
                  $("#startdate").datepicker({
                      dateFormat: "dd-MM-yy",
                      autoSize: true,
                      currentText: "Now",
                      changeYear: true

                  });
                  
              });
           
              $(function () {
                  $("#enddate").datepicker({
                      dateFormat: "dd-MM-yy",
                      autoSize: true,
                      changeYear: true
                  });
              });


              $(document).ready(function () {

                  $("#startdate,#enddate").datepicker({
                      changeMonth: true,
                      changeYear: true,
                      firstDay: 1,
                      dateFormat: 'dd/mm/yy',
                  })

                  //$("#startdate").datepicker({ dateFormat: 'dd-mm-yy' });
                  //$("#enddate").datepicker({ dateFormat: 'dd-mm-yy' });

                  $('#enddate').change(function () {
                      var start = $('#startdate').datepicker('getDate');
                      var end = $('#enddate').datepicker('getDate');

                      if (start <= end) {
                          //var days = (end - start) / 1000 / 60 / 60 / 24;
                          //$('#days').val(days);
                      }
                      else {
                          alert("Start date should not be greater than End date!");
                          //$('#start_datepicker').val("");
                          $('#enddate').val($('#startdate').datepicker('getDate'));
                          //$('#days').val("");

                          var today = new Date();
                          var dd = today.getDate();
                          var mm = today.getMonth() ; //January is 0!
                          var yyyy = today.getFullYear();

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

                          $('#enddate').val(dd + "-" + months[mm] + "-" + yyyy);

                      }
                  }); //end change function
              }); //end ready

  </script>

<!-- Calendar -->
			<link rel="stylesheet" href="css/form/jquery-ui.css" />
				<script src="js/form/jquery-ui.js"></script>
					<script>
						$(function() {
							$( "#datepicker" ).datepicker();
						});
					</script>
		<!-- //Calendar -->

				  <div class="clearfix"> </div>
				</div>
			</div>


		   <div class="clearfix">
               

		   </div>
		</div>	
     
<div>
     <div id="complaintdetails" class="modal-content" >  <%--style="display:none"--%>

                          <!-- Top Navigation Menu -->
<div class="topnav" id="headerdiv" >
  <a href="#" id="SC" class="active">CLIENT ACCOUNT STATEMENT</a>
          <label style="color:white">Property Group:</label><asp:DropDownList ID="PropertyGroup"  OnSelectedIndexChanged="PropertyGroup_SelectedIndexChanged" ForeColor="Red" AutoPostBack="true" runat="server">
          </asp:DropDownList>
         <label style="color:white">Contract Infor:</label> <asp:DropDownList ID="dboContracts"  OnSelectedIndexChanged="dboContracts_SelectedIndexChanged"  AutoPostBack="true"  runat="server"> </asp:DropDownList>
  <a href="javascript:void(0);" class="icon"  style="background-color:crimson">
    <i  style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;font-size:medium" runat="server" onclick="myFunction()">PRINT</i>
  </a>
</div>

 <script>
        function doPrint()
        {
            var prtContent;
            if (document.getElementById("WithClient").style.display == "block") {
                prtContent = document.getElementById('<%= myDataGrid.ClientID %>');
            }
            if (document.getElementById("WithUs").style.display == "block") {
                prtContent = document.getElementById('<%= myDataGridUs.ClientID %>');
            }
            if (document.getElementById("WithProxy").style.display == "block") {
                prtContent = document.getElementById('<%= myDataGridProxy.ClientID %>');
            }
            //document.getElementById("WithUs").style.display = "none";
            //document.getElementById("WithProxy").style.display = "none";

            prtContent.border = 0; //set no border here
            var WinPrint = window.open('','','left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
            WinPrint.document.write(prtContent.outerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
</script>
         
<script>
    function myFunction() {
       // document.getElementById("authorisetrans").click();
        doPrint();
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

            var formatted = dd + "-" + months[mm] + "-" + yyyy;
            if (document.getElementById("enddate").value == "") {
                document.getElementById("enddate").value = formatted;
                document.getElementById("startdate").value = "01-January" + "-" + yyyy;
            }
        }

  
</script>



<div id="WithClient" style="vertical-align: top; height: 100%; overflow:auto;width:100%" runat="server">

        <ASP:GridView id="myDataGrid" runat="server" HeaderStyle-BackColor="#aaaadd" Font-Size="9pt" Font-Name="Verdana" CellPadding="4" ItemStyle-Height="10px" ItemStyle-Wrap="true" ShowFooter="True" Width="100%"  AllowSorting="True"  OnSorting="myDataGrid_Sorting"   ForeColor="#333333" GridLines="Vertical" Font-Names="Verdana">
				        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
				        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
				        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
			            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
			        </ASP:GridView>
 </div>


 <div id="WithUs"  style="vertical-align: top; height: 100%; overflow:auto;width:100%;display:none" runat="server">
        <ASP:GridView id="myDataGridUs" runat="server" HeaderStyle-BackColor="#aaaadd" Font-Size="9pt" Font-Name="Verdana" CellPadding="4" ItemStyle-Height="10px" ItemStyle-Wrap="true" ShowFooter="True" Width="100%"  AllowSorting="True"  OnSorting="myDataGrid_Sorting"   ForeColor="#333333" GridLines="Vertical" Font-Names="Verdana">
				        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
				        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
				        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

			  
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
			            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
			        </ASP:GridView>
 </div>
          

<div id="WithProxy"  style="vertical-align: top; height: 100%; overflow:auto;width:100%;display:none" runat="server">
       <label style="color:red">Proxy:</label> <asp:DropDownList ID="cboProxy"  OnSelectedIndexChanged="cboProxy_SelectedIndexChanged"  AutoPostBack="true"  runat="server"> </asp:DropDownList>
        <ASP:GridView id="myDataGridProxy" runat="server" HeaderStyle-BackColor="#aaaadd" Font-Size="9pt" Font-Name="Verdana" CellPadding="4" ItemStyle-Height="10px" ItemStyle-Wrap="true" ShowFooter="True" Width="100%"  AllowSorting="True"  OnSorting="myDataGrid_Sorting"   ForeColor="#333333" GridLines="Vertical" Font-Names="Verdana">
				        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
				        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
				        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

			  
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
			            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
			        </ASP:GridView>
 </div>

          
            <div class="form-group" style="margin-top:5px; display:none">

               <asp:Button id="authorisetrans" runat="server" OnClick="load_click" class="btn btn-danger"  Width="150px" style="margin-left:10px" Text="SAVE" />
                   
                <button type="button" onclick="showpicture()" id="showImage" class="btn btn-primary" style="float:right;margin-right:10px;width:70px">CLEAR</button>

            </div>
      </div>

    </div>

					<%--</div>--%>

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
