<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pendingrequests.aspx.cs" Inherits="korafinale.pendingrequests" %>

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
            <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label ID="Label3" runat="server" Text="Unhandled requests" Font-Bold="true" Font-Size="X-Large"
        CssClass="StrongText"></asp:Label>

        </div>
        <div>
            <table style="width:800px; margin:auto;">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" Width="100%" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:ButtonField ButtonType="Button" CommandName="accept" Text="Accept">
                                <ControlStyle BackColor="Lime" />
                                </asp:ButtonField>
                                <asp:ButtonField ButtonType="Button" CommandName="reject" Text="Reject">
                                <ControlStyle BackColor="Red" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        </div>
    </form>
</body>
</html>
