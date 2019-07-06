<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="My_Profile.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h2 style="text-align:center">My Profile</h2>
    <asp:Label ID="lblID" runat="server" style="text-align:center" Visible="False"></asp:Label>
    <br />
    <div style="text-align:center;">
    <div style="margin: 0 auto; text-align:left;" class="auto-style1">
    <table style="width:100%">
        <tr>
            <td class="auto-style1">Full Name</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtName" runat="server" required="required" ReadOnly="True"></asp:TextBox>
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
                <asp:TextBox ID="txtEmail" runat="server" required="required" ReadOnly="True"></asp:TextBox>
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
                <asp:TextBox ID="txtType" runat="server" required="required" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">Country</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtCountry" runat="server" required="required" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>

        <asp:Panel ID="panelClass" runat="server" Visible="False">
        <tr>
            <td class="auto-style1">Class</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtClass" runat="server" required="required" Wrap="True" Visible="True" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        </asp:Panel>

        <asp:Panel ID="panelModule" runat="server" Visible="False">
            <tr>
            <td class="auto-style1">Module</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtModule" runat="server" required="required" Visible="True" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        </asp:Panel>

    </table>
    </div>
    </div>

    <asp:Panel ID="panelChange" runat="server">
    <hr style="width:50%"/>

    <div style="text-align:center;">
    <div style="margin: 0 auto; text-align:left;" class="auto-style1">
    <table style="width:100%">
        <tr>
            <td class="auto-style1">New Password</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtPass" runat="server" required="required" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td class="auto-style1">Confirm Password</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtConfirm" runat="server" required="required" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
    </table>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToCompare="txtPass" ControlToValidate="txtConfirm" ForeColor="Red">Mis-Match Password!</asp:CompareValidator>
    </div>
    </div>
    
    <hr style="width:50%"/>
    <br />
    <div style="text-align:center;">
    <div style="margin: 0 auto; text-align:left;" class="auto-style1">
    <table style="width:100%">
        <tr>
            <td class="auto-style1">
            </td>
            <td class="auto-style2">
                <asp:button runat="server" text="Save" class="btn btn-outline-primary text-center" ID="btnChange" OnClick="btnChange_Click"/>
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

