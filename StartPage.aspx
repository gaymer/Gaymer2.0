<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StartPage.aspx.cs" Inherits="_StartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <input type ="Button" id="LogToggelbtn" class="ButtonBase" value="Logg inn" onclick="Toggel('LoginDiv');" />

    <div class="SplitHolder" id="LoginDiv" style="background:#EFFFDF; visibility:hidden; height: 302px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
            <h1>Login</h1>
                <asp:TextBox ID="LogUsernameBox" runat="server"></asp:TextBox>
                <asp:Label ID="LogUsernameTxt" runat="server" Text="User Name"></asp:Label>
            <br />
                <asp:TextBox ID="LogPasswordBox" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Label ID="LogPasswordTxt" runat="server" Text="Password"></asp:Label>
            <br />
                <asp:Button CssClass="ButtonBase" ID="LogInBtn" runat="server" OnClick="LogInBtn_Click" Text="Log in" />
            <asp:Label ID="ErrorMessage" runat="server" ></asp:Label></ContentTemplate></asp:UpdatePanel>
            <br />
        <p>eller</p>
            <asp:Button CssClass="ButtonBase" ID="Regbtn" runat="server" OnClick="Regbtn_Click" Text="Registrer deg" />
        </div>
</asp:Content>