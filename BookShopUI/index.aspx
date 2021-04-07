<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BookShopUI.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="index1">
    <span>请输入：</span><asp:DropDownList ID="ddlSelect" runat="server" 
        style="font-size:16px" >
        <asp:ListItem>书号</asp:ListItem>
        <asp:ListItem>书名</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="serchBooks" runat="server"></asp:TextBox>
    <asp:Button ID="serchButton" runat="server" Text="搜索" onclick="serchButton_Click" />
    <p></p>
    <asp:GridView ID="gvBookList" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        onrowcommand="gvBookList_RowCommand">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="BookID" HeaderText="书号" ItemStyle-CssClass="i-BookID"/>
            <asp:ImageField DataImageUrlField="BookPic" HeaderText="图书封面" ItemStyle-CssClass="i-BookPic"/>
            <asp:HyperLinkField HeaderText="书名" DataTextField="BookName" 
                DataNavigateUrlFields="BookID" 
                DataNavigateUrlFormatString="BookDetail.aspx?BookID={0}" ItemStyle-CssClass="i-BookName"/>
            <asp:BoundField DataField="BookPrice" HeaderText="价格" ItemStyle-CssClass="i-Price"/>
            <asp:BoundField DataField="BookNum" HeaderText="库存数量" ItemStyle-CssClass="i-BookNum"/>
            <asp:ButtonField Text="加入购物车" CommandName="Click" ItemStyle-CssClass="i-BookAdd"/>
        </Columns>

        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
</div>
</asp:Content>
