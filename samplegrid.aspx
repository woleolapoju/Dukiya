<%@ Page Language="C#" AutoEventWireup="true" CodeFile="samplegrid.aspx.cs" Inherits="samplegrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Editable Grid view</title>
</head>
<body>
    <form id="form1" runat="server">
  <div>
    <asp:GridView ID="gvData" AutoGenerateColumns="false" ShowFooter="true" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="lblID" Text='<%#Eval("ID") %>' runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtID" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ProductName">
                <ItemTemplate>
                    <asp:Label ID="lblProductName" Text='<%#Eval("ProductName") %>' runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtProductName" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:Label ID="lblPrice" Text='<%#Eval("Price") %>' runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtPrice" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="lblQuantity" Text='<%#Eval("Quantity") %>' runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <FooterTemplate>
                    <asp:Button ID="btnSubmit" Text="Add"  OnClientClick="addrow()" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<div>
    <script type="text/javascript">
        function addrow () {
         
                alert("here");
                var gridview = $('[id*=gvData]');
                row = $("[id*=gvData] tr:last-child ").prev().clone(true);
                var txtID = $('[id*=gvData] [id*=txtID]').val();
                var txtProductName = $('[id*=gvData] [id*=txtProductName]').val();
                var txtPrice = $('[id*=gvData] [id*=txtPrice]').val();
                var txtQuantity = $('[id*=gvData] [id*=txtQuantity]').val();
                $("td:nth-child(1)", row).html(txtID);
                $("td:nth-child(2)", row).html(txtProductName);
                $("td:nth-child(3)", row).html(txtPrice);
                $("td:nth-child(4)", row).html(txtQuantity);
                $("[id*=gvData] tbody tr:last").before(row);
                $('[id*=gvData] [id*=txtID]').val('');
                $('[id*=gvData] [id*=txtProductName]').val('');
                $('[id*=gvData] [id*=txtPrice]').val('');
                $('[id*=gvData] [id*=txtQuantity]').val('');

                alert("here");
                return false;
 
        }     
</script>
</div>
    </form>
</body>
</html>