using ClosedXML.Excel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NotesGenerator
{
    public partial class Index : System.Web.UI.Page
    {
        string ConnectionString = "Data Source=(DESCRIPTION =" + "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))" + "(CONNECT_DATA =" + "(SERVER = DEDICATED)" + "(SERVICE_NAME = xe)));" + "User Id= NOTES_APP;Password=notes";

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null)
            {
                Response.Redirect("~/Login.aspx", true);
            }
            if (!IsPostBack)
            {
                welcomename.InnerText = Session["Name"].ToString();
                registernumber.InnerText = Session["Regnumber"].ToString();
                PopulateGridview();
            }
        }

        void PopulateGridview()
        {
            DataTable dtbl = new DataTable();
            OracleConnection con = new OracleConnection(ConnectionString);
            OracleCommand cmd = new OracleCommand();
            OracleDataAdapter da = new OracleDataAdapter();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select * from student where name='" + Session["Name"].ToString() + "'";
            cmd.CommandType = CommandType.Text;
            da.SelectCommand = cmd;
            da.Fill(dtbl);

            con.Close();
            if (dtbl.Rows.Count > 0)
            {
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
                gvPhoneBook.Rows[0].Cells.Clear();
                gvPhoneBook.Rows[0].Cells.Add(new TableCell());
                gvPhoneBook.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvPhoneBook.Rows[0].Cells[0].Text = "No Data Found ..!";
                gvPhoneBook.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        protected void gvPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    string RegisterNumber = Session["Regnumber"].ToString();
                    string Name = Session["Name"].ToString();
                    string Subject = (gvPhoneBook.FooterRow.FindControl("txtSubjectFooter") as TextBox).Text.Trim();
                    string Notes = (gvPhoneBook.FooterRow.FindControl("txtNotesFooter") as TextBox).Text.Trim();
                    string Status = (gvPhoneBook.FooterRow.FindControl("txtStatusFooter") as TextBox).Text.Trim();
                    if (Subject == "" || Subject == null || Notes == "" || Notes == null || Status == "" || Status == null)
                    {
                        lblErrorMessage.Text = "Null value cannot be inderted!!! Subject, Notes, Status are mandatory";
                        return;
                    }
                    OracleConnection con = new OracleConnection(ConnectionString);
                    OracleCommand cmd = new OracleCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO STUDENT(REGNO,NAME,SUBJECT,NOTES,STATUS) VALUES('" + RegisterNumber + "','" + Name + "','" + Subject + "','" + Notes + "','" + Status + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    PopulateGridview();
                    lblSuccessMessage.Text = "New Record Added";
                    lblErrorMessage.Text = "";


                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPhoneBook.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void gvPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPhoneBook.EditIndex = -1;
            PopulateGridview();
        }

        protected void gvPhoneBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string RegisterNumber = Session["Regnumber"].ToString();
                string Name = Session["Name"].ToString();
                string Subject = (gvPhoneBook.Rows[e.RowIndex].FindControl("txtSubject") as TextBox).Text.Trim();
                string Notes = (gvPhoneBook.Rows[e.RowIndex].FindControl("txtNotes") as TextBox).Text.Trim();
                string Status = (gvPhoneBook.Rows[e.RowIndex].FindControl("txtStatus") as TextBox).Text.Trim();  
                if (Subject=="" || Subject == null || Notes == "" || Notes == null || Status == "" || Status == null)
                {
                    lblErrorMessage.Text = "Null value cannot be updated!!! Subject, Notes, Status are mandatory";
                    return;
                }
                int Sno = Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString());
                OracleConnection con = new OracleConnection(ConnectionString);
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE STUDENT SET REGNO='" + RegisterNumber + "',Name='" + Name + "',Subject='" + Subject + "',Notes='" + Notes + "',Status='" + Status + "' WHERE SNO = '" + Sno + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();

                gvPhoneBook.EditIndex = -1;
                PopulateGridview();
                lblSuccessMessage.Text = "Selected Record Updated";
                lblErrorMessage.Text = "";


            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                try
                {
                    int Sno = Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString());
                    OracleConnection con = new OracleConnection(ConnectionString);
                    OracleCommand cmd = new OracleCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "DELETE FROM STUDENT WHERE SNO = '" + Sno + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";

                }
                catch (Exception ex)
                {
                    lblSuccessMessage.Text = "";
                    lblErrorMessage.Text = ex.Message;
                }
            }
            else
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = "Selected Record Not Deleted";
              
            }
            

            
        }

        protected void btn_Download_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(ConnectionString);
            OracleCommand cmd = new OracleCommand();
            OracleDataAdapter da = new OracleDataAdapter();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select SUBJECT,NOTES,STATUS from student where name='" + Session["Name"].ToString() + "'";
            cmd.CommandType = CommandType.Text;
            da.SelectCommand = cmd;
            da.Fill(dt);
            using (XLWorkbook wb = new XLWorkbook())
            {
                
                try
                {
                    // dt = ds.Tables[0];

                    wb.AddWorksheet(dt, "Notes Details");
                    

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";

                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                    Response.AddHeader("content-disposition", "attachment;filename=Notes_Report.xlsx");

                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.SuppressContent = true;
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }

                }
                catch (Exception ex)
                {

                }


            }
        }
    }
}