<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Usefull1.aspx.cs" Inherits="sample2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <style>
        @import url(https://fonts.googleapis.com/css?family=Noto+Sans:400,700);

*, *::before, *::after {
  box-sizing: border-box;
}

html {
  min-height: 100%;
}

body {
  margin: 40px;
  font: 1.2em/1.2 'Noto Sans', sans-serif;
  background: linear-gradient(90deg, #b9c3c9, #6b7c87);
}

form {
    position: relative;
    width: 300px;
    margin: 0 auto;
    padding: 20px;
    border-top: 30px solid #5c5d5e;
    border-radius: 10px;
  background-color: #e8ebed;
    box-shadow: 0 0 80px rgba(0, 0, 0, .2);
}

form::before {
    content: '';
    position: absolute;
    top: -20px;
    left: 15px;
    width: 10px;
    height: 10px;
    border-radius: 50%;
  background-color: #adadae;
    box-shadow:
    20px 0 0 #adadae,
    40px 0 0 #adadae;
}

h1 {
  margin: 0;
  padding-bottom: 20px;
  border-bottom: 1px solid #adadae;
  color: #5c5d5e;
  font-size: 1.1em;
}

.tree {
  padding: 20px 0;
}

.tree::after {
  content: '';
  display: block;
  clear: left;
}

.tree div {
  clear: left;
}

input[type="checkbox"] {
  position: absolute;
  left: -9999px;
}

label, a {
  display: block;
  float: left;
  clear: left;
  position: relative;
  margin-left: 25px;
  padding: 5px;
  border-radius: 5px;
  color: #5c5d5e;
  text-decoration: none;
  cursor: pointer;
}

label::before, a::before {
  display: block;
  position: absolute;
  top: 6px;
  left: -25px;
  font-family: 'FontAwesome';
}

label::before {
  content: '\f07b'; /* closed folder */
}

input:checked + label::before {
  content: '\f07c'; /* open folder */
}

a::before {
  content: '\f068'; /* dash */
}

input:focus + label, a:focus {
  outline: none;
  background-color: #b9c3c9;
}

.sub {
  display: none;
  float: left;
  margin-left: 30px;
}

input:checked ~ .sub {
  display: block;
}

input[type="reset"] {
  display: block;
  width: 100%;
  padding: 10px;
  border: none;
  border-radius: 10px;
  color: #e8ebed;
  background-color: #6b7c87;
  font-family: inherit;
  font-size: .9em;
  cursor: pointer;
  -webkit-appearance: none;
  -moz-appearance: none;
}

input[type="reset"]:focus {
  outline: none;
  box-shadow: 0 0 0 4px #b9c3c9;
}
    </style>
</head>
<body>
   <form>
  <h1>C:\Users\Will\Magic</h1>
  <div class="tree">
    <div>
      <input id="n-0" type="checkbox">
      <label for="n-0">Black</label>
      <div class="sub">
        <a href="#link">Plague Rats</span>
        <a href="#link">Sengir Vampire</a>
      </div>
    </div>
    <div>
      <input id="n-1" type="checkbox">
      <label for="n-1">Blue</label>
      <div class="sub">
        <a href="#link">Mana Leak</a>
        <a href="#link">Time Warp</a>
      </div>
    </div>
    <div>
      <input id="n-2" type="checkbox">
      <label for="n-2">Green</label>
      <div class="sub">
        <a href="#link">Giant Growth</a>
        <a href="#link">Liege of the Tangle</a>
      </div>
    </div>
    <div>
      <input id="n-3" type="checkbox">
      <label for="n-3">Red</label>
      <div class="sub">
        <a href="#link">Mogg Fanatic</a>
        <a href="#link">Worldfire</a>
      </div>
    </div>
    <div>
      <input id="n-4" type="checkbox">
      <label for="n-4">White</label>
      <div class="sub">
        <a href="#link">Healing Salve</a>
        <a href="#link">Serra Angel</a>
      </div>
    </div>
    <div>
      <input id="n-5" type="checkbox">
      <label for="n-5">Multicolor</label>
      <div class="sub">
        <div>
          <input id="n-5-0" type="checkbox">
          <label for="n-5-0">Blue + Green</label>
          <div class="sub">
            <a href="#link">Simic Aurora</a>
            <a href="#link">Wistful Selkie</a>
          </div>
        </div>
        <div>
          <input id="n-5-1" type="checkbox">
          <label for="n-5-1">Red + White</label>
          <div class="sub">
            <a href="#link">Boros Swiftblade</a>
            <a href="#link">Lightning Helix</a>
          </div>
        </div>
      </div>
    </div>
  </div>
  <input type="reset" value="Collapse All">
</form>
</body>
</html>
