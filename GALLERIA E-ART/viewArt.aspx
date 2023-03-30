<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewArt.aspx.cs" Inherits="GALLERIA_E_ART.viewArt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
    
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

    </style>

    <br />
    <div class="container-fluid">
        <div class="row">

            <div class="col-md-9 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Art List</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GALLERIA E-ART %>" SelectCommand="SELECT * FROM [art_management_table]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="art_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="art_id" HeaderText="ART ID" ReadOnly="True" SortExpression="art_id" >
                                        <ControlStyle Font-Bold="False" />
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="ARTS">
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                       <div class="row">
                                           <div class="col-lg-14">
                                             <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("art_image_link") %>' />
                                          </div>
                                          <div class="col-lg-10">
                                             <div class="row">
                                                <div class="col-14">
                                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("art_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-14">
                                                   <span>Artist - </span>
                                                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("artist_name") %>'></asp:Label>
                                                   &nbsp;| <span><span>&nbsp;</span>Genre - </span>
                                                   <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                   &nbsp;| 
                                                   <span>
                                                      Type -<span>&nbsp;</span>
                                                      <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("type") %>'></asp:Label>
                                                   </span>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-14">
                                                   Publisher -
                                                   <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                   &nbsp;| Publish Date -
                                                   <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                   &nbsp;| Artist Contact Number -
                                                   <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("contact_number") %>'></asp:Label>
                                                   &nbsp;| Version -
                                                   <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("version") %>'></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-14">
                                                   Cost -
                                                   <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("art_cost") %>'></asp:Label>
                                                   &nbsp;| Available Stock -
                                                   <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-14">
                                                   Description -
                                                   <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("art_description") %>'></asp:Label>
                                                </div>
                                             </div>
                                          </div>
                                       </div>
                                    </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>

                <br />
                <a class="btn btn-primary" href="home.aspx"><i class="fas fa-angle-left"></i> <i class="fa fa-home"></i></a>
                <br />
                <br />

            </div>
        </div>
    </div>

</asp:Content>
