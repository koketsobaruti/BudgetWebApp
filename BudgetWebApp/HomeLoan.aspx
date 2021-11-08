<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeLoan.aspx.cs" Inherits="BudgetWebApp.HomeLoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Home Loan</h1>
    <br/>
    <div style="font-size: medium">

                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                <asp:Label runat="server" ID="lablelA" Text="Purchase Price : R"></asp:Label>
                                &nbsp;
                                <asp:TextBox runat="server" ID="txtPurchase"  Enabled="False"/>
                                <br __designer:mapid="382" />
                                <br __designer:mapid="383" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label runat="server" ID="lablelA0" Text=" Deposit : R"></asp:Label>
                                &nbsp;
                                <asp:TextBox runat="server" ID="txtDeposit"  Enabled="False"/>
                                <br __designer:mapid="387" />
                                <br __designer:mapid="388" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lablelA1" Text="Interest Rate : R"></asp:Label>
                                &nbsp;
                                <asp:TextBox runat="server" ID="txtInterest" Enabled="False" />
                                <br __designer:mapid="38c" />
                                <br __designer:mapid="38d" />
                                &nbsp;
                                <asp:Label runat="server" ID="lablelA2" Text="Number of Months to Pay :"></asp:Label>
                                &nbsp;
                                <asp:TextBox runat="server" ID="txtPaymentMonths"  Enabled="False"/>

                                <br __designer:mapid="38c" />
                                <br __designer:mapid="38d" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total Monthly Cost :&nbsp;R&nbsp;
                                <asp:TextBox runat="server" ID="txtMonthly"  Enabled="False"/>

                                <br __designer:mapid="38c" />
                                <br __designer:mapid="38d" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total Cost : R&nbsp;
                                <asp:TextBox runat="server" ID="txtTotal"  Enabled="False"/>

                                <br />
                                <br />
                                <asp:Button ID="btnBack" runat="server" CssClass="button-orange" OnClick="btnBack_Click" Text="&lt;&lt; Go Back" />

    </div>
</asp:Content>
