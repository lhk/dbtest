using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Linq;
using Mono.Data.Sqlite;
using Gtk;
using Cairo;
using Vokabeltrainerdor.DbLinq;
public partial class MainWindow: Gtk.Window
{	
	List<Spanish_German>.Enumerator wordsEnumerator;
	float fraction=0;
	int currentNumber=0;
	int totalNumber=0;
	public MainWindow (List<Spanish_German> wordsList, int number): base (Gtk.WindowType.Toplevel)
	{
		Console.WriteLine ("mainwindow");
		Build ();

		fraction = 1 / number;
		totalNumber = number;
		wordsEnumerator =wordsList.GetEnumerator ();
	}

	private void wrong(){

	}

	private bool nextVocab(){

		progressBar.Fraction += fraction;
		if(progressBar.Fraction>1)
			progressBar.Fraction = 1;

		if (wordsEnumerator.MoveNext ()) {
			spanishLabel.Text = wordsEnumerator.Current.Spanish;
			return true;
		} else {
			return false;
		}
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void skipClicked (object sender, EventArgs e)
	{

	}

	protected void checkClicked (object sender, EventArgs e)
	{
		nextVocab ();
	}

	protected void drawingAreaExposed (object o, ExposeEventArgs args)
	{
		DrawingArea area = (DrawingArea)o;
		Cairo.Context cx = Gdk.CairoHelper.Create (area.GdkWindow);

		cx.LineWidth = 9;
		cx.SetSourceRGB (1, 0, 0);

		int width, height;
		width = area.WidthRequest;
		height = area.HeightRequest;

		cx.Translate (width / 2, height / 2);
		cx.Arc (0, 0, (width < height ? width : height) / 2 - 10, 0, 2 * Math.PI);
		cx.StrokePreserve ();

		cx.SetSourceRGB (0.3, 0.4, 0.6);
		cx.Fill ();

	}
}
