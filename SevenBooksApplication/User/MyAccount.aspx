<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="SevenBooksApplication.MyAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Opss, You haven't purchase any book yet."></asp:Label>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:GridView ID="gvOrderHistory" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvOrderHistory_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
                    <asp:TemplateField HeaderText="Book Title">                   
                        <ItemTemplate>
                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DatePurchase" DataFormatString="{0: dd/MM/yyyy}" HeaderText="Date Purchase" />
                    <asp:BoundField DataField="Price" DataFormatString="S${0:0.00}" HeaderText="Purchase Price" />
                    <asp:BoundField DataField="Quantity" HeaderText="Purchase Quantity" />
                    <asp:BoundField DataField="OrderStatus" HeaderText="Order Status" />
                </Columns>
            </asp:GridView>
        </asp:View>
    </asp:MultiView>
</asp:Content>
