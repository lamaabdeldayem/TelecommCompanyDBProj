<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Database_Milestone3.WebForm2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WebForm2</title>
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
            top: 20px;
            right: 20px;
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
        .form-group select,
        .form-group asp:TextBox {
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
    <form id="form1" runat="server">
        <div class="tagline">Making connections easier</div>
        <div class="site-name">Connect</div>
        <div class="container">
            <div class="header">
                <h1>WebForm2</h1>
            </div>
            
            <asp:Button ID="Button6" runat="server" CssClass="btn" Text="View All Benefits" OnClick="enter1" />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView>
            <asp:Label ID="LabelError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            
            <div class="form-group">
                <label>Please enter your National ID to retrieve unresolved tickets:</label>
                <asp:TextBox ID="nationalid" runat="server" CssClass="form-control" Placeholder="Enter National ID"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="enter2" Text="Submit" />
                <asp:Label ID="ticketCountLabel" runat="server" Visible="false" ForeColor="Green"></asp:Label>
                <asp:Label ID="errorLabel" runat="server" Visible="false" ForeColor="Red"></asp:Label>
            </div>

            <div class="separator"></div>

            <div class="form-group">
                <label>Please enter your Mobile Number to return the voucher with the highest value:</label>
                <asp:TextBox ID="mobno" runat="server" CssClass="form-control" MaxLength="11" Placeholder="Enter 11-digit Mobile Number"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="enter3" Text="Submit" />
                <asp:Label ID="Label3" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                <asp:Label ID="voucherIDLabel" runat="server" Visible="false" ForeColor="Green"></asp:Label>
            </div>

            <div class="separator"></div>

            <div class="form-group">
                <label>Please enter your Mobile Number and Plan Name to display the remaining or extra amount:</label>
                <asp:TextBox ID="mobno2" runat="server" CssClass="form-control" MaxLength="11" Placeholder="Enter Mobile Number"></asp:TextBox>
                <asp:TextBox ID="plan" runat="server" CssClass="form-control" Placeholder="Enter Plan Name"></asp:TextBox>
                <asp:Button ID="Button3" runat="server" CssClass="btn" OnClick="enter4" Text="Display Remaining Amount" />
                <asp:Button ID="Button4" runat="server" CssClass="btn" OnClick="enter5" Text="Display Extra Amount" />
                <asp:Label ID="resultLabel" runat="server" Visible="false" ForeColor="Green"></asp:Label>
                <asp:Label ID="errorLabel4" runat="server" Visible="false" ForeColor="Red"></asp:Label>
            </div>

            <div class="separator"></div>

            <div class="form-group">
                <label>Please enter your Mobile Number to display the top 10 successful payments with the highest value:</label>
                <asp:TextBox ID="mobno6" runat="server" CssClass="form-control" MaxLength="11" Placeholder="Enter Mobile Number"></asp:TextBox>
                <asp:Button ID="Button5" runat="server" CssClass="btn" OnClick="enter6" Text="Submit" />
                <asp:GridView ID="paymentGridView" runat="server" Visible="false" AutoGenerateColumns="True"></asp:GridView>
                <asp:Label ID="errorLabel6" runat="server" Visible="false" ForeColor="Red"></asp:Label>
            </div>

            <div class="separator"></div>

            <asp:Button ID="Button8" runat="server" CssClass="btn" Text="View More..." OnClick="MainPage" />
               <br />
            <br />
               <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn" OnClick="btnBack_Click" />

        </div>
    </form>
</body>
</html>
