using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Dashboard : System.Web.UI.Page
{
    private int totalIncomplete = 0;
    private int totalComplete = 0;
    private DataTable dtTotalTasksHistory = null;
    Task task = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Role"] != null)
        {
            if (Session["Role"].ToString() == "1")
            {
                h1Welcome.InnerText = "Welcome, Suman Paul";
                spanValidity.InnerText = "Your Account is Activate for next : " + Session["Validity"].ToString() + " days";

                task = new Task();

                if (Session["User"] != null)
                {
                    dtTotalTasksHistory = new DataTable();
                    dtTotalTasksHistory = task.LoadTaskHistory(int.Parse(Session["Role"].ToString()), Session["User"].ToString()).Tables[0];

                    foreach (DataRow dr in dtTotalTasksHistory.Rows)
                    {
                        if (dr[7].ToString() == "Yes") // will check for column isverified if it's value Yes or No
                            totalComplete += 1;
                        else
                            totalIncomplete += 1;
                    }
                    spanTotalCompleted.InnerText = totalComplete.ToString();
                    spanTotalPending.InnerText = totalIncomplete.ToString();
                }
            }
            else if (Session["Role"].ToString() == "2")
            {
                h1Welcome.InnerText = "Welcome, " + Session["Name"].ToString();
                spanValidity.InnerText = "Your Account is Activate for next : " + Session["Validity"].ToString() + " days";
                task = new Task();

                if (Session["User"] != null)
                {
                    dtTotalTasksHistory = new DataTable();
                    dtTotalTasksHistory = task.LoadTaskHistory(int.Parse(Session["Role"].ToString()), Session["User"].ToString()).Tables[0];

                    foreach (DataRow dr in dtTotalTasksHistory.Rows)
                    {
                        if (dr[7].ToString() == "Yes") // will check for column isverified if it's value Yes or No
                            totalComplete += 1;
                        else
                            totalIncomplete += 1;
                    }
                    spanTotalCompleted.InnerText = totalComplete.ToString();
                    spanTotalPending.InnerText = totalIncomplete.ToString();
                }
            }
            else if (Session["Role"].ToString() == "3")
            {
                h1Welcome.InnerText = "Welcome, " + Session["Name"].ToString();
                spanValidity.InnerText = "Your Account is Activate for next : " + Session["Validity"].ToString() + " days";
                task = new Task();

                if (Session["User"] != null)
                {
                    dtTotalTasksHistory = new DataTable();
                    dtTotalTasksHistory = task.LoadTaskHistory(int.Parse(Session["Role"].ToString()), Session["User"].ToString()).Tables[0];

                    foreach (DataRow dr in dtTotalTasksHistory.Rows)
                    {
                        if (dr[7].ToString() == "Yes") // will check for column isverified if it's value Yes or No
                            totalComplete += 1;
                        else
                            totalIncomplete += 1;
                    }
                    spanTotalCompleted.InnerText = totalComplete.ToString();
                    spanTotalPending.InnerText = totalIncomplete.ToString();
                }
            }
        }
        else
        {
            h1Welcome.InnerText = "Welcome, Guest";
        }
    }
}
