using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["User"] != null && Session["Role"].ToString() == "1")
            {
                User objUser = new User();

                if (Request.QueryString["uid"] != null && Request.QueryString["activestats"] != null)
                {
                    string isactivestats = Request.QueryString["activestats"].ToString();
                    if (isactivestats == "Yes")
                        objUser.UpdateUserActiveStatus(false, Request.QueryString["uid"].ToString());
                    else
                        objUser.UpdateUserActiveStatus(true, Request.QueryString["uid"].ToString());

                    //reload the grid();
                    grvUsers.DataSource = objUser.LoadAllUsers();
                    grvUsers.DataBind();
                }
                else
                {
                    grvUsers.DataSource = objUser.LoadAllUsers();
                    grvUsers.DataBind();
                }

            }
            else
            {
                Response.Redirect("~/LoginPage.aspx");
            }

        }
    }
}