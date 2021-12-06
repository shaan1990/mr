<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ApplyService.aspx.cs" Inherits="Admin_ApplyService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="flex-row justify-content-center align-items-center mx-auto">

        <h1 id="hstep3" runat="server" class="text-primary font-weight-light">New Client Registration Form:</h1>
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


        <div class="row shadow rounded-bottom" style="background-color: #a5d1cc;" runat="server" id="divRegistration" visible="false">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <%--name--%>
                <div class="form-group">
                    <label for="txtClientName" class="font-weight-normal">Name of the Client :</label>
                    <asp:TextBox ID="txtClientName" CssClass="form-control form-control-sm" runat="server" placeholder="Type your name in Block Letter."></asp:TextBox>
                </div>

            </div>

            <%--pan , voter id, adhaar, contact no--%>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="txtPAN" class="font-weight-normal">PAN :</label>
                    <asp:TextBox ID="txtPAN" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtVoterID" class="font-weight-normal">Voter ID :</label>
                    <asp:TextBox ID="txtVoterID" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="txtAdhaar" class="font-weight-normal">ADHAAR :</label>
                    <asp:TextBox ID="txtAdhaar" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtContact" class="font-weight-normal">Contact No :</label>
                    <asp:TextBox ID="txtContact" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="txtEmail" class="font-weight-normal">Email :</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                    <label for="txtPassword" class="font-weight-normal">Password :</label>
                    <asp:TextBox ID="txtPassword" CssClass="form-control form-control-sm" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 text-center">
                <div class="form-group">
                    <asp:Button ID="btnRegistration" runat="server" Text="Register" CssClass="btn btn-success btn-sm" OnClick="btnRegistration_Click" />
                </div>

            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 text-center">
                <asp:LinkButton ID="lnkOpendivCustomerID" runat="server" CssClass="font-weight-normal" OnClick="lnkOpendivCustomerID_Click">Already Registered ?? Click here to apply for the new Service</asp:LinkButton>
            </div>
        </div>


        <div class="row shadow rounded-bottom" style="background-color: #a5d1cc;" runat="server" id="divCustomerID">
            <div class="col-lg-6 col-md-6 col-sm-6">
                <%--customer id--%>
                <div class="form-group">
                    <label for="txtCustomerID" class="font-weight-normal">Client ID :</label>
                    <asp:TextBox ID="txtCustomerID" CssClass="form-control form-control-sm" runat="server" placeholder="Type your Customer ID without any space"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-6">
                <%--list of services--%>
                <div class="form-group">
                    <label for="txtCustomerID" class="font-weight-normal">Select Services :</label>
                    <asp:DropDownList ID="ddlServices" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 text-center">
                <div class="form-group">
                    <asp:Button ID="btnOpenForm" runat="server" Text="Open" CssClass="btn btn-warning btn-sm w-25" OnClick="btnOpenForm_Click" />
                    <asp:Button ID="btnEditForm" runat="server" Text="Search" CssClass="btn btn-danger btn-sm w-25" Visible="false" OnClick="btnEditForm_Click" />
                </div>
            </div>

            <br />
            <div class="col-lg-12 col-md-12 col-sm-12 text-center">
                <asp:LinkButton ID="lnkOpendivRegistration" runat="server" CssClass="font-weight-normal" OnClick="lnkOpendivRegistration_Click">New User ?? If yes, Click here for New Registration</asp:LinkButton>
            </div>
        </div>

        <br />
        <%--REGISTRATION FORM SECTION--%>


        <div id="RegistrationFormSection" runat="server">
            <%--INCOME TAX--%>
            <div class="row shadow rounded-bottom" style="background-color: #ffffff;" runat="server" id="divRegFormITAX" visible="false">
                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3">
                    <h2 class="font-weight-light text-success">ITAX Registration Form</h2>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlApplyingAsITAX" class="font-weight-normal">Applying As :</label>
                        <asp:DropDownList ID="ddlApplyingAsITAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Category --</asp:ListItem>
                            <asp:ListItem Value="1">Individual</asp:ListItem>
                            <asp:ListItem Value="2">HUF</asp:ListItem>
                            <asp:ListItem Value="3">Other Than HUF</asp:ListItem>
                            <asp:ListItem Value="4">Tax Ductor</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtPANITAX" class="font-weight-normal">PAN :</label>
                        <asp:TextBox ID="txtPANITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtApplicantNameITAX" class="font-weight-normal">Name of the Applicant:</label>
                        <asp:TextBox ID="txtApplicantNameITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtDOBITAX" class="font-weight-normal">DOB :</label>
                        <asp:TextBox ID="txtDOBITAX" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlResidentialStatsITAX" class="font-weight-normal">Residential Status :</label>
                        <asp:DropDownList ID="ddlResidentialStatsITAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Residential Status --</asp:ListItem>
                            <asp:ListItem Value="1">Resident</asp:ListItem>
                            <asp:ListItem Value="2">Non-Resident</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtMobileITAX" class="font-weight-normal">Mobile :</label>
                        <asp:TextBox ID="txtMobileITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtEmailITAX" class="font-weight-normal">Email :</label>
                        <asp:TextBox ID="txtEmailITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3 class="text-primary font-weight-lighter ">Residentail Address :</h3>
                </div>
                <hr />

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtRoadStreetITAX" class="font-weight-normal">ROAD / STREET / BLOCK / SECTOR :</label>
                        <asp:TextBox ID="txtRoadStreetITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtAreaLocalityITAX" class="font-weight-normal">AREA / LOCALITY :</label>
                        <asp:TextBox ID="txtAreaLocalityITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtPostOfficeITAX" class="font-weight-normal">Post Office :</label>
                        <asp:TextBox ID="txtPostOfficeITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtStateITAX" class="font-weight-normal">State :</label>
                        <asp:DropDownList ID="ddlStateITAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select State --</asp:ListItem>
                            <asp:ListItem Value="1">Tripura</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlCountryITAX" class="font-weight-normal">Country :</label>
                        <asp:DropDownList ID="ddlCountryITAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Country --</asp:ListItem>
                            <asp:ListItem Value="1">INDIA</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtPINITAX" class="font-weight-normal">PIN :</label>
                        <asp:TextBox ID="txtPINITAX" CssClass="form-control form-control-sm" MaxLength="6" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <asp:CheckBox ID="chkAgreeITAX" runat="server" />
                        <span class="small text-danger font-weight-normal ml-3">I hereby solemnly affirm and declare that the information given herein above is true and correct to the best of my knowledge and belief and nothing has been concealed therefrom.									
                        </span>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtNoteITAX" class="font-weight-normal">*Note : Document Required :</label>
                        <label for="txtNoteITAX" class="font-weight-normal">1 . PAN CARD</label>

                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtNoteITAX" class="font-weight-normal">2 . ADHAAR</label>
                    </div>
                </div>

                <%--ACKNOWLEDGEMENT NUMBER--%>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <label for="txtApplicationNumberITAX" class="font-weight-normal">APPLICATION NUMBER :</label>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <asp:TextBox ID="txtApplicationNumberITAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <label for="txtDateOfAckITAX" class="font-weight-normal">DATE :</label>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <asp:TextBox ID="txtDateOfAckITAX" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3 mt-5">
                    <asp:Button ID="btnRegistrationITAX" CssClass="btn btn-success btn-sm w-50" runat="server" Text="Regisration (I.TAX)" OnClick="btnRegistrationITAX_Click" />
                    <asp:Button ID="btnUpdateITAX" CssClass="btn btn-warning btn-sm w-50" runat="server" Text="Update(ITAX)" Visible="false" OnClick="btnUpdateITAX_Click" />
                </div>

            </div>


            <%--PROFESSSIONAL TAX--%>
            <div class="row shadow rounded-bottom" style="background-color: #ffffff;" runat="server" id="divRegFormPTAX" visible="false">

                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3">
                    <h2 class="font-weight-light text-success">PTAX Registration Form</h2>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlApplyingAsPTAX" class="font-weight-normal">Applying As :</label>
                        <asp:DropDownList ID="ddlApplyingAsPTAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Category --</asp:ListItem>
                            <asp:ListItem Value="1">Individual</asp:ListItem>
                            <asp:ListItem Value="2">Others</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>



                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtApplicantNamePTAX" class="font-weight-normal">Name of the Applicant:</label>
                        <asp:TextBox ID="txtApplicantNamePTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtFatherNamePTAX" class="font-weight-normal">Father Name :</label>
                        <asp:TextBox ID="txtFatherNamePTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtPANPTAX" class="font-weight-normal">PAN :</label>
                        <asp:TextBox ID="txtPANPTAX" CssClass="form-control form-control-sm" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlGenderPTAX" class="font-weight-normal">GENDER :</label>
                        <asp:DropDownList ID="ddlGenderPTAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Gender --</asp:ListItem>
                            <asp:ListItem Value="1">Male</asp:ListItem>
                            <asp:ListItem Value="2">Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtMobilePTAX" class="font-weight-normal">Mobile :</label>
                        <asp:TextBox ID="txtMobilePTAX" CssClass="form-control form-control-sm" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtEmailPTAX" class="font-weight-normal">Email :</label>
                        <asp:TextBox ID="txtEmailPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3">
                    <div class="form-group">
                        <label for="txtEstablishmentAddressPTAX" class="font-weight-normal float-left">Establishment Address :</label>
                        <asp:TextBox ID="txtEstablishmentAddressPTAX" CssClass="form-control form-control-sm" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
                        <span class="text-primary small float-left">*Note : Only 135 charcters are allowed</span>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlDistrictPTAX" class="font-weight-normal">District :</label>
                        <asp:DropDownList ID="ddlDistrictPTAX" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtPinCodePTAX" class="font-weight-normal">PIN Code :</label>
                        <asp:TextBox ID="txtPinCodePTAX" CssClass="form-control form-control-sm" runat="server" MaxLength="6"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtEstablishmentNamePTAX" class="font-weight-normal float-left">Establishment Name :</label>
                        <asp:TextBox ID="txtEstablishmentNamePTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlProfessionCategoryPTAX" class="font-weight-normal">CATEGORY OF PROFESSION :</label>
                        <asp:DropDownList ID="ddlProfessionCategoryPTAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Profession Category --</asp:ListItem>
                            <asp:ListItem Value="1">Profession</asp:ListItem>
                            <asp:ListItem Value="2">Trade</asp:ListItem>
                            <asp:ListItem Value="3">Calling</asp:ListItem>
                            <asp:ListItem Value="4">Employment</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlProfessionSubCategoryPTAX" class="font-weight-normal">SUB-CATEGORY OF PROFESSION :</label>
                        <asp:DropDownList ID="ddlProfessionSubCategoryPTAX" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Profession SubCategory --</asp:ListItem>
                            <asp:ListItem Value="1">Profession</asp:ListItem>
                            <asp:ListItem Value="2">Trade</asp:ListItem>
                            <asp:ListItem Value="3">Calling</asp:ListItem>
                            <asp:ListItem Value="4">Employment</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="rbEngageWithPTAX" class="font-weight-normal">Engage With :</label>
                        <asp:RadioButtonList ID="rbEngageWithPTAX" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Profession</asp:ListItem>
                            <asp:ListItem Value="2">Trade</asp:ListItem>
                            <asp:ListItem Value="3">Calling</asp:ListItem>
                            <asp:ListItem Value="4">Employment</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3 class="text-primary font-weight-lighter ">Furnish the Details of Trade :</h3>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtDateofCommencementPTAX" class="font-weight-normal">Date of Commencement :</label>
                        <asp:TextBox ID="txtDateofCommencementPTAX" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtPANTANPTAX" class="font-weight-normal">* PAN / TAN :</label>
                        <asp:TextBox ID="txtPANTANPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtAnnualGrossBusinessPTAX" class="font-weight-normal">* Annual Gross Business :</label>
                        <asp:TextBox ID="txtAnnualGrossBusinessPTAX" CssClass="form-control form-control-sm" runat="server" placeholder="Only Numeric values are allowed" onkeypress="return onlyNumberKey(event)"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtAnnualTurnOverSalesPurchasePTAX" class="font-weight-normal">* Annual TurnOver of all Sales/Purchases :</label>
                        <asp:TextBox ID="txtAnnualTurnOverSalesPurchasePTAX" CssClass="form-control form-control-sm" runat="server" placeholder="Only Numeric values are allowed" onkeypress="return onlyNumberKey(event)"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtMonthlyAvgWorkersPTAX" class="font-weight-normal">Monthly Average Number of Workers :</label>
                        <asp:TextBox ID="txtMonthlyAvgWorkersPTAX" CssClass="form-control form-control-sm" runat="server" placeholder="Only Numeric values are allowed" onkeypress="return onlyNumberKey(event)"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtMonthlyAvgEmployeesPTAX" class="font-weight-normal">Monthly Average Number of Employees :</label>
                        <asp:TextBox ID="txtMonthlyAvgEmployeesPTAX" CssClass="form-control form-control-sm" runat="server" placeholder="Only Numeric values are allowed" onkeypress="return onlyNumberKey(event)"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3 class="text-primary font-weight-lighter">If registered taxpayer under one or more from the list below, please select :</h3>
                </div>



                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtGSTPTAX" class="font-weight-normal">Registered Under GST :</label>
                        <asp:TextBox ID="txtGSTPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtCSTPTAX" class="font-weight-normal">Registered Under CST :</label>
                        <asp:TextBox ID="txtCSTPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtVATPTAX" class="font-weight-normal">Registered Under VAT :</label>
                        <asp:TextBox ID="txtVATPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3 class="text-primary font-weight-lighter">If held Vehicles under the Motor Vehicles Act- 1939, Please Select :</h3>
                </div>


                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="rbVehiclesPTAX" class="font-weight-normal">Vehicle Category :</label>
                        <asp:RadioButtonList ID="rbVehiclesPTAX" runat="server" RepeatDirection="Horizontal">
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
                    <h3 class="text-primary font-weight-lighter">If enganged with Co-Operative Society, Please Select :</h3>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <asp:RadioButtonList ID="rbLevelOfSocietyPTAX" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">State Level Society</asp:ListItem>
                            <asp:ListItem Value="2">District Level Society</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <asp:CheckBox ID="chkAgreePtax" runat="server" />
                    <span class="small font-weight-normal text-danger">All the information written in above is true as per my knowledge If any information is found to be untrue I shall be liable for the cancellation of any services benefits.</span>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    Note: <u>Document Required </u>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <p>1. PAN CARD</p>
                    <p>2. TRADE LICENCE</p>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <p>3. IT RETURN</p>
                    <p>4. GSTIN REG. CERTIFICATE</p>
                </div>


                <%--ACKNOWLEDGEMENT NUMBER--%>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <label for="txtApplicationNumberPTAX" class="font-weight-normal">APPLICATION NUMBER :</label>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <asp:TextBox ID="txtApplicationNumberPTAX" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <label for="txtDateOfAckPTAX" class="font-weight-normal">DATE :</label>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <asp:TextBox ID="txtDateOfAckPTAX" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3 mt-5">
                    <asp:Button ID="btnRegistrationPTAX" CssClass="btn btn-success btn-sm w-50" runat="server" Text="Regisration(PTAX)" OnClick="btnRegistrationPTAX_Click" />
                    <asp:Button ID="btnUpdatePTAX" CssClass="btn btn-warning btn-sm w-50" runat="server" Text="Update(PTAX)" Visible="false" OnClick="btnUpdatePTAX_Click" />
                </div>

            </div>


            <%--RUBBER BOARD--%>
            <div class="row shadow rounded-bottom" style="background-color: #ffffff;" runat="server" id="divRegFormRubber" visible="false">
                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3">
                    <h2 class="font-weight-light text-success">Rubber Board Registration Form</h2>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlLicenceRB" class="font-weight-normal">Applying Dealer Licence :</label>
                        <asp:DropDownList ID="ddlLicenceRB" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Category --</asp:ListItem>
                            <asp:ListItem Value="1">New Licence</asp:ListItem>
                            <asp:ListItem Value="2">Renew Licence</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtApplicantNameRB" class="font-weight-normal">Name of the Applicant:</label>
                        <asp:TextBox ID="txtApplicantNameRB" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtTraderNameRB" class="font-weight-normal">Trader Name :</label>
                        <asp:TextBox ID="txtTraderNameRB" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtFathersNameRB" class="font-weight-normal">Father's Name:</label>
                        <asp:TextBox ID="txtFathersNameRB" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtDOBRB" class="font-weight-normal">DOB :</label>
                        <asp:TextBox ID="txtDOBRB" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>

                <%--BUSINESS PLACE--%>
                <%--=====================================--%>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtBusinessPlaceRB" class="font-weight-normal">Business Place :</label>
                        <asp:TextBox ID="txtBusinessPlaceRB" CssClass="form-control form-control-sm" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </div>
                </div>
                <%--BUSINESS PLACE :  building type, building no, city, district--%>

                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtBuildingTypeRB" class="font-weight-normal">Building Type :</label>
                        <asp:TextBox ID="txtBuildingTypeRB" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtBuildingPlotNoRB" class="font-weight-normal">Building / Plot No  :</label>
                        <asp:TextBox ID="txtBuildingPlotNoRB" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtCityRB" class="font-weight-normal">City :</label>
                        <asp:TextBox ID="txtCityRB" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="ddlDistrictRB" class="font-weight-normal">District :</label>
                        <asp:DropDownList ID="ddlDistrictRB" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <%-- BUSINESS PLACE : state, pin, mobile, email--%>


                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="ddlStateRB" class="font-weight-normal">State :</label>
                        <asp:DropDownList ID="ddlStateRB" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select State --</asp:ListItem>
                            <asp:ListItem Value="1">Tripura</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtPINRB" class="font-weight-normal">PIN  :</label>
                        <asp:TextBox ID="txtPINRB" CssClass="form-control form-control-sm" MaxLength="6" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtMobileRB" class="font-weight-normal">Mobile :</label>
                        <asp:TextBox ID="txtMobileRB" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtEmailRB" class="font-weight-normal">Email :</label>
                        <asp:TextBox ID="txtEmailRB" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>




                <%--STORAGE PLACE--%>
                <%--=====================================--%>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtStoragePlaceRB" class="font-weight-normal">Storage Place :</label>
                        <asp:TextBox ID="txtStoragePlaceRB" CssClass="form-control form-control-sm" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </div>
                </div>
                <%-- STORAGE :  building type, building no, city, district--%>

                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtBuildingTypeRB2" class="font-weight-normal">Building Type :</label>
                        <asp:TextBox ID="txtBuildingTypeRB2" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtBuildingPlotNoRB2" class="font-weight-normal">Building / Plot No  :</label>
                        <asp:TextBox ID="txtBuildingPlotNoRB2" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtCityRB2" class="font-weight-normal">City :</label>
                        <asp:TextBox ID="txtCityRB2" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="ddlDistrictRB_Storage" class="font-weight-normal">District :</label>
                        <asp:DropDownList ID="ddlDistrictRB_Storage" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <%-- STORAGE : state, pin, mobile, email--%>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="ddlStateRB2" class="font-weight-normal">State :</label>
                        <asp:DropDownList ID="ddlStateRB2" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select State --</asp:ListItem>
                            <asp:ListItem Value="1">Tripura</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtPINRB2" class="font-weight-normal">PIN  :</label>
                        <asp:TextBox ID="txtPINRB2" CssClass="form-control form-control-sm" MaxLength="6" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtMobileRB2" class="font-weight-normal">Mobile :</label>
                        <asp:TextBox ID="txtMobileRB2" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtEmailRB2" class="font-weight-normal">Email :</label>
                        <asp:TextBox ID="txtEmailRB2" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <%-- STORAGE : Ownership type and ownership name--%>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtOwnerShipTypeRB" class="font-weight-normal">Ownership Type :</label>
                        <asp:TextBox ID="txtOwnerShipTypeRB" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtOwnerShipNameRB" class="font-weight-normal">Ownership Name :</label>
                        <asp:TextBox ID="txtOwnerShipNameRB" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <%--  PRESENT & PERMANENT ADDRESS--%>
                <%--=====================================--%>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtPresentPermanentAddressRB" class="font-weight-normal">Present & Permanent Address :</label>
                        <asp:TextBox ID="txtPresentPermanentAddressRB" CssClass="form-control form-control-sm" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </div>
                </div>

                <%-- PRESENT & PERMANENT : city, district, state, pin--%>

                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtCityRB3" class="font-weight-normal">City :</label>
                        <asp:TextBox ID="txtCityRB3" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="ddlDistrictRB_Address" class="font-weight-normal">District :</label>
                        <asp:DropDownList ID="ddlDistrictRB_Address" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="ddlStateRB3" class="font-weight-normal">State :</label>
                        <asp:DropDownList ID="ddlStateRB3" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select State --</asp:ListItem>
                            <asp:ListItem Value="1">Tripura</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtPINRB3" class="font-weight-normal">PIN  :</label>
                        <asp:TextBox ID="txtPINRB3" CssClass="form-control form-control-sm" MaxLength="6" runat="server"></asp:TextBox>
                    </div>
                </div>
                <%-- PRESENT & PERMANENT : mobile, email,pan, invested capital--%>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtMobileRB3" class="font-weight-normal">Mobile :</label>
                        <asp:TextBox ID="txtMobileRB3" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtEmailRB3" class="font-weight-normal">Email :</label>
                        <asp:TextBox ID="txtEmailRB3" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtPANRB3" class="font-weight-normal">PAN :</label>
                        <asp:TextBox ID="txtPANRB3" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtInvestedCapitalRB3" class="font-weight-normal">INVESTED CAPITAL  :</label>
                        <asp:TextBox ID="txtInvestedCapitalRB3" CssClass="form-control form-control-sm" runat="server" placeholder="Only Numeric values are allowed" onkeypress="return onlyNumberKey(event)"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3">
                    <asp:CheckBox ID="chkAgreeRubber" runat="server" />
                    <span class="font-weight-normal text-danger">I hereby solemnly affirm and declare that the information given herein above is true and corrent to the best of my knowledge and belief and nothing has been concealed there from.</span>
                </div>


                <%---------------------------------%>
                <div class="col-lg-4 col-md-4 col-sm-4 font-weight-normal">
                    <div class="form-group">
                        <span class="text-black mb-2">Note: <u>Document Required </u></span>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 font-weight-normal">
                    <div class="form-group">
                        <p>1. PAN CARD</p>
                        <p>2. ADHAAR CARD</p>
                        <p>3. VOTER ID</p>
                        <p>4. PRTC</p>
                        <p>5. LAND LEDGER COPY</p>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 font-weight-normal">
                    <div class="form-group">
                        <p>6. RENT AGREEMENT</p>
                        <p>7. TRADE LICENCE</p>
                        <p>8. BANK STATEMENT</p>
                        <p>9. PASSPORT PHOTO</p>
                    </div>
                </div>

                <%--ACKNOWLEDGEMENT NUMBER--%>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <label for="txtApplicationNumberRB" class="font-weight-normal">APPLICATION NUMBER :</label>

                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <asp:TextBox ID="txtApplicationNumberRB" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <label for="txtDateOfAckRB" class="font-weight-normal">DATE :</label>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <asp:TextBox ID="txtDateOfAckRB" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3 mt-5">
                    <asp:Button ID="btnRegistrationRubber" CssClass="btn btn-success btn-sm w-50" runat="server" Text="Regisration(Rubber)" OnClick="btnRegistrationRubber_Click" />
                    <asp:Button ID="btnUpdateRubber" CssClass="btn btn-warning btn-sm w-50" runat="server" Text="Update(Rubber)" Visible="false" OnClick="btnUpdateRubber_Click" />
                </div>

            </div>


            <%--DIGITAL SIGNATURE--%>
            <div class="row shadow rounded-bottom mb-0" style="background-color: #ffffff;" runat="server" id="divRegFormDSC" visible="false">
                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3">
                    <h2 class="font-weight-light text-success">DSC Registration Form</h2>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6 py-0">
                    <div class="form-group">
                        <label for="txtApplicantNameDSC" class="font-weight-normal">Name of the Applicant :</label>
                        <asp:TextBox ID="txtApplicantNameDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6 py-0">
                    <div class="form-group">
                        <label for="txtEstablishmentNameDSC" class="font-weight-normal">Name of the Establishment :</label>
                        <asp:TextBox ID="txtEstablishmentNameDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6 py-0">
                    <div class="form-group">
                        <label for="txtPANDSC" class="font-weight-normal">PAN :</label>
                        <asp:TextBox ID="txtPANDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtAdhaarDSC" class="font-weight-normal">ADHAAR :</label>
                        <asp:TextBox ID="txtAdhaarDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtMobileDSC" class="font-weight-normal">Mobile :</label>
                        <asp:TextBox ID="txtMobileDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtDOBDSC" class="font-weight-normal">DOB :</label>
                        <asp:TextBox ID="txtDOBDSC" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtEmailDSC" class="font-weight-normal">Email :</label>
                        <asp:TextBox ID="txtEmailDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlAdharLinkedDSC" class="font-weight-normal">Adhaar Linked with mobile :</label>
                        <asp:DropDownList ID="ddlAdharLinkedDSC" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Value="2">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtLinkedMobileWithAdhaarDSC" class="font-weight-normal">Linked Mobile with Adhaar :</label>
                        <asp:TextBox ID="txtLinkedMobileWithAdhaarDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-12 col-md-12 col-sm-12 text-center">
                    <div class="form-group">
                        <label for="txtAddressDSC" class="font-weight-normal float-left">Address :</label>
                        <asp:TextBox ID="txtAddressDSC" CssClass="form-control form-control-sm" MaxLength="125" runat="server"></asp:TextBox>
                        <span class="text-primary small float-left">*Note : Only 135 charcters are allowed</span>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlDistrictsDSC" class="font-weight-normal">Districts :</label>
                        <asp:DropDownList ID="ddlDistrictsDSC" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtPINDSC" class="font-weight-normal">PIN :</label>
                        <asp:TextBox ID="txtPINDSC" CssClass="form-control form-control-sm" MaxLength="6" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 text-center">
                    <div class="form-group">
                        <asp:CheckBox ID="chkAgreeDSC" runat="server" />
                        <span class="text-danger font-weight-normal">All the information written in above is true as per my knowledge If any information is found to be untrue I shall be liable for disciplinary action.									
                        </span>
                    </div>
                </div>

                <div class="col-lg-4 col-md-4 col-sm-4 font-weight-normal">
                    <div class="form-group">
                        <span class="text-black mb-2">Note: <u>Document Required </u></span>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 font-weight-normal">
                    <div class="form-group">
                        <p>1. PAN CARD</p>
                        <p>2. ADHAAR CARD</p>
                        <p>3. PHOTO</p>

                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 font-weight-normal text-left">
                    <div class="form-group">
                        <p>4. LETTER OF AUTHENTICATION	</p>
                        <p>5. PAN CARD OF ESTIBLISHMENT	</p>
                    </div>
                </div>



                <%--ACKNOWLEDGEMENT NUMBER--%>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <label for="txtApplicationNumberDSC" class="font-weight-normal">APPLICATION NUMBER :</label>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <asp:TextBox ID="txtApplicationNumberDSC" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <label for="txtDateOfAckDSC" class="font-weight-normal">DATE :</label>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <asp:TextBox ID="txtDateOfAckDSC" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3 mt-5">
                    <asp:Button ID="btnRegistrationDSC" CssClass="btn btn-success btn-sm w-50" runat="server" Text="Regisration(DSC)" OnClick="btnRegistrationDSC_Click" />
                    <asp:Button ID="btnUpdateDSC" CssClass="btn btn-warning btn-sm w-50" runat="server" Text="Update(DSC)" Visible="false" OnClick="btnUpdateDSC_Click" />
                </div>

            </div>

            <%--GST--%>
            <div class="row shadow rounded-bottom" style="background-color: #ffffff;" runat="server" id="divRegFormGST" visible="false">
                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3">
                    <h2 class="font-weight-light text-success">GST Registration Form</h2>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtLegalBusinessNameGST" class="font-weight-normal">Legal Name of the Business :</label>
                        <asp:TextBox ID="txtLegalBusinessNameGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtAdhaarGST" class="font-weight-normal">Adhaar Number :</label>
                        <asp:TextBox ID="txtAdhaarGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtPanGST" class="font-weight-normal">PAN :</label>
                        <asp:TextBox ID="txtPanGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtTradeNameGST" class="font-weight-normal">Trade Name :</label>
                        <asp:TextBox ID="txtTradeNameGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlConstituitionOfBusinessGST" class="font-weight-normal">Constitution of Business :</label>
                        <asp:DropDownList ID="ddlConstituitionOfBusinessGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Proprietorship</asp:ListItem>
                            <asp:ListItem Value="2">Partership</asp:ListItem>
                            <asp:ListItem Value="3">Hindu Undevided Family</asp:ListItem>
                            <asp:ListItem Value="4">Society Club/ Trust/ Association of Persons</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlCasualTaxablePersonGST" class="font-weight-normal">Are you applying for registration as a casual taxable person ? :</label>
                        <asp:DropDownList ID="ddlCasualTaxablePersonGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Value="2">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlOptionsForCommissionGST" class="font-weight-normal">Options for Composition :</label>
                        <asp:DropDownList ID="ddlOptionsForCommissionGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Value="2">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlReasonToObtainRegistrationGST" class="font-weight-normal">Reason to obtain Registration :</label>
                        <asp:DropDownList ID="ddlReasonToObtainRegistrationGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Due to crossing the Threshold</asp:ListItem>
                            <asp:ListItem Value="2">Due to inter-State supply</asp:ListItem>
                            <asp:ListItem Value="3">Due to liability to pay as recipient of services</asp:ListItem>
                            <asp:ListItem Value="4">Due to being Input Service Distributor (ISD)</asp:ListItem>
                            <asp:ListItem Value="5">On voluntary basis</asp:ListItem>
                            <asp:ListItem Value="6">Due to transfer of Business which includes change in the ownership of business (if transferee is not a registered entity)</asp:ListItem>
                            <asp:ListItem Value="7">Due to death of the Proprietor (if the successor is not a registered entity)</asp:ListItem>
                            <asp:ListItem Value="8">Due to de-merger</asp:ListItem>
                            <asp:ListItem Value="9">Due to change in constitution of business</asp:ListItem>
                            <asp:ListItem Value="10">Due to Merger /Amalgamation of two or more registered taxpayers</asp:ListItem>
                            <asp:ListItem Value="11">Due to Migration</asp:ListItem>
                            <asp:ListItem Value="12">Being casual Dealer</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtDateOfCommencementGST" class="font-weight-normal">Date of Commencement of Business :</label>
                        <asp:TextBox ID="txtDateOfCommencementGST" TextMode="Date" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtDateOnLiabbilityGST" class="font-weight-normal">Date on which liability to register arises :</label>
                        <asp:TextBox ID="txtDateOnLiabbilityGST" TextMode="Date" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <h3 class="text-primary font-weight-light">Details of Proprietor </h3>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtNameofPersonGST" class="font-weight-normal">Name of the Person :</label>
                        <asp:TextBox ID="txtNameofPersonGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtFatherNameGST" class="font-weight-normal">Father Name :</label>
                        <asp:TextBox ID="txtFatherNameGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtDOBGST" class="font-weight-normal">DOB :</label>
                        <asp:TextBox ID="txtDOBGST" TextMode="Date" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="ddlGenderGST" class="font-weight-normal">Gender :</label>
                        <asp:DropDownList ID="ddlGenderGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Male</asp:ListItem>
                            <asp:ListItem Value="2">Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtMobileGST" class="font-weight-normal">Mobile :</label>
                        <asp:TextBox ID="txtMobileGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtEmailGST" class="font-weight-normal">Email :</label>
                        <asp:TextBox ID="txtEmailGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtAuthorisedSignatoryGST" class="font-weight-normal">Authorised Signatory :</label>
                        <asp:TextBox ID="txtAuthorisedSignatoryGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlDesignationGST" class="font-weight-normal">Designation :</label>
                        <asp:DropDownList ID="ddlDesignationGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Proprietor</asp:ListItem>
                            <asp:ListItem Value="2">Partner</asp:ListItem>
                            <asp:ListItem Value="3">Director</asp:ListItem>
                            <asp:ListItem Value="4">Head of HUF</asp:ListItem>
                            <asp:ListItem Value="5">Accountant</asp:ListItem>
                            <asp:ListItem Value="6">Secretary</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlNoOfPartnersGST" class="font-weight-normal">Number of Partners/Directors :</label>

                        <asp:DropDownList ID="ddlNoOfPartnersGST" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlConcernDealsWithGST" class="font-weight-normal">Concern Deals with :</label>
                        <asp:DropDownList ID="ddlConcernDealsWithGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Goods</asp:ListItem>
                            <asp:ListItem Value="2">Services</asp:ListItem>
                            <asp:ListItem Value="3">Services &amp; Goods</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtResidentialAddressWithPinGST" class="font-weight-normal">Residential Address with PIN :</label>
                        <asp:TextBox ID="txtResidentialAddressWithPinGST" TextMode="MultiLine" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                        <span class="text-primary small float-left">*Note : Only 135 charcters are allowed</span>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <h3 class="text-primary font-weight-light">Details of Authorised Signatory </h3>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6" hidden="hidden">
                    <div class="form-group">
                        <label for="ddlAuthorisedSignatoryGST" class="font-weight-normal">Details of Authorised Signatory  :</label>
                        <asp:DropDownList ID="ddlAuthorisedSignatoryGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Value="2">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlAdditionalRepresentativeGST" class="font-weight-normal">Do you have any authorised representative ? :</label>
                        <asp:DropDownList ID="ddlAdditionalRepresentativeGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Value="2">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtAutorisedRepresentativeNameGST" class="font-weight-normal">Name :</label>
                        <asp:TextBox ID="txtAutorisedRepresentativeNameGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>



                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtPrincipalPlaceGST" class="font-weight-normal">Details of Principal Place of Business with PIN :</label>
                        <asp:TextBox ID="txtPrincipalPlaceGST" CssClass="form-control form-control-sm" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlStateGST" class="font-weight-normal">State Jurisdiction :</label>
                        <asp:DropDownList ID="ddlStateGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Tripura</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtSecCirWardChargeGST" class="font-weight-normal">Sector/ Circle/ Ward/ Charge :</label>
                        <asp:TextBox ID="txtSecCirWardChargeGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtCommisionerateGST" class="font-weight-normal">Commisionerate  :</label>
                        <asp:TextBox ID="txtCommisionerateGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="ddlDivisionGST" class="font-weight-normal">Division :</label>
                        <asp:DropDownList ID="ddlDivisionGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Division--</asp:ListItem>
                            <asp:ListItem Value="1">Tripura I</asp:ListItem>
                            <asp:ListItem Value="2">Tripura II</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="ddlRangeGST" class="font-weight-normal">Range  :</label>
                        <asp:DropDownList ID="ddlRangeGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Range --</asp:ListItem>                            
                            <asp:ListItem Value="1">Dharmanagar Range</asp:ListItem>
                            <asp:ListItem Value="2">Teliamura Range</asp:ListItem>
                            <asp:ListItem Value="3">Udaipur Range</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlNatureOfPossesionGST" class="font-weight-normal">Nature of possession fo premises :</label>
                        <asp:DropDownList ID="ddlNatureOfPossesionGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Range --</asp:ListItem>
                            <asp:ListItem Value="1">Owned</asp:ListItem>
                            <asp:ListItem Value="2">Leased</asp:ListItem>
                            <asp:ListItem Value="3">Rented</asp:ListItem>
                            <asp:ListItem Value="4">Consent</asp:ListItem>
                            <asp:ListItem Value="5">Shared</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6" hidden="hidden">
                    <div class="form-group">
                        <label for="txtProofOfPrincipalPlaceGST" class="font-weight-normal">Proof of Principal Place of Business :</label>
                        <asp:TextBox ID="txtProofOfPrincipalPlaceGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlNatureofBusinessGST" class="font-weight-normal">Nature of Business Activity being carried out at above mentioned premises  :</label>
                        <asp:DropDownList ID="ddlNatureofBusinessGST" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Selected="True" Value="0">-- Select Range --</asp:ListItem>
                            <asp:ListItem Value="1">Factory / Manufacturing</asp:ListItem>
                            <asp:ListItem Value="2">Wholesale Business</asp:ListItem>
                            <asp:ListItem Value="3">Retail Business</asp:ListItem>
                            <asp:ListItem Value="4">Warehouse/Deport</asp:ListItem>
                            <asp:ListItem Value="5">Bonded Warehouse</asp:ListItem>
                            <asp:ListItem Value="6">Service Provision</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtAdditionalBusinessPlaceGST" class="font-weight-normal">Have Additional Place of Business :</label>
                        <asp:TextBox ID="txtAdditionalBusinessPlaceGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtDetailsOfGdComdtGST" class="font-weight-normal">Details of Goods / Commodities supplied by the business (HSN code) :</label>
                        <asp:TextBox ID="txtDetailsOfGdComdtGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtPTaxRegCertfGST" class="font-weight-normal">Professional Tax Registration Certificate (RC) No. :</label>
                        <asp:TextBox ID="txtPTaxRegCertfGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="txtPTaxEmpCodeGST" class="font-weight-normal">Professional Tax Employee Code (EC) No. :</label>
                        <asp:TextBox ID="txtPTaxEmpCodeGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtPTaxTrnNumberGST" class="font-weight-normal">TRN Number :</label>
                        <asp:TextBox ID="txtTrnNumberGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <asp:CheckBox ID="chkAgreeGST" runat="server" />
                        <span class="small text-danger font-weight-normal">I hereby solemnly affirm and declare that the information given herein above is true and correct to the best of my knowledge and belief and nothing has been concealed therefrom.										
                        </span>
                    </div>
                </div>

                <div class="col-lg-2 col-md-2 col-sm-2 font-weight-normal">
                    <div class="form-group">
                        <span class="text-black mb-2">Note: <u>Document Required </u></span>
                    </div>
                </div>
                <div class="col-lg-5 col-md-5 col-sm-5 font-weight-normal">
                    <div class="form-group">
                        <p>1. PAN CARD</p>
                        <p>2. ADHAAR CARD</p>
                        <p>3. RENT AGREEMENT</p>
                        <p>4. LETTER OF AUTHERATION</p>
                        <p>5. CONSENT LETTER</p>
                    </div>
                </div>
                <div class="col-lg-5 col-md-5 col-sm-5 font-weight-normal">
                    <div class="form-group">
                        <p>6. ELECTRIC BILL</p>
                        <p>7. TRADE LICENCE</p>
                        <p>8. PARTNERSHIP DEED</p>
                        <p>9. PHOTO</p>
                    </div>
                </div>

                <%--ACKNOWLEDGEMENT NUMBER--%>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <label for="txtApplicationNumberGST" class="font-weight-normal">APPLICATION NUMBER :</label>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <asp:TextBox ID="txtApplicationNumberGST" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <label for="txtDateOfAckGST" class="font-weight-normal">DATE :</label>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 text-center">
                    <div class="form-group">
                        <asp:TextBox ID="txtDateOfAckGST" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3 mt-5">
                    <asp:Button ID="btnRegistrationGST" CssClass="btn btn-success btn-sm w-50" runat="server" Text="Regisration(GST)" OnClick="btnRegistrationGST_Click" />
                    <asp:Button ID="btnUpdateGST" CssClass="btn btn-warning btn-sm w-50" runat="server" Text="Update(GST)" Visible="false" OnClick="btnUpdateGST_Click" />
                </div>

            </div>


            <%--ACCOUNTS--%>
            <div class="row shadow rounded-bottom" style="background-color: #ffffff;" runat="server" id="divRegFormAccounts" visible="false">
                <div class="col-lg-12 col-md-12 col-sm-12 text-center mb-3">
                    <h2 class="font-weight-light text-success">Accounts Registration Form</h2>
                </div>

                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtPanACN" class="font-weight-normal">PAN Number. :</label>
                        <asp:TextBox ID="txtPanACN" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <label for="txtAcknowledgementNoACN" class="font-weight-normal">Acknowledgement Number :</label>
                        <asp:TextBox ID="txtAcknowledgementNoACN" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 text-center">
                    <div class="form-group">
                        <label for="txtDateOfAckACN" class="font-weight-normal">DATE :</label>
                        <asp:TextBox ID="txtDateOfAckACN" CssClass="form-control form-control-sm" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group text-center">
                        <asp:Button ID="btnRegistrationAccountsACN" CssClass="btn btn-success btn-sm w-50" runat="server" Text="Regisration(Accounts)" OnClick="btnRegistrationAccountsACN_Click" />
                        <asp:Button ID="btnUpdateAccountsACN" CssClass="btn btn-warning btn-sm w-50" runat="server" Text="Update(ACCOUNTS)" Visible="false" OnClick="btnUpdateAccountsACN_Click" />
                    </div>
                </div>
            </div>
        </div>
        <%--end of parent div--%>
    </div>

    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="../js/md5hash.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {

            $(':input').css('border-width', '1px').css('border-color', 'black').css('border-radius', '0px');

            //begin of session timeout
            var sessionTimeOutValue = '<%= Session.Timeout %>';

            var sec = sessionTimeOutValue * 60,
            countDiv = document.getElementById("ctl00_spanDateTime"),
            secpass,
            countDown = setInterval(function () {
                'use strict';

                secpass();
            }, 1000);

            function secpass() {
                'use strict';

                var min = Math.floor(sec / 60),
                    remSec = sec % 60;

                if (remSec < 10) {

                    remSec = '0' + remSec;

                }
                if (min < 10) {

                    min = '0' + min;

                }
                countDiv.innerHTML = min + ":" + remSec;

                if (sec > 0) {

                    sec = sec - 1;

                } else {

                    clearInterval(countDown);

                    countDiv.innerHTML = 'Session Expired.';

                }
            }


            //end of session timeout

            document.getElementById("ctl00_ContentPlaceHolder1_txtAddressDSC").maxLength = "135";
            document.getElementById("ctl00_ContentPlaceHolder1_txtResidentialAddressWithPinGST").maxLength = "135";
            document.getElementById("ctl00_ContentPlaceHolder1_txtEstablishmentAddressPTAX").maxLength = "135";

        });

        $(document).ready(function () {
            $('#ContentPlaceHolder1_btnRegistration').click(function () {
                if ($('#ContentPlaceHolder1_txtPassword').val().length > 0) {
                    var password = $('#ContentPlaceHolder1_txtPassword').val().trim();
                    $('#ContentPlaceHolder1_txtPassword').val(MD5(password));
                }
            });
        });


    </script>

    <script>
        function onlyNumberKey(evt) {

            // Only ASCII character in that range allowed
            var ASCIICode = (evt.which) ? evt.which : evt.keyCode
            if (ASCIICode > 31 && (ASCIICode < 48 || ASCIICode > 57))
                return false;
            return true;
        }

    </script>
</asp:Content>


