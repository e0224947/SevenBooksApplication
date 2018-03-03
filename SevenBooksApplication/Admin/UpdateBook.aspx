<%@ Page Title="Update Book" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateBook.aspx.cs" Inherits="SevenBooksApplication.UpdateBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../StyleSheetSevenBook1.css" rel="stylesheet" />

    <br />
    <br />

     <table class="auto-style3">
         <tr>
            <td class="auto-style5">
                BookID
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="tbBookId" runat="server" Width="255px" Height="30px"></asp:TextBox> 
            </td>
        </tr>

        <tr>
            <td class="auto-style5">
                Title
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="tbTitle" runat="server" Height="30px" Width="255px"></asp:TextBox> 
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                Author
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="tbAuthor" runat="server" Height="30px" Width="255px"></asp:TextBox> 
            </td>
        </tr>
         <tr>
            <td class="auto-style5">
                ISBN
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="tbISBN" runat="server" Height="30px" Width="255px"></asp:TextBox> 
            </td>
        </tr>
         <tr>
            <td class="auto-style5">
                Catgory
            </td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlCategory" runat="server" Height="30px" Width="200px">
                    <asp:ListItem Text="Children" Value="children" />
                    <asp:ListItem Text="Finance" Value="finance" />
                    <asp:ListItem Text="non-fiction" Value="non-fiction" />
                    <asp:ListItem Text="Technical" Value="technical" />

                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td class="auto-style5">
                image
            </td>
            <td class="auto-style4">
                <asp:FileUpload ID="FileUpload1" runat="server" Height="30px" Width="437px" />
            </td>
             
        </tr>

         <tr>
            <td class="auto-style5">
                Price
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="tbPrice" runat="server" Height="30px" Width="255px"></asp:TextBox> 
            </td>
        </tr>
         <tr>
            <td class="auto-style6">
                Qutantity
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="tbQuantity" runat="server" Height="30px" Width="255px"></asp:TextBox>
                </td>
        </tr>
         <tr>
             <td>

             </td>
             <td>
 <asp:Button ID="btUpdate" CssClass="btn-primary" runat="server" Text="Update" OnClick="update" />
             </td>
             
         </tr>
    </table>
    <br />
    
    <br />

   
     <br />
    <asp:Label ID="Message" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style3 {
            width: 54%;
            height: 416px;
            margin-left: 260px;
            margin-top: 38px;
        }
        .auto-style4 {
            width: 980px;
        }
        .auto-style5 {
            width: 194px;
        }
        .a{
             font-family: Arial;
             color: #ffffff;
             font-size: 14px;
        }
        
        .auto-style6 {
            width: 194px;
            height: 45px;
        }
        .auto-style7 {
            width: 980px;
            height: 45px;
        }
        
    </style>
</asp:Content>

