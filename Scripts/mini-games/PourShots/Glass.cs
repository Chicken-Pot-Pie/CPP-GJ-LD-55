using Godot;
using System;

public partial class Glass : StaticBody2D
{
	private double capacity = 0;
	private FillGlassSignal signal;

	[Export] String name;
    private float threshold = 7;

    public override void _Ready()
	{
		signal = GetNode<FillGlassSignal>("/root/FillGlassSignal");
		signal.FillGlass += OnFillGlass;
	}
	
	public void OnFillGlass(double pourRate, float X){
		if(Position.X < X + threshold && Position.X > X - threshold){
			GD.Print(name + " " + capacity);
			capacity += pourRate;
		}
	}
	
}
