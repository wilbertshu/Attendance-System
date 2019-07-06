<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin_List.aspx.cs" Inherits="ViewAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <h2 style="text-align:center">User Registered List</h2>
    <br />
    <div style="text-align:center;">
    <div style="margin: 0 auto; text-align:left;" class="auto-style1">
    <table class="w-100">
        <tr>
            <td class="auto-style7">User Type:</td>
            <td class="auto-style8">
                <asp:DropDownList ID="ddlUser" runat="server">
                    <asp:ListItem>Guest</asp:ListItem>
                    <asp:ListItem>Student</asp:ListItem>
                    <asp:ListItem>Teacher</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style6"><asp:button runat="server" text="Search" class="btn btn-outline-primary text-center" ID="btnLogin" OnClick="btnSearch_Click"/>
            </td>
        </tr>
    </table>
    </div>
    </div>

    <asp:Panel ID="panelGuest" runat="server">
    <hr class="w-50"/>
    <br />
        <table class="table">
            <tr style="font-weight:bold">
                <td>#</td>
                <td>Full Name</td>
                <td>Username</td>
                <td>Email</td>
                <td>Gender</td>
                <td>Country</td>
                <td>User Type</td>
            </tr>
            <%=fetchData()%>
        </table>
    <span>
    <br />
    </span>
    </asp:Panel>

    <asp:Panel ID="panelStudent" runat="server">
    <hr style="width:50%"/>
    <br />
        <table class="table">
            <tr style="font-weight:bold">
                <td>#</td>
                <td>Full Name</td>
                <td>Username</td>
                <td>Email</td>
                <td>Gender</td>
                <td>Class</td>
            </tr>
            <%=fetchData2()%>
        </table>
    <span>
    <br />
    </span>
    </asp:Panel>

    <asp:Panel ID="panelTeacher" runat="server">
    <hr style="width:50%"/>
    <br />
        <table class="table">
            <tr style="font-weight:bold">
                <td>#</td>
                <td>Full Name</td>
                <td>Username</td>
                <td>Email</td>
                <td>Gender</td>
                <td>Module</td>
            </tr>
            <%=fetchData3()%>
        </table>
    <span>
    <br />
    </span>
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 35%;
        }
        .auto-style7 {
        width: 39%;
    }
    </style>
</asp:Content>



