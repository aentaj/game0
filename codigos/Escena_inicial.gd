extends Node2D


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	Input.set_mouse_mode(Input.MOUSE_MODE_HIDDEN)
	Input.set_mouse_mode(Input.MOUSE_MODE_VISIBLE)
	$TextEdit.grab_focus()#puedo escribir directamente en la pantalla


func _process(delta):
	script_global.cantidad_instancias = int($TextEdit.text)
	
func _input(event):
	if Input.is_action_just_pressed("enter"):
		get_tree().change_scene("res://escenas/Escena_principal.tscn")
