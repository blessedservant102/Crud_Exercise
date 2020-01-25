<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="CRUD_WEBFORM.Category1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    Category List
    <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" EmptyDataText="No records has been added." style="margin-top: 15px" EnableTheming="True" OnRowEditing="Gridview1_RowEditing" OnSelectedIndexChanged="Gridview1_SelectedIndexChanged" OnRowCancelingEdit="Gridview1_RowCancelingEdit" OnRowUpdating="Gridview1_RowUpdating" OnRowDataBound="Gridview1_RowDataBound" OnRowDeleting="Gridview1_RowDeleting" OnSelectedIndexChanging="Gridview1_SelectedIndexChanging">
        <Columns>
    <asp:TemplateField HeaderText="Category Id" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lblID" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:Label ID="lblCategoryId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
        </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Category Name" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtCategoryName1" runat="server" Text='<%# Eval("CategoryName") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>
            <asp:TemplateField  >
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("Id") %>'  OnClick="Edit_Click" >Edit</asp:LinkButton>
                </ItemTemplate>

                <ItemStyle Width="100px"></ItemStyle>
            </asp:TemplateField>
    <asp:CommandField ButtonType="Link" ShowEditButton="false" ShowDeleteButton="true" ItemStyle-Width="150" />
</Columns>


    </asp:GridView>

    <table border="1" style="border-collapse: collapse">
    <tr>
        <td style="width: 300px">
            Category Name:<br />
            <asp:TextBox ID="txtCategoryName" runat="server" Width="310" />
            <asp:TextBox ID="txtId" runat="server" Width="310"  Visible="false"/>
        </td>
        <td style="width: 250px">
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="InsertUpdate" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="CancelUpdate"  Visible ="false"/>
        </td>
    </tr>
    </table>


</asp:Content>
