<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="NotesGenerator.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--bootstrap css--%>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    <%--popper js--%>
    <script src="Styles/popper.min.js"></script>
    <%--bootstrap js--%>
    <script src="Styles/bootstrap.min.js"></script>

    <script type = "text/javascript">
        function Confirm() {
            
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to delete this row?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    

</head>
<body>
    <form id="form1" runat="server">
        <div style="padding-top: 12px;padding-left: 350px;">
            <a class="navbar-brand" href="#" style="color: green;font-weight: bold;font-size: 50px;">
                    <img src="Images/Notes.png" width="100" height="100" />
                   
                    Notes Generator
                </a>
        </div>
        <div>
            <nav class="navbar navbar-expand-lg navbar-light">
                

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                 <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active">
                            <a class="nav-link" href="Index.aspx" style="font-size: 24px;">
                                <img src="Images/Home.jpg" style="width: 22px;height: 22px;"/> Home</a>
                        </li>
                        <li class="nav-item active">
                            <a class="nav-link" href="About.aspx" style="font-size: 24px;">
                                <img src="Images/About.png" style="width: 22px;height: 22px;"/> About</a>
                        </li>
                        

                    </ul>

                    <ul class="navbar-nav" style="padding-left: 800px;">
                        <li class="nav-item active">
                            <a class="nav-link" href="Login.aspx" style="font-size: 24px;">
                                <img src="Images/Logout.png" style="width: 22px;height: 22px;"/> Logout</a>
                        </li>
                    </ul>
                </div>


            </nav>
        </div>


        <!-- Main Content Placeholder -->
        <div style="color: red;">
            <h4>Welcome <label id="welcomename" runat="server"></label> & <label id="registernumber" runat="server"> & </label></h4>
        </div>
        <div style="padding-left: 250px;">
            
            <asp:GridView ID="gvPhoneBook" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="SNO"
                ShowHeaderWhenEmpty="true"

                OnRowCommand="gvPhoneBook_RowCommand" OnRowEditing="gvPhoneBook_RowEditing" OnRowCancelingEdit="gvPhoneBook_RowCancelingEdit"
                OnRowUpdating="gvPhoneBook_RowUpdating" OnRowDeleting="gvPhoneBook_RowDeleting"

                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <%-- Theme Properties --%>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                
                <Columns>
                    
                    <asp:TemplateField HeaderText="Subject">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("SUBJECT") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSubject" Text='<%# Eval("SUBJECT") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtSubjectFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Notes">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("NOTES") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNotes" Text='<%# Eval("NOTES") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNotesFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("STATUS") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtStatus" Text='<%# Eval("STATUS") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtStatusFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" OnClientClick="Confirm()"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/Images/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" /> <asp:Button runat="server" ID="btn_Download" CssClass="lgnbtn" Text="Download" onclick="btn_Download_Click" style="background-color: yellow;color: blue;border: none;" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />

        </div>
        <!-- Main Content Placeholder -->

      

    </form>
</body>
</html>
