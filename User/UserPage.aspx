<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserPage.aspx.cs" Inherits="Brukerside" %>
<%@ Register Src="~/User/Modify.ascx" TagPrefix="uc1" TagName="Modify" %>
<%@ Register Src="~/User/Normal.ascx" TagPrefix="uc1" TagName="Normal" %>
<%@ Register Src="~/Vegg/Vegg.ascx" TagPrefix="uc1" TagName="Vegg" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button CssClass="ButtonBase" ID="ModifySelf" runat="server" Text="Modify" OnClick="ModifySelf_Click" />
            <asp:Label ID="MessageLbl" runat="server" Text="" />
            <div style="overflow:hidden; width:1010px; margin:0 auto;">
                <div style="float:left; width:480px; margin-right:20px;">
            <uc1:Modify Visible="false" runat="server" ID="Modify" />
            <uc1:Normal runat="server" ID="Normal" />
                    </div>
                <div style="float:left; width:500px;">
                    <uc1:Vegg runat="server" ID="Vegg" />
                </div>
       </div>
             </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

