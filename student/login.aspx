<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="student.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Panel</title>
     <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="css/style.css" rel='stylesheet' type='text/css' />
   
</head>
<body style="background-color:burlywood">
    <form id="form1" runat="server">
    <div align="center">
        <h1>Welcome to Student Admin Panel</h1>
        <div class="container"><br /><br /><br />
            <div class="col-md-3"></div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-4">User Name</div>
                    <div class="col-md-6"><input type="text" id="usr" class="form-control" /><br /></div>
                    <div class="col-md-4">Password</div>
                    <div class="col-md-6"><input type="password" id="usr" class="form-control" /><br /></div>
                    <div class="col-md-10"><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit"  class="form-control" style="width:150px;color:#ffffff; background-color:red;font-size:18px" />
                    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /></div>
                </div>


            </div>
            <div class="col-md-3"></div>
        </div>
    
    </div>
    </form>
</body>
</html>
