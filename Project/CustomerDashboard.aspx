<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDashboard.aspx.cs" Inherits="Database_Milestone3.CustomerDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Dashboard</title>
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
        .form-group input[type="date"],
        .form-group select {
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

        .separator {
            margin: 20px 0;
            border-top: 1px solid #ddd;
        }

        asp:GridView {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }

        asp:GridView th,
        asp:GridView td {
            border: 1px solid #ddd;
            padding: 10px;
        }

        asp:GridView th {
            background-color: #f7f7f7;
            font-weight: bold;
        }

        asp:GridView td {
            text-align: left;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="site-name">Customer Dashboard</div>
        <div class="container">
            <div class="form-group">
                <asp:Button ID="Button1" runat="server" CssClass="btn" Text="View details of all service plans" OnClick="Service_Plans" />
                <asp:GridView ID="GridViewServicePlans" runat="server" AutoGenerateColumns="True" />
            </div>

            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="View total SMS, Minutes and Internet consumption"></asp:Label>
                
                <asp:TextBox ID="PlanName" runat="server" CssClass="form-control" Placeholder="Enter Plan Name"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Start date:"></asp:Label>
                <asp:TextBox ID="StarDate" runat="server" CssClass="form-control" Placeholder="yyyy-MM-dd"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="End date:"></asp:Label>
                <asp:TextBox ID="EndDate" runat="server" CssClass="form-control" Placeholder="yyyy-MM-dd"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button ID="Consumption" runat="server" CssClass="btn" Text="View Consumption" OnClick="ConsumptionOfPlan" />
                <asp:GridView ID="GridViewConsumption" runat="server" AutoGenerateColumns="True" />
            </div>

            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Please enter your mobile number:"></asp:Label>
                <asp:TextBox ID="MobileNum1" runat="server" CssClass="form-control" Placeholder="Enter Mobile Number"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button ID="Button2" runat="server" CssClass="btn" Text="View offered plans not subscribed to" OnClick="Plans_Not_SubTo" />
                <asp:GridView ID="GridViewNotSubscribedTo" runat="server" AutoGenerateColumns="True" />
            </div>

            <div class="form-group">
                <asp:Button ID="Button3" runat="server" CssClass="btn" Text="Show the usage of your account active plans during the current month" OnClick="Usage_Plan_CurrentMonth" />
                <asp:GridView ID="GridViewUsage_Plan_CurrentMonth" runat="server" AutoGenerateColumns="True" />
            </div>

            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Please enter your national ID"></asp:Label>
                <asp:TextBox ID="NationalID" runat="server" CssClass="form-control" Placeholder="Enter National ID"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button ID="Button4" runat="server" CssClass="btn" Text="Wallet's Cashback" OnClick="Cashback_Wallet_Customer" />
                <asp:GridView ID="GridViewCashback_Wallet_Customer" runat="server" AutoGenerateColumns="True" />
            </div class="form-group" >
            <asp:Button ID="Button5" runat="server"  CssClass="btn" Text="View more..." OnClick="Customer2" /> 
                          <br />
            <br />
                          <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn" OnClick="btnBack_Click" />

        </div >
    </form>
</body>
</html>

