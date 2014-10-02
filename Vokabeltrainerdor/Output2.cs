// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from main on 2014-10-02 18:03:51Z.
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
		
		public Table<Vocabs> VOCabs
		{
			get
			{
				return this.GetTable <Vocabs>();
			}
		}
	}
	
	[Table(Name="main.vocabs")]
	public partial class Vocabs : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _answer;
		
		private System.Nullable<int> _box;
		
		private string _classification;
		
		private System.Nullable<int> _id;
		
		private System.Nullable<int> _lang;
		
		private string _nextQuery;
		
		private string _question;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnAnswerChanged();
		
		partial void OnAnswerChanging(string value);
		
		partial void OnBoxChanged();
		
		partial void OnBoxChanging(System.Nullable<int> value);
		
		partial void OnClassificationChanged();
		
		partial void OnClassificationChanging(string value);
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(System.Nullable<int> value);
		
		partial void OnLangChanged();
		
		partial void OnLangChanging(System.Nullable<int> value);
		
		partial void OnNextQueryChanged();
		
		partial void OnNextQueryChanging(string value);
		
		partial void OnQuestionChanged();
		
		partial void OnQuestionChanging(string value);
		#endregion
		
		
		public Vocabs()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_answer", Name="answer", DbType="TEXT", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Answer
		{
			get
			{
				return this._answer;
			}
			set
			{
				if (((_answer == value) == false))
				{
					this.OnAnswerChanging(value);
					this.SendPropertyChanging();
					this._answer = value;
					this.SendPropertyChanged("Answer");
					this.OnAnswerChanged();
				}
			}
		}
		
		[Column(Storage="_box", Name="box", DbType="INTEGER", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> Box
		{
			get
			{
				return this._box;
			}
			set
			{
				if ((_box != value))
				{
					this.OnBoxChanging(value);
					this.SendPropertyChanging();
					this._box = value;
					this.SendPropertyChanged("Box");
					this.OnBoxChanged();
				}
			}
		}
		
		[Column(Storage="_classification", Name="classification", DbType="TEXT", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Classification
		{
			get
			{
				return this._classification;
			}
			set
			{
				if (((_classification == value) == false))
				{
					this.OnClassificationChanging(value);
					this.SendPropertyChanging();
					this._classification = value;
					this.SendPropertyChanged("Classification");
					this.OnClassificationChanged();
				}
			}
		}
		
		[Column(Storage="_id", Name="id", DbType="INTEGER", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> ID
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((_id != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_lang", Name="lang", DbType="INTEGER", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> Lang
		{
			get
			{
				return this._lang;
			}
			set
			{
				if ((_lang != value))
				{
					this.OnLangChanging(value);
					this.SendPropertyChanging();
					this._lang = value;
					this.SendPropertyChanged("Lang");
					this.OnLangChanged();
				}
			}
		}
		
		[Column(Storage="_nextQuery", Name="nextquery", DbType="TEXT", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string NextQuery
		{
			get
			{
				return this._nextQuery;
			}
			set
			{
				if (((_nextQuery == value) == false))
				{
					this.OnNextQueryChanging(value);
					this.SendPropertyChanging();
					this._nextQuery = value;
					this.SendPropertyChanged("NextQuery");
					this.OnNextQueryChanged();
				}
			}
		}
		
		[Column(Storage="_question", Name="question", DbType="TEXT", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Question
		{
			get
			{
				return this._question;
			}
			set
			{
				if (((_question == value) == false))
				{
					this.OnQuestionChanging(value);
					this.SendPropertyChanging();
					this._question = value;
					this.SendPropertyChanged("Question");
					this.OnQuestionChanged();
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
