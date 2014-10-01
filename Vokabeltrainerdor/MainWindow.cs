using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Linq;
using Mono.Data.Sqlite;
using Gtk;
using Vokabeltrainerdor.DbLinq;
public partial class MainWindow: Gtk.Window
{	
	List<Spanish_German> wordsList;
	List<Spanish_German>.Enumerator wordsEnumerator;
	int number=0;
	public MainWindow (List<Spanish_German> wordsList, int number): base (Gtk.WindowType.Toplevel)
	{
		Console.WriteLine ("mainwindow");
		Build ();
		this.wordsList = wordsList; wordsList.GetEnumerator ();
		wordsEnumerator = wordsList.GetEnumerator ();
		if (wordsEnumerator.MoveNext ())
			Console.WriteLine (wordsEnumerator.Current.German);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void skipClicked (object sender, EventArgs e)
	{
		progressBar.Fraction += 0.1;
		if(progressBar.Fraction>1)
			progressBar.Fraction = 1;
	}

}
