<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Avatar.aspx.cs" Inherits="User_Avatar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID ="MasterPanel" runat="server" HorizontalAlign="Center" BackColor="#EFFFDF">
    
         <asp:Image ID="AvatarImg" runat="server" Height="245px" Width="226px" ImageAlign="Middle" OnDataBinding="avatarbtn_Click" OnLoad="avatarbtn_Click"/>
    <br />
        <br />
        <asp:FileUpload ID="Fileuploade" runat="server" Height="22px" Width="246px" />
        <br />
        <br />
    <asp:Button CssClass="ButtonBase" ID="avatarbtn" runat="server" Text="Lagre Avatar" Height="24px" OnClick="avatarbtn_Click" Width="106px" />
    <br />
        <br />
        <asp:Label ID="errorlbl" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="tilbake" runat="server" Text="Tilbake" OnClick="tilbake_Click" />

    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="DebugOutput" Runat="Server">
</asp:Content>
