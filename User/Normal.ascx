<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Normal.ascx.cs" Inherits="User_Normal" %>

<asp:Panel ID="MasterPanel" runat="server" BackColor="#EFFFDF" HorizontalAlign ="Center">
    <h2><asp:Label ID="Username" runat="server"></asp:Label>&nbsp;(<asp:Label ID="lblRolle" runat="server"></asp:Label>)</h2>
    <asp:Panel ID="AdminPanel" runat="server" Height="167px" style="margin-top: 0px" Width="568px" Visible="False" HorizontalAlign="Center">
        <br />
        <asp:Button ID="btnAdmin" runat="server" Text="Admin. brukere" Height="30px" Width="125px" />
        <br />
        <br />
</asp:Panel>
 <br />
 <asp:Image ID="MyAvatar" ImageURL="/Style/Images/mario.JPG" runat="server" Height="139px" Width="143px" />
    <asp:Label ID="AboutMeTxt" runat="server" Text="Om Meg tekst"></asp:Label>
    <br />
    <fieldset>
        <legend>Om</legend>
        <dl>
            <dt>Navn</dt>
                <asp:Label ID="UsersNameTxt" runat="server" Text="Name" Font-Size="Large" Font-Bold="true"></asp:Label>
        </dl>
        <dl>
            <dt>Alder</dt>
            <asp:Label ID="UserAgeTxt" runat="server" Text="User Age" Font-Size="Large" Font-Bold="true"></asp:Label>
        </dl>
        <dl>
            <dt>Kjønn</dt>
            
                <asp:Label ID="UserSexTxt" runat="server" Text="User Sex" Font-Size="Large" Font-Bold="true"></asp:Label>
        </dl>
        <dl>
            <dt>Bosted</dt>
            
                <asp:Label ID="UserLivingPlaceTxt" runat="server" Text="User Living Place" Font-Size="Large" Font-Bold="true"></asp:Label>
        </dl>
    </fieldset>

    <asp:Panel ID="FriendPanel" runat="server" HorizontalAlign="Center">
        <asp:GridView ID="FriendView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" Height="73px" Width="184px" HorizontalAlign="Center" >
            <AlternatingRowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:BoundField DataField="Username" HeaderText="Venner" SortExpression="Username" />
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
        <br />
        
    </asp:Panel>

    </asp:Panel>

   