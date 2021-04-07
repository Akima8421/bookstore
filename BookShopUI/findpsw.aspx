<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="findpsw.aspx.cs" Inherits="BookShopUI.findpsw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户找回密码</title>
    <link href="./css/findpsw.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 class="findpsw_top">用户找回密码</h1>
    </div>
    <div class="F1">
        <span id="username">用&nbsp;&nbsp;户&nbsp;&nbsp;名:&nbsp;</span>
        <asp:TextBox ID="tbName" runat="server" Height="20px" Width="220px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="&nbsp*用户名不能为空" ControlToValidate="tbName" Display="Dynamic"></asp:RequiredFieldValidator> 
        <br />
        <br />
        <span id="useremail">邮箱地址:&nbsp;</span>
        <asp:TextBox ID="tbEmail" TextMode="Email" runat="server" Height="20px" Width="220px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="&nbsp*邮箱地址不能为空" ControlToValidate="tbEmail" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="&nbsp*邮箱必须包含“.”和“@”符号！" Display="Dynamic" ControlToValidate="tbEmail"></asp:RegularExpressionValidator>
        <br />
        <br />
        <span id="newpwd">新&nbsp;&nbsp;密&nbsp;&nbsp;码:&nbsp;</span>
        <asp:TextBox ID="tbPwd1" TextMode="Password" runat="server" Height="20px" Width="220px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="&nbsp*新密码不能为空" ControlToValidate="tbPwd1" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
    </div>
    <p class="F2">
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" CausesValidation="false">返回登录页面</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="确认修改" onclick="Button1_Click" />
    </p>
    </form>
</body>
</html>
