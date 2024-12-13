<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shops.aspx.cs" Inherits="WebApplication1.Shops" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>All Shops</title>
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
            max-width: 700px;
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

        asp:GridView {
            width: 100%;
            margin-bottom: 20px;
            border-collapse: collapse;
            text-align: left;
        }

        asp:GridView th,
        asp:GridView td {
            padding: 10px;
            border: 1px solid #ddd;
        }

        asp:GridView th {
            background-color: #f7f7f7;
            font-weight: bold;
        }

        asp:GridView td {
            background-color: #fff;
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

        .form-group {
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="site-name">Available Shops</div>
        <div class="container">
            <div class="header">
                <h1>View All Shops</h1>
            </div>
            <asp:GridView ID="GridViewAllShops" runat="server" AutoGenerateColumns="True" />
            <div class="form-group">
                <asp:Button ID="Button1" runat="server" Text="View Shops" CssClass="btn" OnClick="View" />
            </div>
            <div class="form-group">
                <asp:Button ID="Button2" runat="server" Text="Back" CssClass="btn" OnClick="Back" />
            </div>
        </div>
    </form>
</body>
</html>
