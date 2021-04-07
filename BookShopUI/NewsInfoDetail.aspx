<%@ Page Title="" Language="C#" MasterPageFile="~/BookShop.Master" AutoEventWireup="true" CodeBehind="NewsInfoDetail.aspx.cs" Inherits="BookShopUI.NewsInfoDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center">
        <h2><asp:Label ID="labTitle" runat="server" /></h2>
        <p><asp:Label ID="labNewsInfo" runat="server"></asp:Label></p>
        <div style="text-align:left; margin:auto;">
            <asp:Label ID="labContents" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
