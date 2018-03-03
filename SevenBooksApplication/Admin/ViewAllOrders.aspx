<%@ Page Title="Manage Orders" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewAllOrders.aspx.cs" Inherits="SevenBooksApplication.ViewAllOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
             DataKeyNames="OrderID"
            OnRowCancelingEdit="OnRowCancelingEdit"
            OnRowEditing="OnRowEditing" OnRowUpdating="OnRowUpdating" CssClass="auto-style3" Height="248px" Width="1142px" OnRowDataBound="GridView1_RowDataBound" BorderStyle="Solid" >
            <Columns>
                <asp:TemplateField HeaderText="OrderID">
                    
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("OrderID") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="10px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="UserID">
                   
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("UserID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BookID">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("BookID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Title">
                    <ItemTemplate>
                        <asp:Label ID="lbTitle" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date">
                    
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("DatePurchase") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Discount">
                    
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("Discount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  
                  <asp:BoundField DataField="Price" DataFormatString="S${0:0.00}" HeaderText="Price" />
                 <asp:TemplateField HeaderText="Status">
                 <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("OrderStatus") %>'></asp:Label>
                    </ItemTemplate>
                      <EditItemTemplate>
                          <asp:DropDownList ID="ddlStatus" runat="server">
                             <asp:ListItem Text="Processed" Value="Processed" />
                            <asp:ListItem Text="Completed" Value="Cancel" />
                            <asp:ListItem Text="Canceled" Value="Deliver" />
                          </asp:DropDownList>
                        
                            
                       
                    </EditItemTemplate>
                     </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


              
               

             
                     
                <asp:CommandField ShowEditButton="True" />
              
            </Columns>
        </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style3 {
            margin-left: 0px;
            margin-top: 25px;
        }
    </style>
</asp:Content>

