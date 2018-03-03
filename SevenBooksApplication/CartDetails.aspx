<%@ Page Title="Cart Details" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CartDetails.aspx.cs" Inherits="SevenBooksApplication.CartDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table style="width: 1196px; height: 258px">
        <tr>
            <td style="width: 174px">
                &nbsp;</td>
            <td style="width: 911px">

                <table class="auto-style1" style="width: 97%">
                    <tr>
                        <td class="auto-style3">
                            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" AutoGenerateColumns="False" Width="588px" OnRowDeleting="GridView1_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="Title" HeaderText="Title" />
                                    <asp:BoundField DataField="Author" HeaderText="Author" />
                                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                                    <asp:BoundField DataField="Price" HeaderText="Price" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <image src="image/<%# Eval("ISBN") %>.jpg" width="90" height="120"></image>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowDeleteButton="true" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 356px"></td>
                        <td>&nbsp;</td>
                    </tr>
                </table>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Table ID="Table1" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                              ORDER TOTAL
                                </asp:TableCell>
                            </asp:TableRow>



                        </asp:Table>
                        <table style="width: 100%;">
                            <tr>
                                <td class="auto-style4"><span style="color: rgb(106, 106, 106); font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Subtotal</span></td>
                                <td class="auto-style5"></td>
                                <td class="auto-style6">
                                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 23px; width: 255px;"><span style="color: rgb(106, 106, 106); font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: right; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Discount<span>&nbsp;</span></span></td>
                                <td style="height: 23px; width: 276px;"></td>
                                <td style="height: 23px">
                                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 255px"><strong style="margin: 0px; padding: 0px; font-weight: bold; color: rgb(242, 123, 4); font-family: helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">Grand Total</strong></td>
                                <td style="width: 276px">&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
                <asp:Button ID="Button4" runat="server" Text="PROCEED TO CHECKOUT" Width="300px" OnClick="Button4_Click" />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style3 {
            height: 23px;
            width: 214px;
        }

        .auto-style4 {
            width: 255px;
            height: 23px;
        }

        .auto-style5 {
            width: 276px;
            height: 23px;
        }

        .auto-style6 {
            height: 23px;
        }
    </style>
</asp:Content>

