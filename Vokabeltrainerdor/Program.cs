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
		/// <summary>
		/// The entry point of the program.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main (string[] args)
		{

			string connectionString = "Data Source=databases/languages.sqlite;";

			SqliteConnection sqliteConn = new SqliteConnection (connectionString);
			LanguageDB lang = new LanguageDB (sqliteConn);
			Table<Vocab> wordsTable = lang.GetTable<Vocab> ();

			int number = 0;
			List<Vocab> wordsList = new List<Vocab> ();
			foreach (Vocab word in wordsTable) {
				Console.WriteLine (word.Lang);
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