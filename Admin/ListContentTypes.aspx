<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListContentTypes.aspx.cs" Inherits="Admin_ListContentTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:DataList ID="DataList1" runat="server" DataKeyField="DynamicContentTypeId" DataSourceID="SqlDataSource1" OnCancelCommand="DataList1_CancelCommand" OnEditCommand="DataList1_EditCommand" OnUpdateCommand="DataList1_UpdateCommand">
        <EditItemTemplate>
            Name:
            <asp:TextBox ID="ct_name" runat="server" Text='<%# Eval("Name") %>' />
            <br />
            Unique Label (css class):
            <asp:Label ID="UniqueLabelLabel" runat="server" Text='<%# Eval("UniqueLabel") %>' />
            <br />
            <asp:Button ID="Button1" CommandName="update" Text="Lagre" runat="server" /> 
            <asp:Button ID="Button2" CommandName="cancel" Text="Avbryt" runat="server" />
        </EditItemTemplate>
        <ItemTemplate>
            Name:
            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            <br />
            Unique Label (css class):
            <asp:Label ID="UniqueLabelLabel" runat="server" Text='<%# Eval("UniqueLabel") %>' />
            <br />
            <asp:Button ID="Button3" CommandName="edit" Text="Rediger navn" runat="server" /> 
            <asp:Button ID="Button4" PostBackUrl='<%# String.Format("~/Admin/ManageContentTypeFields.aspx?dcti={0}", Eval("DynamicContentTypeId")) %>' Text="Administrer felt" runat="server" />
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:gaymerdbConnectionString %>" SelectCommand="SELECT [Name], [UniqueLabel], [DynamicContentTypeId] FROM [DynamicContentType] ORDER BY [Name] DESC"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="DebugOutput" runat="Server">
</asp:Content>

