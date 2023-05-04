<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creataccountsa.aspx.cs" Inherits="korafinale.creataccountsa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle1 {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button6" runat="server" Text="logout" OnClick="Button6_Click" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Add a new club:- "></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Name:-"></asp:Label>
            <br />
            <asp:TextBox ID="nameaddclub" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Location:-"></asp:Label>
            <br />
            <asp:TextBox ID="locationaddclub" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literaladd" runat="server" Visible="false"></asp:Literal>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Add club" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Delete a club:-"></asp:Label>
            <br />
            <asp:Label ID="Label11" runat="server" Text="Name:-"></asp:Label>
            <br />
            <asp:TextBox ID="namedeleteclub" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literaldeleteclub" runat="server" Visible="false"></asp:Literal>
            <br />
            <asp:Button ID="Button3" runat="server" Text="Delete club" OnClick="Button3_Click" />
            <br />
            <br />
            <asp:Label ID="Label12" runat="server" Text="Add a new stadium:-"></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Name:-"></asp:Label>
            <br />
            <asp:TextBox ID="namestadium" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Location:-"></asp:Label>
            <br />
            <asp:TextBox ID="locationstadium" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label10" runat="server" Text="Capacity:-"></asp:Label>
            <br />
            <asp:TextBox ID="capacitystadium" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literalstadium" runat="server" Visible="false"></asp:Literal>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Add stadium" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Label ID="Label13" runat="server" Text="Delete a stadium:-"></asp:Label>
            <br />
            <asp:Label ID="Label14" runat="server" Text="Name:-"></asp:Label>
            <br />
            <asp:TextBox ID="namedeletestadium" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literaldeletestadium" runat="server" Visible="false"></asp:Literal>
            <br />
            <asp:Button ID="Button4" runat="server" Text="Delete stadium" OnClick="Button4_Click" />
            <br />
            <br />
            <asp:Label ID="Label15" runat="server" Text="Block a fan:-"></asp:Label>
            <br />
            <asp:Label ID="Label16" runat="server" Text="national id number.:-"></asp:Label>
            <br />
            <asp:TextBox ID="idblockfan" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literalblockfan" runat="server" Visible="false"></asp:Literal>
            <br />
            <asp:Button ID="Button5" runat="server" Text="Block" OnClick="Button5_Click" />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
