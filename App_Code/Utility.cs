using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GeneralInformation
/// </summary>
public class Utility
{
    private string connectionString = string.Empty;
    public Utility()
    {
        connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

    }

    public enum Services
    {
        RBR,
        GST,
        ITR,
        ACS,
        PTX,
        DSC,
        EPF
    }

    // entity classes

    public class Customer
    {
        public string customerid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public string adhaar { get; set; }
        public string pan { get; set; }
        //constructor
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
    //public class Credentials
    //{
    //    public string customerid { get; set; }
    //    public string password { get; set; }
    //    //constructor
    //    public Credentials(string customerid, string password)
    //    {
    //        this.customerid = customerid;
    //        this.password = password;
    //    }
    //}

    public class GeneralInformation
    {
        // getteres and setters
        public string filenumber { get; set; }
        public string customercode { get; set; }
        public string concernname { get; set; }
        public int typesoffirm { get; set; }
        public int noofdirectors { get; set; }
        public int concerndealswith { get; set; }
        public int corebusiness { get; set; }
        public string concernaddress { get; set; }
        public string customername { get; set; }
        public string fathersname { get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public string adhaar { get; set; }
        public string voterid { get; set; }
        public string pannumber { get; set; }
        public int servicetakenon { get; set; }
    }
    public class CustomerCredentials
    {
        public string CustomerID { get; set; }
        public string CustomerPassword { get; set; }
    }
    public class ServiceDetails
    {
        // common fields
        public int serviceid { get; set; }
        public DateTime? acknowledgeupdateon { get; set; }

        //PTAX
        public string customerid { get; set; }
        public string filenumber { get; set; }
        public string applicantname { get; set; }
        public string establishmentname { get; set; }
        public string establishmentaddress { get; set; }
        public int district { get; set; }
        public string pin { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string areaofjurisdiction { get; set; }
        public string charge { get; set; }
        public int engagedwith { get; set; }
        public int category { get; set; }
        public int subcategory { get; set; }
        public DateTime dateofcommencement { get; set; }

        public string gstin { get; set; }
        public int vehiclecategory { get; set; }
        public int levelofsociety { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string enrolmentnumber { get; set; }
        public string applicationnumber { get; set; }
        public string taxperiod { get; set; }
        public DateTime paymentdate { get; set; }
        public decimal amount { get; set; }
        public string paymentreqnumber { get; set; }
        public string grn { get; set; }
        public string cin { get; set; }
        public string transactionstatus { get; set; }
        public string enteredby { get; set; }
        public DateTime dateofinsert { get; set; }
        public int gender { get; set; }
        public string tan { get; set; }
        public decimal annualgrossbusiness { get; set; }
        public decimal annualturnover { get; set; }
        public int monthlyaverageworker { get; set; }
        public int monthlyaverageemployee { get; set; }
        public string gst { get; set; }
        public string cst { get; set; }
        public string vat { get; set; }


        //ITAX
        public int applyingas { get; set; }
        public string pan { get; set; }
        public string address { get; set; }
        public string arealocality { get; set; }
        public string postoffice { get; set; }
        public int state { get; set; }
        public int country { get; set; }
        public string transactionid { get; set; }
        public string financialyear { get; set; }
        public string assessmentyear { get; set; }
        public int returntype { get; set; }
        public bool downloadform26 { get; set; }
        public string returnform { get; set; }
        public string taxpayment { get; set; }
        public string brscode { get; set; }
        public string returnfilldate { get; set; }
        public string itracknowledgement { get; set; }
        public DateTime dob { get; set; }
        public int residentialstatus { get; set; }

        // RUBBER
        public int applydealerlicence { get; set; }
        public string tradername { get; set; }
        public string businessplace { get; set; }
        public string buisnessbuildingtype { get; set; }
        public string businessbuildingplotno { get; set; }
        public string businesscity { get; set; }
        public string storageplace { get; set; }
        public string storagebuildingtype { get; set; }
        public string storagebuildingplotno { get; set; }
        public string storagecity { get; set; }
        public int storagedistrict { get; set; }
        public int storagestate { get; set; }
        public string storagepin { get; set; }
        public string storagemobile { get; set; }
        public string storageemail { get; set; }
        public string ownershiptype { get; set; }
        public string ownershipname { get; set; }
        public string presemtpermanentaddress { get; set; }
        public string ppacity { get; set; } //[ PPA :PRESENT AND PERMANENT ]
        public int ppadistrict { get; set; }
        public int ppastate { get; set; }
        public string ppapin { get; set; }
        public string ppamobile { get; set; }
        public string ppaemail { get; set; }
        public string ppapan { get; set; }
        public decimal ppainvestedcapital { get; set; }
        public string fathername { get; set; }
        public string dealershipnumber { get; set; }
        public DateTime licencevalidtill { get; set; }
        public string concernname { get; set; }
        public string ammendment { get; set; }
        public string returnH2 { get; set; }
        public string returnL { get; set; }
        // DSC

        public string adhaar { get; set; }
        public bool isadhaarlinkedwithmobile { get; set; }
        public string linkedmobilewithadhaar { get; set; }

        public string sharecode { get; set; }
        public string chalangecode { get; set; }
        public string etokenpassword { get; set; }
        public DateTime dscvalidupto { get; set; }

        // GST
        public string legalbusinessname { get; set; }
        public int constitutionofbusiness { get; set; }
        public int iscasualtaxable { get; set; }
        public int compositionoption { get; set; }
        public int resonregistration { get; set; }
        public DateTime dateofliabilityregister { get; set; }
        public string authorisedsignatory { get; set; }
        public string residentialaddress { get; set; }
        public string detailsauthorisedsignatory { get; set; }
        public string nameofauthorisedsignatory { get; set; }
        public string trn { get; set; }
        public int isauthorisedrepresentative { get; set; }
        public string principalplace { get; set; }
        public int statejurisdiction { get; set; }
        public string SCWC { get; set; }
        public string commisionerate { get; set; }
        public int division { get; set; }
        public int range { get; set; }
        public int natureofpossession { get; set; }
        public string proofofprincipleplace { get; set; }
        public int natureofbusiness { get; set; }
        public string businessadditionalplace { get; set; }
        public string detailsofgoodssupplied { get; set; }
        public string ptaxcertificateno { get; set; }
        public string ptaxemployeecode { get; set; }
        public DateTime dateofcommencement_gst { get; set; }
        public int designation { get; set; }
        public int noofdirectors { get; set; }
        public int concerndealswith { get; set; }

        // GST RETURN
        public int year { get; set; }
        public int month { get; set; }
        public string filename { get; set; }
        public int challanmadeon { get; set; }
        public int gstinassign { get; set; }
        public string ewaybillusername { get; set; }
        public string ewaybillpassword { get; set; }
        public string compliances { get; set; }
        public string actiontaken { get; set; }
        public string documentfiledcheckby { get; set; }

        public int salesstatement { get; set; }
        public int purchasestatement { get; set; }
        public int checkewaybilldetails { get; set; }
        public int filedgstriiff { get; set; }

        public int checkgstr2a2b { get; set; }
        public int checktaxliabilities { get; set; }
        public int checktdstcs { get; set; }
        public int recordgstreconciliation { get; set; }
        public int filedgstr3bpmt8 { get; set; }
        public int fileddrc8regarding { get; set; }
        public int checkcashcreditleder { get; set; }
        public string verifiedby { get; set; }
        public int returntypegstr1 { get; set; }
        public int returntypegstr3b { get; set; }
        public int registrationtype { get; set; }
        public int slno { get; set; }

        public DateTime receivedon { get; set; }
        public DateTime filedgstriiffon { get; set; }
        public DateTime filedonreconciliation { get; set; }
        public DateTime fileddrc8regardingon { get; set; }
        public DateTime dateofregistration { get; set; }

        // GST RETURN YEARLY
        public int type { get; set; }
        public int filedgstr94 { get; set; }
        public DateTime filedgstr94on { get; set; }
        public int filedgstr9c { get; set; }
        public DateTime filedgstr9con { get; set; }
        public string notesongstr94 { get; set; }
        public string documentfilledcheckby { get; set; }



        // ACCOUNTS
        public int bookkeepingmadeon { get; set; }
        public string tallydatanumber { get; set; }
        public int tallyexcelreceived { get; set; }
        public int openinngstockstatement { get; set; }
        public int purchasebillstatement { get; set; }
        public int salesbillstatement { get; set; }
        public int cashbook { get; set; }
        public int creditnote { get; set; }
        public int debitnote { get; set; }
        public int bankstatement { get; set; }
        public int cashbooks { get; set; }
        public int loanstatements { get; set; }
        public int receiptpaymentstatement { get; set; }
        public int profitlossaccounts { get; set; }
        public int balancesheet { get; set; }
        public int sundrycreditorslist { get; set; }
        public int salesstatements { get; set; }
        public int sundrydebtorlist { get; set; }
        public int banksatements_rpt { get; set; }
        public int brs { get; set; }
        public int cashbook_rpt { get; set; }
        public int closingstockstatement { get; set; }
        public int receiptpaymentstatement_rpt { get; set; }
        public string observation { get; set; }



    }

    // all datasets

    public DataSet GetAllServices()
    {
        return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "select serviceid,servicename from  dbo.mtbl_services where isactive = 1");
    }
    public DataSet GetAllCoreBusiness()
    {
        return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "select [corebusinessid],[corebusinessname] from [dbo].[mtbl_core_business] where isactive = 1");
    }
    public DataSet GetAllActiveCustomers()
    {
        return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "select serviceid,servicename from  dbo.mtbl_services where isactive = 1");
    }
    public DataSet CreateDataSetForNumberOfDirectors()
    {

        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[2] {
                            new DataColumn("sl", typeof(int)),
                            new DataColumn("noofperson", typeof(string))
                });

        for (int i = 1; i < 16; i++)
        {
            dt.Rows.Add(i, i + " Persons");
        }
        DataSet ds = new DataSet();
        ds.Tables.Add(dt);
        return ds;

    }
    public DataSet GetAllActiveFirms()
    {
        return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "select [firm_id],[firm_name] from [dbo].[mtbl_firms] where isactive = 1");
    }


    // saving customer general information and credentials
    public void InsertGeneralInfoAndCredentials(GeneralInformation generalInformation, CustomerCredentials credentials)
    {
        try
        {
            SqlParameter paramfilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter paramcustomercode = new SqlParameter("@customercode", typeof(string));
            SqlParameter paramconcernname = new SqlParameter("@concernname", typeof(string));
            SqlParameter paramtypesoffirm = new SqlParameter("@typesoffirm", typeof(int));
            SqlParameter paramnoofdirectiors = new SqlParameter("@noofdirectors", typeof(int));
            SqlParameter paramconcerndealswith = new SqlParameter("@concerndealswith", typeof(string));
            SqlParameter paramcorebusiness = new SqlParameter("@corebusinesson", typeof(int));
            SqlParameter paramconcernaddress = new SqlParameter("@concernaddress", typeof(string));
            SqlParameter paramcustomername = new SqlParameter("@customername", typeof(string));
            SqlParameter paramfathersname = new SqlParameter("@fathersname", typeof(string));

            SqlParameter paramemail = new SqlParameter("@email", typeof(string));
            SqlParameter paramcontact = new SqlParameter("@contact", typeof(string));
            SqlParameter paramadhaar = new SqlParameter("@adhaar", typeof(string));
            SqlParameter paramvoterid = new SqlParameter("@voterid", typeof(string));
            SqlParameter parampannumber = new SqlParameter("@pannumber", typeof(string));
            SqlParameter paramservicetakenon = new SqlParameter("@servicetakenon", typeof(int));
            SqlParameter parampassword = new SqlParameter("@password", typeof(string));


            paramfilenumber.Value = generalInformation.filenumber;
            paramcustomercode.Value = generalInformation.customercode;
            paramconcernname.Value = generalInformation.concernname;
            paramtypesoffirm.Value = generalInformation.typesoffirm;
            paramnoofdirectiors.Value = generalInformation.noofdirectors;
            paramconcerndealswith.Value = generalInformation.concerndealswith;
            paramcorebusiness.Value = generalInformation.corebusiness;
            paramconcernaddress.Value = generalInformation.concernaddress;
            paramcustomername.Value = generalInformation.customername;
            paramfathersname.Value = generalInformation.fathersname;
            paramemail.Value = generalInformation.email;
            paramcontact.Value = generalInformation.contact;
            paramadhaar.Value = generalInformation.adhaar;
            paramvoterid.Value = generalInformation.voterid;
            parampannumber.Value = generalInformation.pannumber;
            paramservicetakenon.Value = generalInformation.servicetakenon;
            parampassword.Value = credentials.CustomerPassword;

            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_insert_general_information",
                paramfilenumber, paramcustomercode, paramconcernname, paramtypesoffirm, paramnoofdirectiors, paramconcerndealswith,
                paramcorebusiness, paramconcernaddress, paramcustomername, paramfathersname, paramemail, paramcontact, paramadhaar, paramvoterid,
                parampannumber, paramservicetakenon, parampassword);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }

    }
    public void UpdateGeneralInfoAndCredentials(GeneralInformation generalInformation)
    {
        try
        {
            SqlParameter paramfilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter paramcustomercode = new SqlParameter("@customercode", typeof(string));
            SqlParameter paramconcernname = new SqlParameter("@concernname", typeof(string));
            SqlParameter paramtypesoffirm = new SqlParameter("@typesoffirm", typeof(int));
            SqlParameter paramnoofdirectiors = new SqlParameter("@noofdirectors", typeof(int));
            SqlParameter paramconcerndealswith = new SqlParameter("@concerndealswith", typeof(int));
            SqlParameter paramcorebusiness = new SqlParameter("@corebusinesson", typeof(int));
            SqlParameter paramconcernaddress = new SqlParameter("@concernaddress", typeof(string));
            SqlParameter paramfathersname = new SqlParameter("@fathersname", typeof(string));
            SqlParameter paramcustomername = new SqlParameter("@customername", typeof(string));
            SqlParameter paramemail = new SqlParameter("@email", typeof(string));
            SqlParameter paramcontact = new SqlParameter("@contact", typeof(string));
            SqlParameter paramadhaar = new SqlParameter("@adhaar", typeof(string));
            SqlParameter paramvoterid = new SqlParameter("@voterid", typeof(string));
            SqlParameter parampannumber = new SqlParameter("@pannumber", typeof(string));
            SqlParameter paramservicetakenon = new SqlParameter("@servicetakenon", typeof(int));



            paramfilenumber.Value = generalInformation.filenumber;
            paramcustomercode.Value = generalInformation.customercode;
            paramconcernname.Value = generalInformation.concernname;
            paramtypesoffirm.Value = generalInformation.typesoffirm;
            paramnoofdirectiors.Value = generalInformation.noofdirectors;
            paramconcerndealswith.Value = generalInformation.concerndealswith;
            paramcorebusiness.Value = generalInformation.corebusiness;
            paramconcernaddress.Value = generalInformation.concernaddress;
            paramfathersname.Value = generalInformation.fathersname;
            paramcustomername.Value = generalInformation.customername;
            paramemail.Value = generalInformation.email;
            paramcontact.Value = generalInformation.contact;
            paramadhaar.Value = generalInformation.adhaar;
            paramvoterid.Value = generalInformation.voterid;
            parampannumber.Value = generalInformation.pannumber;
            paramservicetakenon.Value = generalInformation.servicetakenon;

            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_update_general_information",
                paramfilenumber, paramcustomercode, paramconcernname, paramtypesoffirm, paramnoofdirectiors, paramconcerndealswith,
                paramcorebusiness, paramconcernaddress, paramfathersname, paramcustomername, paramemail, paramcontact, paramadhaar, paramvoterid,
                parampannumber, paramservicetakenon);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }

    }
    public void InsertRubberServiceDetails(ServiceDetails serviceDetails)
    {
        try
        {

            SqlParameter paramcustomercode = new SqlParameter("@customerid", typeof(string));
            SqlParameter paramfilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter paramdealershipno = new SqlParameter("@dealershipno", typeof(string));
            SqlParameter paramlicencevalidtill = new SqlParameter("@licencevalidtill", typeof(DateTime));
            SqlParameter paramnconcernname = new SqlParameter("@concernname", typeof(string));
            SqlParameter paramownername = new SqlParameter("@ownername", typeof(string));
            SqlParameter parammobile = new SqlParameter("@mobile", typeof(string));
            SqlParameter paramemail = new SqlParameter("@email", typeof(string));
            SqlParameter parambusinessstorageplace = new SqlParameter("@businessstorageplace", typeof(string));
            SqlParameter parambuildingtype_bsp = new SqlParameter("@buildingtype_bsp", typeof(string));
            SqlParameter parambuildingplotno_bsp = new SqlParameter("@buildingplotno_bsp", typeof(string));
            SqlParameter paramcity_bsp = new SqlParameter("@city_bsp", typeof(string));
            SqlParameter paramdistrict_bsp = new SqlParameter("@district_bsp", typeof(int));
            SqlParameter paramstate_bsp = new SqlParameter("@state_bsp", typeof(int));
            SqlParameter parampin_bsp = new SqlParameter("@pin_bsp", typeof(string));
            SqlParameter parammobile_bsp = new SqlParameter("@mobile_bsp", typeof(string));
            SqlParameter paramemail_bsp = new SqlParameter("@email_bsp", typeof(string));
            SqlParameter paramaddress_ppa = new SqlParameter("@address_ppa", typeof(string));
            SqlParameter paramcity_ppa = new SqlParameter("@city_ppa", typeof(string));
            SqlParameter paramdistrict_ppa = new SqlParameter("@district_ppa", typeof(int));
            SqlParameter paramstate_ppa = new SqlParameter("@state_ppa", typeof(int));
            SqlParameter parampin_ppa = new SqlParameter("@pin_ppa", typeof(string));
            SqlParameter paramusername = new SqlParameter("@username", typeof(string));
            SqlParameter parampassword = new SqlParameter("@password", typeof(string));
            SqlParameter paramammendmenton = new SqlParameter("@ammendmenton", typeof(string));
            SqlParameter paramapplicationnumber = new SqlParameter("@applicationnumber", typeof(string));
            SqlParameter paramdate = new SqlParameter("@date", typeof(DateTime));
            SqlParameter paramfinancialyear = new SqlParameter("@financialyear", typeof(string));
            SqlParameter paramreturnh2 = new SqlParameter("@returnh2", typeof(int));
            SqlParameter paramreturnl = new SqlParameter("@returnl", typeof(int));
            SqlParameter paramenteredby = new SqlParameter("@enteredby", typeof(string));
            SqlParameter paramdateofentry = new SqlParameter("@dateofentry", typeof(DateTime));

            paramcustomercode.Value = serviceDetails.customerid;
            paramfilenumber.Value = serviceDetails.filenumber;
            paramdealershipno.Value = serviceDetails.dealershipnumber;
            paramlicencevalidtill.Value = serviceDetails.licencevalidtill;
            paramnconcernname.Value = serviceDetails.concernname;
            paramownername.Value = serviceDetails.ownershipname;
            parammobile.Value = serviceDetails.mobile;
            paramemail.Value = serviceDetails.email;
            parambusinessstorageplace.Value = serviceDetails.businessplace;
            parambuildingtype_bsp.Value = serviceDetails.buisnessbuildingtype;
            parambuildingplotno_bsp.Value = serviceDetails.businessbuildingplotno;
            paramcity_bsp.Value = serviceDetails.storagecity;
            paramdistrict_bsp.Value = serviceDetails.storagedistrict;
            paramstate_bsp.Value = serviceDetails.storagestate;
            parampin_bsp.Value = serviceDetails.storagepin;
            parammobile_bsp.Value = serviceDetails.storagemobile;
            paramemail_bsp.Value = serviceDetails.storageemail;
            paramaddress_ppa.Value = serviceDetails.presemtpermanentaddress;
            paramcity_ppa.Value = serviceDetails.ppacity;
            paramdistrict_ppa.Value = serviceDetails.ppadistrict;
            paramstate_ppa.Value = serviceDetails.ppastate;
            parampin_ppa.Value = serviceDetails.ppapin;
            paramusername.Value = serviceDetails.username;
            parampassword.Value = serviceDetails.password;
            paramammendmenton.Value = serviceDetails.ammendment;
            paramapplicationnumber.Value = serviceDetails.applicationnumber;
            paramdate.Value = serviceDetails.dateofinsert;
            paramfinancialyear.Value = serviceDetails.financialyear;
            paramreturnh2.Value = serviceDetails.returnH2;
            paramreturnl.Value = serviceDetails.returnL;
            paramenteredby.Value = serviceDetails.enteredby;
            paramdateofentry.Value = serviceDetails.dateofinsert;

            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_insert_service_rubber",
                paramfilenumber, paramcustomercode, paramdealershipno, paramlicencevalidtill, paramnconcernname,
                paramownername, parammobile, paramemail, parambusinessstorageplace, parambuildingtype_bsp, parambuildingplotno_bsp, paramcity_bsp, paramdistrict_bsp,
                paramstate_bsp, parampin_bsp, parammobile_bsp, paramemail_bsp, paramaddress_ppa, paramcity_ppa, paramdistrict_ppa, paramstate_ppa, parampin_ppa,
                paramusername, parampassword, paramammendmenton, paramapplicationnumber, paramdate, paramfinancialyear, paramreturnh2, paramreturnl, paramenteredby, paramdateofentry);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    public void UpdateRubberServiceDetails(ServiceDetails serviceDetails)
    {
        try
        {

            SqlParameter paramcustomercode = new SqlParameter("@customerid", typeof(string));
            SqlParameter paramfilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter paramdealershipno = new SqlParameter("@dealershipno", typeof(string));
            SqlParameter paramlicencevalidtill = new SqlParameter("@licencevalidtill", typeof(DateTime));
            SqlParameter paramnconcernname = new SqlParameter("@concernname", typeof(string));
            SqlParameter paramownername = new SqlParameter("@ownername", typeof(string));
            SqlParameter parammobile = new SqlParameter("@mobile", typeof(string));
            SqlParameter paramemail = new SqlParameter("@email", typeof(string));
            SqlParameter parambusinessstorageplace = new SqlParameter("@businessstorageplace", typeof(string));
            SqlParameter parambuildingtype_bsp = new SqlParameter("@buildingtype_bsp", typeof(string));
            SqlParameter parambuildingplotno_bsp = new SqlParameter("@buildingplotno_bsp", typeof(string));
            SqlParameter paramcity_bsp = new SqlParameter("@city_bsp", typeof(string));
            SqlParameter paramdistrict_bsp = new SqlParameter("@district_bsp", typeof(int));
            SqlParameter paramstate_bsp = new SqlParameter("@state_bsp", typeof(int));
            SqlParameter parampin_bsp = new SqlParameter("@pin_bsp", typeof(string));
            SqlParameter parammobile_bsp = new SqlParameter("@mobile_bsp", typeof(string));
            SqlParameter paramemail_bsp = new SqlParameter("@email_bsp", typeof(string));
            SqlParameter paramaddress_ppa = new SqlParameter("@address_ppa", typeof(string));
            SqlParameter paramcity_ppa = new SqlParameter("@city_ppa", typeof(string));
            SqlParameter paramdistrict_ppa = new SqlParameter("@district_ppa", typeof(int));
            SqlParameter paramstate_ppa = new SqlParameter("@state_ppa", typeof(int));
            SqlParameter parampin_ppa = new SqlParameter("@pin_ppa", typeof(string));
            SqlParameter paramusername = new SqlParameter("@username", typeof(string));
            SqlParameter parampassword = new SqlParameter("@password", typeof(string));
            SqlParameter paramammendmenton = new SqlParameter("@ammendmenton", typeof(string));
            SqlParameter paramapplicationnumber = new SqlParameter("@applicationnumber", typeof(string));
            SqlParameter paramdate = new SqlParameter("@date", typeof(DateTime));
            SqlParameter paramfinancialyear = new SqlParameter("@financialyear", typeof(string));
            SqlParameter paramreturnh2 = new SqlParameter("@returnh2", typeof(int));
            SqlParameter paramreturnl = new SqlParameter("@returnl", typeof(int));
            SqlParameter paramenteredby = new SqlParameter("@enteredby", typeof(string));
            SqlParameter paramdateofentry = new SqlParameter("@dateofentry", typeof(DateTime));

            paramcustomercode.Value = serviceDetails.customerid;
            paramfilenumber.Value = serviceDetails.filenumber;
            paramdealershipno.Value = serviceDetails.dealershipnumber;
            paramlicencevalidtill.Value = serviceDetails.licencevalidtill;
            paramnconcernname.Value = serviceDetails.concernname;
            paramownername.Value = serviceDetails.ownershipname;
            parammobile.Value = serviceDetails.mobile;
            paramemail.Value = serviceDetails.email;
            parambusinessstorageplace.Value = serviceDetails.businessplace;
            parambuildingtype_bsp.Value = serviceDetails.buisnessbuildingtype;
            parambuildingplotno_bsp.Value = serviceDetails.businessbuildingplotno;
            paramcity_bsp.Value = serviceDetails.storagecity;
            paramdistrict_bsp.Value = serviceDetails.storagedistrict;
            paramstate_bsp.Value = serviceDetails.storagestate;
            parampin_bsp.Value = serviceDetails.storagepin;
            parammobile_bsp.Value = serviceDetails.storagemobile;
            paramemail_bsp.Value = serviceDetails.storageemail;
            paramaddress_ppa.Value = serviceDetails.presemtpermanentaddress;
            paramcity_ppa.Value = serviceDetails.ppacity;
            paramdistrict_ppa.Value = serviceDetails.ppadistrict;
            paramstate_ppa.Value = serviceDetails.ppastate;
            parampin_ppa.Value = serviceDetails.ppapin;
            paramusername.Value = serviceDetails.username;
            parampassword.Value = serviceDetails.password;
            paramammendmenton.Value = serviceDetails.ammendment;
            paramapplicationnumber.Value = serviceDetails.applicationnumber;
            paramdate.Value = serviceDetails.dateofinsert;
            paramfinancialyear.Value = serviceDetails.financialyear;
            paramreturnh2.Value = serviceDetails.returnH2;
            paramreturnl.Value = serviceDetails.returnL;
            paramenteredby.Value = serviceDetails.enteredby;
            paramdateofentry.Value = serviceDetails.dateofinsert;

            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_update_service_rubber",
                paramfilenumber, paramcustomercode, paramdealershipno, paramlicencevalidtill, paramnconcernname,
                paramownername, parammobile, paramemail, parambusinessstorageplace, parambuildingtype_bsp, parambuildingplotno_bsp, paramcity_bsp, paramdistrict_bsp,
                paramstate_bsp, parampin_bsp, parammobile_bsp, paramemail_bsp, paramaddress_ppa, paramcity_ppa, paramdistrict_ppa, paramstate_ppa, parampin_ppa,
                paramusername, parampassword, paramammendmenton, paramapplicationnumber, paramdate, paramfinancialyear, paramreturnh2, paramreturnl, paramenteredby, paramdateofentry);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    public void InsertDSCServiceDetails(ServiceDetails serviceDetails)
    {
        try
        {

            SqlParameter paramcustomercode = new SqlParameter("@customerid", typeof(string));
            SqlParameter paramfilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter paramapplicantname = new SqlParameter("@applicantname", typeof(string));
            SqlParameter paramestablishmentname = new SqlParameter("@establishmentname", typeof(DateTime));
            SqlParameter paramdob = new SqlParameter("@dob", typeof(string));
            SqlParameter parammobile = new SqlParameter("@mobile", typeof(string));
            SqlParameter paramemail = new SqlParameter("@email", typeof(string));
            SqlParameter paramaddress = new SqlParameter("@address", typeof(string));
            SqlParameter paramdistrict = new SqlParameter("@district", typeof(string));
            SqlParameter parampincode = new SqlParameter("@pincode", typeof(string));
            SqlParameter paramsharecode = new SqlParameter("@sharecode", typeof(string));
            SqlParameter paramchalangecode = new SqlParameter("@chalangecode", typeof(string));
            SqlParameter paramdesireusername = new SqlParameter("@desireusername", typeof(int));
            SqlParameter paramdesirepassword = new SqlParameter("@desirepassword", typeof(int));
            SqlParameter paramapplicationnumber = new SqlParameter("@applicationnumber", typeof(string));
            SqlParameter paramdated = new SqlParameter("@dated", typeof(string));
            SqlParameter parametokenpassword = new SqlParameter("@etokenpassword", typeof(string));
            SqlParameter paramadscvalidupto = new SqlParameter("@dscvalidupto", typeof(string));
            SqlParameter paramenteredby = new SqlParameter("@enteredby", typeof(string));
            SqlParameter paramdateofentry = new SqlParameter("@dateofentry", typeof(int));


            paramcustomercode.Value = serviceDetails.customerid;
            paramfilenumber.Value = serviceDetails.filenumber;
            paramapplicantname.Value = serviceDetails.applicantname;
            paramestablishmentname.Value = serviceDetails.establishmentname;
            paramdob.Value = serviceDetails.dob;
            parammobile.Value = serviceDetails.mobile;
            paramemail.Value = serviceDetails.email;
            paramaddress.Value = serviceDetails.address;
            paramdistrict.Value = serviceDetails.district;
            parampincode.Value = serviceDetails.pin;
            paramsharecode.Value = serviceDetails.sharecode;
            paramchalangecode.Value = serviceDetails.chalangecode;
            paramdesireusername.Value = serviceDetails.username;
            paramdesirepassword.Value = serviceDetails.password;
            paramapplicationnumber.Value = serviceDetails.applicationnumber;
            paramdated.Value = serviceDetails.dateofinsert;
            parametokenpassword.Value = serviceDetails.etokenpassword;
            paramadscvalidupto.Value = serviceDetails.dscvalidupto;
            paramenteredby.Value = serviceDetails.enteredby;
            paramdateofentry.Value = serviceDetails.dateofinsert;



            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_insert_service_dsc",
                paramfilenumber, paramcustomercode, paramapplicantname, paramestablishmentname, paramdob,
                parammobile, paramemail, paramaddress, paramdistrict, parampincode, paramsharecode, paramchalangecode, paramdesireusername,
                paramdesirepassword, paramapplicationnumber, paramdated, parametokenpassword, paramadscvalidupto, paramenteredby, paramdateofentry);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    public void UpdateDSCServiceDetails(ServiceDetails serviceDetails)
    {
        try
        {

            SqlParameter paramcustomercode = new SqlParameter("@customerid", typeof(string));
            SqlParameter paramfilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter paramapplicantname = new SqlParameter("@applicantname", typeof(string));
            SqlParameter paramestablishmentname = new SqlParameter("@establishmentname", typeof(DateTime));
            SqlParameter paramdob = new SqlParameter("@dob", typeof(string));
            SqlParameter parammobile = new SqlParameter("@mobile", typeof(string));
            SqlParameter paramemail = new SqlParameter("@email", typeof(string));
            SqlParameter paramaddress = new SqlParameter("@address", typeof(string));
            SqlParameter paramdistrict = new SqlParameter("@district", typeof(string));
            SqlParameter parampincode = new SqlParameter("@pincode", typeof(string));
            SqlParameter paramsharecode = new SqlParameter("@sharecode", typeof(string));
            SqlParameter paramchalangecode = new SqlParameter("@chalangecode", typeof(string));
            SqlParameter paramdesireusername = new SqlParameter("@desireusername", typeof(int));
            SqlParameter paramdesirepassword = new SqlParameter("@desirepassword", typeof(int));
            SqlParameter paramapplicationnumber = new SqlParameter("@applicationnumber", typeof(string));
            SqlParameter paramdated = new SqlParameter("@dated", typeof(string));
            SqlParameter parametokenpassword = new SqlParameter("@etokenpassword", typeof(string));
            SqlParameter paramadscvalidupto = new SqlParameter("@dscvalidupto", typeof(string));
            SqlParameter paramenteredby = new SqlParameter("@enteredby", typeof(string));
            SqlParameter paramdateofentry = new SqlParameter("@dateofentry", typeof(int));


            paramcustomercode.Value = serviceDetails.customerid;
            paramfilenumber.Value = serviceDetails.filenumber;
            paramapplicantname.Value = serviceDetails.applicantname;
            paramestablishmentname.Value = serviceDetails.establishmentname;
            paramdob.Value = serviceDetails.dob;
            parammobile.Value = serviceDetails.mobile;
            paramemail.Value = serviceDetails.email;
            paramaddress.Value = serviceDetails.address;
            paramdistrict.Value = serviceDetails.district;
            parampincode.Value = serviceDetails.pin;
            paramsharecode.Value = serviceDetails.sharecode;
            paramchalangecode.Value = serviceDetails.chalangecode;
            paramdesireusername.Value = serviceDetails.username;
            paramdesirepassword.Value = serviceDetails.password;
            paramapplicationnumber.Value = serviceDetails.applicationnumber;
            paramdated.Value = serviceDetails.dateofinsert;
            parametokenpassword.Value = serviceDetails.etokenpassword;
            paramadscvalidupto.Value = serviceDetails.dscvalidupto;
            paramenteredby.Value = serviceDetails.enteredby;
            paramdateofentry.Value = serviceDetails.dateofinsert; 


            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_update_service_dsc",
                paramfilenumber, paramcustomercode, paramapplicantname, paramestablishmentname, paramdob,
                parammobile, paramemail, paramaddress, paramdistrict, parampincode, paramsharecode, paramchalangecode, paramdesireusername,
                paramdesirepassword, paramapplicationnumber, paramdated, parametokenpassword, paramadscvalidupto, paramenteredby, paramdateofentry);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    public DataSet SeachBasicGeneralDetails(string concernname = "", string filenumberforsearch = "", string customercodeforsearch = "")
    {
        string query = @"Select filenumber,concernname,customercode,'Not Sure' as proprietorname 
                            from [dbo].[ttbl_general_information] 
                            where concernname = @concernnameforsearch
                            or filenumber = @filenumberforsearch
                            or customercode = @customercodeforsearch";

        SqlParameter paramconcernname = new SqlParameter("@concernnameforsearch", typeof(string));
        SqlParameter paramfilenumber = new SqlParameter("@filenumberforsearch", typeof(string));
        SqlParameter paramcustomercode = new SqlParameter("@customercodeforsearch", typeof(string));

        paramconcernname.Value = concernname;
        paramfilenumber.Value = filenumberforsearch;
        paramcustomercode.Value = customercodeforsearch;

        return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, query, paramconcernname, paramfilenumber, paramcustomercode);
    }
    public DataSet FindAllDetailsOnFilteredParameter(string filenumber = "", string customercode = "", string concernname = "")
    {
        string query = @"select * from [dbo].[ttbl_general_information]  
                             where 
                             filenumber = @filenumber OR
                             customercode=@customercode OR
                             concernname = @concernname";

        SqlParameter paramfilenumber = new SqlParameter("@filenumber", typeof(string));
        SqlParameter paramcustomercode = new SqlParameter("@customercode", typeof(string));
        SqlParameter paramconcernname = new SqlParameter("@concernname", typeof(string));

        paramfilenumber.Value = filenumber;
        paramcustomercode.Value = customercode;
        paramconcernname.Value = concernname;


        return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, query, paramfilenumber, paramcustomercode, paramconcernname);
    }
    public DataSet GetRegisteredCustomerServices(string CustomerId)
    {
        string query = @"SELECT filenumber,servicetakenon from [dbo].[ttbl_customer_services] where customerid= @customerid and isactive = 1";

        SqlParameter paramCustomerId = new SqlParameter("@customerid", typeof(string));
        paramCustomerId.Value = CustomerId;

        return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, query, paramCustomerId);
    }
    public void InsertPtaxServiceDetails(ServiceDetails details)
    {
        try
        {
            SqlParameter ptaxcustomerid = new SqlParameter("@customerid", typeof(string));
            SqlParameter ptaxfilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter ptaxapplicantname = new SqlParameter("@applicantname", typeof(string));
            SqlParameter ptaxestablishmentname = new SqlParameter("@establishmentname", typeof(int));
            SqlParameter ptaxestablishmentaddress = new SqlParameter("@establishmentaddress", typeof(int));
            SqlParameter ptaxdistrict = new SqlParameter("@district", typeof(int));
            SqlParameter ptaxpin = new SqlParameter("@pin", typeof(int));
            SqlParameter ptaxmobile = new SqlParameter("@mobile", typeof(string));
            SqlParameter ptaxemail = new SqlParameter("@email", typeof(string));
            SqlParameter ptaxareaofjurisdiction = new SqlParameter("@areaofjurisdiction", typeof(string));
            SqlParameter ptaxcharge = new SqlParameter("@charge", typeof(string));
            SqlParameter ptaxengagedwith = new SqlParameter("@engagedwith", typeof(int));
            SqlParameter ptaxcategory = new SqlParameter("@category", typeof(int));
            SqlParameter ptaxsubcategory = new SqlParameter("@subcategory", typeof(int));
            SqlParameter ptaxdateofcommencement = new SqlParameter("@dateofcommencement", typeof(DateTime));
            SqlParameter ptaxgstin = new SqlParameter("@gstin", typeof(int));
            SqlParameter ptaxvehiclecategory = new SqlParameter("@vehiclecategory", typeof(int));
            SqlParameter ptaxlevelofsociety = new SqlParameter("@levelofsociety", typeof(int));
            SqlParameter ptaxuername = new SqlParameter("@username", typeof(string));
            SqlParameter ptaxpassword = new SqlParameter("@password", typeof(int));
            SqlParameter ptaxenrolmentnumber = new SqlParameter("@enrolmentnumber", typeof(int));
            SqlParameter ptaxapplicationnumber = new SqlParameter("@applicationnumber", typeof(int));
            SqlParameter ptaxtaxperiod = new SqlParameter("@taxperiod", typeof(int));
            SqlParameter ptaxpaymentdate = new SqlParameter("@paymentdate", typeof(DateTime));
            SqlParameter ptaxamount = new SqlParameter("@amount", typeof(decimal));
            SqlParameter ptaxpaymentreqnumber = new SqlParameter("@paymentreqnumber", typeof(string));
            SqlParameter ptaxgrn = new SqlParameter("@grn", typeof(string));
            SqlParameter ptaxcin = new SqlParameter("@cin", typeof(int));
            SqlParameter ptaxtransactionstatus = new SqlParameter("@transactionstatus", typeof(int));
            SqlParameter ptaxenteredby = new SqlParameter("@enteredby", typeof(int));
            SqlParameter ptaxdateofinsert = new SqlParameter("@dateofinsert", typeof(DateTime));


            ptaxcustomerid.Value = details.customerid;
            ptaxfilenumber.Value = details.filenumber;
            ptaxapplicantname.Value = details.applicantname;
            ptaxestablishmentname.Value = details.establishmentname;
            ptaxestablishmentaddress.Value = details.establishmentaddress;
            ptaxdistrict.Value = details.district;
            ptaxpin.Value = details.pin;
            ptaxmobile.Value = details.mobile;
            ptaxemail.Value = details.email;
            ptaxareaofjurisdiction.Value = details.areaofjurisdiction;
            ptaxcharge.Value = details.charge;
            ptaxengagedwith.Value = details.engagedwith;
            ptaxcategory.Value = details.category;
            ptaxsubcategory.Value = details.subcategory;
            ptaxdateofcommencement.Value = details.dateofcommencement;
            ptaxgstin.Value = details.gstin;
            ptaxvehiclecategory.Value = details.vehiclecategory;
            ptaxlevelofsociety.Value = details.levelofsociety;
            ptaxuername.Value = details.username;
            ptaxpassword.Value = details.password;
            ptaxenrolmentnumber.Value = details.enrolmentnumber;
            ptaxapplicationnumber.Value = details.applicationnumber;
            ptaxtaxperiod.Value = details.taxperiod;
            ptaxpaymentdate.Value = details.paymentdate;
            ptaxamount.Value = details.amount;
            ptaxpaymentreqnumber.Value = details.paymentreqnumber;
            ptaxgrn.Value = details.grn;
            ptaxcin.Value = details.cin;
            ptaxtransactionstatus.Value = details.transactionstatus;
            ptaxenteredby.Value = details.enteredby;
            ptaxdateofinsert.Value = details.dateofinsert;


            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_insert_service_ptax", ptaxcustomerid,
               ptaxfilenumber, ptaxapplicantname, ptaxestablishmentname, ptaxestablishmentaddress,
               ptaxdistrict, ptaxpin, ptaxmobile, ptaxemail, ptaxareaofjurisdiction, ptaxcharge,
               ptaxengagedwith, ptaxcategory, ptaxsubcategory, ptaxdateofcommencement,
               ptaxgstin, ptaxvehiclecategory, ptaxlevelofsociety, ptaxuername, ptaxpassword,
               ptaxenrolmentnumber, ptaxapplicationnumber, ptaxtaxperiod, ptaxpaymentdate, ptaxamount,
               ptaxpaymentreqnumber, ptaxgrn, ptaxcin, ptaxtransactionstatus, ptaxenteredby, ptaxdateofinsert);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    public void InsertItaxServiceDetails(ServiceDetails details)
    {
        try
        {
            SqlParameter itaxcustomerid = new SqlParameter("@customerid", typeof(string));
            SqlParameter itaxfilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter itaxpplyingas = new SqlParameter("@applyingas", typeof(int));
            SqlParameter itaxmobile = new SqlParameter("@mobile", typeof(string));
            SqlParameter paramapplicantname = new SqlParameter("@applicantname", typeof(string));
            SqlParameter itaxemail = new SqlParameter("@email", typeof(string));
            SqlParameter itaxpan = new SqlParameter("@pan", typeof(string));
            SqlParameter itaxaddress = new SqlParameter("@address", typeof(string));
            SqlParameter itaxarealocality = new SqlParameter("@arealocality", typeof(string));
            SqlParameter itaxpostoffice = new SqlParameter("@postoffice", typeof(string));
            SqlParameter itaxstate = new SqlParameter("@state", typeof(int));
            SqlParameter itaxcountry = new SqlParameter("@country", typeof(int));
            SqlParameter itaxpin = new SqlParameter("@pin", typeof(string));
            SqlParameter itaxusername = new SqlParameter("@username", typeof(string));
            SqlParameter itaxpassword = new SqlParameter("@password", typeof(string));
            SqlParameter itaxtransactionid = new SqlParameter("@transactionid", typeof(string));
            SqlParameter itaxfinancialyear = new SqlParameter("@financialyear", typeof(string));
            SqlParameter itaxassessmentyear = new SqlParameter("@assessmentyear", typeof(string));
            SqlParameter itaxreturntype = new SqlParameter("@returntype", typeof(int));
            SqlParameter itaxdownloadform26 = new SqlParameter("@downloadform26", typeof(Boolean));
            SqlParameter itaxreturnform = new SqlParameter("@returnform", typeof(string));
            SqlParameter itaxtaxpayment = new SqlParameter("@taxpayment", typeof(string));
            SqlParameter itaxbrscode = new SqlParameter("@brscode", typeof(string));
            SqlParameter itaxreturnfilleddate = new SqlParameter("@returnfilleddate", typeof(DateTime));
            SqlParameter itaxitracknowledgement = new SqlParameter("@itracknowledgement", typeof(string));
            SqlParameter itaxenteredby = new SqlParameter("@enteredby", typeof(string));
            SqlParameter itaxdateofinsert = new SqlParameter("@dateofinsert", typeof(DateTime));


            itaxcustomerid.Value = details.customerid;
            itaxfilenumber.Value = details.filenumber;
            itaxpplyingas.Value = details.applyingas;
            itaxmobile.Value = details.mobile;
            paramapplicantname.Value = details.applicantname;
            itaxemail.Value = details.email;
            itaxpan.Value = details.pan;
            itaxaddress.Value = details.address;
            itaxarealocality.Value = details.arealocality;
            itaxpostoffice.Value = details.postoffice;
            itaxstate.Value = details.state;
            itaxcountry.Value = details.country;
            itaxpin.Value = details.pin;
            itaxusername.Value = details.username;
            itaxpassword.Value = details.password;
            itaxtransactionid.Value = details.transactionid;
            itaxfinancialyear.Value = details.financialyear;
            itaxassessmentyear.Value = details.assessmentyear;
            itaxreturntype.Value = details.returntype;
            itaxdownloadform26.Value = details.downloadform26;
            itaxreturnform.Value = details.returnform;
            itaxtaxpayment.Value = details.taxpayment;
            itaxbrscode.Value = details.brscode;
            itaxreturnfilleddate.Value = details.returnfilldate;
            itaxitracknowledgement.Value = details.itracknowledgement;
            itaxenteredby.Value = details.enteredby;
            itaxdateofinsert.Value = details.dateofinsert;


            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_insert_service_itax", itaxcustomerid,
               itaxfilenumber, itaxpplyingas, itaxmobile, paramapplicantname, itaxemail, itaxpan, itaxaddress, itaxarealocality,
               itaxpostoffice, itaxstate, itaxcountry, itaxpin, itaxusername, itaxpassword, itaxtransactionid,
               itaxfinancialyear, itaxassessmentyear, itaxreturntype, itaxdownloadform26, itaxreturnform,
               itaxtaxpayment, itaxbrscode, itaxreturnfilleddate, itaxitracknowledgement, itaxenteredby, itaxdateofinsert);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    public void AddNewService(GeneralInformation generalInformation)
    {
        try
        {
            SqlParameter paramcustomerid = new SqlParameter("@customercode", typeof(string));
            SqlParameter paramfilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter paramservicetakenon = new SqlParameter("@servicetakenon", typeof(int));

            paramcustomerid.Value = generalInformation.customercode;
            paramfilenumber.Value = generalInformation.filenumber;
            paramservicetakenon.Value = generalInformation.servicetakenon;

            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_addmore_services", paramcustomerid, paramfilenumber, paramservicetakenon);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    public string CreateFileNumber(int serviceCode, string PAN)
    {
        string FileNumber = string.Empty;
        if (serviceCode == 1)
            FileNumber = "FLP-" + PAN.Substring(4, 6) + Utility.Services.RBR;
        else if (serviceCode == 2)
            FileNumber = "FLP-" + PAN.Substring(4, 6) + Utility.Services.GST;
        else if (serviceCode == 3)
            FileNumber = "FLP-" + PAN.Substring(4, 6) + Utility.Services.ITR;
        else if (serviceCode == 4)
            FileNumber = "FLP-" + PAN.Substring(4, 6) + Utility.Services.ACS;
        else if (serviceCode == 5)
            FileNumber = "FLP-" + PAN.Substring(4, 6) + Utility.Services.PTX;
        else if (serviceCode == 6)
            FileNumber = "FLT-" + PAN.Substring(4, 6) + Utility.Services.DSC;
        else if (serviceCode == 7)
            FileNumber = "FLT-" + PAN.Substring(4, 6) + Utility.Services.EPF;

        return FileNumber;
    }
    public string CreateCustomerNumber(string Adhaar = "", string Contact = "", string VoterId = "")
    {
        string customerCode = string.Empty;
        if (!string.IsNullOrEmpty(Adhaar) && !string.IsNullOrEmpty(Contact))
        {
            customerCode = "C-" + Contact.Substring(6, 4) + Adhaar.Substring(8, 4);
        }
        else if (!string.IsNullOrEmpty(VoterId) && !string.IsNullOrEmpty(Contact))
        {
            customerCode = "C-" + Contact.Substring(6, 4) + VoterId.Substring(8, 4);
        }
        return customerCode;
    }
    public void InsertRegistrationProfessionalTax(ServiceDetails serviceDetails)
    {
        try
        {
            SqlParameter paramfilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter paramcustomercode = new SqlParameter("@customerid", typeof(string));
            SqlParameter paramapplyingas = new SqlParameter("@applyingas", typeof(int));
            SqlParameter paramapplicantname = new SqlParameter("@applicantname", typeof(string));
            SqlParameter paramfathername = new SqlParameter("@fathername", typeof(string));
            SqlParameter parampan = new SqlParameter("@pan", typeof(string));
            SqlParameter paramgender = new SqlParameter("@gender", typeof(int));
            SqlParameter parammobile = new SqlParameter("@mobile", typeof(string));
            SqlParameter paramemail = new SqlParameter("@email", typeof(string));
            SqlParameter paramestablishmentname = new SqlParameter("@establishmentname", typeof(string));
            SqlParameter paramdistrict = new SqlParameter("@district", typeof(int));
            SqlParameter parampincode = new SqlParameter("@pincode", typeof(string));
            SqlParameter paramestablishmentaddress = new SqlParameter("@establishmentaddress", typeof(string));
            SqlParameter paramcategory = new SqlParameter("@category", typeof(int));
            SqlParameter paramsubcategory = new SqlParameter("@subcategory", typeof(int));
            SqlParameter paramengagewith = new SqlParameter("@engagewith", typeof(int));
            SqlParameter paramdateofcommencement = new SqlParameter("@dateofcommencement", typeof(DateTime));
            SqlParameter parampantan = new SqlParameter("@pantan", typeof(string));
            SqlParameter paramannualgrossbusinesss = new SqlParameter("@annualgrossbusiness", typeof(decimal));
            SqlParameter paramanualturnover = new SqlParameter("@anualturnover", typeof(decimal));
            SqlParameter parammonthlyavgworker = new SqlParameter("@monthlyavgworker", typeof(int));
            SqlParameter parammonthlyavgemployee = new SqlParameter("@monthlyavgemployee", typeof(int));
            SqlParameter paramreggst = new SqlParameter("@reggst", typeof(string));
            SqlParameter paramregcst = new SqlParameter("@regcst", typeof(string));
            SqlParameter paramregvat = new SqlParameter("@regvat", typeof(string));
            SqlParameter paramvehicletype = new SqlParameter("@vehicletype", typeof(int));
            SqlParameter paramsocietylevel = new SqlParameter("@societylevel", typeof(int));
            SqlParameter pramenteredby = new SqlParameter("@enteredby", typeof(string));
            SqlParameter paramdateofentry = new SqlParameter("@dateofentry", typeof(DateTime));
            SqlParameter paramserviceid = new SqlParameter("@serviceid", typeof(int));
            SqlParameter paramacknowledgementno = new SqlParameter("@acknowledgementno", typeof(string));
            SqlParameter paramacknowledgeupdateon = new SqlParameter("@acknowledgeupdateon", typeof(DateTime));


            paramfilenumber.Value = serviceDetails.filenumber;
            paramcustomercode.Value = serviceDetails.customerid;
            paramapplyingas.Value = serviceDetails.applyingas;
            paramapplicantname.Value = serviceDetails.applicantname;
            paramfathername.Value = serviceDetails.fathername;
            parampan.Value = serviceDetails.pan;
            paramgender.Value = serviceDetails.gender;
            parammobile.Value = serviceDetails.mobile;
            paramemail.Value = serviceDetails.email;
            paramestablishmentname.Value = serviceDetails.establishmentname;
            paramdistrict.Value = serviceDetails.district;
            parampincode.Value = serviceDetails.pin;
            paramestablishmentaddress.Value = serviceDetails.establishmentaddress;
            paramcategory.Value = serviceDetails.category;
            paramsubcategory.Value = serviceDetails.subcategory;
            paramengagewith.Value = serviceDetails.engagedwith;
            paramdateofcommencement.Value = serviceDetails.dateofcommencement;
            parampantan.Value = serviceDetails.tan;
            paramannualgrossbusinesss.Value = serviceDetails.annualgrossbusiness;
            paramanualturnover.Value = serviceDetails.annualturnover;
            parammonthlyavgworker.Value = serviceDetails.monthlyaverageworker;
            parammonthlyavgemployee.Value = serviceDetails.monthlyaverageemployee;
            paramreggst.Value = serviceDetails.gst;
            paramregcst.Value = serviceDetails.cst;
            paramregvat.Value = serviceDetails.vat;
            paramvehicletype.Value = serviceDetails.vehiclecategory;
            paramsocietylevel.Value = serviceDetails.levelofsociety;
            pramenteredby.Value = serviceDetails.enteredby;
            paramdateofentry.Value = serviceDetails.dateofinsert;
            paramserviceid.Value = serviceDetails.serviceid;
            paramacknowledgementno.Value = serviceDetails.applicationnumber;
            paramacknowledgeupdateon.Value = serviceDetails.acknowledgeupdateon;

            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_insert_registration_professionaltax",
                paramfilenumber, paramcustomercode, paramapplyingas, paramapplicantname, paramfathername, parampan,
                paramgender, parammobile, paramemail, paramestablishmentname, paramdistrict, parampincode, paramestablishmentaddress, paramcategory, paramsubcategory,
                paramengagewith, paramdateofcommencement, parampantan, paramannualgrossbusinesss, paramanualturnover,
                parammonthlyavgworker, parammonthlyavgemployee, paramreggst, paramregcst, paramregvat, paramvehicletype,
                paramsocietylevel, pramenteredby, paramdateofentry, paramserviceid, paramacknowledgementno, paramacknowledgeupdateon);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }

    }
    public void InsertRegistrationIncomeTax(ServiceDetails serviceDetails)
    {
        try
        {
            SqlParameter paramcustomercode = new SqlParameter("@customerid", typeof(string));
            SqlParameter paramfilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter paramapplyingas = new SqlParameter("@applyingas", typeof(int));
            SqlParameter parampan = new SqlParameter("@pan", typeof(int));
            SqlParameter paramapplicantname = new SqlParameter("@applicantname", typeof(int));
            SqlParameter paramdob = new SqlParameter("@dob", typeof(DateTime));
            SqlParameter paramresidentialstatus = new SqlParameter("@residentailstatus", typeof(int));
            SqlParameter parammobile = new SqlParameter("@mobile", typeof(string));
            SqlParameter paramemail = new SqlParameter("@email", typeof(string));
            SqlParameter paramroadstreet = new SqlParameter("@roadstreet", typeof(string));
            SqlParameter paramarealocality = new SqlParameter("@arealocality", typeof(string));
            SqlParameter parampostoffice = new SqlParameter("@postoffice", typeof(string));
            SqlParameter paramstate = new SqlParameter("@state", typeof(int));
            SqlParameter paramcountry = new SqlParameter("@country", typeof(int));
            SqlParameter parampin = new SqlParameter("@pin", typeof(string));
            SqlParameter pramenteredby = new SqlParameter("@enteredby", typeof(string));
            SqlParameter paramacknowledgementno = new SqlParameter("@acknowledgementno", typeof(string));
            SqlParameter paramdateofentry = new SqlParameter("@dateofentry", typeof(string));
            SqlParameter paramserviceid = new SqlParameter("@serviceid", typeof(int));
            SqlParameter paramacknowledgeupdateon = new SqlParameter("@acknowledgeupdateon", typeof(DateTime));


            paramfilenumber.Value = serviceDetails.filenumber;
            paramcustomercode.Value = serviceDetails.customerid;
            paramapplyingas.Value = serviceDetails.applyingas;
            parampan.Value = serviceDetails.pan;
            paramapplicantname.Value = serviceDetails.applicantname;
            paramdob.Value = serviceDetails.dob;
            paramresidentialstatus.Value = serviceDetails.residentialstatus;
            parammobile.Value = serviceDetails.mobile;
            paramemail.Value = serviceDetails.email;
            paramroadstreet.Value = serviceDetails.address;
            paramarealocality.Value = serviceDetails.arealocality;
            parampostoffice.Value = serviceDetails.postoffice;
            paramstate.Value = serviceDetails.state;
            paramcountry.Value = serviceDetails.country;
            parampin.Value = serviceDetails.pin;
            pramenteredby.Value = serviceDetails.enteredby;
            paramacknowledgementno.Value = serviceDetails.applicationnumber;
            paramdateofentry.Value = serviceDetails.dateofinsert;
            paramserviceid.Value = serviceDetails.serviceid;
            paramacknowledgeupdateon.Value = serviceDetails.acknowledgeupdateon;

            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_insert_registration_incometax",
                paramfilenumber, paramcustomercode, paramapplyingas, parampan, paramapplicantname, paramdob,
                paramresidentialstatus, parammobile, paramemail, paramroadstreet, paramarealocality, parampostoffice, paramstate,
                paramcountry, parampin, pramenteredby, paramacknowledgementno, paramdateofentry, paramserviceid, paramacknowledgeupdateon);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }

    }
    public void InsertRegistrationRubber(ServiceDetails serviceDetails)
    {
        try
        {
            SqlParameter paramfilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter paramcustomerid = new SqlParameter("@customerid", typeof(string));
            SqlParameter paramapplydealerlicence = new SqlParameter("@applydealerlicence", typeof(int));
            SqlParameter paramapplicantname = new SqlParameter("@applicantname", typeof(string));
            SqlParameter paramtradername = new SqlParameter("@tradername", typeof(string));
            SqlParameter paramfathername = new SqlParameter("@fathersname", typeof(string));
            SqlParameter paramdob = new SqlParameter("@dob", typeof(DateTime));
            SqlParameter parambusinessplace = new SqlParameter("@businessplace", typeof(string));
            SqlParameter parambusinessbuildingtype = new SqlParameter("@business_buildingtype", typeof(string));
            SqlParameter parambuildingplotno = new SqlParameter("@business_buldingplotno", typeof(string));
            SqlParameter parambusinesscity = new SqlParameter("@business_city  ", typeof(string));
            SqlParameter parambusinessdistrict = new SqlParameter("@business_district", typeof(int));
            SqlParameter parambusinessstate = new SqlParameter("@business_state", typeof(int));
            SqlParameter parambusinesspin = new SqlParameter("@business_pin", typeof(string));
            SqlParameter parambusinessmobile = new SqlParameter("@business_mobile", typeof(string));
            SqlParameter parambusinessemail = new SqlParameter("@business_email", typeof(string));
            SqlParameter paramstorageplace = new SqlParameter("@storageplace  ", typeof(string));
            SqlParameter paramstoragebuildingtype = new SqlParameter("@storage_buildingtype", typeof(string));
            SqlParameter paramstoragebuildingplotno = new SqlParameter("@storage_buildingplotno", typeof(string));
            SqlParameter paramstoragecity = new SqlParameter("@storage_city", typeof(string));
            SqlParameter paramstoragedistrict = new SqlParameter("@storage_district", typeof(int));

            SqlParameter paramstoragestate = new SqlParameter("@storage_state", typeof(int));
            SqlParameter paramstoragepin = new SqlParameter("@storage_pin", typeof(string));
            SqlParameter paramstoragemobile = new SqlParameter("@storage_mobile", typeof(string));
            SqlParameter paramstorageemail = new SqlParameter("@storage_email", typeof(string));
            SqlParameter paramownershiptype = new SqlParameter("@ownershiptype  ", typeof(string));
            SqlParameter paramownershipname = new SqlParameter("@ownershipname  ", typeof(string));
            SqlParameter parampresentpermanentaddress = new SqlParameter("@presentpermanentaddress  ", typeof(string));
            SqlParameter paramppacity = new SqlParameter("@ppa_city", typeof(string));

            SqlParameter paramppadistrict = new SqlParameter("@ppa_district", typeof(int));
            SqlParameter paramppastate = new SqlParameter("@ppa_state", typeof(int));
            SqlParameter paramppapin = new SqlParameter("@ppa_pin", typeof(string));
            SqlParameter paramppamobile = new SqlParameter("@ppa_mobile", typeof(string));
            SqlParameter paramppaemail = new SqlParameter("@ppa_email", typeof(string));
            SqlParameter paramppapan = new SqlParameter("@ppa_pan", typeof(string));

            SqlParameter paraminvestedcapital = new SqlParameter("@ppa_investedcapital", typeof(decimal));
            SqlParameter paramppaenteredby = new SqlParameter("@enteredby", typeof(string));
            SqlParameter paramppadateofentry = new SqlParameter("@dateofentry", typeof(DateTime));
            SqlParameter paramserviceid = new SqlParameter("@serviceid", typeof(int));
            SqlParameter paramacknowledgementno = new SqlParameter("@applicationnumber", typeof(string));
            SqlParameter paramacknowledgeupdateon = new SqlParameter("@acknowledgeupdateon", typeof(DateTime));



            paramfilenumber.Value = serviceDetails.filenumber;
            paramcustomerid.Value = serviceDetails.customerid;
            paramapplydealerlicence.Value = serviceDetails.applydealerlicence;
            paramapplicantname.Value = serviceDetails.applicantname;
            paramtradername.Value = serviceDetails.tradername;
            paramfathername.Value = serviceDetails.fathername;
            paramdob.Value = serviceDetails.dob;
            parambusinessplace.Value = serviceDetails.businessplace;
            parambusinessbuildingtype.Value = serviceDetails.buisnessbuildingtype;
            parambuildingplotno.Value = serviceDetails.businessbuildingplotno;
            parambusinesscity.Value = serviceDetails.businesscity;
            parambusinessdistrict.Value = serviceDetails.district;
            parambusinessstate.Value = serviceDetails.state;
            parambusinesspin.Value = serviceDetails.pin;
            parambusinessmobile.Value = serviceDetails.mobile;
            parambusinessemail.Value = serviceDetails.email;
            paramstorageplace.Value = serviceDetails.storageplace;
            paramstoragebuildingtype.Value = serviceDetails.storagebuildingtype;
            paramstoragebuildingplotno.Value = serviceDetails.storagebuildingplotno;
            paramstoragecity.Value = serviceDetails.storagecity;
            paramstoragedistrict.Value = serviceDetails.storagedistrict;
            paramstoragestate.Value = serviceDetails.storagestate;
            paramstoragepin.Value = serviceDetails.storagepin;
            paramstoragemobile.Value = serviceDetails.storagemobile;
            paramstorageemail.Value = serviceDetails.storagemobile;
            paramownershiptype.Value = serviceDetails.ownershiptype;
            paramownershipname.Value = serviceDetails.ownershipname;
            parampresentpermanentaddress.Value = serviceDetails.presemtpermanentaddress;
            paramppacity.Value = serviceDetails.ppacity;
            paramppadistrict.Value = serviceDetails.ppadistrict;
            paramppastate.Value = serviceDetails.ppastate;
            paramppapin.Value = serviceDetails.ppapin;
            paramppamobile.Value = serviceDetails.ppamobile;
            paramppaemail.Value = serviceDetails.ppaemail;
            paramppapan.Value = serviceDetails.ppapan;
            paraminvestedcapital.Value = serviceDetails.ppainvestedcapital;
            paramppaenteredby.Value = serviceDetails.enteredby;
            paramppadateofentry.Value = serviceDetails.dateofinsert;
            paramserviceid.Value = serviceDetails.serviceid;
            paramacknowledgementno.Value = serviceDetails.applicationnumber;
            paramacknowledgeupdateon.Value = serviceDetails.acknowledgeupdateon;

            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_insert_registration_rubber",
                paramfilenumber, paramcustomerid, paramapplydealerlicence, paramapplicantname,
                paramtradername, paramfathername, paramdob, parambusinessplace, parambusinessbuildingtype, parambuildingplotno,
                parambusinesscity, parambusinessdistrict, parambusinessstate, parambusinesspin, parambusinessmobile,
                parambusinessemail, paramstorageplace, paramstoragebuildingtype, paramstoragebuildingplotno, paramstoragecity,
                paramstoragedistrict, paramstoragestate, paramstoragepin, paramstoragemobile, paramstorageemail,
                paramownershiptype, paramownershipname, parampresentpermanentaddress, paramppacity, paramppadistrict,
                paramppastate, paramppapin, paramppamobile, paramppaemail, paramppapan, paraminvestedcapital, paramppaenteredby,
                paramppadateofentry, paramserviceid, paramacknowledgementno, paramacknowledgeupdateon);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    public void InsertRegistrationDSC(ServiceDetails serviceDetails)
    {
        try
        {
            SqlParameter paramfiilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter paramcustomerid = new SqlParameter("@customerid", typeof(string));
            SqlParameter paramapplicantname = new SqlParameter("@applicantname", typeof(string));
            SqlParameter paramestablishmentname = new SqlParameter("@establishmentname", typeof(string));
            SqlParameter parampan = new SqlParameter("@pan", typeof(string));
            SqlParameter paramadhaar = new SqlParameter("@adhaar", typeof(string));
            SqlParameter parammobile = new SqlParameter("@mobile", typeof(string));
            SqlParameter paramdateofbirth = new SqlParameter("@dateofbirth", typeof(DateTime));
            SqlParameter paramemail = new SqlParameter("@email", typeof(string));
            SqlParameter paramisadhaarlinkedwithmobile = new SqlParameter("@isadhaarlinkedwithmobile", typeof(bool));
            SqlParameter parammobilelinkedwithadhaar = new SqlParameter("@mobilelinkedwithadhaar", typeof(string));
            SqlParameter paramaddress = new SqlParameter("@address", typeof(string));
            SqlParameter paramdistrict = new SqlParameter("@district", typeof(int));
            SqlParameter parampincode = new SqlParameter("@pincode", typeof(string));
            SqlParameter paramserviceid = new SqlParameter("@serviceid", typeof(int));
            SqlParameter paramenteredby = new SqlParameter("@enteredby", typeof(string));
            SqlParameter paramdateofentry = new SqlParameter("@dateofentry", typeof(DateTime));
            SqlParameter paramacknowledgementno = new SqlParameter("@acknowledgementno", typeof(string));
            SqlParameter paramacknowledgeupdateon = new SqlParameter("@acknowledgeupdateon", typeof(DateTime));



            paramfiilenumber.Value = serviceDetails.filenumber;
            paramcustomerid.Value = serviceDetails.customerid;
            paramapplicantname.Value = serviceDetails.applicantname;
            paramestablishmentname.Value = serviceDetails.establishmentname;
            parampan.Value = serviceDetails.pan;
            paramadhaar.Value = serviceDetails.adhaar;
            parammobile.Value = serviceDetails.mobile;
            paramdateofbirth.Value = serviceDetails.dob;
            paramemail.Value = serviceDetails.email;
            paramisadhaarlinkedwithmobile.Value = serviceDetails.isadhaarlinkedwithmobile;
            parammobilelinkedwithadhaar.Value = serviceDetails.linkedmobilewithadhaar;
            paramaddress.Value = serviceDetails.address;
            paramdistrict.Value = serviceDetails.district;
            parampincode.Value = serviceDetails.pin;
            paramserviceid.Value = serviceDetails.serviceid;
            paramenteredby.Value = serviceDetails.enteredby;
            paramdateofentry.Value = serviceDetails.dateofinsert;
            paramacknowledgementno.Value = serviceDetails.applicationnumber;
            paramacknowledgeupdateon.Value = serviceDetails.acknowledgeupdateon;


            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[udsp_insert_registration_dsc]",
                       paramfiilenumber, paramcustomerid, paramapplicantname, paramestablishmentname, parampan,
                       paramadhaar, parammobile, paramdateofbirth, paramemail, paramisadhaarlinkedwithmobile,
                       parammobilelinkedwithadhaar, paramaddress, paramdistrict, parampincode, paramserviceid,
                       paramenteredby, paramdateofentry, paramacknowledgementno, paramacknowledgeupdateon);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }

    }
    public void UpdateAcknowledgeNumber(ServiceDetails serviceDetails)
    {
        try
        {
            SqlParameter paramfiilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter paramcustomerid = new SqlParameter("@customerid", typeof(string));
            SqlParameter paramacknowledgementno = new SqlParameter("@acknowledgementno", typeof(string));
            SqlParameter paramserviceid = new SqlParameter("@serviceid", typeof(int));
            SqlParameter paramacknowledgeupdateon = new SqlParameter("@acknowledgeupdateon", typeof(DateTime));


            paramfiilenumber.Value = serviceDetails.filenumber;
            paramcustomerid.Value = serviceDetails.customerid;
            paramacknowledgementno.Value = serviceDetails.applicationnumber;
            paramserviceid.Value = serviceDetails.serviceid;
            paramacknowledgeupdateon.Value = serviceDetails.acknowledgeupdateon;

            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_update_acknowledgeno",
                       paramfiilenumber, paramcustomerid, paramacknowledgementno, paramserviceid, paramacknowledgeupdateon);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }

    }

    // SEARCH
    public DataSet GetFormDetails(ServiceDetails serviceDetails)
    {
        SqlParameter paramcustomerid = new SqlParameter("@customerid", typeof(string));
        SqlParameter paramserviceid = new SqlParameter("@serviceid", typeof(int));

        paramcustomerid.Value = serviceDetails.customerid;
        paramserviceid.Value = serviceDetails.serviceid;

        return SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "udsp_getsearchdetails_on_serviceid",
            paramcustomerid, paramserviceid);
    }
    public void InsertRegistrationGST(ServiceDetails serviceDetails)
    {
        try
        {
            SqlParameter paramfiilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter paramcustomerid = new SqlParameter("@customerid", typeof(string));
            SqlParameter paramlegalbusinessname = new SqlParameter("@legalbusinessname", typeof(string));
            SqlParameter paramadhaarno = new SqlParameter("@adhaarno", typeof(string));
            SqlParameter parampan = new SqlParameter("@pan", typeof(string));
            SqlParameter paramtradename = new SqlParameter("@tradename", typeof(string));
            SqlParameter paramconstitutionofbusiness = new SqlParameter("@constitutionofbusiness", typeof(int));
            SqlParameter paramiscasualtaxable = new SqlParameter("@iscasualtaxable", typeof(int));
            SqlParameter paramcompositionoption = new SqlParameter("@compositionoption", typeof(int));
            SqlParameter paramresonregistration = new SqlParameter("@resonregistration", typeof(int));

            SqlParameter paramdateofcommencement = new SqlParameter("@dateofcommencement", typeof(DateTime));
            SqlParameter paramdateofliabilityregister = new SqlParameter("@dateofliabilityregister", typeof(DateTime));
            SqlParameter paramnameofperson = new SqlParameter("@nameofperson", typeof(string));
            SqlParameter paramfathername = new SqlParameter("@fathername", typeof(string));
            SqlParameter paramdob = new SqlParameter("@dob", typeof(DateTime));
            SqlParameter paramgender = new SqlParameter("@gender", typeof(int));
            SqlParameter parammobile = new SqlParameter("@mobile", typeof(string));
            SqlParameter paramemail = new SqlParameter("@email", typeof(string));
            SqlParameter paramauthorisedsignatory = new SqlParameter("@authorisedsignatory", typeof(string));
            SqlParameter paramdesignation = new SqlParameter("@designation", typeof(int));



            SqlParameter paramresidentialaddress = new SqlParameter("@residentialaddress", typeof(string));
            SqlParameter paramnoofpartners = new SqlParameter("@noofpartners", typeof(int));
            SqlParameter paramconcerndealswith = new SqlParameter("@concerndealswith", typeof(int));
            SqlParameter paramdetailsauthorisedsignatory = new SqlParameter("@detailsauthorisedsignatory", typeof(string));
            SqlParameter paramisauthorisedrepresentative = new SqlParameter("@isauthorisedrepresentative", typeof(int));
            SqlParameter paramprincipalplace = new SqlParameter("@principalplace", typeof(string));
            SqlParameter paramstatejurisdiction = new SqlParameter("@statejurisdiction", typeof(int));
            SqlParameter paramSCWC = new SqlParameter("@SCWC", typeof(string));
            SqlParameter paramcommisionerate = new SqlParameter("@commisionerate", typeof(string));
            SqlParameter paramdivision = new SqlParameter("@division", typeof(int));
            SqlParameter paramrange = new SqlParameter("@range", typeof(int));
            SqlParameter paramnatureofpossession = new SqlParameter("@natureofpossession", typeof(int));

            SqlParameter paramproofofprincipleplace = new SqlParameter("@proofofprincipleplace", typeof(string));
            SqlParameter paramnatureofbusiness = new SqlParameter("@natureofbusiness", typeof(int));
            SqlParameter parambusinessadditionalplace = new SqlParameter("@businessadditionalplace", typeof(string));
            SqlParameter paramdetailsofgoodssupplied = new SqlParameter("@detailsofgoodssupplied", typeof(string));
            SqlParameter paramptaxcertificateno = new SqlParameter("@ptaxcertificateno", typeof(string));
            SqlParameter paramptaxemployeecode = new SqlParameter("@ptaxemployeecode", typeof(string));
            SqlParameter paramapplicationnumber = new SqlParameter("@applicationnumber", typeof(string));
            SqlParameter paramserviceid = new SqlParameter("@serviceid", typeof(int));
            SqlParameter paramenteredby = new SqlParameter("@enteredby", typeof(string));
            SqlParameter paramdateofentry = new SqlParameter("@dateofentry", typeof(DateTime));
            SqlParameter paramacknowledgeupdateon = new SqlParameter("@acknowledgeupdateon", typeof(DateTime));
            SqlParameter paramnameofauthorisedsignatory = new SqlParameter("@nameofauthorisedsignatory", typeof(string));
            SqlParameter paramtrn = new SqlParameter("@trn", typeof(string));

            paramfiilenumber.Value = serviceDetails.filenumber;
            paramcustomerid.Value = serviceDetails.customerid;
            paramlegalbusinessname.Value = serviceDetails.legalbusinessname;
            paramadhaarno.Value = serviceDetails.adhaar;
            parampan.Value = serviceDetails.pan;
            paramtradename.Value = serviceDetails.tradername;
            paramconstitutionofbusiness.Value = serviceDetails.constitutionofbusiness; // int
            paramiscasualtaxable.Value = serviceDetails.iscasualtaxable;// int
            paramcompositionoption.Value = serviceDetails.compositionoption;// int
            paramresonregistration.Value = serviceDetails.resonregistration;// int
            paramdateofcommencement.Value = serviceDetails.dateofcommencement_gst;
            paramdateofliabilityregister.Value = serviceDetails.dateofliabilityregister;
            paramnameofperson.Value = serviceDetails.applicantname;
            paramfathername.Value = serviceDetails.fathername;
            paramdob.Value = serviceDetails.dob;
            paramgender.Value = serviceDetails.gender;// int
            parammobile.Value = serviceDetails.mobile;
            paramemail.Value = serviceDetails.email;
            paramauthorisedsignatory.Value = serviceDetails.authorisedsignatory;
            paramdesignation.Value = serviceDetails.designation;// int
            paramresidentialaddress.Value = serviceDetails.residentialaddress;
            paramnoofpartners.Value = serviceDetails.noofdirectors;// int
            paramconcerndealswith.Value = serviceDetails.concerndealswith;// int
            paramdetailsauthorisedsignatory.Value = serviceDetails.detailsauthorisedsignatory;
            paramisauthorisedrepresentative.Value = serviceDetails.isauthorisedrepresentative;// int
            paramprincipalplace.Value = serviceDetails.principalplace;
            paramstatejurisdiction.Value = serviceDetails.statejurisdiction;// int
            paramSCWC.Value = serviceDetails.SCWC;
            paramcommisionerate.Value = serviceDetails.commisionerate;
            paramdivision.Value = serviceDetails.division;// int
            paramrange.Value = serviceDetails.range;// int
            paramnatureofpossession.Value = serviceDetails.natureofpossession;// int
            paramproofofprincipleplace.Value = serviceDetails.proofofprincipleplace;
            paramnatureofbusiness.Value = serviceDetails.natureofbusiness;// int
            parambusinessadditionalplace.Value = serviceDetails.businessadditionalplace;

            paramdetailsofgoodssupplied.Value = serviceDetails.detailsofgoodssupplied;
            paramptaxcertificateno.Value = serviceDetails.ptaxcertificateno;
            paramptaxemployeecode.Value = serviceDetails.ptaxemployeecode;
            paramapplicationnumber.Value = serviceDetails.applicationnumber;
            paramserviceid.Value = serviceDetails.serviceid;// int
            paramenteredby.Value = serviceDetails.enteredby;
            paramdateofentry.Value = serviceDetails.dateofinsert;
            paramacknowledgeupdateon.Value = serviceDetails.acknowledgeupdateon;
            paramnameofauthorisedsignatory.Value = serviceDetails.nameofauthorisedsignatory;
            paramtrn.Value = serviceDetails.trn;

            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[udsp_insert_registration_gst]",
                       paramfiilenumber, paramcustomerid, paramlegalbusinessname, paramadhaarno, parampan, paramtradename,
                       paramconstitutionofbusiness, paramiscasualtaxable, paramcompositionoption, paramresonregistration,
                       paramdateofcommencement, paramdateofliabilityregister, paramnameofperson, paramfathername, paramdob,
                       paramgender, parammobile, paramemail, paramauthorisedsignatory, paramdesignation, paramresidentialaddress,
                       paramnoofpartners, paramconcerndealswith, paramdetailsauthorisedsignatory, paramisauthorisedrepresentative, paramprincipalplace,
                       paramstatejurisdiction, paramSCWC, paramcommisionerate, paramdivision, paramrange, paramnatureofpossession, paramproofofprincipleplace,
                       paramnatureofbusiness, parambusinessadditionalplace, paramdetailsofgoodssupplied, paramptaxcertificateno,
                       paramptaxemployeecode, paramapplicationnumber, paramserviceid, paramenteredby, paramdateofentry, paramacknowledgeupdateon, paramnameofauthorisedsignatory, paramtrn);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    public void InsertGSTServiceDetails(ServiceDetails serviceDetails)
    {
        try
        {
            SqlParameter paramfiilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter paramcustomerid = new SqlParameter("@customerid", typeof(string));
            SqlParameter paramyear = new SqlParameter("@year", typeof(int));
            SqlParameter parammonth = new SqlParameter("@month", typeof(int));
            SqlParameter paramreturntypegstr1 = new SqlParameter("@returntypegstr1", typeof(int));
            SqlParameter paramreturntypegstr3b = new SqlParameter("@returntypegstr3b", typeof(int));
            SqlParameter paramgstin = new SqlParameter("@gstin", typeof(string));
            SqlParameter paramfilename = new SqlParameter("@filename", typeof(string));
            SqlParameter paramconcernname = new SqlParameter("@concernname", typeof(string));
            SqlParameter paramslno = new SqlParameter("@slno", typeof(int));
            SqlParameter paramconcernaddress = new SqlParameter("@concernaddress", typeof(string));
            SqlParameter paramdateofregistration = new SqlParameter("@dateofregistration", typeof(DateTime));
            SqlParameter paramregistrationtype = new SqlParameter("@registrationtype", typeof(int));
            SqlParameter paramusername = new SqlParameter("@username", typeof(string));
            SqlParameter parampassword = new SqlParameter("@password", typeof(string));
            SqlParameter parammobile = new SqlParameter("@mobile", typeof(string));
            SqlParameter paramemail = new SqlParameter("@email", typeof(string));
            SqlParameter paramchallanmadeon = new SqlParameter("@challanmadeon", typeof(int));
            SqlParameter paramgstinassign = new SqlParameter("@gstinassign", typeof(int));
            SqlParameter paramewaybillusername = new SqlParameter("@ewaybillusername", typeof(string));
            SqlParameter paramewaybillpassword = new SqlParameter("@ewaybillpassword", typeof(string));
            SqlParameter paramcompliances = new SqlParameter("@compliances", typeof(string));
            SqlParameter paramactiontaken = new SqlParameter("@actiontaken", typeof(string));
            SqlParameter paramfinancialyear = new SqlParameter("@financialyear", typeof(string));
            SqlParameter paramsalesstatement = new SqlParameter("@salesstatement", typeof(int));
            SqlParameter parampurchasestatement = new SqlParameter("@purchasestatement", typeof(int));
            SqlParameter paramreceivedon = new SqlParameter("@receivedon", typeof(DateTime));
            SqlParameter paramcheckewaybilldetails = new SqlParameter("@checkewaybilldetails", typeof(int));
            SqlParameter paramfiledgstriiff = new SqlParameter("@filedgstriiff", typeof(int));
            SqlParameter paramfiledgstriiffon = new SqlParameter("@filedgstriiffon", typeof(DateTime));
            SqlParameter paramcheckgstr2a2b = new SqlParameter("@checkgstr2a2b", typeof(int));
            SqlParameter paramchecktaxliabilities = new SqlParameter("@checktaxliabilities", typeof(int));
            SqlParameter paramchecktdstcs = new SqlParameter("@checktdstcs", typeof(int));
            SqlParameter paramrecordgstreconciliation = new SqlParameter("@recordgstreconciliation", typeof(int));
            SqlParameter paramfiledgstr3bpmt8 = new SqlParameter("@filedgstr3bpmt8", typeof(int));
            SqlParameter paramfiledonreconciliation = new SqlParameter("@filedonreconciliation", typeof(DateTime));
            SqlParameter paramfileddrc8regarding = new SqlParameter("@fileddrc8regarding", typeof(int));
            SqlParameter paramfileddrc8regardingon = new SqlParameter("@fileddrc8regardingon", typeof(DateTime));
            SqlParameter paramcheckcashcreditleder = new SqlParameter("@checkcashcreditleder", typeof(int));
            SqlParameter paramdocumentfiledcheckby = new SqlParameter("@documentfiledcheckby", typeof(string));
            SqlParameter paramverifiedby = new SqlParameter("@verifiedby", typeof(string));
            SqlParameter paramenteredby = new SqlParameter("@enteredby", typeof(string));
            SqlParameter paramdateofentry = new SqlParameter("@dateofinsert", typeof(DateTime));


            paramfiilenumber.Value = serviceDetails.filenumber;
            paramcustomerid.Value = serviceDetails.customerid;
            paramyear.Value = serviceDetails.year;
            parammonth.Value = serviceDetails.month;
            paramreturntypegstr1.Value = serviceDetails.returntypegstr1;
            paramreturntypegstr3b.Value = serviceDetails.returntypegstr3b;
            paramgstin.Value = serviceDetails.gstin;
            paramfilename.Value = serviceDetails.filename;
            paramslno.Value = serviceDetails.slno;
            paramconcernname.Value = serviceDetails.concernname;
            paramconcernaddress.Value = serviceDetails.address;
            paramdateofregistration.Value = serviceDetails.dateofregistration;
            paramregistrationtype.Value = serviceDetails.registrationtype;
            paramusername.Value = serviceDetails.username;
            parampassword.Value = serviceDetails.password;
            parammobile.Value = serviceDetails.mobile;
            paramemail.Value = serviceDetails.email;
            paramchallanmadeon.Value = serviceDetails.challanmadeon;
            paramgstinassign.Value = serviceDetails.gstinassign;
            paramewaybillusername.Value = serviceDetails.ewaybillusername;
            paramewaybillpassword.Value = serviceDetails.ewaybillpassword;
            paramcompliances.Value = serviceDetails.compliances;
            paramactiontaken.Value = serviceDetails.actiontaken;
            paramfinancialyear.Value = serviceDetails.financialyear;
            paramsalesstatement.Value = serviceDetails.salesstatement;
            parampurchasestatement.Value = serviceDetails.purchasestatement;
            paramreceivedon.Value = serviceDetails.receivedon;
            paramcheckewaybilldetails.Value = serviceDetails.checkewaybilldetails;
            paramfiledgstriiff.Value = serviceDetails.filedgstriiff;
            paramfiledgstriiffon.Value = serviceDetails.filedgstriiffon;
            paramcheckgstr2a2b.Value = serviceDetails.checkgstr2a2b;
            paramchecktaxliabilities.Value = serviceDetails.checktaxliabilities;
            paramchecktdstcs.Value = serviceDetails.checktdstcs;
            paramrecordgstreconciliation.Value = serviceDetails.recordgstreconciliation;
            paramfiledgstr3bpmt8.Value = serviceDetails.filedgstr3bpmt8;
            paramfiledonreconciliation.Value = serviceDetails.filedonreconciliation;
            paramfileddrc8regarding.Value = serviceDetails.fileddrc8regarding;
            paramfileddrc8regardingon.Value = serviceDetails.fileddrc8regardingon;
            paramcheckcashcreditleder.Value = serviceDetails.checkcashcreditleder;
            paramdocumentfiledcheckby.Value = serviceDetails.documentfiledcheckby;
            paramverifiedby.Value = serviceDetails.verifiedby;
            paramenteredby.Value = serviceDetails.enteredby;
            paramdateofentry.Value = serviceDetails.dateofinsert;


            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[udsp_insert_service_gst]",
                       paramfiilenumber, paramcustomerid, paramyear, parammonth, paramreturntypegstr1, paramreturntypegstr3b, paramgstin,
                       paramfilename, paramslno, paramconcernname, paramconcernaddress, paramdateofregistration, paramregistrationtype, paramusername,
                       parampassword, parammobile, paramemail, paramchallanmadeon, paramgstinassign, paramewaybillusername, paramewaybillpassword,
                       paramcompliances, paramactiontaken, paramfinancialyear, paramsalesstatement, parampurchasestatement, paramreceivedon,
                       paramcheckewaybilldetails, paramfiledgstriiff, paramfiledgstriiffon, paramcheckgstr2a2b, paramchecktaxliabilities, paramchecktdstcs,
                       paramrecordgstreconciliation, paramfiledgstr3bpmt8, paramfiledonreconciliation, paramfileddrc8regarding,
                       paramfileddrc8regardingon, paramcheckcashcreditleder, paramdocumentfiledcheckby, paramverifiedby,
                       paramenteredby, paramdateofentry);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }

    public void InsertAccountsServiceDetails(ServiceDetails serviceDetails)
    {
        try
        {
            SqlParameter paramcustomerid = new SqlParameter("@customerid", typeof(string));
            SqlParameter paramfiilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter parambookkeepingmadeon = new SqlParameter("@bookkeepingmadeon", typeof(int));
            SqlParameter paramtallydatanumber = new SqlParameter("@tallydatanumber", typeof(int));
            SqlParameter paramfinancialyear = new SqlParameter("@financialyear", typeof(int));
            SqlParameter parammonth = new SqlParameter("@month", typeof(int));
            SqlParameter paramtallyexcelreceived = new SqlParameter("@tallyexcelreceived", typeof(string));
            SqlParameter paramopeninngstockstatement = new SqlParameter("@openinngstockstatement", typeof(string));
            SqlParameter parampurchasebillstatement = new SqlParameter("@purchasebillstatement", typeof(string));
            SqlParameter paramsalesbillstatement = new SqlParameter("@salesbillstatement", typeof(int));
            SqlParameter paramcredite = new SqlParameter("@credite", typeof(string));
            SqlParameter paramdebite = new SqlParameter("@debite", typeof(DateTime));
            SqlParameter parambankstatement = new SqlParameter("@bankstatement", typeof(int));
            SqlParameter paramcashbooks = new SqlParameter("@cashbooks", typeof(string));
            SqlParameter paramloanstatements = new SqlParameter("@loanstatements", typeof(string));
            SqlParameter paramreceiptpaymentstatetement = new SqlParameter("@receiptpaymentstatetement", typeof(string));
            SqlParameter paramprofitlossaccounts = new SqlParameter("@profitlossaccounts", typeof(string));
            SqlParameter parambalancesheet = new SqlParameter("@balancesheet", typeof(int));
            SqlParameter parampurchasestatement = new SqlParameter("@purchasestatement", typeof(int));
            SqlParameter paramsundrycreditorslist = new SqlParameter("@sundrycreditorslist", typeof(string));
            SqlParameter paramsalesstatements = new SqlParameter("@salesstatements", typeof(string));
            SqlParameter paramsundrydebtorlist = new SqlParameter("@sundrydebtorlist", typeof(string));
            SqlParameter parambanksatements = new SqlParameter("@banksatements", typeof(string));
            SqlParameter parambrs = new SqlParameter("@brs", typeof(string));
            SqlParameter paramcashbook = new SqlParameter("@cashbook", typeof(int));
            SqlParameter paramclosingstockstatement = new SqlParameter("@closingstockstatement", typeof(int));
            SqlParameter paramreceiptpaymentstatement_rpt = new SqlParameter("@receiptpaymentstatement_rpt", typeof(DateTime));
            SqlParameter paramobservation = new SqlParameter("@observation", typeof(int));
            SqlParameter paramenteredby = new SqlParameter("@enteredby", typeof(string));
            SqlParameter paramdateofentry = new SqlParameter("@dateofinsert", typeof(DateTime));


            paramcustomerid.Value = serviceDetails.customerid;
            paramfiilenumber.Value = serviceDetails.filenumber;
            parambookkeepingmadeon.Value = serviceDetails.bookkeepingmadeon;
            paramtallydatanumber.Value = serviceDetails.tallydatanumber;
            paramfinancialyear.Value = serviceDetails.financialyear;
            parammonth.Value = serviceDetails.month;
            paramtallyexcelreceived.Value = serviceDetails.tallyexcelreceived;
            paramopeninngstockstatement.Value = serviceDetails.openinngstockstatement;
            parampurchasebillstatement.Value = serviceDetails.purchasebillstatement;
            paramsalesbillstatement.Value = serviceDetails.salesbillstatement;
            paramcredite.Value = serviceDetails.creditnote;
            paramdebite.Value = serviceDetails.debitnote;
            parambankstatement.Value = serviceDetails.bankstatement;
            paramcashbooks.Value = serviceDetails.cashbook;
            paramloanstatements.Value = serviceDetails.loanstatements;
            paramreceiptpaymentstatetement.Value = serviceDetails.receiptpaymentstatement;
            paramprofitlossaccounts.Value = serviceDetails.profitlossaccounts;
            parambalancesheet.Value = serviceDetails.balancesheet;
            parampurchasestatement.Value = serviceDetails.purchasestatement;
            paramsundrycreditorslist.Value = serviceDetails.sundrycreditorslist;
            paramsalesstatements.Value = serviceDetails.salesbillstatement;
            paramsundrydebtorlist.Value = serviceDetails.sundrydebtorlist;
            parambanksatements.Value = serviceDetails.banksatements_rpt;
            parambrs.Value = serviceDetails.brs;
            paramcashbook.Value = serviceDetails.cashbook_rpt;
            paramclosingstockstatement.Value = serviceDetails.closingstockstatement;
            paramreceiptpaymentstatement_rpt.Value = serviceDetails.receiptpaymentstatement_rpt;
            paramobservation.Value = serviceDetails.observation;
            paramenteredby.Value = serviceDetails.enteredby;
            paramdateofentry.Value = serviceDetails.dateofinsert;

            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[udsp_insert_service_accounts]",
                       paramcustomerid, paramfiilenumber, parambookkeepingmadeon, paramtallydatanumber, paramfinancialyear, parammonth, paramtallyexcelreceived,
                       paramopeninngstockstatement, parampurchasebillstatement, paramsalesbillstatement, paramcredite, paramdebite, parambankstatement,
                       paramcashbooks, paramloanstatements, paramreceiptpaymentstatetement, paramprofitlossaccounts, parambalancesheet, parampurchasestatement,
                       paramsundrycreditorslist, paramsalesstatements, paramsundrydebtorlist, parambanksatements, parambrs, paramcashbook, paramclosingstockstatement,
                       paramreceiptpaymentstatement_rpt, paramobservation, paramenteredby, paramdateofentry);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }

    public void InsertRegistrationAccounts(ServiceDetails serviceDetails)
    {
        try
        {
            SqlParameter paramcustomerid = new SqlParameter("@customerid", typeof(string));
            SqlParameter paramfiilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter parampan = new SqlParameter("@pan", typeof(string));
            SqlParameter paramacknowledgementno = new SqlParameter("@acknowledgementno", typeof(string));
            SqlParameter paramserviceid = new SqlParameter("@serviceid", typeof(int));
            SqlParameter paramenteredby = new SqlParameter("@enteredby", typeof(string));
            SqlParameter paramdateofentry = new SqlParameter("@dateofentry", typeof(DateTime));
            SqlParameter paramacknowledgeupdateon = new SqlParameter("@acknowledgeupdateon", typeof(DateTime));


            paramcustomerid.Value = serviceDetails.customerid;
            paramfiilenumber.Value = serviceDetails.filenumber;
            parampan.Value = serviceDetails.pan;
            paramacknowledgementno.Value = serviceDetails.applicationnumber;
            paramserviceid.Value = serviceDetails.serviceid;
            paramenteredby.Value = serviceDetails.enteredby;
            paramdateofentry.Value = DateTime.Now;
            paramacknowledgeupdateon.Value = serviceDetails.acknowledgeupdateon;


            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[udsp_insert_registration_accounts]",
                       paramfiilenumber, paramcustomerid, parampan, paramacknowledgementno, paramserviceid, paramenteredby, paramdateofentry);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }

    public void InsertServiceGSTRYearly(ServiceDetails serviceDetails)
    {
        try
        {
            SqlParameter paramcustomerid = new SqlParameter("@customerid", typeof(string));
            SqlParameter paramfiilenumber = new SqlParameter("@filenumber", typeof(string));
            SqlParameter paramgstin = new SqlParameter("gstin", typeof(string));
            SqlParameter paramfinancialyear = new SqlParameter("financialyear", typeof(string));
            SqlParameter paramtype = new SqlParameter("type", typeof(int));
            SqlParameter paramfiledgstr94 = new SqlParameter("filedgstr94", typeof(int));
            SqlParameter paramfiledon94 = new SqlParameter("filedon94", typeof(DateTime));
            SqlParameter paramfiledgstr9c = new SqlParameter("filedgstr9c", typeof(int));
            SqlParameter paramfiledon9c = new SqlParameter("filedon9c", typeof(DateTime));
            SqlParameter paramnotesongstr94 = new SqlParameter("notesongstr94", typeof(string));
            SqlParameter paramdocumentfilledcheckby = new SqlParameter("documentfilledcheckby", typeof(string));
            SqlParameter paramverifiedby = new SqlParameter("verifiedby", typeof(string));
            SqlParameter paramserviceid = new SqlParameter("@serviceid", typeof(int));
            SqlParameter paramenteredby = new SqlParameter("@enteredby", typeof(string));
            SqlParameter paramdateofentry = new SqlParameter("@dateofinsert", typeof(DateTime));


            paramcustomerid.Value = serviceDetails.customerid;
            paramfiilenumber.Value = serviceDetails.filenumber;
            paramgstin.Value = serviceDetails.gstin;
            paramfinancialyear.Value = serviceDetails.financialyear;
            paramtype.Value = serviceDetails.type;
            paramfiledgstr94.Value = serviceDetails.filedgstr94;
            paramfiledon94.Value = serviceDetails.filedgstr94on;
            paramfiledgstr9c.Value = serviceDetails.filedgstr9c;
            paramfiledon9c.Value = serviceDetails.filedgstr9con;
            paramnotesongstr94.Value = serviceDetails.notesongstr94;
            paramdocumentfilledcheckby.Value = serviceDetails.documentfiledcheckby;
            paramverifiedby.Value = serviceDetails.verifiedby;
            paramserviceid.Value = serviceDetails.serviceid;
            paramenteredby.Value = serviceDetails.enteredby;
            paramdateofentry.Value = DateTime.Now;

            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_insert_service_gst_yearly",
                       paramcustomerid, paramfiilenumber, paramgstin, paramfinancialyear, paramtype, paramfiledgstr94, paramfiledon94,
                       paramfiledgstr9c, paramfiledon9c, paramnotesongstr94, paramdocumentfilledcheckby, paramverifiedby,
                       paramserviceid, paramenteredby, paramdateofentry);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }

    public DataSet LoadGstrYearlyResut(ServiceDetails serviceDetails)
    {
        string query = @"SELECT financialyear as [FINANCIAL YEAR], mbr.filedname  as [GSTR-9 / 4], filedon94 as [DATE],
                        mbr1.filedname as [GSTR-9C], filedon9c as [DATE]	
                        FROM [dbo].[ttbl_service_gst_yearly]   
                        INNER JOIN mtbl_filedgstr mbr ON mbr.filedid = [ttbl_service_gst_yearly].filedgstr94
                        INNER JOIN mtbl_filedgstr mbr1 on  mbr1.filedid = [ttbl_service_gst_yearly].filedgstr9c
                        WHERE customerid = @customerid";

        SqlParameter paramcustomerid = new SqlParameter("@customerid", typeof(string));
        paramcustomerid.Value = serviceDetails.customerid;

        return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, query, paramcustomerid);

    }

    public DataSet ReturnServiceAlreadySubmitted(string customerid, int serviceid, out string outputmessage, out string isreturninfoexists)
    {
        SqlParameter paramcustomerid = new SqlParameter("@customerid", typeof(string));
        SqlParameter paramserviceid = new SqlParameter("@serviceid", typeof(int));
        SqlParameter paramoutputmessage = new SqlParameter("@outputmessage", SqlDbType.VarChar, 50);
        SqlParameter paramisreturninfoexists = new SqlParameter("@isreturninfoexists", SqlDbType.VarChar, 50);

        paramcustomerid.Value = customerid;
        paramserviceid.Value = serviceid;
        paramoutputmessage.Direction = ParameterDirection.Output;
        paramisreturninfoexists.Direction = ParameterDirection.Output;

        DataSet ds = new DataSet();

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "udsp_check_return_info_submitted",
            paramcustomerid, paramserviceid, paramoutputmessage, paramisreturninfoexists);

        outputmessage = paramoutputmessage.Value.ToString();
        isreturninfoexists = paramisreturninfoexists.Value.ToString();

        return ds;
    }
}
