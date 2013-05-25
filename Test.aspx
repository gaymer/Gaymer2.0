<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="SubmitBtn" />
        </Triggers>
        <ContentTemplate>
            <div>
                <asp:TextBox CssClass="WallInput" ID="Input" TextMode="MultiLine" runat="server"></asp:TextBox>
                <br />
                <a class="ButtonBase" >knappen under skal bli som denne</a><br />
                <asp:Button ID="SubmitBtn" runat="server" CssClass="ButtonBase" Text="Save Comment" OnClick="SubmitBtn_Click" />
            </div>
            <div>
                <asp:ListView ID="Wall" runat="server">
                    <EmptyDataTemplate>
                        ingen comment
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <div class="WallElement">
                            <div style="padding: 5px; border-bottom: solid 1px black;">
                                <%#Eval("Username") %>
                                <br />
                                <%#Eval("CreatedTime") %>
                            </div>
                            <p style="padding: 5px; margin: 0;">
                                <%#Eval("Comment") %>
                            </p>
                        </div>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <div class="WallElement WallAlternating">
                            <div style="padding: 5px; border-bottom: solid 1px black;">
                                <%#Eval("Username") %>
                                <br />
                                <%#Eval("CreatedTime") %>
                            </div>
                            <p style="padding: 5px; margin: 0;">
                                <%#Eval("Comment") %>
                            </p>
                        </div>
                    </AlternatingItemTemplate>
                </asp:ListView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="DebugOutput" runat="Server">
</asp:Content>

