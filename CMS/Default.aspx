﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="CMS_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="DebugOutput" Runat="Server">
    <asp:Panel ID="GenericContentPanel" runat="server"></asp:Panel>
    <asp:Button Text="Lagre" runat="server" ID="SaveContentButton" OnClick="SaveContent_Click" Visible="False"/>
</asp:Content>

