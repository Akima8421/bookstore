<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Curt.aspx.cs" Inherits="BookShopUI.Curt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <asp:GridView ID="gvCurtList" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" BackColor="White"  EmptyDataText="购物车为空"
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            onrowdeleting="gvNewsList_RowDeleting" 
            onrowediting="gvCurtList_RowEditing" 
            onrowcancelingedit="gvCurtList_RowCancelingEdit" 
            onrowupdating="gvCurtList_RowUpdating"
            >
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cbCheck" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:BoundField DataField="BookID" HeaderText="书号"  ReadOnly="true" ItemStyle-CssClass="C-BookID"/>
            <asp:ImageField DataImageUrlField="BookPic" HeaderText="图书封面" ReadOnly="true" ItemStyle-CssClass="C-BookPIC"/>
            <asp:BoundField DataField="BookName" HeaderText="书名" ReadOnly="true" ItemStyle-CssClass="C-BookName" />
            <asp:BoundField DataField="BookPrice" HeaderText="书价" ReadOnly="true" ItemStyle-CssClass="C-BookPrice"/>
            <asp:BoundField DataField="BookNeedNum" HeaderText="数量" ItemStyle-CssClass="C-BookNeedNum"/>
            <asp:CommandField ShowDeleteButton="true"/>
            <asp:CommandField ShowEditButton="true"/>
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
       <br />
       <div class="cart-bottom">
        <asp:Button ID="btnOrderSend" runat="server" Text="提交订单" 
            onclick="btnOrderSend_Click" Width="150px" Height="40px"/>
       <%-- <asp:Label ID="test" runat="server" Text="Label"></asp:Label>--%>
        </div>
    </div>
</asp:Content>
