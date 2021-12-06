using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageDatabase : System.Web.UI.Page
{
    Utility utility;
    Utility.GeneralInformation generalInformation;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropDownListServices();
            LoadDirectorNumbers();
            FillDropDownListForCoreBusiness();
            FillDropDownListForFirms();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Utility customerDatabase = new Utility();
        DataSet dsSearchBasicDetails = customerDatabase.SeachBasicGeneralDetails(txtConcernName.Text, txtFileNumberForSearch.Text, txtCustomerCodeForSearch.Text);
        if (dsSearchBasicDetails.Tables[0].Rows.Count != 0)
        {
            lnkFileNumber.Text = dsSearchBasicDetails.Tables[0].Rows[0][0].ToString();
            lnkCustomerCode.Text = dsSearchBasicDetails.Tables[0].Rows[0][2].ToString();
            lnkConcernName.Text = dsSearchBasicDetails.Tables[0].Rows[0][1].ToString();
            lblProprietorName.Text = dsSearchBasicDetails.Tables[0].Rows[0][3].ToString();
        }
    }

    public void FillDropDownListServices()
    {
        utility = new Utility();
        //ddlServices.DataSource = database.GetAllServices();
        //ddlServices.DataValueField = "serviceid";
        //ddlServices.DataTextField = "servicename";
        //ddlServices.DataBind();
        //ddlServices.Items.Insert(0, new ListItem("-- Select Service --", "0"));


        ddlServicesList.DataSource = utility.GetAllServices();
        ddlServicesList.DataValueField = "serviceid";
        ddlServicesList.DataTextField = "servicename";
        ddlServicesList.DataBind();
        ddlServicesList.Items.Insert(0, new ListItem("-- Select Service --", "0"));

    }


    protected void lnkFileNumber_Click(object sender, EventArgs e)
    {
        utility = new Utility();
        DataSet dsSearchDetailsOnFilter = utility.FindAllDetailsOnFilteredParameter(lnkFileNumber.Text, "", "");

        // call input control filling details method
        FillAllInputsFromSearchResult(dsSearchDetailsOnFilter);
    }

    protected void lnkCustomerCode_Click(object sender, EventArgs e)
    {
        utility = new Utility();
        DataSet dsSearchDetailsOnFilter = utility.FindAllDetailsOnFilteredParameter("", lnkCustomerCode.Text, "");

        // call input control filling details method
        FillAllInputsFromSearchResult(dsSearchDetailsOnFilter);
    }

    protected void lnkConcernName_Click(object sender, EventArgs e)
    {
        utility = new Utility();
        DataSet dsSearchDetailsOnFilter = utility.FindAllDetailsOnFilteredParameter("", "", lnkConcernName.Text);

        // call input control filling details method
        FillAllInputsFromSearchResult(dsSearchDetailsOnFilter);
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

    public void LoadDirectorNumbers()
    {
        Utility utility = new Utility();
        ddlPartners.DataSource = utility.CreateDataSetForNumberOfDirectors();
        ddlPartners.DataTextField = "noofperson";
        ddlPartners.DataValueField = "sl";
        ddlPartners.DataBind();
        ddlPartners.Items.Insert(0, new ListItem("-- Select Number of Person --", "0"));
    }

    public void FillAllInputsFromSearchResult(DataSet dsSearchResult)
    {
        txtFileNumber.Text = dsSearchResult.Tables[0].Rows[0][1].ToString();
        txtCustomerCode.Text = dsSearchResult.Tables[0].Rows[0][2].ToString();
        txtConcern.Text = dsSearchResult.Tables[0].Rows[0][3].ToString();
        ddlFirmType.SelectedIndex = int.Parse(dsSearchResult.Tables[0].Rows[0][4].ToString());
        ddlPartners.SelectedIndex = int.Parse(dsSearchResult.Tables[0].Rows[0][5].ToString());
        ddlConcernDeals.SelectedIndex = int.Parse(dsSearchResult.Tables[0].Rows[0][6].ToString());
        ddlCoreBusiness.SelectedIndex = int.Parse(dsSearchResult.Tables[0].Rows[0][7].ToString());
        txtConcernAddress.Text = dsSearchResult.Tables[0].Rows[0][8].ToString();
        txtName.Text = dsSearchResult.Tables[0].Rows[0][9].ToString();
        txtFatherName.Text = dsSearchResult.Tables[0].Rows[0][10].ToString();
        txtEmail.Text = dsSearchResult.Tables[0].Rows[0][11].ToString();
        txtContact.Text = dsSearchResult.Tables[0].Rows[0][12].ToString();
        txtAdhaar.Text = dsSearchResult.Tables[0].Rows[0][13].ToString();
        txtVoterID.Text = dsSearchResult.Tables[0].Rows[0][14].ToString();
        txtPAN.Text = dsSearchResult.Tables[0].Rows[0][15].ToString();
        ddlServicesList.SelectedIndex = int.Parse(dsSearchResult.Tables[0].Rows[0][16].ToString());
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        txtFileNumber.Enabled = true;
        txtCustomerCode.Enabled = true;
        txtConcern.Enabled = true;
        ddlFirmType.Enabled = true;
        ddlPartners.Enabled = true;
        ddlConcernDeals.Enabled = true;
        ddlCoreBusiness.Enabled = true;
        txtConcernAddress.Enabled = true;
        txtName.Enabled = true;
        txtFatherName.Enabled = true;
        txtEmail.Enabled = true;
        txtContact.Enabled = true;
        txtAdhaar.Enabled = true;
        txtVoterID.Enabled = true;
        txtPAN.Enabled = true;
        ddlServicesList.Enabled = true;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        utility = new Utility();

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
        generalInformation.servicetakenon = int.Parse(ddlServicesList.SelectedValue.ToString());

        // call the update method to update the records based on the user selection
        utility.UpdateGeneralInfoAndCredentials(generalInformation);

        divError.Visible = false;
        divSuccess.Visible = true;
        lblSuccess.InnerText = "Record Updated Successfully.";

    }
}

