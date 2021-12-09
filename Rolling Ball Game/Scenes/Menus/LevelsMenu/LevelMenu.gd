extends Control

var mainmenu_scene_path = "res://Scenes/Menus/MainMenu/MainMenu.tscn"

func _on_FromLevelScreenToStart_pressed():
	get_tree().change_scene(mainmenu_scene_path)
	pass
