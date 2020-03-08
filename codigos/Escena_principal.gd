extends Spatial


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

#array de escenas en el editor
export(Array,PackedScene) var mosaicos


export(int) var ancho = 10
export(int) var largo = 10
export(int) var tileXoffset = 2
export(int) var tileZoffset = 2
var rotar = Vector2()
var camara_elegida = 0

# Called when the node enters the scene tree for the first time.
func _ready():
	randomize()#semilla para que la aleatoriedad sea siempre diferente
	ancho = script_global.cantidad_instancias
	largo = script_global.cantidad_instancias
	$UI/Label.text = "Number of instances " +"\nX= " + str(script_global.cantidad_instancias) +"\nZ= " + str(script_global.cantidad_instancias) 
	forma1()
	

#func _process(delta):
	#$Camera.rotate_y(rotar_y * delta / 8)

func _input(event):
	rotarCamara(event)
	if Input.is_action_just_pressed("enter"):
		get_tree().change_scene("res://escenas/Escena_inicial.tscn")
	#hago que el mouse no este capturado
	if Input.is_action_just_pressed("esc"):
		Input.set_mouse_mode(Input.MOUSE_MODE_VISIBLE)	
	cambiarCamaras()


func forma1() -> void:#funcion que no devuelve ningún valor solamente procesa cosas
	for x in ancho:#tomo el valor del ancho
		for z in largo:#tomo el valor del largo
			#yield(get_tree().create_timer(0.001),"timeout")#detengo el tiempo,es solamente para ver como se forman los suelos
			var mosaico_frontal = mosaicos[0].instance()#instancio un nuevo suelo del arreglo de suelo
			$mosaicos.add_child(mosaico_frontal)#agregao como hijo del nodo mosaico el nodo instanciado
			mosaico_frontal.translation.x = (x * tileXoffset) - largo + 1 #multiplico el indice actual del bucle for por el offset y luego descuento el ancho más 1 para que quede bien posicionado
			mosaico_frontal.translation.z = (z * tileXoffset) - ancho + 1 #multiplico el indice actual del bucle for por el offset y luego descuento el ancho más 1 para que quede bien posicionado
			mosaico_frontal.translation.y = rand_range(0,1.0)#cubo aleatorio hacia arriba



func cambiarCamaras() -> void:#con esta funcion cambio de camaras
	if Input.is_action_just_pressed("w"):
		
		#contador para cambiar de camaras
		camara_elegida += 1
		if camara_elegida > 2:
			camara_elegida = 0
		match camara_elegida:#determina que camara elijo
			0:
				$camaras/Camera_superior.current = true
				$camaras/Camera_vista_media.current = false
				$camaras/Camera_aguila.current = false
			1:
				$camaras/Camera_superior.current = false
				$camaras/Camera_vista_media.current = true
				$camaras/Camera_aguila.current = false
			2:
				$camaras/Camera_superior.current = false
				$camaras/Camera_vista_media.current = false
				$camaras/Camera_aguila.current = true

func rotarCamara(event) -> void:#esta función es para rotar la camara
	if event is InputEventMouseMotion:#si muevo el mouse
		rotar = event.relative * -0.01#tomo elevento relativo del mouse y lo multiplico por un volar
		$camaras/Camera_vista_media.rotate_y(rotar.x)#roto la camara

func capturar_mouse() -> void:#funcion para capturar el mouse
	#Input.set_mouse_mode(Input.MOUSE_MODE_CAPTURED)#el mouse esta capturado
	Input.set_mouse_mode(Input.MOUSE_MODE_CONFINED)#hace el mouse invisible
	$UI/capturar_mouse_boton.visible = false


	
func _on_capturar_mouse_boton_pressed():
	#capturar_mouse()
	pass
