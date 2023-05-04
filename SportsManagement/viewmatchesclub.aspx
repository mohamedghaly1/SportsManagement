﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewmatchesclub.aspx.cs" Inherits="korafinale.viewmatchesclub" %>

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
    <asp:Label ID="Label3" runat="server" Text="Upcoming matches for the club " Font-Bold="true" Font-Size="X-Large"
        CssClass="StrongText"></asp:Label>

        </div>
        <div>
            <table style="width:800px; margin:auto;">
                <tr>
                    <td>
                        <asp:GridView ID="GridView11" runat="server" Width="100%"></asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
