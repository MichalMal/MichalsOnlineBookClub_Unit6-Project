using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReferenceBookClub;

public partial class bookCollection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BookClubWebServiceSoapClient ws = new BookClubWebServiceSoapClient();
        DataTable fetchedBooks = ws.FetchBooks();

        bookList.DataSource = fetchedBooks;

        bookList.DataBind();
        if (bookList != null)
        {
            foreach (GridViewRow gr in bookList.Rows)
            {
                Button button = new Button
                {
                    Text = "View",
                    CssClass = "btn btn-primary"
                };
                button.Click += (s, ev) =>
                {
                    ws.BookSession(Int32.Parse(gr.Cells[0].Text));
                    Debug.WriteLine(gr.Cells[0].Text);
                };
                button.Click += new EventHandler(ViewBookbutton_Click);
                gr.Cells[0].Controls.Add(button);
            }
        }
    }

    protected void ViewBookbutton_Click (object sender, EventArgs e)
    {
        Response.Redirect("bookView.aspx");
    }

}