<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <h2 style="text-align:center">Login Page</h2>
    <br />
    <div style="text-align:center;">
    <div style="margin: 0 auto; text-align:left;" class="auto-style1">
    <table style="width:100%">
        <tr>
            <td class="auto-style1">Admin Account:</td>
            <td class="auto-style6">
                ID: Admin, Pass: admin123
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Username</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtID" runat="server" required="required"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Password</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" required="required"></asp:TextBox>
                <br />
                <asp:Label ID="lblError" runat="server" Text="Wrong Password!" Visible="False" ForeColor="#FF3300"></asp:Label>
            </td>
        </tr>

        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style2"></td>
        </tr>

        <tr>
            <td class="auto-style1">
            </td>
            <td class="auto-style2">
                <asp:button runat="server" text="Login" class="btn btn-outline-primary text-center" ID="btnLogin" OnClick="btnLogin_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <a href="Homepage.aspx" class="btn btn-outline-danger">Cancel</a>
                <br />
                <br />
                <a href="Reset_Password.aspx" class="btn btn-outline-danger">Forgot Password?</a>
            </td>
        </tr>
    </table>
    </div>
    </div>
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


