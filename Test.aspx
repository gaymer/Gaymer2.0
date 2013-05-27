<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <asp:TextBox CssClass="WallInput" ID="Input" TextMode="MultiLine" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="SubmitBtn" runat="server" CssClass="ButtonBase" Text="Save Comment" OnClick="SubmitBtn_Click" />
            </div>
            <div>
                <asp:ListView ID="Wall" DataKeyNames="CommentID" OnItemDeleting="Wall_ItemDeleting" OnItemCanceling="Wall_ItemCanceling" OnItemUpdating="Wall_ItemUpdating" OnItemEditing="Wall_ItemEditing" runat="server">
                    <EmptyDataTemplate>
                        ingen comment
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <div class="WallElement">
                            <div style="padding: 5px; border-bottom: solid 1px black;">
                                <%#Eval("Username") %>
                                <br />
                                <%#Eval("CreatedTime") %>
                                <asp:Button ID="editBtn" runat="server" CssClass="ButtonBase" CommandName="Edit" Text="Edit" />
                                <asp:Button ID="DeleteBtn" runat="server" CssClass="ButtonBase" CommandName="Delete" Text="Delete" />
                            </div>
                            <div style="padding: 5px;">
                            <asp:Label ID="Comment" runat="server">
                                <%#Eval("Comment") %>
                            </asp:Label></div>
                        </div>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <div class="WallElement WallAlternating">
                            <div style="padding: 5px; border-bottom: solid 1px black;">
                                <%#Eval("Username") %>
                                <br />
                                <%#Eval("CreatedTime") %>
                                <asp:Button ID="editBtn" runat="server" CssClass="ButtonBase" CommandName="Edit" Text="Edit" />
                                <asp:Button ID="DeleteBtn" runat="server" CssClass="ButtonBase" CommandName="Delete" Text="Delete" />
                            </div>
                            <div style="padding: 5px;">
                            <asp:Label ID="Comment" runat="server">
                                <%#Eval("Comment") %>
                            </asp:Label></div>
                        </div>
                    </AlternatingItemTemplate>
                    <EditItemTemplate>
                        <div class="WallElement" style="background: #aaa;">
                            <div style="padding: 5px; border-bottom: solid 1px black;">
                                <%#Eval("Username") %>
                                <br />
                                <%#Eval("CreatedTime") %>
                                <asp:Button ID="CancelBtn" CssClass="ButtonBase" runat="server" CommandName="Cancel" Text="Cancel" />
                                <asp:Button ID="Updatetn" CssClass="ButtonBase" runat="server" CommandName="Update" Text="Save" />
                            </div>
                            <div style="">
                                <asp:TextBox ID="EditBox" CssClass="WallEditTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </EditItemTemplate>
                </asp:ListView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="DebugOutput" runat="Server">
</asp:Content>

