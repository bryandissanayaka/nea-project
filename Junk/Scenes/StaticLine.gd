extends StaticBody2D

#onready var rect = get_node("NinePatchRect")
onready var line = get_node("Line2D")

func scale(var size):
	scale.x = size


func set_points(var start_pos, var end_pos):
	var array = [start_pos, end_pos]
	line.set_points(array)
	Debug.Log2(start_pos, end_pos)
	
	
func rotate(var a_rotation):
	rotation_degrees = a_rotation 

func get_pixel_width():
	pass
