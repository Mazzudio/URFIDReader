﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BccService.Data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BCC")]
	public partial class BccDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertServiceLog(ServiceLog instance);
    partial void UpdateServiceLog(ServiceLog instance);
    partial void DeleteServiceLog(ServiceLog instance);
    partial void InsertAdmin(Admin instance);
    partial void UpdateAdmin(Admin instance);
    partial void DeleteAdmin(Admin instance);
    partial void InsertProfile(Profile instance);
    partial void UpdateProfile(Profile instance);
    partial void DeleteProfile(Profile instance);
    partial void InsertFriendList(FriendList instance);
    partial void UpdateFriendList(FriendList instance);
    partial void DeleteFriendList(FriendList instance);
    partial void InsertSystemInfo(SystemInfo instance);
    partial void UpdateSystemInfo(SystemInfo instance);
    partial void DeleteSystemInfo(SystemInfo instance);
    partial void InsertContentAccess(ContentAccess instance);
    partial void UpdateContentAccess(ContentAccess instance);
    partial void DeleteContentAccess(ContentAccess instance);
    partial void InsertContent(Content instance);
    partial void UpdateContent(Content instance);
    partial void DeleteContent(Content instance);
    #endregion
		
		public BccDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BccDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BccDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BccDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ServiceLog> ServiceLogs
		{
			get
			{
				return this.GetTable<ServiceLog>();
			}
		}
		
		public System.Data.Linq.Table<Admin> Admins
		{
			get
			{
				return this.GetTable<Admin>();
			}
		}
		
		public System.Data.Linq.Table<Profile> Profiles
		{
			get
			{
				return this.GetTable<Profile>();
			}
		}
		
		public System.Data.Linq.Table<FriendList> FriendLists
		{
			get
			{
				return this.GetTable<FriendList>();
			}
		}
		
		public System.Data.Linq.Table<SystemInfo> SystemInfos
		{
			get
			{
				return this.GetTable<SystemInfo>();
			}
		}
		
		public System.Data.Linq.Table<ContentAccess> ContentAccesses
		{
			get
			{
				return this.GetTable<ContentAccess>();
			}
		}
		
		public System.Data.Linq.Table<Content> Contents
		{
			get
			{
				return this.GetTable<Content>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ServiceLog")]
	public partial class ServiceLog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _Id;
		
		private System.DateTime _EntryDate;
		
		private string _ModuleName;
		
		private string _TypeName;
		
		private string _Headers;
		
		private string _Request;
		
		private string _Response;
		
		private string _Details;
		
		private string _ServiceVersion;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(long value);
    partial void OnIdChanged();
    partial void OnEntryDateChanging(System.DateTime value);
    partial void OnEntryDateChanged();
    partial void OnModuleNameChanging(string value);
    partial void OnModuleNameChanged();
    partial void OnTypeNameChanging(string value);
    partial void OnTypeNameChanged();
    partial void OnHeadersChanging(string value);
    partial void OnHeadersChanged();
    partial void OnRequestChanging(string value);
    partial void OnRequestChanged();
    partial void OnResponseChanging(string value);
    partial void OnResponseChanged();
    partial void OnDetailsChanging(string value);
    partial void OnDetailsChanged();
    partial void OnServiceVersionChanging(string value);
    partial void OnServiceVersionChanged();
    #endregion
		
		public ServiceLog()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EntryDate", DbType="DateTime NOT NULL")]
		public System.DateTime EntryDate
		{
			get
			{
				return this._EntryDate;
			}
			set
			{
				if ((this._EntryDate != value))
				{
					this.OnEntryDateChanging(value);
					this.SendPropertyChanging();
					this._EntryDate = value;
					this.SendPropertyChanged("EntryDate");
					this.OnEntryDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModuleName", DbType="VarChar(128) NOT NULL", CanBeNull=false)]
		public string ModuleName
		{
			get
			{
				return this._ModuleName;
			}
			set
			{
				if ((this._ModuleName != value))
				{
					this.OnModuleNameChanging(value);
					this.SendPropertyChanging();
					this._ModuleName = value;
					this.SendPropertyChanged("ModuleName");
					this.OnModuleNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TypeName", DbType="VarChar(128) NOT NULL", CanBeNull=false)]
		public string TypeName
		{
			get
			{
				return this._TypeName;
			}
			set
			{
				if ((this._TypeName != value))
				{
					this.OnTypeNameChanging(value);
					this.SendPropertyChanging();
					this._TypeName = value;
					this.SendPropertyChanged("TypeName");
					this.OnTypeNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Headers", DbType="NVarChar(512)")]
		public string Headers
		{
			get
			{
				return this._Headers;
			}
			set
			{
				if ((this._Headers != value))
				{
					this.OnHeadersChanging(value);
					this.SendPropertyChanging();
					this._Headers = value;
					this.SendPropertyChanged("Headers");
					this.OnHeadersChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Request", DbType="NVarChar(2048)")]
		public string Request
		{
			get
			{
				return this._Request;
			}
			set
			{
				if ((this._Request != value))
				{
					this.OnRequestChanging(value);
					this.SendPropertyChanging();
					this._Request = value;
					this.SendPropertyChanged("Request");
					this.OnRequestChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Response", DbType="NVarChar(2048)")]
		public string Response
		{
			get
			{
				return this._Response;
			}
			set
			{
				if ((this._Response != value))
				{
					this.OnResponseChanging(value);
					this.SendPropertyChanging();
					this._Response = value;
					this.SendPropertyChanged("Response");
					this.OnResponseChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Details", DbType="NVarChar(2048)")]
		public string Details
		{
			get
			{
				return this._Details;
			}
			set
			{
				if ((this._Details != value))
				{
					this.OnDetailsChanging(value);
					this.SendPropertyChanging();
					this._Details = value;
					this.SendPropertyChanged("Details");
					this.OnDetailsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServiceVersion", DbType="VarChar(128) NOT NULL", CanBeNull=false)]
		public string ServiceVersion
		{
			get
			{
				return this._ServiceVersion;
			}
			set
			{
				if ((this._ServiceVersion != value))
				{
					this.OnServiceVersionChanging(value);
					this.SendPropertyChanging();
					this._ServiceVersion = value;
					this.SendPropertyChanged("ServiceVersion");
					this.OnServiceVersionChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Admin")]
	public partial class Admin : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _ProfileId;
		
		private bool _Inacrtive;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnProfileIdChanging(int value);
    partial void OnProfileIdChanged();
    partial void OnInacrtiveChanging(bool value);
    partial void OnInacrtiveChanged();
    #endregion
		
		public Admin()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProfileId", DbType="Int NOT NULL")]
		public int ProfileId
		{
			get
			{
				return this._ProfileId;
			}
			set
			{
				if ((this._ProfileId != value))
				{
					this.OnProfileIdChanging(value);
					this.SendPropertyChanging();
					this._ProfileId = value;
					this.SendPropertyChanged("ProfileId");
					this.OnProfileIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Inacrtive", DbType="Bit NOT NULL")]
		public bool Inacrtive
		{
			get
			{
				return this._Inacrtive;
			}
			set
			{
				if ((this._Inacrtive != value))
				{
					this.OnInacrtiveChanging(value);
					this.SendPropertyChanging();
					this._Inacrtive = value;
					this.SendPropertyChanged("Inacrtive");
					this.OnInacrtiveChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Profile")]
	public partial class Profile : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.DateTime _EntryDate;
		
		private string _LineUserId;
		
		private string _DefaultName;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnEntryDateChanging(System.DateTime value);
    partial void OnEntryDateChanged();
    partial void OnLineUserIdChanging(string value);
    partial void OnLineUserIdChanged();
    partial void OnDefaultNameChanging(string value);
    partial void OnDefaultNameChanged();
    #endregion
		
		public Profile()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EntryDate", DbType="DateTime NOT NULL")]
		public System.DateTime EntryDate
		{
			get
			{
				return this._EntryDate;
			}
			set
			{
				if ((this._EntryDate != value))
				{
					this.OnEntryDateChanging(value);
					this.SendPropertyChanging();
					this._EntryDate = value;
					this.SendPropertyChanged("EntryDate");
					this.OnEntryDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LineUserId", DbType="VarChar(64) NOT NULL", CanBeNull=false)]
		public string LineUserId
		{
			get
			{
				return this._LineUserId;
			}
			set
			{
				if ((this._LineUserId != value))
				{
					this.OnLineUserIdChanging(value);
					this.SendPropertyChanging();
					this._LineUserId = value;
					this.SendPropertyChanged("LineUserId");
					this.OnLineUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DefaultName", DbType="NVarChar(32)")]
		public string DefaultName
		{
			get
			{
				return this._DefaultName;
			}
			set
			{
				if ((this._DefaultName != value))
				{
					this.OnDefaultNameChanging(value);
					this.SendPropertyChanging();
					this._DefaultName = value;
					this.SendPropertyChanged("DefaultName");
					this.OnDefaultNameChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.FriendList")]
	public partial class FriendList : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _Id;
		
		private int _ProfileId;
		
		private int _FriendId;
		
		private string _CallName;
		
		private System.DateTime _UpdateDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(long value);
    partial void OnIdChanged();
    partial void OnProfileIdChanging(int value);
    partial void OnProfileIdChanged();
    partial void OnFriendIdChanging(int value);
    partial void OnFriendIdChanged();
    partial void OnCallNameChanging(string value);
    partial void OnCallNameChanged();
    partial void OnUpdateDateChanging(System.DateTime value);
    partial void OnUpdateDateChanged();
    #endregion
		
		public FriendList()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProfileId", DbType="Int NOT NULL")]
		public int ProfileId
		{
			get
			{
				return this._ProfileId;
			}
			set
			{
				if ((this._ProfileId != value))
				{
					this.OnProfileIdChanging(value);
					this.SendPropertyChanging();
					this._ProfileId = value;
					this.SendPropertyChanged("ProfileId");
					this.OnProfileIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FriendId", DbType="Int NOT NULL")]
		public int FriendId
		{
			get
			{
				return this._FriendId;
			}
			set
			{
				if ((this._FriendId != value))
				{
					this.OnFriendIdChanging(value);
					this.SendPropertyChanging();
					this._FriendId = value;
					this.SendPropertyChanged("FriendId");
					this.OnFriendIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CallName", DbType="NVarChar(32)")]
		public string CallName
		{
			get
			{
				return this._CallName;
			}
			set
			{
				if ((this._CallName != value))
				{
					this.OnCallNameChanging(value);
					this.SendPropertyChanging();
					this._CallName = value;
					this.SendPropertyChanged("CallName");
					this.OnCallNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UpdateDate", DbType="DateTime NOT NULL")]
		public System.DateTime UpdateDate
		{
			get
			{
				return this._UpdateDate;
			}
			set
			{
				if ((this._UpdateDate != value))
				{
					this.OnUpdateDateChanging(value);
					this.SendPropertyChanging();
					this._UpdateDate = value;
					this.SendPropertyChanged("UpdateDate");
					this.OnUpdateDateChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SystemInfo")]
	public partial class SystemInfo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Name;
		
		private string _Value;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnValueChanging(string value);
    partial void OnValueChanged();
    #endregion
		
		public SystemInfo()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(64) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value", DbType="NVarChar(1048) NOT NULL", CanBeNull=false)]
		public string Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if ((this._Value != value))
				{
					this.OnValueChanging(value);
					this.SendPropertyChanging();
					this._Value = value;
					this.SendPropertyChanged("Value");
					this.OnValueChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ContentAccess")]
	public partial class ContentAccess : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _Id;
		
		private System.DateTime _EntryDate;
		
		private long _ContentId;
		
		private int _ProfileId;
		
		private bool _Inactive;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(long value);
    partial void OnIdChanged();
    partial void OnEntryDateChanging(System.DateTime value);
    partial void OnEntryDateChanged();
    partial void OnContentIdChanging(long value);
    partial void OnContentIdChanged();
    partial void OnProfileIdChanging(int value);
    partial void OnProfileIdChanged();
    partial void OnInactiveChanging(bool value);
    partial void OnInactiveChanged();
    #endregion
		
		public ContentAccess()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EntryDate", DbType="DateTime NOT NULL")]
		public System.DateTime EntryDate
		{
			get
			{
				return this._EntryDate;
			}
			set
			{
				if ((this._EntryDate != value))
				{
					this.OnEntryDateChanging(value);
					this.SendPropertyChanging();
					this._EntryDate = value;
					this.SendPropertyChanged("EntryDate");
					this.OnEntryDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContentId", DbType="BigInt NOT NULL")]
		public long ContentId
		{
			get
			{
				return this._ContentId;
			}
			set
			{
				if ((this._ContentId != value))
				{
					this.OnContentIdChanging(value);
					this.SendPropertyChanging();
					this._ContentId = value;
					this.SendPropertyChanged("ContentId");
					this.OnContentIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProfileId", DbType="Int NOT NULL")]
		public int ProfileId
		{
			get
			{
				return this._ProfileId;
			}
			set
			{
				if ((this._ProfileId != value))
				{
					this.OnProfileIdChanging(value);
					this.SendPropertyChanging();
					this._ProfileId = value;
					this.SendPropertyChanged("ProfileId");
					this.OnProfileIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Inactive", DbType="Bit NOT NULL")]
		public bool Inactive
		{
			get
			{
				return this._Inactive;
			}
			set
			{
				if ((this._Inactive != value))
				{
					this.OnInactiveChanging(value);
					this.SendPropertyChanging();
					this._Inactive = value;
					this.SendPropertyChanged("Inactive");
					this.OnInactiveChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Content")]
	public partial class Content : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _Id;
		
		private System.DateTime _EntryDate;
		
		private int _ProfileId;
		
		private string _LineMessageId;
		
		private string _DriveContentId;
		
		private string _MimeType;
		
		private bool _Inactive;
		
		private string _DriveDownloadUrl;
		
		private string _DrivePreviewUrl;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(long value);
    partial void OnIdChanged();
    partial void OnEntryDateChanging(System.DateTime value);
    partial void OnEntryDateChanged();
    partial void OnProfileIdChanging(int value);
    partial void OnProfileIdChanged();
    partial void OnLineMessageIdChanging(string value);
    partial void OnLineMessageIdChanged();
    partial void OnDriveContentIdChanging(string value);
    partial void OnDriveContentIdChanged();
    partial void OnMimeTypeChanging(string value);
    partial void OnMimeTypeChanged();
    partial void OnInactiveChanging(bool value);
    partial void OnInactiveChanged();
    partial void OnDriveDownloadUrlChanging(string value);
    partial void OnDriveDownloadUrlChanged();
    partial void OnDrivePreviewUrlChanging(string value);
    partial void OnDrivePreviewUrlChanged();
    #endregion
		
		public Content()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EntryDate", DbType="DateTime NOT NULL")]
		public System.DateTime EntryDate
		{
			get
			{
				return this._EntryDate;
			}
			set
			{
				if ((this._EntryDate != value))
				{
					this.OnEntryDateChanging(value);
					this.SendPropertyChanging();
					this._EntryDate = value;
					this.SendPropertyChanged("EntryDate");
					this.OnEntryDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProfileId", DbType="Int NOT NULL")]
		public int ProfileId
		{
			get
			{
				return this._ProfileId;
			}
			set
			{
				if ((this._ProfileId != value))
				{
					this.OnProfileIdChanging(value);
					this.SendPropertyChanging();
					this._ProfileId = value;
					this.SendPropertyChanged("ProfileId");
					this.OnProfileIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LineMessageId", DbType="VarChar(32) NOT NULL", CanBeNull=false)]
		public string LineMessageId
		{
			get
			{
				return this._LineMessageId;
			}
			set
			{
				if ((this._LineMessageId != value))
				{
					this.OnLineMessageIdChanging(value);
					this.SendPropertyChanging();
					this._LineMessageId = value;
					this.SendPropertyChanged("LineMessageId");
					this.OnLineMessageIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DriveContentId", DbType="VarChar(128) NOT NULL", CanBeNull=false)]
		public string DriveContentId
		{
			get
			{
				return this._DriveContentId;
			}
			set
			{
				if ((this._DriveContentId != value))
				{
					this.OnDriveContentIdChanging(value);
					this.SendPropertyChanging();
					this._DriveContentId = value;
					this.SendPropertyChanged("DriveContentId");
					this.OnDriveContentIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MimeType", DbType="VarChar(64) NOT NULL", CanBeNull=false)]
		public string MimeType
		{
			get
			{
				return this._MimeType;
			}
			set
			{
				if ((this._MimeType != value))
				{
					this.OnMimeTypeChanging(value);
					this.SendPropertyChanging();
					this._MimeType = value;
					this.SendPropertyChanged("MimeType");
					this.OnMimeTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Inactive", DbType="Bit NOT NULL")]
		public bool Inactive
		{
			get
			{
				return this._Inactive;
			}
			set
			{
				if ((this._Inactive != value))
				{
					this.OnInactiveChanging(value);
					this.SendPropertyChanging();
					this._Inactive = value;
					this.SendPropertyChanged("Inactive");
					this.OnInactiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DriveDownloadUrl", DbType="VarChar(256)")]
		public string DriveDownloadUrl
		{
			get
			{
				return this._DriveDownloadUrl;
			}
			set
			{
				if ((this._DriveDownloadUrl != value))
				{
					this.OnDriveDownloadUrlChanging(value);
					this.SendPropertyChanging();
					this._DriveDownloadUrl = value;
					this.SendPropertyChanged("DriveDownloadUrl");
					this.OnDriveDownloadUrlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DrivePreviewUrl", DbType="VarChar(256)")]
		public string DrivePreviewUrl
		{
			get
			{
				return this._DrivePreviewUrl;
			}
			set
			{
				if ((this._DrivePreviewUrl != value))
				{
					this.OnDrivePreviewUrlChanging(value);
					this.SendPropertyChanging();
					this._DrivePreviewUrl = value;
					this.SendPropertyChanged("DrivePreviewUrl");
					this.OnDrivePreviewUrlChanged();
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
}
#pragma warning restore 1591
