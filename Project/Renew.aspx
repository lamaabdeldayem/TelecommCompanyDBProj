<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Renew.aspx.cs" Inherits="WebApplication1.Subscribe" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Renew Subscription</title>
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
            max-width: 600px;
            margin: 50px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 15px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        }

        .site-name {
            font-size: 36px;
            font-weight: 600;
            color: #4a90e2;
            text-align: center;
            margin: 20px 0;
        }

        .header {
            text-align: center;
            margin-bottom: 20px;
        }

        .header h1 {
            font-size: 24px;
            color: #444;
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

        .form-control {
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
            margin-top: 10px;
            transition: background 0.3s ease;
        }

        .btn:hover {
            background: linear-gradient(90deg, #3c78c4, #d054a4);
        }

        .message-label {
            margin-top: 15px;
            font-size: 14px;
            color: #444;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="site-name">Renew Subscription</div>
        <div class="container">
            <div class="header">
                <h1>Renew Your Subscription</h1>
            </div>
            <div class="form-group">
                <label for="mobileNo">Mobile Number:</label>
                <asp:TextBox ID="mobileNo_TextBox" runat="server" Placeholder="Enter Mobile Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="amount">Amount:</label>
                <asp:TextBox ID="amount_TextBox" runat="server" Placeholder="Enter Amount" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="planId">Plan ID:</label>
                <asp:TextBox ID="planId_TextBox" runat="server" Placeholder="Enter Plan ID" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="method">Payment Method:</label>
                <asp:TextBox ID="Method_TextBox" runat="server" Placeholder="Enter Payment Method" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Label ID="feedbackLabel" runat="server" CssClass="message-label"></asp:Label>
            <asp:Button ID="Button2" runat="server" CssClass="btn" Text="Renew Subscription" OnClick="RenewSubscription" />
            <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Back" OnClick="Back" />
        </div>
    </form>
</body>
</html>
