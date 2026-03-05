<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Videos.aspx.cs" Inherits="MyPages.Videos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />  
    <div style="width:100%; background-color:#5A7F9C; 
        padding:5px 0px 5x 0px; text-align: center; color:White; font-weight:bold;">
        My Videos
    </div>
    <br /><br /> 
    <div>
        <div id="ContentTypeTabs">
            <asp:BulletedList ID="tabItems" runat="server" DisplayMode="LinkButton" 
                onclick="tabItems_Click" >
                <asp:ListItem Text="YouTube Fav Videos" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Orkut Videos"></asp:ListItem>                
            </asp:BulletedList>
        </div>
        <div style="clear:both; border-top:solid 1px #9FB0BE; width:100%;">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="1" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <td>
                        <a href="<%#  "http://www.youtube.com/watch?v="+ Eval("VidName")%>">
                            <img alt="" src="<%# "http://img.youtube.com/vi/" + Eval("VidName") + "/2.jpg" %>" height="100"
                                width="150" style="border: none;" /></a><div style="position: relative; top: -5px;
                                    left: -40px; z-index: 5; display: inline; background: #000000; color: #FFFFFF;">
                                    <%# Eval("Time") %></div>
                    </td>
                    <td>
                        <a href="<%#  "http://www.youtube.com/watch?v="+ Eval("VidName")%>">
                            <%#  Eval("Title")   %>
                        </a>
                        <br />
                        <br />
                        <asp:Label Font-Size="8" ID="Label1" runat="server" Text='<%#  Eval("Desc") %>'></asp:Label>
                    </td>
                </ItemTemplate>                
            </asp:DataList>
        </div>
    </div>
</asp:Content>
