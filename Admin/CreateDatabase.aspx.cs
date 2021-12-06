using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CreateDatabase : System.Web.UI.Page
{
    Utility.GeneralInformation generalInformation;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropDownListServices();
            titleGenInfo.Visible = true;
            divGeneralInformation.Visible = true;
            btnBack.Visible = false;


            // at first time page load
            LoadDirectorNumbers();
            FillDropDownListForCoreBusiness();
            FillDropDownListForFirms();
        }
        else
        {
            if (Session["GeneralInformation"] != null)
            {

                generalInformation = new Utility.GeneralInformation();

                txtFileNumber.Text = generalInformation.filenumber;
                txtCustomerCode.Text = generalInformation.filenumber;
                ddlFirmType.SelectedIndex = generalInformation.typesoffirm;
                ddlPartners.SelectedIndex = generalInformation.noofdirectors;
                txtConcern.Text = generalInformation.filenumber;
                ddlCoreBusiness.SelectedIndex = generalInformation.corebusiness;
                txtConcernAddress.Text = generalInformation.concernaddress;
                txtName.Text = generalInformation.filenumber;
                txtFatherName.Text = generalInformation.filenumber;
                txtEmail.Text = generalInformation.filenumber;
                txtContact.Text = generalInformation.filenumber;
                txtAdhaar.Text = generalInformation.filenumber;
                txtVoterID.Text = generalInformation.filenumber;
                txtPAN.Text = generalInformation.filenumber;
                ddlServices.SelectedIndex = generalInformation.servicetakenon;
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

    protected void btnSaveGeneralInformation_Click(object sender, EventArgs e)
    {
        // make step 2 from step 1
        if (hstep1.Visible)
            hdnSteps.Value = "2";
        else
            hdnSteps.Value = "3";

        if (hdnSteps.Value == "2")
        {
            divGeneralInformation.Visible = false;
            titleCredInfo.Visible = true;
            titleGenInfo.Visible = false;
            divCredentialInformation.Visible = true;
            btnSaveGeneralInformation.Text = "Step 3 : Save Information";
            btnBack.Visible = true;

            #region garbage
            // create customer object
            // Session["Customer"] = new DataBase.Customer(txtCustomerCode.Text, txtName.Text, txtEmail.Text, txtContact.Text, txtAdhaar.Text, txtPAN.Text);
            #endregion

            // FILLING THE CUSTOMERDETAILS OBJECT
            CreateGeneralInformationObject();
            // SAVING THE CUSTOMER DETAILS AND CREDENTIALS INTO DATABASE

        }
        else if (hdnSteps.Value == "3")
        {
            divGeneralInformation.Visible = false;
            divCredentialInformation.Visible = false;
            titleCredInfo.Visible = false;
            titleGenInfo.Visible = false;
            btnSaveGeneralInformation.Text = "Save";

            // call save method



            //SaveCutomerDetails();
            if (Session["GeneralInformation"] != null)
            {
                Utility CustomerDatabase = new Utility();
                Utility.GeneralInformation GeneralInformation = (Utility.GeneralInformation)Session["GeneralInformation"];

                // generate customer credentials object 

                Utility.CustomerCredentials customerCredentials = new Utility.CustomerCredentials();
                customerCredentials.CustomerID = txtCustomerId.Text;
                customerCredentials.CustomerPassword = txtPassword.Text;

                // call save method
                CustomerDatabase.InsertGeneralInfoAndCredentials(GeneralInformation, customerCredentials);

                divSuccess.Visible = true;
                lblSuccess.InnerText = "General Information Saved Successfully.";
                divError.Visible = false;
                lblError.Visible = false;
            }
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (hdnSteps.Value == "2")
        {
            FillDropDownListServices();

            divGeneralInformation.Visible = true;
            divCredentialInformation.Visible = false;

            titleGenInfo.Visible = true;
            titleCredInfo.Visible = false;


            btnBack.Visible = false;
            btnSaveGeneralInformation.Text = "Step 2";
            hdnSteps.Value = "1";

            // call method to create general information object

            CreateGeneralInformationObject();
        }
        else if (hdnSteps.Value == "3")
        {
            divGeneralInformation.Visible = false;
            divCredentialInformation.Visible = true;

            titleGenInfo.Visible = false;
            titleCredInfo.Visible = true;

            btnSaveGeneralInformation.Text = "Step 3";
            hdnSteps.Value = "2";
        }
    }

    public void LoadDirectorNumbers()
    {
        Utility utitlity = new Utility();
        ddlPartners.DataSource = utitlity.CreateDataSetForNumberOfDirectors();
        ddlPartners.DataTextField = "noofperson";
        ddlPartners.DataValueField = "sl";
        ddlPartners.DataBind();
        ddlPartners.Items.Insert(0, new ListItem("-- Select Number of Person --", "0"));
    }

    protected void ddlServices_SelectedIndexChanged(object sender, EventArgs e)
    {
        //creating file number based on the service selection by the customer.

        // check if PAN is empty or not
        if (!string.IsNullOrEmpty(txtPAN.Text))
        {
            string FileNumber = string.Empty;
            if (ddlServices.SelectedIndex == 1)
                FileNumber = "FLP-" + txtPAN.Text.Substring(4, 6) + Utility.Services.RBR;
            else if (ddlServices.SelectedIndex == 2)
                FileNumber = "FLP-" + txtPAN.Text.Substring(4, 6) + Utility.Services.GST;
            else if (ddlServices.SelectedIndex == 3)
                FileNumber = "FLP-" + txtPAN.Text.Substring(4, 6) + Utility.Services.ITR;
            else if (ddlServices.SelectedIndex == 4)
                FileNumber = "FLP-" + txtPAN.Text.Substring(4, 6) + Utility.Services.ACS;
            else if (ddlServices.SelectedIndex == 5)
                FileNumber = "FLP-" + txtPAN.Text.Substring(4, 6) + Utility.Services.PTX;
            else if (ddlServices.SelectedIndex == 6)
                FileNumber = "FLT-" + txtPAN.Text.Substring(4, 6) + Utility.Services.DSC;
            else if (ddlServices.SelectedIndex == 7)
                FileNumber = "FLT-" + txtPAN.Text.Substring(4, 6) + Utility.Services.EPF;

            txtFileNumber.Text = FileNumber;
            divError.Visible = false;
        }
        else
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "You need to provide your PAN number";
            divSuccess.Visible = false;
        }

        //creating customer code on general / personal information.

        string customerCode = string.Empty;
        if (!string.IsNullOrEmpty(txtAdhaar.Text) && !string.IsNullOrEmpty(txtContact.Text))
        {
            customerCode = "C-" + txtContact.Text.Substring(6, 4) + txtAdhaar.Text.Substring(8, 4) + Convert.ToDateTime(DateTime.Now).ToString("ddMMyy");
        }
        else if (!string.IsNullOrEmpty(txtVoterID.Text) && !string.IsNullOrEmpty(txtContact.Text))
        {
            customerCode = "C-" + txtContact.Text.Substring(6, 4) + txtVoterID.Text.Substring(8, 4) + Convert.ToDateTime(DateTime.Now).ToString("ddMMyy");
        }
        txtCustomerCode.Text = customerCode;
    }

    // create generalinformation object
    public void CreateGeneralInformationObject()
    {
        if (Session["GeneralInformation"] == null)
        {

            // generate customer general information object

            generalInformation = new Utility.GeneralInformation();
            generalInformation.filenumber = txtFileNumber.Text;
            generalInformation.customercode = txtCustomerCode.Text;
            generalInformation.concernname = txtConcern.Text;
            generalInformation.typesoffirm = int.Parse(ddlFirmType.SelectedValue.ToString());
            generalInformation.noofdirectors = int.Parse(ddlPartners.SelectedValue.ToString());
            generalInformation.concerndealswith = int.Parse(ddlConcernDeals.SelectedValue.ToString());
            generalInformation.corebusiness = int.Parse(ddlCoreBusiness.SelectedValue.ToString());
            generalInformation.concernaddress = txtConcernAddress.Text;
            generalInformation.customername = txtName.Text;
            generalInformation.fathersname = txtFatherName.Text;
            generalInformation.email = txtEmail.Text;
            generalInformation.contact = txtContact.Text;
            generalInformation.adhaar = txtAdhaar.Text;
            generalInformation.voterid = txtVoterID.Text;
            generalInformation.pannumber = txtPAN.Text;
            generalInformation.servicetakenon = int.Parse(ddlServices.SelectedValue.ToString());

            Session["GeneralInformation"] = generalInformation;

            txtCustomerId.Text = generalInformation.customercode;
        }
    }

    public void FillDropDownListForCoreBusiness()
    {
        Utility utility = new Utility();
        ddlCoreBusiness.DataSource = utility.GetAllCoreBusiness();
        ddlCoreBusiness.DataValueField = "corebusinessid";
        ddlCoreBusiness.DataTextField = "corebusinessname";
        ddlCoreBusiness.DataBind();
        ddlCoreBusiness.Items.Insert(0, new ListItem("-- Select Core Business --", "0"));
    }

    public void FillDropDownListForFirms()
    {
        Utility utility = new Utility();
        ddlFirmType.DataSource = utility.GetAllActiveFirms();
        ddlFirmType.DataValueField = "firm_id";
        ddlFirmType.DataTextField = "firm_name";
        ddlFirmType.DataBind();
        ddlFirmType.Items.Insert(0, new ListItem("-- Select Firm --", "0"));
    }

    protected void btnGeneratepw_Click(object sender, EventArgs e)
    {
        string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "1234567890";

        string characters = numbers;

        characters += alphabets + small_alphabets + numbers;

        int length = 6;
        string otp = string.Empty;
        for (int i = 0; i < length; i++)
        {
            string character = string.Empty;
            do
            {
                int index = new Random().Next(0, characters.Length);
                character = characters.ToCharArray()[index].ToString();
            } while (otp.IndexOf(character) != -1);
            otp += character;
        }
        txtPassword.Text = otp;

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        User user = new User();
        user.userid = txtCustomerId.Text;
        user.password = txtPassword.Text;
        try
        { // call reset password method
            user.ResetPassword(user);

            txtCustomerId.Text = string.Empty;
            txtPassword.Text = string.Empty;

            divSuccess.Visible = true;
            lblSuccess.InnerText = "Password Reset Successfully.";
            divError.Visible = false;
            lblError.Visible = false;
        }
        catch (Exception ex)
        {
            divSuccess.Visible = false;
            lblSuccess.Visible = false;
            divError.Visible = true;
            lblError.InnerText = ex.Message.ToString();
        }
    }

    private string CreateSalt(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
    }
}