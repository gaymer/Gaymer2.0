<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Meldinger2.aspx.cs" Inherits="User_Meldinger2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br/>
    <asp:Panel ID="MPanel" runat="server" BackColor="#EFFFDF" HorizontalAlign="Justify">
    <asp:Panel ID="panel1" runat="server">
        <div style="float: left">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="From" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" Height="167px" Width="327px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="From" HeaderText="From" SortExpression="From" Visible="false"/>
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" Visible="True"/>
                    <asp:BoundField DataField="PMessageId" HeaderText="PMessageId" InsertVisible="False" ReadOnly="True" SortExpression="PMessageId" Visible="false"/>
                    <asp:CheckBoxField DataField="Read" HeaderText="Read" SortExpression="Read" />
                    <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
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
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:gaymerdbConnectionString %>" SelectCommand="SELECT DISTINCT PrivateMessage.[From], [User].Username,PrivateMessage.PMessageId, PrivateMessage.[Read], PrivateMessage.Time FROM PrivateMessage,[User] WHERE (PrivateMessage.[To] = @To )AND([User].UID=PrivateMessage.[From]) ORDER BY [Read], Time DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="6" Name="To" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
    <asp:Panel ID="panel2" runat="server">
        <div style="float: right">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="From" DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="PMessageId" HeaderText="PMessageId" InsertVisible="False" ReadOnly="True" SortExpression="PMessageId" Visible="false"/>
                    <asp:BoundField DataField="From" HeaderText="From" SortExpression="From" Visible="false"/>
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                    <asp:CheckBoxField DataField="Read" HeaderText="Read" SortExpression="Read" />
                    <asp:BoundField DataField="Text" HeaderText="Text" SortExpression="Text" />
                    <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
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
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:gaymerdbConnectionString %>" SelectCommand="SELECT PrivateMessage.PMessageId, PrivateMessage.[From], [User].Username, PrivateMessage.[Read], PrivateMessage.Text, PrivateMessage.Time FROM PrivateMessage INNER JOIN [User] ON PrivateMessage.[From] = [User].UID WHERE (PrivateMessage.[To] = @To ) AND (PrivateMessage.[From] = @From ) ORDER BY PrivateMessage.Time DESC">
                <SelectParameters>
                    <asp:Parameter DefaultValue="6" Name="To" Type="Int32" />
                    <asp:ControlParameter ControlID="GridView1" Name="From" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </asp:Panel>
        </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="DebugOutput" runat="Server">
</asp:Content>

