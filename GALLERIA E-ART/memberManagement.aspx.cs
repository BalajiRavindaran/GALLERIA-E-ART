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
    public partial class memberManagement : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getMemberById();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateStatusMemberById("active");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateStatusMemberById("pending");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateStatusMemberById("inactive");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteMemberById();
        }

        void getMemberById()
        {
            if (checkMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strCon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT * FROM member_profile_table WHERE member_id='" + TextBox1.Text.Trim() + "';", con);
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            TextBox2.Text = dataReader.GetValue(0).ToString();
                            TextBox7.Text = dataReader.GetValue(10).ToString();
                            TextBox8.Text = dataReader.GetValue(1).ToString();
                            TextBox3.Text = dataReader.GetValue(2).ToString();
                            TextBox4.Text = dataReader.GetValue(3).ToString();
                            TextBox9.Text = dataReader.GetValue(4).ToString();
                            TextBox10.Text = dataReader.GetValue(5).ToString();
                            TextBox11.Text = dataReader.GetValue(6).ToString();
                            TextBox6.Text = dataReader.GetValue(7).ToString();
                        }
                    }
                    else
                    {
                        Label1.Visible = true;
                        Label1.Text = "Invalid member ID";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception exception)
                {
                    Response.Write("<script>alert('" + exception.Message + "');</script>");
                }
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Invalid member ID";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        void updateStatusMemberById(string str)
        {
            if (checkMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strCon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE member_profile_table SET account_status='" + str + "' WHERE member_id='" + TextBox1.Text.Trim() + "';", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    TextBox7.Text = str;

                    Label1.Visible = true;
                    Label1.Text = "Status Updated Successfully";
                    Label1.ForeColor = System.Drawing.Color.Green;

                }
                catch (Exception exception)
                {
                    Response.Write("<script>alert('" + exception.Message + "');</script>");
                }
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Invalid member ID";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        void deleteMemberById()
        {
            if (checkMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strCon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE FROM member_profile_table WHERE member_id='" + TextBox1.Text.Trim() + "' ", con);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Label1.Visible = true;
                    Label1.Text = "Member deleted Successfully";
                    Label1.ForeColor = System.Drawing.Color.Green;

                    clearForm();
                    GridView1.DataBind();
                }
                catch (Exception exception)
                {
                    Response.Write("<script>alert('" + exception.Message + "');</script>");
                }
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Invalid member ID";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox6.Text = "";
        }

        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from member_profile_table where member_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message + "');</script>");
                return false;
            }
        }
    }
}