using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // get the 5 digit salt
            string salt = CreateSalt(5);
            //Save the salt in session variable  
            Session["salt"] = salt.ToString();
            //Add the JS function call to button with a parameter
            btnLogin.Attributes.Add("onclick", "return HashPwdwithSalt('" + salt.ToString() + "');");

        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        User user = new User();
        user.userid = txtLoginUserId.Text.Trim();

        string userpassword = string.Empty;
        string userid = string.Empty;
        int roleid = 0;
        bool isactive;
        int userloginvalidity;
        string name = string.Empty;

        user.getPassword(user,
                         out roleid,
                         out userid,
                         out userpassword,
                         out isactive,
                         out userloginvalidity,
                         out name);

        //string saltedpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(userpassword.ToString().ToLower() + Session["salt"].ToString(), "md5");


        var algorithm = System.Security.Cryptography.HashAlgorithm.Create("MD5");
        byte[] hash = algorithm.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userpassword.ToString().ToLower() + Session["salt"].ToString()));

        // ToString("x2")  converts byte in hexadecimal value
        string saltedpassword = string.Concat(hash.Select(b => b.ToString("x2"))).ToUpperInvariant();
      

        if (!isactive)
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "Your account has not approved yet, kindly contact with the Administrator.";
            divSuccess.Visible = false;

            return;
        }

        if (userloginvalidity < 1)
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "Your login validity is expired, kindly contact with the Administrator.";
            divSuccess.Visible = false;

            return;
        }

        if (txtLoginPassword.Text.Trim().Equals(saltedpassword.ToLower()))
        {
            Session["User"] = userid;
            Session["Role"] = roleid;
            Session["Name"] = name;
            Session["Validity"] = userloginvalidity;
            Response.Redirect("~/Admin/Dashboard.aspx");
        }
        else
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.InnerText = "Username/Password is mismatched. Please try again.";
            divSuccess.Visible = false;
        }

    }

    private string CreateSalt(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
    }

    public string HashString(string inputString, string hashName)
    {
        var algorithm = HashAlgorithm.Create(hashName);
        if (algorithm == null)
            throw new ArgumentException("Unrecognized hash name", hashName);

        byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        return Convert.ToBase64String(hash);
    }

    //public string GetHash(this string stringToHash, string hashAlgorithm)
    //{
    //    var algorithm = System.Security.Cryptography.HashAlgorithm.Create(hashAlgorithm);
    //    byte[] hash = algorithm.ComputeHash(System.Text.Encoding.UTF8.GetBytes(stringToHash));

    //    // ToString("x2")  converts byte in hexadecimal value
    //    string encryptedVal = string.Concat(hash.Select(b => b.ToString("x2"))).ToUpperInvariant();
    //    return encryptedVal;
    //}
}