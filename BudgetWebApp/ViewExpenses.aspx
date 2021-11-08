<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewExpenses.aspx.cs" Inherits="BudgetWebApp.ViewExpenses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Your Expenses</h1>
        <asp:HiddenField ID="username" runat="server" />
        <br/>
        <div>
            <table style="width:100%; font-size: medium;">
            <tr>
                <td class="modal-lg" style="width: 542px; height: 217px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
Groceries : R <asp:TextBox ID="txtGroceries" runat="server" Height="27px" Width="138px"></asp:TextBox>
                    &nbsp;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Travel Costs : R
                    <asp:TextBox ID="txtTravel" runat="server" Height="27px" Width="140px"></asp:TextBox>
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Water and Lights : R
                    <asp:TextBox ID="txtUtilies" runat="server" Height="27px" Width="138px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; 
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Telephone and Cellphone : R
                    <asp:TextBox ID="txtCommunication" runat="server" Height="27px" Width="138px"></asp:TextBox>
                    <br />
                </td>
                <td style="height: 217px; width: 315px;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="290px" Height="198px">
                        <Columns>
                            <asp:BoundField DataField="OTHER_EXPENSE" HeaderText="Other Expenses" SortExpression="OTHER_EXPENSE" />
                            <asp:BoundField DataField="COST" HeaderText="Cost (R)" SortExpression="COST" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" SelectCommand="SELECT OTHER_EXPENSE, COST FROM OTHER_EXPENSES WHERE FK_USERNAME = @FK_USERNAME">
                        <SelectParameters>
                            <asp:SessionParameter Name="FK_USERNAME" SessionField="name" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td style="height: 217px"></td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 542px">
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Monthly Rental : R "></asp:Label>
                    <asp:TextBox ID="txtRent" runat="server" Height="28px" Width="136px" Enabled="False"></asp:TextBox>
                    <br />
                    <br />
                </td>
                <td style="width: 315px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 542px">
                    <asp:Button ID="btnHome" runat="server" CssClass="button-orange" Height="39px" OnClick="Button1_Click" Text="View Home Loan" Width="198px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td style="width: 315px">
                    <asp:Button ID="btnVehicle" runat="server" CssClass="button-green" Height="45px" Text="View Vehicle Expenses" Width="230px" OnClick="btnVehicle_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        </div>
    </div>
    
</asp:Content>
