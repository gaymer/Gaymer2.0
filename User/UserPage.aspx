<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserPage.aspx.cs" Inherits="Brukerside" %>
<%@ Register Src="~/User/Modify.ascx" TagPrefix="uc1" TagName="Modify" %>
<%@ Register Src="~/User/Normal.ascx" TagPrefix="uc1" TagName="Normal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="ModifySelf" runat="server" Text="Modify" OnClick="ModifySelf_Click" />
            <uc1:Modify Visible="false" runat="server" ID="Modify" />
            <uc1:Normal runat="server" ID="Normal" />
       
             </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

