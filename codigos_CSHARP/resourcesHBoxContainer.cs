using Godot;
using System;

public class resourcesHBoxContainer : HBoxContainer
{
    
    //variables para buscar los puntajes en la UI
    public Label ScoreSilicon,Scorepolycrystalline,ScoreGraphene,ScoreIron,ScoreDopants,ScoreMoney,ScoreEnergy;
    //public int NumScoreSilicon,NumScorepolycrystalline,NumScoreGraphene,NumScoreIron,NumScoreDopants,NumScoreMoney,NumScoreEnergy;
    
    //el gasto de la fabrica sera igual a la cantida * el tipo de fabrica * tiempo funcionando
    public int energiaDePaneles = 0,gastoDefabricas = 0, gastoDeCasas = 0;//es para saber cuantos edificios hay y representarlos en la energía que posee el jugador
    
    
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
    
    private void _on_TimerEnergy_timeout()//Este timer es para aumentar la energía..cuando termino el tiempo en el NodoTimer de energía
    {
        ScoreEnergy.Text = (Convert.ToInt16(ScoreEnergy.Text) + energiaDePaneles).ToString();//aumento la cantidad de energía dependiendo la cantidad de paneles solares el 3 significa que cada panel puede alimentar 3 ciudades
        //GD.Print(energiaDePaneles);
    }

    private void _on_TimerCasas_timeout()//este timer es para restar energía dependiendo la cantidad de casas que hay en la escena
    {
        ScoreEnergy.Text = (Convert.ToInt16(ScoreEnergy.Text) - gastoDeCasas).ToString();//aumento la cantidad de energía
    }

    public void _on_TimerFactory_timeout()//este timer es para restar energía dependiendo la cantidad de fabricas que hay en la escena
    {
        ScoreEnergy.Text =  (Convert.ToInt16(ScoreEnergy.Text) - gastoDefabricas).ToString();//aumento la cantidad de energía
    }

}
