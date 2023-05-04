<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sm.aspx.cs" Inherits="korafinale.sm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="Button4" runat="server" Text="logout" OnClick="Button4_Click" />
            <br />
            <br />
            <br />

            <asp:Button ID="Button1" runat="server" Text="Information of the Stadium" Width="351px" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="All requests have been received" Width="351px" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Manage unhandled requests" OnClick="Button3_Click" Width="351px" />
            <br />

        </div>
    </form>
</body>
</html>
