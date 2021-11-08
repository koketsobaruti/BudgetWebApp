<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAccomodation.aspx.cs" Inherits="BudgetWebApp.NewAccomodation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <style type="text/css">
        .auto-style1 {
            width: 226px;
        }

        .auto-style2 {
            width: 226px;
            height: 20px;
        }

        .auto-style3 {
            height: 20px;
        }

        .auto-style4 {
            width: 932px;
        }

        body {
            padding-top: 50px;
            padding-right: 30px;
            padding-bottom: 50px;
            padding-left: 30px;
        }

        
        .house-submit-button {
            background-color: lightgreen;
            color: white;
            border-radius: 7px;
        }
        .house-eligibility {
            background-color: lightsteelblue;
            border-radius: 7px;
            
        }
        .auto-style5 {
            width: 642px;
        }
        .button-complete {
            background-color: darkorange;
            border-radius: 7px;
        }
        .button-complete:hover {
            background-color: orangered;
        }
        .button-vehicle {
            background-color: lightseagreen;
            border-radius: 7px;
        }
        .button-vehicle:hover {
            background-color: darkcyan;
        }
        .auto-style6 {
            width: 277px;
        }
    </style>
</head>

<body>
    <h1>Accommodation Information</h1>
    <form id="form1" runat="server">
    <h3 style="color: red">*Required</h3>
        <div style="font-size: medium">
            Click the button of the accommodation choice you want.<br />
            <br />
            <asp:Button ID="btnRentOption" runat="server" Text="I want to rent" ForeColor="White" CausesValidation="False" OnClick="btnRentOption_Click" CssClass="button-red"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBuyOption" runat="server" Text="I want to buy a house"  ForeColor="White" CausesValidation="False" OnClick="btnBuyOption_Click" CssClass="button-house" />
            <br />
            <br />
            If you are renting, enter details under the rent option, if you want to buy a house, enter details under the option of buying a house.<br />
            <table class="nav-justified">
                <tr>
                    <td class="auto-style1" style="font-size: large">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Rental Option :</td>
                    <td>Please enter your monthly rental amount below in rands.</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style3">
                        <asp:Panel ID="Panel1" runat="server" Height="138px">
                            Monthly Rental : R
                            <asp:TextBox runat="server" ID="rentTxt" OnTextChanged="rentTxt_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="fieldValidator" ForeColor="Red" Text="*" ControlToValidate="rentTxt" ValidationGroup="rent"></asp:RequiredFieldValidator>
                            <br />
                            <br />
                            <asp:Button runat="server" ID="btnRent" Text="Submit" OnClick="btnRent_Click" CssClass="rent-submit-button" CausesValidation="True"/>
                            <br />
                            <asp:Label ID="rentConfirm" runat="server" ForeColor="Red" Text="You have saved your rent."></asp:Label>
                        </asp:Panel>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
            </table>
            
            <table class="nav-justified">
                <tr>
                    <td class="auto-style1" style="font-size: large">House Loan Option :</td>
                    <td class="auto-style4">
                        Please enter the required home loan details and click 'Calculate Eligibility' find out if you qualify.
                    </td>
                    <td class="auto-style13"></td>
                </tr>
                <tr>
                    <td class="auto-style13"></td>
                    <td class="auto-style4">
                        <asp:Panel runat="server" ID="Panel2">
                            <p>
                                    <asp:Label ID="lbl5" runat="server" ForeColor="Red" Text="*Required"></asp:Label>
                                </p>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label runat="server" ID="lablelA" Text="Purchase Price : R"></asp:Label>
                                &nbsp;
                                <asp:TextBox runat="server" ID="txtPurchase" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPurchase" ValidationGroup="house"></asp:RequiredFieldValidator>
                                <br />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label runat="server" ID="lablelA0" Text=" Deposit : R"></asp:Label>
                                &nbsp;
                                <asp:TextBox runat="server" ID="txtDeposit" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDeposit" ValidationGroup="house"></asp:RequiredFieldValidator>
                                <br />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lablelA1" Text="Interest Rate : R"></asp:Label>
                                &nbsp;
                                <asp:TextBox runat="server" ID="txtInterest" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtInterest" ValidationGroup="house"></asp:RequiredFieldValidator>
                                <br />
                                <br />
                                &nbsp;
                                <asp:Label runat="server" ID="lablelA2" Text="Number of Months to Pay :"></asp:Label>
                                &nbsp;
                                <asp:TextBox runat="server" ID="txtPaymentMonths" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPaymentMonths" ValidationGroup="house"></asp:RequiredFieldValidator>
                                <br />
                                <br />
                                <asp:Button ID="btnEligibility" runat="server" ForeColor="White" OnClick="btnEligibility_Click" Text="Calculate Eligeability" CssClass="house-eligibility" />

                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
                                &nbsp;&nbsp;
                                <asp:Label ID="houseConfirmation" runat="server" ForeColor="red"></asp:Label>
                            
                        </asp:Panel>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1" style="font-size: large"></td>
                    <td class="auto-style4">
                                <asp:Button runat="server" ID="btnSubmitHome" Text="Add Home Loan" BorderStyle="Solid" ForeColor="White" OnClick="btnSubmitHome_Click" CssClass="house-submit-button"/>
                    </td>
                    <td class="auto-style13"></td>
                </tr>
            </table>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
            <div>
                <p>If you intend on owning a vehicle, click the &#39;Add Vehicle&#39; button to fill out the vehicle form. Otherwise, complete your registration</p>
                <table class="nav-justified">
                    <tr>
                        <td style="font-size: medium" class="auto-style5"></td>
                        <td class="auto-style6">
                            <asp:Button ID="btnVehicle" runat="server" CssClass="button-vehicle" ForeColor="White" Text="Add Vehicle" OnClick="btnVehicle_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnComplete" runat="server" CssClass="button-complete" ForeColor="White" Text="Complete Registration&gt;&gt;" OnClick="btnComplete_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style6">
                            <asp:HiddenField ID="username" runat="server" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style6">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>

            </div>
        </div>
        
    </form>

</body>
</html>
