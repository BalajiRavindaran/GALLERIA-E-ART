using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;
using System.IO;

namespace GALLERIA_E_ART
{
    public partial class artManagement : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getArtById();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkArtExists())
            {
                Label13.Visible = true;
                Label13.Text = "Art Already Exsists";
                Label13.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (validations())
                {
                    if (FileUpload1.HasFile == true)
                    {
                        addNewBook();
                    }
                    else
                    {
                        Label13.Visible = true;
                        Label13.Text = "Upload the necessary file";
                        Label13.ForeColor = System.Drawing.Color.Red;
                    }
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (validations())
            {
                updateArtById();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            deleteArtById();
        }

        void getArtById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM art_management_table WHERE art_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["art_name"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["type"].ToString().Trim();
                    TextBox12.Text = dt.Rows[0]["publisher_name"].ToString();
                    TextBox13.Text = dt.Rows[0]["artist_name"].ToString();
                    TextBox3.Text = dt.Rows[0]["publish_date"].ToString();

                    string[] genres = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    ListBox1.ClearSelection();
                    for (int i = 0; i < genres.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genres[i])
                            {
                                ListBox1.Items[j].Selected = true;

                            }
                        }
                    }

                    TextBox9.Text = dt.Rows[0]["version"].ToString();
                    TextBox10.Text = dt.Rows[0]["art_cost"].ToString().Trim();
                    TextBox11.Text = dt.Rows[0]["contact_number"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox7.Text = dt.Rows[0]["sold"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["art_description"].ToString();

                    global_filepath = dt.Rows[0]["art_image_link"].ToString();
                }
                else
                {
                    Label13.Visible = true;
                    Label13.Text = "Invalid art ID";
                    Label13.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message + "');</script>");

            }
        }

        void deleteArtById()
        {
            if (checkArtExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strCon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE FROM art_management_table WHERE art_id='" + TextBox1.Text.Trim() + "' ", con);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Label13.Visible = true;
                    Label13.Text = "Art deleted Successfully";
                    Label13.ForeColor = System.Drawing.Color.Green;

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
                Label13.Visible = true;
                Label13.Text = "Invalid Art ID";
                Label13.ForeColor = System.Drawing.Color.Red;
            }
        }

        void updateArtById()
        {
            if (checkArtExists())
            {
                try
                {
                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/arts/artist";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("arts/" + filename));
                        filepath = "~/arts/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strCon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE art_management_table SET art_name=@art_name, genre=@genre, artist_name=@artist_name, publisher_name=@publisher_name, publish_date=@publish_date, type=@type, version=@version, art_cost=@art_cost, contact_number=@contact_number, art_description=@art_description, current_stock=@current_stock, art_image_link=@art_image_link, sold=@sold, member_id=@member_id where art_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@art_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@artist_name", TextBox13.Text.Trim());
                    cmd.Parameters.AddWithValue("@publisher_name", TextBox12.Text.Trim());
                    cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@type", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@version", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@art_cost", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact_number", TextBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@art_description", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@current_stock", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@art_image_link", filepath);
                    cmd.Parameters.AddWithValue("@sold", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@member_id", Session["memberID"]);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Label13.Visible = true;
                    Label13.Text = "Art Updated Successfully";
                    Label13.ForeColor = System.Drawing.Color.Green;

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
                Label13.Visible = true;
                Label13.Text = "Invalid Art ID";
                Label13.ForeColor = System.Drawing.Color.Red;
            }

        }

        void addNewBook()
        {
            string genres = "";

            foreach (int i in ListBox1.GetSelectedIndices())
            {
                genres += ListBox1.Items[i] + ",";
            }
            genres = genres.Remove(genres.Length - 1);

            string filepath = "~/arts/artist.png";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("arts/" + filename));
            filepath = "~/arts/" + filename;

            try
            {
                SqlConnection con = new SqlConnection(strCon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO art_management_table(art_id,art_name,genre,artist_name,publisher_name,publish_date,type,version,art_cost,contact_number,art_description,current_stock,art_image_link,sold,member_id)" +
                    " VALUES(@art_id,@art_name,@genre,@artist_name,@publisher_name,@publish_date,@type,@version,@art_cost,@contact_number,@art_description,@current_stock,@art_image_link,@sold,@member_id);", con);
                cmd.Parameters.AddWithValue("@art_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@art_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@artist_name", TextBox13.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox12.Text.Trim());
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@type", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@version", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@art_cost", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_number", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@art_description", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@art_image_link", filepath);
                cmd.Parameters.AddWithValue("@sold", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", Session["memberID"]);

                cmd.ExecuteNonQuery();
                con.Close();
                Label13.Visible = true;
                Label13.Text = "Art added successfully";
                Label13.ForeColor = System.Drawing.Color.Green;

                clearForm();
                GridView1.DataBind();
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message + "');</script>");
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            DropDownList1.SelectedIndex = 0;
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
            TextBox5.Text = "";
            TextBox7.Text = "";
            TextBox6.Text = "";
        }

        bool checkArtExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from art_management_table where art_id='" + TextBox1.Text.Trim() + "' or art_name='" + TextBox2.Text.Trim() + "';", con);
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

        bool validations()
        {
            if (TextBox1.Text.Trim() == null || TextBox1.Text.Trim() == "")
            {
                Label13.Visible = true;
                Label13.Text = "Art ID cannot be empty";
                Label13.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else if (TextBox2.Text.Trim() == null || TextBox2.Text.Trim() == "")
            {
                Label13.Visible = true;
                Label13.Text = "Art Name cannot be empty";
                Label13.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else if (DropDownList1.SelectedItem.Value == "Select")
            {
                Label13.Visible = true;
                Label13.Text = "Select your appropriate Art Type";
                Label13.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else if (TextBox12.Text.Trim() == null || TextBox12.Text.Trim() == "")
            {
                Label13.Visible = true;
                Label13.Text = "Publisher Name cannot be empty";
                Label13.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else if (TextBox13.Text.Trim() == null || TextBox13.Text.Trim() == "")
            {
                Label13.Visible = true;
                Label13.Text = "Artist Name cannot be empty";
                Label13.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else if (TextBox3.Text.Trim() == null || TextBox3.Text.Trim() == "")
            {
                Label13.Visible = true;
                Label13.Text = "Publish Date cannot be empty";
                Label13.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else if (TextBox9.Text.Trim() == null || TextBox9.Text.Trim() == "")
            {
                Label13.Visible = true;
                Label13.Text = "Version cannot be empty";
                Label13.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else if (TextBox10.Text.Trim() == null || TextBox10.Text.Trim() == "")
            {
                Label13.Visible = true;
                Label13.Text = "Art Cost cannot be empty";
                Label13.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else if (TextBox11.Text.Trim() == null || TextBox11.Text.Trim() == "")
            {
                Label13.Visible = true;
                Label13.Text = "Contact Number cannot be empty";
                Label13.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else if (TextBox5.Text.Trim() == null || TextBox5.Text.Trim() == "")
            {
                Label13.Visible = true;
                Label13.Text = "Current Stock cannot be empty";
                Label13.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else if (TextBox7.Text.Trim() == null || TextBox7.Text.Trim() == "")
            {
                Label13.Visible = true;
                Label13.Text = "Sold cannot be empty";
                Label13.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else if (TextBox6.Text.Trim() == null || TextBox6.Text.Trim() == "")
            {
                Label13.Visible = true;
                Label13.Text = "Art Description cannot be empty";
                Label13.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}