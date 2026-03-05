<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MyPages.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <br /><br />  
    <div style="width:100%; background-color:#5A7F9C; 
        padding:5px 0px 5x 0px; text-align: center; color:White; font-weight:bold;">
        Contact Us
    </div>
    <br /><br />  
    <div style="float:right; width:75%;">
    <br />
    <table width="100%">
        <tr>
            <td>
            
                <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
                
            </td>
            <td>
            
                <asp:TextBox ID="txtName" runat="server" Width="300px" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*" ControlToValidate="txtName" ValidationGroup="AddComment"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td>
            
                <asp:Label ID="Label2" runat="server" Text="Comment:"></asp:Label>
            
            </td>
            <td>
            
                <asp:TextBox ID="txtComment" runat="server" Height="120px" TextMode="MultiLine" 
                    Width="300px" MaxLength="250"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="*" ControlToValidate="txtComment" ValidationGroup="AddComment"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td>
            
                &nbsp;</td>
            <td>
            
                <asp:Button ID="btnAddComment" runat="server" Text="Submit" 
                    ValidationGroup="AddComment" onclick="btnAddComment_Click" />
            
            </td>
        </tr>
         <tr>
            <td>
            
                &nbsp;</td>
            <td>
            
                &nbsp;</td>
        </tr>
         <tr>
            <td colspan="2">
                <br />
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Recent Comments"></asp:Label>
            
            </td>
        </tr>
         <tr>
            <td colspan="2">
                <asp:DataList ID="DataList1" runat="server" Width="100%">
                    <ItemTemplate>
                        <td>
                            by&nbsp;<asp:Label ID="Label5" Font-Size="14" Font-Bold="true" ForeColor="#336699" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            <br /><asp:Label ID="Label6" Font-Size="11" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
                        </td>
                        <td style="width:35%">
                            <asp:Label ID="Label4" ForeColor="Gray"  Font-Size="11" runat="server" Text='<%# Eval("AddedOn") %>'></asp:Label>
                        </td>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <td colspan="2">
                            <hr style="color:Gray; width:100%; height:1px;" />
                        </td>                        
                    </SeparatorTemplate>
                </asp:DataList>
             </td>
        </tr>
    </table>
    </div>
    <div style="width:24%; height:300px; background-image:url('pics/guestbook.jpg'); background-repeat:no-repeat;">
        
    </div>
</asp:Content>
