<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VehicleLoan.aspx.cs" Inherits="BudgetWebApp.VehicleLoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Vehicle Loan information</h1>
    <div style="font-size: medium">

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Model : <asp:TextBox runat="server" ID="txtModel" Enabled="False"></asp:TextBox>
                        <br/>
                        <br/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Make : <asp:TextBox runat="server" ID="txtMake" Enabled="False"></asp:TextBox>
                        <br/>
                        <br/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Purchase Price : R <asp:TextBox runat="server" ID="txtPurchasePrice" OnTextChanged="Label2_TextChanged" Height="23px" Width="166px" Enabled="False"></asp:TextBox>
                        <br/>
                        <br/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Deposit :R  <asp:TextBox runat="server" ID="txtDeposit" Height="23px" Width="166px" Enabled="False"></asp:TextBox>
                        <br/>
                        <br/>
                        &nbsp;
                        Estimated Interest Rate: <asp:TextBox runat="server" ID="txtInterest" Height="27px" Width="98px" Enabled="False"></asp:TextBox>
                        %<br/>
                        <br/>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        Insurance Premium : R <asp:TextBox runat="server" ID="txtInsurance" Height="25px" Width="160px" Enabled="False"></asp:TextBox>

                        <br />
        <br />
        <asp:Button ID="btnBack" runat="server" CssClass="button-orange" OnClick="btnBack_Click" Text="&lt;&lt; Go Back" />

    </div>
</asp:Content>
