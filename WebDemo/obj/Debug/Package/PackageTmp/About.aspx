<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WebDemo.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <td colspan="2" style="vertical-align:top;">
                            <table cellpadding="0" cellspacing="0" class="tabla_01" style="border-top-width:0px; border-right-width:0px; ">
                                <tr>
                                    <td rowspan="6" style="width:10px;"></td>
                                    <td style="height:7px"></td>
                                    <td rowspan="6" style="width:2px;"></td>
                                    <td></td>
                                    <td rowspan="6" style="width:5px;"></td>
                                    <td></td>   
                                    <td rowspan="6" style="width:2px;"></td>
                                    <td></td>
                                    <td rowspan="6"></td>                                                                             
                                </tr>                                  
                                <tr>
                                    <td class="formlabel_m">
                                        <asp:Label ID="lblContactIn" runat="server" Text="Escriba el producto">
                                        </asp:Label></td>
                                    <td class="formInfo_m" colspan="2">
                                        
                                        <asp:TextBox ID="txtName1" runat="server" MaxLength="100" CssClass="txtBox" Text=""></asp:TextBox></td>
                                    <td style="width:145px;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="8" class="cellspacing"></td>
                                </tr>                                  
                                <tr>
                                    <td class="formlabel_m">
                                        <asp:Label ID="lblAcco" runat="server" Text="cantidad">
                                        </asp:Label></td>
                                    <td class="formInfo_m" colspan="2">
                                        <asp:TextBox ID="TextBox1" runat="server" MaxLength="100" CssClass="txtBox" Text=""></asp:TextBox></td>
                                    
                                </tr>
                                <tr>
                                    <td colspan="8" class="cellspacing"></td>
                                </tr>                                 
                                <tr>
                                    <td class="formlabel_m">
                                    
                                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click"  OnClientClick ="mensaje();" Text="registrar" />
                                    </td>
                                    <td class="formInfo_m" colspan="3">
                                        &nbsp;</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="9" style="height:7px;"></td>
                                </tr>                                
                            </table>                        
                        </td>


<script type="text/javascript">
 
function mensaje() {
 
  alert("Se intento hacer un registro");
    
}
 
</script>



</asp:Content>
