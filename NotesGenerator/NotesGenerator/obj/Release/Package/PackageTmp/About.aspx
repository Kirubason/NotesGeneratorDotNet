<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NotesGenerator.About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%--bootstrap css--%>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    <%--popper js--%>
    <script src="Styles/popper.min.js"></script>
    <%--bootstrap js--%>
    <script src="Styles/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
         <div style="padding-top: 12px;padding-left: 350px;">
            <a class="navbar-brand" href="#" style="color: green;font-weight: bold;font-size: 50px;">
                    <img src="Images/Notes.png" width="100" height="100" />
                   
                    Notes Generator
                </a>
        </div>
        <div>
            <nav class="navbar navbar-expand-lg navbar-light">
                

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                 <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active">
                            <a class="nav-link" href="Index.aspx" style="font-size: 24px;">
                                <img src="Images/Home.jpg" style="width: 22px;height: 22px;"/> Home</a>
                        </li>
                        <li class="nav-item active">
                            <a class="nav-link" href="#" style="font-size: 24px;">
                                <img src="Images/About.png" style="width: 22px;height: 22px;"/> About</a>
                        </li>
                        

                    </ul>

                    <ul class="navbar-nav" style="padding-left: 800px;">
                        <li class="nav-item active">
                            <a class="nav-link" href="Login.aspx" style="font-size: 24px;">
                                <img src="Images/Logout.png" style="width: 22px;height: 22px;"/> Logout</a>
                        </li>
                    </ul>
                </div>


            </nav>
        </div>
        <div>

            <> The notes generation web application have been developed for preparing notes and saving it in the common place</>

            <h5> Here you can create your own notes, delete it and update it whenever required for individual user</h5>

            <h5>The report can be downloaded into excel sheet, if you want to download and print in physical papers</h5>

            


        </div>

        
    </form>
</body>
</html>
