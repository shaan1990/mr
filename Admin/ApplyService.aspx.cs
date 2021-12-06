using MerchantMirrour;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ApplyService : System.Web.UI.Page
{

    DataBase database;
    private static string filenumber = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropDownListServices();
            LoadDistrictsIntoPTAX();
            LoadDistrictsIntoRubber();
            LoadDistrictsIntoDSC();
            LoadDirectorNumbers();

            if (Session != null)
            {
                if (Session["Role"].ToString() == "1" || Session["Role"].ToString() == "3")      // admin  & employee    
                    btnEditForm.Visible = true;
                else
                    btnEditForm.Visible = false;
            }
            else
            {
                Response.Redirect("../LoginPage.aspx");
            }


        }
    }
    public void FillDropDownListServices()
    {
        Utility utility = new Utility();
        ddlServices.DataSource = utility.GetAllServices();
        ddlServices.DataValueField = "serviceid";
        ddlServices.DataTextField = "servicename";
        ddlServices.DataBind();
        ddlServices.Items.Insert(0, new ListItem("-- Select Service --", "0"));
    }

    protected void lnkOpendivCustomerID_Click(object sender, EventArgs e)
    {
        divCustomerID.Visible = true;
        divRegistration.Visible = false;
    }

    protected void btnRegistration_Click(object sender, EventArgs e)
    {
        try
        {
            Utility utility = new Utility();
            Utility.GeneralInformation generatlInformation = new Utility.GeneralInformation();
            generatlInformation.customername = txtClientName.Text;
            generatlInformation.pannumber = txtPAN.Text;
            generatlInformation.adhaar = txtAdhaar.Text;
            generatlInformation.contact = txtContact.Text;
            generatlInformation.filenumber = "NA";
            generatlInformation.email = txtEmail.Text;
            generatlInformation.customercode = utility.CreateCustomerNumber(txtAdhaar.Text, txtContact.Text, txtVoterID.Text);


            Utility.CustomerCredentials customerCredentials = new Utility.CustomerCredentials();
            customerCredentials.CustomerID = generatlInformation.customercode;
            customerCredentials.CustomerPassword = txtPassword.Text;


            utility.InsertGeneralInfoAndCredentials(generatlInformation, customerCredentials);

            divSuccess.Visible = true;
            lblSuccess.InnerText = "New Registration has done Successfully, with Customer ID : " + generatlInformation.customercode + " Kindly note this down for your further references.";
            divError.Visible = false;
            lblError.Visible = false;
        }
        catch (Exception ex)
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = ex.Message.ToString();
            divSuccess.Visible = false;
        }

    }

    protected void lnkOpendivRegistration_Click(object sender, EventArgs e)
    {
        divRegistration.Visible = true;
        divCustomerID.Visible = false;
    }

    protected void btnOpenForm_Click(object sender, EventArgs e)
    {
        if (ddlServices.SelectedIndex != 0 && !string.IsNullOrEmpty(txtCustomerID.Text))
        {
            if (ddlServices.SelectedValue.ToString() == "1") // RUBBER
            {
                divRegFormRubber.Visible = true;

                // visible : false
                divRegFormITAX.Visible = false;
                divRegFormPTAX.Visible = false;
                divRegFormDSC.Visible = false;
                divRegFormGST.Visible = false;
                divRegFormAccounts.Visible = false;

                btnRegistrationRubber.Visible = true;

                ResetInputs(1);

            }
            else if (ddlServices.SelectedValue.ToString() == "2") // GOODS & SERVICE TAX
            {

                divRegFormGST.Visible = true;

                // visible : false
                divRegFormPTAX.Visible = false;
                divRegFormRubber.Visible = false;
                divRegFormDSC.Visible = false;
                divRegFormITAX.Visible = false;

                btnRegistrationGST.Visible = true;
                btnUpdateGST.Visible = false;


                ResetInputs(2);
            }
            else if (ddlServices.SelectedValue.ToString() == "3") // INCOME TAX
            {
                divRegFormITAX.Visible = true;

                // visible : false
                divRegFormPTAX.Visible = false;
                divRegFormRubber.Visible = false;
                divRegFormDSC.Visible = false;
                divRegFormGST.Visible = false;

                btnRegistrationITAX.Visible = true;

                ResetInputs(3);
            }
            else if (ddlServices.SelectedValue.ToString() == "4")
            {

                divRegFormAccounts.Visible = true;

                // visible : false
                divRegFormPTAX.Visible = false;
                divRegFormRubber.Visible = false;
                divRegFormDSC.Visible = false;
                divRegFormGST.Visible = false;
                divRegFormITAX.Visible = false;

                btnRegistrationITAX.Visible = true;

                ResetInputs(4);
            }
            else if (ddlServices.SelectedValue.ToString() == "5")// PROFESSIONAL TAX
            {
                divRegFormPTAX.Visible = true;


                // visible : false
                divRegFormITAX.Visible = false;
                divRegFormRubber.Visible = false;
                divRegFormDSC.Visible = false;
                divRegFormGST.Visible = false;
                divRegFormAccounts.Visible = false;

                btnRegistrationPTAX.Visible = true;

                btnUpdateRubber.Visible = false;

                ResetInputs(5);
            }
            else if (ddlServices.SelectedValue.ToString() == "6")
            {
                divRegFormDSC.Visible = true;

                // visible : false
                divRegFormITAX.Visible = false;
                divRegFormPTAX.Visible = false;
                divRegFormRubber.Visible = false;
                divRegFormGST.Visible = false;
                divRegFormAccounts.Visible = false;

                btnRegistrationDSC.Visible = true;

                ResetInputs(6);
            }
            else if (ddlServices.SelectedValue.ToString() == "7")
            {

                ResetInputs(7);
            }

            divError.Visible = false;
        }
        else
        {
            divSuccess.Visible = false;
            lblSuccess.Visible = false;
            divError.Visible = true;
            lblError.InnerText = "Customer ID and Service must be selected.";
        }
    }

    protected void btnRegistrationITAX_Click(object sender, EventArgs e)
    {
        if (!chkAgreeITAX.Checked)
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "You must accept the concent before you submit the application.";
            divSuccess.Visible = false;

            return;
        }

        if (Session["User"] != null)
        {
            try
            {
                Utility utility = new Utility();
                Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();

                serviceDetails.customerid = txtCustomerID.Text;
                serviceDetails.filenumber = utility.CreateFileNumber(int.Parse(ddlServices.SelectedValue.ToString()), txtPANITAX.Text);
                serviceDetails.applyingas = int.Parse(ddlApplyingAsITAX.SelectedValue.ToString());
                serviceDetails.pan = txtPANITAX.Text;
                serviceDetails.applicantname = txtApplicantNameITAX.Text;
                serviceDetails.dob = string.IsNullOrEmpty(txtDOBITAX.Text) ? DateTime.MaxValue : Convert.ToDateTime(txtDOBITAX.Text);
                serviceDetails.residentialstatus = int.Parse(ddlResidentialStatsITAX.SelectedValue.ToString());
                serviceDetails.mobile = txtMobileITAX.Text;
                serviceDetails.email = txtEmailITAX.Text;
                serviceDetails.address = txtRoadStreetITAX.Text;
                serviceDetails.arealocality = txtAreaLocalityITAX.Text;
                serviceDetails.postoffice = txtPostOfficeITAX.Text;
                serviceDetails.state = int.Parse(ddlStateITAX.SelectedValue.ToString()); ;
                serviceDetails.country = int.Parse(ddlCountryITAX.SelectedValue.ToString());
                serviceDetails.pin = txtPINITAX.Text;
                serviceDetails.enteredby = Session["User"].ToString();
                serviceDetails.dateofinsert = DateTime.Now;
                serviceDetails.serviceid = int.Parse(ddlServices.SelectedValue.ToString());
                serviceDetails.applicantname = txtApplicationNumberITAX.Text;
                serviceDetails.acknowledgeupdateon = string.IsNullOrEmpty(txtDateOfAckITAX.Text) ? DateTime.MaxValue : Convert.ToDateTime(txtDateOfAckITAX.Text);


                database = new DataBase();
                utility.InsertRegistrationIncomeTax(serviceDetails);

                divSuccess.Visible = true;
                lblSuccess.InnerText = "Form Details Submitted Successfully.";
                divError.Visible = false;
                lblError.Visible = false;

                //clear all the input controls
                ResetInputs(int.Parse(ddlServices.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                lblError.Visible = true;
                lblError.InnerText = ex.Message.ToString();
                divSuccess.Visible = false;

            }
        }
        else
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "Session is expired.";
            divSuccess.Visible = false;
        }
    }

    private void ResetInputs(int serviceid)
    {
        if (ddlServices.SelectedValue.ToString() == "1") // RUBBER
        {
            ddlLicenceRB.Enabled = true;
            txtApplicantNameRB.Enabled = true;
            txtTraderNameRB.Enabled = true;
            txtFathersNameRB.Enabled = true;
            txtDOBRB.Enabled = true;

            // business

            txtBusinessPlaceRB.Enabled = true;
            txtBuildingTypeRB.Enabled = true;
            txtBuildingPlotNoRB.Enabled = true;
            txtCityRB.Enabled = true;
            ddlDistrictRB.Enabled = true;


            ddlStateRB.Enabled = true;
            txtPINRB.Enabled = true;
            txtMobileRB.Enabled = true;
            txtEmailRB.Enabled = true;

            // storage

            txtStoragePlaceRB.Enabled = true;
            txtBuildingTypeRB2.Enabled = true;
            txtBuildingPlotNoRB2.Enabled = true;
            txtCityRB2.Enabled = true;
            ddlDistrictRB_Storage.Enabled = true;


            ddlStateRB2.Enabled = true;
            txtPINRB2.Enabled = true;
            txtMobileRB2.Enabled = true;
            txtEmailRB2.Enabled = true;


            txtOwnerShipTypeRB.Enabled = true;
            txtOwnerShipNameRB.Enabled = true;

            // ppa

            txtPresentPermanentAddressRB.Enabled = true;
            txtCityRB3.Enabled = true;
            ddlDistrictRB_Address.Enabled = true;
            ddlStateRB3.Enabled = true;
            txtPINRB3.Enabled = true;
            txtMobileRB3.Enabled = true;
            txtEmailRB3.Enabled = true;
            txtPANRB3.Enabled = true;
            txtInvestedCapitalRB3.Enabled = true;

            //####################################################

            ddlLicenceRB.SelectedIndex = 0;
            txtApplicantNameRB.Text = string.Empty;
            txtTraderNameRB.Text = string.Empty;
            txtFathersNameRB.Text = string.Empty;
            txtDOBRB.Text = string.Empty;

            // business

            txtBusinessPlaceRB.Text = string.Empty;
            txtBuildingTypeRB.Text = string.Empty;
            txtBuildingPlotNoRB.Text = string.Empty;
            txtCityRB.Text = string.Empty;
            ddlDistrictRB.SelectedIndex = 0;


            ddlStateRB.SelectedIndex = 0;
            txtPINRB.Text = string.Empty;
            txtMobileRB.Text = string.Empty;
            txtEmailRB.Text = string.Empty;

            // storage

            txtStoragePlaceRB.Text = string.Empty;
            txtBuildingTypeRB2.Text = string.Empty;
            txtBuildingPlotNoRB2.Text = string.Empty;
            txtCityRB2.Text = string.Empty;
            ddlDistrictRB_Storage.SelectedIndex = 0;


            ddlStateRB2.SelectedIndex = 0;
            txtPINRB2.Text = string.Empty;
            txtMobileRB2.Text = string.Empty;
            txtEmailRB2.Text = string.Empty;


            txtOwnerShipTypeRB.Text = string.Empty;
            txtOwnerShipNameRB.Text = string.Empty;

            // ppa

            txtPresentPermanentAddressRB.Text = string.Empty;
            txtCityRB3.Text = string.Empty;
            ddlDistrictRB_Address.SelectedIndex = 0;
            ddlStateRB3.SelectedIndex = 0;
            txtPINRB3.Text = string.Empty;
            txtMobileRB3.Text = string.Empty;
            txtEmailRB3.Text = string.Empty;
            txtPANRB3.Text = string.Empty;
            txtInvestedCapitalRB3.Text = string.Empty;

        }
        else if (ddlServices.SelectedValue.ToString() == "2")
        {
            txtLegalBusinessNameGST.Text = string.Empty;
            txtAdhaarGST.Text = string.Empty;
            txtPanGST.Text = string.Empty;
            txtTradeNameGST.Text = string.Empty;
            ddlConstituitionOfBusinessGST.SelectedIndex = 0;
            ddlCasualTaxablePersonGST.SelectedIndex = 0;
            ddlOptionsForCommissionGST.SelectedIndex = 0;
            ddlReasonToObtainRegistrationGST.SelectedIndex = 0;
            txtDateOfCommencementGST.Text = string.Empty;
            txtDateOnLiabbilityGST.Text = string.Empty;
            txtNameofPersonGST.Text = string.Empty;
            txtFatherNameGST.Text = string.Empty;
            txtDOBGST.Text = string.Empty;
            ddlGenderGST.SelectedIndex = 0;
            txtMobileGST.Text = string.Empty;
            txtEmailGST.Text = string.Empty;
            txtAuthorisedSignatoryGST.Text = string.Empty;
            ddlDesignationGST.SelectedIndex = 0;
            txtResidentialAddressWithPinGST.Text = string.Empty;
            ddlNoOfPartnersGST.SelectedIndex = 0;
            ddlConcernDealsWithGST.SelectedIndex = 0;
            ddlAuthorisedSignatoryGST.SelectedIndex = 0;
            ddlAdditionalRepresentativeGST.SelectedIndex = 0;
            txtPrincipalPlaceGST.Text = string.Empty;
            ddlStateGST.SelectedIndex = 0;
            txtSecCirWardChargeGST.Text = string.Empty;
            txtCommisionerateGST.Text = string.Empty;
            ddlDivisionGST.SelectedIndex = 0;
            ddlRangeGST.SelectedIndex = 0;
            ddlNatureOfPossesionGST.SelectedIndex = 0;
            txtProofOfPrincipalPlaceGST.Text = string.Empty;
            ddlNatureofBusinessGST.SelectedIndex = 0;
            txtAdditionalBusinessPlaceGST.Text = string.Empty;
            txtDetailsOfGdComdtGST.Text = string.Empty;
            txtPTaxRegCertfGST.Text = string.Empty;
            txtPTaxEmpCodeGST.Text = string.Empty;
        }
        else if (ddlServices.SelectedValue.ToString() == "3") // INCOME TAX
        {
            ddlApplyingAsITAX.Enabled = true;
            txtPANITAX.Enabled = true;
            txtApplicantNameITAX.Enabled = true;
            txtDOBITAX.Enabled = true;
            ddlResidentialStatsITAX.Enabled = true;
            txtMobileITAX.Enabled = true;
            txtEmailITAX.Enabled = true;
            txtRoadStreetITAX.Enabled = true;
            txtAreaLocalityITAX.Enabled = true;
            txtPostOfficeITAX.Enabled = true;
            ddlStateITAX.Enabled = true;
            ddlCountryITAX.Enabled = true;
            txtPINITAX.Enabled = true;

            ddlApplyingAsITAX.SelectedIndex = 0;
            txtPAN.Text = string.Empty;
            txtApplicantNameITAX.Text = string.Empty;
            txtDOBITAX.Text = string.Empty;
            ddlResidentialStatsITAX.SelectedIndex = 0;
            txtMobileITAX.Text = string.Empty;
            txtEmailITAX.Text = string.Empty;
            txtRoadStreetITAX.Text = string.Empty;
            txtAreaLocalityITAX.Text = string.Empty;
            txtPostOfficeITAX.Text = string.Empty;
            ddlStateITAX.SelectedIndex = 0;
            ddlCountryITAX.SelectedIndex = 0;
            txtPINITAX.Text = string.Empty;
        }
        else if (ddlServices.SelectedValue.ToString() == "4")
        {

        }
        else if (ddlServices.SelectedValue.ToString() == "5")// PROFESSIONAL TAX
        {
            ddlApplyingAsPTAX.Enabled = true;
            txtApplicantNamePTAX.Enabled = true;
            txtFatherNamePTAX.Enabled = true;
            txtPANPTAX.Enabled = true;
            ddlGenderPTAX.Enabled = true;
            txtMobilePTAX.Enabled = true;
            txtEmailPTAX.Enabled = true;


            txtEstablishmentNamePTAX.Enabled = true;
            ddlDistrictPTAX.Enabled = true;
            txtPinCodePTAX.Enabled = true;
            txtEstablishmentAddressPTAX.Enabled = true;
            ddlProfessionCategoryPTAX.Enabled = true;
            ddlProfessionSubCategoryPTAX.Enabled = true;
            rbEngageWithPTAX.Enabled = true;


            txtDateofCommencementPTAX.Enabled = true;
            txtPANTANPTAX.Enabled = true;
            txtAnnualGrossBusinessPTAX.Enabled = true;
            txtAnnualTurnOverSalesPurchasePTAX.Enabled = true;
            txtMonthlyAvgWorkersPTAX.Enabled = true;
            txtMonthlyAvgEmployeesPTAX.Enabled = true;


            txtGSTPTAX.Enabled = true;
            txtCSTPTAX.Enabled = true;
            txtVATPTAX.Enabled = true;
            rbVehiclesPTAX.Enabled = true;
            rbLevelOfSocietyPTAX.Enabled = true;

            //###########################################

            ddlApplyingAsPTAX.SelectedIndex = 0;
            txtApplicantNamePTAX.Text = string.Empty;
            txtFatherNamePTAX.Text = string.Empty;
            txtPANPTAX.Text = string.Empty;
            ddlGenderPTAX.SelectedIndex = 0;
            txtMobilePTAX.Text = string.Empty;
            txtEmailPTAX.Text = string.Empty;


            txtEstablishmentNamePTAX.Text = string.Empty;
            ddlDistrictPTAX.SelectedIndex = 0;
            txtPinCodePTAX.Text = string.Empty;
            txtEstablishmentAddressPTAX.Text = string.Empty;
            ddlProfessionCategoryPTAX.SelectedIndex = 0;
            ddlProfessionSubCategoryPTAX.SelectedIndex = 0;
            rbEngageWithPTAX.ClearSelection();


            txtDateofCommencementPTAX.Text = string.Empty;
            txtPANTANPTAX.Text = string.Empty;
            txtAnnualGrossBusinessPTAX.Text = string.Empty;
            txtAnnualTurnOverSalesPurchasePTAX.Text = string.Empty;
            txtMonthlyAvgWorkersPTAX.Text = string.Empty;
            txtMonthlyAvgEmployeesPTAX.Text = string.Empty;


            txtGSTPTAX.Text = string.Empty;
            txtCSTPTAX.Text = string.Empty;
            txtVATPTAX.Text = string.Empty;
            rbVehiclesPTAX.ClearSelection();
            rbLevelOfSocietyPTAX.ClearSelection();
        }
        else if (ddlServices.SelectedValue.ToString() == "6")
        {
            txtApplicantNameDSC.Enabled = true;
            txtEstablishmentNameDSC.Enabled = true;
            txtPANDSC.Enabled = true;
            txtAdhaarDSC.Enabled = true;
            txtMobileDSC.Enabled = true;
            txtDOBDSC.Enabled = true;
            txtEmailDSC.Enabled = true;
            ddlAdharLinkedDSC.Enabled = true;
            txtLinkedMobileWithAdhaarDSC.Enabled = true;
            txtAddressDSC.Enabled = true;
            ddlDistrictsDSC.Enabled = true;
            txtPINDSC.Enabled = true;
            txtApplicationNumberDSC.Enabled = true;

            //#######################################

            txtApplicantNameDSC.Text = string.Empty;
            txtEstablishmentNameDSC.Text = string.Empty;
            txtPANDSC.Text = string.Empty;
            txtAdhaarDSC.Text = string.Empty;
            txtMobileDSC.Text = string.Empty;
            txtDOBDSC.Text = string.Empty;
            txtEmailDSC.Text = string.Empty;
            ddlAdharLinkedDSC.SelectedIndex = 0;
            txtLinkedMobileWithAdhaarDSC.Text = string.Empty;
            txtAddressDSC.Text = string.Empty;
            ddlDistrictsDSC.SelectedIndex = 0;
            txtPINDSC.Text = string.Empty;
            txtApplicationNumberDSC.Text = string.Empty;
        }
        else if (ddlServices.SelectedValue.ToString() == "7")
        {

        }
        else if (ddlServices.SelectedValue.ToString() == "4")
        {
            txtPanACN.Text = string.Empty;
        }

    }

    protected void btnRegistrationPTAX_Click(object sender, EventArgs e)
    {

        if (!chkAgreePtax.Checked)
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "You must accept the concent before you submit the application.";
            divSuccess.Visible = false;

            return;
        }

        if (Session["User"] != null)
        {
            try
            {
                Utility utility = new Utility();
                Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();


                serviceDetails.filenumber = utility.CreateFileNumber(int.Parse(ddlServices.SelectedValue.ToString()), txtPANPTAX.Text);
                serviceDetails.customerid = txtCustomerID.Text;
                serviceDetails.applyingas = int.Parse(ddlApplyingAsPTAX.SelectedValue.ToString());
                serviceDetails.applicantname = txtApplicantNamePTAX.Text;
                serviceDetails.fathername = txtFatherNamePTAX.Text;
                serviceDetails.pan = txtPANPTAX.Text;
                serviceDetails.gender = int.Parse(ddlGenderPTAX.SelectedValue.ToString());
                serviceDetails.mobile = txtMobilePTAX.Text;
                serviceDetails.email = txtEmailPTAX.Text;
                serviceDetails.establishmentname = txtEstablishmentNamePTAX.Text;
                serviceDetails.establishmentaddress = txtEstablishmentAddressPTAX.Text;
                serviceDetails.district = int.Parse(ddlDistrictPTAX.SelectedValue.ToString());
                serviceDetails.pin = txtPinCodePTAX.Text;
                serviceDetails.category = int.Parse(ddlProfessionCategoryPTAX.SelectedValue.ToString());
                serviceDetails.subcategory = int.Parse(ddlProfessionSubCategoryPTAX.SelectedValue.ToString());
                serviceDetails.engagedwith = string.IsNullOrEmpty(rbEngageWithPTAX.SelectedValue) ? 0 : int.Parse(rbEngageWithPTAX.SelectedValue.ToString());
                serviceDetails.dateofcommencement = string.IsNullOrEmpty(txtDateofCommencementPTAX.Text) ? DateTime.MaxValue : Convert.ToDateTime(txtDateofCommencementPTAX.Text);
                serviceDetails.tan = txtPANTANPTAX.Text;
                serviceDetails.annualgrossbusiness = decimal.Parse(txtAnnualGrossBusinessPTAX.Text);
                serviceDetails.annualturnover = decimal.Parse(txtAnnualTurnOverSalesPurchasePTAX.Text);
                serviceDetails.monthlyaverageworker = int.Parse(txtMonthlyAvgWorkersPTAX.Text);
                serviceDetails.monthlyaverageemployee = int.Parse(txtMonthlyAvgEmployeesPTAX.Text);
                serviceDetails.gst = txtGSTPTAX.Text;
                serviceDetails.cst = txtCSTPTAX.Text;
                serviceDetails.vat = txtVATPTAX.Text;
                serviceDetails.vehiclecategory = string.IsNullOrEmpty(rbVehiclesPTAX.SelectedValue) ? 0 : int.Parse(rbVehiclesPTAX.SelectedValue);
                serviceDetails.levelofsociety = string.IsNullOrEmpty(rbLevelOfSocietyPTAX.SelectedValue) ? 0 : int.Parse(rbLevelOfSocietyPTAX.SelectedValue);
                serviceDetails.enteredby = Session["User"].ToString();
                serviceDetails.dateofinsert = DateTime.Now;
                serviceDetails.serviceid = int.Parse(ddlServices.SelectedValue.ToString());
                serviceDetails.acknowledgeupdateon = string.IsNullOrEmpty(txtDateOfAckPTAX.Text) ? DateTime.MaxValue : Convert.ToDateTime(txtDateOfAckPTAX.Text);
                serviceDetails.applicationnumber = txtApplicationNumberPTAX.Text;

                database = new DataBase();
                utility.InsertRegistrationProfessionalTax(serviceDetails);


                divSuccess.Visible = true;
                lblSuccess.InnerText = "Form Details Submitted Successfully.";
                divError.Visible = false;
                lblError.Visible = false;

                //clear all the input controls
                ResetInputs(int.Parse(ddlServices.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                lblError.Visible = true;
                lblError.InnerText = ex.Message.ToString();
                divSuccess.Visible = false;
            }

        }
        else
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "Session is expired.";
            divSuccess.Visible = false;
        }
    }

    public void LoadDistrictsIntoDSC()
    {
        CommonInformation info = new CommonInformation();
        ddlDistrictsDSC.DataSource = info.LoadAllDistricts();
        ddlDistrictsDSC.DataTextField = "name";
        ddlDistrictsDSC.DataValueField = "id";
        ddlDistrictsDSC.DataBind();
        ddlDistrictsDSC.Items.Insert(0, new ListItem("-- Select District --", "0"));
    }

    public void LoadDistrictsIntoPTAX()
    {
        CommonInformation info = new CommonInformation();
        ddlDistrictPTAX.DataSource = info.LoadAllDistricts();
        ddlDistrictPTAX.DataTextField = "name";
        ddlDistrictPTAX.DataValueField = "id";
        ddlDistrictPTAX.DataBind();
        ddlDistrictPTAX.Items.Insert(0, new ListItem("-- Select District --", "0"));
    }

    public void LoadDistrictsIntoRubber()
    {
        CommonInformation info = new CommonInformation();
        ddlDistrictRB.DataSource = info.LoadAllDistricts();
        ddlDistrictRB.DataTextField = "name";
        ddlDistrictRB.DataValueField = "id";
        ddlDistrictRB.DataBind();
        ddlDistrictRB.Items.Insert(0, new ListItem("-- Select District --", "0"));

        ddlDistrictRB_Storage.DataSource = info.LoadAllDistricts();
        ddlDistrictRB_Storage.DataTextField = "name";
        ddlDistrictRB_Storage.DataValueField = "id";
        ddlDistrictRB_Storage.DataBind();
        ddlDistrictRB_Storage.Items.Insert(0, new ListItem("-- Select District --", "0"));

        ddlDistrictRB_Address.DataSource = info.LoadAllDistricts();
        ddlDistrictRB_Address.DataTextField = "name";
        ddlDistrictRB_Address.DataValueField = "id";
        ddlDistrictRB_Address.DataBind();
        ddlDistrictRB_Address.Items.Insert(0, new ListItem("-- Select District --", "0"));
    }

    protected void btnRegistrationRubber_Click(object sender, EventArgs e)
    {

        if (!chkAgreeRubber.Checked)
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "You must accept the concent before you submit the application.";
            divSuccess.Visible = false;

            return;
        }

        if (Session["User"] != null)
        {
            try
            {
                Utility utility = new Utility();
                Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();

                serviceDetails.filenumber = utility.CreateFileNumber(int.Parse(ddlServices.SelectedValue.ToString()), txtPANRB3.Text);
                serviceDetails.customerid = txtCustomerID.Text;
                serviceDetails.applydealerlicence = int.Parse(ddlLicenceRB.SelectedValue.ToString());
                serviceDetails.applicantname = txtApplicantNameRB.Text;
                serviceDetails.tradername = txtTraderNameRB.Text;
                serviceDetails.fathername = txtFathersNameRB.Text;
                serviceDetails.dob = Convert.ToDateTime(txtDOBRB.Text);
                serviceDetails.businessplace = txtBusinessPlaceRB.Text;
                serviceDetails.buisnessbuildingtype = txtBuildingTypeRB.Text;
                serviceDetails.businessbuildingplotno = txtBuildingPlotNoRB.Text;
                serviceDetails.businesscity = txtCityRB.Text;
                serviceDetails.district = int.Parse(ddlDistrictRB.SelectedValue.ToString());
                serviceDetails.state = int.Parse(ddlStateRB.SelectedValue.ToString());
                serviceDetails.pin = txtPINRB.Text;
                serviceDetails.mobile = txtMobileRB.Text;
                serviceDetails.email = txtEmailRB.Text;
                serviceDetails.storageplace = txtStoragePlaceRB.Text;
                serviceDetails.storagebuildingtype = txtBuildingTypeRB2.Text;
                serviceDetails.storagebuildingplotno = txtBuildingPlotNoRB2.Text;
                serviceDetails.storagecity = txtCityRB2.Text;
                serviceDetails.storagedistrict = int.Parse(ddlDistrictRB_Storage.SelectedValue.ToString());
                serviceDetails.storagestate = int.Parse(ddlStateRB2.SelectedValue.ToString());
                serviceDetails.storagepin = txtPINRB2.Text;
                serviceDetails.storagemobile = txtMobileRB2.Text;
                serviceDetails.storageemail = txtEmailRB2.Text;
                serviceDetails.ownershiptype = txtOwnerShipTypeRB.Text;
                serviceDetails.ownershipname = txtOwnerShipNameRB.Text;
                serviceDetails.presemtpermanentaddress = txtPresentPermanentAddressRB.Text;
                serviceDetails.ppacity = txtCityRB3.Text;
                serviceDetails.ppadistrict = int.Parse(ddlDistrictRB_Address.SelectedValue.ToString());
                serviceDetails.ppastate = int.Parse(ddlStateRB3.SelectedValue.ToString());
                serviceDetails.ppapin = txtPINRB3.Text;
                serviceDetails.ppamobile = txtMobileRB3.Text;
                serviceDetails.ppaemail = txtEmailRB3.Text;
                serviceDetails.ppapan = txtPANRB3.Text;
                serviceDetails.ppainvestedcapital = decimal.Parse(txtInvestedCapitalRB3.Text);
                serviceDetails.enteredby = Session["User"].ToString();
                serviceDetails.dateofinsert = DateTime.Now;
                serviceDetails.serviceid = int.Parse(ddlServices.SelectedValue.ToString());
                serviceDetails.acknowledgeupdateon = string.IsNullOrEmpty(txtDateOfAckRB.Text) ? DateTime.MaxValue : Convert.ToDateTime(txtDateOfAckRB.Text);
                serviceDetails.applicationnumber = txtApplicationNumberRB.Text;


                utility = new Utility();
                utility.InsertRegistrationRubber(serviceDetails);

                divSuccess.Visible = true;
                lblSuccess.InnerText = "Form Details Submitted Successfully.";
                divError.Visible = false;
                lblError.Visible = false;

                //clear all the input controls
                ResetInputs(int.Parse(ddlServices.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                lblError.Visible = true;
                lblError.InnerText = ex.Message.ToString();
                divSuccess.Visible = false;
            }
        }
        else
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "Session is expired.";
            divSuccess.Visible = false;
        }


    }

    protected void btnUpdateITAX_Click(object sender, EventArgs e)
    {
        Utility utility = new Utility();
        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();
        serviceDetails.filenumber = filenumber;

        serviceDetails.customerid = txtCustomerID.Text;
        serviceDetails.serviceid = int.Parse(ddlServices.SelectedValue.ToString());
        //if (serviceDetails.serviceid == 1) // Rubber
        //    serviceDetails.applicationnumber = txtApplicationNumberRB.Text;
        //else if (serviceDetails.serviceid == 2) // Foods & Service Tax
        //    serviceDetails.applicationnumber = "";
        //else if (serviceDetails.serviceid == 3) // Income Tax Return
        //    serviceDetails.applicationnumber = txtApplicationNumberITAX.Text;
        //else if (serviceDetails.serviceid == 4) // Accounting Services
        //    serviceDetails.applicationnumber = "";
        //else if (serviceDetails.serviceid == 5) //Professional Tax
        //    serviceDetails.applicationnumber = txtApplicationNumberPTAX.Text;
        //else if (serviceDetails.serviceid == 6) //Digital Signature Service
        //    serviceDetails.applicationnumber = "";
        //else if (serviceDetails.serviceid == 7) //Employees Provident Fund
        //    serviceDetails.applicationnumber = "";
        serviceDetails.applicationnumber = txtApplicationNumberITAX.Text;
        serviceDetails.acknowledgeupdateon = Convert.ToDateTime(txtDateOfAckITAX.Text);
        utility.UpdateAcknowledgeNumber(serviceDetails);

        divSuccess.Visible = true;
        lblSuccess.InnerText = "Record Updated Successfully.";
        divError.Visible = false;
        lblError.Visible = false;
    }

    protected void btnUpdateRubber_Click(object sender, EventArgs e)
    {
        Utility utility = new Utility();
        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();
        serviceDetails.filenumber = filenumber;
        serviceDetails.customerid = txtCustomerID.Text;
        serviceDetails.serviceid = int.Parse(ddlServices.SelectedValue.ToString());
        serviceDetails.applicationnumber = txtApplicationNumberRB.Text;
        serviceDetails.acknowledgeupdateon = Convert.ToDateTime(txtDateOfAckRB.Text);
        utility.UpdateAcknowledgeNumber(serviceDetails);

        divSuccess.Visible = true;
        lblSuccess.InnerText = "Record Updated Successfully.";
        divError.Visible = false;
        lblError.Visible = false;
    }

    protected void btnUpdatePTAX_Click(object sender, EventArgs e)
    {
        Utility utility = new Utility();
        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();
        serviceDetails.filenumber = filenumber;
        serviceDetails.customerid = txtCustomerID.Text;
        serviceDetails.serviceid = int.Parse(ddlServices.SelectedValue.ToString());
        serviceDetails.applicationnumber = txtApplicantNamePTAX.Text;
        serviceDetails.acknowledgeupdateon = Convert.ToDateTime(txtDateOfAckPTAX.Text);
        utility.UpdateAcknowledgeNumber(serviceDetails);

        divSuccess.Visible = true;
        lblSuccess.InnerText = "Record Updated Successfully.";
        divError.Visible = false;
        lblError.Visible = false;
    }

    // SEARCH BUTTON 
    protected void btnEditForm_Click(object sender, EventArgs e)
    {
        Utility utility = new Utility();
        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();
        serviceDetails.customerid = txtCustomerID.Text;
        serviceDetails.serviceid = int.Parse(ddlServices.SelectedValue.ToString());
        DataSet dsSearchDetails = utility.GetFormDetails(serviceDetails);

        // INCOME TAX
        //======================================
        if (dsSearchDetails.Tables[0].Rows.Count > 0 && ddlServices.SelectedValue.ToString() == "3")
        {
            filenumber = dsSearchDetails.Tables[0].Rows[0][2].ToString();

            ddlApplyingAsITAX.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][3].ToString());
            txtPANITAX.Text = dsSearchDetails.Tables[0].Rows[0][4].ToString();
            txtApplicantNameITAX.Text = dsSearchDetails.Tables[0].Rows[0][5].ToString();
            txtDOBITAX.Text = Convert.ToDateTime(dsSearchDetails.Tables[0].Rows[0][6].ToString()).ToString("yyyy-MM-dd");
            ddlResidentialStatsITAX.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][7].ToString());
            txtMobileITAX.Text = dsSearchDetails.Tables[0].Rows[0][8].ToString();
            txtEmailITAX.Text = dsSearchDetails.Tables[0].Rows[0][9].ToString();
            txtRoadStreetITAX.Text = dsSearchDetails.Tables[0].Rows[0][10].ToString();
            txtAreaLocalityITAX.Text = dsSearchDetails.Tables[0].Rows[0][11].ToString();
            txtPostOfficeITAX.Text = dsSearchDetails.Tables[0].Rows[0][12].ToString();
            ddlStateITAX.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][13].ToString());
            ddlCountryITAX.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][14].ToString());
            txtPINITAX.Text = dsSearchDetails.Tables[0].Rows[0][15].ToString();


            divRegFormITAX.Visible = true;

            divRegFormPTAX.Visible = false;
            divRegFormRubber.Visible = false;
            divRegFormDSC.Visible = false;
            divRegFormAccounts.Visible = false;

            btnRegistrationITAX.Visible = false;

            btnUpdateITAX.Visible = true;
            btnUpdateRubber.Visible = false;
            btnUpdatePTAX.Visible = false;
            btnUpdateDSC.Visible = false;

            // disabled inputs if roleid is not 1 else enable
            if (Session["Role"].ToString() != "1")
            {
                ddlApplyingAsITAX.Enabled = false;
                txtPANITAX.Enabled = false;
                txtApplicantNameITAX.Enabled = false;
                txtDOBITAX.Enabled = false;
                ddlResidentialStatsITAX.Enabled = false;
                txtMobileITAX.Enabled = false;
                txtEmailITAX.Enabled = false;
                txtRoadStreetITAX.Enabled = false;
                txtAreaLocalityITAX.Enabled = false;
                txtPostOfficeITAX.Enabled = false;
                ddlStateITAX.Enabled = false;
                ddlCountryITAX.Enabled = false;
                txtPINITAX.Enabled = false;
            }

        }
        //PROFESSIONAL TAX
        //======================================
        else if (dsSearchDetails.Tables[0].Rows.Count > 0 && ddlServices.SelectedValue.ToString() == "5")
        {
            filenumber = dsSearchDetails.Tables[0].Rows[0][1].ToString();

            ddlApplyingAsPTAX.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][3].ToString());
            txtApplicantNamePTAX.Text = dsSearchDetails.Tables[0].Rows[0][4].ToString();
            txtFatherNamePTAX.Text = dsSearchDetails.Tables[0].Rows[0][5].ToString();
            txtPANPTAX.Text = dsSearchDetails.Tables[0].Rows[0][6].ToString();
            ddlGenderPTAX.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][7].ToString());
            txtMobilePTAX.Text = dsSearchDetails.Tables[0].Rows[0][8].ToString();
            txtEmailPTAX.Text = dsSearchDetails.Tables[0].Rows[0][9].ToString();

            txtEstablishmentNamePTAX.Text = dsSearchDetails.Tables[0].Rows[0][10].ToString();
            ddlDistrictPTAX.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][11].ToString());
            txtPinCodePTAX.Text = dsSearchDetails.Tables[0].Rows[0][12].ToString();
            txtEstablishmentAddressPTAX.Text = dsSearchDetails.Tables[0].Rows[0][13].ToString();
            ddlProfessionCategoryPTAX.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][14].ToString());
            ddlProfessionSubCategoryPTAX.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][15].ToString());
            rbEngageWithPTAX.SelectedValue = dsSearchDetails.Tables[0].Rows[0][16].ToString();

            txtDateofCommencementPTAX.Text = Convert.ToDateTime(dsSearchDetails.Tables[0].Rows[0][17].ToString()).ToString("yyyy-MM-dd");
            txtPANTANPTAX.Text = dsSearchDetails.Tables[0].Rows[0][18].ToString();
            txtAnnualGrossBusinessPTAX.Text = dsSearchDetails.Tables[0].Rows[0][19].ToString();
            txtAnnualTurnOverSalesPurchasePTAX.Text = dsSearchDetails.Tables[0].Rows[0][20].ToString();
            txtMonthlyAvgWorkersPTAX.Text = dsSearchDetails.Tables[0].Rows[0][21].ToString();
            txtMonthlyAvgEmployeesPTAX.Text = dsSearchDetails.Tables[0].Rows[0][22].ToString();

            txtGSTPTAX.Text = dsSearchDetails.Tables[0].Rows[0][23].ToString();
            txtCSTPTAX.Text = dsSearchDetails.Tables[0].Rows[0][24].ToString();
            txtVATPTAX.Text = dsSearchDetails.Tables[0].Rows[0][25].ToString();
            rbVehiclesPTAX.SelectedValue = dsSearchDetails.Tables[0].Rows[0][26].ToString();
            rbLevelOfSocietyPTAX.SelectedValue = dsSearchDetails.Tables[0].Rows[0][27].ToString();


            divRegFormPTAX.Visible = true;

            divRegFormRubber.Visible = false;
            divRegFormITAX.Visible = false;
            divRegFormDSC.Visible = false;
            divRegFormAccounts.Visible = false;

            btnRegistrationPTAX.Visible = false;

            btnUpdatePTAX.Visible = true;
            btnUpdateITAX.Visible = false;
            btnUpdateRubber.Visible = false;
            btnUpdateDSC.Visible = false;

            // disabled inputs if roleid is not 1 else enable
            if (Session["Role"].ToString() != "1")
            {
                ddlApplyingAsPTAX.Enabled = false;
                txtApplicantNamePTAX.Enabled = false;
                txtFatherNamePTAX.Enabled = false;
                txtPANPTAX.Enabled = false;
                ddlGenderPTAX.Enabled = false;
                txtMobilePTAX.Enabled = false;
                txtEmailPTAX.Enabled = false;


                txtEstablishmentNamePTAX.Enabled = false;
                ddlDistrictPTAX.Enabled = false;
                txtPinCodePTAX.Enabled = false;
                txtEstablishmentAddressPTAX.Enabled = false;
                ddlProfessionCategoryPTAX.Enabled = false;
                ddlProfessionSubCategoryPTAX.Enabled = false;
                rbEngageWithPTAX.Enabled = false;


                txtDateofCommencementPTAX.Enabled = false;
                txtPANTANPTAX.Enabled = false;
                txtAnnualGrossBusinessPTAX.Enabled = false;
                txtAnnualTurnOverSalesPurchasePTAX.Enabled = false;
                txtMonthlyAvgWorkersPTAX.Enabled = false;
                txtMonthlyAvgEmployeesPTAX.Enabled = false;


                txtGSTPTAX.Enabled = false;
                txtCSTPTAX.Enabled = false;
                txtVATPTAX.Enabled = false;
                rbVehiclesPTAX.Enabled = false;
                rbLevelOfSocietyPTAX.Enabled = false;
            }
        }
        // RUBBER BOARD
        //======================================
        else if (dsSearchDetails.Tables[0].Rows.Count > 0 && ddlServices.SelectedValue.ToString() == "1")
        {

            filenumber = dsSearchDetails.Tables[0].Rows[0][1].ToString();

            ddlLicenceRB.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][3].ToString());
            txtApplicantNameRB.Text = dsSearchDetails.Tables[0].Rows[0][4].ToString();
            txtTraderNameRB.Text = dsSearchDetails.Tables[0].Rows[0][5].ToString();
            txtFathersNameRB.Text = dsSearchDetails.Tables[0].Rows[0][6].ToString();
            txtDOBRB.Text = Convert.ToDateTime(dsSearchDetails.Tables[0].Rows[0][7].ToString()).ToString("yyyy-MM-dd");

            // business

            txtBusinessPlaceRB.Text = dsSearchDetails.Tables[0].Rows[0][8].ToString();
            txtBuildingTypeRB.Text = dsSearchDetails.Tables[0].Rows[0][9].ToString();
            txtBuildingPlotNoRB.Text = dsSearchDetails.Tables[0].Rows[0][10].ToString();
            txtCityRB.Text = dsSearchDetails.Tables[0].Rows[0][11].ToString();
            ddlDistrictRB.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][12].ToString());

            ddlStateRB.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][13].ToString());
            txtPINRB.Text = dsSearchDetails.Tables[0].Rows[0][14].ToString();
            txtMobileRB.Text = dsSearchDetails.Tables[0].Rows[0][15].ToString();
            txtEmailRB.Text = dsSearchDetails.Tables[0].Rows[0][16].ToString();

            // storage

            txtStoragePlaceRB.Text = dsSearchDetails.Tables[0].Rows[0][17].ToString();
            txtBuildingTypeRB2.Text = dsSearchDetails.Tables[0].Rows[0][18].ToString();
            txtBuildingPlotNoRB2.Text = dsSearchDetails.Tables[0].Rows[0][19].ToString();
            txtCityRB2.Text = dsSearchDetails.Tables[0].Rows[0][20].ToString();
            ddlDistrictRB_Storage.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][21].ToString());

            ddlStateRB2.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][22].ToString());
            txtPINRB2.Text = dsSearchDetails.Tables[0].Rows[0][23].ToString();
            txtMobileRB2.Text = dsSearchDetails.Tables[0].Rows[0][24].ToString();
            txtEmailRB2.Text = dsSearchDetails.Tables[0].Rows[0][25].ToString();

            txtOwnerShipTypeRB.Text = dsSearchDetails.Tables[0].Rows[0][26].ToString();
            txtOwnerShipNameRB.Text = dsSearchDetails.Tables[0].Rows[0][27].ToString();

            // ppa

            txtPresentPermanentAddressRB.Text = dsSearchDetails.Tables[0].Rows[0][28].ToString();
            txtCityRB3.Text = dsSearchDetails.Tables[0].Rows[0][29].ToString();
            ddlDistrictRB_Address.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][30].ToString());
            ddlStateRB3.SelectedIndex = int.Parse(dsSearchDetails.Tables[0].Rows[0][31].ToString());
            txtPINRB3.Text = dsSearchDetails.Tables[0].Rows[0][32].ToString();
            txtMobileRB3.Text = dsSearchDetails.Tables[0].Rows[0][33].ToString();
            txtEmailRB3.Text = dsSearchDetails.Tables[0].Rows[0][34].ToString();
            txtPANRB3.Text = dsSearchDetails.Tables[0].Rows[0][35].ToString();
            txtInvestedCapitalRB3.Text = dsSearchDetails.Tables[0].Rows[0][36].ToString();


            divRegFormRubber.Visible = true;

            divRegFormPTAX.Visible = false;
            divRegFormITAX.Visible = false;
            divRegFormDSC.Visible = false;
            divRegFormAccounts.Visible = false;

            btnRegistrationRubber.Visible = false;

            btnUpdateRubber.Visible = true;
            btnUpdatePTAX.Visible = false;
            btnUpdateITAX.Visible = false;
            btnUpdateDSC.Visible = false;


            // disabled inputs if roleid is not 1 else enable
            if (Session["Role"].ToString() != "1")
            {
                ddlLicenceRB.Enabled = false;
                txtApplicantNameRB.Enabled = false;
                txtTraderNameRB.Enabled = false;
                txtFathersNameRB.Enabled = false;
                txtDOBRB.Enabled = false;

                // business

                txtBusinessPlaceRB.Enabled = false;
                txtBuildingTypeRB.Enabled = false;
                txtBuildingPlotNoRB.Enabled = false;
                txtCityRB.Enabled = false;
                ddlDistrictRB.Enabled = false;


                ddlStateRB.Enabled = false;
                txtPINRB.Enabled = false;
                txtMobileRB.Enabled = false;
                txtEmailRB.Enabled = false;

                // storage

                txtStoragePlaceRB.Enabled = false;
                txtBuildingTypeRB2.Enabled = false;
                txtBuildingPlotNoRB2.Enabled = false;
                txtCityRB2.Enabled = false;
                ddlDistrictRB_Storage.Enabled = false;


                ddlStateRB2.Enabled = false;
                txtPINRB2.Enabled = false;
                txtMobileRB2.Enabled = false;
                txtEmailRB2.Enabled = false;


                txtOwnerShipTypeRB.Enabled = false;
                txtOwnerShipNameRB.Enabled = false;

                // ppa

                txtPresentPermanentAddressRB.Enabled = false;
                txtCityRB3.Enabled = false;
                ddlDistrictRB_Address.Enabled = false;
                ddlStateRB3.Enabled = false;
                txtPINRB3.Enabled = false;
                txtMobileRB3.Enabled = false;
                txtEmailRB3.Enabled = false;
                txtPANRB3.Enabled = false;
                txtInvestedCapitalRB3.Enabled = false;

            }


        }
        // DSC
        //======================================
        else if (dsSearchDetails.Tables[0].Rows.Count > 0 && ddlServices.SelectedValue.ToString() == "6")
        {

            filenumber = dsSearchDetails.Tables[0].Rows[0][2].ToString();

            txtApplicantNameDSC.Text = dsSearchDetails.Tables[0].Rows[0][3].ToString();
            txtEstablishmentNameDSC.Text = dsSearchDetails.Tables[0].Rows[0][4].ToString();
            txtPANDSC.Text = dsSearchDetails.Tables[0].Rows[0][5].ToString();
            txtAdhaarDSC.Text = dsSearchDetails.Tables[0].Rows[0][6].ToString();
            txtMobileDSC.Text = dsSearchDetails.Tables[0].Rows[0][7].ToString();
            txtDOBDSC.Text = Convert.ToDateTime(dsSearchDetails.Tables[0].Rows[0][8].ToString()).ToString("yyyy-MM-dd");
            txtEmailDSC.Text = dsSearchDetails.Tables[0].Rows[0][9].ToString();
            ddlAdharLinkedDSC.SelectedValue = dsSearchDetails.Tables[0].Rows[0][10].ToString() == "true" ? "1" : "0";
            txtLinkedMobileWithAdhaarDSC.Text = dsSearchDetails.Tables[0].Rows[0][11].ToString();
            txtAddressDSC.Text = dsSearchDetails.Tables[0].Rows[0][12].ToString();
            ddlDistrictsDSC.SelectedValue = dsSearchDetails.Tables[0].Rows[0][13].ToString();
            txtPINDSC.Text = dsSearchDetails.Tables[0].Rows[0][14].ToString();
            txtApplicationNumberDSC.Text = dsSearchDetails.Tables[0].Rows[0][15].ToString();



            divRegFormDSC.Visible = true;

            divRegFormPTAX.Visible = false;
            divRegFormITAX.Visible = false;
            divRegFormRubber.Visible = false;
            divRegFormAccounts.Visible = false;

            btnRegistrationDSC.Visible = false;

            btnUpdateDSC.Visible = true;
            btnUpdateRubber.Visible = false;
            btnUpdatePTAX.Visible = false;
            btnUpdateITAX.Visible = false;



            // disabled inputs if roleid is not 1 else enable 
            if (Session["Role"].ToString() != "1")
            {
                txtApplicantNameDSC.Enabled = false;
                txtEstablishmentNameDSC.Enabled = false;
                txtPANDSC.Enabled = false;
                txtAdhaarDSC.Enabled = false;
                txtMobileDSC.Enabled = false;
                txtDOBDSC.Enabled = false;
                txtEmailDSC.Enabled = false;
                ddlAdharLinkedDSC.Enabled = false;
                txtLinkedMobileWithAdhaarDSC.Enabled = false;
                txtAddressDSC.Enabled = false;
                ddlDistrictsDSC.Enabled = false;
                txtPINDSC.Enabled = false;
                txtApplicationNumberDSC.Enabled = false;
            }
        }
        // GST
        //======================================
        else if (dsSearchDetails.Tables[0].Rows.Count > 0 && ddlServices.SelectedValue.ToString() == "2")
        {
            filenumber = dsSearchDetails.Tables[0].Rows[0][2].ToString();

            txtLegalBusinessNameGST.Text = dsSearchDetails.Tables[0].Rows[0][3].ToString();
            txtAdhaarGST.Text = dsSearchDetails.Tables[0].Rows[0][4].ToString();
            txtPanGST.Text = dsSearchDetails.Tables[0].Rows[0][5].ToString();
            txtTradeNameGST.Text = dsSearchDetails.Tables[0].Rows[0][6].ToString();
            ddlConstituitionOfBusinessGST.SelectedValue = dsSearchDetails.Tables[0].Rows[0][7].ToString();
            ddlCasualTaxablePersonGST.SelectedValue = dsSearchDetails.Tables[0].Rows[0][8].ToString();
            ddlOptionsForCommissionGST.SelectedValue = dsSearchDetails.Tables[0].Rows[0][9].ToString();
            ddlReasonToObtainRegistrationGST.SelectedValue = dsSearchDetails.Tables[0].Rows[0][10].ToString();
            txtDateOfCommencementGST.Text = Convert.ToDateTime(dsSearchDetails.Tables[0].Rows[0][11].ToString()).ToString("yyyy-MM-dd");
            txtDateOnLiabbilityGST.Text = Convert.ToDateTime(dsSearchDetails.Tables[0].Rows[0][12].ToString()).ToString("yyyy-MM-dd");
            txtNameofPersonGST.Text = dsSearchDetails.Tables[0].Rows[0][13].ToString();
            txtFatherNameGST.Text = dsSearchDetails.Tables[0].Rows[0][14].ToString();
            txtDOBGST.Text = dsSearchDetails.Tables[0].Rows[0][15].ToString();
            ddlGenderGST.SelectedValue = dsSearchDetails.Tables[0].Rows[0][16].ToString();
            txtMobileGST.Text = dsSearchDetails.Tables[0].Rows[0][17].ToString();
            txtEmailGST.Text = dsSearchDetails.Tables[0].Rows[0][18].ToString();
            txtAuthorisedSignatoryGST.Text = dsSearchDetails.Tables[0].Rows[0][19].ToString();
            ddlDesignationGST.SelectedValue = dsSearchDetails.Tables[0].Rows[0][20].ToString();
            txtResidentialAddressWithPinGST.Text = dsSearchDetails.Tables[0].Rows[0][21].ToString();
            ddlNoOfPartnersGST.SelectedValue = dsSearchDetails.Tables[0].Rows[0][22].ToString();
            ddlConcernDealsWithGST.SelectedValue = dsSearchDetails.Tables[0].Rows[0][23].ToString();
            //ddlAuthorisedSignatoryGST.SelectedValue = dsSearchDetails.Tables[0].Rows[0][24].ToString();
            ddlAdditionalRepresentativeGST.SelectedValue = dsSearchDetails.Tables[0].Rows[0][25].ToString();
            txtPrincipalPlaceGST.Text = dsSearchDetails.Tables[0].Rows[0][26].ToString();
            ddlStateGST.SelectedValue = dsSearchDetails.Tables[0].Rows[0][27].ToString();
            txtSecCirWardChargeGST.Text = dsSearchDetails.Tables[0].Rows[0][28].ToString();
            txtCommisionerateGST.Text = dsSearchDetails.Tables[0].Rows[0][29].ToString();
            ddlDivisionGST.SelectedValue = dsSearchDetails.Tables[0].Rows[0][30].ToString();
            ddlRangeGST.SelectedValue = dsSearchDetails.Tables[0].Rows[0][31].ToString();
            ddlNatureOfPossesionGST.SelectedValue = dsSearchDetails.Tables[0].Rows[0][32].ToString();
            txtProofOfPrincipalPlaceGST.Text = dsSearchDetails.Tables[0].Rows[0][33].ToString();
            ddlNatureofBusinessGST.SelectedValue = dsSearchDetails.Tables[0].Rows[0][34].ToString();
            txtAdditionalBusinessPlaceGST.Text = dsSearchDetails.Tables[0].Rows[0][35].ToString();
            txtDetailsOfGdComdtGST.Text = dsSearchDetails.Tables[0].Rows[0][36].ToString();
            txtPTaxRegCertfGST.Text = dsSearchDetails.Tables[0].Rows[0][37].ToString();
            txtPTaxEmpCodeGST.Text = dsSearchDetails.Tables[0].Rows[0][38].ToString();

            divRegFormGST.Visible = true;

            divRegFormPTAX.Visible = false;
            divRegFormITAX.Visible = false;
            divRegFormRubber.Visible = false;
            divRegFormDSC.Visible = false;
            divRegFormAccounts.Visible = false;

            btnRegistrationGST.Visible = false;

            btnUpdateGST.Visible = true;

            btnUpdateDSC.Visible = false;
            btnUpdateRubber.Visible = false;
            btnUpdatePTAX.Visible = false;
            btnUpdateITAX.Visible = false;



            // disabled inputs if roleid is not 1 else enable 
            if (Session["Role"].ToString() != "1")
            {
                txtCustomerID.Enabled = false;
                txtLegalBusinessNameGST.Enabled = false;
                txtAdhaarGST.Enabled = false;
                txtPanGST.Enabled = false;
                txtTradeNameGST.Enabled = false;
                ddlConstituitionOfBusinessGST.Enabled = false;
                ddlCasualTaxablePersonGST.Enabled = false;
                ddlOptionsForCommissionGST.Enabled = false;
                ddlReasonToObtainRegistrationGST.Enabled = false;
                txtDateOfCommencementGST.Enabled = false;
                txtDateOnLiabbilityGST.Enabled = false;
                txtNameofPersonGST.Enabled = false;
                txtFatherNameGST.Enabled = false;
                txtDOBGST.Enabled = false;
                ddlGenderGST.Enabled = false;
                txtMobileGST.Enabled = false;
                txtEmailGST.Enabled = false;
                txtAuthorisedSignatoryGST.Enabled = false;
                ddlDesignationGST.Enabled = false;
                txtResidentialAddressWithPinGST.Enabled = false;
                ddlNoOfPartnersGST.Enabled = false;
                txtResidentialAddressWithPinGST.Enabled = false;
                txtAuthorisedSignatoryGST.Enabled = false;
                ddlAuthorisedSignatoryGST.Enabled = false;
                txtPrincipalPlaceGST.Enabled = false;
                ddlStateGST.Enabled = false;
                txtSecCirWardChargeGST.Enabled = false;
                txtCommisionerateGST.Enabled = false;
                ddlDivisionGST.Enabled = false;
                ddlRangeGST.Enabled = false;
                ddlNatureOfPossesionGST.Enabled = false;
                txtProofOfPrincipalPlaceGST.Enabled = false;
                ddlNatureofBusinessGST.Enabled = false;
                txtAdditionalBusinessPlaceGST.Enabled = false;
                txtDetailsOfGdComdtGST.Enabled = false;
                txtPTaxRegCertfGST.Enabled = false;
                txtPTaxEmpCodeGST.Enabled = false;
                ddlServices.Enabled = false;
            }
        }
        // GST
        //======================================
        else if (dsSearchDetails.Tables[0].Rows.Count > 0 && ddlServices.SelectedValue.ToString() == "4")
        {
            filenumber = dsSearchDetails.Tables[0].Rows[0][2].ToString();

            txtPanACN.Text = dsSearchDetails.Tables[0].Rows[0][2].ToString();

            divRegFormAccounts.Visible = true;

            divRegFormPTAX.Visible = false;
            divRegFormITAX.Visible = false;
            divRegFormRubber.Visible = false;
            divRegFormDSC.Visible = false;
            divRegFormGST.Visible = false;

            btnRegistrationAccountsACN.Visible = false;


            btnUpdateAccountsACN.Visible = true;

            btnUpdateDSC.Visible = false;
            btnUpdateRubber.Visible = false;
            btnUpdatePTAX.Visible = false;
            btnUpdateITAX.Visible = false;
            btnUpdateGST.Visible = false;



            // disabled inputs if roleid is not 1 else enable 
            if (Session["Role"].ToString() != "1")
            {
                txtPanACN.Enabled = false;
            }
        }
    }

    protected void btnRegistrationDSC_Click(object sender, EventArgs e)
    {
        if (!chkAgreeDSC.Checked)
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "You must accept the concent before you submit the application.";
            divSuccess.Visible = false;

            return;
        }
        if (Session["User"] != null)
        {
            try
            {
                Utility utility = new Utility();
                Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();

                serviceDetails.filenumber = utility.CreateFileNumber(int.Parse(ddlServices.SelectedValue.ToString()), txtPANDSC.Text);
                serviceDetails.customerid = txtCustomerID.Text;
                serviceDetails.applicantname = txtApplicantNameDSC.Text;
                serviceDetails.establishmentname = txtEstablishmentNameDSC.Text;
                serviceDetails.pan = txtPANDSC.Text;
                serviceDetails.adhaar = txtAdhaarDSC.Text;
                serviceDetails.mobile = txtMobileDSC.Text;
                serviceDetails.dob = string.IsNullOrEmpty(txtDOBDSC.Text) ? DateTime.MaxValue : Convert.ToDateTime(txtDOBDSC.Text);
                serviceDetails.email = txtEmailDSC.Text;
                serviceDetails.isadhaarlinkedwithmobile = ddlAdharLinkedDSC.SelectedValue.ToString() == "1" ? true : false;
                serviceDetails.linkedmobilewithadhaar = txtLinkedMobileWithAdhaarDSC.Text;
                serviceDetails.address = txtAddressDSC.Text;
                serviceDetails.district = int.Parse(ddlDistrictsDSC.SelectedValue.ToString());
                serviceDetails.pin = txtPINDSC.Text;
                serviceDetails.serviceid = int.Parse(ddlServices.SelectedValue.ToString());
                serviceDetails.enteredby = Session["User"].ToString();
                serviceDetails.dateofinsert = DateTime.Now;
                serviceDetails.applicationnumber = txtApplicationNumberDSC.Text;
                serviceDetails.acknowledgeupdateon = string.IsNullOrEmpty(txtDateOfAckDSC.Text) ? DateTime.MaxValue : Convert.ToDateTime(txtDateOfAckDSC.Text);

                database = new DataBase();
                utility.InsertRegistrationDSC(serviceDetails);

                divSuccess.Visible = true;
                lblSuccess.InnerText = "Form Details Submitted Successfully.";
                divError.Visible = false;
                lblError.Visible = false;

                //clear all the input controls
                ResetInputs(int.Parse(ddlServices.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                lblError.Visible = true;
                lblError.InnerText = ex.Message.ToString();
                divSuccess.Visible = false;
            }
        }
        else
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "Session is expired.";
            divSuccess.Visible = false;
        }
    }

    protected void btnUpdateDSC_Click(object sender, EventArgs e)
    {
        Utility utility = new Utility();
        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();
        serviceDetails.filenumber = filenumber;
        serviceDetails.customerid = txtCustomerID.Text;
        serviceDetails.serviceid = int.Parse(ddlServices.SelectedValue.ToString());
        serviceDetails.applicationnumber = txtApplicationNumberDSC.Text;
        serviceDetails.acknowledgeupdateon = Convert.ToDateTime(txtDateOfAckDSC.Text);
        utility.UpdateAcknowledgeNumber(serviceDetails);

        divSuccess.Visible = true;
        lblSuccess.InnerText = "Record Updated Successfully.";
        divError.Visible = false;
        lblError.Visible = false;
    }
    protected void btnRegistrationGST_Click(object sender, EventArgs e)
    {
        if (!chkAgreeGST.Checked)
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "You must accept the concent before you submit the application.";
            divSuccess.Visible = false;

            return;
        }

        if (Session["User"] != null)
        {
            try
            {
                Utility utility = new Utility();
                Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();

                serviceDetails.filenumber = utility.CreateFileNumber(int.Parse(ddlServices.SelectedValue.ToString()), txtPanGST.Text);
                serviceDetails.customerid = txtCustomerID.Text;
                serviceDetails.legalbusinessname = txtLegalBusinessNameGST.Text;
                serviceDetails.adhaar = txtAdhaarGST.Text;
                serviceDetails.pan = txtPanGST.Text;
                serviceDetails.tradername = txtTradeNameGST.Text;

                serviceDetails.constitutionofbusiness = int.Parse(ddlConstituitionOfBusinessGST.SelectedValue.ToString());
                serviceDetails.iscasualtaxable = int.Parse(ddlCasualTaxablePersonGST.SelectedValue.ToString());
                serviceDetails.compositionoption = int.Parse(ddlOptionsForCommissionGST.SelectedValue.ToString());
                serviceDetails.resonregistration = int.Parse(ddlReasonToObtainRegistrationGST.SelectedValue.ToString());
                serviceDetails.dateofcommencement_gst = string.IsNullOrEmpty(txtDateOfCommencementGST.Text) ? DateTime.MaxValue : Convert.ToDateTime(txtDateOfCommencementGST.Text);
                serviceDetails.dateofliabilityregister = string.IsNullOrEmpty(txtDateOnLiabbilityGST.Text) ? DateTime.MaxValue : Convert.ToDateTime(txtDateOnLiabbilityGST.Text);
                serviceDetails.applicantname = txtNameofPersonGST.Text;
                serviceDetails.fathername = txtFatherNameGST.Text;
                serviceDetails.dob = string.IsNullOrEmpty(txtDOBGST.Text) ? DateTime.MaxValue : Convert.ToDateTime(txtDOBGST.Text);

                serviceDetails.gender = int.Parse(ddlGenderGST.SelectedValue.ToString());
                serviceDetails.mobile = txtMobileGST.Text;
                serviceDetails.email = txtEmailGST.Text;
                serviceDetails.authorisedsignatory = txtAuthorisedSignatoryGST.Text;
                serviceDetails.designation = int.Parse(ddlDesignationGST.SelectedValue.ToString());
                serviceDetails.residentialaddress = txtResidentialAddressWithPinGST.Text;
                serviceDetails.noofdirectors = int.Parse(ddlNoOfPartnersGST.SelectedValue.ToString());
                serviceDetails.concerndealswith = int.Parse(ddlConcernDealsWithGST.SelectedValue.ToString());
                serviceDetails.detailsauthorisedsignatory = txtAuthorisedSignatoryGST.Text;
                serviceDetails.isauthorisedrepresentative = int.Parse(ddlAuthorisedSignatoryGST.SelectedValue.ToString());
                serviceDetails.principalplace = txtPrincipalPlaceGST.Text;
                serviceDetails.statejurisdiction = int.Parse(ddlStateGST.SelectedValue.ToString());
                serviceDetails.SCWC = txtSecCirWardChargeGST.Text;
                serviceDetails.commisionerate = txtCommisionerateGST.Text;
                serviceDetails.division = int.Parse(ddlDivisionGST.SelectedValue.ToString());
                serviceDetails.range = int.Parse(ddlRangeGST.SelectedValue.ToString());
                serviceDetails.natureofpossession = int.Parse(ddlNatureOfPossesionGST.SelectedValue.ToString());
                serviceDetails.proofofprincipleplace = txtProofOfPrincipalPlaceGST.Text;
                serviceDetails.natureofbusiness = int.Parse(ddlNatureofBusinessGST.SelectedValue.ToString());
                serviceDetails.businessadditionalplace = txtAdditionalBusinessPlaceGST.Text;
                serviceDetails.detailsofgoodssupplied = txtDetailsOfGdComdtGST.Text;
                serviceDetails.ptaxcertificateno = txtPTaxRegCertfGST.Text;
                serviceDetails.ptaxemployeecode = txtPTaxEmpCodeGST.Text;
                serviceDetails.serviceid = int.Parse(ddlServices.SelectedValue.ToString());
                serviceDetails.enteredby = Session["User"].ToString();
                serviceDetails.dateofinsert = DateTime.Now;
                serviceDetails.applicationnumber = txtApplicationNumberGST.Text;
                serviceDetails.acknowledgeupdateon = string.IsNullOrEmpty(txtDateOfAckGST.Text) ? DateTime.MaxValue : Convert.ToDateTime(txtDateOfAckGST.Text);
                serviceDetails.nameofauthorisedsignatory = txtAutorisedRepresentativeNameGST.Text;
                serviceDetails.trn = txtTrnNumberGST.Text;

                database = new DataBase();
                utility.InsertRegistrationGST(serviceDetails);

                divSuccess.Visible = true;
                lblSuccess.InnerText = "Form Details Submitted Successfully.";
                divError.Visible = false;
                lblError.Visible = false;

                //clear all the input controls
                ResetInputs(int.Parse(ddlServices.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                lblError.Visible = true;
                lblError.InnerText = ex.Message.ToString();
                divSuccess.Visible = false;
            }
        }
        else
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "Session is expired.";
            divSuccess.Visible = false;
        }
    }
    protected void btnUpdateGST_Click(object sender, EventArgs e)
    {
        Utility utility = new Utility();
        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();
        serviceDetails.filenumber = filenumber;
        serviceDetails.customerid = txtCustomerID.Text;
        serviceDetails.serviceid = int.Parse(ddlServices.SelectedValue.ToString());
        serviceDetails.applicationnumber = txtApplicationNumberGST.Text;
        serviceDetails.acknowledgeupdateon = Convert.ToDateTime(txtDateOfAckGST.Text);
        utility.UpdateAcknowledgeNumber(serviceDetails);

        divSuccess.Visible = true;
        lblSuccess.InnerText = "Record Updated Successfully.";
        divError.Visible = false;
        lblError.Visible = false;
    }

    public void LoadDirectorNumbers()
    {
        Utility utitlity = new Utility();
        ddlNoOfPartnersGST.DataSource = utitlity.CreateDataSetForNumberOfDirectors();
        ddlNoOfPartnersGST.DataTextField = "noofperson";
        ddlNoOfPartnersGST.DataValueField = "sl";
        ddlNoOfPartnersGST.DataBind();
        ddlNoOfPartnersGST.Items.Insert(0, new ListItem("-- Select Number of Person --", "0"));
    }

    protected void btnRegistrationAccountsACN_Click(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            try
            {
                Utility utility = new Utility();
                Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();


                serviceDetails.filenumber = utility.CreateFileNumber(int.Parse(ddlServices.SelectedValue.ToString()), txtPanACN.Text);
                serviceDetails.customerid = txtCustomerID.Text;
                serviceDetails.pan = txtPanACN.Text;
                serviceDetails.applicationnumber = txtAcknowledgementNoACN.Text;
                serviceDetails.enteredby = Session["User"].ToString();
                serviceDetails.dateofinsert = DateTime.Now;
                serviceDetails.serviceid = int.Parse(ddlServices.SelectedValue.ToString());
                serviceDetails.acknowledgeupdateon = string.IsNullOrEmpty(txtDateOfAckACN.Text) ? DateTime.MaxValue : Convert.ToDateTime(txtDateOfAckACN.Text);

                utility = new Utility();
                utility.InsertRegistrationAccounts(serviceDetails);

                divSuccess.Visible = true;
                lblSuccess.InnerText = "Form Details Submitted Successfully.";
                divError.Visible = false;
                lblError.Visible = false;

                //clear all the input controls
                ResetInputs(int.Parse(ddlServices.SelectedValue.ToString()));

                ResetInputs(4);
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                lblError.Visible = true;
                lblError.InnerText = ex.Message.ToString();
                divSuccess.Visible = false;
            }
        }
        else
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "Session is expired.";
            divSuccess.Visible = false;
        }
    }

    protected void btnUpdateAccountsACN_Click(object sender, EventArgs e)
    {
        Utility utility = new Utility();
        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();
        serviceDetails.filenumber = filenumber;
        serviceDetails.customerid = txtCustomerID.Text;
        serviceDetails.serviceid = int.Parse(ddlServices.SelectedValue.ToString());
        serviceDetails.applicationnumber = txtAcknowledgementNoACN.Text;
        utility.UpdateAcknowledgeNumber(serviceDetails);

        divSuccess.Visible = true;
        lblSuccess.InnerText = "Record Updated Successfully.";
        divError.Visible = false;
        lblError.Visible = false;
    }
}