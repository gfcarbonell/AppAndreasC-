<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:: Login 365 ::.</title>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
 
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="css/bootstrap.css"/>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="css/font-awesome.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="css/ionicons.css"/>
    <!-- Theme style -->
    <link rel="stylesheet" href="css/AdminLTE.css"/>
    <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="css/_all-skins.css"/>
    <!-- Morris chart -->
    <link rel="stylesheet" href="css/morris.css"/>
    <!-- jvectormap -->
    <link rel="stylesheet" href="css/jquery-jvectormap.css"/>
    <!-- Date Picker -->
    <link rel="stylesheet" href="css/bootstrap-datepicker.css"/>
    <!-- Daterange picker -->
    <link rel="stylesheet" href="css/daterangepicker.css"/>
    <!-- bootstrap wysihtml5 - text editor -->
    <link rel="stylesheet" href="css/bootstrap3-wysihtml5.css"/>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
    <div class="login-box">
  <div class="login-logo">
    <a href="Login.aspx"><b>Admin</b>365</a>
  </div>
  <!-- /.login-logo -->
  <div class="login-box-body">
    <p class="login-box-msg">Iniciar sesión</p>

   
      <div class="form-group has-feedback">
          <asp:TextBox runat="server" ID="Email" required="" placeholder="Usuario" class="form-control" MaxLength="30"/>
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <asp:TextBox runat="server" ID="Password" TextMode="Password"  required="" class="form-control" placeholder="contraseña" MaxLength="30"/>
        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
      </div>
      <div class="row">
        <div class="col-xs-8">
          <div class="checkbox icheck">
            
          </div>
        </div>
        <!-- /.col -->
        <div class="col-xs-4">
          <asp:Button ID="btnLogin" runat="server" Text="Ingresar"  CssClass="btn btn-primary btn-block btn-flat" OnClick="LogIn"/>
        </div>
        <!-- /.col -->
      </div>
   

    <!-- /.social-auth-links -->

<%--    <a href="#">I forgot my password</a><br>
    <a href="register.html" class="text-center">Register a new membership</a>--%>

  </div>
  <!-- /.login-box-body -->
</div>
    </form>
</body>
</html>
