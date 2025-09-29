<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="bike.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bike Shop</title>
    <style>
        body {
            background: url('Img/background3.jpg');
            background-size: cover;
            background-repeat: no-repeat;
            font-family: Arial, sans-serif;
        }

        .container {
            width: 900px;
            margin: 0 auto;
            text-align: center;
            padding: 50px 0;
        }

        .btn-group {
            margin-top: 20px;
        }

        .btn {
            background-color: #FF9900;
            color: black;
            padding: 10px 20px;
            font-size: 16px;
            cursor: pointer;
            margin: 0 10px;
            box-shadow: 5px 5px 5px black;
        }

        .btn:hover {
            background-color: #FFC266;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 CssClass="titlu">Welcome to our Bike Shop</h1>
            <div class="btn-group">
                <asp:Button ID="BttnRedirect1" runat="server" OnCommand="BttnRedirect1_Command" Text="Lista Produse" CssClass="btn" />
                <asp:Button ID="BttnRedirect2" runat="server" OnClick="BttnRedirect2_Click" Text="Lista Categorii" CssClass="btn" />
                <asp:Button ID="BttnRedirect3" runat="server" OnClick="BttnRedirect3_Click" Text="Lista Brand" CssClass="btn" />
            </div>
        </div>
    </form>
</body>
</html>
