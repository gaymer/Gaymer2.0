<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Meldinger.aspx.cs" Inherits="User_Meldinger" %>
<%--<%@ MasterType VirtualPath="~/MasterPage.Master" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="MasterPanel" runat="server" HorizontalAlign="Center" BackColor="#EFFFDF">
        <asp:Panel ID="PVenstre" runat="server" HorizontalAlign="Left">
            <div style="float:left";>
          
            <asp:GridView ID="MeldBrukere" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="223px" AutoGenerateColumns="False" OnSelectedIndexChanged="MeldBrukere_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#E3EAEB" />
                <Columns>
                    <asp:ButtonField Text="Username" DataTextField="Username" HeaderText="Brukere" />
                </Columns>
                <Columns>
                    <asp:BoundField HeaderText="Uleste Meldinger" DataField="Read" />
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
                <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
                </div>
        </asp:Panel>

        <asp:Panel ID="PHøyre" runat="server" HorizontalAlign="Right">
            <div style="float:right";>
            <asp:GridView ID="MeldingerGV" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
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
        </asp:Panel>
  </asp:Panel>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="DebugOutput" Runat="Server">
</asp:Content>

