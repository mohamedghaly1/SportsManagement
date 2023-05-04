<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="korafinale.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Sign in"></asp:Label>
            <br />
            <br />
            Username:-<br />
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
            <br />
            Password:-<br />
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literalstatus" runat="server" Visible="false"></asp:Literal>
            <br />
            <asp:Button ID="loginn" runat="server" Text="sign in" OnClick="loginn_Click" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Don't have an account?"></asp:Label>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Login Now!</asp:LinkButton>

            <br />

        </div>
    </form>
</body>
</html>
