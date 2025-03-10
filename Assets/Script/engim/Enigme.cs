using UnityEngine;

public abstract class Enigme
{
    public string Title;
    public string Explanations;
    public int Number;
    public bool finished = false;
    
    protected GameObject PlayField;

    public Enigme(string title, string explanations, int number)
    {
        Title = title;
        Explanations = explanations;
        Number = number;

        PlayField = EnigmeManager.Instance.PlayField;
    }
    
    public abstract void Initialize();

    public abstract bool Check();

}