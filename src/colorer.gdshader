shader_type canvas_item;
uniform sampler2D Palette1: filter_nearest;
uniform sampler2D Palette2: filter_nearest;
uniform sampler2D Palette3: filter_nearest;

void vertex() {
	// Called for every vertex the material is visible on.
}

void fragment() {
	// Called for every pixel the material is visible on.
	vec4 f = COLOR;
	if (f.r > 0.0 && f.g <= 0.0 && f.b <= 0.0) {
		float v = f.r;
		COLOR = texture(Palette1, vec2(v,0));
	}
	if (f.g > 0.0 && f.r <= 0.0 && f.b <= 0.0) {
		float v = f.g;
		COLOR = texture(Palette2, vec2(v,0));
	}
	if (f.b > 0.0 && f.r <= 0.0 && f.g <= 0.0) {
		float v = f.b;
		COLOR = texture(Palette3, vec2(v,0));
	}
	COLOR.a = f.a;
}
