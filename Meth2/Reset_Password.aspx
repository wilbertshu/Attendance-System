<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Reset_Password.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <h2 style="text-align:center">Reset Password</h2>
    <br />
    <div style="text-align:center;">
    <div style="margin: 0 auto; text-align:left;" class="auto-style1">
    <table style="width:100%">
        <tr>
            <td class="auto-style1">E-mail</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtEmail" runat="server" required="required"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">New Password</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtPass" runat="server" required="required" TextMode="Password"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style2">
            </td>
        </tr>

        <tr>
            <td class="auto-style1">
            </td>
            <td class="auto-style2">
                <asp:button runat="server" text="Reset" class="btn btn-outline-primary text-center" ID="btnReset" OnClick="btnReset_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <a href="Homepage.aspx" class="btn btn-outline-danger">Cancel</a>
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


