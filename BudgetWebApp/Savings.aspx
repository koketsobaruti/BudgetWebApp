<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Savings.aspx.cs" Inherits="BudgetWebApp.Savings" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=20.1.0.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Savings Page</h1>
        <p style="font-size: 22px">Enter the required details in order to calculate how much your monthly savings should be in order to reach your goal.</p>
        <p style="font-size: 21px; text-decoration: underline;">Your Goal Details</p>
        <div style="font-size: medium">
            <br/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Reason for Savings : <asp:TextBox runat="server" ID="txtReason" Height="62px" TextMode="MultiLine" Width="287px" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Reason should be between 5 and 50 characters." ControlToValidate="txtReason"
                                            ValidationExpression="^[\s\S]{5,50}$" ForeColor="red" Display="Dynamic"></asp:RegularExpressionValidator>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtReason" ValidationGroup="house" Display="Dynamic"></asp:RequiredFieldValidator>

            <br/>
            <br/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Savings Goal : R <asp:TextBox runat="server" ID="txtGoal" Height="29px" Width="180px" ></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtReason" ValidationGroup="house"></asp:RequiredFieldValidator>

            <br/>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Interest Amount : <asp:TextBox runat="server" ID="txtInterestRate" Height="29px" Width="77px"></asp:TextBox>
        &nbsp;%
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtReason" ValidationGroup="house">

            </asp:RequiredFieldValidator>
                <br />
                <table class="nav-justified">
                <tr>
                    <td style="width: 257px; height: 67px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Interest Method :<br />
                    </td>
                    <td style="width: 773px; height: 67px;"> 
                        <br />

                        <asp:Button ID="btnSimple" runat="server" Text="Simple Interest" CssClass="button-red" OnClick="btnSimple_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCompound" runat="server" Text="Compound Interest" CssClass="button-house" ForeColor="White" OnClick="btnCompound_Click" />

                        <br />
                        <asp:Label ID="errLbl" runat="server" Text="*You need to select an option" ForeColor="Red"></asp:Label>

                        <br />

                    </td>
                    <td style="height: 67px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 257px;"width: 773px;> 
                        
                    </td>
                    <td >
                        &nbsp;<br />
                        <asp:Label ID="lblCompoundN" runat="server" Text="Your interest will be compounded every  " ForeColor="#698988"></asp:Label>

                    &nbsp;<asp:TextBox ID="TextBox1" runat="server" Height="24px" Width="72px"></asp:TextBox>
&nbsp;<asp:Label ID="lblCompoundN0" runat="server" Text="months." ForeColor="#698988"></asp:Label>

                        <asp:Button ID="btnAdd" runat="server" CssClass="rent-submit-button" Text="Add Months..." Height="34px" Width="145px" />
                        <br />
                        </td>
                </tr>
                <tr>
                    <td style="width: 257px">
                        Enter the savings duration:</td>
                    <td style="width: 773px">
                        <asp:TextBox ID="txtYears" runat="server" Height="24px" Width="72px"></asp:TextBox>
                        <br />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 257px">&nbsp;</td>
                    <td style="width: 773px">
                        <asp:HiddenField ID="username" runat="server"></asp:HiddenField>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br/>
            <asp:Button runat="server" ID="btnCalculate" Text="Calculate Monthly Savings" Height="37px" Width="270px" OnClick="btnCalculate_Click" CssClass="button-green"></asp:Button>
            <br/>
            <br/>
            Required Monthly Savings : R
            <asp:TextBox runat="server" ID="txtRequiredAmount" Enabled="False" Height="25px" Width="168px"/>
            &nbsp;
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;
            <br/>
            <p></p>
        </div>
    <div id="saveModal">
       
</div>
</asp:Content>
