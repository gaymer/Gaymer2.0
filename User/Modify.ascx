<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Modify.ascx.cs" Inherits="User_Modify" %>

<asp:Panel ID="MasterPanel" runat="server" BackColor="#EFFFDF">
    <h2><asp:Label ID="Username" runat="server"></asp:Label></h2>

    <asp:Image ID="MyAvatar" runat="server" Height="155px" Width="162px" />
    <asp:Button CssClass="ButtonBase" ID="RedAvatarbtn" runat="server" Text="Rediger avatar" OnClick="RedAvatarbtn_Click" />
<h3>Om meg</h3>
        <asp:TextBox ID="AboutMeTxt" runat="server" TextMode="MultiLine" Width="300" Height="150"></asp:TextBox>
    <br />
    <fieldset>
        <legend>About</legend>
        <dl>
            <dt>First Name</dt>
            <dd>
                <asp:TextBox ID="UserFirstName" runat="server"></asp:TextBox></dd>
        </dl>
        <dl>
            <dt>Last Name</dt>
            <dd>
                <asp:TextBox ID="UserLastName" runat="server"></asp:TextBox></dd>
        </dl>
        <dl>
            <dt>Age</dt>
            <dd>
                <asp:TextBox ID="UserAgeTxtBox" runat="server" TextMode="Date"></asp:TextBox></dd>
        </dl>
        <dl>
            <dt>Sex</dt>
            <dd>
                <asp:RadioButtonList ID="GenderList" runat="server">
                    <asp:ListItem Value="true">Female</asp:ListItem>
                    <asp:ListItem Value="false">Male</asp:ListItem>
                    <asp:ListItem Value="null">Undefined</asp:ListItem>
                </asp:RadioButtonList>
            </dd>
        </dl>
        <dl>
            <dt>Living Place</dt>
            <dd>
                <asp:TextBox ID="UserLivingPlaceTxtBox" runat="server"></asp:TextBox></dd>
        </dl>
    </fieldset>
    </asp:Panel>