<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="changepwd.aspx.cs" Inherits="BookShopUI.changepwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="CP">
    <h2 class="CP-title">修改密码</h2>
    <div class="old-pwd">
        <span>旧密码:&nbsp;</span>
        <asp:TextBox ID="oldpwd" runat="server" TextMode="Password" Display="Dynamic"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="&nbsp*旧密码不能为空" ControlToValidate="oldpwd" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <br />
    <div class="new-pwd">
        <span>新密码:&nbsp;</span>
        <asp:TextBox ID="newpwd" runat="server" TextMode="Password" Display="Dynamic"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="&nbsp*新密码不能为空" ControlToValidate="newpwd" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <br />
    <div class="CP-bottom">
    <asp:Button ID="changepassword" runat="server" Text="确定修改" 
        onclick="changepassword_Click" Height="40px" Width="150px"/>
    </div>
</div>
</asp:Content>
