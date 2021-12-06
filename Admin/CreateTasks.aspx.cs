using MerchantMirrour;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CreateTasks : System.Web.UI.Page
{
    private Task task;
    private DataTable dataTable = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            // load employees in dropdown
            LoadAllEmployees();

            // Get request param from url and search details on param no.
            if (Request.QueryString["arn"] != null)
            {
                task = new Task();
                dataTable = task.GetARNDetailnOnARNumber(Request.QueryString["arn"].ToString()).Tables[0];
                txtARNno.Text = dataTable.Rows[0][1].ToString();
                txtCurrentDataTime.Text = dataTable.Rows[0][2].ToString();
                txtFileNumber.Text = dataTable.Rows[0][3].ToString();
                if (Convert.ToBoolean(dataTable.Rows[0][4].ToString()) == true)
                {
                    chkBillRequired.SelectedValue = "Yes";
                }
                txtQuery.Text = dataTable.Rows[0][5].ToString();
                // for action details
                // this section will set values only when the action has been taken already
                if (Convert.ToBoolean(dataTable.Rows[0][7].ToString()))
                {
                    txtActionTaken.Text = dataTable.Rows[0][6].ToString();
                    txtActionTakenBy.Text = dataTable.Rows[0][8].ToString();
                    txtActionTakenOn.Text = Convert.ToDateTime(dataTable.Rows[0][9].ToString()).ToString("yyyy-MM-dd");
                }
                if (Convert.ToBoolean(dataTable.Rows[0][12].ToString()) == true)
                {
                    chkBillRequired.SelectedValue = "Yes";
                }
                ddlPriority.SelectedIndex = Convert.ToInt16(dataTable.Rows[0][14].ToString());
                if (ddlPriority.SelectedIndex == 1)
                    spanUrgent.Visible = true;
                else if (ddlPriority.SelectedIndex == 2)
                    spanVeryUrgent.Visible = true;
                else
                    spanNormal.Visible = true;

                var item = ddlEmployee.Items.FindByValue(dataTable.Rows[0][15].ToString());
                if (item != null)
                    item.Selected = true;


                // action verification will be enabled based on role
                // for admin it will be enabled
                // for employee it will be disabled
                // for operator it will be disabled

                actionVerificationStatus(Convert.ToBoolean(dataTable.Rows[0][10].ToString()));

                if (Session["Role"].ToString() != "1") // disabled inputs if role is not Admin
                {
                    disabledInputsforOperator(int.Parse(Session["Role"].ToString()));
                }
                else
                {
                    btnTaskUpdate.Visible = true;
                    btnRegister.Visible = false;
                }

                // hide upadate button on 
            }
            else
            {
                task = new Task();
                txtARNno.Text = task.getARSerialNumber();
                txtCurrentDataTime.Text = DateTime.Now.ToString();

                spanNotVerified.Visible = true;
                verifyquestion.Visible = true;
                verifyquestion.InnerText = "Status of this action is unverified until Admin verification";
                radioIsVerified.Visible = false;
            }

            // disabled bill required when the bill prepared is selected No
            if (chkBillRequired.SelectedValue == "No")
            {
                chkBillPrepared.SelectedValue = "No";
                chkBillPrepared.Enabled = false;
            }


        }
    }

    protected void ddlPriority_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPriority.SelectedIndex == 1)
        {
            spanUrgent.Visible = true;
            spanVeryUrgent.Visible = false;
            spanNormal.Visible = false;
        }
        else if (ddlPriority.SelectedIndex == 2)
        {
            spanVeryUrgent.Visible = true;
            spanUrgent.Visible = false;
            spanNormal.Visible = false;
        }
        else if (ddlPriority.SelectedIndex == 3)
        {
            spanNormal.Visible = true;
            spanUrgent.Visible = false;
            spanVeryUrgent.Visible = false;
        }
        else
        {
            spanNormal.Visible = false;
            spanUrgent.Visible = false;
            spanVeryUrgent.Visible = false;
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        bool isbillrequired = false;
        bool isbillprepared = false;

        if (IsPostBack)
        {
            if (chkBillRequired.SelectedValue == "Yes")
                isbillrequired = true;
            if (chkBillPrepared.SelectedValue == "Yes")
                isbillprepared = true;
        }

        try
        {
            Task task = new Task(txtARNno.Text.Trim(), txtCurrentDataTime.Text, txtFileNumber.Text,
                isbillrequired, txtQuery.Text, txtActionTaken.Text, false, txtActionTakenBy.Text, txtActionTakenOn.Text, false, ""
                , isbillprepared, null, ddlPriority.SelectedValue, ddlEmployee.SelectedValue.Trim());


            Task openConnectioString = new Task();
            openConnectioString.CreateNewTasks(task);

            divSuccess.Visible = true;
            lblSuccess.InnerText = "ARN Details Saved Successfully.";
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


        // call method for resetting inputs
        ResetAllInputs();
    }

    public void LoadAllEmployees()
    {
        Role role = new Role();
        ddlEmployee.DataSource = role.getAllEmployees();
        ddlEmployee.DataTextField = "employeename";
        ddlEmployee.DataValueField = "userid";
        ddlEmployee.DataBind();
        ddlEmployee.Items.Insert(0, new ListItem("-- Select Employee --", "0"));
    }

    public void disabledInputsforOperator(int RoleId)
    {
        txtARNno.Enabled = false;
        txtFileNumber.Enabled = false;
        txtCurrentDataTime.Enabled = false;
        chkBillPrepared.Enabled = false;
        txtQuery.Enabled = false;
        chkBillRequired.Enabled = false;
        ddlPriority.Enabled = false;
        btnTaskUpdate.Visible = true;
        btnRegister.Visible = false;
        ddlEmployee.Enabled = false;

        // when action is taken for role 1
        //1/ disabled the text inputs
        //2/ visible true the radio verification

        RoleId = int.Parse(Session["Role"].ToString());

        if (RoleId == 1) // Administrator
        {
            if (Convert.ToBoolean(dataTable.Rows[0][7].ToString())) // if action is taken
            {
                txtActionTaken.Enabled = false;
                txtActionTakenBy.Enabled = false;
                txtActionTakenOn.Enabled = false;

                radioIsVerified.Visible = true;
            }
            else
            {
                // when the action has not taken yet
                radioIsVerified.Visible = false;
                verifyquestion.InnerText = "Once the action has been taken Administrator can verify this ARN.";
            }
        }
        else if (RoleId == 2) // Computer Operator
        {
            if (Convert.ToBoolean(dataTable.Rows[0][7].ToString())) // if action is taken
            {
                txtActionTaken.Enabled = false;
                txtActionTakenBy.Enabled = false;
                txtActionTakenOn.Enabled = false;

                radioIsVerified.Visible = false;
            }
            else
            {
                // when the action has not taken yet
                radioIsVerified.Visible = false;
                verifyquestion.InnerText = "Once the action has been taken Administrator can verify this ARN.";
            }
        }
        else  // Employee
        {
            if (Convert.ToBoolean(dataTable.Rows[0][7].ToString())) // if action is taken
            {
                txtActionTaken.Enabled = false;
                txtActionTakenBy.Enabled = false;
                txtActionTakenOn.Enabled = false;

                radioIsVerified.Visible = false;
            }
            else
            {
                // when the action has not taken yet
                radioIsVerified.Visible = false;
                verifyquestion.InnerText = "Once the action has been taken Administrator can verify this ARN.";
            }
        }

    }

    public void actionVerificationStatus(bool status)
    {
        if (status)
        {
            spanVerified.Visible = true;
            spanPending.Visible = false;
            verifyquestion.Visible = true;
            verifyquestion.InnerText = "Administrator has verified this action";
            radioIsVerified.Visible = false;
        }
        else
        {
            spanVerified.Visible = false;
            spanPending.Visible = true;
            radioIsVerified.Visible = true;
            radioIsVerified.Enabled = true;
            verifyinfo.Visible = true;
            verifyquestion.Visible = true;
        }

    }

    protected void btnTaskUpdate_Click(object sender, EventArgs e)
    {

        bool isbillrequired = false;
        bool isbillprepared = false;
        bool isactionverified = false;
        bool isactiontaken = false;
        bool isverified = false;


        if (chkBillRequired.SelectedValue == "Yes")
            isbillrequired = true;
        if (chkBillPrepared.SelectedValue == "Yes")
            isbillprepared = true;
        if (spanVerified.Visible == true)
            isactionverified = true;
        if (!string.IsNullOrEmpty(txtQuery.Text))
            isactiontaken = true;
        if (radioIsVerified.SelectedValue.Trim() == "Yes")
            isverified = true;

        #region Update Final ARN Status by Administrator
        Task taskCheckPresentActionStatus = new Task();
        if (taskCheckPresentActionStatus.IsActionTakenByEmployee(txtARNno.Text.Trim()))
        {
            Task updateVerificationStaus = new Task();

            try
            {
                updateVerificationStaus.UpdateVarification(isverified, txtARNno.Text.Trim());

                divSuccess.Visible = true;
                lblSuccess.InnerText = "ARN Verification Completed Successfully.";
                divError.Visible = false;
                lblError.Visible = false;

                return;
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                lblSuccess.Visible = false;
                divError.Visible = true;
                lblError.InnerText = ex.Message.ToString();
            }

        }
        #endregion
        else
        {
            #region Update Action Details by Computer Operator and Administrator
            try
            {
                Task task = new Task(txtARNno.Text, txtCurrentDataTime.Text, txtFileNumber.Text, isbillrequired, txtQuery.Text, txtActionTaken.Text, isactiontaken, txtActionTakenBy.Text, txtActionTakenOn.Text, isactionverified, Session["User"].ToString(), isbillprepared, "NA", ddlPriority.SelectedValue.ToString(), txtActionTakenBy.Text);
                Task taskUpdate = new Task();
                taskUpdate.UpdateTaskActionDetails(task);

                divSuccess.Visible = true;
                lblSuccess.InnerText = "Action Details Saved Successfully.";
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
            #endregion
        }
    }

    protected void chkBillRequired_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (chkBillRequired.SelectedValue == "No")
        {
            chkBillPrepared.SelectedIndex = 1;
            chkBillPrepared.Enabled = false;
        }
        else
        {
            chkBillPrepared.Enabled = true;
        }
    }

    public void ResetAllInputs()
    {
        txtARNno.Text = string.Empty;
        txtCurrentDataTime.Text = string.Empty;
        txtFileNumber.Text = string.Empty;

        ddlPriority.SelectedIndex = 0;
        ddlEmployee.SelectedIndex = 0;

        txtQuery.Text = string.Empty;
        txtActionTaken.Text = string.Empty;
        txtActionTakenBy.Text = string.Empty;
        txtActionTakenOn.Text = string.Empty;

        // for card verification
        spanNotVerified.Visible = true;
        verifyquestion.Visible = true;
        verifyquestion.InnerText = "Status of this action is unverified until Admin verification";
        radioIsVerified.Visible = false;
    }
}
