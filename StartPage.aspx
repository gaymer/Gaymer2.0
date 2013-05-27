<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StartPage.aspx.cs" Inherits="_StartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .SplitHolder
        {
            width:100%; 
            float:left;
        }   

fieldset
{
    border-bottom-width: 0px;
    border-left-width: 0px;
    border-right-width: 0px;
    border-top-width: 0px;
    font-family: "Verdana", "Helvetica", "Arial", sans-serif;
    font-size: 1.1em;
}

    fieldset dl
    {
        padding-bottom: 4px;
        padding-left: 0px;
        padding-right: 0px;
        padding-top: 4px;
    }

    fieldset dt
    {
        display: block;
        float: left;
        text-align: right;
        width: 40%;
    }

    fieldset dd
    {
        margin-bottom: 3px;
        margin-left: 41%;
        vertical-align: top;
    }

    fieldset.fields2 dt
    {
        width: 10em;
        border-right-width: 0;
    }

    fieldset.fields2 dd
    {
        width: 25em;
        border-right-width: 0;
    }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <input type ="Button" id="LogToggelbtn"  value="Logg inn" onclick="Toggel('LoginDiv')" />

    <div class="SplitHolder" id="LoginDiv" style="background:#EFFFDF; visibility:hidden; height: 302px;">
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
            <h1>Login</h1>
                <asp:TextBox ID="LogUsernameBox" runat="server"></asp:TextBox>
                <asp:Label ID="LogUsernameTxt" runat="server" Text="User Name"></asp:Label>
            <br />
                <asp:TextBox ID="LogPasswordBox" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Label ID="LogPasswordTxt" runat="server" Text="Password"></asp:Label>
            <br />
                <asp:Button ID="LogInBtn" runat="server" OnClick="LogInBtn_Click" Text="Log in" />
            <asp:Label ID="ErrorMessage" runat="server" ></asp:Label></ContentTemplate></asp:UpdatePanel>
            <br />
        <p>eller</p>
            <asp:Button ID="Regbtn" runat="server" OnClick="Regbtn_Click" Text="Registrer deg" />
        </div>
</asp:Content>