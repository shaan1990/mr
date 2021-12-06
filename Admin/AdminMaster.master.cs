using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            int RoleId = int.Parse(Session["Role"].ToString());

            // rolewise menu access to the authorised user

            if (RoleId == 1) // for administrator
            {
                menucreatetask.Visible = true;
                menumanagetask.Visible = true;
                menuhistorytask.Visible = true;
                menunewregistration.Visible = true;
                menuyearlyreturn.Visible = true;

                menucreatedb.Visible = true;
                menumanagedb.Visible = true;

                spanLoginAs.InnerText = "Administrator";
            }
            else if (RoleId == 2) // for computer operator
            {
                menucreatetask.Visible = false;
                menumanagetask.Visible = false;
                menuhistorytask.Visible = true;

                menumanagedb.Visible = false;

                spanLoginAs.InnerText = "Computer Operator";
            }
            else if (RoleId == 4) // for computer operator
            {
                menucreatetask.Visible = false;
                menumanagetask.Visible = false;
                menuhistorytask.Visible = true;

                menumanagedb.Visible = false;

                spanLoginAs.InnerText = "Customer";
            }
            else // for employee
            {
                menucreatetask.Visible = false;
                menumanagetask.Visible = false;
                menuhistorytask.Visible = true;
                menuyearlyreturn.Visible = true;
                menunewregistration.Visible = true;

                menumanagedb.Visible = false;

                spanLoginAs.InnerText = "Employee";
            }
        }
    }
}

