<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="MyPages.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
    <table style="width:75%;">
        <tr>
            <td>
            
                From :</td>
            <td>
            
                <asp:TextBox ID="txtFrom" runat="server" Width="339px"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
            <td>
            
                To :</td>
            <td>
            
                <asp:TextBox ID="txtTo" runat="server" Width="339px"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
            <td>
            
                Cc:</td>
            <td>
            
                <asp:TextBox ID="txtCC" runat="server" Width="339px"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
            <td>
            
                Bcc :</td>
            <td>
            
                <asp:TextBox ID="txtBCC" runat="server" Width="339px"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
            <td>
            
                Subject:</td>
            <td>
            
                <asp:TextBox ID="txtSubject" runat="server" Width="339px"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
            <td>
            
                Body:</td>
            <td>
            
                <asp:TextBox ID="txtBody" runat="server" Height="240px" TextMode="MultiLine" 
                    Width="479px"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
            <td>
            
                &nbsp;</td>
            <td>
            
                <asp:Button ID="btnSend" runat="server" onclick="btnSend_Click" Text="Send" 
                    Width="69px" />
            
            </td>
        </tr>
    </table>
</asp:Content>
