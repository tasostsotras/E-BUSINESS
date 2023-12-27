<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="E_BUSINESS.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:Label ID="Label1" runat="server" Text="Epilexte typo xristi"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" style="margin-left: 553px" TextMode="Email"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
        </p>
        <p>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="252px">
            <asp:ListItem>Admin</asp:ListItem>
            <asp:ListItem>Customer</asp:ListItem>
        </asp:DropDownList>
            <asp:TextBox ID="TextBox5" runat="server" style="margin-left: 454px" TextMode="Phone"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="Telephone"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 652px" Width="235px"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Onoma xristi"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 655px" Width="232px" TextMode="Password"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Kodikos" ></asp:Label>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Eggrafi" />
    </form>
</body>
</html>
