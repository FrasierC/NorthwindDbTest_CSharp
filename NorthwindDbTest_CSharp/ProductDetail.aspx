<%@ Page Title="Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="NorthwindDbTest_CSharp.ProductDetail" %>

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
    </div>
</asp:Content>
