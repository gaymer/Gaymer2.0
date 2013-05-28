<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="Roles" %>
<%--<%@ MasterType VirtualPath="~/MasterPage.Master" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="Role" HeaderText="Role" SortExpression="Role" />
        <asp:BoundField DataField="Label" HeaderText="Label" SortExpression="Label" />
        <asp:BoundField DataField="PermissionUniqueString" HeaderText="PermissionUniqueString" SortExpression="PermissionUniqueString" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:gaymerdbConnectionString %>" SelectCommand="SELECT Role.Role, Permission.Label, Permission.PermissionUniqueString FROM Permission INNER JOIN PermissionToRole ON Permission.PermissionId = PermissionToRole.PermissionId INNER JOIN Role ON PermissionToRole.RoleId = Role.RoleID ORDER BY Permission.Label"></asp:SqlDataSource>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="DebugOutput" Runat="Server">
</asp:Content>

