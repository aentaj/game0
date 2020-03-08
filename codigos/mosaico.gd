extends Spatial

const materialNaranja = preload("res://materiales/naranja.tres")#precargo el material
onready var materialGris = $mosaico_prueba/Cube.get_material_override()#obtengo el color gris
# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass

func _on_Area_mouse_entered():
	pass
	#print("entro el mouse")
	#if Input.is_action_just_pressed("click_izquierdo"):
		#print("entro el mouse y click")


func _on_Area_input_event(camera, event, click_position, click_normal, shape_idx):
	if event is InputEventMouseButton:#si el evento dentro del area es un boton del mouse
		if Input.is_action_just_pressed("click_izquierdo"):#si presiono click izquierdo
			$mosaico_prueba/Cube.set_surface_material(0,materialNaranja)#cambio el material
