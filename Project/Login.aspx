<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Database_Milestone3.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
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

        .form-group {
            margin-bottom: 20px;
            text-align: left;
        }

        .form-group label {
            display: block;
            font-size: 0.9em;
            color: #555;
            margin-bottom: 5px;
        }

        .form-group input {
            width: 100%;
            padding: 10px;
            font-size: 1em;
            border: 1px solid #ddd;
            border-radius: 6px;
        }

        .form-group input:focus {
            outline: none;
            border-color: #007bff;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
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

        .error-label {
            color: #e74c3c;
            font-size: 0.9em;
            margin-top: 10px;
        }

        .info-label {
            color: #666;
            font-size: 0.9em;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Welcome Back</h2>
            <asp:Label ID="Label" runat="server" CssClass="info-label" Text="Please enter your username and password below."></asp:Label>

            <!-- Username -->
            <div class="form-group">
                <label for="UserName">Username:</label>
                <asp:TextBox ID="UserNamee" runat="server" Width="100%" Placeholder="Enter your username"></asp:TextBox>
            </div>

            <!-- Password -->
            <div class="form-group">
                <label for="Password">Password:</label>
                <asp:TextBox ID="Passwordd" runat="server" Width="100%" TextMode="Password" Placeholder="Enter your password"></asp:TextBox>
            </div>

            <!-- Login Button -->
            <asp:Button ID="LoginButton" runat="server" Text="Log In" CssClass="btn" OnClick="Login_Click" />

            <!-- Error Message -->
            <br />
            <asp:Label ID="Label11" runat="server" CssClass="error-label"></asp:Label>
             <br />
             <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn" OnClick="btnBack_Click" Width="162px" />

        </div>
    </form>
</body>
</html>
