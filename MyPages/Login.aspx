<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyPages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />  
    <div style="width:100%; background-color:#5A7F9C; 
        padding:5px 0px 5x 0px; text-align: center; color:White; font-weight:bold;">
        Login
    </div>
    <br />
    <table width="100%">
        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <img src="images/secureLogin.JPG" alt="Secure Login" />
            </td>
            <td align="center">
                <br />
                <asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" 
                    BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                    Font-Size="0.9em" ForeColor="#333333" Width="270px" OnLoggedIn="Login1_LoggedIn">
                    <TextBoxStyle Font-Size="0.8em" Width="150px" />
                    <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
                        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
                        ForeColor="White" />
                </asp:Login>
            </td>
        </tr>
    </table>
    <br /><br />
</asp:Content>
