using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GALLERIA_E_ART
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    LinkButton1.Visible = true; //MemberLogin
                    LinkButton2.Visible = true; //MemberSignUp
                    LinkButton6.Visible = true; //AdminLogin

                    LinkButton3.Visible = false; //LogOut
                    LinkButton7.Visible = false; //HelloUser
                    LinkButton8.Visible = false; //ArtInventory
                    LinkButton10.Visible = false; //MemberManagement
                    LinkButton4.Visible = false; //ViewArt
                }
                else if (Session["role"].Equals("Artist") && Session["status"].Equals("active"))
                {
                    LinkButton3.Visible = true; //LogOut
                    LinkButton7.Visible = true; //HelloUser
                    LinkButton7.Text = "Hello " + Session["fullName"].ToString();
                    LinkButton4.Visible = true; //ViewArt
                    LinkButton8.Visible = true; //ArtInventory
                    LinkButton6.Visible = true; //AdminLogin

                    LinkButton1.Visible = false; //MemberLogin
                    LinkButton2.Visible = false; //MemberSignUp
                    LinkButton10.Visible = false; //MemberManagement
                }
                else if (Session["role"].Equals("General User") || ((Session["role"].Equals("Artist") && Session["status"].Equals("pending")) || (Session["role"].Equals("Artist") && Session["status"].Equals("inactive"))))
                {
                    LinkButton3.Visible = true; //LogOut
                    LinkButton7.Visible = true; //HelloUser
                    LinkButton7.Text = "Hello " + Session["fullName"].ToString();
                    LinkButton4.Visible = true; //ViewArt
                    LinkButton6.Visible = true; //AdminLogin

                    LinkButton1.Visible = false; //MemberLogin
                    LinkButton2.Visible = false; //MemberSignUp
                    LinkButton8.Visible = false; //ArtInventory
                    LinkButton10.Visible = false; //MemberManagement
                }
                else if (Session["role"].Equals("Admin"))
                {
                    LinkButton3.Visible = true; //LogOut
                    LinkButton7.Visible = true; //HelloUser
                    LinkButton7.Text = "Hello Admin";
                    LinkButton7.Enabled = false;
                    LinkButton10.Visible = true; //MemberManagement

                    LinkButton1.Visible = false; //MemberLogin
                    LinkButton2.Visible = false; //MemberSignUp
                    LinkButton6.Visible = false; //AdminLogin
                    LinkButton8.Visible = false; //ArtInventory
                }
            }
            catch (Exception exception)
            {

            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminLogin.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("memberManagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("artManagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewArt.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("memberLogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("memberSignup.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("memberProfile.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["memberID"] = "";
            Session["fullName"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton1.Visible = true; //MemberLogin
            LinkButton2.Visible = true; //MemberSignUp
            LinkButton6.Visible = true; //AdminLogin

            LinkButton3.Visible = false; //LogOut
            LinkButton7.Visible = false; //HelloUser
            LinkButton8.Visible = false; //ArtInventory
            LinkButton10.Visible = false; //MemberManagement
            LinkButton4.Visible = false; //ViewArt

            Response.Redirect("home.aspx");
        }
    }
}