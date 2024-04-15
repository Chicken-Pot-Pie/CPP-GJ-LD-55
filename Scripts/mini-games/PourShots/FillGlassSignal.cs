using Godot;
using System;

public partial class FillGlassSignal : Node
{
	[Signal]
	public delegate void FillGlassEventHandler(double pourRate, float x);
}
