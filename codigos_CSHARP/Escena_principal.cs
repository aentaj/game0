using Godot;
using Godot.Collections;
using System;

public class Escena_principal : Spatial
{
    //[Export]
    //public PackedScene masaicos;
    [Export]
    private Array<PackedScene> Masaicos = new Array<PackedScene>();

    [Export]
    public int ancho = 10;
    [Export]
    public int largo = 10;
    [Export]
    public int tileXoffset = 2;
    [Export]
    public int tileZoffset = 2;

    private Spatial mosaicos;
    private Camera Camera_superior;
    private Camera Camera_vista_media;
    private Camera Camera_aguila;

    private Spatial mosaico;

    Vector2 rotar = new Vector2();
    public int camara_elegida = 0;


    //public static var script_global_cSharp = (script_global_cSharp)GetNode("/root/script_global_cSharp");

    public override void _Ready()
    {
        //randomize();//semilla para que la aleatoriedad sea siempre diferente
        //ancho = GetNode<script_global_cSharp>("/root/script_global_cSharp").cantidad_de_instancias;
        //largo = GetNode<script_global_cSharp>("/root/script_global_cSharp").cantidad_de_instancias;
        GD.Print(GetNode<script_global_cSharp>("/root/script_global_cSharp").cantidad_de_instancias);

        GetNode<Label>("UI/Label").Text = "Number of instances " + "\nX= " + Convert.ToString(ancho) + "\nZ= " + Convert.ToString(largo);
        //Input.SetMouseMode(Input.MouseMode.Captured);//capture the mouse

        //inicializo nodos para ahorrar recursos
        mosaicos = GetNode<Spatial>("mosaicos");
        Camera_superior = GetNode<Camera>("camaras/Camera_superior");
        Camera_vista_media = GetNode<Camera>("camaras/Camera_vista_media");
        Camera_aguila = GetNode<Camera>("camaras/Camera_aguila");
        
        forma1();
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }


    private void forma1()
    {
        //Random IniciarAleatoriedad = new Random();
        for (int x = 0; x < ancho; x++)
        {
            for (int z = 0; z < largo; z++)
            {
                if (x==0 || x==ancho -1 || z==0 || z==largo -1)
                {
                    mosaico = (Spatial)Masaicos[4].Instance();//instancio la escena empaquetada mosaicos
                    mosaicos.AddChild(mosaico);//agrego el nodo a la escena
                                               //cambia la posicion de los mosaicos
                    mosaico.Translation = new Vector3
                    (
                        (x * tileXoffset) - largo + 1,//posición en X

                        //(float)Godot.GD.RandRange(0,1),//posición en Y convierto randRange en float
                        0,

                        (z * tileXoffset) - ancho + 1// posición en Z
                    );
                }
                else
                {
                    mosaico = (Spatial)Masaicos[0].Instance();//instancio la escena empaquetada mosaicos
                    mosaicos.AddChild(mosaico);//agrego el nodo a la escena
                                               //cambia la posicion de los mosaicos
                    mosaico.Translation = new Vector3
                    (
                        (x * tileXoffset) - largo + 1,//posición en X

                        //(float)Godot.GD.RandRange(0,1),//posición en Y convierto randRange en float
                        0,

                        (z * tileXoffset) - ancho + 1// posición en Z
                    );
                }

            }
        }
    }



    private void cambiarCamara()
    {//esta funcion cambia las camaras
        if (Input.IsActionJustPressed("w"))
        {

            camara_elegida += 1;
            if (camara_elegida > 2)
            {
                camara_elegida = 0;
            }
            //dependiendo el valor es la camara elegido en el switch
            switch (camara_elegida)
            {
                case 0:
                    Camera_aguila.Current = true;
                    Camera_superior.Current = false;
                    Camera_vista_media.Current = false;
                    return;

                case 1:
                    Camera_aguila.Current = false;
                    Camera_superior.Current = true;
                    Camera_vista_media.Current = false;
                    return;

                case 2:
                    Camera_aguila.Current = false;
                    Camera_superior.Current = false;
                    Camera_vista_media.Current = true;
                    return;

            }

        }
    }


    //eventos relacionados al mouse
    public override void _Input(InputEvent @event)
    {
        cambiarCamara();
        if (@event is InputEventMouseMotion moverMouse)
        {
            Vector2 rotar = moverMouse.Relative * -0.01f;
            Camera_vista_media.RotateY(rotar.x);
            
        }
        if (Input.IsActionJustPressed("enter"))
        {
            GetTree().ChangeScene("res://escenas/Escena_inicial.tscn");
        }
    }


}
