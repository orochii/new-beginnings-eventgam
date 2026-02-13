using Godot;
using System;
using System.Net.Mail;

public partial class Visuals : Node2D
{
	[Export] private AnimatedSprite2D[] Sprites;
	[Export] private Texture2D Palette1;
	[Export] private Texture2D Palette2;
	[Export] private Texture2D Palette3;
    public override void _Ready()
    {
        base._Ready();
		Recolor();
    }
	public void Recolor()
	{
		foreach (var s in Sprites) {
			//
			var m = s.Material;
			if (m != null)
			{
				var sm = m as ShaderMaterial;
				sm.SetShaderParameter("Palette1", Palette1);
				sm.SetShaderParameter("Palette2", Palette2);
				sm.SetShaderParameter("Palette3", Palette3);
			}
		}
	}
	public void PlayAnimation(StringName name)
	{
		foreach (var s in Sprites)
		{
			if (s.SpriteFrames.HasAnimation(name)) s.Animation = name;
		}
	}
}
