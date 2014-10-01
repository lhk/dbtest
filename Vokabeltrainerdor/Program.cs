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

			string connectionString = "Data Source=databases/languages.sqlite;";

			SqliteConnection sqliteConn = new SqliteConnection (connectionString);
			LanguageDB lang = new LanguageDB (sqliteConn);
			Table<Spanish_German> wordsTable = lang.GetTable<Spanish_German> ();
			foreach (Spanish_German word in wordsTable) {
				Console.WriteLine (word.German);
			}

			var query =
				from word in wordsTable
					select word;

			int number = 0;
			List<Spanish_German> wordsList = new List<Spanish_German> ();
			foreach (Spanish_German word in query) {
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