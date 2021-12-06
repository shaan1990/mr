<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="TaskHistory.aspx.cs" Inherits="Admin_TaskHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <h2 class="text-center text-primary"><i class="fa fa-pencil-square-o pr-1"></i>Tasks History</h2>
        </div>
    </div>

    <hr />

    <div class="alert alert-success alert-dismissible fade show" role="alert" runat="server" visible="false" id="divSuccess">
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">&times;</button>
        <span runat="server" id="lblSuccess" aria-hidden="true">&times;</span>
    </div>

    <div class="alert alert-danger alert-dismissible" runat="server" visible="false" id="divError">
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">&times;</button>
        <span runat="server" id="lblError" aria-hidden="true">&times;</span>
    </div>

    <br />

    <div class="row shadow rounded-bottom" style="background-color: #a5d1cc;">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <asp:GridView ID="grvTasks" CssClass="table table-responsive small text-center" Width="100%"
                GridLines="None" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" Style="display: table;">
                <Columns>
                    <%--<asp:BoundField DataField="arn" HeaderText="ARN" />--%>
                    <%--<asp:CommandField HeaderText="ARN" SelectText="ARN" ShowSelectButton="True" />--%>
                    <asp:HyperLinkField
                        DataNavigateUrlFields="arn"
                        DataNavigateUrlFormatString="CreateTasks.aspx?arn={0}"
                        DataTextField="arn"
                        HeaderText="ARN">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:HyperLinkField>
                    <asp:BoundField DataField="dateofarn" HeaderText="Date of ARN" />
                    <asp:BoundField DataField="filenumber" HeaderText="File Number" />
                    <asp:BoundField DataField="billrequired" HeaderText="Bill Required" />
                    <asp:BoundField DataField="employeename" HeaderText="Employee ID" />
                    <asp:BoundField DataField="isactiontaken" HeaderText="Action Taken ?" />
                    <asp:BoundField DataField="workpriority" HeaderText="Work Priority" />
                    <asp:BoundField DataField="isverified" HeaderText="Virified ?" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            var workpriority;
            var isactiontaken;
            var isbillrequired;
            var isverified;
            $('#ContentPlaceHolder1_grvTasks tbody tr').each(function () {

                // set the font type in table body with secondary 50
                $(this).addClass('text-black-50 font-weight-bold');


                if (typeof $(this).find('td:eq(6)').html() === 'undefined') {

                }
                else {
                    workpriority = $(this).find('td:eq(6)').html();
                    isbillrequired = $(this).find('td:eq(3)').html();
                    isactiontaken = $(this).find('td:eq(5)').html();
                    isverified = $(this).find('td:eq(7)').html();

                    if (workpriority == "Urgent") {
                        $(this).find('td:eq(6)').addClass('badge badge-pill badge-warning small');
                    }
                    if (workpriority == "Very Urgent") {
                        $(this).find('td:eq(6)').addClass('badge badge-pill badge-danger small');
                    }
                    if (workpriority == "Normal") {
                        $(this).find('td:eq(6)').addClass('badge badge-pill badge-info small');
                    }

                    //BillRequired
                    if (isbillrequired == 'Yes') {
                        $(this).find('td:eq(3)').addClass('text-success font-weight-bold');
                    }
                    else {
                        $(this).find('td:eq(3)').addClass('text-danger font-weight-bold');
                    }

                    //ActionTaken
                    if (isactiontaken == 'Yes') {
                        $(this).find('td:eq(5)').addClass('text-success font-weight-bold');
                    }
                    else {
                        $(this).find('td:eq(5)').addClass('text-danger font-weight-bold');
                    }

                    // isverified
                    if (isverified == 'Yes') {
                        $(this).find('td:eq(7)').addClass('text-success font-weight-bold');
                    }
                    else {
                        $(this).find('td:eq(7)').addClass('text-danger font-weight-bold');
                    }

                }

            });



        });
    </script>
</asp:Content>


