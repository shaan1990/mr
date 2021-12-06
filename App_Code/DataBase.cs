using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataBase
/// </summary>
public class DataBase
{
    private string connectionString = string.Empty;
    public DataBase()
    {
        connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
    }


    public DataSet GetAllServices()
    {
        return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "select serviceid,servicename from  dbo.mtbl_services where isactive = 1");
    }

    public DataSet GetAllActiveCustomers()
    {
        return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "select serviceid,servicename from  dbo.mtbl_services where isactive = 1");
    }


    class Customer
    {
        public string customerid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public string adhaar { get; set; }
        public string pan { get; set; }


        public Customer(string customerid, string name, string email, string contact, string adhaar, string pan)
        {
            this.customerid = customerid;
            this.name = name;
            this.email = email;
            this.contact = contact;
            this.adhaar = adhaar;
            this.pan = pan;
        }
    }


    class Credentials
    {
        private string customerid { get; set; }
        private string password { get; set; }
    }


}