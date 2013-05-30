<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<%@ Register Src="~/Vegg/Vegg.ascx" TagPrefix="uc1" TagName="Vegg" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="overflow:hidden;">
    <div style="width:500px; float:left;"><uc1:Vegg runat="server" ID="Vegg" />
        </div>
    <div style="width:500px; float:left;">
        <uc1:Vegg runat="server" ID="Vegg1" />
    </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="DebugOutput" runat="Server">
</asp:Content>

