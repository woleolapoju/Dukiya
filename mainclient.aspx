<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mainclient.aspx.cs" Inherits="MainClient" %>

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
		<link rel="stylesheet" type="text/css" href="css/menu/component1.css" />
		<script src="js/menu/modernizr-2.6.2.min.js"></script>
        <link href="css/Dashboard/font-awesome.css" rel="stylesheet"/> 


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
				<%--<img src="images/applogo_black.png" />--%>
                <h4><i>for</i></h4> 
                <h2>Gabadan Properties Ltd.</h2>
             
                
                <nav class="codrops-demos">
                    <a href="#">
                        <label id="lblclientname" runat="server">Client name</label></a> of
					<a href="#">
                        <label id="lblproperty" runat="server">Property name</label>
					</a>
				</nav>
			</header>
		<%--	<section>
				<p>Soko leek tomatillo quandong winter purslane caulie jícama daikon dandelion bush tomato. Daikon cress amaranth leek cabbage black-eyed pea kakadu plum scallion watercress garbanzo gram caulie welsh onion water spinach tomatillo groundnut desert raisin. Wakame salsify bunya nuts spring onion lotus root prairie turnip fennel onion dandelion black-eyed pea bok choy zucchini taro. Jícama collard greens amaranth bell pepper catsear brussels sprout sweet pepper daikon spring onion aubergine broccoli rabe quandong mustard celery corn groundnut peanut. Mung bean fennel eggplant water spinach bunya nuts sierra leone bologi epazote okra caulie groundnut black-eyed pea parsnip fava bean squash.</p>
				<p>Parsnip tomatillo swiss chard garbanzo gourd potato silver beet. Celery swiss chard melon zucchini arugula pea quandong beet greens radish artichoke black-eyed pea endive winter purslane horseradish garlic amaranth collard greens chickpea. Rock melon pumpkin collard greens celery broccoli rabe endive nori brussels sprout gourd courgette sea lettuce artichoke desert raisin coriander chard.</p>
				<p>Collard greens ricebean horseradish wattle seed chard epazote potato peanut gram earthnut pea spinach yarrow desert raisin salad mung bean summer purslane fennel. Water spinach celery cucumber grape cauliflower nori daikon sweet pepper endive lentil turnip greens catsear leek beet greens. Melon seakale parsnip soybean bamboo shoot fennel scallion. Coriander groundnut squash corn aubergine bitterleaf azuki bean dandelion courgette broccoli rabe. Chickweed salsify chickweed groundnut nori okra lentil water spinach rock melon broccoli. Soko leek tomatillo quandong winter purslane caulie jícama daikon dandelion bush tomato. Daikon cress amaranth leek cabbage black-eyed pea kakadu plum scallion watercress garbanzo gram caulie welsh onion water spinach tomatillo groundnut desert raisin. Wakame salsify bunya nuts spring onion lotus root prairie turnip fennel onion dandelion black-eyed pea bok choy zucchini taro. Jícama collard greens amaranth bell pepper catsear brussels sprout sweet pepper daikon spring onion aubergine broccoli rabe quandong mustard celery corn groundnut peanut. Mung bean fennel eggplant water spinach bunya nuts sierra leone bologi epazote okra caulie groundnut black-eyed pea parsnip fava bean squash.</p>
				<p>Parsnip tomatillo swiss chard garbanzo gourd potato silver beet. Celery swiss chard melon zucchini arugula pea quandong beet greens radish artichoke black-eyed pea endive winter purslane horseradish garlic amaranth collard greens chickpea. Rock melon pumpkin collard greens celery broccoli rabe endive nori brussels sprout gourd courgette sea lettuce artichoke desert raisin coriander chard.</p>
				<p>Collard greens ricebean horseradish wattle seed chard epazote potato peanut gram earthnut pea spinach yarrow desert raisin salad mung bean summer purslane fennel. Water spinach celery cucumber grape cauliflower nori daikon sweet pepper endive lentil turnip greens catsear leek beet greens. Melon seakale parsnip soybean bamboo shoot fennel scallion. Coriander groundnut squash corn aubergine bitterleaf azuki bean dandelion courgette broccoli rabe. Chickweed salsify chickweed groundnut nori okra lentil water spinach rock melon broccoli.</p>
			</section>--%>
			<div class="component">
				<!-- Start Nav Structure -->
				<button class="cn-button" id="cn-button">Menu</button>
				<div class="cn-wrapper" id="cn-wrapper">
				    <ul>
                       <%--  <li><a href="Complaint.aspx"><span>Complaint</span></a></li>--%>


                       
                      <li><a title="Complaint" href="Complaint.aspx"><span class="fa fa-comment"></span></a></li>

				     <%-- <li><a href="#"><span class="icon-picture"></span></a></li>--%>
				      <li><a href="#"><span class="icon-headphones"></span></a></li>
				      <li><a href="#"><span class="icon-home"></span></a></li>
				      <li><a href="#"><span class="icon-facetime-video"></span></a></li>
				      <li><a href="#"><span class="icon-envelope-alt"></span></a></li>
				     </ul>
				</div>
				<div id="cn-overlay" class="cn-overlay"></div>
				<!-- End Nav Structure -->
			</div>
		</div><!-- /container -->
		<script src="js/menu/polyfills.js"></script>
		<script src="js/menu/demo1.js"></script>
		<!-- For the demo ad only -->   
<%--<script src="http://tympanus.net/codrops/adpacks/demoad.js"></script>--%>
	</body>
</html>