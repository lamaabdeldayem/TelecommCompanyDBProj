<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Database_Milestone3.AdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
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

        .tagline {
            font-size: 14px;
            font-style: italic;
            color: #555;
            position: absolute;
            top: 61px;
            right: 516px;
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

        .result-label {
            font-size: 14px;
            color: #e74c3c;
            margin-top: 10px;
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
    <form id="form2" runat="server">
        <div class="tagline">Making connections easier</div>
        <div class="site-name">Connect</div>
        <div class="container">
            <div class="header">
                <h1>Admin Dashboard</h1>
            </div>
            <asp:GridView ID="GridViewCustomerProfiles" runat="server" AutoGenerateColumns="True" />
            <div class="form-group">
                <asp:Button runat="server" CssClass="btn" Text="View Details of all Customer Profiles" OnClick="Customer_profiles" />
            </div>
            
            <asp:GridView ID="GridViewPhysical" runat="server" AutoGenerateColumns="True" />
            <div class="form-group">
                <asp:Button runat="server" CssClass="btn" Text="List of All Physical Stores" OnClick="Physical_shops" />
            </div>
            
            <asp:GridView ID="GridViewresolved_tickets" runat="server" AutoGenerateColumns="True" />
            <div class="form-group">
                <asp:Button runat="server" CssClass="btn" Text="View Details for All Resolved Tickets" OnClick="resolved_tickets" />
            </div>
            
            <asp:GridView ID="GridViewAccounts" runat="server" AutoGenerateColumns="True" />
            <div class="form-group">
                <asp:Button runat="server" CssClass="btn" Text="View All Customers’ Accounts" OnClick="Accounts" />
            </div>

            <div class="form-group">
                <asp:TextBox ID="TxtPlanID" runat="server" CssClass="form-control" Placeholder="Enter Plan ID"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="TxtSubDate" runat="server" CssClass="form-control" Placeholder="Enter Subscription Date"></asp:TextBox>
            </div>
            <asp:GridView ID="GridViewGetAcc" runat="server" AutoGenerateColumns="True" />

            <div class="form-group">
                <asp:Button runat="server" CssClass="btn" Text="List all Customer Accounts Subscribed to the Input Plan ID on a Certain Input Date" OnClick="GetAccounts" />
            </div>

            <div class="separator"></div>

            <div class="form-group">
                <asp:TextBox ID="Txtmobile_num" runat="server" CssClass="form-control" Placeholder="Enter Mobile Number"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="TxtStartDate" runat="server" CssClass="form-control" Placeholder="Enter Start Date"></asp:TextBox>
            </div>
            <asp:GridView ID="GridViewUsage" runat="server" AutoGenerateColumns="True" />

            <div class="form-group">
                <asp:Button runat="server" CssClass="btn" Text="Show Total Usage of the Input Account on Each Subscribed Plan From a Given Input Date" OnClick="Usage" />
            </div>

            <div class="form-group">
                <asp:TextBox ID="TxtPlanIDD" runat="server" CssClass="form-control" Placeholder="Enter Plan ID"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="TxtMob_num" runat="server" CssClass="form-control" Placeholder="Enter Mobile Number"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button runat="server" CssClass="btn" Text="Remove All Benefits Offered to the Input Account for a Certain Input Plan ID" OnClick="Remove_benefits" />
            </div>
            
            <asp:Label ID="Result1" runat="server" CssClass="result-label"></asp:Label>

            <div class="separator"></div>

            <div class="form-group">
                <asp:TextBox ID="Mobile_number_in" runat="server" CssClass="form-control" Placeholder="Enter Mobile Number"></asp:TextBox>
            </div>
            <asp:GridView ID="GridViewSMSOffers" runat="server" AutoGenerateColumns="True" />
            <div class="form-group">
                <asp:Button runat="server" CssClass="btn" Text="List All SMS Offers for a Certain Input Account" OnClick="SMS_offered" />
            </div>
            <asp:Label ID="SMS_Res" runat="server" CssClass="result-label"></asp:Label>
            <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn" OnClick="btnNext_Click" />
            <br />
            <br />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn" OnClick="btnBack_Click" />
            <br />
        </div>
    </form>
</body>
</html>
