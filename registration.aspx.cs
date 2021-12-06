using MerchantMirrour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadRolesIntoDropDown();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        User user = new User();

        user.name = txtName.Text;
        user.contact = txtContact.Text;
        user.roleid = int.Parse(ddlRole.SelectedValue.ToString());
        user.email = txtEmail.Text;
        if (txtPassword.Text.Trim() == txtConfirmPassword.Text.Trim())
            user.password = txtConfirmPassword.Text.Trim();
        user.dateofregistration = DateTime.Now;

        bool newUserStats = false;
        string userid = string.Empty;
        user.newRegistration(user, out newUserStats, out userid);
        if (newUserStats == false)
        {
            // show modal popup when registration completed successfully.
            spanUserid.InnerText = "Your USER ID :" + userid;
            spanPassword.InnerText = "and Your Password is you given while registration";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#MyPopup').modal('show')", true);

            // resetting all input controls after registration.
            resetAllInputs();
        }
        else
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "Record with " + txtEmail.Text + " is already exist.";
            divSuccess.Visible = false;
        }

    }
    public void LoadRolesIntoDropDown()
    {
        Role objRole = new Role();
        ddlRole.DataSource = objRole.getAllRoles();
        ddlRole.DataTextField = "rolename";
        ddlRole.DataValueField = "roleid";
        ddlRole.DataBind();
        ddlRole.Items.Insert(0, new ListItem("-- Select Role --", "0"));
    }
    private string CreateSalt(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
    }

    public void resetAllInputs()
    {
        txtName.Text = string.Empty;
        txtContact.Text = string.Empty;
        txtEmail.Text = string.Empty;
        ddlRole.SelectedIndex = 0;
    }
}

