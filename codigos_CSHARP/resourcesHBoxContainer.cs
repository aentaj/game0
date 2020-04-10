using Godot;
using System;

public class resourcesHBoxContainer : HBoxContainer
{
    
    //variables para buscar los puntajes en la UI
    public Label ScoreSilicon,Scorepolycrystalline,ScoreGraphene,ScoreIron,ScoreDopants,ScoreMoney,ScoreEnergy;
    public int NumScoreSilicon,NumScorepolycrystalline,NumScoreGraphene,NumScoreIron,NumScoreDopants,NumScoreMoney,NumScoreEnergy;
    
    public int cantidadDePaneles = 0;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //acceder a los nodos de puntuacion
        ScoreSilicon = GetNode<Label>("SiliconMarginContainer/HBoxContainer/ScoreSilicon");
        Scorepolycrystalline = GetNode<Label>("polycrystallineMarginContainer/HBoxContainer2/Scorepolycrystalline");  
        ScoreGraphene = GetNode<Label>("GrapheneMarginContainer/HBoxContainer3/ScoreGraphene");
        ScoreIron = GetNode<Label>("IronMarginContainer/HBoxContainer4/ScoreIron");
        ScoreDopants = GetNode<Label>("DopantsMarginContainer5/HBoxContainer5/ScoreDopants");
        ScoreMoney =GetNode<Label>("MoneyMarginContainer/HBoxContainer6/ScoreMoney");
        ScoreEnergy = GetNode<Label>("EnergyMarginContainer/HBoxContainer6/ScoreEnergy");
        ScoreEnergy.Text = "100";
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    private void _on_TimerEnergy_timeout()//cuando termino el tiempo en el NodoTimer de energía
    {
        ScoreEnergy.Text = (Convert.ToInt16(ScoreEnergy.Text) + cantidadDePaneles).ToString();//aumento la cantidad de energía
    }

}
