<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="UserAdmin.aspx.cs" Inherits="BookShopUI.UserAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="UA">
        <h2 class="UA-title">用户列表</h2>
        <div class="UA-table">
            <asp:gridview ID="gvUserInfo1" runat="server" AutoGenerateColumns="False" 
                onrowdeleting="gvUserInfo_RowDeleting" DataKeyNames="ID" 
                    onselectedindexchanged="gvUserInfo_SelectedIndexChanged" 
                onrowdatabound="gvUserInfo1_RowDataBound" >
                <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="UserName" HeaderText="用户名" ReadOnly="true"  />
                    <asp:BoundField DataField="Email" HeaderText="邮箱" ReadOnly="true" />
                    <asp:BoundField DataField="Tel" HeaderText="手机号码" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="封禁" />
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
            </asp:gridview><p />
        </div>
        <div class="UA-bottom">
            <a href="UserDel.aspx">查看用户封禁列表</a><p />
        </div>
        </div>
</asp:Content>
