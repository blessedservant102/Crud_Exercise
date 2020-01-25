<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="CRUD_WEBFORM.Product1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    Product List
    <br /><%--OnSelectedIndexChanged="ProductGrid_SelectedIndexChanged" OnRowEditing="ProductGrid_RowEditing" OnSelectedIndexChanging="ProductGrid_SelectedIndexChanging" --%>
    <a runat="server" href="~/Form/AddProduct.aspx?TransactionType=NewProduct">Create New</a>
    <asp:GridView ID="ProductGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" EmptyDataText="No records has been added." style="margin-top: 15px" EnableTheming="True"   >
        <Columns>
            <asp:TemplateField HeaderText="Product Id" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                </EditItemTemplate>

            <ItemStyle Width="150px">

            </ItemStyle>
           </asp:TemplateField>
                <asp:TemplateField HeaderText="Category Name" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCategoryName" runat="server" Text='<%# Eval("CategoryName") %>'></asp:TextBox>
                </EditItemTemplate>

            <ItemStyle Width="150px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Name" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>'></asp:TextBox>
                </EditItemTemplate>

                <ItemStyle Width="150px"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Image" ItemStyle-Width="150">
                <ItemTemplate>

                      <asp:Image ID="lblImage" runat="server" ImageUrl='<%#"ImageHandler.ashx?ProductId="+ Eval("Id")  %>' style="width: 300px; height: 150px;"></asp:Image>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Image ID="txtImage" runat="server" ImageUrl='<%#"ImageHandler.ashx?ProductId="+ Eval("Id")  %>'></asp:Image>
                </EditItemTemplate>

                <ItemStyle Width="150px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField  >
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("Id") %>'  OnClick="Edit_Click" >Edit</asp:LinkButton>
                    <asp:LinkButton ID="lnkDetails" runat="server" CommandArgument='<%# Eval("Id") %>'  OnClick="Detials_Click" >Details</asp:LinkButton>
                     <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("Id") %>'  OnClick="Delete_Click" >Delete</asp:LinkButton>
                </ItemTemplate>

                <ItemStyle Width="150px"></ItemStyle>
            </asp:TemplateField>
            <%--<asp:CommandField ShowDeleteButton="True" />--%>
        </Columns>

            
    </asp:GridView>

</asp:Content>