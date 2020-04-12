<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="PLTrading_WebApp.Dashboard" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: white; font-family: Tahoma; font-size: 13px/20px;">
    <form id="form1" runat="server">
        <div style="color: gray;">
            <div style="display: block; float: left; text-align: left; width: 100%; background-color: cornflowerblue;">
                <h2 style="color: white;">Primelight Trading</h2>
            </div>
            <br />
            <br />

            <asp:Label ID="lblWelcomeUser" runat="server" Text=""></asp:Label>

            <br />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
            <br />
            <br />
            <table>
                <tr>
                    <td style="vertical-align:top">
                        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" EnableTheming="True">
                            <DynamicItemTemplate>
                                <%# Eval("Text") %>
                            </DynamicItemTemplate>
                            <Items>
                                <asp:MenuItem Text="Amazon Listing" Value="Amazon Listing"></asp:MenuItem>
                                <asp:MenuItem Text="Walmart Listing" Value="Walmart Listing"></asp:MenuItem>
                            </Items>
                        </asp:Menu>
                    </td>
                    <td>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                        <div  style="vertical-align:middle">
                                            <iframe style="" src="AMZ_Listing.aspx" width='1400' height='700'"></iframe>
                                        </div>
                                
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                        <div style="vertical-align:middle">
                                            <iframe style="" src="WAL_Listing.aspx" width='1400' height='700'"></iframe>
                                        </div>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

        </div>
    </form>
</body>
</html>
