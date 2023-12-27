<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Seller.aspx.cs" Inherits="E_BUSINESS.Seller" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        "ΚΕΝΤΡΙΚΗ ΔΙΟΙΚΗΣΗ"
    </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h32> ΣΥΝΟΛΙΚΑ ΕΣΟΔΑ:  </h32><br><br />
            <br /><br /><h16>ΑΝΑΛΥΤΗΚΑ ΣΤΟΙΧΕΙΑ:&nbsp;&nbsp;&nbsp; </h16></div>
        <p>
            <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2">
                <ItemTemplate>
                    useremail:
                    <asp:Label ID="useremailLabel" runat="server" Text='<%# Eval("useremail") %>' />
                    <br />
                    price:
                    <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
                    <br />
                    whenordered:
                    <asp:Label ID="whenorderedLabel" runat="server" Text='<%# Eval("whenordered") %>' />
                    <br />
                    items:
                    <asp:Label ID="itemsLabel" runat="server" Text='<%# Eval("items") %>' />
                    <br />
<br />
                </ItemTemplate>
            </asp:DataList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:EBUSINESSConnectionString %>" SelectCommand="SELECT * FROM [Orders]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Logout" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Σελίδα Πελάτη" />
    </form>
</body>
</html>