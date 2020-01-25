<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="CRUD_WEBFORM.Form.AddProduct" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

         <asp:Label ID="txtTransactionType" runat="server" Width="310"  Text="New Product"/>

        <asp:TextBox ID="txtId" runat="server" Width="310" Visible ="false" />
        <table border="1" style="border-collapse: collapse">
            <tr>
                <td style="width: 150px">
                    Select a Category:
                </td>
                <td>
                    <asp:DropDownList ID="CategoryDropDownList" runat="server"
                        DataTextField="CategoryName" DataValueField="Id">
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Product Name:<br />
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtProductName" runat="server" Width="310" />
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Description:<br />
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtDescription" runat="server" Width="310" />
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Upload Image:<br />
                </td>
                <td style="width: 300px">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <%--<asp:TextBox ID="txtImage" runat="server" Width="310" />--%>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="width: 450px"> <%--ImageUrl='<%#"ImageHandler.ashx?ProductId="+ Eval("Id")  %>'--%>
                    <asp:Image ID="txtImage" runat="server" ></asp:Image>
                </td>
            </tr>
            <tr>
                <td style="width: 150px" colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="Save" OnClick="SaveUpdateProduct" />

                    <asp:Button ID="Button1" runat="server" Text="Cancel" OnClick="CloseForm"  /> 
                </td>
            </tr>
            
        </table>
</asp:Content>
