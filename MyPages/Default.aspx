<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="MyPages.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div style="width:100%; background-color:#5A7F9C; 
        padding:5px 0px 5x 0px; text-align: center; color:White; font-weight:bold;">
        Home
    </div>
    <br /><br /> 
    
    <table width="100%" border=0>
        <tr>
            <td style="width: 30%;">
                <center>
                    <img src="images/sman1.jpg" 
                    width="200px" style="border:solid 1px gray;" alt="" />
                    <%-- <img src="https://lh6.googleusercontent.com/_Vx-A-qGl3mQ/TXpxpxJkc3I/AAAAAAAAB4k/ULhlOwSu650/s512/sman1.JPG" 
                    width="200px" style="border:solid 1px gray;" alt="" /> --%>
                </center>
                <br />

                <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>

                <script language="javascript" type="text/ecmascript">
                    $(document).ready(function() {
                    $('#divContentPageList').html("<center><img src='images/iconLoading.gif' alt='' /></center>");
                        $.ajax({
                            type: "POST",
                            url: "sawCMS.asmx/GetContentPageList",
                            data: "",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: SuccessCallBack,
                            error: FailureCallBack
                        });
                    });
                    function SuccessCallBack(data) {
                        var str = data.d;
                        //alert(data.d);
                        $('#divContentPageList').html(data.d);
                    }

                    function FailureCallBack(data) {
                        alert(data.status + " : " + data.statusText);
                    }
                </script>

                <div id="divContentPageList" style="width: 90%; border: solid 1px Gray; height: 300px;
                    overflow-y: auto; padding: 5px 5px 5px 5px; color: Gray; margin: 0 5px 0 5px;
                    font-family:Arial; font-size:medium;">
                </div>
            </td>
            <td>
                <br />
                <div style="text-align: justify; padding: 0 10px 0 10px; font-family:Arial; font-size:small;">
                    <%= PageData %>
                    <br />
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td colspan="1" style="padding:0 0px 0 10px; font-family:Arial; font-size:small;">
            <div style="float:left; width:33%; text-align:justify; padding:0 4px 0 0;">
                <center>
                <object width="100%" height="50px">
                <param name="movie" value="sawmanager.swf">
                <embed src="sawmanager.swf" width="190" height="50">
                </embed>
                </object>
                </center> <br />
                ... is a personal manager application to keep track
                of events, b'days, tasks, manage contacts and shares trading porfolio,...etc. 
                <br />
                <a href="http://www.sawinfotech.com/SAWManager" style="color:gray; text-decoration:none;">more>></a>            
            </div>
            <div style="float:left; width:33%; padding:0 5px 0 5px;
                border-right:solid 1px Gray;
                text-align:justify;
                border-left:solid 1px Gray;">
                <center>
                <object width="100%" height="50px">
                <param name="movie" value="SAWWiki.swf">
                <embed src="SAWWiki.swf" width="190" height="50">
                </embed>
                </object>
                </center><br />
               ... is a wiki site to post and share information on virtually any topic and
                create your own collaborated knowledgebase online.
                <br />
                <a href="http://www.sawinfotech.com/SAWWiki" style="color:gray; text-decoration:none;">more>></a>
            </div>
            <div style="float:left; width:30%;padding:0 5px 0 5px; text-align:justify;">
                <center>
                <object width="100%" height="50px">
                <param name="movie" value="Waingankars.swf">
                <embed src="Waingankars.swf" width="190" height="50">
                </embed>
                </object>
                </center><br />
                ... is a family website for our family members to share photo albums, track 
                family events, B'days, chat and other stuffs.
                <br />
                <a href="http://waingankars.sawinfotech.com" style="color:gray; text-decoration:none;">more>></a>            
            </div>
            </td>
        </tr>
    </table>
    <br /><br />
</asp:Content>
