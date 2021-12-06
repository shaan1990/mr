<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="CreateTasks.aspx.cs" Inherits="Admin_CreateTasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#customSwitch1').change(function () {
                if ($('#customSwitch1').is(":checked")) {
                    $('#customSwitch1').next().text("Yes");
                    $('#customSwitch1').next().css("color", "green");
                }
                else {
                    $('#customSwitch1').next().text("No");
                }
            });


            $('#customSwitch2').change(function () {
                if ($('#customSwitch2').is(":checked")) {
                    $('#customSwitch2').next().text("Yes");
                    $('#customSwitch2').next().css("color", "green");
                }
                else {
                    $('#customSwitch2').next().text("No");
                }
            });



        });
    </script>

    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h2 class="text-center text-primary font-weight-bold"><i class="fa fa-pencil-square-o pr-1"></i>Create Task</h2>
            </div>
        </div>

        <hr />

        <%--bootstrap alert dialog--%>
        <div class="alert alert-success alert-dismissible fade show" role="alert" runat="server" visible="false" id="divSuccess">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">&times;</button>
            <span runat="server" id="lblSuccess" aria-hidden="true">&times;</span>
        </div>

        <div class="alert alert-danger alert-dismissible" runat="server" visible="false" id="divError">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">&times;</button>
            <span runat="server" id="lblError" aria-hidden="true">&times;</span>
        </div>

        <div class="flex-row justify-content-center align-items-center mx-auto">
            <div class="row shadow rounded-bottom pt-3 pb-3" style="background-color: #a5d1cc;">
                <%--style="background-color: #96b0e3;">--%>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtARNno" class="font-weight-normal"><i class="fa fa-list-ol pr-1"></i><strong class="text-danger">* </strong>ARN Number:</label>
                        <asp:TextBox ID="txtARNno" CssClass="form-control form-control-sm" runat="server" required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtCurrentDataTime" class="font-weight-normal"><i class="fa fa-calendar pr-1"></i>Date & Time:</label>
                        <asp:TextBox ID="txtCurrentDataTime" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtFileNumber" class="font-weight-normal"><i class="fa fa-files-o pr-1"></i><strong class="text-danger">* </strong>File Number:</label>
                        <asp:TextBox ID="txtFileNumber" CssClass="form-control form-control-sm" PlaceHolder="Which belongs to query." runat="server" required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group text-center">
                        <label for="chkBillRequired" class="font-weight-normal"><i class="fa fa-check pr-1"></i>Bill Required:</label>
                        <asp:RadioButtonList ID="chkBillRequired" CssClass="w-100 text-black-50 font-weight-bolder text" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="chkBillRequired_SelectedIndexChanged">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>


                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlPriority" class="font-weight-normal"><i class="fa fa-signal pr-1"></i>Work Priority:</label>

                        <span id="spanVeryUrgent" runat="server" class="badge badge-pill badge-danger" visible="false">Very Urgent</span>
                        <span id="spanUrgent" runat="server" class="badge badge-pill badge-warning" visible="false">Urgent</span>
                        <span id="spanNormal" runat="server" class="badge badge-pill badge-info" visible="false">Normal</span>

                        <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control form-control-sm" OnSelectedIndexChanged="ddlPriority_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="0">-- Select Priority --</asp:ListItem>
                            <asp:ListItem Value="1">Urgent</asp:ListItem>
                            <asp:ListItem Value="2">Very Urgent</asp:ListItem>
                            <asp:ListItem Value="3">Normal</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label for="ddlEmployee" class="font-weight-normal"><i class="fa fa-wheelchair pr-1"></i><strong class="text-danger">* </strong>Employee Name:</label>
                        <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control form-control-sm" required="required">
                        </asp:DropDownList>
                    </div>
                </div>

                <%--A & QN--%>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtQuery" class="font-weight-normal"><i class="fa fa-quora pr-1"></i>Assignment & Queries Notes :</label>
                        <asp:TextBox ID="txtQuery" CssClass="form-control form-control-sm" TextMode="MultiLine" PlaceHolder="Write Customer Queries which needed to be resolved..." Rows="3" runat="server"></asp:TextBox>
                    </div>
                </div>

                <%--Action Taken--%>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label for="txtActionTaken" class="font-weight-normal"><i class="fa fa-check-square-o pr-1"></i>Report on Assignment & Queries :</label>
                        <asp:TextBox ID="txtActionTaken" CssClass="form-control form-control-sm" TextMode="MultiLine" PlaceHolder="Write an Action that has to be taken by an employee on this query..." Rows="3" runat="server"></asp:TextBox>
                    </div>
                </div>


                <%--Footer Part--%>


                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtActionTakenBy" class="font-weight-normal"><i class="fa fa-user-circle-o pr-1"></i>Report Prepared By:</label>
                        <asp:TextBox ID="txtActionTakenBy" CssClass="form-control form-control-sm" PlaceHolder="Employer Name" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-3 col-md-3 col-sm-3">

                    <div class="form-group">
                        <label for="txtActionTakenOn" class="font-weight-normal"><i class="fa fa-calendar pr-1"></i>Date & Time:</label>
                        <asp:TextBox ID="txtActionTakenOn" CssClass="form-control form-control-sm" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                </div>



                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group text-center">
                        <label for="chkBillPrepared" class="font-weight-normal"><i class="fa fa-check pr-1"></i>Bill Prepared:</label>
                        <asp:RadioButtonList ID="chkBillPrepared" CssClass="w-100 text-black-50 font-weight-bolder text" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem> Yes</asp:ListItem>
                            <asp:ListItem Selected="True"> No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <label for="txtVerifiedBy" class="font-weight-normal"><i class="fa fa-user-secret pr-1"></i>Verified & Submitted By:</label>
                        <div class="card">
                            <div class="card-body">
                                <span id="spanNotVerified" runat="server" class="badge badge-pill badge-danger" visible="false">Not Verified</span>
                                <span id="spanPending" runat="server" class="badge badge-pill badge-warning" visible="false">Pending</span>
                                <span id="spanVerified" runat="server" class="badge badge-pill badge-success" visible="false">Verified</span>
                                <br />
                                <span runat="server" id="verifyquestion" class="small" visible="false">Would you like to verify this action ?</span>
                                <br />
                                <span runat="server" id="verifyinfo" class="small" visible="false">(For Administrator use only)</span>

                            </div>
                            <div class="card-footer">
                                <%--<span class="lead">Would you like to verify this action ?</span>--%>
                                <asp:RadioButtonList ID="radioIsVerified" CssClass="w-100 text-black-50 font-weight-normal text" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem Selected="True">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>

                        <%--<asp:TextBox ID="txtVerifiedBy" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>--%>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 text-center">
                    <%--<button id="btnRegister" runat="server" class="btn btn-primary btn-sm"  onclick="btnRegister_Click1();"><i class="fa fa-floppy-o pr-1"</i>New Registeration</button>--%>
                    <asp:Button ID="btnRegister" runat="server" class="btn btn-primary btn-sm" Text="Create Task" OnClick="btnRegister_Click"></asp:Button>
                    <asp:Button ID="btnTaskUpdate" runat="server" class="btn btn-warning btn-sm" Text="Update" Visible="false" OnClick="btnTaskUpdate_Click" />
                </div>

                <br />
                <br />
                <br />
            </div>
        </div>
    </div>



    <%--    <div class="row mt-2">
        <div class="col-lg-12 col-md-12 col-sm-12 text-center">
            <button id="btnRegister" runat="server" class="btn btn-primary btn-sm"><i class="fa fa-floppy-o pr-1"></i>New Registeration</button>
        </div>
    </div>--%>
</asp:Content>
