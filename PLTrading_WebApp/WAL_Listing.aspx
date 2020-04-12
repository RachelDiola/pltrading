<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WAL_Listing.aspx.cs" Inherits="PLTrading_WebApp.WAL_Listing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:white; font-family: Tahoma; font-size: 12px;" >
    <form id="form1" runat="server">
        <div>
             <%--   <div style = "display: block; float: left;    text-align: left; width: 100%; background-color:cornflowerblue;">
                    <h2 style="color:white;">Primelight Trading</h2>
                </div><br /><br /><br /><br /><br />--%>

            <h2 style="color:dimgray;"> Listing in Walmart </h2>
            <h3><asp:Label ID="Label2" runat="server" Text="Lister:"></asp:Label>
        
            <asp:Label ID="lblLister" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Date:"></asp:Label>
            <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></h3>
            <br />
        </div>

    </form>
</body>
</html>
