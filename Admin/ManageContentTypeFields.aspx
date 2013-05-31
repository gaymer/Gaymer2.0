<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageContentTypeFields.aspx.cs" Inherits="Admin_ManageContentTypeFields" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:DataList ID="DataList1" runat="server" OnUpdateCommand="DataList1_UpdateCommand" OnCancelCommand="DataList1_CancelCommand" OnEditCommand="DataList1_EditCommand" DataSourceID="SqlDataSource1">
        <EditItemTemplate>
            Name:   
            <asp:TextBox ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            <br />
            Label:
            <asp:TextBox ID="LabelLabel" runat="server" Text='<%# Eval("Label") %>' />
            <br />
            CssName:
            <asp:Label ID="CssNameLabel" runat="server" Text='<%# Eval("CssName") %>' />
            <br />
            Weight:
            <asp:Label ID="WeightLabel" runat="server" Text='<%# Eval("Weight") %>' />
            <br />
            HelpText:
            <asp:Label ID="HelpTextLabel" runat="server" Text='<%# Eval("HelpText") %>' />
            <br />
            <asp:Button ID="Button1" CommandName="update" Text="Lagre" runat="server" /> 
            <asp:Button ID="Button2" CommandName="cancel" Text="Avbryt" runat="server" />
            <br />
            <br />
        </EditItemTemplate>
        <ItemTemplate>
            Name:   
            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            <br />
            Label:
            <asp:Label ID="LabelLabel" runat="server" Text='<%# Eval("Label") %>' />
            <br />
            CssName:
            <asp:Label ID="CssNameLabel" runat="server" Text='<%# Eval("CssName") %>' />
            <br />
            Weight:
            <asp:Label ID="WeightLabel" runat="server" Text='<%# Eval("Weight") %>' />
            <br />
            HelpText:
            <asp:Label ID="HelpTextLabel" runat="server" Text='<%# Eval("HelpText") %>' />
            <br />
            <asp:Button ID="Button3" CommandName="edit" Text="Rediger" runat="server" />


            <asp:Button ID="Button4" Text="Flytt opp" runat="server" />
            <asp:Button ID="Button5" Text="Flytt ned" runat="server" />


<%--            <asp:Button ID="Button4" PostBackUrl='<%# String.Format("~/Admin/ManageContentTypeFields.aspx?dcti={0}", Eval("DynamicContentTypeId")) %>' Text="Administrer felt" runat="server" />--%>
            <br />
            <br />

            <%--            InputElementId:
            <asp:Label ID="InputElementIdLabel" runat="server" Text='<%# Eval("InputElementId") %>' />
            <br />
            ContentTypeId:
            <asp:Label ID="ContentTypeIdLabel" runat="server" Text='<%# Eval("ContentTypeId") %>' />
            <br />--%>
            <br />
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:gaymerdbConnectionString %>" SelectCommand="SELECT InputElement.Name, InputElement.Label, InputElement.CssName, ElementInContent.Weight, ElementInContent.HelpText, ElementInContent.InputElementId, ElementInContent.ContentTypeId FROM ElementInContent INNER JOIN InputElement ON ElementInContent.InputElementId = InputElement.InputElementId WHERE (ElementInContent.ContentTypeId = @dcti) ORDER BY ElementInContent.Weight">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="-1" Name="dcti" QueryStringField="dcti" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="DebugOutput" runat="Server">
</asp:Content>

