<%@ Page Title="Set discount" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SetDiscount.aspx.cs" Inherits="SevenBooksApplication.SetDiscount" %>

<asp:Content ID="Head1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            var dateFormat = "dd/mm/yyyy",
                from = $("#MainContent_DateFrom")
                    .datepicker({
                        defaultDate: "+1w",
                        changeMonth: true,
                        numberOfMonths: 2
                    })
                    .on("change", function () {
                        to.datepicker("option", "minDate", getDate(this));
                    }),
                to = $("#MainContent_DateTo").datepicker({
                    defaultDate: "+1w",
                    changeMonth: true,
                    numberOfMonths: 2
                })
                    .on("change", function () {
                        from.datepicker("option", "maxDate", getDate(this));
                    });

            function getDate(element) {
                var date;
                try {
                    date = $.datepicker.parseDate(dateFormat, element.value);
                } catch (error) {
                    date = null;
                }

                return date;
            }
        });
    </script>
    <label for="from">From</label>
    <asp:TextBox ID="DateFrom" runat="server"></asp:TextBox>
    <label for="to">to</label>
    <asp:TextBox ID="DateTo" runat="server"></asp:TextBox>

    <h4>Discount percent:</h4>
    <asp:TextBox ID="tbDiscount" runat="server" Width="32px" />
    %
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Wrong number format" ValidationExpression="[1-9]{0,1}[0-9]" ControlToValidate="tbDiscount"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Button ID="btnConfirm" class="btn-primary" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
</asp:Content>

