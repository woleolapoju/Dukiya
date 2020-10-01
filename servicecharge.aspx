<%@ Page Language="C#" AutoEventWireup="true" CodeFile="servicecharge.aspx.cs" Inherits="servicecharge" %>

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

<%--for navbar--%>
<style>
/*body {
  font-family: Arial, Helvetica, sans-serif;
}*/

/*.mobile-container {
  max-width: 480px;
  margin: auto;
  background-color: #555;
  height: 500px;
  color: white;
  border-radius: 10px;
}*/

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
								<h4 class="title">Contract Listings</h4>

                                <div class="form-group" > <%--style="background-color:lightgray"--%>
                                    <label for="dboproduct" class="col-form-label">Product Group:</label>
                                    <asp:DropDownList ID="dboproduct" AutoPostBack="true" class="form-control" Font-Size="Medium" runat="server" OnTextChanged="dboproduct_TextChanged" OnSelectedIndexChanged="dboproduct_SelectedIndexChanged"> </asp:DropDownList>
                                </div>
							</div>
							<table class="table stats-table ">
								<thead>
									<tr>
										<th>Ref.No</th>
                                        <th>Contract Info.</th>
										<th>Property</th>
										<th>Balance</th>
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

                          <!-- Top Navigation Menu -->
<div class="topnav">
  <a href="#home" id="SC" class="active">Service Charge - Utilization</a>
  <div id="myLinks">
    <a href="#" id="ut" style="color:red">Utilization</a>
    <a href="#" id="OB">Opening Balance</a>
    <a href="#" id="RC">Receipt from Client</a>
    <a href="#" id="P2P">Payment to Proxy</a>
    <a href="#" id="PfromP">Payment From Proxy</a>
    <a href="#" id="BT">Balance Transfer</a>
    <a href="authoriseservicecharge.aspx" id="authorise">Authorise Transactions</a>
    <a href="servicechargeacctsmt.aspx" id="acctstatement">Account Statements</a>
  </div>
  <a href="javascript:void(0);" class="icon" onclick="myFunction()" style="background-color:crimson">
    <i class="fa fa-bars"></i>
  </a>
</div>


<script>
function myFunction() {
  var x = document.getElementById("myLinks");
  if (x.style.display === "block") {
    x.style.display = "none";
  } else {
    x.style.display = "block";
  }
}

$("#myLinks").click(function (event) {

    var x = document.getElementById("myLinks");
        x.style.display = "none";
       
        var button = event.target;
        //alert(button.id);

        document.getElementById("SC").innerHTML = "Service Charge - " + button.innerHTML;

        document.getElementById("hiddenSource").value = button.innerHTML;
        

        document.getElementById("ut").style.color = "white";
        document.getElementById("OB").style.color = "white";
        document.getElementById("RC").style.color = "white";
        document.getElementById("P2P").style.color = "white";
        document.getElementById("PfromP").style.color = "white";
        document.getElementById("BT").style.color = "white";

        button.style.color = "red";

    if (button.id=="ut") {
        document.getElementById("divut").style.display = "block";
        document.getElementById("divob").style.display = "none";
        document.getElementById("divrc").style.display = "none";
        document.getElementById("divp2p").style.display = "none";
        document.getElementById("divpfromp").style.display = "none";
        document.getElementById("divbt").style.display = "none";
        document.getElementById("mainform").style.backgroundColor = "white";
        
    }
    if (button.id == "OB") {
        document.getElementById("divut").style.display = "none";
        document.getElementById("divob").style.display = "block";
        document.getElementById("divrc").style.display = "none";
        document.getElementById("divp2p").style.display = "none";
        document.getElementById("divpfromp").style.display = "none";
        document.getElementById("divbt").style.display = "none";
        document.getElementById("mainform").style.backgroundColor = "#FF9900";
    }
    if (button.id == "RC") {
        document.getElementById("divrc").style.display = "block";
        document.getElementById("divut").style.display = "none";
        document.getElementById("divob").style.display = "none";
        document.getElementById("divp2p").style.display = "none";
        document.getElementById("divpfromp").style.display = "none";
        document.getElementById("divbt").style.display = "none";
        document.getElementById("mainform").style.backgroundColor = "#669900";
    }
    if (button.id == "P2P") {
        document.getElementById("divp2p").style.display = "block";
        document.getElementById("divut").style.display = "none";
        document.getElementById("divob").style.display = "none";
        document.getElementById("divrc").style.display = "none";
        document.getElementById("divpfromp").style.display = "none";
        document.getElementById("divbt").style.display = "none";
        document.getElementById("mainform").style.backgroundColor = "#808080";
    }
    if (button.id == "PfromP") {
        document.getElementById("divpfromp").style.display = "block";
        document.getElementById("divut").style.display = "none";
        document.getElementById("divob").style.display = "none";
        document.getElementById("divrc").style.display = "none";
        document.getElementById("divp2p").style.display = "none";
        document.getElementById("divbt").style.display = "none";
        document.getElementById("mainform").style.backgroundColor = "#ff8080";
    }
    if (button.id == "BT") {
        document.getElementById("divbt").style.display = "block";
        document.getElementById("divpfromp").style.display = "none";
        document.getElementById("divut").style.display = "none";
        document.getElementById("divob").style.display = "none";
        document.getElementById("divrc").style.display = "none";
        document.getElementById("divp2p").style.display = "none";
        document.getElementById("mainform").style.backgroundColor = "#99CC00";
    }



})
</script>

      <div class="modal-body" id="mainform">
           <div class="form-group">
            <label for="dproperty" class="col-form-label">Property:</label>
            <input type="text"  readonly="true" class="form-control" id="dproperty" runat="server"/>
          </div>
           <div class="form-group">
            <label for="Contract_Details" class="col-form-label">Contract Details:</label>
            <input type="text"  readonly="true" class="form-control" id="Contract_Details" runat="server"/>
          </div>
          
            <div class="form-group"  id="div1" runat="server" style="margin-top:0px;padding-top:0px" >
                    <label for="TransDate_datepicker" class="col-form-label">Date:</label>
                     <input type="text" class="form-control" id="TransDate_datepicker" runat="server" required="required" autocomplete="off" readonly="" style="padding:2px;width:150px;background-color:white"/>
              </div>

            <div id="divob" style="display:none">
            <div class="form-group">
                <label for="particularsob" class="col-form-label">Particulars:</label>
                <textarea class="form-control"  runat="server" rows="3" id="particularsob"></textarea>
              </div>
              <div class="form-group">
                 <label for="Proxyob" class="col-form-label">Balance With:</label>
                  <asp:DropDownList ID="Proxyob"  class="form-control" style="background-color:white"  ForeColor="black"  runat="server"/> 
              </div>
                  <div class="form-group" style="display:inline-block">
                   <table style="width:100%">
                   <tr>
                       <td>
                            <label for="amountob" class="col-form-label">Amount:</label>
                            <input type="text" class="form-control"  id="amountob" runat="server" value="0" style="padding:2px;width:150px" autocomplete="off" onkeypress="return isDecimal(event)" />
                      </td>
                       <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                       <td >
                             <input id="chknegativeob" class="col-form-label" runat="server" type="checkbox"  style="font-size:120px;margin-top:10px"  /> <span style="color:red;font-size:small"> Negative Balance </span> 
                       </td>
                   </tr>
                     
               </table>
                           
         </div>

          </div>


          <div id="divut">
               <div class="form-group">
                <label for="particulars" class="col-form-label">Particulars:</label>
                <textarea class="form-control" runat="server"  rows="3" id="particulars"></textarea>
              </div>
               <div class="form-group"  id="div2" runat="server" style="margin-top:0px;padding-top:0px" >
               </div>

               <div class="form-group" style="display:inline-block">
               <table style="width:100%">
                   <tr>
                       <td>
                 <label for="amount" class="col-form-label">Amount:</label>
                <input type="text" class="form-control"  id="amount" runat="server" value="0" autocomplete="off" style="padding:2px;width:150px" onkeypress="return isDecimal(event)" />
             
                       </td>
                       <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                       <td >
                     <label for="amount1" style="color:red" class="col-form-label">Our Component:</label>
                    <input type="text" class="form-control"  id="amount1" runat="server" value="0" autocomplete="off" style="padding:2px;width:150px" onkeypress="return isDecimal(event)" />
             
                       </td>
                   </tr>
               </table>
         </div>

              <div class="form-group">
                 <label for="Proxyut" class="col-form-label">Operator:</label>
                  <asp:DropDownList ID="Proxyut"  class="form-control" style="background-color:white"  ForeColor="black"  runat="server"/> 
              </div>
          </div>

          <div id="divrc" style="display:none">
               <div class="form-group">
                <label for="particularsrc" class="col-form-label">Particulars:</label>
                <textarea class="form-control" runat="server"  rows="3" id="particularsrc"></textarea>
              </div>

              <div class="form-group">
                 <label for="Proxyrc" class="col-form-label">Receipt By:</label>
                  <asp:DropDownList ID="Proxyrc"  class="form-control" style="background-color:white"  ForeColor="black"  runat="server"/> 
              </div>

               <div class="form-group" style="display:inline-block">
               <table style="width:100%">
                   <tr>
                       <td>
                           
                   <label for="amountrc" class="col-form-label">Amount:</label>
                     <input type="text" class="form-control"  id="amountrc" runat="server" autocomplete="off" value="0" style="padding:2px;width:150px" onkeypress="return isDecimal(event)" />

                       </td>
                       <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                       <td >
                           <label for="PVrc" class="col-form-label">PV No:</label>
                             <input type="text" class="form-control"  id="PVrc" runat="server" style="padding:2px;width:150px"  />
                       </td>
                   </tr>
               </table>
         </div>

          </div>

           <div id="divp2p" style="display:none">
               <div class="form-group">
                <label for="particularsp2p" class="col-form-label">Particulars:</label>
                <textarea class="form-control" runat="server"  rows="3" id="particularsp2p"></textarea>
              </div>
              
                <div class="form-group">
                 <label for="amount" class="col-form-label">Receiving Proxy:</label>
                  <asp:DropDownList ID="Proxyp2p"  class="form-control" style="background-color:white"  ForeColor="black"  runat="server"/> 
              </div>

                  <div class="form-group">
                <label for="amountp2p" class="col-form-label">Amount:</label>
                     <input type="text" class="form-control"  id="amountp2p" autocomplete="off" runat="server" value="0" style="padding:2px;width:150px" onkeypress="return isDecimal(event)" />
                </div>


                  <div class="form-group" style="display:inline-block">
               <table style="width:100%">
                   <tr>
                       <td>
                           
                       <label for="Beneficiary" class="col-form-label">Payment From:</label>
                        <asp:DropDownList ID="Beneficiaryp2p"  class="form-control" style="background-color:white"  Width="150px" ForeColor="black"  runat="server"> 
                            <asp:ListItem value="Us" Selected="True" >Us</asp:ListItem>  
                            <asp:ListItem value="Client" >Client</asp:ListItem>
                       </asp:DropDownList>

                       </td>
                       <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                       <td >
                             <label for="PVp2p" class="col-form-label">PV No:</label>
                             <input type="text" class="form-control"  id="PVp2p" runat="server" autocomplete="off" style="padding:2px;width:150px"  />
                       </td>
                   </tr>
               </table>
         </div>


          </div>

          <div id="divpfromp" style="display:none">
               <div class="form-group">
                <label for="particularspfromp" class="col-form-label">Particulars:</label>
                <textarea class="form-control" runat="server"   rows="3" id="particularspfromp"></textarea>
              </div>

               <div class="form-group">
                 <label for="Proxypfromp" class="col-form-label">Paying Proxy:</label>
                  <asp:DropDownList ID="Proxypfromp"  class="form-control" style="background-color:white"  ForeColor="black"  runat="server"/> 
              </div>

               <div class="form-group"  id="div5" runat="server" style="margin-top:0px;padding-top:0px" >
                <label for="amountpfromp" class="col-form-label">Amount:</label>
                <input type="text" class="form-control"  id="amountpfromp" autocomplete="off" runat="server" value="0" style="padding:2px;width:150px" onkeypress="return isDecimal(event)" />
              </div>
                 <div class="form-group" style="display:inline-block">
               <table style="width:100%">
                   <tr>
                       <td>
                           
                       <label for="Beneficiary" class="col-form-label">Beneficiary <span style="font-size:small"> (Payment To): </span></label>
                        <asp:DropDownList ID="Beneficiarypfromp"  class="form-control" style="background-color:white"  Width="150px" ForeColor="black"  runat="server"> 
                            <asp:ListItem value="Us" Selected="True" >Us</asp:ListItem>  
                            <asp:ListItem value="Client" >Client</asp:ListItem>
                       </asp:DropDownList>

                       </td>
                       <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                       <td >
                           <label for="PVNopFromp" class="col-form-label">PV No:</label>
                             <input type="text" class="form-control"  id="PVNopFromp" runat="server" autocomplete="off"  style="padding:2px;width:150px"  />
                       </td>
                   </tr>
               </table>
         </div>
          </div>


          
            <div id="divbt" style="display:none" >
               <div class="form-group">
                 <label for="amount" class="col-form-label">Transfer To:</label>
                  <asp:DropDownList ID="TransferTo"  class="form-control" style="background-color:white"  ForeColor="black"  runat="server"/> 
              </div>
                    <div class="form-group">
                <label for="particularsbt" class="col-form-label">Particulars:</label>
                <textarea class="form-control" runat="server"  rows="3" id="particularsbt"></textarea>
              </div>
                 <div class="form-group">
               
              


                      </div>




                  <div class="form-group" style="display:inline-block">
               <table style="width:100%">
                   <tr>
                       <td>
                           
                      <label for="Proxybt" class="col-form-label">Transfer Balance from:</label>
                            <asp:DropDownList ID="Proxybt"  class="form-control" style="background-color:white"  ForeColor="black"  runat="server"/> 

                       </td>
                       <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                       <td  style="width:auto">
                            <label for="Beneficiarybt" class="col-form-label">Transfer To:</label>
                            <asp:DropDownList ID="Beneficiarybt"  class="form-control" style="background-color:white"  ForeColor="black"  runat="server"/> 
                       </td>
                   </tr>
               </table>
         </div>



              <div class="form-group" style="display:inline-block">
                   <table style="width:100%">
                   <tr>
                       <td>
                            <label for="amountbt" class="col-form-label">Amount:</label>
                            <input type="text" class="form-control"  id="amountbt" autocomplete="off" runat="server" value="0" style="padding:2px;width:150px" onkeypress="return isDecimal(event)" />
                      </td>
                       <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                       <td >
                             <input id="chknegativebt" class="col-form-label" runat="server" type="checkbox"  style="font-size:120px;margin-top:10px"  /> <span style="color:red;font-size:small"> Negative Balance </span> 
                       </td>
                   </tr>
                     
               </table>
                           
    </div>
                
          </div>


           <script>
    function isDecimal(evt)
    {
       var charCode = (evt.which) ? evt.which : event.keyCode
       var parts = evt.srcElement.value.split('.');
       if(parts.length > 1 && charCode==46)
          return false;
       else
       {
          if (charCode == 46 || (charCode >= 48 && charCode <= 57))
             return true;
          return false;
       }
    }
</script>

             <script>
                 $(function () {
                     $("#TransDate_datepicker").datepicker({
                      dateFormat: "dd-MM-yy",
                      autoSize: true,
                      currentText: "Now",
                      changeYear: true
                     
                     });
              });


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
          
          
     
      
        
        

 <%--   </form>--%>
              </div>
          
            <div class="form-group" style="margin-top:5px">

               <asp:Button ID="btnNewjoblog" runat="server" OnClick="btnNewjoblog_Click" class="btn btn-danger"  Width="150px" style="margin-left:10px" Text="SAVE" />
                   
                <button type="button" onclick="showpicture()" id="showImage" class="btn btn-primary" style="float:right;margin-right:10px;width:70px">CLEAR</button>
               
                          <input type="text"  id="hiddenSource" runat="server" value="Utilization"  style="display:none" />
           
            </div>
      </div>

    </div>

					</div>

    </form>
        </section>
        </section>


</body>

    <script>
        $("#tblBody").click(function (event) {     
            var button = event.target;
            var recipient = button.title;  
            if (recipient = button.id) {
                   document.getElementById("dproperty").value = document.getElementById(recipient + "b").value;
                document.getElementById("Contract_Details").value = document.getElementById(recipient + "a").value;
            }
            else
                return;

        });
    </script>
 

</html>
