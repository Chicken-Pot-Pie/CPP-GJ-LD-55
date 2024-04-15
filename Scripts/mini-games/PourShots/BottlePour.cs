using Godot;
using System;
using System.Numerics;

public partial class BottlePour : CharacterBody2D
{
	private double pourRate =.5;
	private FillGlassSignal signal;
	private float yPos;

	float speed = 1000;
	
	[Export] 
	RayCast2D ray;
    private bool isPouring;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		signal = GetNode<FillGlassSignal>("/root/FillGlassSignal");
		yPos = Position.Y;
		isPouring = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Godot.Vector2 newPos = new Godot.Vector2(GetGlobalMousePosition().X, yPos);
		Position = Position.MoveToward(newPos, (float) delta * speed);

		if(ray.IsColliding() && isPouring){
			signal.EmitSignal(nameof(FillGlassSignal.FillGlass), pourRate,Position.X);	
		
		}

	}

	public override void _Input(InputEvent @event)
	{
		// Mouse in viewport coordinates.
		if (@event.IsActionPressed("left_mouse_click") ){//is InputEventMouseButton eventMouseButtonPressed && eventMouseButtonPressed.Pressed &&  eventMouseButtonPressed.ButtonIndex == MouseButton.Left){
			isPouring = true;
			GetNode<Sprite2D>("Sprite2D").Rotate(Mathf.Pi/4 + Mathf.Pi);
		}
			
		if(@event.IsActionReleased("left_mouse_click") ) //is InputEventMouseButton eventMouseButtonReleased && eventMouseButtonReleased.IsReleased() &&  eventMouseButtonReleased.ButtonIndex == MouseButton.Left)
		{
			isPouring = false;
			GetNode<Sprite2D>("Sprite2D").Rotate(-Mathf.Pi/4 + Mathf.Pi);
		}	
	}
}
