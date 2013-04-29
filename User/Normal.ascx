<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Normal.ascx.cs" Inherits="User_Normal" %>


    <h2><asp:Label ID="Username" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblRolle" runat="server"></asp:Label>
</h2>
    <asp:Image ID="MyAvatar" runat="server" Height="139px" Width="143px" />
    <h3>Om meg</h3>
    <asp:Label ID="AboutMeTxt" runat="server" Text="Om Meg tekst"></asp:Label>
    <br />
    <fieldset>
        <legend>About</legend>
        <dl>
            <dt>Navn</dt>
            <dd>
                <asp:Label ID="UsersNameTxt" runat="server" Text="Name"></asp:Label></dd>
        </dl>
        <dl>
            <dt>Alder</dt>
            <dd>
                <asp:Label ID="UserAgeTxt" runat="server" Text="User Age"></asp:Label></dd>
        </dl>
        <dl>
            <dt>Kjønn</dt>
            <dd>
                <asp:Label ID="UserSexTxt" runat="server" Text="User Sex"></asp:Label></dd>
        </dl>
        <dl>
            <dt>Bosted</dt>
            <dd>
                <asp:Label ID="UserLivingPlaceTxt" runat="server" Text="User Living Place"></asp:Label></dd>
        </dl>
    </fieldset>