<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="availableMatchesToAttend.aspx.cs" Inherits="korafinale.availableMatchesToAttend" %>

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
            <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label ID="Label3" runat="server" Text="Available Matches To Attend" Font-Bold="true" Font-Size="X-Large"
        CssClass="StrongText"></asp:Label>

        </div>
        <div>
            <table style="width:800px; margin:auto;">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" Width="100%" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:ButtonField ButtonType="Button" CommandName="purchase" Text="Purchase ticket">
                                <ControlStyle BackColor="Lime" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        </div>
        </div>
    </form>
</body>
</html>
