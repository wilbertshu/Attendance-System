<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Check_Attendance.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h2 style="text-align:center">View Attendance</h2>
    <br />
    <p style="text-align:center">
        <asp:Label ID="lblUname" runat="server"></asp:Label>
        <asp:Label ID="lblClass" runat="server" Visible="False"></asp:Label>
    </p>
    <br />
    <table class="table">
            <tr style="font-weight:bold">
                <td>Date</td>
                <td>Module</td>
                <td>Attendance</td>
            </tr>
            <%=fetchData()%>
        </table>
    <br />
    <br />
    <br />
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 35%;
        }
        .auto-style6 {
            height: 55px;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
</asp:Content>

