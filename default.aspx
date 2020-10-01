﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
<head>
<title>Dukiya-Property Manager</title>
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" content="Property Management System" />
<meta name="keywords" content="Dukiya,MegaHit Systems,StackLogic Systems,Property Management Solution," />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<link rel="shortcut icon" href="/images/appicon.ico"/>
<!-- Custom Theme files -->
<link href="css/styleDefault.css" rel="stylesheet" type="text/css" media="all" />

<!-- //Custom Theme files --> 
<!-- web font --> 
<link href="//fonts.googleapis.com/css?family=Cormorant+Garamond:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">
<link href="//fonts.googleapis.com/css?family=Arsenal:400,400i,700,700i" rel="stylesheet">
<!-- //web font -->
</head>
<body onload="checkCookie()">


	<!-- main --> 
	<div class="main-agileinfo slider ">
		<div class="items-group">
            
			<div class="item agileits-w3layouts">
				<div class="block text main-agileits"> 
					<span class="circleLight"></span> 
					<!-- login form -->
					<div class="login-form loginw3-agile"> 
						<div class="agile-row">
                            <div style="padding:0px; margin-right: auto;margin-left: auto">
                                <h1>Dukiya</h1> 
                                 <h2 style="color:yellow"><strong>Property Manager</strong></h2> 
                                 <h4><i>for</i></h4> 
                     <%--        <h2>  <a href="http://www.gabadan.com" target="=_blank">Gabadan Properties Ltd</a> </h2> --%>
                             
                                  <div class="w3lsfooteragileits wthree" style="text-align: center;padding:0; margin-top: 0em; margin-bottom: 2em; line-height: 0.2em;">
				                        <p style=" font-size:x-large; text-align: center;padding:0; margin-top: 0em; margin-bottom: 2em; line-height: 0.7em;">	 <a href="http://www.gabadan.com" target="=_blank">Gabadan Properties Ltd</a> </p>
				            </div> 
                            </div>
							
							<div class="login-agileits-top"> 	
								<%--<form action="#" method="post"> --%>
                                 <form runat="server">
                                   
									<p>User Name </p>
									<%--<input type="text" id="user_username" runat="server" class="name" name="user name" required=""/>--%>
                                     <input type="text" id="userID" runat="server" class="name" name="username" required=""/>  
									<p>Password</p>
									<input type="password" id="userPwd" runat="server" class="password" name="Password" required=""/>  
									<label class="anim" style="margin-top: 1em; margin-bottom: 1em"">
										<input type="checkbox" class="checkbox" id="user_Remember">
										<span> Remember me ?</span> 
									</label>   
									<%--<input type="submit" value="Login"> --%>

                                        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click"  OnClientClick="rememberUser()" Text="Log In" />


								</form> 	
							</div> 
							<%--<div class="login-agileits-bottom wthree"> 
								<h6><a href="#">Forgot password?</a></h6>
							</div> --%>
                            <div class="w3lsfooteragileits wthree">
					<p style=" font-size:small;margin-right: auto;margin-left: auto; margin-top: 1em; margin-bottom: 0em"> &copy; 2018 | Design by  <a href="http://www.stacklogicsystems.com" target="=_blank">StackLogic Systems, Ltd.</a> <a href="http://w3layouts.com" target="=_blank" style="color:rgba(0, 0, 0, 0)">W3layouts</a></p>
				</div> 
						</div>  
					</div>   
				</div>
				<%--<div class="w3lsfooteragileits">
					<p> &copy; 2018 Dukiya Property Manager | Design by  <a href="http://www.stacklogicsystems.com" target="=_blank">StackLogic Systems, Ltd.</a> <a href="http://w3layouts.com" target="=_blank" style="color:rgba(0, 0, 0, 0)">W3layouts</a></p>
				</div> --%>
			</div>   
		</div>
	</div>	 
	<!-- //main --> 
     <%--Cookie functions  for remember--%>
    <script>

        function setCookie(cname, cvalue, exdays) {
            var d = new Date();
            d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
            var expires = "expires=" + d.toGMTString();
            document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
        }

        function checkCookie() {
            var useruserId = getCookie("dukiya_userId");

            if (useruserId != "") {
                document.getElementById("userID").value = useruserId;
                document.getElementById("user_Remember").checked = true;
            }

            //if (user != "") {
            //   alert("Welcome again " + user);

            //}
            // else {
            //    user = prompt("Please enter your name:", "");
            //    if (user != "" && user != null) {
            //        setCookie("username", user, 30);
            //    }
            //}
        }

        function getCookie(cname) {
            var name = cname + "=";
            var decodedCookie = decodeURIComponent(document.cookie);
            var ca = decodedCookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') {
                    c = c.substring(1);
                }
                if (c.indexOf(name) == 0) {
                    return c.substring(name.length, c.length);
                }
            }
            return "";
        }
    </script>

      <script>
         function rememberUser() {

             var checkBox = document.getElementById("user_Remember");
          
             if (checkBox.checked == true) {
                 setCookie("dukiya_userId", document.getElementById("userID").value, 365);
             } else {
                 setCookie("dukiya_userId", "", 365);
             }
        }
    </script>

</body>
</html>
