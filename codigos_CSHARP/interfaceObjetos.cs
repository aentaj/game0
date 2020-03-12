using Godot;
using Godot.Collections;
using System;

public class interfaceObjetos : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    
    private Array<PackedScene> edificios = new Array<PackedScene>();
    private Camera Camera_aguila,Camera_superior,Camera_vista_media;//para precargar las camaras

    private Spatial edificioInstanciado;

    private Spatial building;
    private PopupMenu MenuCasas;//referencia al poput menu
    private bool InstanciarCasa = false;
    //private Vector3 posicionNuevaCasa;


    //TODO ESTO ES RELACIONADO A LA CAMARA MUY IMPORTANTE
    [Export]
    int RayoDistancia = 1000;
    // Called when the node enters the scene tree for the first time.

    //private Godot.Collections.Dictionary intercepto = new Godot.Collections.Dictionary(); //diccionario global que guarda las posiciones donde esta el mouse
    //private Godot.Collections.Array intercepto = new Godot.Collections.Array { };

    private string CamaraActiva;//para saber cual es la camara activa
    private Camera camaraActual;//la camara actual activa
    private Vector3 origen;
    private Vector3 destino;
    private PhysicsDirectSpaceState espacio;
    private Dictionary intercepto;
    /////////////////////////////////////////////////////////////////

    public override void _Ready()
    {
        MenuCasas = (PopupMenu)GetTree().GetNodesInGroup("PopupMenu")[0];//como el popupmenu es el segundo el indice es 1
        building = (Spatial)GetTree().GetNodesInGroup("building")[0];//busco el nodo donde se crearan los edificios
        //precargo las camaras
        Camera_aguila =((Camera)GetTree().GetNodesInGroup("Camera_aguila")[0]);//guardo la camara
        Camera_superior = ((Camera)GetTree().GetNodesInGroup("Camera_superior")[0]);//guardo la camara
        Camera_vista_media = ((Camera)GetTree().GetNodesInGroup("Camera_vista_media")[0]);//guardo la camara
        CamaraActiva = GetViewport().GetCamera().Name;//tomo la camara activa del viewport
    }
        
        
        
        

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
   public override void _Process(float delta)
   {
        if(InstanciarCasa)
        {
            if( InstanciarCasa == true)
            {
                RayoDeCamara();
            }
                
            if(Input.IsActionJustPressed("click_derecho"))
            {
                InstanciarCasa = false;
            }
        }    
       GD.Print(GetViewport().GetCamera().Name);   
       //GD.Print(GetGlobalMousePosition());  
   }

    private void _on_Button_button_down()
    {
        MenuCasas.Show();
    }

    private void _on_Button2_button_down()
    {  
        GD.Print("presione el primer boton");
        instanciarEdificio(0);//si presiono este boton instancio la casa que esta en el indice 0
        MenuCasas.Hide();//hace invisible el menu
    }
    private void _on_Button3_button_down()
    {  
        GD.Print("presione el primer boton");
        instanciarEdificio(1);//si presiono este boton instancio la casa que esta en el indice 0
        MenuCasas.Hide();//hace invisible el menu
    }
    private void _on_Button4_button_down()
    {  
        GD.Print("presione el primer boton");
        instanciarEdificio(2);//si presiono este boton instancio la casa que esta en el indice 0
        MenuCasas.Hide();//hace invisible el menu
    }


    private void instanciarEdificio(int escena)//resibo por parametro la escena que voy a instanciar al llamar a esta función,comienza con 0
    {
        InstanciarCasa = true;
        edificioInstanciado = (Spatial)edificios[escena].Instance();//instancio el edificio que esta en el indice 0
        building.AddChild(edificioInstanciado);//agrego como nodo hijo
        //await ToSignal(GetTree().CreateTimer(2.0f),"timeout");
    }    
        

    /*public override void _Input(InputEvent @event)
    {
        if(@event is InputEventMouseMotion evento)
        {
             
        }
    }*/



    private void RayoDeCamara() //funcion para tirar un rayo desde la camara y determinar la posición  del mouse con respecto a la camara
    {  
        if(CamaraActiva == "Camera_aguila")
        {
            camaraActual = Camera_aguila;
            GD.Print("estoy en Camera_aguila");
        }
            
        if(CamaraActiva == "Camera_superior")
        {
            camaraActual = Camera_superior;
            GD.Print("estoy en Camera_superior");
        }
            
        if(CamaraActiva == "Camera_vista_media")
        {
            camaraActual = Camera_vista_media;
            GD.Print("estoy en Camera_vista_media"); 
        }
  

        origen = camaraActual.ProjectRayOrigin(GetGlobalMousePosition());//determina la posición de la camara 3D respecto al viewport 
        destino = origen + camaraActual.ProjectRayNormal(GetLocalMousePosition()) * RayoDistancia;//rayo lanzado desde la camara y el mouse
        espacio =  camaraActual.GetWorld().DirectSpaceState;
        intercepto = espacio.IntersectRay(origen,destino,new Godot.Collections.Array{}, 1);//esto es una variable global para saber la posición del mouse
        

        if(intercepto.Contains("position"))//si el diccionario tiene esa clave
        {
            edificioInstanciado.Translation = (Vector3)intercepto["position"];//guardo la posición del mouse
            GD.Print(intercepto["position"]);//imprimo por pantalla la ubicación del mouse
        }    
    }
        
        

}




