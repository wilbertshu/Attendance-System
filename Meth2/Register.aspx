<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h2 style="text-align:center">Registration Page</h2>
    <br />
    <div style="text-align:center;">
    <div style="margin: 0 auto; text-align:left;" class="auto-style1">
    <table class="w-100">
        <tr>
            <td class="auto-style1">Full Name</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtName" runat="server" required="required"></asp:TextBox>
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
            </td>
        </tr>

        <tr>
            <td class="auto-style1">Email</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtEmail" TextMode="Email" required="required" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">Gender</td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddlGender" runat="server" required="required">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">Country</td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddlCountry" runat="server" required="required">
                    <asp:ListItem>Indonesia</asp:ListItem>
                    <asp:ListItem>Singapore</asp:ListItem>
                    <asp:ListItem>Malaysia</asp:ListItem>
                    <asp:ListItem>Thailand</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">Account Type</td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddlType" runat="server" required="required">
                    <asp:ListItem>Student</asp:ListItem>
                    <asp:ListItem>Teacher</asp:ListItem>
                </asp:DropDownList>
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
                <asp:button runat="server" text="Register" class="btn btn-outline-success text-center" ID="btnRegister" OnClick="btnRegister_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <a href="Homepage.aspx" class="btn btn-outline-danger">Cancel
                </a>
            </td>
        </tr>

        <tr>
             <td style="width: 187px; height: 44px;">
                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
              </td>
              <td style="height: 44px"></td>
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
    </style>
</asp:Content>

