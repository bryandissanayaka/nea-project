extends Node2D

var x = 0
var y = 0
var z = 0


func _ready():
	x = 1
	y = 1
	z = x + y
	print(z)
	pass

func _process(delta):
	x = y
	y = z
	z = x + y
	print(z)
