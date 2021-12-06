<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="Admin_ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <h2 class="text-center text-success"><i class="fa fa-pencil-square-o pr-1"></i>Manage Users</h2>
            <h4 class="lead text-center text-info justify-content-center">This page is only managed by the <b>Administrator</b>.</h4>
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

    <div class="row shadow rounded-bottom">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <asp:GridView ID="grvUsers" CssClass="table table-responsive small text-center" Width="100%"
                GridLines="None" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" Style="display: table;">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="rolename" HeaderText="Role" />
                    <asp:HyperLinkField
                        DataNavigateUrlFields="userid,isactive"
                        DataNavigateUrlFormatString="ManageUsers.aspx?uid={0}&activestats={1}"
                        DataTextField="userid"
                        HeaderText="UserID">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:HyperLinkField>
                    <asp:BoundField DataField="isactive" HeaderText="Active Status" />
                    <asp:BoundField DataField="validity" HeaderText="Validity Left (in days)" />

                </Columns>
            </asp:GridView>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            var isverified;
            $('#ContentPlaceHolder1_grvUsers tbody tr').find('th').addClass('text-info font-weight-bold');
            $('#ContentPlaceHolder1_grvUsers tbody tr').each(function () {

                // set the font type in table body with secondary 50

                $(this).find('td').addClass('text-black-50 font-weight-bold');

                if (typeof $(this).find('td:eq(3)').html() === 'undefined') { }
                else {
                    isverified = $(this).find('td:eq(3)').html();

                    if (isverified == "Yes") {
                        $(this).find('td:eq(3)').addClass('badge badge-pill badge-success small');
                    }
                    if (isverified == "No") {
                        $(this).find('td:eq(3)').addClass('badge badge-pill badge-danger small');
                    }
                }

            });

        });
    </script>
</asp:Content>

