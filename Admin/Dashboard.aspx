<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Admin_Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h1 class="text-success font-weight-lighter" id="h1Welcome" runat="server"></h1>
                <span class="lead text-black-50 float-md-right" id="spanValidity" runat="server">Your Account is Active for : 64 days</span>
                <br />
                <hr />
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-lg-3 col-md-3 col-sm-3">
                <div class="card bg-success">
                    <div class="card-body text-center">
                        <h1><span id="spanTotalCompleted" runat="server" class="text-white font-weight-light">NA</span></h1>
                    </div>
                    <div class="card-footer text-center text-white">
                        <h1 class="lead">Total Tasks Verified</h1>
                    </div>
                </div>

                <br />
                <div class="card bg-danger">
                    <div class="card-body text-center">
                        <h1><span id="spanTotalPending" runat="server" class="text-white font-weight-light">NA</span></h1>
                    </div>
                    <div class="card-footer text-center text-white">
                        <h1 class="lead">Total Tasks Yet to Complete and Verify</h1>
                    </div>
                </div>
            </div>

            <div class="col-lg-9 col-md-9 col-sm-9">
                <div class="card">
                    <div class="card-title lead bg-info">
                        <%--<span id="spanServices" runat="server" class="font-weight-light">We are currently providing these serives</span>--%>
                        <h3><span class="font-weight-light p-3 text-white-50">We are currently providing these serives :</span></h3>
                    </div>
                    <div class="card-body text-center">
                        <h1></h1>
                    </div>

                </div>
            </div>
        </div>
        <%-- <div class="row justify-content-left">
        <div class="col-lg-3 col-md-3 col-sm-3 align-self-center">
        </div>
    </div>--%>
   
</asp:Content>

