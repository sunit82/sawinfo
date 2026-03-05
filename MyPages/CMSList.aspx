<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
 CodeBehind="CMSList.aspx.cs" Inherits="MyPages.CMSList" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
        function ConfirmDelete() {
           return confirm("Are you sure, you want to delete the record");
        }
    </script>
    <br /><br />  
<div style="width:100%; background-color:#5A7F9C; 
    padding:5px 0px 5x 0px; text-align: center; color:White; font-weight:bold;">
    CMS List
</div>
<br />
<div style="padding:0 10px 0 10px;">
    <br />
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
    <table>
        <tr>
            <td>
                <asp:Button ID="btnInstall" runat="server" Text="Install & start" 
                    onclick="btnInstall_Click"  /><br />        
            </td>
            <td>
                <asp:Button ID="btnUninstall" runat="server" Text="Uninstall" 
                    onclick="btnUninstall_Click"  />
            &nbsp;<asp:Button ID="btnTestMail" runat="server" onclick="btnTestMail_Click" 
                    Text="Test Mail" />
            &nbsp;<asp:Label ID="lblServiceStatus" runat="server" Text=""></asp:Label></td>
        </tr>
    </table> 
    <table border=0 width="100%">
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkAddNew" OnClick="lnkAddNew_Click" runat="server">Add New</asp:LinkButton>
                            
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkAdminConsole" runat="server" onclick="lnkAdminConsole_Click">Admin Console</asp:LinkButton>
                        </td>
                        <td width="70%" align="right">
                            <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogout_Click">Logout</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                Search by Page Name :
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" 
                    onclick="btnSearch_Click" />
                &nbsp;<br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:GridView ID="gvPageList" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None"  
                    onrowcommand="gvPageList_RowCommand" DataKeyNames="CMSID" Width="100%">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField HeaderText="PageName" DataField="PageName" />
                        <asp:BoundField HeaderText="ModifiedOn" DataField="ModifiedOn" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ForeColor="Blue" ID="lnkEdit" CommandArgument='<%# Eval("CMSId") %>' CommandName="cmsEdit" runat="server">Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ForeColor="Blue" ID="lnkDelete" OnClientClick="return ConfirmDelete();" CommandArgument='<%# Eval("CMSId") %>' CommandName="cmsDelete" runat="server">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <br />
            </td>
        </tr>
    </table>
    <br /><br />
</div>

</asp:Content>
