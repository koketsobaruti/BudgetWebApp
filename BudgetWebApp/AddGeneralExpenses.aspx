<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGeneralExpenses.aspx.cs" Inherits="BudgetWebApp.AddGeneralExpenses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Expense Details
    </h1>

    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>

    <br />
        <table class="nav-justified">
            <tr>
                <td style="font-size: large; width: 840px; text-decoration: underline;" class="modal-lg">Income Details<br />
                </td>
                <td style="width: 357px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr aria-sort="none" style="font-size: medium">
                <td style="width: 840px; font-size: small;" class="modal-lg">&nbsp;<asp:Label ID="errorEmptyLbl" runat="server" ForeColor="Red" Text="*Enter all the missing values" style=""></asp:Label>
                    &nbsp; 
                    <br />
                    &nbsp;&nbsp;
                    Monthly income :&nbsp; R&nbsp;
                    <asp:TextBox ID="txtMonthlyIncome" runat="server" Height="27px" Width="114px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMonthlyIncome"></asp:RequiredFieldValidator>
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Estimated Tax :
                    <asp:TextBox ID="txtTax" runat="server" Width="89px" Height="27px"></asp:TextBox>
&nbsp;%<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTax"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 357px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 840px; font-size: small; height: 33px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td style="height: 33px; width: 357px;"></td>
                <td style="height: 33px"></td>
            </tr>
            <tr>
                <td style="font-size: large; width: 840px; text-decoration: underline; height: 22px;">General Expenses</td>
                <td style="height: 22px; width: 357px;">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="font-size: small; width: 840px; background-color: #F0F0F0; height: 126px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Groceries : R <asp:TextBox ID="txtGroceries" runat="server" Height="27px" Width="138px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGroceries"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Travel Costs : R
                    <asp:TextBox ID="txtTravel" runat="server" Height="27px" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTravel"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    &nbsp;
                    Water and Lights : R
                    <asp:TextBox ID="txtUtilies" runat="server" Height="27px" Width="138px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUtilies"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Telephone and Cellphone : R
                    <asp:TextBox ID="txtCommunication" runat="server" Height="27px" Width="138px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCommunication"></asp:RequiredFieldValidator>
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td style="font-size: small; height: 126px; width: 357px;">
                    &nbsp;</td>
                <td style="height: 126px; font-size: small;">
                    <asp:Panel runat="server" ID="panelExpenseList" Height="169px">
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 840px; height: 33px; font-size: medium;">
                    <br />
                    Click &#39;Add Other&#39; to add any other extra expenses that you may have.<br />
                </td>
                <td style="width: 357px; height: 33px;"></td>
                <td style="height: 33px"></td>
            </tr>
            <tr>
                <td style="width: 840px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="font-size: medium; width: 840px;" >
                    <asp:Button ID="btnReturn" runat="server" BackColor="#FE3A0A" BorderStyle="Solid" ForeColor="White" OnClick="Button2_Click" Text="Return" />
                </td>
                <td style="font-size: medium">
                    &nbsp;
                    <asp:Button ID="btnAddOther" runat="server" BackColor="#006699" BorderStyle="Solid" ForeColor="White" Text="Add other..." OnClick="btnAddOther_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnContinue" runat="server" BackColor="#00D200" BorderStyle="Solid" ForeColor="White" Text="Next" OnClick="btnContinue_Click" Height="33px" Width="94px" />
                </td>
                <td>
    <asp:HiddenField runat="server" ID="username" />
                </td>
            </tr>
            <tr>
                <td style="width: 840px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

</asp:Content>
