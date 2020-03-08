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

    [Export]
    int RayoDistancia = 1000;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        MenuCasas = (PopupMenu)GetTree().GetNodesInGroup("PopupMenu")[0];//como el popupmenu es el segundo el indice es 1
        building = (Spatial)GetTree().GetNodesInGroup("building")[0];//busco el nodo donde se crearan los edificios
        //precargo las camaras
        Camera_aguila =((Camera)GetTree().GetNodesInGroup("Camera_aguila")[0]);//guardo la camara
        Camera_superior = ((Camera)GetTree().GetNodesInGroup("Camera_superior")[0]);//guardo la camara
        Camera_vista_media = ((Camera)GetTree().GetNodesInGroup("Camera_vista_media")[0]);//guardo la camara
        
        
        
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
   public override void _Process(float delta)
   {
       if(InstanciarCasa)
       {
            edificioInstanciado.Translation = new Vector3(
            -GetGlobalMousePosition().x / 100,
            0,
            -GetGlobalMousePosition().y / 100);//la posición es la misma que la del mouse
            
       }
       //GD.Print(GetGlobalMousePosition());
       
   }


    private void _on_Button_button_down()
    {
        MenuCasas.Show();
    }

    private void _on_Button2_button_down()
    {
        
        GD.Print("presione el primer boton");
        instanciarEdificio(2);//si presiono este boton instancio la casa que esta en el indice 0
        MenuCasas.Hide();//hace invisible el menu
    }


    private void instanciarEdificio(int escena)//resibo por parametro la escena que voy a instanciar al llamar a esta función,comienza con 0
    {
        edificioInstanciado = (Spatial)edificios[escena].Instance();//instancio el edificio que esta en el indice 0
        building.AddChild(edificioInstanciado);//agrego como nodo hijo
        //await ToSignal(GetTree().CreateTimer(2.0f),"timeout");
        edificioInstanciado.Translation = new Vector3(
            0,
            0,
            0);
        InstanciarCasa = true;
    }    

    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventMouseButton eventMouseButton && eventMouseButton.Pressed && eventMouseButton.ButtonIndex == 1)
        {
            Vector3 origen = Camera_aguila.ProjectRayOrigin(eventMouseButton.Position);//determina la posición de la camara 3D respecto al viewport 
            Vector3 destino = origen + Camera_aguila.ProjectRayOrigin(eventMouseButton.Position) * RayoDistancia;
            var espacio =  Camera_aguila.GetWorld().DirectSpaceState;
            var intercepto = espacio.IntersectRay(origen,destino,new Godot.Collections.Array{}, 1);
            //foreach (var keys in intercepto)
            //{
            //    GD.Print(keys);
            //}

        }
    }


}
