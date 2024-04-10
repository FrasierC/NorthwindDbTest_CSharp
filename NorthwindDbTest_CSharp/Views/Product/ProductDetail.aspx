<%@ Page Title="Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="NorthwindDbTest_CSharp.Views.ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:FormView ID="productDetail" runat="server" ItemType="NorthwindDbTest_CSharp.ViewModels.ProductDetailViewModel" SelectMethod="GetProduct" RenderOuterTable="false">
            <ItemTemplate>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="/">Home</a></li>
                        <li class="breadcrumb-item"><a href="/products">Products</a></li>
                        <li class="breadcrumb-item active" aria-current="page"><%# Item.Name %></li>
                    </ol>
                </nav>
                <div class="col-12 mt-2">
                    <div class="d-flex">
                        <div>
                            <h1><%# Item.Name %></h1>
                        </div>
                        <div><i class="bi bi-circle-fill <%# Item.IsAvailable ? "text-success" : "text-danger" %>"></i></span></div>
                    </div>
                </div>
                <div class="col-12 mt-2">
                    <h4>Category Info</h4>
                    <div class="col-12 mt-2">
                        <table class="table table-sm table-light">
                            <tr>
                                <td class="fw-bold">ID
                                </td>
                                <td>
                                    <%# Item.Category.Id %>
                                </td>
                            </tr>
                            <tr>
                                <td class="fw-bold">Name
                                </td>
                                <td>
                                    <%# Item.Category.Name %>
                                </td>
                            </tr>
                            <tr>

                                <td class="fw-bold">Description
                                </td>
                                <td>
                                    <%# Item.Category.Description %>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-12 mt-2">
                        <h4>Product Info</h4>
                        <table class="table table-sm table-light">
                            <tr>
                                <td class="fw-bold">ID
                                </td>
                                <td>
                                    <%# Item.Id %>
                                </td>
                            </tr>
                            <tr>
                                <td class="fw-bold">Qty Per Unit
                                </td>
                                <td>
                                    <%# Item.QuantityPerUnit %>
                                </td>
                            </tr>
                            <tr>
                                <td class="fw-bold">Unit Price
                                </td>
                                <td class="text-md-end">
                                    <%# $"${Item.UnitPrice}" %>
                                </td>
                            </tr>
                            <tr>
                                <td class="fw-bold">Units In Stock
                                </td>
                                <td class="text-md-end">
                                    <%# Item.UnitsInStock %>
                                </td>
                            </tr>
                            <tr>
                                <td class="fw-bold">Units on Order
                                </td>
                                <td class="text-md-end">
                                    <%# Item.UnitsOnOrder %>
                                </td>
                            </tr>
                            <tr>
                                <td class="fw-bold">Reorder Level
                                </td>
                                <td class="text-md-end">
                                    <%# Item.ReorderLevel %>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-12 mt-2">
                        <h4>Supplier Info</h4>
                        <table class="table table-sm table-light">
                            <tr>
                                <td class="fw-bold">ID
                                </td>
                                <td>
                                    <%# Item.Supplier.Id %>
                                </td>
                            </tr>
                            <tr>
                                <td class="fw-bold">Name
                                </td>
                                <td>
                                    <%# Item.Supplier.CompanyName %>
                                </td>
                            </tr>
                            <tr>
                                <td class="fw-bold">Contact
                                </td>
                                <td>
                                    <%# Item.Supplier.ContactName %>
                                </td>
                            </tr>
                            <tr>
                                <td class="fw-bold">Phone Number
                                </td>
                                <td>
                                    <%# Item.Supplier.Address?.Phone == null ? "N/A" : Item.Supplier.Address.Phone %>
                                </td>
                            </tr>
                            <tr>
                                <td class="fw-bold">Address
                                </td>
                                <td>
                                    <%# Item.GetFormatAddress() %>
                                </td>
                            </tr>
                        </table>
                    </div>
            </ItemTemplate>
        </asp:FormView>
        <asp:UpdatePanel ID="upResults" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="col-12 mt-2">
                    <div class="table-responsive">
                        <asp:GridView ID="gvOrders" runat="server"
                            AutoGenerateColumns="false"
                            Width="100%"
                            CellPadding="3"
                            CssClass="table table-sm table-striped table-light"
                            EmptyDataText="No orders available."
                            OnPreRender="gvOrders_PreRender">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Order ID" />
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer" />
                                <asp:TemplateField HeaderText="Order Date">
                                    <ItemTemplate>
                                        <%# Eval("OrderDate") != null ? ((DateTime)Eval("OrderDate")).ToShortDateString() : "N/A" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Required Date">
                                    <ItemTemplate>
                                        <%# Eval("RequiredDate") != null ? ((DateTime)Eval("RequiredDate")).ToShortDateString() : "N/A" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Shipped Date">
                                    <ItemTemplate>
                                        <%# Eval("ShippedDate") != null ? ((DateTime)Eval("ShippedDate")).ToShortDateString() : "N/A" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Freight" HeaderText="Freight" />
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                <asp:TemplateField HeaderText="Unit Price">
                                    <ItemTemplate>
                                        <%# $"${Eval("UnitPrice")}" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Discount">
                                    <ItemTemplate>
                                        <%# $"${Eval("Discount")}" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <ItemTemplate>
                                        <%# $"${Eval("Total")}" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
