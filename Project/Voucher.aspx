<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Voucher.aspx.cs" Inherits="WebApplication1.Voucher" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Voucher Redemption</title>
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
            max-width: 500px;
            margin: 50px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 15px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        }

        .header {
            text-align: center;
            margin-bottom: 20px;
        }

        .header h1 {
            font-size: 24px;
            color: #4a90e2;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-label {
            display: block;
            font-size: 14px;
            color: #444;
            margin-bottom: 5px;
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
            font-size: 14px;
            color: #e74c3c;
            margin-top: 10px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <h1>Voucher Redemption</h1>
            </div>
            <div class="form-group">
                <label for="MobileNo_TextBox" class="form-label">Insert Mobile Number:</label>
                <asp:TextBox ID="MobileNo_TextBox" runat="server" CssClass="form-control" Placeholder="Enter Mobile Number"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="VoucherID_TextBox" class="form-label">Insert Voucher ID:</label>
                <asp:TextBox ID="VoucherID_TextBox" runat="server" CssClass="form-control" Placeholder="Enter Voucher ID"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="Button1" runat="server" Text="Redeem Voucher" CssClass="btn" OnClick="Redeem" />
            </div>
            <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>
            <div class="form-group">
                <asp:Button ID="Button2" runat="server" Text="Back" CssClass="btn" OnClick="Back" />
            </div>
        </div>
    </form>
</body>
</html>
