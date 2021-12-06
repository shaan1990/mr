<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ManageDatabase.aspx.cs" Inherits="Admin_ManageDatabase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <h2 class="text-center text-primary"><i class="fa fa-pencil-square-o pr-1"></i>Manage Database</h2>
            <hr />
        </div>
    </div>

    <%--bootstrap alert dialog--%>
    <div class="alert alert-success alert-dismissible fade show" role="alert" runat="server" visible="false" id="divSuccess">
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">&times;</button>
        <span runat="server" id="lblSuccess" aria-hidden="true">&times;</span>
    </div>

    <div class="alert alert-danger alert-dismissible" runat="server" visible="false" id="divError">
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">&times;</button>
        <span runat="server" id="lblError" aria-hidden="true">&times;</span>
    </div>

    <div class="flex-row justify-content-center align-items-center mx-auto">
        <div class="row shadow rounded-bottom" style="background-color: #a5d1cc;">

            <div class="col-lg-3 col-md-3 col-sm-3">
                <div class="form-group">
                    <label for="txtConcernName">Concern Name :<strong class="text-danger ml-1">*</strong></label>
                    <asp:TextBox ID="txtConcernName" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3">
                <div class="form-group">
                    <label for="txtCustomerCodeForSearch">Customer Code :</label>
                    <asp:TextBox ID="txtCustomerCodeForSearch" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3">
                <div class="form-group">
                    <label for="txtFileNumberForSearch">File Number :</label>
                    <%-- <asp:DropDownList ID="ddlServices" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>--%>
                    <asp:TextBox ID="txtFileNumberForSearch" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3">
                <div class="form-group">
                    <label for="btnSearch"></label>
                    <br />
                    <asp:Button ID="btnSearch" runat="server" Text="Seach" CssClass="btn btn-info btn-sm w-100" OnClick="btnSearch_Click" />
                </div>
            </div>

            <%--show basic details on search--%>
            <div class="col-lg-3 col-md-3 col-sm-3">
                <div class="form-group">
                    <label for="lblFileNumber">File Number :</label>
                    <asp:LinkButton ID="lnkFileNumber" runat="server" CssClass="font-weight-bold small text-primary" OnClick="lnkFileNumber_Click">NA</asp:LinkButton>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3">
                <div class="form-group">
                    <label for="lblCustomerCode">Customer Code :</label>
                    <asp:LinkButton ID="lnkCustomerCode" runat="server" CssClass="font-weight-bold small text-primary" OnClick="lnkCustomerCode_Click">NA</asp:LinkButton>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3">
                <div class="form-group">
                    <label for="lblConcernName">Concern Name :</label>
                    <asp:LinkButton ID="lnkConcernName" runat="server" CssClass="font-weight-bold small text-primary" OnClick="lnkConcernName_Click">NA</asp:LinkButton>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3">
                <div class="form-group">
                    <label for="lblProprietorName">Proprietor / PA Name :</label>
                    <asp:Label ID="lblProprietorName" runat="server" CssClass="font-weight-bold small text-black-50">NA</asp:Label>
                </div>
            </div>


        </div>

        <%--show entire details on search --%>
        <div class="row shadow rounded-bottom mt-2" style="background-color: #a5d1cc;">
            <div class="col-lg-6 col-md-6 col-sm-6">
                <h2 class="text-danger font-weight-light text-center">Concern Details</h2>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <h2 class="text-danger font-weight-light text-center">Person Details</h2>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="txtFileNumber">File Number :</label>
                    <asp:TextBox ID="txtFileNumber" CssClass="form-control form-control-sm" runat="server" PlaceHolder="This is autogenerated"></asp:TextBox>
                    <small id="smallfilenumber" class="form-text text-black-50">** This is a system generated text which is fixed for particular customer for particular service.</small>
                </div>


            </div>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="txtCustomerCode">Customer Code :</label>
                    <asp:TextBox ID="txtCustomerCode" CssClass="form-control form-control-sm" runat="server" PlaceHolder="This is autogenerated"></asp:TextBox>
                    <small id="smallcustomercode" class="form-text text-black-50">** This is a system generated text which is fixed for particular customer for particular service.</small>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="txtConcern">Concern Name :</label>
                    <asp:TextBox ID="txtConcern" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="ddlFirmType">Types of Firm :</label>
                    <asp:DropDownList ID="ddlFirmType" CssClass="form-control form-control-sm" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="ddlPartners">Number of Directors / Partners :</label>
                    <asp:DropDownList ID="ddlPartners" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="ddlConcernDeals">Concern Deals With :</label>
                    <asp:DropDownList ID="ddlConcernDeals" CssClass="form-control form-control-sm" runat="server">
                        <asp:ListItem Selected="True" Value="0">-- Select --</asp:ListItem>
                        <asp:ListItem Value="1">Goods</asp:ListItem>
                        <asp:ListItem Value="2">Services</asp:ListItem>
                        <asp:ListItem Value="3">Services &amp; Goods</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label for="ddlCoreBusiness">Core Business As :</label>
                    <asp:DropDownList ID="ddlCoreBusiness" CssClass="form-control form-control-sm" runat="server">
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label for="ddlCoreBusiness">Concern's Address :</label>
                    <asp:TextBox ID="txtConcernAddress" CssClass="form-control form-control-sm" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                </div>

            </div>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="txtName">Name :</label>
                    <asp:TextBox ID="txtName" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtFatherName">Father's Name :</label>
                    <asp:TextBox ID="txtFatherName" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtEmail">Email :</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtContact">Contact :</label>
                    <asp:TextBox ID="txtContact" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtAdhaar">Adhaar :</label>
                    <asp:TextBox ID="txtAdhaar" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtVoterID">Voter ID :</label>
                    <asp:TextBox ID="txtVoterID" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtPAN">PAN Number :</label>
                    <asp:TextBox ID="txtPAN" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="ddlServices">Service taken on :</label>
                    <asp:DropDownList ID="ddlServicesList" CssClass="form-control form-control-sm" runat="server" AutoPostBack="True"></asp:DropDownList>
                    <small id="smallddlServices" class="form-text text-black-50">** Based on the service selection Your Customer Code and FIle Number will be generated.</small>
                </div>

            </div>
        </div>

        <div class="row shadow rounded-bottom mb-3 p-3" style="background-color: #a5d1cc;">
            <div class="col-lg-4 col-md-4 col-sm-4 text-right">
                <asp:Button ID="btnEdit" runat="server" Text="Edit Details" CssClass="btn btn-warning btn-sm w-50" OnClick="btnEdit_Click"/>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4 text-center">
                <asp:Button ID="btnUpdate" runat="server" Text="Update Details" CssClass="btn btn-success btn-sm w-50" OnClick="btnUpdate_Click"/>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4 text-left">
                <asp:Button ID="btnPrint" runat="server" Text="Print Details" CssClass="btn btn-danger btn-sm w-50"/>
            </div>
        </div>

    </div>
</asp:Content>

