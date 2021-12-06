<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ReturnInformationYearly.aspx.cs" Inherits="Admin_ReturnInformationYearly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="flex-row justify-content-center align-items-center mx-auto">

        <h1 id="hstep3" runat="server" class="text-primary font-weight-light">Yearly Return Information :</h1>
        <div class="row shadow rounded-bottom">

            <%--DIV ERROR AND SUCCESS ALERT--%>
            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="alert alert-success alert-dismissible fade show" role="alert" runat="server" visible="false" id="divSuccess">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">&times;</button>
                    <span runat="server" id="lblSuccess" aria-hidden="true">&times;</span>
                </div>

                <div class="alert alert-danger alert-dismissible" runat="server" visible="false" id="divError">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">&times;</button>
                    <span runat="server" id="lblError" aria-hidden="true">&times;</span>
                </div>
            </div>
        </div>



        <div class="row shadow rounded-bottom" style="background-color: #a5d1cc;">
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="txtCustomerId" class="font-weight-bold">Customer Id :</label>
                    <asp:TextBox ID="txtCustomerId" CssClass="form-control form-control-sm" runat="server" required="required"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="txtGstin" class="font-weight-bold">GSTIN :</label>
                    <asp:TextBox ID="txtGstin" CssClass="form-control form-control-sm" runat="server" required="required"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="form-group">
                    <label for="txtFileName" class="font-weight-bold">File Name :</label>
                    <asp:TextBox ID="txtFileName" CssClass="form-control form-control-sm" runat="server" required="required"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="ddlFinancialYear" class="font-weight-bold">Financial Year :</label>
                    <asp:DropDownList ID="ddlFinancialYear" CssClass="form-control form-control-sm" runat="server">
                        <asp:ListItem Selected="True">-- Select Financial Year --</asp:ListItem>
                        <asp:ListItem Value="1">2015-2016</asp:ListItem>
                        <asp:ListItem Value="2">2016-2017</asp:ListItem>
                        <asp:ListItem Value="3">2017-2018</asp:ListItem>
                        <asp:ListItem Value="4">2018-2019</asp:ListItem>
                        <asp:ListItem Value="5">2019-2020</asp:ListItem>
                        <asp:ListItem Value="6">2020-2021</asp:ListItem>
                        <asp:ListItem Value="7">2021-2022</asp:ListItem>
                        <asp:ListItem Value="8">2022-2023</asp:ListItem>
                        <asp:ListItem Value="9">2023-2024</asp:ListItem>
                        <asp:ListItem Value="10">2024-2025</asp:ListItem>
                        <asp:ListItem Value="11">2025-2026</asp:ListItem>
                        <asp:ListItem Value="12">2026-2027</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="ddlType" class="font-weight-bold">Type :</label>
                    <asp:DropDownList ID="ddlType" CssClass="form-control form-control-sm" runat="server">
                        <asp:ListItem Selected="True">-- Select Financial Year --</asp:ListItem>
                        <asp:ListItem Value="1">REGULAR TAXPAYER</asp:ListItem>
                        <asp:ListItem Value="2">COMPASITION TAXPAYER</asp:ListItem>
                        <asp:ListItem Value="3">CASULA TAXPAYER</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="ddlFiledGstr9by4" class="font-weight-bold">FILED GSTR 9 / 4 :</label>
                    <asp:DropDownList ID="ddlFiledGstr9by4" CssClass="form-control form-control-sm" runat="server">
                        <asp:ListItem Selected="True">-- Select  --</asp:ListItem>
                        <asp:ListItem Value="1">Filed</asp:ListItem>
                        <asp:ListItem Value="2">Not Filed</asp:ListItem>
                        <asp:ListItem Value="3">Not Applicable</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="txtFiledGstr9by4On" class="font-weight-bold">FILED ON :</label>
                    <asp:TextBox ID="txtFiledGstr9by4On" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="ddlFiledGstr9c" class="font-weight-bold">FILED GSTR 9 C :</label>
                    <asp:DropDownList ID="ddlFiledGstr9c" CssClass="form-control form-control-sm" runat="server">
                        <asp:ListItem Selected="True">-- Select --</asp:ListItem>
                        <asp:ListItem Value="1">Filed</asp:ListItem>
                        <asp:ListItem Value="2">Not Filed</asp:ListItem>
                        <asp:ListItem Value="3">Not Applicable</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="txtFiledGstr9cOn" class="font-weight-bold">FILED ON :</label>
                    <asp:TextBox ID="txtFiledGstr9cOn" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="form-group">
                    <label for="txtNoteOnGstr9by4" class="font-weight-bold">NOTES ON GSTR 9 / 4 :</label>
                    <asp:TextBox ID="txtNoteOnGstr9by4" CssClass="form-control form-control-sm" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="txtDocFilledAndCheckedBy" class="font-weight-bold">DOCUMENT FILED & CHECKED BY :</label>
                    <asp:TextBox ID="txtDocFilledAndCheckedBy" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="txtVerifiedBy" class="font-weight-bold">VARIFIED BY :</label>
                    <asp:TextBox ID="txtVerifiedBy" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 text-center">
                <asp:Button ID="btnSubmitInformation" runat="server" CssClass="btn  btn-success w-50 mb-3" Text="Submit" OnClick="btnSubmitInformation_Click"></asp:Button>
            </div>
        </div>

        <div class="row shadow rounded-bottom" style="background-color: #a5d1cc;" runat="server" id="divgrvShowRecords" visible="false">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:GridView ID="grvShowRecords" runat="server" CssClass="table table-responsive bg-warning small" Width="100%" GridLines="None"></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

