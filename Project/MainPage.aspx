<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Page</title>
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
            max-width: 900px;
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
            margin: 10px 0;
            transition: background 0.3s ease;
        }

        .btn:hover {
            background: linear-gradient(90deg, #3c78c4, #d054a4);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="site-name">Main Page</div>
        <div class="container">
            <div class="header">
                <h1>Welcome to the Main Page</h1>
            </div>
            <asp:Button runat="server" CssClass="btn" Text="All Available Shops" OnClick="AllShops" />
            <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Subscribed Plans" OnClick="SubscribedPlans" />
            <asp:Button ID="Button2" runat="server" CssClass="btn" Text="Renew Subscription" OnClick="RenewSub" />
            <asp:Button ID="Button3" runat="server" CssClass="btn" Text="Get CashBack" OnClick="GetCB" />
            <asp:Button ID="Button4" runat="server" CssClass="btn" Text="Recharge Balance" OnClick="RB" />
            <asp:Button ID="Button5" runat="server" CssClass="btn" Text="Redeem Voucher" OnClick="RV" />
                          <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn" OnClick="btnBack_Click" Width="162px" />

        </div>
    </form>
</body>
</html>
