<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Add_Class.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <h2 style="text-align:center">Add Class</h2>
    <br />
    
    <div style="text-align:center;">
    <div style="margin: 0 auto; text-align:left;" class="auto-style1">
    <table class="w-100">
        <tr>
            <td class="auto-style7">Class Name</td>
            <td class="auto-style8">
                <asp:TextBox ID="txtClass" runat="server" required="required" Width="188px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style6">
                <asp:button runat="server" text="Add" class="btn btn-outline-primary text-center" ID="btnAdd" OnClick="btnAdd_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:button runat="server" text="Reset" class="btn btn-outline-primary text-center" ID="btnReset" OnClick="btnReset_Click"/>
            </td>
        </tr>
    </table>
    </div>
    </div>
    <hr style="width:50%"/>
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


