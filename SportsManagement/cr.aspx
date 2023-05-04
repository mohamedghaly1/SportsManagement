<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cr.aspx.cs" Inherits="korafinale.cr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button5" runat="server" Text="logout" OnClick="Button5_Click" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Information of the club" Width="338px" OnClick="Button1_Click1" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Upcoming matches for the club" Width="338px" OnClick="Button2_Click" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="View all available stadiums:-"></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Start time:-"></asp:Label>
            <br />
            <asp:TextBox ID="date" runat="server" Width="234px"></asp:TextBox>
            <br />
            <asp:Literal ID="Literal2" runat="server" Visible="false"></asp:Literal>
            <br />
            <asp:Button ID="Button3" runat="server" Text="view" OnClick="Button3_Click" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Send a request to host an upcoming match:- "></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="stadium manager name:-"></asp:Label>
            <br />
            <asp:TextBox ID="namesm" runat="server" Width="234px"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="start time:-"></asp:Label>
            <br />
            <asp:TextBox ID="starttime" runat="server" Width="234px"></asp:TextBox>
            <br />
            <asp:Literal ID="Literal1" runat="server" Visible="false"></asp:Literal>
            <br />
            <asp:Button ID="Button4" runat="server" Text="send request" OnClick="Button4_Click1" />
            <br />
        </div>
    </form>
</body>
</html>
