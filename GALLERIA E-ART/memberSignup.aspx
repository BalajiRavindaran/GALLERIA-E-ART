﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="memberSignup.aspx.cs" Inherits="GALLERIA_E_ART.memberSignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <style>

        body {
            margin: 0;
            min-height: 100vh;
            display: grid;
            background: #1a1c1d;
            color: #ffffff;
        }

        h2 {
            font-size: 3.1vw;
            font-weight: normal;
        }

        h3, h4, h5, h6 {
            font-size: 2.1vw;
            color: red;
        }

        p{
            font-size: 1.2vw;
        }

        label, span, li {
            color: #000000;
        }

        .blink {
            animation: blinker 1.5s linear infinite;
        }

        @keyframes blinker {
            50% {
                opacity: 0;
            }
        }
    </style>

    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">

                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="assets/signup.png" width="100px"/>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member Sign Up</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center><p><span class="badge bg-info" style="color:white">Personal Credentials</span></p></center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Date Of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="dd-mm-yyyy" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact Number</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Member Type</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">
                                        <asp:ListItem Text="Select" Value="Select"/>
                                        
                                        <asp:ListItem Text="General User" Value="General User"/>
                                        <asp:ListItem Text="Artist" Value="Artist"/>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Select" Value="Select"/>
                                        
                                        <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh"/>
                                        <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh	"/>
                                        <asp:ListItem Text="Assam" Value="Assam"/>
                                        <asp:ListItem Text="Bihar" Value="Bihar"/>
                                        <asp:ListItem Text="Chhattisgarh" Value="Chhattisgarh"/>

                                        <asp:ListItem Text="Goa" Value="Goa"/>
                                        <asp:ListItem Text="Gujarat" Value="Gujarat"/>
                                        <asp:ListItem Text="Haryana" Value="Haryana"/>
                                        <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh"/>
                                        <asp:ListItem Text="Jharkhand" Value="Jharkhand"/>

                                        <asp:ListItem Text="Karnataka" Value="Karnataka"/>
                                        <asp:ListItem Text="Kerala" Value="Kerala"/>
                                        <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh"/>
                                        <asp:ListItem Text="Maharashtra" Value="Maharashtra"/>
                                        <asp:ListItem Text="Manipur" Value="Manipur"/>

                                        <asp:ListItem Text="Meghalaya" Value="Meghalaya"/>
                                        <asp:ListItem Text="Mizoram" Value="Mizoram"/>
                                        <asp:ListItem Text="Nagaland" Value="Nagaland"/>
                                        <asp:ListItem Text="Odisha" Value="Odisha"/>
                                        <asp:ListItem Text="Punjab" Value="Punjab"/>

                                        <asp:ListItem Text="Rajasthan" Value="Rajasthan"/>
                                        <asp:ListItem Text="Sikkim" Value="Sikkim"/>
                                        <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu"/>
                                        <asp:ListItem Text="Telangana" Value="Telangana"/>
                                        <asp:ListItem Text="Tripura" Value="Tripura"/>

                                        <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh"/>
                                        <asp:ListItem Text="Uttarakhand" Value="Uttarakhand"/>
                                        <asp:ListItem Text="West Bengal" Value="West Bengal"/>

                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="City"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pincode</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Pincode" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Full Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                               <center><p><span class="badge bg-info" style="color:white">Login Credentials</span></p></center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Member ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <ul CssClass="form-control">
                            <li>Password must be 8 characters long</li>
                            <li>Password should contain atleast 1 special characters</li>
                            <li>Password should contain atleast 1 number</li>
                        </ul>

                        <center>
                            <asp:Label ID="Label1" CssClass="blink" runat="server" Text="Label" Visible="False"></asp:Label>
                        </center>
                        <br />

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-success btn-block" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click"/>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                
                <br />
                <a class="btn btn-primary" href="home.aspx"><i class="fas fa-angle-left"></i> <i class="fa fa-home"></i></a>
                <br /><br />

            </div>
        </div>
    </div>


</asp:Content>
