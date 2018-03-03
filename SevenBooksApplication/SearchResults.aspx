<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="SevenBooksApplication.SearchResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="repBookListSearch" runat="server" OnItemCommand="AddToCartbtn_Click">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
            <div style="display: inline-block">
            <%--<asp:Image runat="server" Width="200px" PostBackUrl='<%# "~/BookDetails.aspx?ISBN=" +Eval("ISBN") %>'
                       ImageUrl='<%# "~/image/"+Eval("ISBN")+".jpg" %>' AlternateText='<%#Eval("ISBN") %>'></asp:Image>--%>
            <asp:ImageButton runat="server" Width="200px" CssClass="img-responsive" ID="bookImage"
                                 PostBackUrl='<%# "~/BookDetails.aspx?ISBN=" +Eval("ISBN") %>'
                                 ImageUrl='<%# "~/image/"+Eval("ISBN")+".jpg" %>' AlternateText='<%#Eval("ISBN") %>'></asp:ImageButton>
            <br/>
            <table>
                <tr><td class="title"><asp:Label CssClass="lb-book-list" ID = "lbTitle" runat="server" text ='<%#Eval("Title") %>'></asp:Label></td></tr>
                <tr><td class="author"><asp:Label CssClass="lb-book-list" ID = "lbAuthor" runat="server" text ='<%#Eval("Author") %>'></asp:Label></td></tr>
                <tr><td class ="price"><asp:Label CssClass="lb-book-list" ID = "lbPrice" runat="server" text ='<%# "S$" + Eval("Price") %>' ></asp:Label></td></tr>
                <tr><td class="add-to-cart"><asp:Button CssClass="btn-primary"  runat="server" ID="btnAddtoCart"
                    Text="Add to cart" CommandName="AddToCart" CommandArgument='<%#Eval("ISBN")%>' /></td></tr>
            </table>
            </div>
            
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
    </asp:Content>
