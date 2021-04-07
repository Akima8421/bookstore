<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="BookAdd.aspx.cs" Inherits="BookShopUI.BookAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="BookAdd1">
    <h1>图书添加</h1>
        <p><span>图书名:&nbsp</span><asp:TextBox ID="BookName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="图书名不能为空" ControlToValidate="BookName"></asp:RequiredFieldValidator></p>
        <p><span>图书号:&nbsp</span><asp:TextBox ID="BookID" runat="server"></asp:TextBox><asp:Label ID="BookAgain" runat="server" Text=""></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="图书号不能为空" ControlToValidate="BookID"></asp:RequiredFieldValidator></p>
        <p><span>作者:&nbsp</span><asp:TextBox ID="BookAuthor" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="作者不能为空" ControlToValidate="BookAuthor"></asp:RequiredFieldValidator></p> 
        <p><span>出版商:&nbsp</span><asp:TextBox ID="BookFrom" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="出版商不能为空" ControlToValidate="BookFrom"></asp:RequiredFieldValidator></p>
        <p><span>价格:&nbsp</span><asp:TextBox ID="BookPrice" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="价格不能为空" ControlToValidate="BookPrice"></asp:RequiredFieldValidator></p>
        <p><span>数量:&nbsp</span><asp:TextBox ID="BookNum" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="数量不能为空" ControlToValidate="BookNum"></asp:RequiredFieldValidator></p>
        <p><span>上传封面:&nbsp</span><asp:FileUpload ID="fupImg" runat="server" style="margin-bottom: 0px" />
            <asp:Label ID="labTips" runat="server"></asp:Label></p>
        <p><span>图书简介:&nbsp</span><asp:TextBox ID="BookThings" runat="server" Height="20px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="简介不能为空" ControlToValidate="BookThings"></asp:RequiredFieldValidator></p>
        </p>
        <p><asp:Button ID="Button1" runat="server" Text="上传图书" onclick="Button1_Click" /></p>
        
        
        <p><asp:Label ID="LabelShow" runat="server"></asp:Label>
            
        </p>
    </div>
</asp:Content>
