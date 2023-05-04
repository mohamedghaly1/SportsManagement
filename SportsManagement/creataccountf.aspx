<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creataccountf.aspx.cs" Inherits="korafinale.creataccountf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Fill the form :-"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Name:-"></asp:Label>
            <br />
            <asp:TextBox ID="name" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Username:-"></asp:Label>
            <br />
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Password:-"></asp:Label>
            <br />
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="National id number:-"></asp:Label>
            <br />
            <asp:TextBox ID="nationalid" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="phone number:-"></asp:Label>
            <br />
            <asp:TextBox ID="phonenumber" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Birth date(yyyy/MM/dd):-"></asp:Label>
            <br />
            <asp:TextBox ID="birthdate" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Address:-"></asp:Label>
            <br />
            <asp:TextBox ID="adress" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literal1" runat="server" Visible="false"></asp:Literal>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Done" OnClick="Button1_Click"/>
            <br />
        </div>
    </form>
</body>
</html>
