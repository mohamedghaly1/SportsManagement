<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="availablematchesblock.aspx.cs" Inherits="korafinale.availablematchesblock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
        </div>
        <div>
            <div>
            <div>
            <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label ID="Label3" runat="server" Text="Available Matches To Attend(You are blocked can not purchase tickets)" Font-Bold="true" Font-Size="X-Large"
        CssClass="StrongText"></asp:Label>

        </div>
        <div>
            <table style="width:800px; margin:auto;">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" Width="100%"></asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        </div>
        </div>
        </div>
    </form>
</body>
</html>
