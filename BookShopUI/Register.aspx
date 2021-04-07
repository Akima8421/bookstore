<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BookShopUI.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>注册页面</title>
    <link href="./css/Register.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
           <h1 class="Register_top">欢迎注册叮叮书店</h1><br />
           <div class="R1">
                <span id="username" >用&nbsp;&nbsp;户&nbsp;&nbsp;名:&nbsp;</span>
                <asp:TextBox runat="server" ID="tbName" Height="30px" Width="170px" CssClass="Tb"></asp:TextBox>
                <asp:Button ID="btnCheck" runat="server" Text="检查用户名是否存在" onclick="Button1_Click" CausesValidation="false" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="&nbsp*用户名不能为空" ControlToValidate="tbName" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:Label ID="Label1" runat="server" EnableTheming="True"></asp:Label>
               <br />
               <br />
           </div>
           <div class="R2">
                <span id="userpwd">密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码:&nbsp;</span>
                <asp:TextBox runat="server" ID="tbPwd1" TextMode="Password" Height="30px" Width="310px" CssClass="Tb"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="&nbsp*密码不能为空" ControlToValidate="tbPwd1" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
           </div>
           <div class="R3">
               <span id="ruserpwd">重复密码:&nbsp;</span>
               <asp:TextBox runat="server" ID="tbPwd2" TextMode="Password" Height="30px" Width="310px" CssClass="Tb" ></asp:TextBox>
               <asp:requiredfieldvalidator id="requiredfieldvalidator5" runat="server" Errormessage="&nbsp*重复密码不能为空" Controltovalidate="tbpwd2" Display="Dynamic"></asp:requiredfieldvalidator>                       
               <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="&nbsp*两次密码不一致" ControlToValidate="tbPwd2" ControlToCompare="tbPwd1" Display="Dynamic"></asp:CompareValidator> 
               <br />
               <br />
           </div>
           <div class="R4">
               <span id="phonenumber">手机号码:&nbsp;</span>
               <asp:TextBox ID="tbPhone" TextMode="Phone" Height="30px" Width="310px" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="&nbsp*手机号码不能为空" ControlToValidate="tbPhone" Display="Dynamic"></asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="&nbsp*手机为11位数字，且首位必须是“1”！" ValidationExpression="1[0-9]{10}" ControlToValidate="tbPhone" Display="Dynamic"></asp:RegularExpressionValidator>
               <br />
               <br />
           </div>
           <div class="R5">
                <span id="email">电子邮箱:&nbsp;</span>
                <asp:TextBox ID="tbEmail" TextMode="Email" Height="30px" Width="310px" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                    ErrorMessage="&nbsp*邮箱地址不能为空" ControlToValidate="tbEmail" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ErrorMessage="&nbsp*邮箱必须包含“.”和“@”符号！"  ControlToValidate="tbEmail"></asp:RegularExpressionValidator>
                <br />
           </div>
         <table class="Register_bottom">
            <tr>
                <td>
                    <asp:CheckBox ID="Agree" runat="server" Checked="true" />
                    <span>同意</span>  <asp:LinkButton runat="server" Text="服务条款" ID="ckItem"></asp:LinkButton>
                    <asp:LinkButton ID="linkToLogin" runat="server" Text="已有账号?登录" 
                                            onclick="linkToLogin_Click" CausesValidation="false"></asp:LinkButton>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnRegister" runat="server" CssClass="transButton" Height="49px" Text="注    册" Width="390px" OnClick="btnRegister_Click" />
    </form>
    </body>
</html>