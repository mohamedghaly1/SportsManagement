<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="defineUser.aspx.cs" Inherits="korafinale.defineUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Please select the specialism for which you wish to register :-"></asp:Label>
            <br />
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SAM" runat="server" Text="Sports Association Manager" Width="224px" OnClick="SAM_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="CR" runat="server" Text="Club Representative" Width="224px" OnClick="CR_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SM" runat="server" Text="Stadium Manager" Width="224px" OnClick="SM_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="F" runat="server" Text="Fan" Width="224px" OnClick="F_Click" />
        </div>
    </form>
</body>
</html>
