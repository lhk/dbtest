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
	/// <summary>
	/// All the current words
	/// </summary>
	List<Vocabs> wordsList;
	List<Vocabs>.Enumerator wordsEnumerator;

	float fraction=0;
	int currentNumber=0;
	int totalNumber=0;

	/// <summary>
	/// Background color of the drawing area
	/// Can be changed to green or red and will automatically fade back
	/// </summary>
	Cairo.Color backgroundColor;

	/// <summary>
	/// The rotation speed of the ? symbol in the drawing area
	/// </summary>
	public double rotationSpeed=0.3;
	/// <summary>
	/// The x coordinate speed of the ? symbol in the drawing area
	/// </summary>
	public double xSpeed=1;
	/// <summary>
	/// The y coordinate speed of the ? symbol in the drawing area
	/// </summary>
	public double ySpeed=1;
	/// <summary>
	/// The rotation of the ? symbol in the drawing area
	/// </summary>
	public double rotation=1;
	/// <summary>
	/// The x coordinate of the ? symbol in the drawing area
	/// </summary>
	public double x = 0;
	/// <summary>
	/// The y coordinate of the ? symbol in the drawing area
	/// </summary>
	public double y = 0;

	public MainWindow (List<Vocabs> wordsList, int number): base (Gtk.WindowType.Toplevel)
	{
		Console.WriteLine ("mainwindow");
		Build ();

		backgroundColor = new Color (0.2, 0.2, 0.2);

		fraction = 1 / number;
		totalNumber = number;
		this.wordsList = wordsList;
		wordsEnumerator =this.wordsList.GetEnumerator ();

		if (wordsEnumerator.MoveNext ())
			spanishLabel.Text = wordsEnumerator.Current.Question;

		GLib.Timeout.Add (20, new GLib.TimeoutHandler(onTimer));
	}

	/// <summary>
	/// Refresh the drawing area
	/// </summary>
	/// <returns><c>true</c>, if timer was oned, <c>false</c> otherwise.</returns>
	private bool onTimer(){
		drawingArea.QueueDraw ();
		return true;
	}

	/// <summary>
	/// flash the background red
	/// </summary>
	private void wrong(){
		backgroundColor.R = 1.5;
	}

	/// <summary>
	/// flash the background green
	/// </summary>
	private void right(){
		backgroundColor.G = 1.5;
	}

	/// <summary>
	/// check the current vocab, then setup the next
	/// </summary>
	/// <returns><c>true</c>, if there are vocabs left <c>false</c> if the final question was answered</returns>
	private bool nextVocab(){
		answerText.Text = "";
		progressBar.Fraction += fraction;
		if(progressBar.Fraction>1)
			progressBar.Fraction = 1;

		if (wordsEnumerator.MoveNext ()) {
			spanishLabel.Text = wordsEnumerator.Current.Question;
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

	/// <summary>
	/// Skip the current question, it's automatically wrong
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void skipClicked (object sender, EventArgs e)
	{
		wrong ();
		nextVocab ();
	}

	/// <summary>
	/// Check the current answer, wrong or false?
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void checkClicked (object sender, EventArgs e)
	{
		if (answerText.Text == wordsEnumerator.Current.Answer) {
			right ();
			nextVocab ();
		}
		else
			wrong ();
	}

	protected void onKeyPressed (object o, KeyReleaseEventArgs args)
	{
		if (args.Event.Key == Gdk.Key.Return) {
			if (answerText.Text == wordsEnumerator.Current.Answer) {
				right ();
				nextVocab ();
			} else
				wrong ();
		}
	}

	/// <summary>
	/// Called every time, the drawing area is rendered
	/// </summary>
	/// <param name="o">O.</param>
	/// <param name="args">Arguments.</param>
	protected void drawingAreaExposed (object o, ExposeEventArgs args)
	{
		// fade the background color back to normal
		// it might have been changed by right() or wrong()
		if (backgroundColor.R > 0.2)
			backgroundColor.R *= 0.97f;
		if (backgroundColor.G > 0.2)
			backgroundColor.G *= 0.97f;
		if (backgroundColor.B > 0.2)
			backgroundColor.B *= 0.97f;

		// get the drawing area's context and fill the background
		// if an answer was wrong, the backgroundColor will be shifted towards red, or green respectively
		DrawingArea area = (DrawingArea)o;
		Cairo.Context cx = Gdk.CairoHelper.Create (area.GdkWindow);
		cx.LineWidth = 9;
		cx.SetSourceRGB (backgroundColor.R, backgroundColor.G, backgroundColor.B);
		cx.Paint ();

		// width and height of the drawing area
		// TODO: Get the actual with and height
		int width, height;
		width = 100;
		height = 100;

		//-----------------------------------------------------
		// now a lot of code for a little bit of animation

		// bounce of the corners
		if (x > width||x<0)
			xSpeed *= -1;
		if (y > height||y<0)
			ySpeed *= -1;

		// move the ?
		x += xSpeed;
		y += ySpeed;

		// some random speed changes
		Random rand = new Random ();
		if (rand.NextDouble () > 0.8)
			xSpeed *= 1.5;
		else
			xSpeed *= 0.95;
		if (rand.NextDouble () > 0.8)
			ySpeed *= 1.5;
		else
			ySpeed *= 0.95;

		if (Math.Abs (xSpeed) > 3)
			xSpeed *= 0.8;
		if (Math.Abs (ySpeed) > 3)
			ySpeed *= 0.8;

		if (Math.Abs (xSpeed) < 0.05)
			xSpeed = 0.05;

		if (Math.Abs (ySpeed) < 0.05)
			ySpeed = 0.05;

		// rotate the ? symbol
		rotation += rotationSpeed;
		if (rotation < 0)
			rotation = 360;
		if (rotation > 360)
			rotation = 0;

		// some random rotation changes
		if (rand.NextDouble () > 0.98)
			rotationSpeed *= -1;

		//-----------------------------------------------

		// draw the ?
		cx.SelectFontFace ("Courier", FontSlant.Normal, FontWeight.Bold);
		cx.SetFontSize (70);
		cx.SetSourceRGB (1, 1, 1);

		TextExtents extents = cx.TextExtents ("?");

		cx.MoveTo (x - extents.Width / 2, y);
		cx.Rotate (rotation);
		cx.TextPath ("?");
		cx.Clip ();
		cx.Stroke ();
		cx.Paint ();

		cx.Dispose ();

	}
}
