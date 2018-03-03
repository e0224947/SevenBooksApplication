<%@ Page Title="Check out" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CheckoutCart.aspx.cs" Inherits="SevenBooksApplication.CheckoutCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
               <h3 style="color: #FF0000; position: relative; text-align: center;">Opps, your cart is empty</h3>
        </asp:View>
        <asp:View ID="View2" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Thanks for your orders. Below is your order summary:"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" HorizontalAlign="Left" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" PageSize="3" GridLines="Horizontal" Width="60%">
        <RowStyle HorizontalAlign="Center" />
        <Columns>
            <asp:TemplateField HeaderText="Book">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageAlign="Middle" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="lblQty" runat="server" Text="Label"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit Price">
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server" Text="Label"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Price">
                <ItemTemplate>
                    <asp:Label ID="lblTotalPrice" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="lblDiscount" runat="server" Text="Label" Visible="False"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <PagerSettings Position="TopAndBottom" />
        <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
    </asp:GridView>
            <br />
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MyAccount.aspx">Click here </asp:HyperLink>  to view all order history
    </p>

        </asp:View>
    </asp:MultiView>
</asp:Content>
