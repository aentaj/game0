using Godot;
using Godot.Collections;
using System;

public class MenuFabricas : InterfaceObjetos
{
   private int cantidadDeFabricas = 0;
   private int consumoFabrica = 0;


    public override void _Ready()
    {
        resourcesHBoxContainer = (resourcesHBoxContainer)GetTree().GetNodesInGroup("resourcesHBoxContainer")[0];
        MenuCasas = GetNode<Control>("edificios");//Esto busca el nodo que tiene como hijos los botones que instancian objetos
        building = (Spatial)GetTree().GetNodesInGroup("building")[0];//busco el nodo donde se crearan los edificios que se encuentra en la escena principal
        //precargo las camaras
        Camera_aguila =((Camera)GetTree().GetNodesInGroup("Camera_aguila")[0]);//guardo la camara
        Camera_superior = ((Camera)GetTree().GetNodesInGroup("Camera_superior")[0]);//guardo la camara
        Camera_vista_media = ((Camera)GetTree().GetNodesInGroup("Camera_vista_media")[0]);//guardo la camara
        CamaraActiva = GetViewport().GetCamera().Name;//tomo la camara activa del viewport
    }
        
        
        

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
   public override void _Process(float delta)
   {
        CamaraActiva = GetViewport().GetCamera().Name;//tomo la camara activa del viewport esto es provisorio por el momento
        
        if(InstanciarCasa)
        {
            MoverEdificioInstanciado();
            if(Input.IsActionJustPressed("click_derecho"))
            {
                resourcesHBoxContainer.gastoDefabricas = consumoFabrica + cantidadDeFabricas;//Esto determina el gasto energético cada ves que instancio una fabrica nueva a la escena
                cantidadDeFabricas += 1;//sumo una fabrica
                InstanciarCasa = false;
            }
        }    
                
       //GD.Print(GetViewport().GetCamera().Name);   
       //GD.Print(GetGlobalMousePosition());  
   }

    private void _on_Button_button_down()//si presiono el boton muestro el menu
    {
        OcultaryHacerVisibleMenu();//esto hace que el menu sea o no sea visible dependiendo su estado
        PosicionarPoputMenu();//la posición del menu es relativo al boton
    }
        
    //////Esto son los botones que estan dentro del menu//////////////

    private void _on_Button2_button_down()
    {  
        //GD.Print("presione el primer boton");
        instanciarEdificio(0);//si presiono este boton instancio la casa que esta en el indice 0
        consumoFabrica = 2;//cuanto consume este edificio instanciado
    }


    private void _on_Button3_button_down()
    {  
        //GD.Print("presione segundo boton");
        instanciarEdificio(1);//si presiono este boton instancio la casa que esta en el indice 0
        consumoFabrica = 4;
    }


    private void _on_Button4_button_down()
    {  
        //GD.Print("presione el tercer boton");
        instanciarEdificio(2);//si presiono este boton instancio la casa que esta en el indice 0
        consumoFabrica = 6;
    }
        
}
        
