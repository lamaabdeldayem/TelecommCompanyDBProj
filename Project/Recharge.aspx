<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recharge.aspx.cs" Inherits="WebApplication1.Recharge" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recharge Balance</title>
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

        .form-group input[type="text"] {
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
        <div class="site-name">Recharge</div>
        <div class="container">
            <div class="header">
                <h1>Recharge Balance</h1>
            </div>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Insert Mobile Number:"></asp:Label>
                <asp:TextBox ID="MobileNo_TextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Amount to be Recharged:"></asp:Label>
                <asp:TextBox ID="Amount_TextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Payment Method:"></asp:Label>
                <asp:TextBox ID="PaymentMethod_TextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Plan ID:"></asp:Label>
                <asp:TextBox ID="PlanID_TextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="Button" runat="server" CssClass="btn" Text="Recharge Balance" OnClick="RechargeButton" />
            <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>
            <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Back" OnClick="Back" />
        </div>
    </form>
</body>
</html>
