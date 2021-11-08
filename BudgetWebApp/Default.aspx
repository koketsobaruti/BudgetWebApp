<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BudgetWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome to the Budgeting App</h1>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Login or Register to start budgeting!</h2>
        </div>
           
        </div>
    <h2>Login</h2>
    <h4>
        &nbsp;</h4>
    
    <table style="width:100%;">
        <tr>
            <td style="font-size: medium; height: 42px; width: 374px;">Username&nbsp; :&nbsp;
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </td>
            <td style="height: 42px; font-size: small; color: #FF0000;">
                <asp:Button ID="btnLogin" runat="server" Height="32px" OnClick="btnLogin_Click" Text="Login" Width="93px" />
            </td>
            <td style="height: 42px"></td>
        </tr>
        <tr>
            <td style="font-size: medium; height: 47px; width: 374px;">Password&nbsp; :&nbsp;
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="height: 47px; font-size: small; color: #0000FF;">New user?<br />
                <asp:Button ID="btnRegister" runat="server" ForeColor="#000066" Height="32px" Text="Register" Width="96px" OnClick="btnRegister_Click" />
                <br />
            </td>
            <td style="height: 47px"></td>
        </tr>
        <tr>
            <td style="width: 374px; font-size: medium; color: #FF0000;">&nbsp;
        <asp:Label ID="errLabel" runat="server" Text="Label" ></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
    
    
</asp:Content>
