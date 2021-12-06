<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

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
            background: url(image/landing2.jpg) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            background-size: cover;
            -o-background-size: cover;
        }
    </style>

</head>

<body>

    <div class="container-fluid">
        <form id="form1" runat="server">
            <nav class="navbar navbar-expand-lg navbar-light bg-transparent">
                <a class="navbar-brand" href="index.aspx">
                    <img src="image/Logo-1.bmp" width="200px" height="100px" />
                </a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ml-auto ">
                        <li class="nav-item active">
                            <a class="nav-link text-black" href="#">ABOUT US </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-black" href="#">CONTACT US</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-black" href="#">SERVICES</a>
                        </li>

                        <%--   <li class="nav-item dropdown">
                            <a class="nav-link  text-white" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Dropdown
                            </a>
                          <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <a class="dropdown-item text-white" href="#">Action</a>
                                <a class="dropdown-item text-white" href="#">Another action</a>
                                <div class="dropdown-divider text-white"></div>
                                <a class="dropdown-item text-white" href="#">Something else here</a>
                            </div>
                        </li>--%>
                        <li class="nav-item">
                            <a class="nav-link text-black" href="LoginPage.aspx" tabindex="-1" aria-disabled="true">LOGIN</a>
                        </li>
                    </ul>
                    <%--<form class="form-inline my-2 my-lg-0">
                        <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
                        <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
                    </form>--%>
                </div>

            </nav>
            <hr />
        </form>
    </div>



</body>
</html>

