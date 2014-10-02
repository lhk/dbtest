using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Linq;
using Mono.Data.Sqlite;
using Gtk;

namespace Vokabeltrainerdor
{
	using Vokabeltrainerdor.DbLinq;
	class MainClass
	{
		public static void Main (string[] args)
		{

			string connectionString = "Data Source=databases/languages2.sqlite;";

			SqliteConnection sqliteConn = new SqliteConnection (connectionString);
			LanguageDB lang = new LanguageDB (sqliteConn);
			Table<Vocabs> wordsTable = lang.GetTable<Vocabs> ();
			foreach (Vocabs word in wordsTable) {
				Console.WriteLine (word.Answer);
			}

			var query =
				from word in wordsTable
					select word;

			int number = 0;
			List<Vocabs> wordsList = new List<Vocabs> ();
			foreach (Vocabs word in query) {
				number++;
				wordsList.Add (word);
			}

			Application.Init ();
			MainWindow win = new MainWindow (wordsList,number);
			win.Show ();
			Application.Run ();
		}
	}
}