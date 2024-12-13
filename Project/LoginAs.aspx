<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAs.aspx.cs" Inherits="Database_Milestone3.LoginAs" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login As</title>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&display=swap');

        body {
            font-family: 'Poppins', sans-serif;
            background: linear-gradient(to bottom right, #87CEFA, #FFB6C1);
            margin: 0;
            padding: 0;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

        .login-container {
            background-color: #ffffff;
            padding: 30px;
            border-radius: 12px;
            box-shadow: 0px 4px 12px rgba(0, 0, 0, 0.2);
            max-width: 400px;
            width: 100%;
            text-align: center;
        }

        .login-container h2 {
            margin-bottom: 20px;
            font-size: 1.8em;
            color: #333;
        }

        .btn {
            display: inline-block;
            width: 100%;
            padding: 12px;
            font-size: 1em;
            color: #fff;
            background: linear-gradient(to right, #4a90e2, #ec6ead);
            border: none;
            border-radius: 6px;
            cursor: pointer;
            margin-top: 10px;
            transition: background 0.3s ease;
        }

        .btn:hover {
            background: linear-gradient(to right, #3c78c4, #d054a4);
        }

        .info-label {
            color: #666;
            font-size: 1em;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Select Login Type</h2>
            <asp:Label runat="server" CssClass="info-label" Text="Please choose how you want to log in:"></asp:Label>
            <div>
                <asp:Button runat="server" Text="Customer" CssClass="btn" OnClick="Login_Customer" />
            </div>
            <div>
                <asp:Button runat="server" Text="Admin" CssClass="btn" OnClick="Login_Admin" />
            </div>
        </div>
    </form>
</body>
</html>
