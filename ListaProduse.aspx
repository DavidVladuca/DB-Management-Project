<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MySite.Master" CodeBehind="ListaProduse.aspx.cs" Inherits="bike.ListaProduse" %>

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
            width: 50%;
            padding: 20px;
            padding-left: 60px;
        }

        .title-text {
            font-size: 24px; 
            font-weight: bold;
            
        }
    </style>

    <%-- HEADER --%>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="LISTA PRODUSE" CssClass="title-text"></asp:Label>
    <br />
    <br />
    CAUTARE<asp:TextBox ID="txtSearch" runat="server" Height="17px" style="margin-left: 21px" Width="182px"></asp:TextBox>
    <asp:Button ID="SearchBtn" runat="server" Text="Search" style="margin-left: 31px" Width="94px" OnClick="SearchBtn_Click" />
    <br />
    <br />
    <asp:Button ID="btnRefresh" runat="server" Text="REFRESH" OnClick="btnRefresh_Click" Width="82px" />
    <asp:Button ID="btnAdd" runat="server" Text="ADD" style="margin-left: 23px" OnClientClick="return false; showAddPopup();" />
    <asp:Button ID="btnUndo" runat="server" Text="Undo" style="margin-left: 23px" OnClick="btnUndo_Click" Visible="false" />
    <br />
    <br />

    <%-- GRID DATABASE --%>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="product_id">
        <Columns>
            <asp:BoundField DataField="product_id" HeaderText="Product ID" />
            <asp:TemplateField HeaderText="Product Name">
                <ItemTemplate>
                    <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("product_name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("product_name") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="model_year" HeaderText="Model Year" />
            <asp:BoundField DataField="price" HeaderText="Price" />
            <asp:BoundField DataField="brand_name" HeaderText="Brand Name" />
            <asp:BoundField DataField="category_name" HeaderText="Category Name" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CommandArgument='<%# Container.DataItemIndex %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="btnSave" runat="server" Text="Save" CommandName="Update" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <%-- ERROR MESSAGE --%>
    <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" Visible="false"></asp:Label>
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%-- POPUP PANEL AJAXTOOLKIT--%>
    <asp:Button ID="btnFakeSaveAddProduct" runat="server" Text="FAKE SAVE" OnClick="btnSaveAddProduct_Click" Style="display: none;" />
    <ajaxToolkit:ModalPopupExtender ID="addProductModal" runat="server" TargetControlID="btnAdd" PopupControlID="pnlAddProduct" BackgroundCssClass="popupBackground" DropShadow="true" OkControlID="btnFakeSaveAddProduct" CancelControlID="btnCancelAddProduct" />

    <%-- THE POPUP PANEL --%>
    <asp:Panel ID="pnlAddProduct" runat="server" CssClass="popupPnl" style="display: none;">
        <asp:Label ID="lblAddProduct" runat="server" Text="ADD PRODUCT"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblProductNameAdd" runat="server" Text="Product Name"></asp:Label>
        <asp:TextBox ID="txtProductNameAdd" runat="server" Width="142px" Height="19px"></asp:TextBox>
        <br />
        <asp:Label ID="lblYearAdd" runat="server" Text="Model Year"></asp:Label>
        <asp:TextBox ID="txtModelYearAdd" runat="server" Width="142px" Height="19px"></asp:TextBox>
        <br />
        <asp:Label ID="lblPriceAdd" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="txtPriceAdd" runat="server" Width="142px" Height="19px"></asp:TextBox>
        <br />
        <asp:Label ID="lblBrandAdd" runat="server" Text="Brand Name"></asp:Label>
        <asp:DropDownList ID="ddlBrandAdd" runat="server"></asp:DropDownList>
        <br />
        <asp:Label ID="lblCategoryAdd" runat="server" Text="Category Name"></asp:Label>
        <asp:DropDownList ID="ddlCategoryAdd" runat="server"></asp:DropDownList>
        <br />
        <asp:Button ID="btnSaveAddProduct" runat="server" Text="SAVE" OnClick="btnSaveAddProduct_Click" />
        <asp:Button ID="btnCancelAddProduct" runat="server" Text="CANCEL" OnClientClick="return hideAddPopup();" />
    </asp:Panel>

</asp:Content>
