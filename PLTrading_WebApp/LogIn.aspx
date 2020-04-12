
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="PLTrading_WebApp.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:white; font-family: Tahoma; font-size: 13px/20px;" >

    <form id="form1" runat="server">
<%--    <div class = "width:960px; background-color:black; margin:20px auto 0px auto; border:1px solid #496077;">--%>
    <div>
        <div style = "display: block;    float: left;    text-align: left;    width: 100%; background-color:cornflowerblue;">
            <h2 style="color:white;">Primelight Trading</h2>
        </div><br /><br /><br /><br /><br />
        
<%--        <div>
        <%--<asp:Button ID="lblErrMsg" runat="server" Text="Incorrect Username/Password!" EnableTheming="True" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" BorderStyle="None" ForeColor="#FF3300" />--%>
        <asp:Label ID="lblcsttime" runat="server" Font-Size="Small"></asp:Label><br />
        <asp:Label ID="lblutctime" runat="server" Font-Size="Small"></asp:Label><br /><br /><br />
        <%--</div>--%>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            <fieldset style="border:1px solid gray; width:20%; line-height:180%;">
            <legend style = "color:gray;  font-size:90%;  text-align:left;">Login Details</legend>
                 <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtUserName" placeholder="Username" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>

                        <td>
                            <asp:TextBox ID="txtPassword" placeholder="Password" runat="server" TextMode = "password" ></asp:TextBox></td>
                    </tr>
                    <tr>

                        <td>
                            <asp:Button ID="btnLogIn" runat="server" Text="Log In" onclick="btnLogIn_Click" /></td>
                    </tr>  
                    <tr>

                        <td>
                            </td>
                    </tr>

                </table>

            </fieldset><br />
            <asp:Label ID="lblErrMsg1" runat="server" Text="Incorrect Username/Password!" Font-Size="Small" ForeColor="#FF3300"></asp:Label>    
    </div>
    </form>
</body>
</html>
