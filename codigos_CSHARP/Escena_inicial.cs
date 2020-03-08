using Godot;
using System;

public class Escena_inicial : Node2D
{

    private script_global_cSharp referenciaAinstancias;
    private TextEdit Nodotexto;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Input.SetMouseMode(Input.MouseMode.Hidden);
        Input.SetMouseMode(Input.MouseMode.Visible);
        GetNode<TextEdit>("TextEdit").GrabFocus();
        referenciaAinstancias = GetNode<script_global_cSharp>("/root/script_global_cSharp");
        Nodotexto = GetNode<TextEdit>("TextEdit");
    }

    public override void _Process(float delta){  
        referenciaAinstancias.cantidad_de_instancias = Convert.ToInt16(Nodotexto.Text);//cambio la cantidad de cubos usando el script global
    }

    //esto es para manejar los input de entradas
    /*public override void _UnhandledInput(InputEvent @event){
        if(@event is InputEventMouseButton){
            if (Input.IsMouseButtonPressed(1))
            {
                GD.Print("tendria que cambiar de escena");
                GetTree().ChangeScene("res://escenas/Escena_principal.tscn");
            }
        }
    }*/

    public void _on_Button_pressed(){//si presiono el boton start
        GetTree().ChangeScene("res://escenas/Escena_principal.tscn");//cambio la escena
    }   

}
