extends Control

var levelsmenu_scene_path = "res://Scenes/Menus/LevelsMenu/LevelMenu.tscn"

func _ready():
	pass

func _on_StartButton_pressed():
	get_tree().change_scene(levelsmenu_scene_path)
	pass
