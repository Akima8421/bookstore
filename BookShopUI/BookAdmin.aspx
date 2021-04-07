<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="BookAdmin.aspx.cs" Inherits="BookShopUI.BookAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="BAM">
    <div class="BAM-top">
        <span>请输入：</span><asp:DropDownList ID="ddlSelect" runat="server" 
            style="font-size:16px" >
            <asp:ListItem>书号</asp:ListItem>
            <asp:ListItem>书名</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="serchBooks" runat="server" Width="200px" style="font-size:16px" />
        <asp:Button ID="btnFindBooks" runat="server" Text=" 查 询 "  
            style="font-size:16px" onclick="btnFindBooks_Click" /><p />
    </div>
    <div class="BAM-table">
        <asp:GridView ID="gvBooksList" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" BackColor="White" 
            BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" Width="1150px" 
            onrowdeleting="gvBooksList_RowDeleting" DataKeyNames="BookId" 
            onpageindexchanging="gvBooksList_PageIndexChanging" 
            onrowcancelingedit="gvBooksList_RowCancelingEdit" 
            onrowdatabound="gvBooksList_RowDataBound" onrowediting="gvBooksList_RowEditing" 
            onrowupdating="gvBooksList_RowUpdating">
            <AlternatingRowStyle BackColor="#F7F7F7" />

            <Columns>
                <asp:BoundField DataField="BookID" HeaderText="书号" ReadOnly="True" ItemStyle-Width="20px" ItemStyle-CssClass="booknumber"/>
                <asp:ImageField  HeaderText="封面" DataImageUrlField="BookPic" ReadOnly="True" ItemStyle-CssClass="book"/>
                <asp:BoundField DataField="BookName"  HeaderText="书名"  ItemStyle-CssClass="bookname"/>
                <asp:BoundField DataField="BookAuthor"  HeaderText="作者"  ItemStyle-CssClass="bookauthor"/>
                <asp:BoundField DataField="BookFrom"  HeaderText="出版商" ItemStyle-CssClass="author"/>
                <asp:BoundField DataField="BookNum"  HeaderText="数量"  ItemStyle-CssClass="number"/>
                <asp:BoundField DataField="BookPrice"  HeaderText="价格"  ItemStyle-CssClass="price"/>
                <asp:BoundField DataField="BookThings"  HeaderText="简介"  ItemStyle-CssClass="note"/>
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="True"  ItemStyle-CssClass="delate"/>
            </Columns>

            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C"  />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
    </div>
</div>
</asp:Content>
