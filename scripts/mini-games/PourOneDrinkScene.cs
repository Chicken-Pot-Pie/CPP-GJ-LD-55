using Godot;
using System;
using System.Collections.Generic;

public partial class PourOneDrinkScene : Node2D
{
	private float _goalHeight;

	private float _actualHeight;
	private float _flowRate;
	private int _score;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_goalHeight = getGoalHeight();
		setLineHeight("Goal Quantity of drink", _goalHeight);
		_flowRate = 80;
		_score = 0;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
    {
		Line2D goalDrinkQuantity = (Line2D)GetNode("Goal Quantity of drink");
        StaticBody2D actualDrinkQuantity = (StaticBody2D)GetNode("Actual Quantity of drink");
		Godot.Vector2 goalPoint = new(actualDrinkQuantity.Position.X, goalDrinkQuantity.GetPointPosition(0).Y);
		actualDrinkQuantity.Position = actualDrinkQuantity.Position.MoveToward(goalPoint, _flowRate * (float)delta);
		GD.Print(actualDrinkQuantity.Position);
    }

	//When space is pressed, stops the game after calculating the score obtained in the minigame.
    public override void _Input(InputEvent @event) {
    	if (@event.IsActionPressed("space")) {
			Scoring();
			GD.Print(_score + " %");
    	}
	}

	//Sets the y value of a Line2D.
	//To eventually delete.
	private void setLineHeight(String node, float newYPosition) {
		Line2D actualDrinkQuantity = (Line2D)GetNode(node);
		var points = actualDrinkQuantity.Points;
		for(int i = 0; i < points.Length; i++) {
			points[i].Y = newYPosition;
		}
		actualDrinkQuantity.Points = points;
		//actualDrinkQuantity._Draw();
	}

	//Returns the y value relative to the canvas of the goal to reach.
	private float getGoalHeight() {
		Sprite2D glass = (Sprite2D)GetNode("Glass");
		return glass.Position.Y - (float)(0.5*glass.Texture.GetHeight());
	}

	//Returns the y value relative to the canvas of the bottom of the glass.
	private float getbaseHeight() {
		Sprite2D glass = (Sprite2D)GetNode("Glass");
		return glass.Position.Y + (float)glass.Texture.GetHeight();
	}

	//Calculates the score in percentages.
	//To completely redo.
	private void Scoring() {
        _score = (int)(1 - (Math.Abs(_goalHeight - _actualHeight) / (getbaseHeight() - getGoalHeight())));
	}

	public double GetScore() {
		return _score;
	}

}
