using Godot;

public enum EBodySlot {
    BODY,HEAD,TAIL,SIDES,DORSAL,NECK,HORN,
}

[GlobalClass]
public partial class BodyPart : Resource {
    const string PATH = "res://data/parts/";
    const string EXT = ".tres";
    // Part properties
    [Export] EBodySlot Slot;
    [Export] int HealthPlus;
    [Export] int BitePlus;
    [Export] int TacklePlus;
    [Export] int SpeedPlus;
    [Export] int JumpPlus;
    // Display
    [Export] string DisplayName;
    [Export] string DisplayDesc;
    [Export] SpriteFrames Frames;
    // Resource management
    static BodyPart GetData(StringName n) {
        var fname = $"{PATH}{n}{EXT}";
        return OZResourceLoader.Load<BodyPart>(fname);
    }
    public StringName GetId() {
        var len = this.ResourcePath.Length - PATH.Length - EXT.Length;
        return this.ResourcePath.Substring(PATH.Length, len);
    }
}