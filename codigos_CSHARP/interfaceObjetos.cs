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
    private Vector3 posicionNuevaCasa;

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
            edificioInstanciado.Translation = posicionNuevaCasa;
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
        if(@event is InputEventMouseMotion evento)
        {
            
            //if(evento.Pressed && evento.ButtonIndex == (int)ButtonList.Left)
            //{
                //Vector3 origen = Camera_aguila.ProjectRayOrigin(evento.Position);//determina la posición de la camara 3D respecto al viewport 
            Vector3 origen = Camera_aguila.ProjectRayOrigin(GetGlobalMousePosition());//determina la posición de la camara 3D respecto al viewport 
            
            Vector3 destino = origen + Camera_aguila.ProjectRayNormal(evento.Position) * RayoDistancia;
            var espacio =  Camera_aguila.GetWorld().DirectSpaceState;
            var intercepto = espacio.IntersectRay(origen,destino,new Godot.Collections.Array{}, 1);
            posicionNuevaCasa = (Vector3)intercepto["position"];
            GD.Print(intercepto["position"]);
                //GD.Print(intercepto);
                //if((bool)intercepto["collider"])
                //{
                //    GD.Print("intercepto con el suelo");
                //}

                /*foreach (var keys in intercepto.Keys)
                {
                    GD.Print(keys);
                }
                foreach (var Values in intercepto.Values)
                {
                    GD.Print(Values);
                }*/

            //}
        }

    }
}




