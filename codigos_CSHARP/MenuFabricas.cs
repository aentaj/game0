using Godot;
using Godot.Collections;
using System;

public class MenuFabricas : InterfaceObjetos
{
   
    public override void _Ready()
    {
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
        //CamaraActiva = GetViewport().GetCamera().Name;//tomo la camara activa del viewport
        if(InstanciarCasa)
        {
            MoverEdificioInstanciado();
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


    private void _on_Button2_button_down()
    {  
        GD.Print("presione el primer boton");
        instanciarEdificio(0);//si presiono este boton instancio la casa que esta en el indice 0
        MenuCasas.Visible = false;//hace invisible el menu
    }


    private void _on_Button3_button_down()
    {  
        GD.Print("presione segundo boton");
        instanciarEdificio(1);//si presiono este boton instancio la casa que esta en el indice 0
         MenuCasas.Visible = false;//hace invisible el menu
    }


    private void _on_Button4_button_down()
    {  
        GD.Print("presione el tercer boton");
        instanciarEdificio(2);//si presiono este boton instancio la casa que esta en el indice 0
        MenuCasas.Visible = false;//hace invisible el menu
    }
        
}
        
