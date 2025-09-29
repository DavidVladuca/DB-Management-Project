<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MySite.Master" CodeBehind="ListaCategorii.aspx.cs" Inherits="bike.ListaCategorii" %>


<asp:Content ID="Content1" ContentPlaceHolderID="placeHolderMain" runat="server">
    <style>
        .popupBackground {
            opacity: 40%;
            background-color: black;
        }

        .popupPnl {
            background-color: white;
            border-style: solid;
            border-width: 3px;
            border-color: black;
            border-radius: 5px;
            width: 25%;
            padding: 20px;
            padding-left: 60px;
        }
    </style>

        <div>
            LISTA CATEGORII<br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="CAUTA"></asp:Label>
&nbsp;
            <asp:TextBox ID="txtSearch" runat="server" style="margin-left: 14px"></asp:TextBox>
            <br />
        </div>
        <asp:Button ID="bttnRefresh" runat="server" Text="REFRESH" Width="91px" OnClick="bttnRefresh_Click" />
        <asp:GridView ID="gridCategorii" runat="server"  style="margin-left: 13px; margin-top: 24px">
        </asp:GridView>
        <br />

        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Categorie"></asp:Label>
            &nbsp;<asp:TextBox ID="txtCategoryName" runat="server" Height="16px" style="margin-left: 9px" Width="152px"></asp:TextBox>
&nbsp;
            <asp:Button ID="btnAdd" runat="server" style="margin-left: 30px" Text="ADD" Width="49px" OnClick="btnAdd_Click" />
        </asp:Panel>
        <br />
        <br />
</asp:Content>

