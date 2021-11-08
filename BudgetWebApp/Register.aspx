<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BudgetWebApp.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Register
    </h2>
    <h3 style="color: #FF0000; font-size: medium">*Required</h3>

            <table class="nav-justified">
                <tr>
            <td style="font-size: medium; height: 43px; width: 659px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Name :&nbsp;<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

            </td>
            <td style="height: 43px"></td>
            <td style="height: 43px"></td>
        </tr>
                    <tr>
            <td style="font-size: medium; height: 43px; width: 659px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Surname :
                <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSurname" ErrorMessage="*" ForeColor="Red" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
                <tr>
                    <td style="font-size: medium; height: 43px; width: 659px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Username :
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUsername" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

                        <asp:Label ID="takenLabel" runat="server"  ForeColor="Red" Text="Username is already taken."/>

                    </td>
                    <td style="height: 43px"></td>
                    <td style="height: 43px"></td>
                </tr>
                <tr>
                    <td style="font-size: medium; height: 45px; width: 659px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Password :
                        <asp:TextBox ID="txtPassword" runat="server" Height="26px" TextMode="Password" Width="177px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td style="font-size: medium; height: 45px;"></td>
                    <td style="font-size: medium; height: 45px;"></td>
                </tr>
                <tr>
                    <td style="font-size: medium; height: 43px; width: 659px;">Confirm Password :
                        <asp:TextBox ID="txtCompare" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtCompare" Display="Dynamic" ErrorMessage="*Enter matching passwords" ForeColor="Red"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCompare" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td style="height: 43px">&nbsp;</td>
                    <td style="height: 43px"></td>
                </tr>
                <tr>
                    <td style="width: 659px; height: 51px">
                        <asp:Button ID="btnReturn" runat="server" ForeColor="#0000CC" Height="31px" OnClick="btnReturn_Click" Text="Return To Login" Width="157px" />
                        &nbsp;&nbsp; </td>
                    <td style="height: 51px">
                        <asp:Button ID="btnCreate" runat="server" BackColor="#00CC00" CausesValidation="False" BorderStyle="Solid" ForeColor="White" Height="32px" OnClick="btnCreate_Click" Text="Next" Width="112px" />
                    </td>
                    <td style="height: 51px"></td>
                </tr>
        
        </table>
    
</asp:Content>
