<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Content.aspx.cs" Inherits="MyPages.Content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div style="width:100%; background-color:#5A7F9C; 
        padding:5px 0px 5x 0px; text-align: center; color:White; font-weight:bold;">
        SAWINFO Content
    </div>
    <br /><br /> 
    <table width="100%">
        <tr>
            <td style="width: 30%;">
                <center>
                    <img src="http://www.sawinfotech.com/pics/superman.gif" alt="" />
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

                <div id="divContentPageList" style="width: 95%; border: solid 1px Gray; height: 300px;
                    overflow-y: auto; padding: 5px 5px 5px 5px; color: Gray; margin: 0 5px 0 5px;
                    font-family:Arial; font-size:medium;">
                </div>
            </td>
            <td>
                <br />
                <div style="text-align: justify; padding: 0 10px 0 10px; font-family:Arial; font-size:smaller;">
                    <%= PageData %>
                    <br />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
