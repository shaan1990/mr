using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Task
/// </summary>
public class Task
{

    private string arn { get; set; }
    private string dateofarn { get; set; }
    private string filenumber { get; set; }
    private bool billrequired { get; set; }
    private string query { get; set; }
    private string action { get; set; }
    private bool isactiontaken { get; set; }
    private string actiontakenby { get; set; }
    private string dateofaction { get; set; }
    private bool isverified { get; set; }
    private string verifiedby { get; set; }
    private bool isbillprepared { get; set; }
    private string billpreparedby { get; set; }
    private string workpriority { get; set; }
    private string employeename { get; set; }

    private string connectionString = string.Empty;
    public Task()
    {
        connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
    }

    public Task(string arn, string dateofarn, string filenumber, bool billrequired, string query, string action,
        bool isactiontaken, string actiontakenby, string dateofaction, bool isverified, string verifiedby,
        bool isbillprepared, string billpreparedby, string workpriority, string employeename)
    {
        this.arn = arn;
        this.dateofarn = dateofarn;
        this.filenumber = filenumber;
        this.billrequired = billrequired;
        this.query = query;
        this.action = action;
        this.isactiontaken = isactiontaken;
        this.actiontakenby = actiontakenby;
        this.dateofaction = dateofaction;
        this.isverified = isverified;
        this.verifiedby = verifiedby;
        this.isbillprepared = isbillprepared;
        this.billpreparedby = billpreparedby;
        this.workpriority = workpriority;
        this.employeename = employeename;
    }

    public string getARSerialNumber()
    {
        string ARNSerialNumber = SqlHelper.ExecuteScalar(connectionString, CommandType.Text, "select [dbo].[GetARNumber]()").ToString();
        return ARNSerialNumber;
    }

    public void CreateNewTasks(Task task)
    {
        SqlParameter paramARN = new SqlParameter("@arn", SqlDbType.VarChar);
        SqlParameter paramDateOfARN = new SqlParameter("@dateofarn", SqlDbType.DateTime, 10);
        SqlParameter paramFileNumber = new SqlParameter("@filenumber", SqlDbType.VarChar);
        SqlParameter paramBillRequired = new SqlParameter("@billrequired", SqlDbType.Bit);
        SqlParameter paramQuery = new SqlParameter("@query", SqlDbType.VarChar);
        SqlParameter paramAction = new SqlParameter("@action", SqlDbType.VarChar);
        SqlParameter paramIsActionTaken = new SqlParameter("@isactiontaken", SqlDbType.Bit);
        SqlParameter paramActionTakenBy = new SqlParameter("@actiontakenby", SqlDbType.VarChar);
        SqlParameter paramIsVerified = new SqlParameter("@isverified", SqlDbType.Bit);
        SqlParameter paramVerifiedBy = new SqlParameter("@verifiedby", SqlDbType.VarChar);
        SqlParameter paramIsBillPrepared = new SqlParameter("@isbillprepared", SqlDbType.Bit);
        SqlParameter paramBillPreparedBy = new SqlParameter("@billpreparedby", SqlDbType.VarChar);
        SqlParameter paramWorkPriority = new SqlParameter("@workpriority", SqlDbType.Int);
        SqlParameter paramEmployeeName = new SqlParameter("@employeename", SqlDbType.VarChar);

        paramARN.Value = task.arn;
        paramDateOfARN.Value = task.dateofarn;
        paramFileNumber.Value = task.filenumber;
        paramBillRequired.Value = task.billrequired;
        paramQuery.Value = task.query;
        paramAction.Value = task.action;
        paramIsActionTaken.Value = task.isactiontaken;
        paramActionTakenBy.Value = task.actiontakenby;
        paramIsVerified.Value = task.isverified;
        paramVerifiedBy.Value = task.verifiedby;
        paramIsBillPrepared.Value = task.isbillprepared;
        paramBillPreparedBy.Value = task.billpreparedby;
        paramWorkPriority.Value = task.workpriority;
        paramEmployeeName.Value = task.employeename;

        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "udsp_create_arn_task",
            paramARN, paramDateOfARN, paramFileNumber, paramBillRequired, paramQuery, paramAction, paramIsActionTaken,
            paramActionTakenBy, paramIsVerified, paramVerifiedBy, paramIsBillPrepared,
            paramBillPreparedBy, paramWorkPriority, paramEmployeeName);

    }

    public DataSet LoadTaskHistory(int RoleId, string userid = "")
    {
        string query = string.Empty;
        if (RoleId == 1)
        {
            query = @"select arn, dateofarn, upper(filenumber) as filenumber ,case when billrequired = 1 then 'Yes' else 'No' end as billrequired,employeename,
            case when isactiontaken = 1 then 'Yes' else 'No' end as isactiontaken, case when workpriority = 1 then 'Urgent'
            when workpriority = 2 then 'Very Urgent' else 'Normal' end as workpriority, case when isverified = 0 then 'No' else 'Yes' end as isverified
            from[dbo].[ttbl_arn_queries]";

            return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, query);
        }
        else
        {
            query = @"select arn, dateofarn, upper(filenumber) as filenumber ,case when billrequired = 1 then 'Yes' else 'No' end as billrequired,employeename,
            case when isactiontaken = 1 then 'Yes' else 'No' end as isactiontaken, case when workpriority = 1 then 'Urgent'
            when workpriority = 2 then 'Very Urgent' else 'Normal' end as workpriority, case when isverified = 0 then 'No' else 'Yes' end as isverified
            from[dbo].[ttbl_arn_queries]
            where employeename= @userid";

            SqlParameter paramUserID = new SqlParameter("@userid", SqlDbType.VarChar);
            paramUserID.Value = userid;
            return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, query, paramUserID);
        }
    }

    public DataSet GetARNDetailnOnARNumber(string arn)
    {
        SqlParameter paramARN = new SqlParameter("@arn", SqlDbType.VarChar, 10);
        paramARN.Value = arn;
        return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "select * from ttbl_arn_queries where arn=@arn", paramARN);
    }

    public void UpdateTaskActionDetails(Task task)
    {
        SqlParameter paramARN = new SqlParameter("@arn", SqlDbType.VarChar);
        SqlParameter paramAction = new SqlParameter("@action", SqlDbType.VarChar);
        SqlParameter paramIsActionTaken = new SqlParameter("@isactiontaken", SqlDbType.Bit);
        SqlParameter paramActionTakenBy = new SqlParameter("@actiontakenby", SqlDbType.VarChar);
        SqlParameter paramDateOfAction = new SqlParameter("@dateofaction", SqlDbType.VarChar);

        paramARN.Value = task.arn;
        paramAction.Value = task.action;
        paramIsActionTaken.Value = task.isactiontaken;
        paramActionTakenBy.Value = task.actiontakenby;
        paramDateOfAction.Value = task.dateofaction;

        SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, "update [ttbl_arn_queries] set action = @action, isactiontaken = @isactiontaken, actiontakenby =@actiontakenby, dateofaction= @dateofaction where arn = @arn", paramAction, paramIsActionTaken, paramActionTakenBy, paramDateOfAction, paramARN);
    }

    public void UpdateVarification(bool VerificationStatus, string ARN)
    {
        SqlParameter paramARN = new SqlParameter("@arn", SqlDbType.VarChar);
        SqlParameter paramIsVerified = new SqlParameter("@isverified", SqlDbType.Bit);
        paramARN.Value = ARN;
        paramIsVerified.Value = VerificationStatus;
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, "update [ttbl_arn_queries] set isverified =@isverified,verifiedby='Administrator' where arn=@arn", paramARN, paramIsVerified);
    }

    public bool IsActionTakenByEmployee(string ARN)
    {
        bool actiontakenstatus = false;
        SqlParameter paramARN = new SqlParameter("@arn", SqlDbType.VarChar);
        paramARN.Value = ARN;
        actiontakenstatus = Convert.ToBoolean(SqlHelper.ExecuteScalar(connectionString, CommandType.Text, " select isactiontaken from  [ttbl_arn_queries] where arn=@arn", paramARN).ToString());
        return actiontakenstatus;
    }



}