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
	List<Spanish_German>.Enumerator wordsEnumerator;
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

	public MainWindow (List<Spanish_German> wordsList, int number): base (Gtk.WindowType.Toplevel)
	{
		Console.WriteLine ("mainwindow");
		Build ();

		backgroundColor = new Color (0.2, 0.2, 0.2);

		fraction = 1 / number;
		totalNumber = number;
		wordsEnumerator =wordsList.GetEnumerator ();

		if (wordsEnumerator.MoveNext ())
			spanishLabel.Text = wordsEnumerator.Current.Spanish;

		GLib.Timeout.Add (20, new GLib.TimeoutHandler(onTimer));
	}

	private bool onTimer(){
		drawingArea.QueueDraw ();
		return true;
	}

	private void wrong(){
		backgroundColor.R = 1;
	}

	private void right(){
		backgroundColor.G = 1;
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
		if (answerText.Text == wordsEnumerator.Current.German) {
			right ();
			nextVocab ();
		}
		else
			wrong ();
	}

	protected void drawingAreaExposed (object o, ExposeEventArgs args)
	{
		if (backgroundColor.R > 0.2)
			backgroundColor.R *= 0.97f;
		if (backgroundColor.G > 0.2)
			backgroundColor.G *= 0.97f;
		if (backgroundColor.B > 0.2)
			backgroundColor.B *= 0.97f;

		DrawingArea area = (DrawingArea)o;
		Cairo.Context cx = Gdk.CairoHelper.Create (area.GdkWindow);

		cx.LineWidth = 9;
		cx.SetSourceRGB (backgroundColor.R, backgroundColor.G, backgroundColor.B);
		cx.Paint ();

		int width, height;
		width = area.WidthRequest;
		height = area.HeightRequest;

		if (x > width||x<0)
			xSpeed *= -1;
		if (y > height||y<0)
			ySpeed *= -1;

		x += xSpeed;
		y += ySpeed;

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

		rotation += rotationSpeed;
		if (rotation < 0)
			rotation = 360;
		if (rotation > 360)
			rotation = 0;

		if (rand.NextDouble () > 0.98)
			rotationSpeed *= -1;

		cx.SelectFontFace ("Courier", FontSlant.Normal, FontWeight.Bold);
		cx.SetFontSize (50);
		cx.SetSourceRGB (1, 1, 1);

		TextExtents extents = cx.TextExtents ("?");

		cx.MoveTo (x - extents.Width / 2, y);
		cx.Rotate (rotation);
		cx.TextPath ("?");
		cx.Clip ();
		cx.Stroke ();
		cx.Paint ();


	}
}
