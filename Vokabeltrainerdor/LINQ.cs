// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from main on 2014-10-06 10:29:05Z.
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
		
		public Table<Vocab> VOCab
		{
			get
			{
				return this.GetTable <Vocab>();
			}
		}
	}
	
	[Table(Name="main.vocab")]
	public partial class Vocab
	{
		
		private string _answer;
		
		private string _lang;
		
		private System.Nullable<int> _level;
		
		private string _question;
		
		private string _type;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnAnswerChanged();
		
		partial void OnAnswerChanging(string value);
		
		partial void OnLangChanged();
		
		partial void OnLangChanging(string value);
		
		partial void OnLevelChanged();
		
		partial void OnLevelChanging(System.Nullable<int> value);
		
		partial void OnQuestionChanged();
		
		partial void OnQuestionChanging(string value);
		
		partial void OnTypeChanged();
		
		partial void OnTypeChanging(string value);
		#endregion
		
		
		public Vocab()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_answer", Name="answer", DbType="text", AutoSync=AutoSync.Never)]
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
					this._answer = value;
					this.OnAnswerChanged();
				}
			}
		}
		
		[Column(Storage="_lang", Name="lang", DbType="text", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Lang
		{
			get
			{
				return this._lang;
			}
			set
			{
				if (((_lang == value) == false))
				{
					this.OnLangChanging(value);
					this._lang = value;
					this.OnLangChanged();
				}
			}
		}
		
		[Column(Storage="_level", Name="level", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> Level
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
					this._level = value;
					this.OnLevelChanged();
				}
			}
		}
		
		[Column(Storage="_question", Name="question", DbType="text", AutoSync=AutoSync.Never)]
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
					this._question = value;
					this.OnQuestionChanged();
				}
			}
		}
		
		[Column(Storage="_type", Name="type", DbType="text", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Type
		{
			get
			{
				return this._type;
			}
			set
			{
				if (((_type == value) == false))
				{
					this.OnTypeChanging(value);
					this._type = value;
					this.OnTypeChanged();
				}
			}
		}
	}
}
