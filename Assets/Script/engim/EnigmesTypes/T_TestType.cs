using UnityEngine;

public class T_TestType : Enigme
{
    public T_TestType(string title, string explanations, int number): base(title, explanations, number) {}
    
    public override void Initialize(){}

    public override bool Check()
    {
        return true;
    }
}