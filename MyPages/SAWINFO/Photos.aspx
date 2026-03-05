<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Photos.aspx.cs" Inherits="MyPages.Photos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <br /><br />  
    <div style="width:100%; background-color:#5A7F9C; 
        padding:5px 0px 5x 0px; text-align: center; color:White; font-weight:bold;">
        My Photo Albums
    </div>
    <br /><br /> 
    <div style="text-align:center">
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
        <ItemTemplate>
            <td>
                <div class="container">
                    <b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4">
                    </b></b>
                    <center>
                        <table style="width: 194px; " cellpadding="0" cellspacing="0" >
                            <tr>
                                <td align="center" style="height: 194px; background: url(http://picasaweb.google.com/f/img/transparent_album_background.gif) no-repeat left;">
                                    <a href='<%#Eval("AlbumLink") %>'>
                                        <img alt="x" src='<%# Eval("ImgLink") %>' width="160" height="160" border="0" style="margin: 18px 0 0 0;"></a>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; font-family: arial,sans-serif; font-size: 11px;">
                                    <a href='<%#Eval("AlbumLink") %>' style="font-weight: bold; text-decoration: none;">
                                        <%# Eval("ImgTitle")%></a>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1">
                    </b></b>
            </td>
        </ItemTemplate>
    </asp:DataList>
    </div>    
    <br />
</asp:Content>
