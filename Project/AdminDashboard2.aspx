<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard2.aspx.cs" Inherits="Database_Milestone3.AdminDashboard2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard 2</title>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&display=swap');

        body {
            font-family: 'Poppins', sans-serif;
            background: linear-gradient(to bottom right, #87CEFA, #FFB6C1);
            margin: 0;
            padding: 0;
            color: #333;
        }

        .container {
            width: 90%;
            max-width: 850px;
            margin: 40px auto;
            padding: 25px;
            background-color: #fff;
            border-radius: 12px;
            box-shadow: 0px 5px 15px rgba(0, 0, 0, 0.2);
        }

        .header {
            text-align: center;
            margin-bottom: 15px;
        }

        .header h1 {
            font-size: 1.8em;
            color: #444;
            margin: 0;
        }

        .form-group {
            margin: 15px 0;
        }

        .form-group input[type="text"],
        .form-group input[type="date"],
        .form-group select {
            width: 100%;
            padding: 10px;
            font-size: 14px;
            border: 1px solid #ddd;
            border-radius: 6px;
        }

        .btn {
            display: block;
            width: 100%;
            padding: 12px;
            font-size: 14px;
            color: #fff;
            background: linear-gradient(to right, #4a90e2, #ec6ead);
            border: none;
            border-radius: 6px;
            cursor: pointer;
            text-align: center;
            margin-top: 10px;
            transition: background 0.3s ease;
        }

        .btn:hover {
            background: linear-gradient(to right, #3c78c4, #d054a4);
        }

        .result-label {
            font-size: 14px;
            color: #e74c3c;
            margin-top: 8px;
        }

        .separator {
            margin: 15px 0;
            border-top: 1px solid #ccc;
        }

        table {
            border-collapse: collapse;
            margin: 15px 0;
        }

        table th,
        table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        table th {
            background-color: #f9f9f9;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <h1>Admin Dashboard</h1>
            </div>

            <!-- Update Points Section -->
            <div class="form-group">
                <asp:TextBox ID="txtPointsMobileNumber" runat="server" Placeholder="Enter Mobile Number"></asp:TextBox>
            </div>
            <asp:Button runat="server" Text="Update Points" CssClass="btn" OnClick="btnUpdatePoints_Click" />
            <asp:Label ID="lblOldPoints" runat="server" CssClass="result-label"></asp:Label>
            <asp:Label ID="lblNewPoints" runat="server" CssClass="result-label"></asp:Label>

            <div class="separator"></div>


            <!-- Check Wallet Link -->
            <div class="form-group">
                <asp:TextBox ID="txtMobileNumber" runat="server" Placeholder="Enter Mobile Number"></asp:TextBox>
            </div>
            <asp:Button runat="server" Text="Check Wallet Link" CssClass="btn" OnClick="btnCheckWalletLink_Click" />
            <asp:Label ID="lblWalletLinkStatus" runat="server" CssClass="result-label"></asp:Label>

            <div class="separator"></div>

            <!-- Average Transfer Amount -->
            <div class="form-group">
                <asp:TextBox ID="txtWalletIDTransfer" runat="server" Placeholder="Enter Wallet ID"></asp:TextBox>
                <asp:TextBox ID="txtStartDate" runat="server" Placeholder="Enter Start Date"></asp:TextBox>
                <asp:TextBox ID="txtEndDate" runat="server" Placeholder="Enter End Date"></asp:TextBox>
            </div>
            <asp:Button runat="server" Text="View Avg Transfer Amount" CssClass="btn" OnClick="btnViewAvgTransfer_Click" />
            <asp:Label ID="lblAvgTransferAmount" runat="server" CssClass="result-label"></asp:Label>

            <div class="separator"></div>

            <!-- Cashback Amount -->
            <div class="form-group">
                <asp:TextBox ID="txtWalletID" runat="server" Placeholder="Enter Wallet ID"></asp:TextBox>
                <asp:TextBox ID="txtPlanID" runat="server" Placeholder="Enter Plan ID"></asp:TextBox>
            </div>
            <asp:Button runat="server" Text="View Cashback Amount" CssClass="btn" OnClick="btnViewCashbackAmount_Click" />
            <asp:Label ID="lblCashbackAmount" runat="server" CssClass="result-label"></asp:Label>

            <div class="separator"></div>
       
             <!-- Payment Account Section -->
    <div class="form-group">
    <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="input-text" Placeholder="Enter Phone Number" MaxLength="11"></asp:TextBox>
</div>
<asp:Button ID="btnViewPaymentPoints" runat="server" Text="View Accepted Payments and Accepted Points" CssClass="btn" OnClick="btnViewPaymentPoints_Click" />
<asp:Label ID="lblErrorMessage" runat="server" CssClass="result-label" Visible="false"></asp:Label>

<asp:GridView ID="gvPaymentPoints" runat="server" AutoGenerateColumns="True" CssClass="compactGrid" Visible="false" />


      
        <!-- Data Tables -->
         
            <asp:Button runat="server" Text="View Wallet Details" CssClass="btn" OnClick="btnViewWallets_Click" />

<asp:GridView ID="gvWalletDetails" runat="server" AutoGenerateColumns="True" 
    Height="200px" Width="100%" CssClass="compactGrid" PageSize="5">
</asp:GridView>

<style>
    .compactGrid {
        width: 100%;
        table-layout: fixed; /* Fixed column width */
        font-size: 12px; /* Smaller font size */
        border-collapse: collapse;
    }

    .compactGrid td, .compactGrid th {
        padding: 5px;
        text-overflow: ellipsis;
        white-space: nowrap;
        overflow: hidden;
    }

    .compactGrid th {
        background-color: #f2f2f2;
    }
</style>    
     
            <asp:Button runat="server" Text="View E-Shop Vouchers" CssClass="btn" OnClick="btnViewEShopVouchers_Click" />

            <asp:GridView ID="gvEShopVouchers" runat="server" AutoGenerateColumns="True" />
           
        
            <asp:Button runat="server" Text="View Payments" CssClass="btn" OnClick="btnViewPayments_Click" />

            <asp:GridView ID="gvPayments" runat="server" AutoGenerateColumns="True" />

            <asp:Button runat="server" Text="View Cashback" CssClass="btn" OnClick="btnViewCashback_Click" />

            <asp:GridView ID="gvCashback" runat="server" AutoGenerateColumns="True" />

                          <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn" OnClick="btnBack_Click" />

          
            
        </div>
    </form>
</body>
</html>
