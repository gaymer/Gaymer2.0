﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="vennesok.aspx.cs" Inherits="User_vennesok" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="MasterPanel" runat="server" HorizontalAlign ="Center">
        <br />
        <asp:TextBox ID="soktxt" runat="server"></asp:TextBox>
        <asp:Button ID="sokbtn" runat="server" Text="Søk" OnClick="sokbtn_Click"/>
        <br />
        <asp:Label ID="sokerrorlbl" runat="server"></asp:Label>
        <br />
        <br />
    </asp:Panel>
    
    <asp:Panel ID="TablePanel" runat="server" ScrollBars="Auto">
        <asp:GridView ID="sokResult" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#E3EAEB" />
             <Columns>  
               <asp:ImageField DataImageUrlField="UID" DataImageUrlFormatString="~/user/ViewAvatar.ashx?uid={0}" Visible="true">
                   <ControlStyle Height="200px" Width="180px" />
                 </asp:ImageField> 
             </Columns>
            <Columns>
                 <asp:HyperLinkField DataNavigateUrlFields="UID" DataNavigateUrlFormatString="~/User/UserPage.aspx?UserId={0}" DataTextField="Username" HeaderText="Medlemmer" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>

    </asp:Panel> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="DebugOutput" Runat="Server">
</asp:Content>

