<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StartPage.aspx.cs" Inherits="_StartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .SplitHolder
        {
            width:50%; 
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
        <div class="SplitHolder" style="background:#94deff;">
            <h1>Login</h1>
                <asp:TextBox ID="LogUsernameBox" runat="server"></asp:TextBox>
                <asp:Label ID="LogUsernameTxt" runat="server" Text="User Name"></asp:Label>
            <br />
                <asp:TextBox ID="LogPasswordBox" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Label ID="LogPasswordTxt" runat="server" Text="Password"></asp:Label>
            <br />
                <asp:Button ID="LogInBtn" runat="server" OnClick="LogInBtn_Click" Text="Log in" />
        </div>
        <div class="SplitHolder" style="background:#94ff6a;">
            <h1>Registrering</h1>
            
   <fieldset>
     <legend>Personalia:</legend>
        <dl>
            <dt>
                <asp:TextBox ID="RegUsernameBox" runat="server"></asp:TextBox>
            </dt>
            <dd>
                <asp:Label ID="RegUsernameTxt" runat="server" Text="User name"></asp:Label>
            </dd>
        </dl>            
        <dl>
            <dt>
                <asp:TextBox ID="RegEmailBox" runat="server"></asp:TextBox>
            </dt>
            <dd>
                <asp:Label ID="RegEmailTxt" runat="server" Text="E-mail"></asp:Label>
            </dd>
        </dl>            
        <dl>
            <dt>
                <asp:TextBox ID="RegREmailBox" runat="server"></asp:TextBox>
            </dt>
            <dd>
                <asp:Label ID="RegREmailTxt" runat="server" Text="Repeat E-mail"></asp:Label>
            </dd>
        </dl>           
        <dl>
            <dt>
               <asp:TextBox ID="RegPasswordBox" runat="server" TextMode="Password"></asp:TextBox>
            </dt>
            <dd>
               <asp:Label ID="RegPasswordTxt" runat="server" Text="Password"></asp:Label>
            </dd>
        </dl>           
        <dl>
            <dt>
               <asp:TextBox ID="RegRPasswordBox" runat="server" TextMode="Password"></asp:TextBox>
            </dt>
            <dd>
               <asp:Label ID="RegRPasswordTxt" runat="server" Text="Repeat Password"></asp:Label>
            </dd>
        </dl>
       <dl>
           <dt>
               <asp:Button ID="RegisterBtn" runat="server" OnClick="RegisterBtn_Click" Text="Register" /></dt>
           <dd>
               <asp:Label ID="RegError" runat="server"></asp:Label>
           </dd>
       </dl>
            </fieldset>
        </div>
</asp:Content>