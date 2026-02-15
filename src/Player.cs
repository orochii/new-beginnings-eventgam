using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	[Export] private Visuals Visuals;
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		/*
		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}
		*/
		// Get the input direction and handle the movement/deceleration.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		velocity.X = (direction.X != 0) ? direction.X * Speed : Mathf.MoveToward(Velocity.X, 0, Speed);
		velocity.Y = (direction.Y != 0) ? direction.Y * Speed : Mathf.MoveToward(Velocity.Y, 0, Speed);
		if (direction.X != 0)
		{
			var s = direction.X > 0 ? 1 : -1;
			Visuals.Scale = new Vector2(s,1);
		}
		Velocity = velocity;
		MoveAndSlide();
	}
}
