extends Node2D

var is_drawing = false

var start_position = Vector2.ZERO
var end_position = Vector2.ZERO
var line_vector = Vector2.ZERO
var line_length : float = 0
var line_rotation : float = 0

func _draw_line():
	print("Drawing line from ", start_position, " to " , end_position)
	line_vector = end_position - start_position
	line_length = line_vector.length()
	line_rotation = atan2(line_vector.y, line_vector.x) * 57.29577951 + 90
	print("Line length: ", line_length)
	print(line_rotation)
	

func _input(event):
	if event is InputEventMouseButton:
		is_drawing = not is_drawing
		start_position = event.global_position
	elif (event is InputEventMouseMotion) and (is_drawing):
		end_position = event.global_position
		_draw_line()

func _ready():
	pass # Replace with function body.

#func _process(delta):
#	pass
