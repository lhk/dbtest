// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from main on 2014-10-01 15:51:49Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
namespace Vokabeltrainerdor.DbLinq
{
	using System;
	using System.ComponentModel;
	using System.Data;
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Diagnostics;
	
	
	public partial class LanguageDB : DataContext
	{
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		#endregion
		
		
		public LanguageDB(string connectionString) : 
				base(connectionString)
		{
			this.OnCreated();
		}
		
		public LanguageDB(IDbConnection connection) : 
				base(connection)
		{
			this.OnCreated();
		}
		
		public LanguageDB(string connection, MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			this.OnCreated();
		}
		
		public LanguageDB(IDbConnection connection, MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			this.OnCreated();
		}
		
		public Table<Spanish_German> Spanish_German
		{
			get
			{
				return this.GetTable <Spanish_German>();
			}
		}
	}
	
	[Table(Name="main.spanish-german")]
	public partial class Spanish_German : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private int _difficulty;
		
		private string _german;
		
		private int _level;
		
		private string _spanish;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnDifficultyChanged();
		
		partial void OnDifficultyChanging(int value);
		
		partial void OnGermanChanged();
		
		partial void OnGermanChanging(string value);
		
		partial void OnLevelChanged();
		
		partial void OnLevelChanging(int value);
		
		partial void OnSpanishChanged();
		
		partial void OnSpanishChanging(string value);
		#endregion
		
		
		public Spanish_German()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_difficulty", Name="difficulty", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int Difficulty
		{
			get
			{
				return this._difficulty;
			}
			set
			{
				if ((_difficulty != value))
				{
					this.OnDifficultyChanging(value);
					this.SendPropertyChanging();
					this._difficulty = value;
					this.SendPropertyChanged("Difficulty");
					this.OnDifficultyChanged();
				}
			}
		}
		
		[Column(Storage="_german", Name="german", DbType="TEXT", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string German
		{
			get
			{
				return this._german;
			}
			set
			{
				if (((_german == value) == false))
				{
					this.OnGermanChanging(value);
					this.SendPropertyChanging();
					this._german = value;
					this.SendPropertyChanged("German");
					this.OnGermanChanged();
				}
			}
		}
		
		[Column(Storage="_level", Name="level", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int Level
		{
			get
			{
				return this._level;
			}
			set
			{
				if ((_level != value))
				{
					this.OnLevelChanging(value);
					this.SendPropertyChanging();
					this._level = value;
					this.SendPropertyChanged("Level");
					this.OnLevelChanged();
				}
			}
		}
		
		[Column(Storage="_spanish", Name="spanish", DbType="TEXT", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string Spanish
		{
			get
			{
				return this._spanish;
			}
			set
			{
				if (((_spanish == value) == false))
				{
					this.OnSpanishChanging(value);
					this.SendPropertyChanging();
					this._spanish = value;
					this.SendPropertyChanged("Spanish");
					this.OnSpanishChanged();
				}
			}
		}
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
