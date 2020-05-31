﻿using CodeImp.DoomBuilder.Geometry;
using CodeImp.DoomBuilder.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeImp.DoomBuilder.BuilderModes
{
	public class EventLine
	{
		private Vector3D start;
		private Vector3D end;
		private Line3D line;
		private TextLabel label;

		public Line3D Line { get { return line; } }
		public TextLabel Label { get { return label; } }

		public EventLine(Vector3D start, Vector3D end)
		{
			this.start = start;
			this.end = end;

			line = new Line3D(start, end);
			label = null;
		}

		public EventLine(Vector3D start, Vector3D end, string text) : this(start, end, text, General.Colors.InfoLine)
		{
		}

		public EventLine(Vector3D start, Vector3D end, string text, PixelColor color)
		{
			this.start = start;
			this.end = end;

			line = new Line3D(start, end, color.WithAlpha(255));

			if (!string.IsNullOrEmpty(text))
			{
				label = new TextLabel();
				label.Text = text;
				label.TransformCoords = true;
				label.Location = Line2D.GetCoordinatesAt(start, end, 0.5f);
				label.AlignX = TextAlignmentX.Center;
				label.AlignY = TextAlignmentY.Middle;
				label.Color = color.WithAlpha(255);
				label.BackColor = General.Colors.Background; // .WithAlpha(255);
			}
			else
			{
				label = null;
			}
		}

		public void SetColor(PixelColor color)
		{
			line.Color = color;
			label.Color = color;
		}
	}
}