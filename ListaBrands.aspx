<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MySite.Master" CodeBehind="ListaBrands.aspx.cs" Inherits="bike.ListaBrands" %>

<asp:Content ID="Content1" ContentPlaceHolderID="placeHolderMain" runat="server">
        <div>
            LISTA BRAND<br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="CAUTA"></asp:Label>
            <asp:TextBox ID="txtSearch" runat="server" style="margin-left: 22px"></asp:TextBox>
            <br />
        </div>
        <asp:Button ID="bttnRefresh" runat="server" Text="REFRESH" Width="85px" OnClick="bttnRefresh_Click" />
        <asp:GridView ID="gridBrands" runat="server" style="margin-top: 36px" Width="281px">
        </asp:GridView>
        <br />
&nbsp;<br />
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Brand"></asp:Label>
            &nbsp;<asp:TextBox ID="txtBrandName" runat="server" Height="16px" style="margin-left: 9px" Width="152px"></asp:TextBox>
            &nbsp;
            <asp:Button ID="btnAdd" runat="server" style="margin-left: 30px" Text="ADD" Width="49px" OnClick="btnAdd_Click" />
        </asp:Panel>


</asp:Content>

