<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SweetsComplete.Views.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link href="Content/bootstrap.css" rel="stylesheet"/>
        <script src="Scripts/jquery-1.8.2.js"></script>
        <script src="Scripts/bootstrap.js"></script>
    <title>Sweets Complete</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="user_id" DataSourceID="SqlDataSource1" CssClass="table table-hover table-striped">
            <Columns>
                <asp:BoundField DataField="user_id" HeaderText="user_id" InsertVisible="False" ReadOnly="True" SortExpression="user_id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
                <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                <asp:BoundField DataField="state_province" HeaderText="state_province" SortExpression="state_province" />
                <asp:BoundField DataField="postal_code" HeaderText="postal_code" SortExpression="postal_code" />
                <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" />
                <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
                <asp:BoundField DataField="balance" HeaderText="balance" SortExpression="balance" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM members"></asp:SqlDataSource>
    </form>
</body>
</html>
