<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BookShopUI.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="./CSS/Login.css" rel="stylesheet" type="text/css" />
 <title>登录</title>
</head>

<body>
    <div>
    <form id="form1" runat="server">
        <div>
            <h1 class="Login_top">欢迎用户登录</h1>
            <br />
            <div class="L1">
                <span id="spanuser">用&nbsp;户&nbsp;名:&nbsp;</span>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Height="30px" Width="220px"></asp:TextBox>
                <ASP:RequiredFieldValidator ID="RequiredFieldValidator1" Runat="Server" ControlToValidate="TextBox1" ErrorMessage="用户名不能为空" Display="Dynamic"></ASP:RequiredFieldValidator><p />
            </div>
            <div class="L2">
                <span id="spanpsd">密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码:&nbsp;</span>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox" Height="30px" Width="220px" TextMode="Password"></asp:TextBox>
                <ASP:RequiredFieldValidator ID="RequiredFieldValidator2" Runat="Server" ControlToValidate="TextBox2" ErrorMessage="密码不能为空" Display="Dynamic"></ASP:RequiredFieldValidator><p />
            </div>
            <div class="L3">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="false">没有账号?注册</asp:LinkButton>
                <asp:CheckBox ID="cbxRemeberUser" runat="server" Text="记住用户名" />
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CausesValidation="false">找回密码</asp:LinkButton>
                <br />
                <br />        
            </div>
            <div class="L4">
                <asp:Button ID="Button1" runat="server" Text="登 录" Width="270px" Height="40px" OnClick="Button1_Click" />
            </div>
            
    <asp:Label ID="admin" runat="server" Text="" Visible= "false"></asp:Label><asp:Label ID="Del"
        runat="server" Text="Label" Visible="false"></asp:Label>
        </div>
    </form>
    </div>
</body>
</html>
