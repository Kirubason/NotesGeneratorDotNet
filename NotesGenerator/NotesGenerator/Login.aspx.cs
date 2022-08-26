using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NotesGenerator
{
    public partial class Login : System.Web.UI.Page
    {
        string ConnectionString = "Data Source=(DESCRIPTION =" + "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))" + "(CONNECT_DATA =" + "(SERVER = DEDICATED)" + "(SERVICE_NAME = xe)));" + "User Id= NOTES_APP;Password=notes";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();
            }

        }
        protected void btn_Cancel_Clear(object sender, EventArgs e)
        {
            txt_Username.Text = "";
            txt_Regnumber.Text = "";
        }
        protected void btn_Register_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Registration form.aspx");
           
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            
            
            string username = txt_Username.Text.Trim();
            string password = txt_password.Text.Trim();
            string regnumber = txt_Regnumber.Text.Trim();
            
            if(username == "" || username ==null)
            {
                error.InnerText = "Please enter username!!!";
                return;
            }
            if (password == "" || password == null)
            {
                error.InnerText = "Please enter password!!!";
                return;
            }

            if (regnumber == "" || regnumber == null)
            {
                error.InnerText = "Please enter register nnumber!!!";
                return;
            }
            

            int a = UserCheack(username);
            if (a>0)
            {
                DataTable dt = new DataTable();
                dt = UserDetails(username);
                string usernametemp = dt.Rows[0].Field<string>("USER_NAME");
                string passwordtemp = dt.Rows[0].Field<string>("PASSWORD");
                string registernumbertemp = dt.Rows[0].Field<string>("REG_NO");
                if (usernametemp == username && passwordtemp == password && regnumber == registernumbertemp)
                {
                    Session["Name"] = username;
                    Session["Regnumber"] = regnumber;
                    Response.Redirect("~/Index.aspx");
                }
                else if (usernametemp != username)
                {
                    error.InnerText = "Incorrect Username!!!";
                }
                else if (passwordtemp != password)
                {
                    error.InnerText = "Incorrect Password!!!";
                }
                else if (registernumbertemp != regnumber)
                {
                    error.InnerText = "Incorrect Register Number!!!";
                }
                else
                {
                    error.InnerText = "Incorrect Detais!!!";
                }

            }
            else
            {
                
               error.InnerText = "It seems you do not have access, please ask administrator for registration!!!";           
            }
        }


        public bool DatabaseConnectionCheck()
        {
            bool connection = false;
            
            OracleConnection Con = new OracleConnection(ConnectionString);
            try
            {
                Con.Open();
                Con.Close();
                Con.Dispose();
                connection = true;
            }
            catch
            {
                connection = false;
            }

            return connection;


        }

        public int UserCheack(string username)
        {
            int i = 0;
            OracleConnection con = new OracleConnection(ConnectionString);
            OracleCommand cmd = new OracleCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select count(*) from user_details where user_name='" + username + "'";
            i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return i;

        }



        public DataTable UserDetails(string username)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(ConnectionString);
            OracleCommand cmd = new OracleCommand();
            OracleDataAdapter da = new OracleDataAdapter();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select REG_NO,USER_NAME, PASSWORD from user_details where user_name='" + username + "'";
            cmd.CommandType = CommandType.Text;
            da.SelectCommand = cmd;
            da.Fill(dt);
           
            con.Close();
            return dt;

        }

    }
}