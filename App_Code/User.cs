using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    public string name { get; set; }
    public string contact { get; set; }
    public int roleid { get; set; }
    public string email { get; set; }
    public string userid { get; set; }
    public string password { get; set; }
    public DateTime dateofregistration { get; set; }

    private string connectionString = string.Empty;

    public User()
    {
        connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
    }

    public void newRegistration(User user, out bool UserStatus, out string userid)
    {
        SqlParameter paramName = new SqlParameter("@name", SqlDbType.VarChar);
        SqlParameter paramContact = new SqlParameter("@contact", SqlDbType.VarChar, 10);
        SqlParameter paramRoleID = new SqlParameter("@roleid", SqlDbType.Int, 2);
        SqlParameter paramEmail = new SqlParameter("@email", SqlDbType.VarChar);
        SqlParameter paramPassword = new SqlParameter("@password", SqlDbType.VarChar);
        SqlParameter paramDOR = new SqlParameter("@dateofregistration", SqlDbType.DateTime);
        SqlParameter paramIAE = new SqlParameter("@isalreadyexists", SqlDbType.Bit);
        SqlParameter paramUID = new SqlParameter("@userid", SqlDbType.VarChar, 10);

        paramName.Value = user.name;
        paramContact.Value = user.contact;
        paramRoleID.Value = user.roleid;
        paramEmail.Value = user.email;
        paramPassword.Value = user.password;
        paramDOR.Value = user.dateofregistration;

        paramIAE.Direction = ParameterDirection.Output;
        paramUID.Direction = ParameterDirection.Output;

        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_new_registration", paramName, paramContact, paramRoleID, paramEmail, paramPassword, paramDOR, paramIAE, paramUID);

        UserStatus = (bool)paramIAE.Value;
        userid = (string)paramUID.Value;
    }

    public void getPassword(User user, out int roleid, out string userid, out string password, out bool isactive, out int validityexist, out string name)
    {
        string query = string.Empty;


        query = @"select users.userid,users.roleid,users.password,users.isactive,datediff(day,getdate(),users.validupto) as validupto,registration.name 
                        from mtbl_users users
                        inner join [ttbl_registration] registration
                        on users.username = registration.email
                        where userid= @userid";



        SqlParameter paramUID = new SqlParameter("@userid", SqlDbType.VarChar, 50);

        paramUID.Value = user.userid;

        DataSet dsUserDetails = new DataSet();
        dsUserDetails = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, query, paramUID);

        // when user details is not found in registration and user table 
        // then it will search for the customer login into user and the general information table

        if (dsUserDetails.Tables[0].Rows.Count == 0)
        {
            query = @"select users.userid,users.roleid,users.password,users.isactive,datediff(day,getdate(),users.validupto) as validupto,generalinfo.customername as name 
                        from mtbl_users users
                        inner join [ttbl_general_information] generalinfo
                        on users.userid = generalinfo.customercode
                        where users.userid = @userid";

            dsUserDetails = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, query, paramUID);
        }


        // initialisign the output parameters
        userid = dsUserDetails.Tables[0].Rows[0][0].ToString();
        roleid = int.Parse(dsUserDetails.Tables[0].Rows[0][1].ToString());
        password = dsUserDetails.Tables[0].Rows[0][2].ToString();
        isactive = Convert.ToBoolean(dsUserDetails.Tables[0].Rows[0][3].ToString());
        validityexist = Convert.ToInt16(dsUserDetails.Tables[0].Rows[0][4].ToString());
        name = dsUserDetails.Tables[0].Rows[0][5].ToString();
    }

    public void ResetPassword(User user)
    {
        SqlParameter paramPassword = new SqlParameter("@password", SqlDbType.VarChar);
        SqlParameter paramValidUpto = new SqlParameter("@validupto", SqlDbType.DateTime);
        SqlParameter paramUeId = new SqlParameter("@userid", SqlDbType.VarChar);

        paramPassword.Value = user.password;
        paramValidUpto.Value = DateTime.Now.ToString();
        paramUeId.Value = user.userid;

        string query = "update [dbo].[mtbl_users] set password = @password , validupto = dateadd(month,3,@validupto) where userid=@userid";

        SqlHelper.ExecuteDataset(connectionString, CommandType.Text, query, paramPassword, paramValidUpto, paramUeId);
    }

    public DataSet LoadAllUsers()
    {
        string query = string.Empty;

        query = @"select registration.[name],roles.rolename, [user].userid,case when [user].isactive = 1 then 'Yes' else 'No' end as isactive, datediff(day,getdate(), [user].validupto) as validity
                        from [dbo].[mtbl_users] [user]
                        inner join [dbo].[ttbl_registration] registration on [user].username = registration.email
                        inner join [dbo].[mtbl_role] roles on roles.roleid = [user].roleid
                        ";

        return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, query);

    }

    public void UpdateUserActiveStatus(bool isactive, string userid)
    {
        string query = string.Empty;
        SqlParameter paramIsActive = new SqlParameter("@isactive", SqlDbType.Bit);
        SqlParameter paramContact = new SqlParameter("@userid", SqlDbType.VarChar);

        paramIsActive.Value = isactive;
        paramContact.Value = userid;

        query = @"update [dbo].[mtbl_users] set isactive = @isactive where userid=@userid";

        SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, query, paramIsActive, paramContact);

    }
}