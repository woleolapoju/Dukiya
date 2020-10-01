
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Dukiya-Property Manager</title>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" content="Property Management System" />
<meta name="keywords" content="Dukiya,MegaHit Systems,StackLogic Systems,Property Management Solution," />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<link rel="shortcut icon" href="/images/appicon.ico"/>
    <style>
        body {
  padding: 0;
  margin: 0;
  font-family: "Oxygen", sans-serif;
}

.error-wall {
  width: 100%;
  height: 100%;
  position: fixed;
  text-align: center;
}
.error-wall.load-error {
  background-color: #f3785e;
}
.error-wall.matinence {
  background-color: #a473b1;
}
.error-wall.missing-page {
  background-color: #00bbc6;
}
.error-wall .error-container {
  display: block;
  width: 100%;
  position: absolute;
  left: 50%;
  top: 50%;
  transform: translate(-50%, -50%);
  -webkit-transform: translate(-50%, -50%);
  -moz-transform: translate(-50%, -50%);
}
.error-wall .error-container h1 {
  color: #fff;
  font-size: 80px;
  margin: 0;
}
@media (max-width: 850px) {
  .error-wall .error-container h1 {
    font-size: 65px;
  }
}
.error-wall .error-container h3 {
  color: #464444;
  font-size: 34px;
  margin: 0;
}
@media (max-width: 850px) {
  .error-wall .error-container h3 {
    font-size: 25px;
  }
}
.error-wall .error-container h4 {
  margin: 0;
  color: #fff;
  font-size: 40px;
}
@media (max-width: 850px) {
  .error-wall .error-container h4 {
    font-size: 35px;
  }
}
.error-wall .error-container p {
  font-size: 15px;
}
.error-wall .error-container p:first-of-type {
  color: #464444;
  font-weight: lighter;
}
.error-wall .error-container p:nth-of-type(2) {
  color: #464444;
  font-weight: bold;
}
.error-wall .error-container p.type-white {
  color: #fff;
}
@media (max-width: 850px) {
  .error-wall .error-container p {
    font-size: 12px;
  }
}
@media (max-width: 390px) {
  .error-wall .error-container p {
    font-size: 10px;
  }
}



.link-container {
  text-align: center;
}
a.more-link {
  text-transform: uppercase;
  font-size: 13px;
  background-color: #bbb;
  padding: 10px 15px;
  border-radius: 0;
  color: #fff;
  display: inline-block;
  margin-right: 5px;
  margin-bottom: 5px;
  line-height: 1.5;
  text-decoration: none;
  margin-top: 50px;
  letter-spacing: 1px;
}



    </style>
</head>
<body>
<div class="error-wall load-error">
  <div class="error-container">
    <h1>oh no...</h1>
    <h3>We have had an error</h3>
    <h5>An error Occurred in the Application And Your Page could not be Served</h5>
    <p>Sorry...give us feedback to correct the error</p>
      
    <p>  <a href="#" onclick="myFunction()">See details...</a></p>
      <div id="myDIV" style="display:none">
      <label id="lblError" runat="server">?</label>
</div>

<div class="link-container">
  <a href="Default.aspx" class="more-link">Home</a>
</div>
    

  </div>

</div>
    <script>
function myFunction() {
    var x = document.getElementById("myDIV");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}
</script>

</body>
</html>
