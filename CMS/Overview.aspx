<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Overview.aspx.cs" Inherits="CMS_Overview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Oversikt fra databasen</h1>
    <form id="form1" runat="server">
    <div>
        <h3>Velg hva du vil se utskrift av:</h3>
        <asp:HyperLink runat="server" ID="lnkPermissionView" NavigateUrl="Overview.aspx?view=permission">Permission</asp:HyperLink> | 
        <asp:HyperLink runat="server" ID="lnkRoleView" NavigateUrl="Overview.aspx?view=role">Role</asp:HyperLink> | 
        <asp:HyperLink runat="server" ID="lnkUserView" NavigateUrl="Overview.aspx?view=user">User</asp:HyperLink> | 
        <asp:HyperLink runat="server" ID="lnkContentTypeView" NavigateUrl="Overview.aspx?view=contenttype">ContentType</asp:HyperLink> | 
        <asp:HyperLink runat="server" ID="lnkInputElementView" NavigateUrl="Overview.aspx?view=inputelement">InputElement</asp:HyperLink> |
        <asp:HyperLink runat="server" ID="lnkInputDataView" NavigateUrl="Overview.aspx?view=inputs">InputData (SimpleText)</asp:HyperLink>
        <hr />
        <asp:Label ID="lblNumberOfRows" runat="server"></asp:Label> <br /><br />
        <asp:GridView ID="gvOverview" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
