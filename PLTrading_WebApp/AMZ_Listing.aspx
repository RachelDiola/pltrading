<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AMZ_Listing.aspx.cs" Inherits="PLTrading_WebApp.AMZ_Listing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.3.1.js"></script>
</head>
<body style="background-color:white; font-family: Tahoma; font-size: 12px;" >
    <form id="form1" runat="server">
        <div style ="color:gray;">
       <%--     <div style = "display: block;    float: left;    text-align: left;    width: 100%; background-color:cornflowerblue;">
            <h2 style="color:white;">Primelight Trading</h2>
            </div>--%>
            <%--<br /><br /> --%>

                <h2 style="color:dimgray;"> Listing in Amazon </h2>
                <h3><asp:Label ID="Label2" runat="server" Text="Lister:"></asp:Label>
        
                <asp:Label ID="lblLister" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Date:"></asp:Label>
                <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></h3>
                <br />

                        <asp:Label style="text-align:center" ID="Label27" runat="server" Text="SKU:" Font-Size="Large"></asp:Label>
                        <asp:TextBox width="30%" ID="txtSKU" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="Large" />
                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ForeColor="Red" Font-Bold="true" />
                <fieldset style="border:1px solid gray;">
                <legend style = "color:gray;  font-size:15px;  text-align:left; font-weight:bolder;">Source Information</legend>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Source Link:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtsourcelink" width="1000" runat="server"  OnTextChanged="txtSource_Link_TextChanged" OnClick="return CheckIfChannelHasChanged()" AutoPostBack="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidateRequestMode="Enabled" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Source Link" ControlToValidate="txtsourcelink" ForeColor="Red" Font-Bold="true">*</asp:RequiredFieldValidator>
                        </td>
                   </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Source:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtsource" runat="server" Enabled="False" OnTextChanged="txtsource_TextChanged" AutoPostBack="True"></asp:TextBox>
                            <asp:RadioButton ID="rbtnWAL" runat="server"  Text="WAL" Visible="False" GroupName="walmart" OnCheckedChanged="rbtnWAL_CheckedChanged" AutoPostBack="True" />
                            <asp:RadioButton ID="rbtnWALHAY" runat="server"  Text="WAL-HAY" Visible="False" GroupName="walmart" OnCheckedChanged="rbtnWALHAY_CheckedChanged" AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Price:"></asp:Label>
                        </td>
                        <td>
                            
                            <asp:TextBox width="60" ID="txtprice" runat="server" AutoPostBack="True" OnTextChanged="txtprice_TextChanged" TextMode="Number"></asp:TextBox>&nbsp; &nbsp; 
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Source Price" ControlToValidate="txtprice" ForeColor="Red" Font-Bold="true">*</asp:RequiredFieldValidator>
                            <asp:Label ID="Label15" runat="server" Text="Shipping Cost:"></asp:Label>
                            <asp:TextBox width="50" ID="txtshippingcost" runat="server" AutoPostBack="True" TextMode="Number" OnTextChanged="txtshippingcost_TextChanged"></asp:TextBox>&nbsp; &nbsp;
                            <asp:Label ID="Label16" runat="server" Text="Handling Time:"></asp:Label>
                            <asp:TextBox Width="30" ID="txthandling" runat="server" Enabled="False" OnTextChanged="txthandling_TextChanged"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Handling Time" ControlToValidate="txthandling" ForeColor="Red" Font-Bold="true">*</asp:RequiredFieldValidator>
                            <%--<asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" TextMode="Date"></asp:TextBox>--%>
                            <asp:TextBox Width="130" ID="txtdatepicker" runat="server" AutoPostBack="True" TextMode="Date" OnTextChanged="txtdatepicker_TextChanged1"></asp:TextBox>
                        </td>
                            
                                  
                            
                            <%--<asp:Button ID="btnGetPrice" runat="server" Text="Get Price" OnClick="btnGetPrice_Click" />--%>
                        
                    </tr>   
            
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Vendor Variant:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox  width="230" ID="txtvariant" runat="server"></asp:TextBox>&nbsp; &nbsp;
                            <asp:Label ID="Label6" runat="server" Text="Item/Model#"></asp:Label>
                            <asp:TextBox ID="txtitemNum" runat="server" AutoPostBack="True" OnTextChanged="txtitemNum_TextChanged"></asp:TextBox>&nbsp; &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Item/Model # " ControlToValidate="txtitemNum" ForeColor="Red" Font-Bold="true">*</asp:RequiredFieldValidator>
                            <asp:Label ID="Label9" runat="server" Text="QTY:"></asp:Label>
                            <asp:TextBox width="40" ID="txtqty" runat="server" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Quantity" ControlToValidate="txtqty" ForeColor="Red" Font-Bold="true">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Shipping:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="Free 2-day delivery on $35+ orders"></asp:ListItem>
                                <asp:ListItem Value="Free Delivery"></asp:ListItem>
                                <asp:ListItem Value="Free Delivery on $45 order"></asp:ListItem>
                                <asp:ListItem Value="Free Shipping"></asp:ListItem>
                                <asp:ListItem Value="Price includes shipping"></asp:ListItem>
                                <asp:ListItem Value="Standard Shipping"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Shipping" ControlToValidate="DropDownList1" ForeColor="Red" Font-Bold="true">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
              <%--      <tr>
                        <td colspan="2">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" Font-Bold="true" />
                        </td>
                    </tr>--%>

                </table>
                </fieldset>
                <br /><br />               
                <fieldset style="border:1px solid gray;">
                <legend style = "color:gray;  font-size:15px;  text-align:left; font-weight:bolder;">Amazon Information</legend>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Amazon Product Name:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox  width="1300" ID="txtamzprodname" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="AMZ Product Name" ControlToValidate="txtamzprodname" ForeColor="Red" Font-Bold="true">*</asp:RequiredFieldValidator>
                        </td>
                   </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Brand:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox width="180" ID="txtbrand" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Brand" ControlToValidate="txtbrand" ForeColor="Red" Font-Bold="true">*</asp:RequiredFieldValidator>
                            <asp:Label ID="Label28" runat="server" Text="Sales Rank:"></asp:Label>
                            <asp:TextBox ID="txtsalesrank" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Sales Rank" ControlToValidate="txtsalesrank" ForeColor="Red" Font-Bold="true">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="ASIN:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox  width="100" ID="txtASIN" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="ASIN" ControlToValidate="txtASIN" ForeColor="Red" Font-Bold="true">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>   
            
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Type:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList3" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="MF">MF</asp:ListItem>
                                <asp:ListItem Value="Available from these sellers"></asp:ListItem>
                                <asp:ListItem Value="FBA"></asp:ListItem>
                                <asp:ListItem Value="AMZ"></asp:ListItem>
                            </asp:DropDownList>&nbsp; &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Type" ControlToValidate="DropDownList3" ForeColor="Red" Font-Bold="true">*</asp:RequiredFieldValidator>
                            <asp:Label ID="Label14" runat="server" Text="Position:"></asp:Label>
                            <asp:DropDownList width ="40" ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="1"></asp:ListItem>
                                <asp:ListItem Value="2"></asp:ListItem>
                                <asp:ListItem Value="3"></asp:ListItem>
                                <asp:ListItem Value="4"></asp:ListItem>
                                <asp:ListItem Value="5"></asp:ListItem>
                            </asp:DropDownList>&nbsp; &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Position" ControlToValidate="DropDownList2" ForeColor="Red" Font-Bold="true">*</asp:RequiredFieldValidator>
                            <asp:Label ID="Label26" runat="server" Text="Price"></asp:Label>
                            <asp:TextBox width ="60" ID="txtamzprice" runat="server" AutoPostBack="True" TextMode="Number" OnTextChanged="txtamzprice_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Amazon Price" ControlToValidate="txtamzprice" ForeColor="Red" Font-Bold="true">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>    
        <%--            <tr>
                        <td colspan="2">
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" Font-Bold="true" />
                        </td>
                    </tr>--%>
                </table>
                </fieldset>
                <br /><br />               
                <fieldset style="border:1px solid gray;">
                <legend style = "color:gray;  font-size:15px;  text-align:left; font-weight:bolder;">Computation</legend>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label17" runat="server" Text="Profit:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox Width = "50" ID="txtprofit" runat="server" Enabled="False" AutoPostBack="True"></asp:TextBox>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                            <asp:Label Width = "120" ID="Label20" runat="server" Text="Profit w/o Tax:"></asp:Label>
                            <asp:TextBox Width = "50" ID="txtprofitwotax" runat="server" Enabled="False" AutoPostBack="True"></asp:TextBox>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                            <asp:Label Width = "120" ID="Label23" runat="server" Text="Source Price + Tax:"></asp:Label>
                            <asp:TextBox Width = "55px" ID="txtsourceprice" runat="server" Enabled="False" AutoPostBack="True"></asp:TextBox>
                        </td>
                   </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label18" runat="server" Text="Profit Margin:"></asp:Label>&nbsp;
                        </td>
                        <td>
                            <asp:TextBox Width = "50" ID="txtprofitmargin" runat="server" Enabled="False" AutoPostBack="True"></asp:TextBox>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                            <asp:Label ID="Label21" runat="server" Text="Profit Margin w/o Tax:"></asp:Label>
                            <asp:TextBox Width = "50" ID="txtprofitmarginwotax" runat="server" Enabled="False" AutoPostBack="True"></asp:TextBox>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                            <asp:Label Width = "120" ID="Label24" runat="server" Text="Total Cost:"></asp:Label>
                            <asp:TextBox Width = "55px" ID="txttotalcost" runat="server" Enabled="False" AutoPostBack="True" TextMode="Number"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label19" runat="server" Text="ROI:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox Width = "50" ID="txtroi" runat="server" Enabled="False" AutoPostBack="True"></asp:TextBox>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                            <asp:Label Width = "120" ID="Label22" runat="server" Text="ROI w/o Tax:"></asp:Label>
                            <asp:TextBox Width = "50" ID="txtroiwotax" runat="server" Enabled="False" AutoPostBack="True"></asp:TextBox>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                            <asp:Label ID="Label25" runat="server" Text="Minimum Listing Price:"></asp:Label>
                            <asp:TextBox Width = "55px" ID="txtminlist" runat="server" Enabled="False" AutoPostBack="True"></asp:TextBox>
                        </td>
                    </tr>                  
                </table>
                </fieldset>
                <br /><br />
                &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                <asp:Label ID="lblSave" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" />&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="CANCEL" OnClick="btnCancel_Click" CausesValidation="False" />&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                <asp:Button ID="btnClear" runat="server" Text="CLEAR" OnClick="btnClear_Click" CausesValidation="False" />
                
        </div>
    </form>
</body>
</html>
