extends Control

var levelsmenu_scene_path = "res://Scenes/Menus/LevelsMenu/LevelMenu.tscn"
var optionsmenu_scene_path = "res://Scenes/Menus/OptionsMenu/OptionsMenu.tscn"

func _on_StartButton_pressed():
	get_tree().change_scene(levelsmenu_scene_path)
	pass

func _on_Options_pressed():
	get_tree().change_scene(optionsmenu_scene_path)
	pass

