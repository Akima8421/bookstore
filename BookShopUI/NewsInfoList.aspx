<%@ Page Title="" Language="C#" MasterPageFile="~/BookShop.Master" AutoEventWireup="true" CodeBehind="NewsInfoList.aspx.cs" Inherits="BookShopUI.NewsInfoList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--查询-->
    新闻标题：<asp:TextBox ID="tbNewsTitle" runat="server" Width="200px" style="font-size:16px" />&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlNewsType" runat="server" style="font-size:16px" />&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFindNews" runat="server" Text=" 查 询 "  style="font-size:16px"
        onclick="btnFindNews_Click" /><p />
    <!--数据绑定-->
    <asp:GridView ID="gvNewsList" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" EmptyDataText="查询无结果，请重设查询条件！">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="rownum" HeaderText="序号" />
            <asp:HyperLinkField HeaderText="标题" DataTextField="Title" DataNavigateUrlFields="NewsId" DataNavigateUrlFormatString="NewsInfoDetail.aspx?NewsId={0}" />
            <asp:BoundField DataField="typename" HeaderText="类型" />
            <asp:BoundField DataField="cdate" DataFormatString="{0:d}" HeaderText="发布日期" />
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

</asp:Content>
