using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        LoginLib login = new LoginLib();
        if (login.IsUserLoggedIn())
        {
            //LogOutBtn.Visible = true;
            //LogOutBtn.Enabled = true;

            //Must run last for logged in users on every page, meaning before this block closes
            //login.CreateNewCookie();
        }
        else
        {
            //LogOutBtn.Visible = false;
            //LogOutBtn.Enabled = false;
        }
        rendreMenu(login);
    }

    private void rendreMenu(LoginLib login)
    {
        rendreAdminMenu(login);
        rendreUserMenu(login);
    }

    private void rendreUserMenu(LoginLib login)
    {
        if (login.IsUserLoggedIn())
        {
            MenuItem BrukerMenu = new MenuItem();
            BrukerMenu.Text = "Bruker";
            Menu.Items.Add(BrukerMenu);

            MenuItem MeldUserMenu = new MenuItem();
            MeldUserMenu.Text = "Meldinger";
            MeldUserMenu.NavigateUrl = "~/User/Meldinger.aspx";

            MenuItem BrukerSokMenu = new MenuItem();
            BrukerSokMenu.Text = "Søk i brukere";
            BrukerSokMenu.NavigateUrl = "~/User/vennesok.aspx";

            MenuItem rootUserMenu = new MenuItem();
            rootUserMenu.Text = "Logout";
            Menu.Items.Add(rootUserMenu);

            BrukerMenu.ChildItems.Add(MeldUserMenu);
            BrukerMenu.ChildItems.Add(BrukerSokMenu);
        }
        else 
        {
            MenuItem rootUserMenu = new MenuItem();
            rootUserMenu.Text = "Login";
            rootUserMenu.NavigateUrl = "javascript:Toggel('LoginDiv');";
            Menu.Items.Add(rootUserMenu);
        }
    }

    private void rendreAdminMenu(LoginLib login)
    {
        if (ManageDB.UserHasPermission(Permissions.Gaymer_View_Admin_Menu, login.GetUserID()))
        {
            MenuItem rootAdminMenu = new MenuItem();
            rootAdminMenu.Text = "Admin";
            rootAdminMenu.NavigateUrl = "~/Online/Student/FagListe.aspx";
            rootAdminMenu.Selectable = false;
            Menu.Items.Add(rootAdminMenu);

            MenuItem m;

            if (ManageDB.UserHasPermission(Permissions.Gaymer_Manage_Roles, login.GetUserID()))
            {
                m = new MenuItem();
                m.Text = "Roller";
                m.NavigateUrl = "~/Admin/Roles.aspx";
                rootAdminMenu.ChildItems.Add(m);
            }

            if (ManageDB.UserHasPermission(Permissions.Gaymer_Manage_Users, login.GetUserID()))
            {
                m = new MenuItem();
                m.Text = "Users";
                m.NavigateUrl = "~/Admin/Users.aspx";
                rootAdminMenu.ChildItems.Add(m);
            }
        }

    }

    protected void Menu_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (e.Item.Text == "Logout") 
        {
            LoginLib login = new LoginLib();
            login.LogOut();
            Response.Redirect("/StartPage.aspx");
        }
    }
}
