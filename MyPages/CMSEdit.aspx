<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" 
CodeBehind="CMSEdit.aspx.cs" Inherits="MyPages.CMSEdit" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /> 
    <div style="width:100%; background-color:#5A7F9C; 
        padding:5px 0px 5x 0px; text-align: center; color:White; font-weight:bold;">
        CMS Edit
    </div>
    <br />
    <div style="padding:0 0 0 10px;">
        <br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
        
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" 
                        ValidationGroup="save" />
                    <br /><br />
                </td>
                <td>
                    <asp:LinkButton ID="lnkList" PostBackUrl="~/CMSList.aspx" runat="server">Goto Listing</asp:LinkButton>
                    <br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    
                    Page Name:
                    <br />
                    <asp:TextBox ID="txtPageName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtPageName" ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>
                </td>
                <td width="70%">
                    <br />
                    Is SubContent:
                    <asp:CheckBox ID="chkIsSubContent" runat="server" />
                   
                </td>
            </tr>
            <tr>
                <td colspan="2">
                     <br />
                    Page Content:
                    <br />
                    <asp:TextBox Id="txtPageContent" RunAt="server" Rows="15" Columns="80" TextMode="MultiLine" />
                </td>
            </tr>
        </table>
        
        
        
        <br /><br /><br /><br />
    </div>
</asp:Content>
