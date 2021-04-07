<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="changeinformation.aspx.cs" Inherits="BookShopUI.changeinformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="CI">
    <h2 class="CI-title">修改个人信息</h2>
    <div class="CIUN">
        <span id="username">用&nbsp;&nbsp;户&nbsp;&nbsp;名:&nbsp;</span>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
    </div>
    <div class="CIE">
        <p>
        <span>邮&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;箱:&nbsp;</span>
            <asp:TextBox ID="tbEmail" runat="server" Text=""></asp:TextBox>
        </p>
    </div>
    <div class="CIT">
        <p>
        <span>手机号码:&nbsp;</span>
        <asp:TextBox ID="tbTel" runat="server" Text=""></asp:TextBox>
        </p>
    </div>
    <div class="CAD">
        <p>
        <span>地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址:&nbsp;</span>
        <asp:TextBox ID="tbAddress" runat="server" Text=""></asp:TextBox>
        </p>
    </div>
    <div class="CI-bottom">
    <asp:Button ID="xx" runat="server" Text="确定修改" 
        onclick="xx_Click" Height="40px" Width="150px"/>
    </div>
    <p>
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </p>
</div>
</asp:Content>
