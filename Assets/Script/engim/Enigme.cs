//Que fait il :
//  - Gère les tps entre chaque salle.

//Dépendence :
using UnityEngine;

public abstract class Enigme
{
    // Variable :
    public string s_Title;
    public string s_Explanations;
    public int i_Number;

    public bool b_finished = false;
    
    protected GameObject PlayField;

    // Constructeur de la classe abstraite Enigme
    public Enigme(string s_title, string s_explanations, int i_number)
    {
        s_Title = s_title;
        s_Explanations = s_explanations;
        i_Number = i_number;

        PlayField = EnigmeManager.Instance.PlayField;
    }

    //Fonction de la classe abstraite Enigme :
    public abstract void Initialize();

    public abstract bool Check();
}