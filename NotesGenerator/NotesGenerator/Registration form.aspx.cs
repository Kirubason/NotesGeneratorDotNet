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
    public partial class Registration_form : System.Web.UI.Page
    {
        string ConnectionString = "Data Source=(DESCRIPTION =" + "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))" + "(CONNECT_DATA =" + "(SERVER = DEDICATED)" + "(SERVICE_NAME = xe)));" + "User Id= NOTES_APP;Password=notes";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
            protected void btn_Register_Click(object sender, EventArgs e)
        {


            string username = txt_Username.Text.Trim();
            string password = txt_password.Text.Trim();
            string Confirmpassword = txt_password_confirm.Text.Trim();
            string regnumber = txt_Regnumber.Text.Trim();

            if (username == "" || username == null)
            {
                error.InnerText = "Please enter username!!!";
                return;
            }
            if (regnumber == "" || regnumber == null)
            {
                error.InnerText = "Please enter register nnumber!!!";
                return;
            }
            if (password == "" || password == null)
            {
                error.InnerText = "Please enter password!!!";
                return;
            }
            if (Confirmpassword == "" || Confirmpassword == null)
            {
                error.InnerText = "Please enter password!!!";
                return;
            }
            if (password == Confirmpassword )
            {
                int a = UserCheack(regnumber);
                if (a <= 0)
                {
                    OracleConnection con = new OracleConnection(ConnectionString);
                    OracleCommand cmd = new OracleCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO USER_DETAILS(USER_NAME,PASSWORD,REG_NO) VALUES('" + username + "','" + password + "','" + regnumber + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    error.InnerText = "Registered successfully, please go to login page to proceed!!!";
                    return;
                }
                {
                    error.InnerText = "This number already registered, please proceed with another register number!!!";
                    return;
                }

                    
            }
            else
            {
                error.InnerText = "Please make sure password and confirm password are same!!!";
                return;
            }





        }
        public int UserCheack(string regnumber)
        {
            int i = 0;
            OracleConnection con = new OracleConnection(ConnectionString);
            OracleCommand cmd = new OracleCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select count(*) from user_details where reg_no='" + regnumber + "'";
            i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return i;

        }

    }
}