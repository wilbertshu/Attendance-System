<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View_Feedback.aspx.cs" Inherits="ViewAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <h2 style="text-align:center">Feedback List</h2>
    <br />
    <br />
        <table class="table">
            <tr style="font-weight:bold">
                <td>#</td>
                <td>From user</td>
                <td>To user</td>
                <td>Feedback</td>
            </tr>
            <%=fetchData()%>
        </table>
    <span>
    <br />
    </span>
</asp:Content>



