<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="forgetpw.aspx.cs" Inherits="forgetpw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container h-100">

        <%--bootstrap alert dialog--%>

        <div class="alert alert-success alert-dismissible fade show" role="alert" runat="server" visible="false" id="divSuccess">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">&times;</button>
            <span runat="server" id="lblSuccess" aria-hidden="true">&times;</span>
        </div>

        <div class="alert alert-danger alert-dismissible" runat="server" visible="false" id="divError">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">&times;</button>
            <span runat="server" id="lblError" aria-hidden="true">&times;</span>
        </div>

        <div class="row justify-content-center align-self-center mt-5">
            <div class="col-md-6 col-lg-6 col-sm-6 login-form-2 shadow p-3 mb-5 rounded bg-white">
                <h3>Reset Password</h3>

                <div class="form-group">
                    <span class="text-secondary font-weight-bold"><i class="fa fa-vcard pr-1"></i>User Id :</span>
                    <input type="text" id="txtUserId" required="required" runat="server" class="form-control form-control-sm" placeholder="To check if the user is already registered or not ! *" value="" />
                </div>

                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <span class="lead text-success font-weight-light">Click here to generate Strong random password : </span>
                        <asp:Button ID="btnGeneratepw" runat="server" Text="Generate" CssClass="btn btn-success btn-sm" OnClick="btnGeneratepw_Click" />
                    </div>
                </div>

                <div class="form-group">
                    <span class="text-secondary font-weight-bold"><i class="fa fa-key pr-1"></i>Password :</span>
                    <input type="text" id="txtPassword" runat="server" class="form-control form-control-sm" placeholder="You may also create your custom password by writing here *" value="" />
                </div>

                <div class="form-group text-center">
                    <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-info btn-sm rounded w-50" OnClick="btnReset_Click" />
                </div>

                <hr />
                <div class="form-group">
                    <a id="hbacktologin" href="LoginPage.aspx" class="btn btn-link "><span class="text-primary text-decoration-none pr-1"><i class="fa fa-backward"></i>Back to Login</span></a>
                </div>

            </div>
            <div class="col-md-6 col-lg-6 col-sm-6 login-form-2 bg-info text-white shadow p-3 mb-5 rounded">
                <h1>Password Policies</h1>

                <span class="lead text-white-50">New Password must follow these below criterias :</span>
                <hr />

                <ul>
                    <li>Make your password eight characters or longer. </li>
                    <li>Don’t make passwords easy to guess. </li>
                    <li>Use a passphrase, then add in some punctuation and capitalization. </li>
                    <li>Use Numeric values for better creating an alphanumeric combination. </li>
                    <li>Do not include personal information such as your name or pets’ names easily to find on social media. </li>
                    <li>Avoid using common words in your password. </li>
                    <li>Avoid using common words in your password. </li>
                    <li>Never share your password</li>
                </ul>

            </div>
        </div>

    </div>


    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="js/md5hash.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#ContentPlaceHolder1_btnReset').click(function () {
                if ($('#ContentPlaceHolder1_txtPassword').val().length > 0) {
                    var password = $('#ContentPlaceHolder1_txtPassword').val().trim();
                    $('#ContentPlaceHolder1_txtPassword').val(MD5(password));
                }
            });

            $('#hbacktologin').click(function () {
                sessionStorage.clear();
                sessionStorage.removeItem('Role');
            });
        });
    </script>
</asp:Content>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous" />
    <script src="js/md5hash.js"></script>
    <title>Reset Password</title>
</head>

<body>
   
</body>
--%>


