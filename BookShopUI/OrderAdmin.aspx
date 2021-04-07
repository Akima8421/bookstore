<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="OrderAdmin.aspx.cs" Inherits="BookShopUI.OrderAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    订单信息：<asp:TextBox ID="OrderAbout" runat="server" Width="200px" style="font-size:16px" />&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlOrderstate" runat="server" style="font-size:16px">
        <asp:ListItem>订单号</asp:ListItem>
        <asp:ListItem>订单状态</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFindNews" runat="server" Text=" 查 询 "  style="font-size:16px"
        onclick="btnFindNews_Click" /><p />
     <div class="OrderAdmin">
     <asp:GridView ID="gvOrderList" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" BackColor="White"  EmptyDataText="订单为空"
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" Width="1090px" 
         onpageindexchanging="gvOrderList_PageIndexChanging" 
         onrowcancelingedit="gvOrderList_RowCancelingEdit" 
         onrowdatabound="gvOrderList_RowDataBound" onrowediting="gvOrderList_RowEditing" 
         onrowupdating="gvOrderList_RowUpdating">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns> 
            <asp:BoundField DataField="OrderID" HeaderText="订单号" ReadOnly="true" ItemStyle-CssClass="OrderAdmin-OID"/>
            <asp:BoundField DataField="cdate" HeaderText="创建时间" ReadOnly="true" ItemStyle-CssClass="OrderAdmin-cdate"/>
            <asp:BoundField DataField="BookID" HeaderText="书号"  ReadOnly="true" ItemStyle-CssClass="OrderAdmin-BID"/>
            <asp:ImageField DataImageUrlField="BookPic" HeaderText="图书封面" ReadOnly="true" ItemStyle-CssClass="OrderAdmin-BPic"/>
            <asp:BoundField DataField="BookName" HeaderText="书名" ReadOnly="true" ItemStyle-CssClass="OrderAdmin-BName"/>
            <asp:BoundField DataField="BookPrice" HeaderText="书价" ReadOnly="true" ItemStyle-CssClass="OrderAdmin-BPrice"/>
            <asp:TemplateField HeaderText="订单状态" ItemStyle-CssClass="OrderAdmin-state">
                    <EditItemTemplate>
                        <asp:Label ID="Orderstate" runat="server" Text='<%# Eval("OrderState") %>' Visible="false"></asp:Label>
                        <asp:DropDownList ID="ddlOrder" runat="server">
                            <asp:ListItem Value="待发货">待发货</asp:ListItem>
                            <asp:ListItem Value="已发货">已发货</asp:ListItem>
                            <asp:ListItem Value="已收货">已收货</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Orderstate" runat="server" Text='<%# Eval("OrderState") %>'></asp:Label>    
                    </ItemTemplate>
             </asp:TemplateField>
             <asp:CommandField ShowEditButton="true" ItemStyle-CssClass="OrderAdmin-edit"/>
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
