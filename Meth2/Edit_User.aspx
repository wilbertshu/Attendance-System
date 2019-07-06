<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Edit_User.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br />
    <h2 style="text-align:center">Edit Registered User</h2>
    <br />
    
    <div style="text-align:center;">
    <div style="margin: 0 auto; text-align:left;" class="auto-style1">
    <table class="w-100">
        <tr>
            <td class="auto-style7">User's Name:</td>
            <td class="auto-style8">
                <asp:TextBox ID="txtSearch" runat="server" required="required" Width="188px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style6">
                <asp:button runat="server" text="Search" class="btn btn-outline-primary text-center" ID="btnSearch" OnClick="btnSearch_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:button runat="server" text="Reset" class="btn btn-outline-primary text-center" ID="btnReset" OnClick="btnReset_Click"/>
            </td>
        </tr>
    </table>
    </div>
    </div>
    <hr style="width:50%"/>
    
    <asp:Panel ID="panelData" runat="server">
    <div style="text-align:center;">
    <div style="margin: 0 auto; text-align:left;" class="auto-style1">
    <table style="width:100%">
        <tr>
            <td class="auto-style1">Name</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtName" runat="server" required="required"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">Username</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtUsername" runat="server" required="required" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">E-mail</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtMail" runat="server" required="required" TextMode="SingleLine"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">Gender</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtGender" runat="server" required="required" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">User Type</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtUser" runat="server" required="required" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">Country</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtCountry" runat="server" required="required" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>

        <asp:Panel ID="panelModule" runat="server">
        <tr>
            <td class="auto-style1">Module</td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddlModule" runat="server" required="required">
                    <asp:ListItem>Bahasa Indonesia</asp:ListItem>
                    <asp:ListItem>English</asp:ListItem>
                    <asp:ListItem>Mathematics</asp:ListItem>
                    <asp:ListItem>Physics</asp:ListItem>
                    <asp:ListItem>Biology</asp:ListItem>
                    <asp:ListItem>Geography</asp:ListItem>
                    <asp:ListItem>Sociology</asp:ListItem>
                    <asp:ListItem>Economic</asp:ListItem>
                    <asp:ListItem>History</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        </asp:Panel>

        <asp:Panel ID="panelClass" runat="server">
        <tr>
            <td class="auto-style1">Class</td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddlClass" runat="server" required="required" DataSourceID="SqlDataSource1" DataTextField="class" DataValueField="class">

                </asp:DropDownList>
            </td>
        </tr>
        </asp:Panel>

        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style6"></td>
        </tr>

        <tr>
            <td class="auto-style1">
            </td>
            <td class="auto-style6">
                <asp:button runat="server" text="Edit" class="btn btn-outline-success text-center" ID="btnEdit" OnClick="btnEdit_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:button runat="server" text="Delete" class="btn btn-outline-danger text-center" ID="btnDelete" OnClick="btnDelete_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <a href="Homepage.aspx" class="btn btn-outline-danger">Cancel</a>
            </td>
        </tr>
    </table>
    </div>
    </div>
    </asp:Panel>
        <br />
        <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [class] FROM [Class]"></asp:SqlDataSource>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 35%;
        }
        .auto-style6 {
            height: 55px;
        }
    .auto-style7 {
        width: 39%;
    }
    </style>
</asp:Content>

