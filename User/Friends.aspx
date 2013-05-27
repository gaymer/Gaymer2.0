<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Friends.aspx.cs" Inherits="User_Friends" %>
<%@ Register Src="~/User/Normal.ascx" TagPrefix="uc1" TagName="Normal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:Panel ID="MasterPanel" runat="server" BackColor="#EFFFDF" HorizontalAlign ="Center">
      <uc1:Normal runat="server" ID="Normal" />


  </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="DebugOutput" Runat="Server">
</asp:Content>

