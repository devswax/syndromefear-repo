using UnityEngine;

public class T_Reversi : Enigme
{
    public T_Reversi(string title, string explanations, int number) : base(title, explanations, number) {}
    
    public override void Initialize()
    {
        Debug.Log("Initialisation du Reversi...");
        
    }

    public override bool Check()
    {
        Debug.Log("Vérification de la victoire...");
        return false; 
    }
    
}