<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="SiteMap.aspx.cs" Inherits="MyPages.SiteMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />  
    <div style="width:100%; background-color:#5A7F9C; 
        padding:5px 0px 5x 0px; text-align: center; color:White; font-weight:bold;">
        Site Map
    </div>
    <br /><br /> 
    <br />
    <div style="padding:0 0 0 20px;">
    <asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1">
    </asp:TreeView>
    <asp:SiteMapDataSource StartingNodeUrl="~/Default.aspx" ID="SiteMapDataSource1" runat="server" />
    <br /><br /><br />
    </div>
</asp:Content>
