using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ReturnInformationYearly : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadResults("C-99434345100521");
    }
    protected void btnSubmitInformation_Click(object sender, EventArgs e)
    {
        Utility utility = new Utility();
        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();

        serviceDetails.customerid = txtCustomerId.Text;
        serviceDetails.filenumber = txtFileName.Text;
        serviceDetails.gstin = txtGstin.Text;
        serviceDetails.financialyear = ddlFinancialYear.SelectedItem.Text;
        serviceDetails.type = int.Parse(ddlType.SelectedValue.ToString());
        serviceDetails.filedgstr94 = int.Parse(ddlFiledGstr9by4.SelectedValue.ToString());
        serviceDetails.filedgstr94on = Convert.ToDateTime(txtFiledGstr9by4On.Text);
        serviceDetails.filedgstr9c = int.Parse(ddlFiledGstr9c.SelectedValue.ToString());
        serviceDetails.filedgstr9con = Convert.ToDateTime(txtFiledGstr9cOn.Text);
        serviceDetails.notesongstr94 = txtNoteOnGstr9by4.Text;
        serviceDetails.documentfiledcheckby = txtDocFilledAndCheckedBy.Text;
        serviceDetails.verifiedby = txtVerifiedBy.Text;
        serviceDetails.enteredby = Session["User"].ToString();
        serviceDetails.dateofinsert = DateTime.Now;

        utility.InsertServiceGSTRYearly(serviceDetails);

        divSuccess.Visible = true;
        lblSuccess.InnerText = "Return Information Submitted Successfully.";
        divError.Visible = false;
        lblError.Visible = false;

        // load result into gridview
        LoadResults(txtCustomerId.Text);

        //clear all the input controls
        ResetInputs();

       
    }

    private void ResetInputs()
    {
        txtCustomerId.Text = string.Empty;
        txtFileName.Text = string.Empty;
        txtGstin.Text = string.Empty;
        ddlFinancialYear.SelectedItem.Text = string.Empty;
        ddlType.SelectedIndex = 0;
        ddlFiledGstr9by4.SelectedIndex = 0;
        txtFiledGstr9by4On.Text = string.Empty;
        ddlFiledGstr9c.SelectedIndex = 0;
        txtFiledGstr9cOn.Text = string.Empty;
        txtNoteOnGstr9by4.Text = string.Empty;
        txtDocFilledAndCheckedBy.Text = string.Empty;
        txtVerifiedBy.Text = string.Empty;
    }

    public void LoadResults(string customerid)
    {
        Utility utility = new Utility();
        Utility.ServiceDetails serviceDetails = new Utility.ServiceDetails();

        serviceDetails.customerid = customerid;

        grvShowRecords.DataSource = utility.LoadGstrYearlyResut(serviceDetails);
        grvShowRecords.DataBind();

        divgrvShowRecords.Visible = true;
        grvShowRecords.EmptyDataText = "No Record Exists";
    }

}