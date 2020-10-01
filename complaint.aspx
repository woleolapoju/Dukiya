<%@ Page Language="C#" AutoEventWireup="true" CodeFile="complaint.aspx.cs" Inherits="Complaint" %>

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

<style>
    .checkbox label:after {
  content: '';
  display: table;
  clear: both;
}

.checkbox .cr {
  position: relative;
  display: inline-block;
  border: 1px solid #a9a9a9;
  border-radius: .25em;
  width: 1.3em;
  height: 1.3em;
  float: left;
  margin-right: .5em;
}

.checkbox .cr .cr-icon {
  position: absolute;
  font-size: .8em;
  line-height: 0;
  top: 50%;
  left: 15%;
}

.checkbox label input[type="checkbox"] {
  display: none;
}

.checkbox label input[type="checkbox"]+.cr>.cr-icon {
  opacity: 0;
}

.checkbox label input[type="checkbox"]:checked+.cr>.cr-icon {
  opacity: 1;
}
</style>
</head>

<body>

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
                            <td ><h1 class="w3layouts_head">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Complaint Form</h1> 
                            </td>
                        </tr>

                    </table>
				
	
<form  runat="server" class="w3_form_post" style="margin-right:0px">
                       
                        <div class="w3_agileits_main_grid w3l_main_grid" >
                                <table>
                                    <tr>
                                        
                                        <td style="align-content:center; width:100%">
                                            <label style="width:auto;font-weight:300" id="lblusername" runat="server">Oluwole</label> : complaint on behalf of<br />
                                            <label style="width:auto;font-weight:700" id="lblClient" runat="server">?</label><br />
                                            <label style="width:auto;font-weight:700" id="lblproperty" runat="server">?</label>

                                        </td>
                                     </tr>
                                   
                                </table>
                        </div>
                        <br />
                  
     <div class="w3_agileits_main_grid w3l_main_grid" id="complaintlist" runat="server">
	 <legend>Pls choose appropriate complaints</legend>      
 
       <%--  <div class="checkbox">
              <label>
               <input type="checkbox" value="" checked  disabled>
               <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
               Option two is checked by default ddgdgdgdgdgdgdgd dbgdhdhdhdhdhd dgddhhdhd
               </label>
            </div>--%>

<script type="text/javascript">  
function LoadSelection()  
{  
    var checkboxes = document.getElementsByName("comcheck");
    //var numberOfCheckedItems = 0;
    //var dID = "";
    document.getElementById("tSelectedCom").value = "";
        for(var i = 0; i < checkboxes.length; i++)  
        {
            
            if (checkboxes[i].checked) {
                //dID = checkboxes[i].id + "l";
         
                if (document.getElementById("tSelectedCom").value == "") {
                    document.getElementById("tSelectedCom").value =  checkboxes[i].title;
                }
                else
                {
                    document.getElementById("tSelectedCom").value = document.getElementById("tSelectedCom").value + "," + "\n" + checkboxes[i].title;
                }
            }
        }  
}  
</script>

 </div>


						        <div class="w3_agileits_main_grid w3l_main_grid">
							        <span class="agileits_grid">
								        <label style="font-size:12px">Other Complaint</label>
                                        <textarea name="Task" id="tSelectedCom" runat="server" rows="8" value="" style="display:none"  ></textarea>
                                        <textarea name="Task" id="tcomplaint" runat="server" style="margin-right:0px" placeholder="Please enter your complaint..." rows="8"  autofocus="autofocus"></textarea>
							        </span>
						        </div>



                                <div class="w3_agileits_main_grid w3l_main_grid" style="display:none">
							        <span class="agileits_grid">
								        <label style="font-size:12px">Attention Level: <span class="star">*</span></label>
                                       <asp:DropDownList ID="ActionLevel"  style="background-color:white;color:black"  runat="server"> 
                                            <asp:ListItem value="Controlled" Selected="True" >Controlled</asp:ListItem>  
                                            <asp:ListItem value="Severe" >Severe</asp:ListItem>
                                            <asp:ListItem value="Critical">Critical</asp:ListItem>
                                       </asp:DropDownList>
							        </span>

						        </div>

						        <div class="w3_agileits_main_grid w3l_main_grid">
							        <span class="agileits_grid">
								        <label style="font-size:12px">Scope of complaint</label>
                   
							        </span>
                                    <div style="line-height:0.5px">
                                              <asp:RadioButtonList id="RadioScopeList" runat="server" >
                                            <asp:ListItem value="In Compound" Selected="True" >My Compound</asp:ListItem>  
                                            <asp:ListItem value="Entire Estate">Entire Estate</asp:ListItem>
                                            </asp:RadioButtonList>
                                    </div>
                                        <input id="dImgPath" style="display:none;"  type="text" runat="server" name="dImgPath" />
						       
                                  </div>


                            
                            <div class="w3_agileits_main_grid w3l_main_grid">
                                 <span class="agileits_grid">
                                      <button type="button" id="start_camera"  runat="server" class="btn btn-info" data-toggle="collapse" >Take a photo</button>
                                    <button type="button" id="btnshowphoto" style="visibility:hidden"  onclick="showpictmodal()" class="btn btn-info"  >View Photo</button>

                                <%-- style="display:none" --%>
                                 </span>

                            </div>

					<div class="w3_main_grid">
                        <table style="width:100%">
                            <tr>
                                <td>
                                        <div class="w3_main_grid_right" style="text-align:left">
			                             <div  style="width:100px;background-color:black;color:white">
                                              <a  href="MainClient.aspx"><span style="color:white;text-align:center">  Go back  </span></a>
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
                                   <span style="text-align:center"> <strong>PLEASE NOTE!!!!</strong> Complaint would only be seen during working hours.</span>
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
                      window.location.href = "MainClient.aspx";
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