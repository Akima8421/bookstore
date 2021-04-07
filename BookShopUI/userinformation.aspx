<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="userinformation.aspx.cs" Inherits="BookShopUI.userinformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="UI">
    <h2 class="UI-title">用户个人信息</h2>
    <div class="UN">
        <span id="username">用户名:</span>
        <asp:Label ID="lbName" runat="server" Text=""></asp:Label>
    </div>
    <div class="UE">
        <p>
        <span>邮箱:</span>
            <asp:Label ID="lbEmail" runat="server" Text=""></asp:Label>
        </p>
    </div>
    <div class="UT">
        <p>
        <span>手机号码:</span>
        <asp:Label ID="lbTel" runat="server" Text=""></asp:Label>
        </p>
    </div>
    <div class="UAD">
        <p>
        <span>地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址:&nbsp;</span>
        <asp:Label ID="lbAddress" runat="server" Text=""></asp:Label>
        </p>
    </div>
    <div class="UI-bottom">
    <asp:Button ID="ChangeInfo" runat="server" Text="前去修改" 
        onclick="ChangeInfo_Click" Height="40px" Width="150px"/>
    </div>
</div>
</asp:Content>
