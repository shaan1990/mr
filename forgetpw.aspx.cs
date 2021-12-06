using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forgetpw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "1")
            { }
            else { Response.Redirect("~/LoginPage.aspx"); }
        }

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
        txtPassword.Value = otp;

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {

        User user = new User();
        user.userid = txtUserId.Value;
        user.password = txtPassword.Value;
        try
        { // call reset password method
            user.ResetPassword(user);

            txtUserId.Value = string.Empty;
            txtPassword.Value = string.Empty;

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