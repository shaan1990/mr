using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;

namespace MerchantMirrour
{
    public class Role
    {
        private string connectionString = string.Empty;
        public Role()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        }

        public DataSet getAllRoles()
        {
            string query = @"if exists(select roleid from mtbl_users where roleid=1)
                            begin
	                            select roleid,rolename from mtbl_role where roleid <> 1;
                            end
                            else
                            begin
	                            select roleid,rolename from mtbl_role;
                            end";
            return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, query);
        }

        public DataSet getAllEmployees()
        {
            return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "select userid, username +'[ '+ userid+' ]' as employeename from [dbo].[mtbl_users] where roleid=3");
        }

    }
}