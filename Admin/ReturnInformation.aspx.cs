using MerchantMirrour;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ReturnInformation : System.Web.UI.Page
{
    Utility utility;
    DataSet dsGeneralInformation;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropDownListServices();
            LoadDistricts();

            LoadDistrictsIntoRubber(); // for rubber

            if (Session != null)
            {

            }
            else
            {
                Response.Redirect("../LoginPage.aspx");
            }
        }
    }
    public void FillDropDownListServices()
    {
        DataBase database = new DataBase();
        ddlServices.DataSource = database.GetAllServices();
        ddlServices.DataValueField = "serviceid";
        ddlServices.DataTextField = "servicename";
        ddlServices.DataBind();
        ddlServices.Items.Insert(0, new ListItem("-- Select Service --", "0"));
    }
    protected void btnFindCustomer_Click(object sender, EventArgs e)
    {

        FillDropDown(txtCustomerId.Text);

        // create a session object of customer general information
        //DataBase.GeneralInformation generalInformation = new DataBase.GeneralInformation();
        //generalInformation.customername = dsGeneralInformation.Tables[0].Rows[0][8].ToString();
        //generalInformation.fathersname = dsGeneralInformation.Tables[0].Rows[0][9].ToString();
        //generalInformation.email = dsGeneralInformation.Tables[0].Rows[0][10].ToString();
        //generalInformation.contact = dsGeneralInformation.Tables[0].Rows[0][11].ToString();
        //generalInformation.adhaar = dsGeneralInformation.Tables[0].Rows[0][12].ToString();
        //generalInformation.voterid = dsGeneralInformation.Tables[0].Rows[0][13].ToString();
        //generalInformation.pannumber = dsGeneralInformation.Tables[0].Rows[0][14].ToString();


        //// clear the session before creating 
        //if (Session["GeneralInformation"] != null)
        //    Session.Remove("GeneralInformation");
        //else
        //    Session["GeneralInformation"] = generalInformation;
    }
    protected void btnOpen_Click(object sender, EventArgs e)
    {

        if (ddlFileNumbers.SelectedValue.ToString() == "1")
        {
            RUBBERBOARDService.Visible = true;



            utility = new Utility();
            DataSet dsLoadReturnInfo = new DataSet();

            string outputmessage = string.Empty;
            string isreturninfoexists = string.Empty;

            dsLoadReturnInfo = utility.ReturnServiceAlreadySubmitted(txtCustomerId.Text, int.Parse(ddlFileNumbers.SelectedValue.ToString()), out outputmessage, out isreturninfoexists);

            if (dsLoadReturnInfo.Tables.Count != 0)
            {
                int RoleId = int.Parse(Session["Role"].ToString());
                EnabledDisabledInputsOnRoles(dsLoadReturnInfo, RoleId, int.Parse(ddlFileNumbers.SelectedValue.ToString()));

                btnUpdateRubber.Visible = true;
                btnSaveRubberInfo.Visible = false;
            }
            else
            {
                ResetInputs(1);
                btnUpdateRubber.Visible = false;
                btnSaveRubberInfo.Visible = true;
            }

            PTAXService.Visible = false;
            INCOMETAXService.Visible = false;
            DSCService.Visible = false;
            GSTService.Visible = false;
            ACCOUNTService.Visible = false;
        }
        else if (ddlFileNumbers.SelectedValue.ToString() == "2")
        {
            GSTService.Visible = true;

            RUBBERBOARDService.Visible = false;
            PTAXService.Visible = false;
            INCOMETAXService.Visible = false;
            DSCService.Visible = false;
            ACCOUNTService.Visible = false;
        }
        else if (ddlFileNumbers.SelectedValue.ToString() == "3")
        {
            INCOMETAXService.Visible = true;

            PTAXService.Visible = false;
            RUBBERBOARDService.Visible = false;
            DSCService.Visible = false;
            GSTService.Visible = false;
            ACCOUNTService.Visible = false;
        }
        else if (ddlFileNumbers.SelectedValue.ToString() == "4")
        {
            ACCOUNTService.Visible = true;

            INCOMETAXService.Visible = false;
            PTAXService.Visible = false;
            RUBBERBOARDService.Visible = false;
            DSCService.Visible = false;
            GSTService.Visible = false;
        }
        else if (ddlFileNumbers.SelectedValue.ToString() == "5")
        {
            PTAXService.Visible = true;

            INCOMETAXService.Visible = false;
            RUBBERBOARDService.Visible = false;
            DSCService.Visible = false;
            GSTService.Visible = false;
            ACCOUNTService.Visible = false;
        }
        else if (ddlFileNumbers.SelectedValue.ToString() == "6")
        {
            DSCService.Visible = true;

            utility = new Utility();
            DataSet dsLoadReturnInfo = new DataSet();

            string outputmessage = string.Empty;
            string isreturninfoexists = string.Empty;

            dsLoadReturnInfo = utility.ReturnServiceAlreadySubmitted(txtCustomerId.Text, int.Parse(ddlFileNumbers.SelectedValue.ToString()), out outputmessage, out isreturninfoexists);

            if (dsLoadReturnInfo.Tables.Count != 0)
            {
                int RoleId = int.Parse(Session["Role"].ToString());
                EnabledDisabledInputsOnRoles(dsLoadReturnInfo, RoleId, int.Parse(ddlFileNumbers.SelectedValue.ToString()));

                btnUpdateDSCInfo.Visible = true;
                btnSaveDSCInfo.Visible = false;
            }
            else
            {
                ResetInputs(1);
                btnUpdateDSCInfo.Visible = false;
                btnSaveDSCInfo.Visible = true;
            }




            INCOMETAXService.Visible = false;
            RUBBERBOARDService.Visible = false;
            PTAXService.Visible = false;
            GSTService.Visible = false;
            ACCOUNTService.Visible = false;
        }
        else if (ddlFileNumbers.SelectedValue.ToString() == "7")
        {

        }
    }
    public void FillDropDown(string customerid)
    {

        utility = new Utility();
        dsGeneralInformation = utility.GetRegisteredCustomerServices(customerid);

        ddlFileNumbers.DataSource = dsGeneralInformation;
        ddlFileNumbers.DataTextField = "filenumber";
        ddlFileNumbers.DataValueField = "servicetakenon";
        ddlFileNumbers.DataBind();
        ddlFileNumbers.Items.Insert(0, new ListItem("-- Select FileNumber --", "0"));
    }
    protected void btnSavePtaxInfo_Click(object sender, EventArgs e)
    {

        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();

        serviceDetails.customerid = txtCustomerId.Text;
        serviceDetails.filenumber = ddlFileNumbers.SelectedItem.Text.Trim();
        serviceDetails.applicantname = txtapplicantnamePTAX.Text;
        serviceDetails.establishmentname = txtestablishmentnamePTAX.Text;
        serviceDetails.establishmentaddress = txtestablishmentaddressPTAX.Text;
        serviceDetails.district = int.Parse(ddlDistrictPTAX.SelectedValue.ToString());
        serviceDetails.pin = txtPinPTAX.Text;
        serviceDetails.mobile = txtMobilePTAX.Text;
        serviceDetails.email = txtEmailPTAX.Text;
        serviceDetails.areaofjurisdiction = txtJurisdictionPTAX.Text;
        serviceDetails.charge = txtChargePTAX.Text;
        serviceDetails.engagedwith = int.Parse(ddlEngageWithPTAX.SelectedValue.ToString());
        serviceDetails.category = int.Parse(ddlCategoryPTAX.SelectedValue.ToString());
        serviceDetails.subcategory = int.Parse(ddlSubcategoryPTAX.SelectedValue.ToString());
        serviceDetails.dateofcommencement = Convert.ToDateTime(txtDateOfCommencementPTAX.Text);
        serviceDetails.gstin = txtGSTINPTAX.Text;
        serviceDetails.vehiclecategory = int.Parse(rdVehiclesPTAX.SelectedValue.ToString());
        serviceDetails.levelofsociety = int.Parse(rbLevelSocietyPTAX.SelectedValue.ToString());
        serviceDetails.username = txtUserNamePTAX.Text;
        serviceDetails.password = txtPasswordPTAX.Text;
        serviceDetails.enrolmentnumber = txtUserNamePTAX.Text;
        serviceDetails.applicationnumber = txtUserNamePTAX.Text;
        serviceDetails.taxperiod = txtUserNamePTAX.Text;
        serviceDetails.paymentdate = Convert.ToDateTime(txtPaymentDatePTAX.Text);
        serviceDetails.amount = decimal.Parse(txtAmountPTAX.Text);
        serviceDetails.paymentreqnumber = txtPaymentReqNoPTAX.Text;
        serviceDetails.grn = txtGRNPTAX.Text;
        serviceDetails.cin = txtCINPTAX.Text;
        serviceDetails.transactionstatus = txtTransactionStatsPTAX.Text;
        serviceDetails.enteredby = Session["User"].ToString();
        serviceDetails.dateofinsert = DateTime.Now;


        utility = new Utility();
        utility.InsertPtaxServiceDetails(serviceDetails);

        divSuccess.Visible = true;
        lblSuccess.InnerText = "Return Information Submitted Successfully.";
        divError.Visible = false;
        lblError.Visible = false;

        //clear all the input controls
        ResetInputs(5);
    }
    public void ResetInputs(int serviceID)
    {
        #region PTAX
        if (serviceID == 5)
        {
            txtCustomerId.Text = string.Empty;
            ddlFileNumbers.SelectedIndex = 0;
            txtapplicantnamePTAX.Text = string.Empty;
            txtestablishmentnamePTAX.Text = string.Empty;
            txtestablishmentaddressPTAX.Text = string.Empty;
            ddlDistrictPTAX.SelectedIndex = 0;
            txtPinPTAX.Text = string.Empty;
            txtMobilePTAX.Text = string.Empty;
            txtEmailPTAX.Text = string.Empty;
            txtJurisdictionPTAX.Text = string.Empty;
            txtChargePTAX.Text = string.Empty;
            ddlEngageWithPTAX.SelectedIndex = 0;
            ddlCategoryPTAX.SelectedIndex = 0;
            ddlSubcategoryPTAX.SelectedIndex = 0;
            txtDateOfCommencementPTAX.Text = string.Empty;
            txtGSTINPTAX.Text = string.Empty;
            rdVehiclesPTAX.SelectedValue = string.Empty;
            rbLevelSocietyPTAX.SelectedValue = string.Empty;
            txtUserNamePTAX.Text = string.Empty;
            txtPasswordPTAX.Text = string.Empty;
            txtUserNamePTAX.Text = string.Empty;
            txtUserNamePTAX.Text = string.Empty;
            txtUserNamePTAX.Text = string.Empty;
            txtPaymentDatePTAX.Text = string.Empty;
            txtAmountPTAX.Text = string.Empty;
            txtPaymentReqNoPTAX.Text = string.Empty;
            txtGRNPTAX.Text = string.Empty;
            txtCINPTAX.Text = string.Empty;
            txtTransactionStatsPTAX.Text = string.Empty;
        }
        #endregion
        #region ITAX
        else if (serviceID == 5)
        {
            ddlApplyingAsITAX.SelectedIndex = 0;
            txtMobileITAX.Text = string.Empty;
            txtApplicantNameITAX.Text = string.Empty;
            txtEmailITAX.Text = string.Empty;
            txtPanITAX.Text = string.Empty;
            txtRoadStreetITAX.Text = string.Empty;
            txtAreaLocalityITAX.Text = string.Empty;
            txtPostOfficeITAX.Text = string.Empty;
            ddlStateITAX.Text = string.Empty;
            ddlCountryITAX.Text = string.Empty;
            txtPinITAX.Text = string.Empty;
            txtUsernameITAX.Text = string.Empty;
            txtPasswordITAX.Text = string.Empty;
            txtTransactionIdITAX.Text = string.Empty;
            ddlFinancialYearITAX.SelectedIndex = 0;
            ddlAssessmentITAX.SelectedIndex = 0;
            ddlReturnTypeITAX.SelectedIndex = 0;
            rbform26asITAX.ClearSelection();
            txtReturnFormITAX.Text = string.Empty;
            txtTaxPaymentITAX.Text = string.Empty;
            txtBrsCodeITAX.Text = string.Empty;
            txtReturnFilledDateITAX.Text = string.Empty;
            txtITAcknowledgementITAX.Text = string.Empty;
        }

        #endregion
        #region RUBBER
        else if (serviceID == 1)
        {
            txtCustomerCodeRBR.Text = string.Empty;
            txtFileNumberRBR.Text = string.Empty;
            txtDealershipNoRBR.Text = string.Empty;
            txtLicenceValidTillRBR.Text = string.Empty;
            txtConcernNameRBR.Text = string.Empty;
            txtOwnerNameRBR.Text = string.Empty;
            txtMobielRBR.Text = string.Empty;
            txtEmailRBR.Text = string.Empty;
            txtBusinessPlaceRB_BSP.Text = string.Empty;
            txtBuildingTypeRB_BSP.Text = string.Empty;
            txtBuildingPlotNoRB_BSP.Text = string.Empty;
            txtCityRB_BSP.Text = string.Empty;
            ddlDistrictRB_BSP.SelectedIndex = 0;
            ddlStateRB_BSP.SelectedIndex = 0;
            txtPINRB_BSP.Text = string.Empty;
            txtMobileRB_BSP.Text = string.Empty;
            txtEmailRB_BSP.Text = string.Empty;
            txtPresentPermanentAddressRB_PPA.Text = string.Empty;
            txtCityRB_PPA.Text = string.Empty;
            ddlDistrictRB_Address_PPA.SelectedIndex = 0;
            ddlStateRB_PPA.SelectedIndex = 0;
            txtPINRB_PPA.Text = string.Empty;
            txtUsernameRBR_PPA.Text = string.Empty;
            txtPasswordRBR_PPA.Text = string.Empty;
            txtAmmendmentMadeOnRBR_PPA.Text = string.Empty;
            txtApplicationNumberRBR_PPA.Text = string.Empty;

            txtDateRBR_PPA.Text = string.Empty;
            ddlFinancialYearRBR_PPA.SelectedIndex = 0;
            ddlReturnH2RBR_PPA.SelectedIndex = 0;
            ddlReturnLRBR_PPA.SelectedIndex = 0;

        }
        #endregion
        #region DSC
        else if (serviceID == 6)
        {
            txtCustomerCodeDSC.Text = string.Empty;
            txtFileNumberDSC.Text = string.Empty;
            txtApplicantNameDSC.Text = string.Empty;
            txtEstablishmentNameDSC.Text = string.Empty;
            txtDOBDSC.Text = string.Empty;
            txtMobileDSC.Text = string.Empty;
            txtEmailDSC.Text = string.Empty;
            txtAddressDSC.Text = string.Empty;
            ddlDistrictDSC.SelectedIndex = 0;
            txtPINDSC.Text = string.Empty;
            txtShareCodeDSC.Text = string.Empty;
            txtChallengeCodeDSC.Text = string.Empty;
            txtDesiredUserNameDSC.Text = string.Empty;
            txtDesiredPasswordDSC.Text = string.Empty;
            txtApplicationNumberDSC.Text = string.Empty;
            txtEtokenPWDSC.Text = string.Empty;
            txtDSCValidUptoDSC.Text = string.Empty;
        }
        #endregion
        #region GST
        else if (serviceID == 2)
        {
            txtCustomerCodeGST.Text = string.Empty;
            ddlFileNumbers.SelectedIndex = 0;
            ddlMonthGST.SelectedIndex = 0;
            ddlReturnTypeGstr1GST.SelectedIndex = 0;
            ddlReturnTypeGstr3bGST.SelectedIndex = 0;
            txtGSTINGST.Text = string.Empty;
            txtFileNameGST.Text = string.Empty;
            txtSerialNumberGST.Text = string.Empty;
            txtConcernNameGST.Text = string.Empty;
            txtConcernAddressGST.Text = string.Empty;
            txtDateOfRegistrationGST.Text = string.Empty;
            ddlRegistrationTypeGST.SelectedIndex = 0;
            txtUsernameGST.Text = string.Empty;
            txtPasswordGST.Text = string.Empty;
            txtMobileGST.Text = string.Empty;
            txtEmailGST.Text = string.Empty;
            ddlChallanMadeOnGST.SelectedIndex = 0;
            ddlGSTINAssignGST.SelectedIndex = 0;
            txtEwayBillUsernameGST.Text = string.Empty;
            txtEwayBillPasswordGST.Text = string.Empty;
            txtCompliancesGST.Text = string.Empty;
            txtActionTakenGST.Text = string.Empty;
            ddlFinancialYearGST.SelectedIndex = 0;
            ddlSalesStatementGST.SelectedIndex = 0;
            ddlPurchaseStatementGST.SelectedIndex = 0;
            txtSalesPurchaseStmtGST.Text = string.Empty;
            ddlEWayBillDetailsGST.SelectedIndex = 0;
            ddlFiledGstrGST.SelectedIndex = 0;
            txtEwayFIledGstrOnGST.Text = string.Empty;
            ddlCheckGstr2a2bGST.SelectedIndex = 0;
            ddlCheckLiabilityComparisonGST.SelectedIndex = 0;
            ddlCheckTdsTcsGST.SelectedIndex = 0;
            ddlReconciliationStatementGST.SelectedIndex = 0;
            ddlFiledGstr3bpmt8GST.SelectedIndex = 0;
            txtReconciliationStatementGST.Text = string.Empty;
            ddlFiledDrc8.SelectedIndex = 0;
            txtDrc8FiledOnGST.Text = string.Empty;
            ddlCashCreditLedgerGST.SelectedIndex = 0;
            txtDocumentFilledAndCheckedByGST.Text = string.Empty;
            txtGSTINAssignGST.Text = string.Empty;
            txtVerifiedByGST.Text = string.Empty;
        }
        #endregion
    }
    protected void btnSaveItaxInfo_Click(object sender, EventArgs e)
    {
        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();

        serviceDetails.customerid = txtCustomerId.Text;
        serviceDetails.filenumber = ddlFileNumbers.SelectedItem.Text.Trim();
        serviceDetails.applyingas = int.Parse(ddlApplyingAsITAX.SelectedValue.ToString());
        serviceDetails.mobile = txtMobileITAX.Text;
        serviceDetails.applicantname = txtApplicantNameITAX.Text;
        serviceDetails.email = txtEmailITAX.Text;
        serviceDetails.pan = txtPanITAX.Text;
        serviceDetails.establishmentname = txtestablishmentnamePTAX.Text;
        serviceDetails.establishmentaddress = txtestablishmentaddressPTAX.Text;
        serviceDetails.district = int.Parse(ddlDistrictPTAX.SelectedValue.ToString());
        serviceDetails.pin = txtPinPTAX.Text;
        serviceDetails.address = txtRoadStreetITAX.Text;
        serviceDetails.arealocality = txtAreaLocalityITAX.Text;
        serviceDetails.postoffice = txtPostOfficeITAX.Text;
        serviceDetails.state = int.Parse(ddlStateITAX.SelectedValue.ToString());
        serviceDetails.country = int.Parse(ddlCountryITAX.SelectedValue.ToString());
        serviceDetails.pin = txtPinITAX.Text;
        serviceDetails.username = txtUsernameITAX.Text;
        serviceDetails.password = txtPasswordITAX.Text;
        serviceDetails.transactionid = txtTransactionIdITAX.Text;
        serviceDetails.financialyear = ddlFinancialYearITAX.SelectedItem.Text;
        serviceDetails.assessmentyear = ddlAssessmentITAX.SelectedItem.Text;
        serviceDetails.returntype = int.Parse(ddlReturnTypeITAX.SelectedValue.ToString());
        serviceDetails.downloadform26 = rbform26asITAX.SelectedValue.ToString() == "Yes" ? true : false;
        serviceDetails.returnform = txtReturnFormITAX.Text;
        serviceDetails.taxpayment = txtTaxPaymentITAX.Text;
        serviceDetails.brscode = txtBrsCodeITAX.Text;
        serviceDetails.returnfilldate = txtReturnFilledDateITAX.Text;
        serviceDetails.itracknowledgement = txtITAcknowledgementITAX.Text;
        serviceDetails.enteredby = Session["User"].ToString();
        serviceDetails.dateofinsert = DateTime.Now;


        utility = new Utility();
        utility.InsertItaxServiceDetails(serviceDetails);

        divSuccess.Visible = true;
        lblSuccess.InnerText = "Return Information Submitted Successfully.";
        divError.Visible = false;
        lblError.Visible = false;

        //clear all the input controls
        ResetInputs(3);
    }
    protected void btnAddMoreServices_Click(object sender, EventArgs e)
    {
        utility = new Utility();
        Utility.GeneralInformation generalInformation = new Utility.GeneralInformation();
        generalInformation.customercode = txtCustomerId.Text;
        generalInformation.filenumber = utility.CreateFileNumber(int.Parse(ddlServices.SelectedValue.ToString()), txtPanForAddNewService.Text.Trim());
        generalInformation.servicetakenon = int.Parse(ddlServices.SelectedValue.ToString());
        utility.AddNewService(generalInformation);

        // RESET ALL INPUTS
        ddlServices.SelectedIndex = 0;
        txtPanForAddNewService.Text = string.Empty;

    }
    public void LoadDistricts()
    {
        CommonInformation info = new CommonInformation();
        ddlDistrictPTAX.DataSource = info.LoadAllDistricts();
        ddlDistrictPTAX.DataTextField = "name";
        ddlDistrictPTAX.DataValueField = "id";
        ddlDistrictPTAX.DataBind();
        ddlDistrictPTAX.Items.Insert(0, new ListItem("-- Select District --", "0"));
    }
    protected void btnSaveRubberInfo_Click(object sender, EventArgs e)
    {
        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();

        serviceDetails.customerid = txtCustomerCodeRBR.Text;
        serviceDetails.filenumber = txtFileNumberRBR.Text;
        serviceDetails.dealershipnumber = txtDealershipNoRBR.Text;
        serviceDetails.licencevalidtill = Convert.ToDateTime(txtLicenceValidTillRBR.Text);
        serviceDetails.concernname = txtConcernNameRBR.Text;
        serviceDetails.ownershipname = txtOwnerNameRBR.Text;
        serviceDetails.mobile = txtMobielRBR.Text;
        serviceDetails.email = txtEmailRBR.Text;
        serviceDetails.businessplace = txtBusinessPlaceRB_BSP.Text;
        serviceDetails.buisnessbuildingtype = txtBuildingTypeRB_BSP.Text;
        serviceDetails.businessbuildingplotno = txtBuildingPlotNoRB_BSP.Text;
        serviceDetails.storagecity = txtCityRB_BSP.Text;
        serviceDetails.storagedistrict = int.Parse(ddlDistrictRB_BSP.SelectedValue.ToString());
        serviceDetails.storagestate = int.Parse(ddlStateRB_BSP.SelectedValue.ToString());
        serviceDetails.storagepin = txtPINRB_BSP.Text;
        serviceDetails.storagemobile = txtMobileRB_BSP.Text;
        serviceDetails.storageemail = txtEmailRB_BSP.Text;
        serviceDetails.presemtpermanentaddress = txtPresentPermanentAddressRB_PPA.Text;
        serviceDetails.ppacity = txtCityRB_PPA.Text;
        serviceDetails.ppadistrict = int.Parse(ddlDistrictRB_Address_PPA.SelectedValue.ToString());
        serviceDetails.ppastate = int.Parse(ddlStateRB_PPA.SelectedValue.ToString());
        serviceDetails.ppapin = txtPINRB_PPA.Text;
        serviceDetails.username = txtUsernameRBR_PPA.Text;
        serviceDetails.password = txtPasswordRBR_PPA.Text;
        serviceDetails.ammendment = txtAmmendmentMadeOnRBR_PPA.Text;
        serviceDetails.applicationnumber = txtApplicationNumberRBR_PPA.Text;
        serviceDetails.financialyear = ddlFinancialYearRBR_PPA.SelectedValue;
        serviceDetails.returnH2 = ddlReturnH2RBR_PPA.SelectedValue;
        serviceDetails.returnL = ddlReturnLRBR_PPA.SelectedValue;
        serviceDetails.enteredby = Session["User"].ToString();
        serviceDetails.dateofinsert = DateTime.Now;


        utility = new Utility();
        utility.InsertRubberServiceDetails(serviceDetails);

        divSuccess.Visible = true;
        lblSuccess.InnerText = "Return Information Submitted Successfully.";
        divError.Visible = false;
        lblError.Visible = false;

        //clear all the input controls
        ResetInputs(1);

    }
    public void LoadDistrictsIntoRubber()
    {
        CommonInformation info = new CommonInformation();
        ddlDistrictRB_BSP.DataSource = info.LoadAllDistricts();
        ddlDistrictRB_BSP.DataTextField = "name";
        ddlDistrictRB_BSP.DataValueField = "id";
        ddlDistrictRB_BSP.DataBind();
        ddlDistrictRB_BSP.Items.Insert(0, new ListItem("-- Select District --", "0"));

        ddlDistrictRB_Address_PPA.DataSource = info.LoadAllDistricts();
        ddlDistrictRB_Address_PPA.DataTextField = "name";
        ddlDistrictRB_Address_PPA.DataValueField = "id";
        ddlDistrictRB_Address_PPA.DataBind();
        ddlDistrictRB_Address_PPA.Items.Insert(0, new ListItem("-- Select District --", "0"));

        ddlDistrictDSC.DataSource = info.LoadAllDistricts();
        ddlDistrictDSC.DataTextField = "name";
        ddlDistrictDSC.DataValueField = "id";
        ddlDistrictDSC.DataBind();
        ddlDistrictDSC.Items.Insert(0, new ListItem("-- Select District --", "0"));

    }
    protected void btnSaveDSCInfo_Click1(object sender, EventArgs e)
    {
        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();
        serviceDetails.customerid = txtCustomerCodeDSC.Text;
        serviceDetails.filenumber = txtFileNumberDSC.Text;
        serviceDetails.applicantname = txtApplicantNameDSC.Text;
        serviceDetails.establishmentname = txtEstablishmentNameDSC.Text;
        serviceDetails.dob = Convert.ToDateTime(txtDOBDSC.Text);
        serviceDetails.mobile = txtMobileDSC.Text;
        serviceDetails.email = txtEmailDSC.Text;
        serviceDetails.address = txtAddressDSC.Text;
        serviceDetails.district = int.Parse(ddlDistrictDSC.SelectedValue.ToString());
        serviceDetails.pin = txtPINDSC.Text;
        serviceDetails.sharecode = txtShareCodeDSC.Text;
        serviceDetails.chalangecode = txtChallengeCodeDSC.Text;
        serviceDetails.username = txtDesiredUserNameDSC.Text;
        serviceDetails.password = txtDesiredPasswordDSC.Text;
        serviceDetails.applicationnumber = txtApplicationNumberDSC.Text;
        serviceDetails.etokenpassword = txtEtokenPWDSC.Text;
        serviceDetails.dscvalidupto = Convert.ToDateTime(txtDSCValidUptoDSC.Text);
        serviceDetails.enteredby = Session["User"].ToString();
        serviceDetails.dateofinsert = DateTime.Now;

        utility = new Utility();
        utility.InsertDSCServiceDetails(serviceDetails);

        divSuccess.Visible = true;
        lblSuccess.InnerText = "Return Information Submitted Successfully.";
        divError.Visible = false;
        lblError.Visible = false;

        //clear all the input controls
        ResetInputs(6);
    }
    protected void btnSaveGSTInfo_Click(object sender, EventArgs e)
    {
        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();

        serviceDetails.customerid = txtCustomerCodeGST.Text;
        serviceDetails.filenumber = ddlFileNumbers.SelectedItem.Text.ToString();
        serviceDetails.year = DateTime.Now.Year;
        serviceDetails.month = int.Parse(ddlMonthGST.SelectedValue.ToString());
        serviceDetails.returntypegstr1 = int.Parse(ddlReturnTypeGstr1GST.SelectedValue.ToString());
        serviceDetails.returntypegstr3b = int.Parse(ddlReturnTypeGstr3bGST.SelectedValue.ToString());
        serviceDetails.gstin = txtGSTINGST.Text;
        serviceDetails.filename = txtFileNameGST.Text;
        serviceDetails.slno = int.Parse(txtSerialNumberGST.Text);
        serviceDetails.concernname = txtConcernNameGST.Text;
        serviceDetails.address = txtConcernAddressGST.Text;
        serviceDetails.dateofregistration = Convert.ToDateTime(txtDateOfRegistrationGST.Text);
        serviceDetails.registrationtype = int.Parse(ddlRegistrationTypeGST.SelectedValue.ToString());
        serviceDetails.username = txtUsernameGST.Text;
        serviceDetails.password = txtPasswordGST.Text;
        serviceDetails.mobile = txtMobileGST.Text;
        serviceDetails.email = txtEmailGST.Text;
        serviceDetails.challanmadeon = int.Parse(ddlChallanMadeOnGST.SelectedValue.ToString());
        serviceDetails.gstinassign = int.Parse(ddlGSTINAssignGST.SelectedValue.ToString());
        serviceDetails.ewaybillusername = txtEwayBillUsernameGST.Text;
        serviceDetails.ewaybillpassword = txtGSTINAssignGST.Text;
        serviceDetails.compliances = txtCompliancesGST.Text;
        serviceDetails.actiontaken = txtActionTakenGST.Text;
        serviceDetails.financialyear = ddlFinancialYearGST.SelectedItem.Text.ToString();
        serviceDetails.salesstatement = int.Parse(ddlSalesStatementGST.SelectedValue.ToString());
        serviceDetails.purchasestatement = int.Parse(ddlPurchaseStatementGST.SelectedValue.ToString());
        serviceDetails.receivedon = Convert.ToDateTime(txtSalesPurchaseStmtGST.Text);
        serviceDetails.checkewaybilldetails = int.Parse(ddlEWayBillDetailsGST.SelectedValue.ToString());
        serviceDetails.filedgstriiff = int.Parse(ddlFiledGstrGST.SelectedValue.ToString());
        serviceDetails.filedgstriiffon = Convert.ToDateTime(txtEwayFIledGstrOnGST.Text);
        serviceDetails.checkgstr2a2b = int.Parse(ddlCheckGstr2a2bGST.SelectedValue.ToString());
        serviceDetails.checktaxliabilities = int.Parse(ddlCheckLiabilityComparisonGST.SelectedValue.ToString());
        serviceDetails.checktdstcs = int.Parse(ddlCheckTdsTcsGST.SelectedValue.ToString());
        serviceDetails.recordgstreconciliation = int.Parse(ddlReconciliationStatementGST.SelectedValue.ToString());
        serviceDetails.filedgstr3bpmt8 = int.Parse(ddlFiledGstr3bpmt8GST.SelectedValue.ToString());
        serviceDetails.filedonreconciliation = Convert.ToDateTime(txtReconciliationStatementGST.Text);
        serviceDetails.fileddrc8regarding = int.Parse(ddlFiledDrc8.SelectedValue.ToString());
        serviceDetails.fileddrc8regardingon = Convert.ToDateTime(txtDrc8FiledOnGST.Text);
        serviceDetails.checkcashcreditleder = int.Parse(ddlCashCreditLedgerGST.SelectedValue.ToString());
        serviceDetails.documentfiledcheckby = txtDocumentFilledAndCheckedByGST.Text;
        serviceDetails.verifiedby = txtVerifiedByGST.Text;
        serviceDetails.enteredby = Session["User"].ToString();
        serviceDetails.dateofinsert = DateTime.Now;

        utility = new Utility();
        utility.InsertGSTServiceDetails(serviceDetails);

        divSuccess.Visible = true;
        lblSuccess.InnerText = "Return Information Submitted Successfully.";
        divError.Visible = false;
        lblError.Visible = false;

        //clear all the input controls
        ResetInputs(2);
    }
    protected void btnAccountsInfoACNK_Click(object sender, EventArgs e)
    {

        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();

        serviceDetails.customerid = txtCustomerId.Text;
        serviceDetails.filenumber = ddlFileNumbers.SelectedItem.Text.ToString();
        serviceDetails.bookkeepingmadeon = int.Parse(ddlBookKeepingOnACN.SelectedValue.ToString());
        serviceDetails.tallydatanumber = txtTallyDataNoACN.Text;
        serviceDetails.financialyear = ddlFinancialYearACN.SelectedValue.ToString();
        serviceDetails.month = int.Parse(ddlMonthACN.SelectedValue.ToString());
        serviceDetails.tallyexcelreceived = int.Parse(rbTallyExcelDataRcvACN.SelectedValue.ToString());
        serviceDetails.openinngstockstatement = int.Parse(rbOpeningStockStmtACN.SelectedValue.ToString());
        serviceDetails.purchasebillstatement = int.Parse(rbPurchaseBillStatementACN.SelectedValue.ToString());
        serviceDetails.salesbillstatement = int.Parse(rbSalesBillStatementACN.SelectedValue.ToString());
        serviceDetails.creditnote = int.Parse(rbCreditNoteACN.SelectedValue.ToString());
        serviceDetails.debitnote = int.Parse(rbDebitNoteACN.SelectedValue.ToString());
        serviceDetails.bankstatement = int.Parse(rbBankStatementsACN.SelectedValue.ToString());
        serviceDetails.cashbook = int.Parse(rbCashBooksACN.SelectedValue.ToString());
        serviceDetails.loanstatements = int.Parse(rbLoanStatementsACN.SelectedValue.ToString());
        serviceDetails.receiptpaymentstatement = int.Parse(rbReceivePaymentStatementACN.SelectedValue.ToString());
        serviceDetails.profitlossaccounts = int.Parse(rbProfitLossAccountsACN.SelectedValue.ToString());
        serviceDetails.balancesheet = int.Parse(rbBalanceSheetACN.SelectedValue.ToString());
        serviceDetails.purchasestatement = int.Parse(rbPurchaseStatementACN.SelectedValue.ToString());
        serviceDetails.sundrycreditorslist = int.Parse(rbSundryCreditorListACN.SelectedValue.ToString());
        serviceDetails.salesstatement = int.Parse(rbSalesSatementACN.SelectedValue.ToString());
        serviceDetails.sundrydebtorlist = int.Parse(rbSundryDebtorListACN.SelectedValue.ToString());
        serviceDetails.banksatements_rpt = int.Parse(rbBankStatementsReportACN.SelectedValue.ToString());
        serviceDetails.brs = int.Parse(rbBrsACN.SelectedValue.ToString());
        serviceDetails.cashbook_rpt = int.Parse(rbCashBookACN_Report.SelectedValue.ToString());
        serviceDetails.closingstockstatement = int.Parse(rbClosingStockStatementACN.SelectedValue.ToString());
        serviceDetails.receiptpaymentstatement_rpt = int.Parse(rbReceivePaymentStatementReportACN.SelectedValue.ToString());
        serviceDetails.observation = txtObservationACN.Text;
        serviceDetails.enteredby = Session["User"].ToString();
        serviceDetails.dateofinsert = DateTime.Now;


        utility = new Utility();
        utility.InsertAccountsServiceDetails(serviceDetails);

        divSuccess.Visible = true;
        lblSuccess.InnerText = "Return Information Submitted Successfully.";
        divError.Visible = false;
        lblError.Visible = false;

        //clear all the input controls
        ResetInputs(4);
    }

    public int FindServiceIDFromFileNumber(string filenumber)
    {
        string servicestring = filenumber.Substring(11, 3);

        if (Utility.Services.RBR.ToString() == servicestring)
            return 1;
        else if (Utility.Services.GST.ToString() == servicestring)
            return 2;
        else if (Utility.Services.ITR.ToString() == servicestring)
            return 3;
        else if (Utility.Services.ACS.ToString() == servicestring)
            return 4;
        else if (Utility.Services.PTX.ToString() == servicestring)
            return 5;
        else if (Utility.Services.DSC.ToString() == servicestring)
            return 6;
        else
            return 7;

    }

    public void EnabledDisabledInputsOnRoles(DataSet dsLoadReturnInfo, int RoleID, int serviceID)
    {
        #region SERVICE_RUBBER
        if (serviceID == 1)
        {
            txtCustomerCodeRBR.Text = dsLoadReturnInfo.Tables[0].Rows[0][1].ToString();
            txtFileNumberRBR.Text = dsLoadReturnInfo.Tables[0].Rows[0][2].ToString();
            txtDealershipNoRBR.Text = dsLoadReturnInfo.Tables[0].Rows[0][3].ToString();
            txtLicenceValidTillRBR.Text = Convert.ToDateTime(dsLoadReturnInfo.Tables[0].Rows[0][4].ToString()).ToString("yyyy-MM-dd");
            txtConcernNameRBR.Text = dsLoadReturnInfo.Tables[0].Rows[0][5].ToString();
            txtOwnerNameRBR.Text = dsLoadReturnInfo.Tables[0].Rows[0][6].ToString();
            txtMobielRBR.Text = dsLoadReturnInfo.Tables[0].Rows[0][7].ToString();
            txtEmailRBR.Text = dsLoadReturnInfo.Tables[0].Rows[0][8].ToString();
            txtBusinessPlaceRB_BSP.Text = dsLoadReturnInfo.Tables[0].Rows[0][9].ToString();
            txtBuildingTypeRB_BSP.Text = dsLoadReturnInfo.Tables[0].Rows[0][10].ToString();
            txtBuildingPlotNoRB_BSP.Text = dsLoadReturnInfo.Tables[0].Rows[0][11].ToString();
            txtCityRB_BSP.Text = dsLoadReturnInfo.Tables[0].Rows[0][12].ToString();
            ddlDistrictRB_BSP.SelectedValue = dsLoadReturnInfo.Tables[0].Rows[0][13].ToString();
            ddlStateRB_BSP.SelectedValue = dsLoadReturnInfo.Tables[0].Rows[0][14].ToString();
            txtPINRB_BSP.Text = dsLoadReturnInfo.Tables[0].Rows[0][15].ToString();
            txtMobileRB_BSP.Text = dsLoadReturnInfo.Tables[0].Rows[0][16].ToString();
            txtEmailRB_BSP.Text = dsLoadReturnInfo.Tables[0].Rows[0][17].ToString();
            txtPresentPermanentAddressRB_PPA.Text = dsLoadReturnInfo.Tables[0].Rows[0][18].ToString();
            txtCityRB_PPA.Text = dsLoadReturnInfo.Tables[0].Rows[0][19].ToString();
            ddlDistrictRB_Address_PPA.SelectedIndex = int.Parse(dsLoadReturnInfo.Tables[0].Rows[0][20].ToString());
            ddlStateRB_PPA.SelectedIndex = int.Parse(dsLoadReturnInfo.Tables[0].Rows[0][21].ToString());
            txtPINRB_PPA.Text = dsLoadReturnInfo.Tables[0].Rows[0][22].ToString();
            txtUsernameRBR_PPA.Text = dsLoadReturnInfo.Tables[0].Rows[0][23].ToString();
            txtPasswordRBR_PPA.Text = dsLoadReturnInfo.Tables[0].Rows[0][24].ToString();
            txtAmmendmentMadeOnRBR_PPA.Text = dsLoadReturnInfo.Tables[0].Rows[0][25].ToString();
            txtApplicationNumberRBR_PPA.Text = dsLoadReturnInfo.Tables[0].Rows[0][26].ToString();
            txtDateRBR_PPA.Text = Convert.ToDateTime(dsLoadReturnInfo.Tables[0].Rows[0][27].ToString()).ToString("yyyy-MM-dd");
            ddlFinancialYearRBR_PPA.SelectedValue = dsLoadReturnInfo.Tables[0].Rows[0][28].ToString();
            ddlReturnH2RBR_PPA.SelectedValue = dsLoadReturnInfo.Tables[0].Rows[0][29].ToString();
            ddlReturnLRBR_PPA.SelectedValue = dsLoadReturnInfo.Tables[0].Rows[0][30].ToString();

            if (RoleID == 1)
            {
                txtCustomerCodeRBR.Enabled = true;
                txtFileNumberRBR.Enabled = true;
                txtDealershipNoRBR.Enabled = true;
                txtLicenceValidTillRBR.Enabled = true;
                txtConcernNameRBR.Enabled = true;
                txtOwnerNameRBR.Enabled = true;
                txtMobielRBR.Enabled = true;
                txtEmailRBR.Enabled = true;
                txtBusinessPlaceRB_BSP.Enabled = true;
                txtBuildingTypeRB_BSP.Enabled = true;
                txtBuildingPlotNoRB_BSP.Enabled = true;
                txtCityRB_BSP.Enabled = true;
                ddlDistrictRB_BSP.Enabled = true;
                ddlStateRB_BSP.Enabled = true;
                txtPINRB_BSP.Enabled = true;
                txtMobileRB_BSP.Enabled = true;
                txtEmailRB_BSP.Enabled = true;
                txtPresentPermanentAddressRB_PPA.Enabled = true;
                txtCityRB_PPA.Enabled = true;
                ddlDistrictRB_Address_PPA.Enabled = true;
                ddlStateRB_PPA.Enabled = true;
                txtPINRB_PPA.Enabled = true;
                txtUsernameRBR_PPA.Enabled = true;
                txtPasswordRBR_PPA.Enabled = true;
                txtAmmendmentMadeOnRBR_PPA.Enabled = true;
                txtApplicationNumberRBR_PPA.Enabled = true;
                txtDateRBR_PPA.Enabled = true;

                ddlFinancialYearRBR_PPA.Enabled = true;
                ddlReturnH2RBR_PPA.Enabled = true;
                ddlReturnLRBR_PPA.Enabled = true;
            }
            else if (RoleID == 3) // employee can see only not edit/update
            {
                txtCustomerCodeRBR.Enabled = false;
                txtFileNumberRBR.Enabled = false;
                txtDealershipNoRBR.Enabled = false;
                txtLicenceValidTillRBR.Enabled = false;
                txtConcernNameRBR.Enabled = false;
                txtOwnerNameRBR.Enabled = false;
                txtMobielRBR.Enabled = false;
                txtEmailRBR.Enabled = false;
                txtBusinessPlaceRB_BSP.Enabled = false;
                txtBuildingTypeRB_BSP.Enabled = false;
                txtBuildingPlotNoRB_BSP.Enabled = false;
                txtCityRB_BSP.Enabled = false;
                ddlDistrictRB_BSP.Enabled = false;
                ddlStateRB_BSP.Enabled = false;
                txtPINRB_BSP.Enabled = false;
                txtMobileRB_BSP.Enabled = false;
                txtEmailRB_BSP.Enabled = false;
                txtPresentPermanentAddressRB_PPA.Enabled = false;
                txtCityRB_PPA.Enabled = false;
                ddlDistrictRB_Address_PPA.Enabled = false;
                ddlStateRB_PPA.Enabled = false;
                txtPINRB_PPA.Enabled = false;
                txtUsernameRBR_PPA.Enabled = false;
                txtPasswordRBR_PPA.Enabled = false;
                txtAmmendmentMadeOnRBR_PPA.Enabled = false;
                txtApplicationNumberRBR_PPA.Enabled = false;
                txtDateRBR_PPA.Enabled = false;


                ddlFinancialYearRBR_PPA.Enabled = true;
                ddlReturnH2RBR_PPA.Enabled = true;
                ddlReturnLRBR_PPA.Enabled = true;
            }
        }
        #endregion
        #region SERVICE_DSC
        if (serviceID == 6)
        {
            txtCustomerCodeDSC.Text = dsLoadReturnInfo.Tables[0].Rows[0][1].ToString();
            txtFileNumberDSC.Text = dsLoadReturnInfo.Tables[0].Rows[0][2].ToString();
            txtApplicantNameDSC.Text = dsLoadReturnInfo.Tables[0].Rows[0][3].ToString();
            txtEstablishmentNameDSC.Text = dsLoadReturnInfo.Tables[0].Rows[0][4].ToString();
            txtDOBDSC.Text = Convert.ToDateTime(dsLoadReturnInfo.Tables[0].Rows[0][5].ToString()).ToString("yyyy-MM-dd");
            txtMobileDSC.Text = dsLoadReturnInfo.Tables[0].Rows[0][6].ToString();
            txtEmailDSC.Text = dsLoadReturnInfo.Tables[0].Rows[0][7].ToString();
            txtAddressDSC.Text = dsLoadReturnInfo.Tables[0].Rows[0][8].ToString();
            ddlDistrictDSC.SelectedValue = dsLoadReturnInfo.Tables[0].Rows[0][9].ToString();
            txtPINDSC.Text = dsLoadReturnInfo.Tables[0].Rows[0][10].ToString();
            txtShareCodeDSC.Text = dsLoadReturnInfo.Tables[0].Rows[0][11].ToString();
            txtChallengeCodeDSC.Text = dsLoadReturnInfo.Tables[0].Rows[0][12].ToString();
            txtDesiredUserNameDSC.Text = dsLoadReturnInfo.Tables[0].Rows[0][13].ToString();
            txtDesiredPasswordDSC.Text = dsLoadReturnInfo.Tables[0].Rows[0][14].ToString();
            //txtApplicationNumberDSC.Text = dsLoadReturnInfo.Tables[0].Rows[0][15].ToString();
            //txtDatedDSC.Text = Convert.ToDateTime(dsLoadReturnInfo.Tables[0].Rows[0][16].ToString()).ToString("yyyy-MM-dd");
            //txtEtokenPWDSC.Text = dsLoadReturnInfo.Tables[0].Rows[0][17].ToString();
            //txtDSCValidUptoDSC.Text = Convert.ToDateTime(dsLoadReturnInfo.Tables[0].Rows[0][18].ToString()).ToString("yyyy-MM-dd");
        }
        if (RoleID == 1)
        {
            txtCustomerCodeDSC.Enabled = true;
            txtFileNumberDSC.Enabled = true;
            txtApplicantNameDSC.Enabled = true;
            txtEstablishmentNameDSC.Enabled = true;
            txtDOBDSC.Enabled = true;
            txtMobileDSC.Enabled = true;
            txtEmailDSC.Enabled = true;
            txtAddressDSC.Enabled = true;
            ddlDistrictDSC.Enabled = true;
            txtPINDSC.Enabled = true;
            txtShareCodeDSC.Enabled = true;
            txtChallengeCodeDSC.Enabled = true;
            txtDesiredUserNameDSC.Enabled = true;
            txtDesiredPasswordDSC.Enabled = true;
            txtApplicationNumberDSC.Enabled = true;
            txtEtokenPWDSC.Enabled = true;
            txtDSCValidUptoDSC.Enabled = true;

        }
        else
        {
            txtCustomerCodeDSC.Enabled = false;
            txtFileNumberDSC.Enabled = false;
            txtApplicantNameDSC.Enabled = false;
            txtEstablishmentNameDSC.Enabled = false;
            txtDOBDSC.Enabled = false;
            txtMobileDSC.Enabled = false;
            txtEmailDSC.Enabled = false;
            txtAddressDSC.Enabled = false;
            ddlDistrictDSC.Enabled = false;
            txtPINDSC.Enabled = false;
            txtShareCodeDSC.Enabled = false;
            txtChallengeCodeDSC.Enabled = false;
            txtDesiredUserNameDSC.Enabled = false;
            txtDesiredPasswordDSC.Enabled = false;
            txtApplicationNumberDSC.Enabled = false;
            txtEtokenPWDSC.Enabled = false;
            txtDSCValidUptoDSC.Enabled = false;
        }
        #endregion
    }
    protected void btnUpdateRubber_Click(object sender, EventArgs e)
    {
        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();

        serviceDetails.customerid = txtCustomerCodeRBR.Text;
        serviceDetails.filenumber = txtFileNumberRBR.Text;
        serviceDetails.dealershipnumber = txtDealershipNoRBR.Text;
        serviceDetails.licencevalidtill = Convert.ToDateTime(txtLicenceValidTillRBR.Text);
        serviceDetails.concernname = txtConcernNameRBR.Text;
        serviceDetails.ownershipname = txtOwnerNameRBR.Text;
        serviceDetails.mobile = txtMobielRBR.Text;
        serviceDetails.email = txtEmailRBR.Text;
        serviceDetails.businessplace = txtBusinessPlaceRB_BSP.Text;
        serviceDetails.buisnessbuildingtype = txtBuildingTypeRB_BSP.Text;
        serviceDetails.businessbuildingplotno = txtBuildingPlotNoRB_BSP.Text;
        serviceDetails.storagecity = txtCityRB_BSP.Text;
        serviceDetails.storagedistrict = int.Parse(ddlDistrictRB_BSP.SelectedValue.ToString());
        serviceDetails.storagestate = int.Parse(ddlStateRB_BSP.SelectedValue.ToString());
        serviceDetails.storagepin = txtPINRB_BSP.Text;
        serviceDetails.storagemobile = txtMobileRB_BSP.Text;
        serviceDetails.storageemail = txtEmailRB_BSP.Text;
        serviceDetails.presemtpermanentaddress = txtPresentPermanentAddressRB_PPA.Text;
        serviceDetails.ppacity = txtCityRB_PPA.Text;
        serviceDetails.ppadistrict = int.Parse(ddlDistrictRB_Address_PPA.SelectedValue.ToString());
        serviceDetails.ppastate = int.Parse(ddlStateRB_PPA.SelectedValue.ToString());
        serviceDetails.ppapin = txtPINRB_PPA.Text;
        serviceDetails.username = txtUsernameRBR_PPA.Text;
        serviceDetails.password = txtPasswordRBR_PPA.Text;
        serviceDetails.ammendment = txtAmmendmentMadeOnRBR_PPA.Text;
        serviceDetails.applicationnumber = txtApplicationNumberRBR_PPA.Text;
        serviceDetails.financialyear = ddlFinancialYearRBR_PPA.SelectedValue;
        serviceDetails.returnH2 = ddlReturnH2RBR_PPA.SelectedValue;
        serviceDetails.returnL = ddlReturnLRBR_PPA.SelectedValue;
        serviceDetails.enteredby = Session["User"].ToString();
        serviceDetails.dateofinsert = DateTime.Now;


        utility = new Utility();
        utility.UpdateRubberServiceDetails(serviceDetails);

        divSuccess.Visible = true;
        lblSuccess.InnerText = "Return Information Updated Successfully.";
        divError.Visible = false;
        lblError.Visible = false;

        //clear all the input controls
        ResetInputs(1);

    }
    protected void btnUpdateDSCInfo_Click(object sender, EventArgs e)
    {
        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();
        serviceDetails.customerid = txtCustomerCodeDSC.Text;
        serviceDetails.filenumber = txtFileNumberDSC.Text;
        serviceDetails.applicantname = txtApplicantNameDSC.Text;
        serviceDetails.establishmentname = txtEstablishmentNameDSC.Text;
        serviceDetails.dob = Convert.ToDateTime(txtDOBDSC.Text);
        serviceDetails.mobile = txtMobileDSC.Text;
        serviceDetails.email = txtEmailDSC.Text;
        serviceDetails.address = txtAddressDSC.Text;
        serviceDetails.district = int.Parse(ddlDistrictDSC.SelectedValue.ToString());
        serviceDetails.pin = txtPINDSC.Text;
        serviceDetails.sharecode = txtShareCodeDSC.Text;
        serviceDetails.chalangecode = txtChallengeCodeDSC.Text;
        serviceDetails.username = txtDesiredUserNameDSC.Text;
        serviceDetails.password = txtDesiredPasswordDSC.Text;
        serviceDetails.applicationnumber = txtApplicationNumberDSC.Text;
        serviceDetails.etokenpassword = txtEtokenPWDSC.Text;
        serviceDetails.dscvalidupto = Convert.ToDateTime(txtDSCValidUptoDSC.Text);
        serviceDetails.enteredby = Session["User"].ToString();
        serviceDetails.dateofinsert = DateTime.Now;

        utility = new Utility();
        utility.UpdateDSCServiceDetails(serviceDetails);

        divSuccess.Visible = true;
        lblSuccess.InnerText = "Return Information Updated Successfully.";
        divError.Visible = false;
        lblError.Visible = false;

        //clear all the input controls
        ResetInputs(6); 
    }
}

