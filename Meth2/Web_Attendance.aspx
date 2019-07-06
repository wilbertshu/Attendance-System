<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Web_Attendance.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h2 style="text-align:center">Web Attendance</h2>
    <br />
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblModule" runat="server" Visible="False"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblClass" runat="server" Visible="False"></asp:Label>
    </div>
    <br />

    <asp:panel runat="server" id="panelSearch">
    <div style="text-align:center;">
    <div style="margin: 0 auto; text-align:left;" class="auto-style1">
    <table style="width:100%">
        <tr>
            <td class="auto-style1">Class</td>
            <td class="auto-style6">
            <asp:DropDownList ID="ddlClass" runat="server" required="required" DataSourceID="SqlDataSource2" DataTextField="class" DataValueField="class">
            </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style6">
                <asp:button runat="server" text="Confirm" class="btn btn-outline-success text-center" ID="btnConfirm" OnClick="btnConfirm_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <a href="Homepage.aspx" class="btn btn-outline-danger">Cancel</a>
            </td>
        </tr>

    </table>
    </div>
    </div>
    <br />
    <hr style="width:50%"/>
    <br />
    </asp:panel>

    <asp:panel runat="server" id="panelAttendance">
    <div style="text-align:center;">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <div style="margin: 0 auto; text-align:center;" class="auto-style1">
        <asp:GridView runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" Width="500px" ID="GridView1">
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Mark Attendance">
                    <ItemTemplate>
                        &nbsp;&nbsp;
                        <asp:RadioButton ID="rbtn1" runat="server" Checked="True" GroupName="YesNo" Height="20px" Text="Present" />
                        &nbsp;
                        <asp:RadioButton ID="rbtn2" runat="server" GroupName="YesNo" Height="20px" Text="Absent" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:button runat="server" text="Save" class="btn btn-outline-success text-center" ID="btnSave" OnClick="btnSave_Click"/>
        &nbsp;&nbsp;&nbsp;
        <a href="Web_Attendance.aspx" class="btn btn-outline-danger">Cancel</a>
        <br />
        <br />
        <br />
    </div>
    </div>
    </asp:panel>
    <asp:sqldatasource runat="server" ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [class] FROM [Class]"></asp:sqldatasource>
    <asp:sqldatasource runat="server" ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [name], [email] FROM [Student] WHERE ([class] = @class)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlClass" Name="class" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:sqldatasource>
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

