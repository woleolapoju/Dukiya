﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Usefull2.aspx.cs" Inherits="Usefull2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <style>
        @import url(https://fonts.googleapis.com/css?family=Roboto:500,700);

*, *::before, *::after {
  box-sizing: border-box;
}

html {
  min-height: 100%;
}

body {
  margin: 20px;
  color: #435757;
  background: linear-gradient(-20deg, #d0b782 20%, #a0cecf 80%);
  font: 500 1.2em/1.2 'Roboto', sans-serif;
}

.container {
  max-width: 450px;
  margin: 0 auto;
  border-top: 5px solid #435757;
  background-color: rgba(255, 255, 255, .2);
  box-shadow: 0 0 20px rgba(0, 0, 0, .1);
  user-select: none;
}

h1 {
  margin: 0;
  padding: 20px;
  background-color: rgba(255, 255, 255, .4);
  font-size: 1.8em;
  text-align: center;
}

.items {
  display: flex;
  flex-direction: column;
  padding: 20px;
  counter-reset: done-items undone-items;
}

h2 {
  position: relative;
  margin: 0;
  padding: 10px 0;
  font-size: 1.2em;
}

h2::before {
  content: '';
  display: block;
  position: absolute;
  top: 10px;
  bottom: 10px;
  left: -20px;
  width: 5px;
  background-color: #435757;
}

h2::after {
  display: block;
  float: right;
  font-weight: normal;
}

.done {
  order: 1;
}

.done::after {
  content: ' (' counter(done-items) ')';
}

.undone {
  order: 3;
}

.undone::after {
  content: ' (' counter(undone-items) ')';
}

/* hide inputs offscreen, but at the same vertical positions as the correpsonding labels, so that tabbing scrolls the viewport as expected */
input {
  display: block;
  height: 53px;
  margin: 0 0 -53px -9999px;
  order: 4;
  outline: none;
  counter-increment: undone-items;
}

input:checked {
  order: 2;
  counter-increment: done-items;  
}

label {
  display: block;
  position: relative;
  padding: 15px 0 15px 45px;
  border-top: 1px dashed #fff;
  order: 4;
  cursor: pointer;
  animation: undone .5s;
}

label::before {
  content: '\f10c'; /* circle outline */
  display: block;
  position: absolute;
  top: 11px;
  left: 10px;
  font: 1.5em 'FontAwesome';
}

label:hover, input:focus + label {
  background-color: rgba(255, 255, 255, .2);
}

input:checked + label {
  order: 2;
  animation: done .5s;
}

input:checked + label::before {
  content: '\f058'; /* circle checkmark */
}

@keyframes done {
  0% {
    opacity: 0;
    background-color: rgba(255, 255, 255, .4);
    transform: translateY(20px);
  }
  50% {
    opacity: 1;
    background-color: rgba(255, 255, 255, .4);
  }
}

@keyframes undone {
  0% {
    opacity: 0;
    background-color: rgba(255, 255, 255, .4);
    transform: translateY(-20px);
  }
  50% {
    opacity: 1;
    background-color: rgba(255, 255, 255, .4);
  }
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
  <h1>Will's Summer To-Do List</h1>
  <div class="items">
    <input id="item1" type="checkbox" checked>
    <label for="item1">Create a to-do list</label>

    <input id="item2" type="checkbox">
    <label for="item2">Take down Christmas tree</label>

    <input id="item3" type="checkbox">
    <label for="item3">Learn Ember.js</label>

    <input id="item4" type="checkbox">
    <label for="item4">Binge watch every episode of MacGyver</label>

    <input id="item5" type="checkbox">
    <label for="item5">Alphabetize everything in the fridge</label>

    <input id="item6" type="checkbox">
    <label for="item6">Do 10 pull-ups without dropping</label>

    <h2 class="done" aria-hidden="true">Done</h2>
    <h2 class="undone" aria-hidden="true">Not Done</h2>
  </div>
</div>
    </form>
</body>
</html>
