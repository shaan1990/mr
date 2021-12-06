<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ReturnInformation.aspx.cs" Inherits="Admin_ReturnInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="flex-row justify-content-center align-items-center mx-auto">

        <h1 id="hstep3" runat="server" class="text-primary font-weight-light">Return Information:</h1>
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


            <%--Name and email and Contact--%>

            <div class="col-lg-4 col-md-4 col-sm-4">
                Customer Id :
                <div class="form-group">
                    <%--<label for="txtCustomerId" class="font-weight-normal">Customer Id :</label>--%>
                    <asp:TextBox ID="txtCustomerId" CssClass="form-control form-control-sm" runat="server" required="required"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-4 col-md-4 col-sm-4 mt-4">
                <div class="form-group">
                    <asp:Button ID="btnFindCustomer" runat="server" Text="Find Client's File Number" CssClass="btn btn-primary btn-sm w-100" OnClick="btnFindCustomer_Click" />
                </div>
            </div>

            <div class="col-lg-4 col-md-4 col-sm-4">
                File Number :
                <div class="form-group">
                    <%-- <label for="ddlFileNumbers" class="font-weight-normal">File Numbers :</label>--%>
                    <asp:DropDownList ID="ddlFileNumbers" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="form-group">
                    <asp:Button ID="btnOpen" runat="server" Text="Open File and Return Information" CssClass="btn btn-primary btn-sm w-100" OnClick="btnOpen_Click" />
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-6" hidden="hidden">
                <div class="card mt-2 bg-transparent">
                    <div class="card-body">
                        <div class="form-group">
                            <label for="ddlServices" class="font-weight-normal">Add more services :</label>
                            <asp:DropDownList ID="ddlServices" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="txtPanForAddNewService" class="font-weight-normal">PAN :</label>
                            <asp:TextBox ID="txtPanForAddNewService" CssClass="form-control form-control-sm" runat="server" placeholder="PAN Number must provide to add new Service."></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnAddMoreServices" runat="server" Text="Add Services" CssClass="btn btn-success btn-sm" OnClick="btnAddMoreServices_Click" />
                        </div>
                    </div>
                </div>

            </div>

        </div>
        <hr />


        <div id="divReturnInformation" runat="server">
            <%--PROFESSIONAL TAX--%>
            <div class="row shadow rounded-bottom" style="background-color: #a5d1cc;" id="PTAXService" runat="server" visible="false">

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3 class="text-secondary font-weight-light">Application for Profession Tax</h3>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtRoadStreet" class="font-weight-normal">Name of the Applicant :</label>
                        <asp:TextBox ID="txtapplicantnamePTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtRoadStreet" class="font-weight-normal">Name of the Establishment :</label>
                        <asp:TextBox ID="txtestablishmentnamePTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtRoadStreet" class="font-weight-normal">Establishment Address :</label>
                        <asp:TextBox ID="txtestablishmentaddressPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlDistrictPTAX" class="font-weight-normal">District :</label>
                        <%--<asp:TextBox ID="txtDistrictPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddlDistrictPTAX" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>

                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtPinPTAX" class="font-weight-normal">PIN Code :</label>
                        <asp:TextBox ID="txtPinPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtMobilePTAX" class="font-weight-normal">Mobile :</label>
                        <asp:TextBox ID="txtMobilePTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtEmailPTAX" class="font-weight-normal">Email :</label>
                        <asp:TextBox ID="txtEmailPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtJurisdictionPTAX" class="font-weight-normal">Area of Jurisdiction :</label>
                        <asp:TextBox ID="txtJurisdictionPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtChargePTAX" class="font-weight-normal">Charge :</label>
                        <asp:TextBox ID="txtChargePTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlEngageWithPTAX" class="font-weight-normal">Select Engage with :</label>
                        <asp:DropDownList ID="ddlEngageWithPTAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Engagement --</asp:ListItem>
                            <asp:ListItem Value="1">Profession</asp:ListItem>
                            <asp:ListItem Value="2">Trade</asp:ListItem>
                            <asp:ListItem Value="3">Calling</asp:ListItem>
                            <asp:ListItem Value="4">Employment</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlCategoryPTAX" class="font-weight-normal">Select Category :</label>
                        <asp:DropDownList ID="ddlCategoryPTAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Category --</asp:ListItem>
                            <asp:ListItem Value="1">Profession</asp:ListItem>
                            <asp:ListItem Value="2">Trade</asp:ListItem>
                            <asp:ListItem Value="3">Calling</asp:ListItem>
                            <asp:ListItem Value="4">Employment</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlSubcategoryPTAX" class="font-weight-normal">Select Sub-Category :</label>
                        <asp:DropDownList ID="ddlSubcategoryPTAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select SubCategory --</asp:ListItem>
                            <asp:ListItem Value="1">Profession</asp:ListItem>
                            <asp:ListItem Value="2">Trade</asp:ListItem>
                            <asp:ListItem Value="3">Calling</asp:ListItem>
                            <asp:ListItem Value="4">Employment</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>



                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtDateOfCommencementPTAX" class="font-weight-normal">Date of Commencement :</label>
                        <asp:TextBox ID="txtDateOfCommencementPTAX" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtPanTanPTAX" class="font-weight-normal">PAN/TAN :</label>
                        <asp:TextBox ID="txtPanTanPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <%-- <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtDateOfCommencement" class="font-weight-normal">Date of Commencement :</label>
                        <asp:TextBox ID="TextBox4" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>--%>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtGSTINPTAX" class="font-weight-normal">GSTIN :</label>
                        <asp:TextBox ID="txtGSTINPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="rdVehiclesPTAX" class="font-weight-normal">Choose Vehicles Category :</label>
                        <asp:RadioButtonList ID="rdVehiclesPTAX" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Good Vehicles</asp:ListItem>
                            <asp:ListItem Value="2">Three Wheelers</asp:ListItem>
                            <asp:ListItem Value="3">Light Motor Vehicles</asp:ListItem>
                            <asp:ListItem Value="4">Taxis</asp:ListItem>
                            <asp:ListItem Value="5">Trucks</asp:ListItem>
                            <asp:ListItem Value="6">Buses</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h4 class="text-info font-weight-normal">If engaged with Co-operative Society, Please select :</h4>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <asp:RadioButtonList ID="rbLevelSocietyPTAX" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">State Level Society</asp:ListItem>
                        <asp:ListItem Value="2">District Level Society</asp:ListItem>
                    </asp:RadioButtonList>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtUserNamePTAX" class="font-weight-normal">Username :</label>
                        <asp:TextBox ID="txtUserNamePTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtPasswordPTAX" class="font-weight-normal">Password :</label>
                        <asp:TextBox ID="txtPasswordPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtEnrolmentNoPTAX" class="font-weight-normal">ENROLMENT NUMBER / PTAN :</label>
                        <asp:TextBox ID="txtEnrolmentNoPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtApplicationNumberPTAX" class="font-weight-normal">APPLICATION NUMBER :</label>
                        <asp:TextBox ID="txtApplicationNumberPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtTaxPeriodPTAX" class="font-weight-normal">TAX PERIOD / YEAR :</label>
                        <asp:TextBox ID="txtTaxPeriodPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtPaymentDatePTAX" class="font-weight-normal">PAYMENT DATE :</label>
                        <asp:TextBox ID="txtPaymentDatePTAX" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtAmountPTAX" class="font-weight-normal">AMOUNT :</label>
                        <asp:TextBox ID="txtAmountPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtPaymentReqNoPTAX" class="font-weight-normal">PAYMENT REQUEST NUMBER :</label>
                        <asp:TextBox ID="txtPaymentReqNoPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>




                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtGRNPTAX" class="font-weight-normal">GRN :</label>
                        <asp:TextBox ID="txtGRNPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtCINPTAX" class="font-weight-normal">CIN :</label>
                        <asp:TextBox ID="txtCINPTAX" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtTransactionStatsPTAX" class="font-weight-normal">TRANSACTION STATUS :</label>
                        <asp:TextBox ID="txtTransactionStatsPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 text-center">
                    <asp:Button ID="btnSavePtaxInfo" runat="server" CssClass="btn  btn-success w-50 mb-3" Text="Save PTAX Info" OnClick="btnSavePtaxInfo_Click"></asp:Button>
                </div>

            </div>

            <%--INCOME TAX--%>
            <div class="row shadow rounded-bottom" style="background-color: #a5d1cc;" id="INCOMETAXService" runat="server" visible="false">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3 class="text-secondary font-weight-light">Application for Income Tax</h3>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlApplyingAsITAX" class="font-weight-normal">Applying As :</label>
                        <asp:DropDownList ID="ddlApplyingAsITAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Category --</asp:ListItem>
                            <asp:ListItem Value="1">Individual</asp:ListItem>
                            <asp:ListItem Value="2">HUF</asp:ListItem>
                            <asp:ListItem Value="3">Other than HUF</asp:ListItem>
                            <asp:ListItem Value="4">Tax Ductor or Collector</asp:ListItem>
                        </asp:DropDownList>
                    </div>


                    <div class="form-group">
                        <label for="txtApplicantNameITAX" class="font-weight-normal">Name of the Applicant :</label>
                        <asp:TextBox ID="txtApplicantNameITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>


                    <div class="form-group">
                        <label for="txtPanITAX" class="font-weight-normal">PAN :</label>
                        <asp:TextBox ID="txtPanITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>


                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtMobileITAX" class="font-weight-normal">Mobile :</label>
                        <asp:TextBox ID="txtMobileITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>


                    <div class="form-group">
                        <label for="txtEmailITAX" class="font-weight-normal">Email :</label>
                        <asp:TextBox ID="txtEmailITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>

                </div>


                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h4 class="text-info font-weight-normal">Residential Address</h4>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtRoadStreetITAX" class="font-weight-normal">ROAD / STREET / BLOCK / SECTOR :</label>
                        <asp:TextBox ID="txtRoadStreetITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtAreaLocalityITAX" class="font-weight-normal">AREA / LOCALITY :</label>
                        <asp:TextBox ID="txtAreaLocalityITAX" CssClass="form-control form-control-sm" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtPostOfficeITAX" class="font-weight-normal">POST OFFICE :</label>
                        <asp:TextBox ID="txtPostOfficeITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="ddlStateITAX" class="font-weight-normal">STATE :</label>
                        <%--<asp:TextBox ID="txtStateITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddlStateITAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select State --</asp:ListItem>
                            <asp:ListItem Value="1">Tripura</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="ddlCountryITAX" class="font-weight-normal">COUNTRY :</label>
                        <%--<asp:TextBox ID="txtCountryITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddlCountryITAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Country --</asp:ListItem>
                            <asp:ListItem Value="1">INDIA</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtPinITAX" class="font-weight-normal">PIN :</label>
                        <asp:TextBox ID="txtPinITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>



                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtUsernameITAX" class="font-weight-normal">USERNAME :</label>
                        <asp:TextBox ID="txtUsernameITAX" CssClass="form-control form-control-sm" runat="server" PlaceHolder="This must be your PAN Number."></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtPasswordITAX" class="font-weight-normal">PASSWORD :</label>
                        <asp:TextBox ID="txtPasswordITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtTransactionIdITAX" class="font-weight-normal">TRANSACTION ID :</label>
                        <asp:TextBox ID="txtTransactionIdITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>



                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlFinancialYearITAX" class="font-weight-normal">Financial Year :</label>
                        <asp:DropDownList ID="ddlFinancialYearITAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Financial Year --</asp:ListItem>
                            <asp:ListItem Value="1">2017-2018</asp:ListItem>
                            <asp:ListItem Value="2">2018-2019</asp:ListItem>
                            <asp:ListItem Value="3">2019-2020</asp:ListItem>
                            <asp:ListItem Value="4">2020-2021</asp:ListItem>
                            <asp:ListItem Value="4">2021-2022</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlAssessmentITAX" class="font-weight-normal">Assessment Year :</label>
                        <asp:DropDownList ID="ddlAssessmentITAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Assessment Year --</asp:ListItem>
                            <asp:ListItem Value="1">2017-2018</asp:ListItem>
                            <asp:ListItem Value="2">2018-2019</asp:ListItem>
                            <asp:ListItem Value="3">2019-2020</asp:ListItem>
                            <asp:ListItem Value="4">2020-2021</asp:ListItem>
                            <asp:ListItem Value="4">2021-2022</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>


                <div class="col-lg-12 col-md-12 col-sm-12">
                    <label for="ddlReturnTypeITAX" class="font-weight-normal">Return Type :</label>
                    <asp:DropDownList ID="ddlReturnTypeITAX" CssClass="form-control form-control-sm" runat="server">
                        <asp:ListItem Selected="True" Value="0">-- Select Return Type --</asp:ListItem>
                        <asp:ListItem Value="1">NORMAL TAX RETURN</asp:ListItem>
                        <asp:ListItem Value="2">NORMAL RETURN WITH AUDITOR CERTIFICATE</asp:ListItem>
                        <asp:ListItem Value="3">NORMAL TDS RETURN</asp:ListItem>
                        <asp:ListItem Value="4">SALARY RETURN</asp:ListItem>
                        <asp:ListItem Value="5">TAX AUDIT RETURN</asp:ListItem>
                        <asp:ListItem Value="6">NORMAL RETURN WITH ESTIMATED & PROJECT TPL & BS	</asp:ListItem>
                        <asp:ListItem Value="7">NORMAL RETURN WITH ESTIMATED & PROJECT TPL & BS & AUDIT REPORT</asp:ListItem>
                        <asp:ListItem Value="8">TAX AUDIT RETURN WITH ESTIMATED & PROJECT TPL & BS</asp:ListItem>
                    </asp:DropDownList>
                </div>



                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbform26asITAX" class="font-weight-normal">DOWNLOAD FROM 26AS :</label>
                        <asp:RadioButtonList ID="rbform26asITAX" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtReturnFormITAX" class="font-weight-normal">Return Form :</label>
                        <asp:TextBox ID="txtReturnFormITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>



                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtTaxPaymentITAX" class="font-weight-normal">Tax Payment :</label>
                        <asp:TextBox ID="txtTaxPaymentITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtBrsCodeITAX" class="font-weight-normal">BRS Code :</label>
                        <asp:TextBox ID="txtBrsCodeITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtReturnFilledDateITAX" class="font-weight-normal">RETURN FILED DATE :</label>
                        <asp:TextBox ID="txtReturnFilledDateITAX" CssClass="form-control form-control-sm" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtITAcknowledgementITAX" class="font-weight-normal">ITR-V (IT ACKNOWLEDGEMENT) :</label>
                        <asp:TextBox ID="txtITAcknowledgementITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3">
                    <asp:Button ID="btnSaveItaxInfoITAX" runat="server" Text="Save ITAX Info" CssClass="btn btn-success w-50" OnClick="btnSaveItaxInfo_Click" />
                </div>



            </div>

            <%--RUBBER BOARD--%>
            <div class="row shadow rounded-bottom" style="background-color: #a5d1cc;" id="RUBBERBOARDService" runat="server" visible="false">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3 class="text-secondary font-weight-light ">Application for Rubber Board</h3>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3 class="text-BLACK font-weight-BOLD">CORE INFORMATION OF RUBBER BOARD RETURN SERVICES</h3>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <%--<div class="form-group mb-0">--%>
                    <label for="txtCustomerCodeRBR" class="font-weight-normal">CustomerCode :</label>
                    <asp:TextBox ID="txtCustomerCodeRBR" CssClass="form-control form-control-sm  mt-0" runat="server"></asp:TextBox>
                    <%--</div>--%>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtFileNumberRBR" class="font-weight-normal">File Number :</label>
                    <asp:TextBox ID="txtFileNumberRBR" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtDealershipNoRBR" class="font-weight-normal">Dealership Number :</label>
                    <asp:TextBox ID="txtDealershipNoRBR" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtLicenceValidTillRBR" class="font-weight-normal">Licence Valid Till :</label>
                    <asp:TextBox ID="txtLicenceValidTillRBR" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>

                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtConcernNameRBR" class="font-weight-normal">Name of the Concern :</label>
                    <asp:TextBox ID="txtConcernNameRBR" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtOwnerNameRBR" class="font-weight-normal">Owner Name :</label>
                    <asp:TextBox ID="txtOwnerNameRBR" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtMobielRBR" class="font-weight-normal">Mobile :</label>
                    <asp:TextBox ID="txtMobielRBR" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtEmailRBR" class="font-weight-normal">Email:</label>
                    <asp:TextBox ID="txtEmailRBR" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>

                <%--BUSINESS PLACE--%>
                <%--=====================================--%>
                <div class="col-lg-12 col-md-12 col-sm-12">

                    <label for="txtBusinessPlaceRB_BSP" class="font-weight-normal">Business and Storage Place :</label>
                    <asp:TextBox ID="txtBusinessPlaceRB_BSP" CssClass="form-control form-control-sm" TextMode="MultiLine" runat="server"></asp:TextBox>

                </div>
                <%--BUSINESS PLACE :  building type, building no, city, district--%>

                <div class="col-lg-3 col-md-3 col-sm-3">

                    <label for="txtBuildingTypeRB_BSP" class="font-weight-normal">Building Type :</label>
                    <asp:TextBox ID="txtBuildingTypeRB_BSP" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">

                    <label for="txtBuildingPlotNoRB_BSP" class="font-weight-normal">Building / Plot No  :</label>
                    <asp:TextBox ID="txtBuildingPlotNoRB_BSP" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">

                    <label for="txtCityRB_BSP" class="font-weight-normal">City :</label>
                    <asp:TextBox ID="txtCityRB_BSP" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">

                    <label for="ddlDistrictRB_BSP" class="font-weight-normal">District :</label>
                    <asp:DropDownList ID="ddlDistrictRB_BSP" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>

                </div>

                <%-- BUSINESS PLACE : state, pin, mobile, email--%>

                <div class="col-lg-3 col-md-3 col-sm-3">

                    <label for="ddlStateRB_BSP" class="font-weight-normal">State :</label>
                    <asp:DropDownList ID="ddlStateRB_BSP" CssClass="form-control form-control-sm" runat="server">
                        <asp:ListItem Selected="True" Value="0">-- Select State --</asp:ListItem>
                        <asp:ListItem Value="1">Tripura</asp:ListItem>
                    </asp:DropDownList>

                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">

                    <label for="txtPINRB_BSP" class="font-weight-normal">PIN  :</label>
                    <asp:TextBox ID="txtPINRB_BSP" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">

                    <label for="txtMobileRB_BSP" class="font-weight-normal">Mobile :</label>
                    <asp:TextBox ID="txtMobileRB_BSP" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">

                    <label for="txtEmailRB_BSP" class="font-weight-normal">Email :</label>
                    <asp:TextBox ID="txtEmailRB_BSP" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>



                <%--  PRESENT & PERMANENT ADDRESS--%>
                <%--=====================================--%>
                <div class="col-lg-12 col-md-12 col-sm-12">

                    <label for="txtPresentPermanentAddressRB_PPA" class="font-weight-normal">Present & Permanent Address :</label>
                    <asp:TextBox ID="txtPresentPermanentAddressRB_PPA" CssClass="form-control form-control-sm" TextMode="MultiLine" runat="server"></asp:TextBox>

                </div>

                <%-- PRESENT & PERMANENT : city, district, state, pin--%>

                <div class="col-lg-3 col-md-3 col-sm-3">

                    <label for="txtCityRB_PPA" class="font-weight-normal">City :</label>
                    <asp:TextBox ID="txtCityRB_PPA" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">

                    <label for="ddlDistrictRB_Address_PPA" class="font-weight-normal">District :</label>
                    <asp:DropDownList ID="ddlDistrictRB_Address_PPA" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>

                </div>

                <div class="col-lg-3 col-md-3 col-sm-3">

                    <label for="ddlStateRB_PPA" class="font-weight-normal">State :</label>
                    <asp:DropDownList ID="ddlStateRB_PPA" CssClass="form-control form-control-sm" runat="server">
                        <asp:ListItem Selected="True" Value="0">-- Select State --</asp:ListItem>
                        <asp:ListItem Value="1">Tripura</asp:ListItem>
                    </asp:DropDownList>

                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">

                    <label for="txtPINRB_PPA" class="font-weight-normal">PIN  :</label>
                    <asp:TextBox ID="txtPINRB_PPA" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>


              <%--  <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3">
                    <asp:CheckBox ID="chkAgreeRubber" runat="server" />
                    <span class="font-weight-normal text-danger">I hereby solemnly affirm and declare that the information given herein above is true and corrent to the best of my knowledge and belief and nothing has been concealed therefrom.</span>
                </div>--%>


                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtUsernameRBR_PPA" class="font-weight-normal">Username :</label>
                    <asp:TextBox ID="txtUsernameRBR_PPA" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtPasswordRBR_PPA" class="font-weight-normal">Password :</label>
                    <asp:TextBox ID="txtPasswordRBR_PPA" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>


                <div class="col-lg-4 col-md-4 col-sm-4">

                    <label for="txtAmmendmentMadeOnRBR_PPA" class="font-weight-normal">Ammendment Mage On :</label>
                    <asp:TextBox ID="txtAmmendmentMadeOnRBR_PPA" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>

                <div class="col-lg-4 col-md-4 col-sm-4">

                    <label for="txtApplicationNumberRBR_PPA" class="font-weight-normal">Application Number :</label>
                    <asp:TextBox ID="txtApplicationNumberRBR_PPA" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>

                <div class="col-lg-4 col-md-4 col-sm-4">

                    <label for="txtDateRBR_PPA" class="font-weight-normal">Date :</label>
                    <asp:TextBox ID="txtDateRBR_PPA" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>

                </div>
                <%--financial year , return L, return H2--%>
                <div class="col-lg-4 col-md-4 col-sm-4">

                    <label for="ddlFinancialYearRBR_PPA" class="font-weight-normal">Financial Year :</label>
                    <asp:DropDownList ID="ddlFinancialYearRBR_PPA" CssClass="form-control form-control-sm" runat="server">
                        <asp:ListItem Selected="True">-- Select Financial Year --</asp:ListItem>
                        <asp:ListItem Value="1">2017-2018</asp:ListItem>
                        <asp:ListItem Value="2">2018-2019</asp:ListItem>
                        <asp:ListItem Value="3">2019-2020</asp:ListItem>
                        <asp:ListItem Value="4">2020-2021</asp:ListItem>
                        <asp:ListItem Value="5">2021-2022</asp:ListItem>
                    </asp:DropDownList>

                </div>

                <div class="col-lg-4 col-md-4 col-sm-4">

                    <label for="ddlReturnH2RBR_PPA" class="font-weight-normal">Return H2 :</label>
                    <asp:DropDownList ID="ddlReturnH2RBR_PPA" CssClass="form-control form-control-sm" runat="server">
                        <asp:ListItem Selected="True">-- Select Month --</asp:ListItem>
                        <asp:ListItem Value="1">January</asp:ListItem>
                        <asp:ListItem Value="2">February</asp:ListItem>
                        <asp:ListItem Value="3">March</asp:ListItem>
                        <asp:ListItem Value="4">April</asp:ListItem>
                        <asp:ListItem Value="5">May</asp:ListItem>
                        <asp:ListItem Value="6">June</asp:ListItem>
                        <asp:ListItem Value="7">July</asp:ListItem>
                        <asp:ListItem Value="8">August</asp:ListItem>
                        <asp:ListItem Value="9">September</asp:ListItem>
                        <asp:ListItem Value="10">October</asp:ListItem>
                        <asp:ListItem Value="11">November</asp:ListItem>
                        <asp:ListItem Value="12">December</asp:ListItem>
                    </asp:DropDownList>

                </div>

                <div class="col-lg-4 col-md-4 col-sm-4">

                    <label for="ddlReturnLRBR_PPA" class="font-weight-normal">Return L :</label>
                    <asp:DropDownList ID="ddlReturnLRBR_PPA" CssClass="form-control form-control-sm" runat="server">
                        <asp:ListItem Selected="True">-- Select Month --</asp:ListItem>
                        <asp:ListItem Value="1">January</asp:ListItem>
                        <asp:ListItem Value="2">February</asp:ListItem>
                        <asp:ListItem Value="3">March</asp:ListItem>
                        <asp:ListItem Value="4">April</asp:ListItem>
                        <asp:ListItem Value="5">May</asp:ListItem>
                        <asp:ListItem Value="6">June</asp:ListItem>
                        <asp:ListItem Value="7">July</asp:ListItem>
                        <asp:ListItem Value="8">August</asp:ListItem>
                        <asp:ListItem Value="9">September</asp:ListItem>
                        <asp:ListItem Value="10">October</asp:ListItem>
                        <asp:ListItem Value="11">November</asp:ListItem>
                        <asp:ListItem Value="12">December</asp:ListItem>
                    </asp:DropDownList>

                </div>


                <div class="col-lg-12 col-md-12 col-sm-12 text-center mt-3">
                    <asp:Button ID="btnSaveRubberInfo" runat="server" Text="Save Rubber Info" CssClass="btn btn-success w-25" OnClick="btnSaveRubberInfo_Click" />
                    <asp:Button ID="btnUpdateRubber" runat="server" Text="Update Rubber Info" CssClass="btn btn-warning w-25" Visible="false" OnClick="btnUpdateRubber_Click" />
                </div>


            </div>


            <%--DSC--%>
            <div class="row shadow rounded-bottom" style="background-color: #a5d1cc;" id="DSCService" runat="server" visible="false">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3 class="text-secondary font-weight-light">Return information for DSC</h3>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtCustomerCodeDSC" class="font-weight-normal">Customer Code :</label>
                    <asp:TextBox ID="txtCustomerCodeDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtFileNumberDSC" class="font-weight-normal">File Number :</label>
                    <asp:TextBox ID="txtFileNumberDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>


                <div class="col-lg-4 col-md-4 col-sm-4">

                    <label for="txtApplicantNameDSC" class="font-weight-normal">Name of the Applicant :</label>
                    <asp:TextBox ID="txtApplicantNameDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">

                    <label for="txtEstablishmentNameDSC" class="font-weight-normal">Name of the Establishment :</label>
                    <asp:TextBox ID="txtEstablishmentNameDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">

                    <label for="txtDOBDSC" class="font-weight-normal">DOB :</label>
                    <asp:TextBox ID="txtDOBDSC" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>

                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtMobileDSC" class="font-weight-normal">Mobile :</label>
                    <asp:TextBox ID="txtMobileDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtEmailDSC" class="font-weight-normal">Email :</label>
                    <asp:TextBox ID="txtEmailDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>


                <div class="col-lg-12 col-md-12 col-sm-12">

                    <label for="txtAddressDSC" class="font-weight-normal">Address :</label>
                    <asp:TextBox ID="txtAddressDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="ddlDistrictDSC" class="font-weight-normal">District :</label>
                    <asp:DropDownList ID="ddlDistrictDSC" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>

                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtPINDSC" class="font-weight-normal">PIN :</label>
                    <asp:TextBox ID="txtPINDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtShareCodeDSC" class="font-weight-normal">Share Code :</label>
                    <asp:TextBox ID="txtShareCodeDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtChallengeCodeDSC" class="font-weight-normal">Challenge Code :</label>
                    <asp:TextBox ID="txtChallengeCodeDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtDesiredUserNameDSC" class="font-weight-normal">Desired User Name (E-Sign) :</label>
                    <asp:TextBox ID="txtDesiredUserNameDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtDesiredPasswordDSC" class="font-weight-normal">Desired Password (E-Sign)  :</label>
                    <asp:TextBox ID="txtDesiredPasswordDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtApplicationNumberDSC" class="font-weight-normal">Application Number :</label>
                    <asp:TextBox ID="txtApplicationNumberDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtDatedDSC" class="font-weight-normal">Dated :</label>
                    <asp:TextBox ID="txtDatedDSC" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>

                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtEtokenPWDSC" class="font-weight-normal">E-Token Password :</label>
                    <asp:TextBox ID="txtEtokenPWDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">

                    <label for="txtDSCValidUptoDSC" class="font-weight-normal">DSC Valid Upto :</label>
                    <asp:TextBox ID="txtDSCValidUptoDSC" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>

                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 text-center mt-3">
                    <div class="form-group">
                        <asp:Button ID="btnSaveDSCInfo" runat="server" Text="Save DSC Info" CssClass="btn btn-success w-25" OnClick="btnSaveDSCInfo_Click1" />
                        <asp:Button ID="btnUpdateDSCInfo" runat="server" Text="Update DSC Info" CssClass="btn btn-warning w-25" OnClick="btnUpdateDSCInfo_Click" />
                    </div>
                </div>

            </div>


            <%--GST--%>
            <div class="row shadow rounded-bottom" style="background-color: #a5d1cc;" id="GSTService" runat="server" visible="false">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3 class="text-secondary font-weight-light">Return information for GST</h3>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">

                    <label for="txtGSTINGST" class="font-weight-normal">GSTIN :</label>
                    <asp:TextBox ID="txtGSTINGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>

                </div>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtFileNameGST" class="font-weight-normal">File Name :</label>
                        <asp:TextBox ID="txtFileNameGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtSerialNumberGST" class="font-weight-normal">Serial Number :</label>
                        <asp:TextBox ID="txtSerialNumberGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtCustomerCodeGST" class="font-weight-normal">Customer Code :</label>
                        <asp:TextBox ID="txtCustomerCodeGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtConcernNameGST" class="font-weight-normal">Concern Name :</label>
                        <asp:TextBox ID="txtConcernNameGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtConcernAddressGST" class="font-weight-normal">Concern Address :</label>
                        <asp:TextBox ID="txtConcernAddressGST" TextMode="MultiLine" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtUsernameGST" class="font-weight-normal">Username :</label>
                        <asp:TextBox ID="txtUsernameGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtPasswordGST" class="font-weight-normal">Password :</label>
                        <asp:TextBox ID="txtPasswordGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtDateOfRegistrationGST" class="font-weight-normal">Date of Registration :</label>
                        <asp:TextBox ID="txtDateOfRegistrationGST" TextMode="Date" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlRegistrationTypeGST" class="font-weight-normal">Registration Type :</label>
                        <asp:DropDownList ID="ddlRegistrationTypeGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Registration Type --</asp:ListItem>
                            <asp:ListItem Value="1">REGULAR TAXPAYER</asp:ListItem>
                            <asp:ListItem Value="2">COMPASITION TAXPAYER</asp:ListItem>
                            <asp:ListItem Value="3">CASULA TAXPAYER</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtMobileGST" class="font-weight-normal">Mobile :</label>
                        <asp:TextBox ID="txtMobileGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtEmailGST" class="font-weight-normal">Email :</label>
                        <asp:TextBox ID="txtEmailGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlChallanMadeOnGST" class="font-weight-normal">Challan Made On :</label>
                        <asp:DropDownList ID="ddlChallanMadeOnGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Bank --</asp:ListItem>
                            <asp:ListItem Value="1">Bank of Baroda</asp:ListItem>
                            <asp:ListItem Value="2">Bank of India</asp:ListItem>
                            <asp:ListItem Value="3">Canara Bank</asp:ListItem>
                            <asp:ListItem Value="4">Central Bank of India</asp:ListItem>
                            <asp:ListItem Value="5">Indian Bank</asp:ListItem>
                            <asp:ListItem Value="6">Indian Overseas Bank</asp:ListItem>
                            <asp:ListItem Value="7">Punjab and Sind Bank</asp:ListItem>
                            <asp:ListItem Value="8">Punjab National Bank</asp:ListItem>
                            <asp:ListItem Value="9">State Bank of India</asp:ListItem>
                            <asp:ListItem Value="10">UCO Bank</asp:ListItem>
                            <asp:ListItem Value="1">Union Bank of India</asp:ListItem>
                            <asp:ListItem Value="12">Tripura Gramin Bank</asp:ListItem>
                            <asp:ListItem Value="13">Bandhan Bank</asp:ListItem>
                            <asp:ListItem Value="14">Bank of Maharashtra</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlGSTINAssignGST" class="font-weight-normal">GSTIN Assign (Range Officer) :</label>
                        <asp:DropDownList ID="ddlGSTINAssignGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Bank --</asp:ListItem>
                            <asp:ListItem Value="1">Central GST</asp:ListItem>
                            <asp:ListItem Value="2">State GST</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtEwayBillUsernameGST" class="font-weight-normal">E-Way Bill Username :</label>
                        <asp:TextBox ID="txtEwayBillUsernameGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtEwayBillPasswordGST" class="font-weight-normal">E-Way Bill Password :</label>
                        <asp:TextBox ID="txtEwayBillPasswordGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>



                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtCompliancesGST" class="font-weight-normal">Compliances :</label>
                        <asp:TextBox ID="txtCompliancesGST" TextMode="MultiLine" Rows="5" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtActionTakenGST" class="font-weight-normal">Action Taken :</label>
                        <asp:TextBox ID="txtActionTakenGST" TextMode="MultiLine" Rows="5" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtEwayBillPasswordGST" class="font-weight-normal">E-Way Bill Password :</label>
                        <asp:TextBox ID="TextBox1" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtGSTINAssignGST" class="font-weight-normal">GSTIN Assign (Range Officer) :</label>
                        <asp:TextBox ID="txtGSTINAssignGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlMonthGST" class="font-weight-normal">Month :</label>
                        <asp:DropDownList ID="ddlMonthGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select Month --</asp:ListItem>
                            <asp:ListItem Value="1">January</asp:ListItem>
                            <asp:ListItem Value="2">February</asp:ListItem>
                            <asp:ListItem Value="3">March</asp:ListItem>
                            <asp:ListItem Value="4">April</asp:ListItem>
                            <asp:ListItem Value="5">May</asp:ListItem>
                            <asp:ListItem Value="6">June</asp:ListItem>
                            <asp:ListItem Value="7">July</asp:ListItem>
                            <asp:ListItem Value="8">August</asp:ListItem>
                            <asp:ListItem Value="9">September</asp:ListItem>
                            <asp:ListItem Value="10">October</asp:ListItem>
                            <asp:ListItem Value="11">November</asp:ListItem>
                            <asp:ListItem Value="12">December</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlFinancialYearGST" class="font-weight-normal">Financial Year :</label>
                        <asp:DropDownList ID="ddlFinancialYearGST" CssClass="form-control form-control-sm" runat="server">
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
                        <label for="ddlReturnTypeGstr1GST" class="font-weight-normal">RETURN TYPE GSTR 1 :</label>
                        <asp:DropDownList ID="ddlReturnTypeGstr1GST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select Return Type --</asp:ListItem>
                            <asp:ListItem Value="1">Monthly</asp:ListItem>
                            <asp:ListItem Value="2">Quaterly</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlReturnTypeGstr3bGST" class="font-weight-normal">RETURN TYPE GSTR 3B :</label>
                        <asp:DropDownList ID="ddlReturnTypeGstr3bGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select Return Type --</asp:ListItem>
                            <asp:ListItem Value="1">Normal</asp:ListItem>
                            <asp:ListItem Value="2">QRMPS</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <%--sales statement, purchase statement, received on--%>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="ddlSalesStatementGST" class="font-weight-normal">Sales Statement :</label>
                        <asp:DropDownList ID="ddlSalesStatementGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select Sales Statement --</asp:ListItem>
                            <asp:ListItem Value="1">Received</asp:ListItem>
                            <asp:ListItem Value="2">Not Received</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="ddlPurchaseStatementGST" class="font-weight-normal">Purchase Statement :</label>
                        <asp:DropDownList ID="ddlPurchaseStatementGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select Purchase Statement --</asp:ListItem>
                            <asp:ListItem Value="1">Received</asp:ListItem>
                            <asp:ListItem Value="2">Not Received</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtSalesPurchaseStmtGST" class="font-weight-normal">Received On :</label>
                        <asp:TextBox ID="txtSalesPurchaseStmtGST" TextMode="Date" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <%--check eway bill details, filed gstr I/IFF, filed on--%>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="ddlEWayBillDetailsGST" class="font-weight-normal">Check E-Way Bill Details :</label>
                        <asp:DropDownList ID="ddlEWayBillDetailsGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select Sales Statement --</asp:ListItem>
                            <asp:ListItem Value="1">Checked</asp:ListItem>
                            <asp:ListItem Value="2">Not Checked</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="ddlFiledGstrGST" class="font-weight-normal">FILED GSTR I / IFF :</label>
                        <asp:DropDownList ID="ddlFiledGstrGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select Purchase Statement --</asp:ListItem>
                            <asp:ListItem Value="1">Filed</asp:ListItem>
                            <asp:ListItem Value="2">Not Filed</asp:ListItem>
                            <asp:ListItem Value="3">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtEwayFIledGstrOnGST" class="font-weight-normal">Received On :</label>
                        <asp:TextBox ID="txtEwayFIledGstrOnGST" TextMode="Date" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <%--CHECK GSTR 2A & 2B	,CHECK TAX LIABILITIES & COMPARISON	, CHECK TDS & TCS--%>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="ddlCheckGstr2a2bGST" class="font-weight-normal">CHECK GSTR 2A & 2B :</label>
                        <asp:DropDownList ID="ddlCheckGstr2a2bGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Checked</asp:ListItem>
                            <asp:ListItem Value="2">Not Checked</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="ddlCheckLiabilityComparisonGST" class="font-weight-normal">CHECK TAX LIABILITIES & COMPARISON :</label>
                        <asp:DropDownList ID="ddlCheckLiabilityComparisonGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Checked</asp:ListItem>
                            <asp:ListItem Value="2">Not Checked</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="ddlCheckTdsTcsGST" class="font-weight-normal">CHECK TDS & TCS :</label>
                        <asp:DropDownList ID="ddlCheckTdsTcsGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Checked</asp:ListItem>
                            <asp:ListItem Value="2">Not Checked</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <%--RECORD GST RE-CONCILIATION STATEMENT,FILED GSTR 3B / PMT 08, FILED ON	--%>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="ddlReconciliationStatementGST" class="font-weight-normal">RECORD GST RE-CONCILIATION STATEMENT :</label>
                        <asp:DropDownList ID="ddlReconciliationStatementGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Record</asp:ListItem>
                            <asp:ListItem Value="2">Not Record</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="ddlFiledGstr3bpmt8GST" class="font-weight-normal">FILED GSTR 3B / PMT 08 :</label>
                        <asp:DropDownList ID="ddlFiledGstr3bpmt8GST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Filed</asp:ListItem>
                            <asp:ListItem Value="2">Not Filed</asp:ListItem>
                            <asp:ListItem Value="3">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtReconciliationStatementGST" class="font-weight-normal">FILED ON :</label>
                        <asp:TextBox ID="txtReconciliationStatementGST" TextMode="Date" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <%--FILED DRC-08 REAGARDING THIS MONTH	, FILED ON ,CHECK CASH LEDGER & CREDIT LEDGER FOR THIS MONTH --%>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="ddlReconciliationStatementGST" class="font-weight-normal">FILED DRC-08 REGARDING THIS MONTH :</label>
                        <asp:DropDownList ID="ddlFiledDrc8" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Filed</asp:ListItem>
                            <asp:ListItem Value="2">Not Filed</asp:ListItem>
                            <asp:ListItem Value="3">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtDrc8FiledOnGST" class="font-weight-normal">FILED ON :</label>
                        <asp:TextBox ID="txtDrc8FiledOnGST" TextMode="Date" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="ddlCashCreditLedgerGST" class="font-weight-normal">CHECK CASH LEDGER & CREDIT LEDGER FOR THIS MONTH :</label>
                        <asp:DropDownList ID="ddlCashCreditLedgerGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Checked</asp:ListItem>
                            <asp:ListItem Value="2">Not Checked</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtEwayBillPasswordGST" class="font-weight-normal">Document Filled & Checked by :</label>
                        <asp:TextBox ID="txtDocumentFilledAndCheckedByGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtVerifiedByGST" class="font-weight-normal">Verified By :</label>
                        <asp:TextBox ID="txtVerifiedByGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3">
                    <asp:Button ID="btnSaveGSTInfo" runat="server" Text="Save GST Info" CssClass="btn btn-success w-50" OnClick="btnSaveGSTInfo_Click" />
                </div>

            </div>


            <%--ACCOUNTS--%>
            <div class="row shadow rounded-bottom" style="background-color: #a5d1cc;" id="ACCOUNTService" runat="server" visible="false">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3 class="text-secondary font-weight-light">Return information for Accounts</h3>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="ddlBookKeepingOnACN" class="font-weight-normal">BookKeeping Made on :</label>
                        <asp:DropDownList ID="ddlBookKeepingOnACN" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Excel</asp:ListItem>
                            <asp:ListItem Value="2">Tally</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtTallyDataNoACN" class="font-weight-normal">Tally Data No :</label>
                        <asp:TextBox ID="txtTallyDataNoACN" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlFinancialYearACN" class="font-weight-normal">Financial Year :</label>
                        <asp:DropDownList ID="ddlFinancialYearACN" CssClass="form-control form-control-sm" runat="server">
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
                        <label for="ddlMonthACN" class="font-weight-normal">Month :</label>
                        <asp:DropDownList ID="ddlMonthACN" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True">-- Select Month --</asp:ListItem>
                            <asp:ListItem Value="1">January</asp:ListItem>
                            <asp:ListItem Value="2">February</asp:ListItem>
                            <asp:ListItem Value="3">March</asp:ListItem>
                            <asp:ListItem Value="4">April</asp:ListItem>
                            <asp:ListItem Value="5">May</asp:ListItem>
                            <asp:ListItem Value="6">June</asp:ListItem>
                            <asp:ListItem Value="7">July</asp:ListItem>
                            <asp:ListItem Value="8">August</asp:ListItem>
                            <asp:ListItem Value="9">September</asp:ListItem>
                            <asp:ListItem Value="10">October</asp:ListItem>
                            <asp:ListItem Value="11">November</asp:ListItem>
                            <asp:ListItem Value="12">December</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3">
                    <h3 class="text-primary font-weight-lighter">Document Received</h3>
                </div>
                <%--1--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbTallyExcelDataRcvACN" class="font-weight-normal">Tally / Excel Data Received :</label>
                        <asp:RadioButtonList ID="rbTallyExcelDataRcvACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes on Tally </asp:ListItem>
                            <asp:ListItem Value="2">Yes on Excel</asp:ListItem>
                            <asp:ListItem Value="3">No</asp:ListItem>
                            <asp:ListItem Value="4">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--2--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbOpeningStockStmtACN" class="font-weight-normal">Opening  Stock / Statement :</label>
                        <asp:RadioButtonList ID="rbOpeningStockStmtACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes on Tally </asp:ListItem>
                            <asp:ListItem Value="2">Yes on Excel</asp:ListItem>
                            <asp:ListItem Value="3">In Hard Copy</asp:ListItem>
                            <asp:ListItem Value="4">No</asp:ListItem>
                            <asp:ListItem Value="5">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--3--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbPurchaseBillStatementACN" class="font-weight-normal">Purchase Bills / Statement :</label>
                        <asp:RadioButtonList ID="rbPurchaseBillStatementACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes on Tally </asp:ListItem>
                            <asp:ListItem Value="2">Yes on Excel</asp:ListItem>
                            <asp:ListItem Value="3">In Hard Copy</asp:ListItem>
                            <asp:ListItem Value="4">No</asp:ListItem>
                            <asp:ListItem Value="5">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--4--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbSalesBillStatementACN" class="font-weight-normal">Sales Bills / Statement :</label>
                        <asp:RadioButtonList ID="rbSalesBillStatementACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes on Tally </asp:ListItem>
                            <asp:ListItem Value="2">Yes on Excel</asp:ListItem>
                            <asp:ListItem Value="3">In Hard Copy</asp:ListItem>
                            <asp:ListItem Value="4">No</asp:ListItem>
                            <asp:ListItem Value="5">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--5--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbCreditNoteACN" class="font-weight-normal">Credit Note  :</label>
                        <asp:RadioButtonList ID="rbCreditNoteACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes on Tally </asp:ListItem>
                            <asp:ListItem Value="2">Yes on Excel</asp:ListItem>
                            <asp:ListItem Value="3">In Hard Copy</asp:ListItem>
                            <asp:ListItem Value="4">No</asp:ListItem>
                            <asp:ListItem Value="5">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--6--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbDebitNoteACN" class="font-weight-normal">Debit Note :</label>
                        <asp:RadioButtonList ID="rbDebitNoteACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes on Tally </asp:ListItem>
                            <asp:ListItem Value="2">Yes on Excel</asp:ListItem>
                            <asp:ListItem Value="3">In Hard Copy</asp:ListItem>
                            <asp:ListItem Value="4">No</asp:ListItem>
                            <asp:ListItem Value="5">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--7--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbBankStatementsACN" class="font-weight-normal">Bank Statements :</label>
                        <asp:RadioButtonList ID="rbBankStatementsACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes on Tally </asp:ListItem>
                            <asp:ListItem Value="2">Yes on Excel</asp:ListItem>
                            <asp:ListItem Value="3">In Hard Copy</asp:ListItem>
                            <asp:ListItem Value="4">No</asp:ListItem>
                            <asp:ListItem Value="5">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--8--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbCashBooksACN" class="font-weight-normal">Cash Books :</label>
                        <asp:RadioButtonList ID="rbCashBooksACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes on Tally </asp:ListItem>
                            <asp:ListItem Value="2">Yes on Excel</asp:ListItem>
                            <asp:ListItem Value="3">In Hard Copy</asp:ListItem>
                            <asp:ListItem Value="4">No</asp:ListItem>
                            <asp:ListItem Value="5">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--9--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbLoanStatementsACN" class="font-weight-normal">Loan Statements :</label>
                        <asp:RadioButtonList ID="rbLoanStatementsACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes on Tally </asp:ListItem>
                            <asp:ListItem Value="2">Yes on Excel</asp:ListItem>
                            <asp:ListItem Value="3">In Hard Copy</asp:ListItem>
                            <asp:ListItem Value="4">No</asp:ListItem>
                            <asp:ListItem Value="5">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--10--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbReceivePaymentStatementACN" class="font-weight-normal">Receipt & Payment Statement :</label>
                        <asp:RadioButtonList ID="rbReceivePaymentStatementACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes on Tally </asp:ListItem>
                            <asp:ListItem Value="2">Yes on Excel</asp:ListItem>
                            <asp:ListItem Value="3">In Hard Copy</asp:ListItem>
                            <asp:ListItem Value="4">No</asp:ListItem>
                            <asp:ListItem Value="5">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--11--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbProfitLossAccountsACN" class="font-weight-normal">Profit / Loss Accounts :</label>
                        <asp:RadioButtonList ID="rbProfitLossAccountsACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes on Tally </asp:ListItem>
                            <asp:ListItem Value="2">Yes on Excel</asp:ListItem>
                            <asp:ListItem Value="3">In Hard Copy</asp:ListItem>
                            <asp:ListItem Value="4">No</asp:ListItem>
                            <asp:ListItem Value="5">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                <%--12--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbBalanceSheetACN" class="font-weight-normal">Balance Sheet :</label>
                        <asp:RadioButtonList ID="rbBalanceSheetACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes on Tally </asp:ListItem>
                            <asp:ListItem Value="2">Yes on Excel</asp:ListItem>
                            <asp:ListItem Value="3">In Hard Copy</asp:ListItem>
                            <asp:ListItem Value="4">No</asp:ListItem>
                            <asp:ListItem Value="5">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3">
                    <h3 class="text-primary font-weight-lighter">Accounting Report Made on </h3>
                </div>

                <%--1--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbPurchaseStatementACN" class="font-weight-normal">Purchase Statement :</label>
                        <asp:RadioButtonList ID="rbPurchaseStatementACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Created in Excel </asp:ListItem>
                            <asp:ListItem Value="2">Generated in Tally</asp:ListItem>
                            <asp:ListItem Value="3">Not Made</asp:ListItem>
                            <asp:ListItem Value="4">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--2--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbSundryCreditorListACN" class="font-weight-normal">Sundry Creditors List :</label>
                        <asp:RadioButtonList ID="rbSundryCreditorListACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Created in Excel </asp:ListItem>
                            <asp:ListItem Value="2">Generated in Tally</asp:ListItem>
                            <asp:ListItem Value="3">Not Made</asp:ListItem>
                            <asp:ListItem Value="4">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--3--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbSalesSatementACN" class="font-weight-normal">Sales Statements :</label>
                        <asp:RadioButtonList ID="rbSalesSatementACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Created in Excel </asp:ListItem>
                            <asp:ListItem Value="2">Generated in Tally</asp:ListItem>
                            <asp:ListItem Value="3">Not Made</asp:ListItem>
                            <asp:ListItem Value="4">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--4--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbSundryDebtorListACN" class="font-weight-normal">Sundry Debtors List :</label>
                        <asp:RadioButtonList ID="rbSundryDebtorListACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Created in Excel </asp:ListItem>
                            <asp:ListItem Value="2">Generated in Tally</asp:ListItem>
                            <asp:ListItem Value="3">Not Made</asp:ListItem>
                            <asp:ListItem Value="4">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--5--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbBankStatementsReportACN" class="font-weight-normal">Bank Statements :</label>
                        <asp:RadioButtonList ID="rbBankStatementsReportACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Created in Excel </asp:ListItem>
                            <asp:ListItem Value="2">Generated in Tally</asp:ListItem>
                            <asp:ListItem Value="3">Not Made</asp:ListItem>
                            <asp:ListItem Value="4">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--6--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbBrsACN" class="font-weight-normal">BRS :</label>
                        <asp:RadioButtonList ID="rbBrsACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Created in Excel </asp:ListItem>
                            <asp:ListItem Value="2">Generated in Tally</asp:ListItem>
                            <asp:ListItem Value="3">Not Made</asp:ListItem>
                            <asp:ListItem Value="4">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--7--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbCashBookACN_Report" class="font-weight-normal">Cash Book :</label>
                        <asp:RadioButtonList ID="rbCashBookACN_Report" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Created in Excel </asp:ListItem>
                            <asp:ListItem Value="2">Generated in Tally</asp:ListItem>
                            <asp:ListItem Value="3">Not Made</asp:ListItem>
                            <asp:ListItem Value="4">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--8--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbClosingStockStatementACN" class="font-weight-normal">Closing Stock Statement :</label>
                        <asp:RadioButtonList ID="rbClosingStockStatementACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Created in Excel </asp:ListItem>
                            <asp:ListItem Value="2">Generated in Tally</asp:ListItem>
                            <asp:ListItem Value="3">Not Made</asp:ListItem>
                            <asp:ListItem Value="4">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--9--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbReceivePaymentStatementReportACN" class="font-weight-normal">Receipt & Payment Statement :</label>
                        <asp:RadioButtonList ID="rbReceivePaymentStatementReportACN" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Created in Excel </asp:ListItem>
                            <asp:ListItem Value="2">Generated in Tally</asp:ListItem>
                            <asp:ListItem Value="3">Not Made</asp:ListItem>
                            <asp:ListItem Value="4">Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtObservationACN" class="font-weight-normal">Observation :</label>
                        <asp:TextBox ID="txtObservationACN" TextMode="MultiLine" Rows="5" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 text-center">
                    <asp:Button ID="btnAccountsInfoACNK" runat="server" CssClass="btn  btn-success w-50 mb-3" Text="Save Accounts Info" OnClick="btnAccountsInfoACNK_Click"></asp:Button>
                </div>

            </div>

        </div>


        <%--COMMON GRID FOR ALL THE SERVICES--%>

        <div class="col-lg-12 col-md-12 col-sm-12 text-center">
            <asp:GridView ID="grvReturnInformation" runat="server" CssClass="table table-responsive small"></asp:GridView>
        </div>
    </div>

    <script type="text/javascript">

        $(document).ready(function () {
            $(':input').css('border-width', '1px').css('border-color', 'black').css('border-radius', '0px');
        });
    </script>

</asp:Content>
