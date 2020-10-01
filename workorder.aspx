﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="workorder.aspx.cs" Inherits="workorder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Dukiya-Property Manager</title>
<meta charset="UTF-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<meta name="description" content="Property Management System" />
<meta name="keywords" content="Dukiya,MegaHit Systems,StackLogic Systems,Property Management Solution," />
<link rel="shortcut icon" href="/images/appicon.ico"/>

<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
function hideURLbar(){ window.scrollTo(0,1); } </script>

<%--       <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>

<!-- //for-mobile-apps -->

<!-- //custom-theme -->
<link href="css/form/style.css" rel="stylesheet" type="text/css" media="all" />

<!-- js -->
<script type="text/javascript" src="js/form/jquery-2.1.4.min.js"></script>
<!-- //js -->

<!-- google fonts -->
<link href="//fonts.googleapis.com/css?family=Source+Sans+Pro:200,200i,300,300i,400,400i,600,600i,700,700i,900,900i&amp;subset=cyrillic,cyrillic-ext,greek,greek-ext,latin-ext,vietnamese" rel="stylesheet"/>
<!-- google fonts -->

<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

  <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>

  <style>

 .modal-content1 {
    position: relative;
    background-color: #fefefe;
    margin: auto;
    padding: 0;
    border: 1px solid #888;
    width: 90%;
    height:100vh;
    box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
    -webkit-animation-name: animatetop;
    -webkit-animation-duration: 0.4s;
    animation-name: animatetop;
    animation-duration: 0.4s
}

  </style>


    <style>
        body{
	margin:0;
	padding:0;
	background: url(images/form_bg.jpg);
    background-repeat: no-repeat;
    background-position: center;
    background-attachment: fixed;
    background-size: cover;
    -webkit-background-size: cover;
    -moz-background-size: cover;
    -o-background-size: cover;
    -ms-background-size: cover;
	font-family: 'Source Sans Pro', sans-serif;
 }

        .banner-dott{
    background: url(images/dott.png)repeat 0px 0px;
    background-size: 2px;
    -webkit-background-size: 2px;
    -moz-background-size: 2px;
    -o-background-size: 2px;
    -ms-background-size: 2px;
  
}
 .ui-datepicker .ui-datepicker-prev { 
	left: 10px;
    width: 20px;
    background:url(images/cal1.png) no-repeat 0px 0px;
       /*background:url(../images/cal1.png) no-repeat 0px 0px;*/
    cursor: pointer;
}
.ui-datepicker .ui-datepicker-next {
	right: 10px;
	width: 20px;
    background:url(images/cal.png) no-repeat 0px 0px;
    cursor: pointer;
 }
    </style>

    <style>
      /* Create a custom radio button */
input[type=radio] {
    border: 0px;
    width: 20px;
    height: 20px;
    padding:0px;
    margin:2px;
}
</style>

    <style>

        @import url('https://fonts.googleapis.com/css?family=Open+Sans:400,700');

*{
    box-sizing: border-box;
    margin: 0;
    padding: 0;
}

html{
    background-color: #fff;
    font:normal 16px/1.5 sans-serif;
    color: #333;
}

h3{
    font: normal 32px/1.5 'Open Sans', sans-serif;
    color: #2c3e50;
    margin: 50px 0;
    text-align: center;
}


.container{
    max-width: 500px;
     min-width: 500px;
    margin: 50px auto;
    margin: auto;
    padding: 20px;
    background-color: #efefef;
}

.app{
    width: 100%;
    position: relative;
    margin:auto;
}

.app #start_camera{
    display: none;
    border-radius: 3px;
    max-width: 400px;
    color: #fff;
    background-color: #448AFF;
    text-decoration: none;
    padding: 15px;
    opacity: 0.8;
    margin: 50px auto;
    text-align: center;
}

.app video#camera-stream{
    display: none;
    width: 100%;
}

.app img#snap{
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    z-index: 10;
    display: none;
}

.app #error-message{
    width: 100%;
    background-color: #ccc;
    color: #9b9b9b;
    font-size: 28px;
    padding: 200px 100px;
    text-align: center;
    display: none;
}

.app .controls{
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    z-index: 20;

    display: flex;
    align-items: flex-end;
    justify-content: space-between;
    padding: 30px;
    display: none;
}

.app .controls a{
    border-radius: 50%;
    color: #fff;
    background-color: #111;
    text-decoration: none;
    padding: 15px;
    line-height: 0;
    opacity: 0.7;
    outline: none;
    -webkit-tap-highlight-color: transparent;
}

.app .controls a:hover{
    opacity: 1;
}

.app .controls a.disabled{
    background-color: #555;
    opacity: 0.5;
    cursor: default;
    pointer-events: none;
}

.app .controls a.disabled:hover{
    opacity: 0.5;
}

.app .controls a i{
    font-size: 18px;
}

.app .controls #take-photo i{
    font-size: 32px;
}

.app canvas{
    display: none;
}

.app video#camera-stream.visible,
.app img#snap.visible,
.app #error-message.visible
{
    display: block;
}

.app .controls.visible{
    display: flex;
}

@media(max-width: 500px){
    .container{
        margin: 40px;
    }

    .app #start_camera.visible{
        display: block;
    }

    .app .controls a i{
        font-size: 16px;
    }

    .app .controls #take-photo i{
        font-size: 24px;
    }
}


@media(max-width:300px){
    .container{
        margin: 10px;
    }

    .app #error-message{
        padding: 80px 50px;
        font-size: 18px;
    }

    .app .controls a i{
        font-size: 12px;
    }

    .app .controls #take-photo i{
        font-size: 18px;
    }
}


    </style>
  

</head>

<body onload="RemoveGridBlankRow()">

    
<!-- banner -->
    
	<div class="center-container">

	<div class="banner-dott">
		<div class="main" style="opacity:0.9;margin-right:0px">
				<div class="w3layouts_main_grid" >
                    <table>
                        <tr >
                           
                            <td> 
                                 <div style="background-color:seashell;line-height:0.5em"">
                                    <%--<h2  style="margin-bottom:0.3em; color:black; text-shadow: 2px 2px #FF0000">Dukiya</h2> 
                                     <h5 style="color:black;margin-top:0"><strong>Property Manager</strong></h5> --%>
                                     <img src="images/applogo_black.png" />
                                </div>
                              </td>
                            <td ><h1 class="w3layouts_head">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Work Order</h1> 
                            </td>
                        </tr>

                    </table>

<form  runat="server" class="w3_form_post" style="margin-right:0px">
                       
                                <div class="w3_agileits_main_grid w3l_main_grid" id="divrefno" runat="server" style="display:none">
							        <span class="agileits_grid">
								        <label style="font-size:12px">Workorder RefNo:</label>
                                       <input type="text"  id="workorder_ref" runat="server" style="padding:2px;width:150px" readonly="readonly" />
							        </span>
						        </div>

                            <div class="w3_agileits_main_grid w3l_main_grid">
							        <span class="agileits_grid">
								        <label style="font-size:12px">Property Group<span class="star">*</span></label>
                                           <asp:DropDownList ID="PropertyGroup" style="background-color:white" ForeColor="Red" OnSelectedIndexChanged="PropertyGroup_SelectedIndexChanged"  OnTextChanged="PropertyGroup_TextChanged" AutoPostBack="true" runat="server">
                                         </asp:DropDownList>
                             

							        </span>
						        </div>
                                <div class="w3_agileits_main_grid w3l_main_grid">
							        <span class="agileits_grid">
								        <label style="font-size:12px">Contract Details <span class="star">*</span></label>
                                           <asp:DropDownList ID="dboContracts"  style="background-color:white" ForeColor="Red" OnSelectedIndexChanged="dboContracts_SelectedIndexChanged" OnTextChanged="dboContracts_TextChanged" AutoPostBack="true"  runat="server"> </asp:DropDownList>
							        </span>
						        </div>

                                <div class="w3_agileits_main_grid w3l_main_grid">
							        <span class="agileits_grid">
								        <label style="font-size:12px">Property Unitname <span class="star">*</span></label>
                                       <asp:DropDownList ID="UnitDecription"  style="background-color:white" ForeColor="red"  runat="server"> </asp:DropDownList>
							        </span>
						        </div>
       
                        <div id="divComplaintRef" runat="server" class="w3_agileits_main_grid w3l_main_grid" style="margin-top:0px;padding-top:0px">
							        <span class="agileits_grid">
                                          <label id="complaintlabel" runat="server" style="font-size:12px">Complaint RefNo: </label> <label style="width:auto;font-size:14px;font-weight:700;color:red" id="complaint_Ref" runat="server">??</label> <br />

                                   </span>
                                                    <br />
					</div>

                   
      <div class="w3_agileits_main_grid w3l_main_grid">
							        <span class="agileits_grid">
								        <label style="font-size:12px">Expected Startdate<span class="star">*</span></label>
                                       <input type="text"  id="start_datepicker" runat="server" required="required" autocomplete="off" readonly="" />
							        </span>
						        </div>

                                 <div class="w3_agileits_main_grid w3l_main_grid">
							        <span class="agileits_grid">
								        <label style="font-size:12px">Expected&nbsp;&nbsp Enddate<span class="star">*</span></label>
                                       <input type="text"  id="end_datepicker" runat="server" required="required" autocomplete="off" readonly=""/>
                                           <input type="text"  id="clientdate" runat="server" style="display:none"/>
                                        <input type="text"  id="daction" runat="server" style="display:none"/>
							        </span>
						        </div>

      <script>
              $( function() {
                  //$("#start_datepicker").datepicker();
                  $("#start_datepicker").datepicker({
                      dateFormat: "dd-MM-yy",
                      autoSize: true,
                      currentText: "Now",
                      changeYear: true
                      
                      //closeText: "Close",
                      //constrainInput: false,
                      //showOptions: { direction: "up" }
                     
                  });
              });
           
              $(function () {
                  $("#end_datepicker").datepicker({
                      dateFormat: "dd-MM-yy",
                      defaultDate: +7,
                      autoSize: true,
                      changeYear: true
                  });
              });


              $(document).ready(function () {

                  //$("#start_datepicker,#end_datepicker").datepicker({
                  //    changeMonth: true,
                  //    changeYear: true,
                  //    firstDay: 1,
                  //    dateFormat: 'dd/mm/yy',
                  //})

                  //$("#startdate").datepicker({ dateFormat: 'dd-mm-yy' });
                  //$("#enddate").datepicker({ dateFormat: 'dd-mm-yy' });

                  $('#end_datepicker').change(function () {
                      var start = $('#start_datepicker').datepicker('getDate');
                      var end = $('#end_datepicker').datepicker('getDate');

                      if (start <= end) {
                          //var days = (end - start) / 1000 / 60 / 60 / 24;
                          //$('#days').val(days);
                      }
                      else {
                          alert("Start date should not be greater than End date!");
                          //$('#start_datepicker').val("");
                          $('#end_datepicker').val($('#start_datepicker').datepicker('getDate'));
                          //$('#days').val("");

                          var today = new Date();
                          var dd = today.getDate();
                          var mm = today.getMonth() ; //January is 0!
                          var yyyy = today.getFullYear();

                          if (dd < 10) {
                              dd = '0' + dd
                          }

                          //if (mm < 10) {
                          //    mm = '0' + mm
                          //}

                          //today = dd + '-' + mm + '-' + yyyy;

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

                          $('#end_datepicker').val(dd + "-" + months[mm] + "-" + yyyy);

                      }
                  }); //end change function
              }); //end ready

  </script>



						         <div class="w3_agileits_main_grid w3l_main_grid">
							        <span class="agileits_grid">
								        <label style="font-size:12px">Terms of Service </label>
                                        <textarea name="Task" id="txtserviceterm" runat="server" style="margin-right:0px" placeholder="Enter terms of service..." rows="4"  autofocus="autofocus"></textarea>
							        </span>
						        </div>

						        <div class="w3_agileits_main_grid w3l_main_grid">
							        <span class="agileits_grid">
								        <label style="font-size:12px">Work &nbsp;&nbsp Description<span class="star">*</span></label>
                                        <textarea name="Task" id="tDetails" runat="server" style="margin-right:0px" placeholder="Please describe the work/service required..." rows="6" required="required" autofocus="autofocus"></textarea>
							        </span>
						        </div>

                                 <div class="w3_agileits_main_grid w3l_main_grid">
							        <span class="agileits_grid">
								        <label style="font-size:12px">Supervision Team <span class="star">*</span></label>
                                       <input type="text"  id="supervisionteam" runat="server"/>
							        </span>
						        </div>
                                <div class="w3_agileits_main_grid w3l_main_grid">
							        <span class="agileits_grid">
								        <label style="font-size:12px">Attention Level: <span class="star">*</span></label>
                                       <asp:DropDownList ID="ActionLevel"  style="background-color:white" ForeColor="black"  runat="server"> 
                                            <asp:ListItem value="Controlled" Selected="True" >Controlled</asp:ListItem>  
                                            <asp:ListItem value="Severe" >Severe</asp:ListItem>
                                            <asp:ListItem value="Critical">Critical</asp:ListItem>
                                            <asp:ListItem value="Resolved">Resolved</asp:ListItem>
                                       </asp:DropDownList>
							        </span>

						        </div>
                                        <div style="display:none" >
                                              <textarea type="text"  id="hiddenTextforGrid" runat="server" />
        
                                        </div>

						        <div class="w3_agileits_main_grid w3l_main_grid">
							        <span class="agileits_grid">
								        <label style="font-size:12px">Scope of Work</label>
                   
							        </span>
                                    <div style="line-height:0.5px">
                                              <asp:RadioButtonList id="RadioScopeList" runat="server" >
                                            <asp:ListItem value="In Compound" Selected="True" >In Compound</asp:ListItem>  
                                            <asp:ListItem value="Entire Estate">Entire Estate</asp:ListItem>
                                            </asp:RadioButtonList>
                                    </div>
                                        <input id="dImgPath" style="display:none;"  type="text" runat="server" name="dImgPath" />
						       
                                  </div>
    <br />
    <div style="overflow-x:auto;width:auto">
    <ASP:GridView ID="gvCustomers" CssClass = "table" runat="server"  AutoGenerateColumns="false" BorderStyle="Solid" ShowFooter="true" SelectedRowStyle-Wrap="true" >
    <Columns>
        <asp:TemplateField HeaderText="Labour Description" ItemStyle-Width="525px" HeaderStyle-Font-Bold="true"   ItemStyle-Wrap="true">
            
            <ItemTemplate>
             <%# Eval("LabourDescr") %>
        
            </ItemTemplate>
              <FooterTemplate  >
                    <asp:TextBox ID="txtLabourDescr" runat="server"  Style="margin:0px;padding:0px" Text="" Wrap="true" />
                </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Hours" ItemStyle-Width="50px"  HeaderStyle-Font-Bold="true">
            <ItemTemplate>
                <%# Eval("HoursRequired")%>
            </ItemTemplate>
              <FooterTemplate>
                     <asp:TextBox ID="txtHoursRequired" runat="server" Width="50px"  Text="0" Style="margin:0px;padding:1px"  onkeypress="return isDecimal(event)"   />
                </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount" ItemStyle-Width="80px"  HeaderStyle-Font-Bold="true">
            <ItemTemplate>
                <%# Eval("AmountRequired")%>
            </ItemTemplate>
              <FooterTemplate>
                    <asp:TextBox ID="txtAmountRequired" runat="server" Width="60px"  Text="0" Style="margin:0px;padding:1px"  onkeypress="return isDecimal(event)"  />
                
                <%--  <button type="button" id="btnAdd"   onclick="return AddRow()" class="btn btn-info"  >Add</button>--%>
                </FooterTemplate>
   
        </asp:TemplateField>

      <%--   <asp:TemplateField HeaderText="dddd"  ItemStyle-Width="80px"  HeaderStyle-Font-Bold="true">

           <ItemTemplate> 
           </ItemTemplate>
             
        </asp:TemplateField>--%>
               <asp:TemplateField HeaderText=""  ItemStyle-Width="80px"  HeaderStyle-Font-Bold="true">
                    <ItemTemplate>
           <asp:LinkButton  ID="gdlbtnRemove" runat="server" width="80px"  OnClientClick="return RemoveRow(this)">Remove</asp:LinkButton> 
       
            </ItemTemplate>
              <FooterTemplate >
                 
                    <%--<asp:TextBox ID="txtDonotdelete" Visible="false" runat="server" Width="60px"  Text="0"/>--%>
                  <button type="button" id="btnAdd"  style="padding:2px;"  onclick="return AddRow()" class="btn btn-info"  > &nbsp;Add&nbsp; </button>
               
                </FooterTemplate>

        </asp:TemplateField>

      <%--    <asp:TemplateField HeaderText=" " ItemStyle-Width="50px"  HeaderStyle-Font-Bold="true">

              <FooterTemplate>
                    <asp:TextBox ID="txtAmountRequired" runat="server" Width="60px"  Text="0"  TextMode="Number" />
                  <button type="button" id="btnAdd"   onclick="return AddRow()" class="btn btn-info"  >Add</button>
                </FooterTemplate>

        </asp:TemplateField>--%>

    </Columns>
       
</ASP:GridView>
   
     
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


    function RemoveRow(item) {
        var table = document.getElementById('gvCustomers');
        table.deleteRow(item.parentNode.parentNode.rowIndex);

        fillhiddenTextforGrid();

        return false;
    }

</script>
        <script>

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
                var formattedwithtime = dd + "-" + months[mm] + "-" + yyyy + " " + hours + ":" + minutes + ":" + seconds;

  
                if (document.getElementById("daction").value != "Edit") {
                    document.getElementById("start_datepicker").value = formatted;
                    document.getElementById("end_datepicker").value = formatted;
                }
                document.getElementById("clientdate").value = formattedwithtime;
                
               

            }

        </script>
<script type="text/javascript">

    function RemoveGridBlankRow()
    {
      if (document.getElementById("daction").value != "Edit") {
            var gridView = document.getElementById("<%=gvCustomers.ClientID %>");
            //Reference the TBODY tag.
            var tbody = gridView.getElementsByTagName("tbody")[0];

            var row = tbody.getElementsByTagName("tr")[1];
            tbody.removeChild(row);
      }
      else
      {
          var x = document.getElementById("btnClear");
           x.style.display = "none";
      }
        getclientdate();
         

    }

    function ClearGrid() {
        //Reference the GridView.
        var gridView = document.getElementById("<%=gvCustomers.ClientID %>");
        //Reference the TBODY tag.

        var tbody = gridView.getElementsByTagName("tbody")[0];

        var GridviewRows = $("#<%=gvCustomers.ClientID%> tr").length;
        var rowlenght = GridviewRows - 1;
        var table = document.getElementById('gvCustomers');
        for (var i = rowlenght; i > 1; i--) {
            var row = tbody.getElementsByTagName("tr")[i];
            //if (row.getElementsByTagName("td")[i].innerHTML != "")  //tbody.removeChild(row);
            //{
                table.deleteRow(i);
            //}

        }

        document.getElementById("hiddenTextforGrid").value = "";
    }

 
    function AddRow() {

       <%-- if (document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtLabourDescr")).ClientID%>").value == null) return;--%>
     if (document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtLabourDescr")).ClientID%>").value == "") return;

        if (document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtHoursRequired")).ClientID%>").value == "") {
            document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtHoursRequired")).ClientID%>").value = 0;
        }

        if (document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtAmountRequired")).ClientID%>").value == "") {
            document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtAmountRequired")).ClientID%>").value = 0;
        }

        if (document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtHoursRequired")).ClientID%>").value < 0) {
            alert("Hours cannot be less less that zero (0)");
            return;
        }

           if (document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtAmountRequired")).ClientID%>").value < 0) {
            alert("Amount cannot be less less that zero (0)");
            return;
        }

    //Reference the GridView.
    var gridView = document.getElementById("<%=gvCustomers.ClientID %>");
 
    //Reference the TBODY tag.
    var tbody = gridView.getElementsByTagName("tbody")[0];
 
    //Reference the first row.
    var row = tbody.getElementsByTagName("tr")[1];

    //Check if row is dummy, if yes then remove.
    if (row.getElementsByTagName("td")[0].innerHTML.replace(/\s/g, '') == "") {
        tbody.removeChild(row);
    }
 
    //Clone the reference first row.
    row = tbody.getElementsByTagName("tr")[1];
    row = row.cloneNode(true);
 

    if (document.getElementById("hiddenTextforGrid").value == "") {

        document.getElementById("hiddenTextforGrid").value = document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtLabourDescr")).ClientID%>").value + " - " + document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtHoursRequired")).ClientID%>").value + " ** " + document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtAmountRequired")).ClientID%>").value;
    }
    else
    {
        document.getElementById("hiddenTextforGrid").value = document.getElementById("hiddenTextforGrid").value + " @ " + document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtLabourDescr")).ClientID%>").value + " - " + document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtHoursRequired")).ClientID%>").value + " ** " + document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtAmountRequired")).ClientID%>").value;
    }
      //  document.getElementById("Text1").value = 0


    //Add the Name value to first cell.
   var txtLabourDescr = document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtLabourDescr")).ClientID%>");

        SetValue(row, 0, "LabourDescr", txtLabourDescr);
       

    var txtHoursRequired = document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtHoursRequired")).ClientID%>");
    SetValue(row, 1, "HoursRequired", txtHoursRequired);
 
    var txtAmountRequired = document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtAmountRequired")).ClientID%>");
    SetValue(row,2, "AmountRequired", txtAmountRequired);

    

    //Add the row to the GridView.
    tbody.appendChild(row);

    


    document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtHoursRequired")).ClientID%>").value = 0;
    document.getElementById("<%=((TextBox)gvCustomers.FooterRow.FindControl("txtAmountRequired")).ClientID%>").value = 0;
        return false;


    };


    function fillhiddenTextforGrid() {
        var table, tbody, i, rowLen, row, j, colLen, cell;
        document.getElementById("hiddenTextforGrid").value = "";
        table = document.getElementById("gvCustomers");
        tbody = table.tBodies[0];
        var dlabourdesc, dcost, dtime;
        for (i = 1, rowLen = tbody.rows.length; i < rowLen; i++) {
            row = tbody.rows[i];
            for (j = 0, colLen = 3; j < colLen; j++) {  // row.cells.length
                cell = row.cells[j];
               // alert(row.cells[j].innerText);
                if (j == 0) dlabourdesc = cell.innerText;
                if (j == 1) dtime = cell.innerText;
                if (j == 2)  dcost = cell.innerText;
            }

            if (dlabourdesc !="") {
                if (document.getElementById("hiddenTextforGrid").value == "")
                    document.getElementById("hiddenTextforGrid").value = dlabourdesc + " - " + dtime + " ** " + dcost;
                else
                    document.getElementById("hiddenTextforGrid").value = document.getElementById("hiddenTextforGrid").value + " @ " +  dlabourdesc + " - " + dtime + " ** " + dcost;;
            }
        }
    }
 
function SetValue(row, index, name, textbox) {
    //Reference the Cell and set the value.
    row.cells[index].innerHTML = textbox.value;
  //Create and add a Hidden Field to send value to server.
    var input = document.createElement("input");
    input.type = "hidden";
    input.name = name;
    input.value = textbox.value;
    row.cells[index].appendChild(input);
    if (document.getElementById("daction").value != "Edit")
        row.cells[3].innerHTML = "";

    //Clear the TextBox.
    textbox.value = "";
}
</script>


                            <div class="w3_agileits_main_grid w3l_main_grid">
                                 <span class="agileits_grid">
                                      <button type="button" id="start_camera"  runat="server" class="btn btn-info" data-toggle="collapse" >Take a photo</button>
                                    <button type="button" id="btnshowphoto" style="visibility:hidden"  runat="server" onclick="showpictmodal()" class="btn btn-info"  >View Photo</button>
                                          <button type="button" id="btnClear"   onclick="ClearGrid()"  class="btn btn-danger" style="position:relative;float:right;padding:1px"  >Clear Grid</button>
                                <%-- style="display:none" --%>
                                 </span>

                            </div>

					<div class="w3_main_grid">
                        <table style="width:100%">
                            <tr>
                                <td>
                                        <div class="w3_main_grid_right" style="text-align:left">
			                             <div  style="width:100px;background-color:black;color:white">
                                              <a  href="#" onclick="goBack()"><span style="color:white;text-align:center">  Go back  </span></a>
                                        </div>
						                </div>
                                    </td>
                                 <td>
                                        <div class="w3_main_grid_right" style="text-align:left">
                                             <div  style="width:100px;background-color:black;color:white">
                                              <a  href="MainStaff.aspx"><span style="color:white;text-align:center">  MENU  </span></a>
                                        </div>
						                </div>
                                    </td>
                                  <td>
						                <div class="w3_main_grid_right">
							                <asp:Button ID="btnsubmit" runat="server" style="width:100px" OnClick="btnsubmit_Click" Text="Save" />
						                </div>
                                </td>
                                </tr>
                            <tr>
                                <td style="font-size:small;width:100%; margin:auto" colspan="2" >
                                <%--   <span style="text-align:center"> <strong>PLEASE NOTE!!!!</strong> Complaint would only be seen during working hours.</span>--%>
                                </td>
                            </tr>
                            </table>
					</div>



    
				</form>
			</div>
			
		<!-- Calendar -->
			<link rel="stylesheet" href="css/form/jquery-ui.css" />
				<script src="js/form/jquery-ui.js"></script>
					<script>
						$(function() {
							$( "#datepicker" ).datepicker();
						});
					</script>
		<!-- //Calendar -->

              <script>
                  function goBack() {

                      //location.href = 'MainClient.aspx';
                      //window.history.back();
                      if (document.getElementById("daction").value == "Edit") 
                          window.location.href = "workorderprofile.aspx";
                      else
                          window.location.href = "complaintlistforworkorder.aspx";
                    }
              </script>

			<div class="w3layouts_copy_right">
				<%--<div class="container">--%>
							<p style=" font-size:small;margin-right: auto;margin-left: auto; margin-top: 1em; margin-bottom: 0em"> &copy; 2018 | Design by  <a href="http://www.stacklogicsystems.com" target="=_blank">StackLogic Systems, Ltd.</a> <a href="http://w3layouts.com" target="=_blank" style="color:rgba(0, 0, 0, 0)">W3layouts</a></p>
				<%--</div>--%>
			</div>
		</div>
	</div>
	</div>
<!-- //footer -->



     <!-- Modal -->
  
  <div class="modal fade" id="myModal" role="dialog" style="height:100vh" >
   <%-- <div class="modal-dialog">--%>
    
      <!-- Modal content-->
   <%--   <div class="modal-content" id="dModal">--%>
       <%-- <div class="modal-header" style="padding:10px 10px;">--%>
                <%--    <button type="button" id="closeMyModal" class="close" data-dismiss="modal" >&times;</button> --%>
         <%-- <h5> Take Picture of complaint area</h5>--%>
       <%-- </div>--%>
        <div class="modal-content1" > <%-- style="padding:40px 50px;"--%>
            
          <%--<div id="mainDiv" class="modal-dialog" style="width:auto;margin:0px">--%>

  <div id="minorDiv" class="app" style="width:100%;height:100vh;margin:auto">

 
    <video controls="controls" autoplay="autoplay" id="camera-stream" style="width:100%;height:100%;margin:auto" ></video>
    <img style="width:100%;height:100%;margin:auto" id="snap"/>

    <p id="error-message"></p>

    <div class="controls" title="Take Picture of complaint area">

            <a href="#" id="delete-photo" title="Delete Photo" class="disabled"><i class="material-icons">delete</i></a>
            <a href="#" id="take-photo" data-dismiss="modal" title="Take Photo"><i  class="material-icons">camera_alt</i></a>
            <a href="#" id="close-photo" data-dismiss="modal" onclick="closeModal()" title="Close"><i class="material-icons">close</i></a>
     
     <%-- <a href="#" id="close-photo" download="selfie.png" title="Save Photo" class="disabled"><i class="material-icons">file_download</i></a> --%> 
    </div>

    <!-- Hidden canvas element. Used for taking snapshot of video. -->
    <canvas  id="myCanvas"></canvas>

  <%--</div>--%>

<%--</div>--%>
        <%--<div class="modal-footer">
              <a href="#" id="start_camera" class="visible">Touch here to start the app.</a>
        </div>--%>
      </div>
      
  <%--  </div>--%>
  </div> 
</div>

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

 
    <script>
   function closeModal() {

       //e.preventDefault();
    //   video.pause();
    //video.src = null;
    //localStream.getVideoTracks()[0].stop();

       var MediaStream = window.MediaStream;

       if (typeof MediaStream === 'undefined' && typeof webkitMediaStream !== 'undefined') {
           MediaStream = webkitMediaStream;
       }

       /*global MediaStream:true */
       if (typeof MediaStream !== 'undefined' && !('stop' in MediaStream.prototype)) {
           MediaStream.prototype.stop = function () {
               this.getAudioTracks().forEach(function (track) {
                   track.stop();
               });

               this.getVideoTracks().forEach(function (track) {
                   track.stop();
               });
           };
       }

    //$('#dModal').modal('toggle'); //or  
    $('#dModal').modal('hide');
    //return false;
}
</script>


<%--====================camera===============--%>

     <script>
      function watermarkedDataURL(ocanvas, text) {
          var tempCtx = ocanvas.getContext('2d');
  
          var cw, ch;
          cw =ocanvas.width;
          ch =  ocanvas.height;

          tempCtx.drawImage(ocanvas, 0, 0);


          tempCtx.font = "24px verdana";
          var textWidth = tempCtx.measureText(text).width;
          tempCtx.globalAlpha = .50;
          tempCtx.fillStyle = 'white'
          tempCtx.fillText(text, cw - textWidth - 10, ch - 20);
          tempCtx.fillStyle = 'black'
          tempCtx.fillText(text, cw - textWidth - 10 + 2, ch - 20 + 2);

       
      }
  </script>

    <script>
        function showpictmodal()
        {

            if (document.getElementById("dImgPath").value == "")
                alert("Image not yet captured!!!");
            else
                $('#myphotoModal').modal({ backdrop: 'static', keyboard: false });
        }
    </script>

     <script>
        function getUserMedia(options, successCallback, failureCallback) {
            var api = navigator.getUserMedia || navigator.webkitGetUserMedia ||
              navigator.mozGetUserMedia || navigator.msGetUserMedia;
            if (api) {
                return api.bind(navigator)(options, successCallback, failureCallback);
            }
        }

        function getStream (type) {
            if (!navigator.getUserMedia && !navigator.webkitGetUserMedia &&
              !navigator.mozGetUserMedia && !navigator.msGetUserMedia) {
                alert('Camera not accessible....User Media API not supported.');
                return;
            }

            var constraints = {};
            constraints[type] = true;
            getUserMedia(constraints, function (stream) {
                var mediaControl = document.querySelector(type);
    
                if ('srcObject' in mediaControl) {
                    mediaControl.srcObject = stream;
                    mediaControl.src = (window.URL || window.webkitURL).createObjectURL(stream);
                } else if (navigator.mozGetUserMedia) {
                    mediaControl.mozSrcObject = stream;
                }
            }, function (err) {
                alert('Error: ' + err);
            });

        }
       


     


    </script>

    <script>

    document.addEventListener('DOMContentLoaded', function () {

        // References to all the element we will need.
        var video = document.querySelector('#camera-stream'),
            image = document.querySelector('#snap'),
            start_camera = document.querySelector('#start_camera'),
            controls = document.querySelector('.controls'),
            take_photo_btn = document.querySelector('#take-photo'),
            delete_photo_btn = document.querySelector('#delete-photo'),
            download_photo_btn = document.querySelector('#download-photo'),
            error_message = document.querySelector('#error-message');


        //// The getUserMedia interface is used for handling camera input.
        //// Some browsers need a prefix so here we're covering all the options
       
        //navigator.getWebcam = (navigator.getUserMedia || navigator.webKitGetUserMedia || navigator.moxGetUserMedia || navigator.mozGetUserMedia || navigator.msGetUserMedia);
        //if (navigator.mediaDevices.getUserMedia) {
        //    //  navigator.mediaDevices.getUserMedia({ audio: true, video: true }) //------------------for audio
        //    navigator.mediaDevices.getUserMedia({ video: true })
        //    .then(function (stream) {
        //        //Display the video stream in the video object
        //        video.src = window.URL.createObjectURL(stream);
        //        //video.addEventListener('click', takeSnapshot);
        //    })
        //     .catch(function (e) { logError(e.name + ": " + e.message); });
        //}
        //else {

        //    navigator.getWebcam({ video: true },
        //       //  navigator.getWebcam({ audio: true, video: true }, //------------------for audio
        //         function (stream) {
        //             //Display the video stream in the video object
        //             video.src = window.URL.createObjectURL(stream);
        //             //video.addEventListener('click', takeSnapshot);
        //         },
        //         function () { logError("Web cam is not accessible."); });
        //}


        // Mobile browsers cannot play video without user input,
        // so here we're using a button to start it manually.
        start_camera.addEventListener("click", function (e) {

          
       
            $('#myModal').modal({ backdrop: 'static', keyboard: false })
      
            e.preventDefault();

            // Start video playback manually.

            getStream('video');
            video.play();
            showVideo();

        });


        take_photo_btn.addEventListener("click", function (e) {

            e.preventDefault();

            var snap = takeSnapshot();

            // Show image. 
            image.setAttribute('src', snap);
            image.classList.add("visible");

            // Enable delete and save buttons
            delete_photo_btn.classList.remove("disabled");
            download_photo_btn.classList.remove("disabled");
 

            // Set the href attribute of the download button to the snap url.
            download_photo_btn.href = snap;

      
            document.getElementById("myImg").style.visibility = "visible"

            // Pause video playback of stream.
            video.pause();


        });


        delete_photo_btn.addEventListener("click", function (e) {

            e.preventDefault();

            document.getElementById("dImgPath").value = "";
            document.getElementById("btnshowphoto").style.visibility = "hidden";

            // Hide image.
            image.setAttribute('src', "");
            image.classList.remove("visible");
            myImg.src = "";

            // Disable delete and save buttons
            delete_photo_btn.classList.add("disabled");
            //download_photo_btn.classList.add("disabled");

            // Resume playback of stream.
            video.play();

        });

       

        function showVideo() {
            // Display the video stream and the controls.

            hideUI();
            video.classList.add("visible");
            controls.classList.add("visible");

        }


        function takeSnapshot() {
            // Here we're using a trick that involves a hidden canvas element.  
        
            var hidden_canvas = document.querySelector('canvas'),
                context = hidden_canvas.getContext('2d');


            var width = video.videoWidth,
                height = video.videoHeight;

      

            if (width && height) {

                // Setup a canvas with the same dimensions as the video.
                hidden_canvas.width = width;
                hidden_canvas.height = height;
                myImg.width = width;
                myImg.height = height;
                

                // Make a copy of the current frame in the video on the canvas.
                context.drawImage(video, 0, 0, width, height);
              
              
                var dataURL = watermarkedDataURL(myCanvas, "Dukiya pM!");
                document.getElementById("dImgPath").value = document.getElementById("myCanvas").toDataURL("image/png").replace(/^data:image\/(png|jpg);base64,/, "");
                document.getElementById("btnshowphoto").style.visibility = "visible";

                // Turn the canvas image into a dataURL that can be used as a src for our photo.

                myImg.src = hidden_canvas.toDataURL('image/png');
              

                return hidden_canvas.toDataURL('image/png');
            }

        }


        function displayErrorMessage(error_msg, error) {
            error = error || "";
            if (error) {
                console.error(error);
            }

            error_message.innerText = error_msg;

            hideUI();
            error_message.classList.add("visible");
        }


        function hideUI() {
            // Helper function for clearing the app UI.

            controls.classList.remove("visible");
            //start_camera.classList.remove("visible");
            video.classList.remove("visible");
            snap.classList.remove("visible");
            error_message.classList.remove("visible");
        }

    });

</script>



</body>
</html>