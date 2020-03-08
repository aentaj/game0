using Godot;
using System;

public class UI : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private PopupMenu MenuCasas;//referencia al poput menu
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        MenuCasas = (PopupMenu)GetTree().GetNodesInGroup("PopupMenu")[0];
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    /*private void _on_ButtonMenu_button_down()//si preciono el boton
    {
        MenuCasas.Show();
    }*/



}
