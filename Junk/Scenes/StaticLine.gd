extends StaticBody2D

var mouse_in_area = false

func scale(var size):
	scale.x = size
	
	
func rotate(var a_rotation):
	rotation_degrees = a_rotation

func get_pixel_width():
	pass


func _on_Body_input_event(viewport, event, shape_idx):
	if(mouse_in_area):
		if event is InputEventMouseButton:
			if event.button_index == BUTTON_RIGHT:
				if event.pressed:
					queue_free()


func _on_Body_mouse_entered():
	mouse_in_area = true
	print(mouse_in_area)


func _on_Body_mouse_exited():
	mouse_in_area = false
	print(mouse_in_area)
