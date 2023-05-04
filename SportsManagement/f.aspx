<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="f.aspx.cs" Inherits="korafinale.f" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="Button2" runat="server" Text="logout" OnClick="Button2_Click" />
            <br />
            <br />
            <br />

            <asp:Label ID="Label1" runat="server" Text="Start time for matches to attend:-"></asp:Label>
            <br />
            <asp:TextBox ID="st" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literal1" runat="server" Visible="false"></asp:Literal>
            <br />
            <asp:Button ID="Button1" runat="server" Text="View" OnClick="Button1_Click" />

        </div>
    </form>
</body>
</html>
