<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="Roles" %>

<%--<%@ MasterType VirtualPath="~/MasterPage.Master" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:DropDownList ID="RoleList" runat="server" OnSelectedIndexChanged="RoleList_SelectedIndexChanged" AutoPostBack="True" DataTextField="Role" DataValueField="RoleID">
    </asp:DropDownList>

    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:gaymerdbConnectionString %>" SelectCommand="SELECT [Role], [RoleID] FROM [Role] ORDER BY [Role]"></asp:SqlDataSource>--%>

    <asp:Panel ID="panel" runat="server">

    </asp:Panel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="DebugOutput" runat="Server">
</asp:Content>

