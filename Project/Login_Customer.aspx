<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Customer.aspx.cs" Inherits="Database_Milestone3.Login_Customer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&display=swap');

        body {
            font-family: 'Poppins', sans-serif;
            background: linear-gradient(135deg, #87CEFA, #FFB6C1);
            margin: 0;
            padding: 0;
            color: #333;
        }

        .container {
            max-width: 400px;
            margin: 150px auto;
            padding: 40px;
            background-color: #fff;
            border-radius: 15px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        }

        .site-name {
            font-size: 36px;
            font-weight: 600;
            color: #4a90e2;
            text-align: center;
            margin-bottom: 20px;
        }

        h2 {
            font-size: 24px;
            color: #444;
            text-align: center;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #333;
        }

        .form-group input[type="text"],
        .form-group input[type="password"] {
            width: 100%;
            padding: 10px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 8px;
        }

        .btn {
            display: inline-block;
            width: 100%;
            padding: 12px;
            font-size: 14px;
            color: #fff;
            background: linear-gradient(90deg, #4a90e2, #ec6ead);
            border: none;
            border-radius: 8px;
            cursor: pointer;
            text-align: center;
            transition: background 0.3s ease;
        }

        .btn:hover {
            background: linear-gradient(90deg, #3c78c4, #d054a4);
        }

        .error-message {
            color: red;
            font-weight: bold;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Login Page</h2>
            <asp:Label ID="Label1" runat="server" Text="Please enter your username and password below:" ForeColor="Black" />
            <br /><br />

            <div class="form-group">
                <asp:Label runat="server" Text="Username:" AssociatedControlID="UserName" />
                <asp:TextBox ID="UserName" runat="server" CssClass="form-control" Placeholder="Enter Username" />
            </div>
            <br />

            <div class="form-group">
                <asp:Label runat="server" Text="Password:" AssociatedControlID="Password" />
                <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter Password" />
            </div>
            <br />

            <div>
                <asp:Button runat="server" Text="Log In" CssClass="btn" OnClick="Login_Click" />
            </div>
            <br />

            <asp:Label ID="ErrorLabel" runat="server" CssClass="error-message" Text=""></asp:Label>
              <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
