﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="CreateDatabase.aspx.cs" Inherits="Admin_CreateDatabase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdnSteps" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h2 class="text-center text-success"><i class="fa fa-pencil-square-o pr-1"></i>Create Database</h2>
                <hr />
                <h4 runat="server" visible="false" id="titleGenInfo" class="text-center text-secondary"><i class="fa fa-info-circle pr-1"></i>General Information</h4>
                <h4 runat="server" visible="false" id="titleCredInfo" class="text-center text-secondary"><i class="fa fa-key pr-1"></i>Credentials Information</h4>
                <%--<h4 runat="server" visible="false" id="titleReturnInfo" class="text-center text-secondary"><i class="fa fa-sticky-note pr-1"></i>Return Information</h4>--%>
            </div>
        </div>

        <hr />

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


            <div id="divGeneralInformation" runat="server" visible="false">
                <h1 id="hstep1" runat="server" class="text-primary font-weight-light">Step 1:</h1>
                <div class="row shadow rounded-bottom" style="background-color: #a5d1cc;">

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
                            <asp:DropDownList ID="ddlServices" CssClass="form-control form-control-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlServices_SelectedIndexChanged"></asp:DropDownList>
                            <small id="smallddlServices" class="form-text text-black-50">** Based on the service selection Your Customer Code and FIle Number will be generated.</small>
                        </div>


                    </div>

                </div>
            </div>
            <div id="divCredentialInformation" runat="server" visible="false">
                <h1 id="hstep2" runat="server" class="text-primary font-weight-light">Step 2:</h1>
                <div class="row shadow rounded-bottom" style="background-color: #a5d1cc;">
                    <div class="col-md-6 col-lg-6 col-sm-6 login-form-2 shadow p-3 rounded">
                        <h2 class="text-danger font-weight-light">Generate Password</h2>
                        <br />

                        <div class="form-group">
                            <span class="text-secondary font-weight-bold"><i class="fa fa-vcard pr-1"></i>Customer Id :</span>
                            <%--<asp:DropDownList ID="ddlCustomers" class="form-control form-control-sm" runat="server"></asp:DropDownList>--%>
                            <asp:TextBox ID="txtCustomerId" class="form-control form-control-sm" runat="server"></asp:TextBox>
                        </div>

                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <%--<span class="text-primary font-weight-bold">Click here to generate Strong random password : </span>--%>
                                <asp:Button ID="btnGeneratepw" runat="server" Text="Generate Password" CssClass="btn btn-success btn-sm" OnClick="btnGeneratepw_Click" />
                            </div>
                        </div>

                        <div class="form-group">
                            <span class="text-secondary font-weight-bold"><i class="fa fa-key pr-1"></i>Password :</span>
                            <%--<input type="text" id="txtPassword" runat="server" class="form-control form-control-sm" placeholder="You may also create your custom password by writing here *" value="" />--%>
                            <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-sm" placeholder="You may also create your custom password by writing here *"></asp:TextBox>
                        </div>

                        <div class="form-group text-center">
                            <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-info btn-sm rounded w-50" OnClick="btnReset_Click" />
                        </div>

                        <hr />
                        <div class="form-group">
                            <a id="hbacktologin" href="../LoginPage.aspx" class="btn btn-link "><span class="text-primary text-decoration-none pr-1"><i class="fa fa-backward pr-1"></i>Back to Login</span></a>
                        </div>

                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-6 login-form-2 bg-primary text-white shadow p-3 rounded">
                        <h1>Password Policies</h1>

                        <span class="lead text-white-50">New Password must follow these below criterias :</span>
                        <hr />

                        <ul>
                            <li>Make your password eight characters or longer. </li>
                            <li>Don’t make passwords easy to guess. </li>
                            <li>Use a passphrase, then add in some punctuation and capitalization. </li>
                            <li>Use Numeric values for better creating an alphanumeric combination. </li>
                            <li>Do not include personal information such as your name or pets’ names easily to find on social media. </li>
                            <li>Avoid using common words in your password. </li>
                            <li>Avoid using common words in your password. </li>
                            <li>Never share your password</li>
                        </ul>

                    </div>

                </div>
            </div>

            <br />
            <div id="divButton">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <asp:Button ID="btnBack" CssClass="btn btn-warning btn-sm" runat="server" Text="Back" OnClick="btnBack_Click" />
                        <asp:Button ID="btnSaveGeneralInformation" CssClass="btn btn-primary btn-sm" runat="server" Text="Step 2" OnClick="btnSaveGeneralInformation_Click" />
                    </div>
                </div>
            </div>


        </div>
    </div>

    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="../js/md5hash.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#ContentPlaceHolder1_btnReset').click(function () {
                if ($('#ContentPlaceHolder1_txtPassword').val().length > 0) {
                    var password = $('#ContentPlaceHolder1_txtPassword').val().trim();
                    $('#ContentPlaceHolder1_txtPassword').val(MD5(password));
                }
            });

            $('#ContentPlaceHolder1_btnSaveGeneralInformation').click(function () {
                if ($('#ContentPlaceHolder1_txtPassword').val().length > 0) {
                    var password = $('#ContentPlaceHolder1_txtPassword').val().trim();
                    $('#ContentPlaceHolder1_txtPassword').val(MD5(password));
                }
            });
        });
    </script>
</asp:Content>

