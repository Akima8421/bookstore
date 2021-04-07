<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="BookDetail.aspx.cs" Inherits="BookShopUI.BookDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BDContent2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="BookDetail-main">
        <div class="divPic">
            <asp:Image ID="imgBookPic" runat="server" Width="300px"/><br />
        </div>
        <p class="book-title">《&nbsp;&nbsp;<asp:Label ID="labBookName" runat="server" Text="图书名称" Font-Size="28px"/>&nbsp;&nbsp;》</p><br />
        <div class="divbookinfo">
            书号：<asp:Label ID="labBookID" runat="server" Text="图书ISBN" /><br />
            作者：<asp:Label ID="labBookAuthor" runat="server" Text="图书作者" /><br />
            价格：<asp:Label ID="labBookPrice" runat="server" Text="图书金额" /><br />
            出版社：<asp:Label ID="labBookFrom" runat="server" Text="图书出版社" /><br />
            库存数量：<asp:Label ID="labBookNum" runat="server" Text="图书剩余数量" /><br />
            <asp:Button ID="btnCurt" runat="server" Text="加入购物车" Width="150px" 
                Height="40px" Font-Size="18px" onclick="btnCurt_Click"/>
        </div>
        <div class="divtext">
            <p>简介：</p>
            <asp:Label ID="labThings" runat="server" Text="简介" Width="90%"  Font-Size="18px"></asp:Label>
        </div>
    </div>  
</asp:Content>
