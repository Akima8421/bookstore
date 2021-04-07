<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="UserDel.aspx.cs" Inherits="BookShopUI.UserDel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="UD">
        <h2 class="UD-title">用户列表</h2>
        <div class="UD-table">
            <asp:gridview ID="gvUserInfo" runat="server" AutoGenerateColumns="False" 
                onrowdeleting="gvUserInfo_RowDeleting" DataKeyNames="ID" 
                    onselectedindexchanged="gvUserInfo_SelectedIndexChanged" 
                    onrowdatabound="gvUserInfo_RowDataBound" >
                <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="UserName" HeaderText="用户名" ReadOnly="true" />
    <%--                <asp:TemplateField  HeaderText="性别">--%>
    <%--                    <EditItemTemplate>
                            <asp:Label ID="labSex" runat="server" Text='<%# Eval("UserSex") %>' Visible="false"></asp:Label>
                            <asp:DropDownList ID="ddlSex" runat="server">
                                <asp:ListItem Value="男">男</asp:ListItem>
                                <asp:ListItem Value="女">女</asp:ListItem>
                            </asp:DropDownList>--%>
    <%--                    </EditItemTemplate>--%>
    <%--                    <ItemTemplate>
                            <asp:Label ID="labSex" runat="server" Text='<%# Eval("UserSex") %>'></asp:Label>    
                        </ItemTemplate>--%>
    <%--                </asp:TemplateField>--%>
                    <asp:BoundField DataField="Email" HeaderText="邮箱" ReadOnly="true" />
                    <asp:BoundField DataField="Tel" HeaderText="手机号码" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="解封" />
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
        <div class="UD-bottom">
           <a href="UserAdmin.aspx">查看用户列表</a><p />
        </div>
        </div>
</asp:Content>
