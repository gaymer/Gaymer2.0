<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="User_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="SplitHolder">
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
               <asp:Button CssClass="ButtonBase" ID="RegisterBtn" runat="server" OnClick="RegisterBtn_Click" Text="Register" /></dt>
           <dd>
               <asp:Label ID="RegError" runat="server"></asp:Label>
           </dd>
       </dl>
            </fieldset>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="DebugOutput" Runat="Server">
</asp:Content>

