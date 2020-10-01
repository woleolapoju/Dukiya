<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mainstaff.aspx.cs" Inherits="MainStaff"   %>

<!DOCTYPE html>

<%--<html xmlns="http://www.w3.org/1999/xhtml">--%>
<html lang="en" class="no-js">
	<head>
		<meta charset="UTF-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"> 
		<meta name="viewport" content="width=device-width, initial-scale=1.0"> 
		<title>Dukiya - Property Manager</title>
		<meta name="description" content="Property Management System" />
		<meta name="keywords" content="Dukiya,MegaHit Systems,StackLogic Systems,Property Management Solution," />
		<meta name="author" content="Sara Soueidan for Codrops" />
		<link rel="shortcut icon" href="/images/appicon.ico"/>
		<link rel="stylesheet" type="text/css" href="css/menu/normalize.css" />
		<link rel="stylesheet" type="text/css" href="css/menu/demo.css" />
		<link rel="stylesheet" type="text/css" href="css/menu/component2.css" />
		<script src="js/menu/modernizr-2.6.2.min.js"></script>

<script type="text/javascript">
var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-7243260-2']);
_gaq.push(['_trackPageview']);
(function() {
var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();
</script>
  
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

	<body>

		<div class="container">
			<!-- Top Navigation -->
			<div class="codrops-top clearfix">
				<%--<a class="codrops-icon codrops-icon-prev" href="default.aspx"><span>Previous Demo</span></a>--%>
  
                  Username: <label id="lblusername" runat="server">?</label>
               <%-- <input type="text" id="userID" runat="server" class="name" name="username"  readonly="readonly"/>  --%>

               

				<span class="right"><a  href="default.aspx"><span>Log Off</span></a></span>
			</div>
			<header>
				<h1 style="line-height:0.5em"> <strong> Dukiya </strong><span style="font-size:large;   color:yellow;padding-top:0.5em">Property Manager</span></h1>	
				<%--<nav class="codrops-demos">
					<a href="index.html">Demo 1</a>
					<a class="current-demo" href="index2.html">Demo 2</a>
					<a href="interactivedemo/index.html">Intractive demo</a>
				</nav>--%>

 <h4><i>for</i></h4> 
                <h2>Gabadan Properties Ltd.</h2>
             

                <p>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </p>
                 <p>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </p>
                 <p>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </p>

                <%--  <p>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </p>
                  <p>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </p>
                  <p>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </p>--%>
                 
			</header>
			<div class="component">
				<h2>Gabadan Properties</h2>
				<!-- Start Nav Structure -->
				<button class="cn-button" id="cn-button">Menu</button>
				<div class="cn-wrapper" id="cn-wrapper" >
					<ul>
                       <li><a href="#"><span>Clients</span></a></li>
						<li><a href="complaintlistforinspection.aspx"><span>Inspection</span></a></li>
						<li><a href="complaintlistforworkorder.aspx"><span>Work <br /> Order</span></a></li>
						<li><a href="workorderlistings.aspx"><span>Activity <br /> log</span></a></li>
						<li><a href="servicecharge.aspx"><span style="color:crimson">Service <br /> Charge</span></a></li>
						<li><a href="Dashboard.aspx"><span>Dash <br /> Board</span></a></li>
						<li><a href="#"><span>Admin.</span></a></li>
					 </ul>
				</div>
				<!-- End of Nav Structure -->
			</div>
		<section>
				<%--<p>Soko leek tomatillo quandong winter purslane caulie jícama daikon dandelion bush tomato. Daikon cress amaranth leek cabbage black-eyed pea kakadu plum scallion watercress garbanzo gram caulie welsh onion water spinach tomatillo groundnut desert raisin. Wakame salsify bunya nuts spring onion lotus root prairie turnip fennel onion dandelion black-eyed pea bok choy zucchini taro. Jícama collard greens amaranth bell pepper catsear brussels sprout sweet pepper daikon spring onion aubergine broccoli rabe quandong mustard celery corn groundnut peanut. Mung bean fennel eggplant water spinach bunya nuts sierra leone bologi epazote okra caulie groundnut black-eyed pea parsnip fava bean squash.</p>	--%>
	
            <p>&nbsp</p>	

				<%--	<p  style="font-size:small;margin-right: auto;margin-left: auto; margin-top: 1em; margin-bottom: 0em"> &copy; 2018 | Design by  <a href="http://www.stacklogicsystems.com" target="=_blank">StackLogic Systems, Ltd.</a> </p>--%>
       
					<p style="text-align:center; font-size:small;margin-right: auto;margin-left: auto;"> &copy; 2018 | Design by  <a href="http://www.stacklogicsystems.com" target="=_blank">StackLogic Systems, Ltd.</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <a href="http://w3layouts.com" target="=_blank" style="color:rgba(0, 0, 0, 0)">W3layouts</a></p>
		
        
        </section>
		</div><!-- /container -->
  





         

 


		<script src="js/menu/polyfills.js"></script>
		<script src="js/menu/demo2.js"></script>
		<!-- For the demo ad only -->   
<%--<script src="http://tympanus.net/codrops/adpacks/demoad.js"></script>--%>
	</body>
</html>
