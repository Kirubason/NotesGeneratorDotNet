<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration form.aspx.cs" Inherits="NotesGenerator.Registration_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }
        form {
            border: 3px solid #f1f1f1;
        }
        input[type=text], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }
        button:hover {
            opacity: 0.8;
        }
        .cnbtn {
            background-color: #ec3f3f;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 49%;
        }
        .lgnbtn {
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 50%;
        }
        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }
        img.avatar {
            width: 40%;
            border-radius: 50%;
        }
        .container {
            padding: 16px;
            height: 387px;
            width: 500px;
        }
        span.psw {
            float: right;
            padding-top: 16px;
        }
        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }
            .cnbtn {
                width: 100%;
            }
        }
        .frmalg {
            margin: auto;
            width: 40%;
        }
        .Rgbtn {
            background-color: blue;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 49%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="width: 40%;margin-left: 400px;">
        
      
        <div class="container" style="height: 500px;">
            <center>
                <h3>Notes Generation Registration form </h3>
            </center>
            <label for="uname"><b>Username</b></label>
            <asp:TextBox runat="server" ID="txt_Username" placeholder="Enter Username"></asp:TextBox>
            <label for="regnumber"><b>Register Number</b></label>
            <asp:TextBox runat="server" ID="txt_Regnumber" placeholder="Enter Reg No"></asp:TextBox>
            <label for="psw"><b>Password</b></label>
            <asp:TextBox runat="server" ID="txt_password" TextMode="Password" placeholder="Enter Password"></asp:TextBox>
            <label for="psw"><b>Confirm Password</b></label>
            <asp:TextBox runat="server" ID="txt_password_confirm" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
            <center>
                <asp:Button runat="server" ID="btn_Register" CssClass="lgnbtn" Text="Register" onclick="btn_Register_Click" />
                <asp:Button runat="server" ID="btn_Login" CssClass="lgnbtn" Text="Login" onclick="btn_Login_Click" />
            </center>
            <br></br><label runat="server" for="error" id="error" style="color:red;"></label>
            
        </div>
         
    </form>
</body>
</html>
