using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Add : MonoBehaviour
{
    public UIManager ui;
    public string name;
    public UIManager.ObjectType type;
    public Sprite image;

    public void Start()
    {
        ui.AddElement(name, type, image);
    }
}
