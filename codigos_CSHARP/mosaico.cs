using Godot;
using System;

public class mosaico : Spatial
{

    private Material materialNaranja = ResourceLoader.Load("res://materiales/naranja.tres") as Material;//precargo el material
    private Material materialGris;
    private MeshInstance mosaic;
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //materialGris = (Material)GetNode("mosaico_prueba/Cube").get_material_override();
        mosaic = (MeshInstance)GetChild(0);//busco al cubo que tiene el material
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void _on_Area_mouse_entered(){
        //GetNode<MeshInstance>("mosaico_prueba/Cube").MaterialOverride = materialNaranja;
        GD.Print("entro el mouse");
    }

    public void _on_Area_input_event(Camera camara,InputEvent @event,Vector2 posicion,float normal,int shape_idx){
        if(@event is InputEventMouseButton){
            if(Input.IsActionJustPressed("click_izquierdo")){
                GD.Print("entro el mouse");
                mosaic.MaterialOverride = materialNaranja;
            }  
        }
    }
}
