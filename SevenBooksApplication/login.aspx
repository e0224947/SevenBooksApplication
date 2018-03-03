<%@ Page Title="Login/ Register" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SevenBooksApplication.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <table style="margin: auto; border:hidden" >
            <tr>
                
                <td class="auto-style3"><div class="card-border-primary">
                    <asp:Login CssClass="login-panel" ID="Login1" runat="server" Height="300px" OnLoggedIn="Login1_LoggedIn" BorderStyle="None" Width="407px">
                        <LayoutTemplate><br/>
                            
                            <table cellpadding="1" cellspacing="0" style="border: hidden;">
                                <tr>
                                    <td>
                                        <table cellpadding="5px" style="height:300px;width:407px;">
                                            <tr>
                                                <td align="center" colspan="2" style="border: hidden; padding-bottom: 30px"><strong>Log In</strong></td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox CssClass="input-box" ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color:Red;">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:Button ID="LoginButton" runat="server" BorderStyle="None" CommandName="Login" CssClass="btn-primary" Font-Bold="True" Text="Log In" ValidationGroup="Login1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <LoginButtonStyle BorderStyle="None" CssClass="btn-primary" Font-Bold="True" />
                    </asp:Login></div>
                </td>
                
                <td>
                    <div class="card-border-primary" >
                        
                    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" ContinueDestinationPageUrl="~/Default.aspx" OnContinueButtonClick="CreateUserWizard1_ContinueButtonClick" OnCreatedUser="CreateUserWizard1_CreatedUser" BorderStyle="None" Height="100px" Width="653px">
                        <CreateUserButtonStyle BorderStyle="None" CssClass="btn-primary" Font-Bold="True" />
                        <WizardSteps>
                            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                                <ContentTemplate>
                                    <table cellpadding="5px"  style="font-size:100%;height:100px;width:653px;">
                                        
                                        <tr>
                                            <td style="padding: 20px;" align="center" colspan="2"><strong>Sign Up for Your New Account</strong></td>
                                        </tr>
                                        
                                        <tr>
                                            <td style="padding: 5px;" align="right">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox CssClass="input-box"  ID="UserName" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;" align="right">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox CssClass="input-box"  ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;" align="right">
                                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox CssClass="input-box"  ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;" align="right">
                                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox CssClass="input-box"  ID="Email" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;" align="right">
                                                <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security Question:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox CssClass="input-box"  ID="Question" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" ErrorMessage="Security question is required." ToolTip="Security question is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;" align="right">
                                                <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security Answer:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox CssClass="input-box" ID="Answer" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer" ErrorMessage="Security answer is required." ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;" align="center" colspan="2">
                                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match." ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;" align="center" colspan="2" style="color:Red;">
                                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </ContentTemplate>
                                <CustomNavigationTemplate>
                                    <table border="0"  style="width:100%;height:100%;">
                                        <tr align="right">
                                            <td align="center" colspan="0">
                                                <asp:Button ID="StepNextButton" runat="server" BorderStyle="None" CommandName="MoveNext" CssClass="btn-primary" Font-Bold="True" Text="Create User" ValidationGroup="CreateUserWizard1" />
                                            </td>
                                        </tr>
                                    </table>
                                </CustomNavigationTemplate>
                            </asp:CreateUserWizardStep>
                            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                            </asp:CompleteWizardStep>
                        </WizardSteps>
                    </asp:CreateUserWizard>
                    </div>
                </td>
            </tr>
        </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style3 {
            width: 485px;
        }
    </style>
</asp:Content>

