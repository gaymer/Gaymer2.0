<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StartPage.aspx.cs" Inherits="_StartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="Button" id="LogToggelbtn" class="ButtonBase" value="Logg inn" onclick="Toggel('LoginDiv');" />
    <div>
        <asp:Menu ID="Menu" runat="server" CssClass="menu"
            EnableViewState="false" IncludeStyleBlock="false"
            Orientation="Horizontal">
            <Items>
                <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Fremside" />
                <asp:MenuItem Text="Rediger" Selectable="False" Value="Admin">
                    <asp:MenuItem NavigateUrl="~/Online/Laerer/ListStudenter.aspx" Text="Studenter"
                        Value="Studenter"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Online/Laerer/FagListe.aspx" Text="Fag"
                        Value="Fag"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Online/Laerer/OppgaveListe.aspx" Text="Oppgaver"
                        Value="Fag"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
        </asp:Menu>

    </div>
    <div class="SplitHolder" id="LoginDiv" style="background: #EFFFDF; visibility: hidden; height: 302px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h1>Login</h1>
                <asp:TextBox ID="LogUsernameBox" runat="server"></asp:TextBox>
                <asp:Label ID="LogUsernameTxt" runat="server" Text="User Name"></asp:Label>
                <br />
                <asp:TextBox ID="LogPasswordBox" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Label ID="LogPasswordTxt" runat="server" Text="Password"></asp:Label>
                <br />
                <asp:Button CssClass="ButtonBase" ID="LogInBtn" runat="server" OnClick="LogInBtn_Click" Text="Log in" />
                <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <p>eller</p>
        <asp:Button CssClass="ButtonBase" ID="Regbtn" runat="server" OnClick="Regbtn_Click" Text="Registrer deg" />
    </div>
</asp:Content>
