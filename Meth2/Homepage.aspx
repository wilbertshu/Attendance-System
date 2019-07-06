<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <p style="text-align:center">Welcome to Homepage</p>
    <p style="text-align:left">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblName" runat="server" Visible="False"></asp:Label>
    </p>
</asp:Content>


