extends StaticBody2D

onready var area = get_node("Area2D")
onready var sprite = get_node("Sprite")
onready var physics_area = get_node("CollisionShape2D")
export (PackedScene) var player_scene
var player_node

func _ready():
	sprite.set_process(false)
	physics_area.set_process(false)
	pass

func scale(var size):
	scale.x = size

func validate(): #checks if it overlaps other collision objects before enabling sprite and collision
	var a = area.get_overlapping_bodies()
	if a.empty():
		Debug.Log1("")
		sprite.set_process(true)
		physics_area.set_process(true)
	pass
	
	
func rotate(var a_rotation):
	rotation_degrees = a_rotation

func get_pixel_width():
	pass
