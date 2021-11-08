<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddVehicle.aspx.cs" Inherits="BudgetWebApp.AddVehicle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 255px;
        }
        .auto-style2 {
            width: 580px;
        }
        

        .button-back {
            background-color: lightseagreen;
            color: white;
            border-radius: 7px;
        }
        .button-back:hover {
            background-color: darkcyan;
        }

        .button-submit {
            background-color: #00CC00;
            color: white;
            border-radius: 7px;
        }

        .button-submit:hover{
            background-color: darkgreen;
        }

    </style>
</head>
<body>
<h1>Vehicle Information</h1>
    <form id="form1" runat="server" style="font-size: medium">
        Enter your vehicle information below.
        <div>
            
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:HiddenField ID="username" runat="server" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Model : <asp:TextBox runat="server" ID="txtModel"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*required" ForeColor="Red" ControlToValidate="txtModel" Text="*"></asp:RequiredFieldValidator>
                        <br/>
                        <br/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Make : <asp:TextBox runat="server" ID="txtMake"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMake" ErrorMessage="*required" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                        <br/>
                        <br/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Purchase Price : R <asp:TextBox runat="server" ID="txtPurchasePrice" Height="23px" Width="166px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPurchasePrice" ErrorMessage="*required" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                        <br/>
                        <br/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Deposit :R  <asp:TextBox runat="server" ID="txtDeposit" Height="23px" Width="166px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDeposit" ErrorMessage="*required" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                        <br/>
                        <br/>
                        &nbsp;
                        Estimated Interest Rate: <asp:TextBox runat="server" ID="txtInterest" Height="27px" Width="98px"></asp:TextBox>
                        %<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtInterest" ErrorMessage="*required" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                        <br/>
                        <br/>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        Insurance Premium : R <asp:TextBox runat="server" ID="txtInsurance" Height="25px" Width="160px"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtInsurance" ErrorMessage="*required" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>

                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        <br />
                        <asp:Button ID="btnSubmit" runat="server" Text="Add Vehicle" CssClass="button-submit" OnClick="btnSubmit_Click"/>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Added your vehicle" ForeColor="red"></asp:Label>
                        <br />
                        <br />
                    </td>
                    <td>
                            &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="btnReturn" runat="server" CssClass="button-back" Text="&lt;&lt; Go Back" OnClick="btnReturn_Click" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                            <asp:Button ID="btnComplete" runat="server" CssClass="button-orange" ForeColor="White" Text="Complete Registration&gt;&gt;" OnClick="btnComplete_Click" />
                        </td>
                </tr>
            </table>
            
        </div>
        
    </form>
</body>
</html>
