<%--
  Created by IntelliJ IDEA.
  User: VictorViena
  Date: 23.05.2019
  Time: 08:54
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <link rel="stylesheet" type="text/css" href="static/error.css">
    <title>Too many players</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
          integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
<div class="container-fluid">
    <div class="row up-label"></div>
    <div class=" row text-white  bg-danger mid-label">
        <p class="text-center">Error there are ${playersSize} connected</p></div>
    <div class="row down-label"></div>

</div>
</body>
</html>
