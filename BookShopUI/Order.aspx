<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="BookShopUI.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="labName" runat="server" Text="" Font-Size="25px"></asp:Label>
     <asp:GridView ID="gvOrderList" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" BackColor="White"  EmptyDataText="订单为空"
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns> 
            <asp:BoundField DataField="OrderID" HeaderText="订单号" ReadOnly="true" ItemStyle-CssClass="O-OrderID"/>
            <asp:BoundField DataField="cdate" HeaderText="创建时间" ReadOnly="true" ItemStyle-CssClass="O-cdate"/>
            <asp:BoundField DataField="OrderState" HeaderText="订单状态" ItemStyle-CssClass="O-OrderState"/>
             <asp:BoundField DataField="tel" HeaderText="电话" ItemStyle-CssClass="O-Tel"/>
            <asp:BoundField DataField="address" HeaderText="地址" ItemStyle-CssClass="O-address"/>
            <asp:BoundField DataField="PriceSum" HeaderText="总价" ItemStyle-CssClass="O-PriceSum"/>
            <asp:BoundField DataField="BookID" HeaderText="书号"  ReadOnly="true" ItemStyle-CssClass="O-BookID"/>
            <asp:ImageField DataImageUrlField="BookPic" HeaderText="图书封面" ReadOnly="true" ItemStyle-CssClass="O-BookPic"/>
            <asp:BoundField DataField="BookName" HeaderText="书名" ReadOnly="true" ItemStyle-CssClass="O-BookName"/>
            <asp:BoundField DataField="BookPrice" HeaderText="书价" ReadOnly="true" ItemStyle-CssClass="O-BookPrice"/>          
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
       <div class="Order-bottom">
            <asp:DropDownList ID="ddlOrderID" runat="server" Width="180px" Height="35px" Font-Size="20px"></asp:DropDownList>
            <asp:Button ID="btnChange" runat="server" Text="确认收货" 
             onclick="btnChange_Click" Width="95px" Height="35px" Font-Size="20px"/>
       </div>
</asp:Content>
