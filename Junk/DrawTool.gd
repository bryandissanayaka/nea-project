extends Node2D

const RAD_TO_DEGREES = 57.29577951

var is_drawing = false
var start_position = Vector2.ZERO
var end_position = Vector2.ZERO
var line_vector = Vector2.ZERO
var line_length : float = 0
var line_rotation : float = 0
var line_midpoint = Vector2.ZERO
const LINE_PIXEL_WIDTH = 32

export (PackedScene) var line_scene


func _draw_line():
	line_vector = end_position - start_position
	print("start pos: ", start_position , " ~ end position: ", end_position , " ~ line vec: ", line_vector)
	line_length = line_vector.length()
	line_rotation = atan2(line_vector.y, line_vector.x) * RAD_TO_DEGREES
	line_midpoint = Vector2(line_vector.x / 2, line_vector.y / 2)
	var line = line_scene.instance()
	add_child(line)  #dont know why but i have to add child
	line.global_position = start_position + line_midpoint
	line.scale(line_length / LINE_PIXEL_WIDTH)
	line.rotate(line_rotation)
	
func _input(event):
	if event is InputEventMouseButton:
		is_drawing = not is_drawing
		if(is_drawing):
			start_position = event.global_position
			#_draw_line()
		else : #when releasing mouse button
			_draw_line()
			
	elif (event is InputEventMouseMotion) and (is_drawing):
		end_position = event.global_position


func _process(delta):
	pass
