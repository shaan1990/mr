using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TaskHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Task task = new Task();
            if (Session["User"] != null)
            {
                grvTasks.DataSource = task.LoadTaskHistory(int.Parse(Session["Role"].ToString()), Session["User"].ToString());
                grvTasks.DataBind();
            }
        }
    }
}