<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="BudgetWebApp.Homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
    <h2>Budgeting Application Homepage</h2>
    <br/>
    <div>
        <div style="font-size: large">My Balances</div>
        <br/>
        
        <div style="font-size: medium">
            <asp:Label ID="errLbl" runat="server" Text="*Required" ForeColor="red"></asp:Label>
            <br/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Gross Income : R <asp:TextBox runat="server" ID="txtIncome" Height="25px" Width="145px"/>
                            &nbsp;<asp:RequiredFieldValidator runat="server" ID="fieldValidator" ForeColor="Red" Text="*" ControlToValidate="txtIncome" ></asp:RequiredFieldValidator>
            <br/>
            <br/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Tax : <asp:TextBox runat="server" ID="txtTax" Height="27px" Width="107px"/>
                            &nbsp;%&nbsp;
                            <asp:RequiredFieldValidator runat="server" ID="fieldValidator0" ForeColor="Red" Text="*" ControlToValidate="txtTax"></asp:RequiredFieldValidator>
            <br/>
            <br/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Income after Tax : R <asp:TextBox runat="server" ID="txtAfterTax" Height="24px" Width="145px"/>
            <br/>
            <br/>
            &nbsp;&nbsp;&nbsp;&nbsp;
            Total monthly Expenses : R <asp:TextBox runat="server" ID="txtTotalExpenses" Height="23px" Width="152px"/>
            <br/>
            <br/>
            &nbsp;
            Income after all Expenses : R <asp:TextBox runat="server" ID="txtNet" Height="23px" Width="150px"/>
            <br/>
            <br/>
        </div>
        <p style="font-size: medium; color: #FF2626">Click on 'Save' to finish editing.</p>
        <table style="width:100%; font-size: medium;">
            <tr>
                <td style="width: 330px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="button-green" OnClick="btnEdit_Click" Height="38px" Width="75px"/>
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button-red" OnClick="btnSave_Click" Height="36px" Width="77px"/>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 330px">&nbsp;&nbsp;</td>
                <td>
                    <asp:HiddenField ID="username" runat="server" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 330px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>
</asp:Content>
