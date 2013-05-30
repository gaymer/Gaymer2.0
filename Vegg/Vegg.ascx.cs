using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vegg_Vegg : System.Web.UI.UserControl
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
        if (Input.Text != "")
        {
            GaymerLINQDataContext db = new GaymerLINQDataContext();
            LoginLib login = new LoginLib();
            int UserID = login.GetUserID();

            Comment com = new Comment();
            com.AuthorID = UserID;
            com.UserWallID = Convert.ToInt32(Request.QueryString["UserId"]);
            com.CreateTime = DateTime.Now;
            com.Text = Input.Text;
            com.Hidden = false;

            db.Comments.InsertOnSubmit(com);

            try
            {
                db.SubmitChanges();
                BindWall();
                Input.Text = "";
            }
            catch
            {
            }
        }
    }
    private void BindWall()
    {
        
        LoginLib login = new LoginLib();
        int LoginID = login.GetUserID();
        GaymerLINQDataContext db = new GaymerLINQDataContext();
        var WallContent = from a in db.Comments
                          where a.UserWallID != null? a.UserWallID == GetActiveWall() : a.AuthorID == GetActiveWall() && !a.Hidden
                          orderby a.CommentId descending
                          select new
                          {
                              CommentID = a.CommentId,
                              Username = a.User.Username,
                              CreatedTime = CreatedTime(a.UpdateTime, a.CreateTime),
                              Comment = a.Text,
                              EditBtnVisible = a.AuthorID == LoginID ? "display:inline;" : "display:none;",
                              DeleteBtnVisible = a.AuthorID == LoginID ? "display:inline;" : a.UserWallID == LoginID ? "display:inline;" : "display:none;"
                          };
        Wall.DataSource = WallContent;
        Wall.DataBind();
    }
    private string CreatedTime(DateTime? UpdateTime, DateTime CreateTime)
    {
        return UpdateTime.HasValue ? "Updated: " + UpdateTime.Value.ToString() : "Created:" + CreateTime.ToString();
    }
    private int GetActiveWall()
    {
        LoginLib login = new LoginLib();
        int UserID = Convert.ToInt32(Request.QueryString["UserId"]);
        if (UserID == 0)
        {
            UserID = login.GetUserID();
        }
        return UserID;
    }
    protected void Wall_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
        Wall.EditIndex = -1;
        BindWall();
    }
    protected void Wall_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        LoginLib login = new LoginLib();
        int LoginID = login.GetUserID();
        GaymerLINQDataContext db = new GaymerLINQDataContext();
        var comment = db.Comments.Where(a => a.CommentId == (int)Wall.DataKeys[e.ItemIndex].Value).First();
        if (comment.AuthorID == LoginID)
        {
            ListViewItem item = Wall.Items[e.ItemIndex];
            string UpdateContent = ((TextBox)item.FindControl("EditBox")).Text.ToString();
            Wall.EditIndex = -1;

            var update = db.Comments.Where(a => a.CommentId == (int)Wall.DataKeys[e.ItemIndex].Value).First();
            update.Text = UpdateContent;
            update.UpdateTime = DateTime.Now;

            try { db.SubmitChanges(); }
            catch { }

            var WallContent = from a in db.Comments
                              where a.UserWallID != null ? a.UserWallID == GetActiveWall() : a.AuthorID == GetActiveWall() && !a.Hidden
                              orderby a.CommentId descending
                              select new
                              {
                                  CommentID = a.CommentId,
                                  Username = a.User.Username,
                                  CreatedTime = a.CommentId == (int)Wall.DataKeys[e.ItemIndex].Value ? CreatedTime(DateTime.Now, a.CreateTime) : CreatedTime(a.UpdateTime, a.CreateTime),
                                  Comment = a.CommentId == (int)Wall.DataKeys[e.ItemIndex].Value ? UpdateContent : a.Text,
                                  EditBtnVisible = a.AuthorID == LoginID ? "display:inline;" : "display:none;",
                                  DeleteBtnVisible = a.AuthorID == LoginID ? "display:inline;" : a.UserWallID == LoginID ? "display:inline;" : "display:none;"
                              };
            Wall.DataSource = WallContent;
            Wall.DataBind();
        }
    }
    protected void Wall_ItemEditing(object sender, ListViewEditEventArgs e)
    {
        LoginLib login = new LoginLib();
        int LoginID = login.GetUserID();
        
            GaymerLINQDataContext db = new GaymerLINQDataContext();
            var comment = db.Comments.Where(a => a.CommentId == (int)Wall.DataKeys[e.NewEditIndex].Value).First();

        if (comment.AuthorID == LoginID)
        {
            Wall.EditIndex = e.NewEditIndex;
            var WallContent = from a in db.Comments
                              where a.UserWallID != null ? a.UserWallID == GetActiveWall() : a.AuthorID == GetActiveWall() && !a.Hidden
                              orderby a.CommentId descending
                              select new
                              {
                                  CommentID = a.CommentId,
                                  Username = a.User.Username,
                                  CreatedTime = CreatedTime(a.UpdateTime, a.CreateTime),
                                  Comment = a.Text,
                                  EditBtnVisible = a.AuthorID == LoginID ? "display:inline;" : "display:none;",
                                  DeleteBtnVisible = a.AuthorID == LoginID ? "display:inline;" : a.UserWallID == LoginID ? "display:inline;" : "display:none;"
                              };
            Wall.DataSource = WallContent;
            Wall.DataBind();
            ListViewItem item = Wall.Items[e.NewEditIndex];
            TextBox EditBox = (TextBox)item.FindControl("EditBox");

            EditBox.Text = WallContent.FirstOrDefault(p => p.CommentID == (int)Wall.DataKeys[e.NewEditIndex].Value).Comment;
        }
    }
    protected void Wall_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        LoginLib login = new LoginLib();
        int LoginID = login.GetUserID();
        GaymerLINQDataContext db = new GaymerLINQDataContext();
        var comment = db.Comments.Where(a => a.CommentId == (int)Wall.DataKeys[e.ItemIndex].Value).First();
        int wallOwnerID = -1;
        if (comment.UserWallID.HasValue)
        {
            wallOwnerID = comment.UserWallID.Value;
        }
        if (wallOwnerID == LoginID || comment.AuthorID == LoginID)
        {
            comment.Hidden = true;
            try { db.SubmitChanges(); }
            catch { }

            var WallContent = from a in db.Comments
                              where a.UserWallID != null ? a.UserWallID == GetActiveWall() : a.AuthorID == GetActiveWall() && !a.Hidden && a.CommentId != (int)Wall.DataKeys[e.ItemIndex].Value
                              orderby a.CommentId descending
                              select new
                              {
                                  CommentID = a.CommentId,
                                  Username = a.User.Username,
                                  CreatedTime = CreatedTime(a.UpdateTime, a.CreateTime),
                                  Comment = a.Text,
                                  EditBtnVisible = a.AuthorID == LoginID ? "display:inline;" : "display:none;",
                                  DeleteBtnVisible = a.AuthorID == LoginID ? "display:inline;" : a.UserWallID == LoginID ? "display:inline;" : "display:none;"
                              };
            Wall.DataSource = WallContent;
            Wall.DataBind();
        }
    }
}