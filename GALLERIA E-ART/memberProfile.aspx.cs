using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GALLERIA_E_ART
{
    public partial class memberProfile : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["memberID"].ToString() == "" || Session["memberID"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("UserLogin.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        getMemberDetails();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["memberID"].ToString() == "" || Session["memberID"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("UserLogin.aspx");
            }
            else
            {
                validation();
                if (!Page.IsPostBack)
                {
                    getMemberDetails();
                }

            }
        }

        void getMemberDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_profile_table where member_id='" + Session["memberID"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                TextBox2.Text = dt.Rows[0]["date_of_birth"].ToString();
                TextBox3.Text = dt.Rows[0]["contact_number"].ToString();
                TextBox4.Text = dt.Rows[0]["member_type"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                TextBox5.Text = dt.Rows[0]["city"].ToString();
                TextBox6.Text = dt.Rows[0]["pincode"].ToString();
                TextBox7.Text = dt.Rows[0]["full_address"].ToString();
                TextBox8.Text = dt.Rows[0]["member_id"].ToString();
                TextBox9.Text = dt.Rows[0]["password"].ToString(); ;

                Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "inactive")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-info");
                }


            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message + "');</script>");

            }
        }

        void validation()
        {
            if (TextBox1.Text.Trim() == null || TextBox1.Text.Trim() == "")
            {
                Label3.Visible = true;
                Label3.Text = "Full Name cannot be empty";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
            else if (TextBox2.Text.Trim() == null || TextBox2.Text.Trim() == "")
            {
                Label3.Visible = true;
                Label3.Text = "Date of Birth cannot be empty";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
            else if (TextBox3.Text.Trim() == null || TextBox3.Text.Trim() == "")
            {
                Label3.Visible = true;
                Label3.Text = "Contact Number cannot be empty";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
            else if (TextBox5.Text.Trim() == null || TextBox5.Text.Trim() == "")
            {
                Label3.Visible = true;
                Label3.Text = "City cannot be empty";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
            else if (TextBox6.Text.Trim() == null || TextBox6.Text.Trim() == "")
            {
                Label3.Visible = true;
                Label3.Text = "Pincode cannot be empty";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
            else if (TextBox7.Text.Trim() == null || TextBox7.Text.Trim() == "")
            {
                Label3.Visible = true;
                Label3.Text = "Full Address cannot be empty";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList1.SelectedItem.Value == "Select")
            {
                Label3.Visible = true;
                Label3.Text = "Select your appropriate state";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                updateMemberDetails();
            }
        }

        void updateMemberDetails()
        {
            string password = "";
            if (TextBox10.Text.Trim() == "")
            {
                password = TextBox9.Text.Trim();
            }
            else
            {
                password = TextBox10.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("update member_profile_table set full_name=@full_name, date_of_birth=@date_of_birth, contact_number=@contact_number, member_type=@member_type, state=@state, city=@city, pincode=@pincode, full_address=@full_address, password=@password, account_status=@account_status WHERE member_id='" + Session["memberID"].ToString().Trim() + "';", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@date_of_birth", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_number", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@member_type", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    Label3.Visible = true;
                    Label3.Text = "Your Details Updated Successfully";
                    Label3.ForeColor = System.Drawing.Color.Green;

                    getMemberDetails();
                }
                else
                {
                    Label3.Visible = true;
                    Label3.Text = "Invaid entry";
                    Label3.ForeColor = System.Drawing.Color.Red;
                }

            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message + "');</script>");
            }
        }
    }
}