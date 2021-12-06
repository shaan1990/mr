<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>


    <link href="css/logintemplate.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous" />
    <script src="js/md5hash.js"></script>
    <%--Password hashing--%>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnSubmit').click(function () {
                var password = $('#txtPassword').val().trim();
                var confirmpassword = $('#txtConfirmPassword').val().trim();

                $('#txtPassword').val(MD5(password));
                $('#txtConfirmPassword').val(MD5(confirmpassword));
            });

        });
    </script>

    <style type="text/css">
        body {
            background: url(image/pexels-fauxels-3184460.png) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            background-size: cover;
            -o-background-size: cover;
        }
    </style>

</head>
<script type="text/javascript">

    function HashPwdwithSalt(salt) {
        if (document.getElementById("txtLoginPassword").value != "") {
            document.getElementById("txtLoginPassword").value = MD5(document.getElementById("txtLoginPassword").value);
            document.getElementById("txtLoginPassword").value = MD5(document.getElementById("txtLoginPassword").value + salt);
            document.getElementById("hdnpd").value = MD5(document.getElementById("txtLoginPassword").value + salt);

            return MD5(document.getElementById("txtLoginPassword").value + salt);
        }
    }
</script>

<body>
    <form id="form1" runat="server">
        <div class="container login-container">

            <%--bootstrap alert dialog--%>

            <div class="alert alert-success alert-dismissible fade show" role="alert" runat="server" visible="false" id="divSuccess">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">&times;</button>
                <span runat="server" id="lblSuccess" aria-hidden="true">&times;</span>
            </div>

            <div class="alert alert-danger alert-dismissible" runat="server" visible="false" id="divError">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">&times;</button>
                <span runat="server" id="lblError" aria-hidden="true">&times;</span>
            </div>

            <div class="row">
                <div class="col-md-8 col-sm-8"></div>
                <div class="col-md-4 col-sm-4 login-form-1  text-black" style="background-color: white; opacity: 0.7;">
                    <h3 class="font-weight-bold">Login</h3>

                    <div class="form-group">
                        <span class="font-weight-bold"><i class="fa fa-user pr-1"></i>User ID :</span>
                        <asp:TextBox ID="txtLoginUserId" runat="server" class="form-control form-control-sm"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <span class="font-weight-bold"><i class="fa fa-key pr-1"></i>Password :</span>
                        <asp:TextBox ID="txtLoginPassword" runat="server" class="form-control form-control-sm" TextMode="Password"></asp:TextBox>
                    </div>

                    <asp:HiddenField ID="hdnpd" runat="server" />
                    <div class="form-group">
                        <asp:Button ID="btnLogin" runat="server" class="btnSubmit" Text="Login" OnClick="btnLogin_Click" />
                    </div>
                    <div class="form-group text-black font-weight-bold">
                        New User ? Click <a href="registration.aspx" class="ForgetPwd text-success">here</a> for new Registration
                    </div>

                </div>

            </div>


            <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#MyPopup" hidden="hidden">
                Open Modal</button>

            <!-- Modal Popup -->
            <div id="MyPopup" class="modal fade" role="dialog" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header text-left">
                            <h4 class="modal-title float-left">Login Details
                            </h4>
                            <button type="button" class="close" data-dismiss="modal">
                                &times;</button>

                        </div>
                        <div class="modal-body">
                            <h1 class="text-warning font-weight-light">Record Saved Successfully</h1>
                            <span class="lead text-success">Kindly note your credentials for your account login</span><br />
                            <span id="spanUserid" runat="server"></span>
                            <br />
                            <span id="spanPassword" runat="server"></span>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">
                                Close</button>
                        </div>
                    </div>
                </div>
            </div>
            <%--End of Modal Popup--%>
        </div>

    </form>
</body>
</html>

