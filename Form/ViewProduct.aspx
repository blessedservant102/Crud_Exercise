<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="CRUD_WEBFORM.Form.ViewProduct" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
         <asp:Label ID="txtTransactionType" runat="server" Width="310"  Text="Product Details"/>
    <br />
        <asp:TextBox ID="txtId" runat="server" Width="310" Visible ="false" />
        <table border="1" style="border-collapse: collapse">
            <tr>
                <td style="width: 150px">
                    Product Id :<br />
                </td>
                <td style="width: 300px">
                    <asp:Label ID="lblId" runat="server" Width="310" />
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Category :<br />
                </td>
                <td style="width: 300px">
                    <asp:Label ID="lblCategory" runat="server" Width="310" />
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Product Name:<br />
                </td>
                <td style="width: 300px">
                    <asp:Label ID="lblProductName" runat="server" Width="310" />
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Description:<br />
                </td>
                <td style="width: 300px">
                    <asp:Label ID="lblDescription" runat="server" Width="310" />
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Image: <br />
                </td>
               
                <td> <%--ImageUrl='<%#"ImageHandler.ashx?ProductId="+ Eval("Id")  %>'--%>
                    <asp:Image ID="txtImage" runat="server" ></asp:Image>
                </td>
            </tr>
            <tr>
                <td style="width: 150px" colspan="2">
                    <asp:LinkButton ID="lnkBack" runat="server" OnClick="CloseForm">Back to List</asp:LinkButton>
                </td>
            </tr>
            
        </table>
</asp:Content>

