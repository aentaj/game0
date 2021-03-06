using Godot;
using Godot.Collections;
using System;



public class InterfaceObjetos : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    
    [Export]
    public Array<PackedScene> edificios = new Array<PackedScene>();
    public Spatial edificioInstanciado, building;
    public Control MenuCasas;//referencia al poput menu
    public bool InstanciarCasa = false;
    //private Vector3 posicionNuevaCasa;

    public resourcesHBoxContainer resourcesHBoxContainer;//para buscar las variables que contienen los nodos en esta clase



    //TODO ESTO ES RELACIONADO A LA CAMARA MUY IMPORTANTE
    [Export]
    int RayoDistancia = 1000;
    // Called when the node enters the scene tree for the first time.
    public Camera Camera_aguila,Camera_superior,Camera_vista_media,camaraActual;//para precargar las camaras

    //private Godot.Collections.Dictionary intercepto = new Godot.Collections.Dictionary(); //diccionario global que guarda las posiciones donde esta el mouse
    //private Godot.Collections.Array intercepto = new Godot.Collections.Array { };

    public string CamaraActiva;//para saber cual es la camara activa
    public Vector3 origen,destino,posicionEdificioInstanciado;

    public PhysicsDirectSpaceState espacio;
    public Dictionary intercepto;
    /////////////////////////////////////////////////////////////////

    //esto lo sobreescribo en cada clase instanciada
    /*public override void _Ready()
    {
        MenuCasas = (Control)GetTree().GetNodesInGroup("edificios")[0];//como el popupmenu es el segundo el indice es 1
        building = (Spatial)GetTree().GetNodesInGroup("building")[0];//busco el nodo donde se crearan los edificios
        //precargo las camaras
        Camera_aguila =((Camera)GetTree().GetNodesInGroup("Camera_aguila")[0]);//guardo la camara
        Camera_superior = ((Camera)GetTree().GetNodesInGroup("Camera_superior")[0]);//guardo la camara
        Camera_vista_media = ((Camera)GetTree().GetNodesInGroup("Camera_vista_media")[0]);//guardo la camara
        CamaraActiva = GetViewport().GetCamera().Name;//tomo la camara activa del viewport
    }*/
        


    /*private void _on_Button2_button_down()
    {  
        GD.Print("presione el primer boton");
        instanciarEdificio(0);//si presiono este boton instancio la casa que esta en el indice 0
    }


    private void _on_Button3_button_down()
    {  
        GD.Print("presione segundo boton");
        instanciarEdificio(1);//si presiono este boton instancio la casa que esta en el indice 0
    }


    private void _on_Button4_button_down()
    {  
        GD.Print("presione el tercer boton");
        instanciarEdificio(2);//si presiono este boton instancio la casa que esta en el indice 0
    }*/    
        
        

// Called every frame. 'delta' is the elapsed time since the previous frame.
   public override void _Process(float delta)
   {
        CamaraActiva = GetViewport().GetCamera().Name;//tomo la camara activa del viewport
        if(InstanciarCasa)
        {
            MoverEdificioInstanciado();
            //CamaraActiva = GetViewport().GetCamera().Name;
            if(Input.IsActionJustPressed("click_derecho"))
            {
                InstanciarCasa = false;
            }
        }    
                
       //GD.Print(GetViewport().GetCamera().Name);   
       //GD.Print(GetGlobalMousePosition());  
   }

    private void _on_Button_button_down()
    {
        MenuCasas.Visible = true;//hace visible y invisible el poput menu
        
        //cambio la posición del POPUPMENU
        MenuCasas.SetPosition(new Vector2
            ( //la posición del menu es relativo al boton
            MenuCasas.RectPosition.x,//la posición en x es la misma
            this.RectGlobalPosition.y//posicion global en y donde esta situado el padre de los nodos
            )
        );
    }

    

    public void instanciarEdificio(int escena)//resibo por parametro la escena que voy a instanciar al llamar a esta función,comienza con 0
    {
        InstanciarCasa = true;
        edificioInstanciado = (Spatial)edificios[escena].Instance();//instancio el edificio que esta en el indice 0
        building.AddChild(edificioInstanciado);//agrego como nodo hijo
        //await ToSignal(GetTree().CreateTimer(2.0f),"timeout");
        MenuCasas.Visible = false;//hace invisible el menu

    }


        
    public void MoverEdificioInstanciado() //funcion para tirar un rayo desde la camara y determinar la posición  del mouse con respecto a la camara
    {  
        //GD.Print("estoy en la función mover edificio instanciado");
        if(CamaraActiva == "Camera_aguila")
        {
            camaraActual = Camera_aguila;
            //GD.Print("estoy en Camera_aguila");
        }
            
        if(CamaraActiva == "Camera_superior")
        {
            camaraActual = Camera_superior;
            //GD.Print("estoy en Camera_superior");
        }
            
        if(CamaraActiva == "Camera_vista_media")
        {
            camaraActual = Camera_vista_media;
           //GD.Print("estoy en Camera_vista_media"); 
        }
  

        origen = camaraActual.ProjectRayOrigin(GetGlobalMousePosition());//determina la posición de la camara 3D respecto al viewport 
        destino = origen + camaraActual.ProjectRayNormal(GetGlobalMousePosition()) * RayoDistancia;//rayo lanzado desde la camara y el mouse
        espacio =  camaraActual.GetWorld().DirectSpaceState;
        intercepto = espacio.IntersectRay(origen,destino,new Godot.Collections.Array{}, 1);//esto es una variable global para saber la posición del mouse
        //GD.Print(intercepto["position"]);
        //esto es para mover los cubos instanciados
        if(intercepto.Contains("position"))//si el diccionario tiene esa clave
        {
            posicionEdificioInstanciado = (Vector3)intercepto["position"];//guardo la posición desde el arreglo donde esta la posición del rayo
            posicionEdificioInstanciado = new Vector3( //conviero la posición a número entero
                Mathf.Floor(posicionEdificioInstanciado.x),
                Mathf.Floor(posicionEdificioInstanciado.y),
                Mathf.Floor(posicionEdificioInstanciado.z)
                );
            //GetViewport().WarpMouse(new Vector2(0,0));
            //edificioInstanciado.Translation = (Vector3)intercepto["position"];//guardo la posición del mouse
            edificioInstanciado.Translation = posicionEdificioInstanciado;//guardo la posición del mouse


            GD.Print(posicionEdificioInstanciado);//imprimo por pantalla la ubicación del mouse donde intercepto dependiendo la Cámara
        }    
        /*GetViewport().WarpMouse(new Vector2(
                posicionEdificioInstanciado.x + 1,
                posicionEdificioInstanciado.z + 1)
                );*/
    }
            


    public void MenuInvisible()
    {
        MenuCasas.Visible = false;//hace invisible el menu
    }    
        

    public void OcultaryHacerVisibleMenu()//hace que el menu sea visible y invisible si presiono el boton
    {
        if(MenuCasas.Visible == false) //si el menu NO esta visible
        {
            MenuCasas.Visible = true;//hace visible el menu
        }
        else //si el menu esta visible
        {
            MenuCasas.Visible = false; //hago invisible
        } 
    }

    public void PosicionarPoputMenu()//la posición del menu es relativo al boton
    {
        //cambio la posición del POPUPMENU
        MenuCasas.SetPosition(new Vector2
            ( //la posición del menu es relativo al boton
            MenuCasas.RectPosition.x,//la posición en x es la misma
            this.RectGlobalPosition.y//posicion global en y donde esta situado el padre de los nodos
            )
        );
    }

        
}
        





