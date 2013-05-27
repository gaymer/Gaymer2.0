using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindWall();
        }
    }
    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        GaymerLINQDataContext db = new GaymerLINQDataContext();
        LoginLib login = new LoginLib();
        string input = Input.Text;
        int UserID = login.GetUserID();

        Comment com = new Comment();
        com.AuthorID = UserID;
        com.CreateTime = DateTime.Now;
        com.Text = input;
        com.Hidden = false;

        db.Comments.InsertOnSubmit(com);

        try
        {
            db.SubmitChanges();
            BindWall();
        }
        catch
        {
        }
    }
    private void BindWall()
    {
        GaymerLINQDataContext db = new GaymerLINQDataContext();
        LoginLib login = new LoginLib();
        var WallContent = from a in db.Comments
                          where a.AuthorID == login.GetUserID() && !a.Hidden
                          orderby a.CommentId descending
                          select new
                          {
                              CommentID = a.CommentId,
                              Username = a.User.Username,
                              CreatedTime = a.UpdateTime.HasValue ? "Updated: " + a.UpdateTime.Value.ToString() : "Created:" + a.CreateTime,
                              Comment = a.Text
                          };
        Wall.DataSource = WallContent;
        Wall.DataBind();
    }
    protected void Wall_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
        Wall.EditIndex = -1;
        BindWall();
    }
    protected void Wall_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        GaymerLINQDataContext db = new GaymerLINQDataContext();
        LoginLib login = new LoginLib();
        ListViewItem item = Wall.Items[e.ItemIndex];
        string UpdateContent = ((TextBox)item.FindControl("EditBox")).Text.ToString();
        Wall.EditIndex = -1;

        db.Comments.Where(a => a.CommentId == (int)Wall.DataKeys[e.ItemIndex].Value).First().Text = UpdateContent;
        try { db.SubmitChanges(); }
        catch { }

        int UID = login.GetUserID();
        var WallContent = from a in db.Comments
                          where a.AuthorID == login.GetUserID() && !a.Hidden
                          orderby a.CommentId descending
                          select new
                          {
                              CommentID = a.CommentId,
                              Username = a.User.Username,
                              CreatedTime = a.UpdateTime.HasValue ? "Updated: " + a.UpdateTime.Value.ToString() : "Created:" + a.CreateTime,
                              Comment = a.CommentId == (int)Wall.DataKeys[e.ItemIndex].Value ?UpdateContent: a.Text
                          };
        Wall.DataSource = WallContent;
        Wall.DataBind();
    }
    protected void Wall_ItemEditing(object sender, ListViewEditEventArgs e)
    {
        Wall.EditIndex = e.NewEditIndex;
        GaymerLINQDataContext db = new GaymerLINQDataContext();
        LoginLib login = new LoginLib();
        int UID = login.GetUserID();
        var WallContent = from a in db.Comments
                          where a.AuthorID == login.GetUserID() && !a.Hidden
                          orderby a.CommentId descending
                          select new
                          {
                              CommentID = a.CommentId,
                              Username = a.User.Username,
                              CreatedTime = a.UpdateTime.HasValue ? "Updated: " + a.UpdateTime.Value.ToString() : "Created:" + a.CreateTime,
                              Comment = a.Text
                          };
        Wall.DataSource = WallContent;
        Wall.DataBind();
        ListViewItem item = Wall.Items[e.NewEditIndex];
        TextBox EditBox = (TextBox)item.FindControl("EditBox");

        EditBox.Text = WallContent.FirstOrDefault(p => p.CommentID == (int)Wall.DataKeys[e.NewEditIndex].Value).Comment;
    }
}