<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Teacher_Studentfeedback.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h2 style="text-align:center">Teacher Feedback Form</h2>
    <asp:Label ID="lblModule" runat="server" Visible="False"></asp:Label>
    <br />
    <div style="text-align:center;">
    <div style="margin: 0 auto; text-align:left;" class="auto-style1">
    <table class="w-100">
        <tr>
            <td class="auto-style1">Student Name:</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtSearch" runat="server" required="required" Width="188px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style6">
                <asp:button runat="server" text="Search" class="btn btn-outline-primary text-center" ID="btnLogin" OnClick="btnSearch_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:button runat="server" text="Reset" class="btn btn-outline-primary text-center" ID="btnReset" OnClick="btnReset_Click"/>
            </td>
        </tr>
    </table>
    </div>
    </div>
    <asp:panel runat="server" ID="Panel1">
    <hr class="w-50"/>

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
            <td class="auto-style1">E-mail</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtEmail" runat="server" required="required"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">Gender</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtGender" runat="server" required="required"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">Class</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtModule" runat="server" required="required"></asp:TextBox>
            </td>

        </tr>
    </table>
    </div>
    </div>
    <br />
    <hr class="w-50"/>
    <br />

    <div class="text-center">
        <h2>Insert Feedback</h2>
        <br />
        <div style="margin: 0 auto; text-align:left;" class="auto-style1">
        <table>
            <tr>
            <td class="auto-style7">From: </td>
            <td class="auto-style6">
                <asp:TextBox ID="txtUser" runat="server" required="required" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        </table>
        </div>
        <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine" Height="100px" Width="330px"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFeedback" ErrorMessage="No text inputed!" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
        <asp:button runat="server" text="Send" class="btn btn-outline-primary text-center" ID="Button1" OnClick="btnSend_Click"/>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <a href="Homepage.aspx" class="btn btn-outline-danger">Cancel</a>
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>

    </asp:panel>
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




