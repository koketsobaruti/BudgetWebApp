<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddOtherExpenses.aspx.cs" Inherits="BudgetWebApp.AddOtherExpenses" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=20.1.0.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    
    <title></title>
    <style>
        .other {
            padding: 5px;
        }
        .auto-style1 {
            width: 513px;
        }
        .auto-style2 {
            width: 248px;
        }
        .auto-style3 {
            width: 513px;
            height: 67px;
        }
        .auto-style4 {
            width: 248px;
            height: 67px;
        }
        .auto-style5 {
            height: 67px;
        }
    </style>
</head>
<body class="other">
    <form id="form1" runat="server">
        <h1>Add Other Expenses</h1>

        <div style="font-size: medium">
            Add Other Expenses<asp:HiddenField runat="server" ID="username" />
                                <br />
                        <asp:Label ID="errLbl" runat="server" ForeColor="Red" Text="*Enter the missing details"></asp:Label>
                        &nbsp;&nbsp;
                        <br />
                        <table class="nav-justified">
                            <tr>
                                <td class="auto-style1">&nbsp; Expense Description :
                        <asp:TextBox ID="txtOtherExp" runat="server" Height="27px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="fieldValidator" runat="server" ControlToValidate="txtOtherExp" ForeColor="Red" Text="*" ValidationGroup="rent"></asp:RequiredFieldValidator>
                                    <br />
                        <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cost : R&nbsp; <asp:TextBox ID="txtOtherCost" runat="server" Height="27px" Width="84px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="fieldValidator0" runat="server" ControlToValidate="txtOtherCost" ForeColor="Red" Text="*" ValidationGroup="rent"></asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
&nbsp;<br />
&nbsp;&nbsp;
                        <asp:Button ID="btnAdd" runat="server" Height="36px" Text="Add Other Expense" Width="225px" CausesValidation="False" OnClick="btnAdd_Click" BorderStyle="Solid" CssClass="button-orange"/>
                    

                        </td>
                                <td class="auto-style2">Your list of expenses :<br />
                                    <asp:ListBox ID="otherList" runat="server" Height="114px" style="margin-top: 0px" Width="226px"></asp:ListBox>
                                    <br />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    &nbsp;</td>
                                <td class="auto-style4">
                                    &nbsp;</td>
                                <td class="auto-style5">
                                    <asp:Button ID="btnSaveOther" runat="server" BorderStyle="Solid" ForeColor="White" Text="Next" OnClick="btnSaveOther_Click" CssClass="button-green" Height="37px" Width="110px"/>

                                    </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td class="auto-style2">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
            </table>
            

        </div>
    </form>
</body>
</html>
