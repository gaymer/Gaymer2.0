﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="gaymerdb")]
public partial class GaymerLINQDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertUserRole(UserRole instance);
  partial void UpdateUserRole(UserRole instance);
  partial void DeleteUserRole(UserRole instance);
  partial void InsertUserAbout(UserAbout instance);
  partial void UpdateUserAbout(UserAbout instance);
  partial void DeleteUserAbout(UserAbout instance);
  partial void InsertUser(User instance);
  partial void UpdateUser(User instance);
  partial void DeleteUser(User instance);
  #endregion
	
	public GaymerLINQDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["gaymerdbConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public GaymerLINQDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public GaymerLINQDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public GaymerLINQDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public GaymerLINQDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<UserRole> UserRoles
	{
		get
		{
			return this.GetTable<UserRole>();
		}
	}
	
	public System.Data.Linq.Table<UserAbout> UserAbouts
	{
		get
		{
			return this.GetTable<UserAbout>();
		}
	}
	
	public System.Data.Linq.Table<User> Users
	{
		get
		{
			return this.GetTable<User>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserRole")]
public partial class UserRole : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _RoleID;
	
	private string _Role;
	
	private EntitySet<User> _Users;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRoleIDChanging(int value);
    partial void OnRoleIDChanged();
    partial void OnRoleChanging(string value);
    partial void OnRoleChanged();
    #endregion
	
	public UserRole()
	{
		this._Users = new EntitySet<User>(new Action<User>(this.attach_Users), new Action<User>(this.detach_Users));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int RoleID
	{
		get
		{
			return this._RoleID;
		}
		set
		{
			if ((this._RoleID != value))
			{
				this.OnRoleIDChanging(value);
				this.SendPropertyChanging();
				this._RoleID = value;
				this.SendPropertyChanged("RoleID");
				this.OnRoleIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Role", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string Role
	{
		get
		{
			return this._Role;
		}
		set
		{
			if ((this._Role != value))
			{
				this.OnRoleChanging(value);
				this.SendPropertyChanging();
				this._Role = value;
				this.SendPropertyChanged("Role");
				this.OnRoleChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserRole_User", Storage="_Users", ThisKey="RoleID", OtherKey="RoleID")]
	public EntitySet<User> Users
	{
		get
		{
			return this._Users;
		}
		set
		{
			this._Users.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_Users(User entity)
	{
		this.SendPropertyChanging();
		entity.UserRole = this;
	}
	
	private void detach_Users(User entity)
	{
		this.SendPropertyChanging();
		entity.UserRole = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserAbout")]
public partial class UserAbout : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _AbID;
	
	private string _FirstName;
	
	private string _LastName;
	
	private System.Nullable<System.DateTime> _Birthdate;
	
	private string _Location;
	
	private System.Nullable<bool> _Gender;
	
	private EntitySet<User> _Users;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAbIDChanging(int value);
    partial void OnAbIDChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnBirthdateChanging(System.Nullable<System.DateTime> value);
    partial void OnBirthdateChanged();
    partial void OnLocationChanging(string value);
    partial void OnLocationChanged();
    partial void OnGenderChanging(System.Nullable<bool> value);
    partial void OnGenderChanged();
    #endregion
	
	public UserAbout()
	{
		this._Users = new EntitySet<User>(new Action<User>(this.attach_Users), new Action<User>(this.detach_Users));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AbID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int AbID
	{
		get
		{
			return this._AbID;
		}
		set
		{
			if ((this._AbID != value))
			{
				this.OnAbIDChanging(value);
				this.SendPropertyChanging();
				this._AbID = value;
				this.SendPropertyChanged("AbID");
				this.OnAbIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="VarChar(50)")]
	public string FirstName
	{
		get
		{
			return this._FirstName;
		}
		set
		{
			if ((this._FirstName != value))
			{
				this.OnFirstNameChanging(value);
				this.SendPropertyChanging();
				this._FirstName = value;
				this.SendPropertyChanged("FirstName");
				this.OnFirstNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="VarChar(50)")]
	public string LastName
	{
		get
		{
			return this._LastName;
		}
		set
		{
			if ((this._LastName != value))
			{
				this.OnLastNameChanging(value);
				this.SendPropertyChanging();
				this._LastName = value;
				this.SendPropertyChanged("LastName");
				this.OnLastNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Birthdate", DbType="DateTime2")]
	public System.Nullable<System.DateTime> Birthdate
	{
		get
		{
			return this._Birthdate;
		}
		set
		{
			if ((this._Birthdate != value))
			{
				this.OnBirthdateChanging(value);
				this.SendPropertyChanging();
				this._Birthdate = value;
				this.SendPropertyChanged("Birthdate");
				this.OnBirthdateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Location", DbType="VarChar(MAX)")]
	public string Location
	{
		get
		{
			return this._Location;
		}
		set
		{
			if ((this._Location != value))
			{
				this.OnLocationChanging(value);
				this.SendPropertyChanging();
				this._Location = value;
				this.SendPropertyChanged("Location");
				this.OnLocationChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gender", DbType="Bit")]
	public System.Nullable<bool> Gender
	{
		get
		{
			return this._Gender;
		}
		set
		{
			if ((this._Gender != value))
			{
				this.OnGenderChanging(value);
				this.SendPropertyChanging();
				this._Gender = value;
				this.SendPropertyChanged("Gender");
				this.OnGenderChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserAbout_User", Storage="_Users", ThisKey="AbID", OtherKey="AbID")]
	public EntitySet<User> Users
	{
		get
		{
			return this._Users;
		}
		set
		{
			this._Users.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_Users(User entity)
	{
		this.SendPropertyChanging();
		entity.UserAbout = this;
	}
	
	private void detach_Users(User entity)
	{
		this.SendPropertyChanging();
		entity.UserAbout = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _UID;
	
	private string _Username;
	
	private string _Mail;
	
	private string _Password;
	
	private System.Nullable<int> _AbID;
	
	private int _RoleID;
	
	private string _LoginSession;
	
	private EntityRef<UserAbout> _UserAbout;
	
	private EntityRef<UserRole> _UserRole;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUIDChanging(int value);
    partial void OnUIDChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnMailChanging(string value);
    partial void OnMailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnAbIDChanging(System.Nullable<int> value);
    partial void OnAbIDChanged();
    partial void OnRoleIDChanging(int value);
    partial void OnRoleIDChanged();
    partial void OnLoginSessionChanging(string value);
    partial void OnLoginSessionChanged();
    #endregion
	
	public User()
	{
		this._UserAbout = default(EntityRef<UserAbout>);
		this._UserRole = default(EntityRef<UserRole>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int UID
	{
		get
		{
			return this._UID;
		}
		set
		{
			if ((this._UID != value))
			{
				this.OnUIDChanging(value);
				this.SendPropertyChanging();
				this._UID = value;
				this.SendPropertyChanged("UID");
				this.OnUIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string Username
	{
		get
		{
			return this._Username;
		}
		set
		{
			if ((this._Username != value))
			{
				this.OnUsernameChanging(value);
				this.SendPropertyChanging();
				this._Username = value;
				this.SendPropertyChanged("Username");
				this.OnUsernameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Mail", DbType="VarChar(75) NOT NULL", CanBeNull=false)]
	public string Mail
	{
		get
		{
			return this._Mail;
		}
		set
		{
			if ((this._Mail != value))
			{
				this.OnMailChanging(value);
				this.SendPropertyChanging();
				this._Mail = value;
				this.SendPropertyChanged("Mail");
				this.OnMailChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
	public string Password
	{
		get
		{
			return this._Password;
		}
		set
		{
			if ((this._Password != value))
			{
				this.OnPasswordChanging(value);
				this.SendPropertyChanging();
				this._Password = value;
				this.SendPropertyChanged("Password");
				this.OnPasswordChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AbID", DbType="Int")]
	public System.Nullable<int> AbID
	{
		get
		{
			return this._AbID;
		}
		set
		{
			if ((this._AbID != value))
			{
				if (this._UserAbout.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnAbIDChanging(value);
				this.SendPropertyChanging();
				this._AbID = value;
				this.SendPropertyChanged("AbID");
				this.OnAbIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleID", DbType="Int NOT NULL")]
	public int RoleID
	{
		get
		{
			return this._RoleID;
		}
		set
		{
			if ((this._RoleID != value))
			{
				if (this._UserRole.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnRoleIDChanging(value);
				this.SendPropertyChanging();
				this._RoleID = value;
				this.SendPropertyChanged("RoleID");
				this.OnRoleIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LoginSession", DbType="VarChar(MAX)")]
	public string LoginSession
	{
		get
		{
			return this._LoginSession;
		}
		set
		{
			if ((this._LoginSession != value))
			{
				this.OnLoginSessionChanging(value);
				this.SendPropertyChanging();
				this._LoginSession = value;
				this.SendPropertyChanged("LoginSession");
				this.OnLoginSessionChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserAbout_User", Storage="_UserAbout", ThisKey="AbID", OtherKey="AbID", IsForeignKey=true)]
	public UserAbout UserAbout
	{
		get
		{
			return this._UserAbout.Entity;
		}
		set
		{
			UserAbout previousValue = this._UserAbout.Entity;
			if (((previousValue != value) 
						|| (this._UserAbout.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._UserAbout.Entity = null;
					previousValue.Users.Remove(this);
				}
				this._UserAbout.Entity = value;
				if ((value != null))
				{
					value.Users.Add(this);
					this._AbID = value.AbID;
				}
				else
				{
					this._AbID = default(Nullable<int>);
				}
				this.SendPropertyChanged("UserAbout");
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserRole_User", Storage="_UserRole", ThisKey="RoleID", OtherKey="RoleID", IsForeignKey=true)]
	public UserRole UserRole
	{
		get
		{
			return this._UserRole.Entity;
		}
		set
		{
			UserRole previousValue = this._UserRole.Entity;
			if (((previousValue != value) 
						|| (this._UserRole.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._UserRole.Entity = null;
					previousValue.Users.Remove(this);
				}
				this._UserRole.Entity = value;
				if ((value != null))
				{
					value.Users.Add(this);
					this._RoleID = value.RoleID;
				}
				else
				{
					this._RoleID = default(int);
				}
				this.SendPropertyChanged("UserRole");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
#pragma warning restore 1591
