extends Node2D

const RAD_TO_DEGREES = 57.29577951

var is_drawing = false
var start_position = Vector2.ZERO
var end_position = Vector2.ZERO
var line_vector = Vector2.ZERO
var line_length : float = 0
var line_rotation : float = 0
var line_midpoint = Vector2.ZERO
const LINE_PIXEL_WIDTH = 1
# export keyword exposes the variable in the inspector tab. it can be assigned directly in the field in the editor 
export (PackedScene) var line_scene

#slider variables
var max_ink = 1600
var current_ink
onready var bar = get_node("ProgressBar")
var min_line_length = 10

func _ready():
	current_ink = max_ink
	bar.max_value = max_ink
	bar.value = current_ink

func _use_ink(var amount):
	if(amount < min_line_length): return false
	var remaining_ink = current_ink - amount
	if(remaining_ink >= min_line_length):
		current_ink = remaining_ink
		bar.value = current_ink
		return true
	else:
		return false

func _draw_line():
	line_vector = end_position - start_position
#	print("start pos: ", start_position , " ~ end position: ", end_position , " ~ line vec: ", line_vector)
	line_length = line_vector.length()
	if not _use_ink(line_length): return #check if there is enough ink to draw the line
	line_rotation = atan2(line_vector.y, line_vector.x) * RAD_TO_DEGREES
	line_midpoint = Vector2(line_vector.x / 2, line_vector.y / 2)
	var line = line_scene.instance()
	add_child(line)
	line.global_position = start_position + line_midpoint
	line.scale(line_length / LINE_PIXEL_WIDTH)
	line.rotate(line_rotation)
	print(current_ink)
	

func _input(event):
	if event is InputEventMouseButton:
		if event.button_index == BUTTON_LEFT:
			if event.pressed: #left click pressed
				start_position = event.global_position
			else: #left click released
				end_position = event.global_position
				_draw_line()
	pass

