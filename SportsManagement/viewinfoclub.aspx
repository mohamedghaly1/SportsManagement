<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewinfoclub.aspx.cs" Inherits="korafinale.viewinfoclub" %>

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
        
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label ID="represnet" runat="server" Text="Information about the club" Font-Bold="true" Font-Size="X-Large"
        CssClass="StrongText"></asp:Label>

        </div>
        <br />
            <br />
            <br />
            <br />
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label ID="Label2" runat="server" Text="Your club" Font-Bold="true" Font-Size="X-Large"
        CssClass="StrongText"></asp:Label>

        </div>
        <div>
            <table style="width:800px; margin:auto;">
                <tr>
                    <td>
                        <asp:GridView ID="GridView3" runat="server" Width="100%"></asp:GridView>
                    </td>
                </tr>
            </table>
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label ID="Label3" runat="server" Text="Requests sent" Font-Bold="true" Font-Size="X-Large"
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
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label ID="Label1" runat="server" Text="Upcoming matches" Font-Bold="true" Font-Size="X-Large"
        CssClass="StrongText"></asp:Label>

        </div>
        <div>
            <table style="width:800px; margin:auto;">
                <tr>
                    <td>
                        <asp:GridView ID="GridView2" runat="server" Width="100%"></asp:GridView>
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
