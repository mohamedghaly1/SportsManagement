<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sam.aspx.cs" Inherits="korafinale.sam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button6" runat="server" Text="logout" OnClick="Button6_Click" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Add a new match:-"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Host club:-"></asp:Label>
            <br />
            <asp:TextBox ID="hostclubname" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Guest club:-"></asp:Label>
            <br />
            <asp:TextBox ID="guestclubname" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Start time:-"></asp:Label>
            <br />
            <asp:TextBox ID="sarttime" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="End time:-"></asp:Label>
            <br />
            <asp:TextBox ID="endtime" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literal1" runat="server" Visible="false"></asp:Literal>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Delete a match:-"></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Host club:-"></asp:Label>
            <br />
            <asp:TextBox ID="hostclubnamedelete" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Guest club:-"></asp:Label>
            <br />
            <asp:TextBox ID="guestclubnamedelete" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Start time:-"></asp:Label>
            <br />
            <asp:TextBox ID="sarttimedelete" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label10" runat="server" Text="End time:-"></asp:Label>
            <br />
            <asp:TextBox ID="endtimedelete" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literal2" runat="server" Visible="false"></asp:Literal>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="View All upcoming matches" OnClick="Button3_Click" Width="426px" />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text="View already played matches" OnClick="Button4_Click" Width="426px" />
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" Text="View pair of club never played together" OnClick="Button5_Click" Width="426px" />
            <br />
        </div>
    </form>
</body>
</html>
