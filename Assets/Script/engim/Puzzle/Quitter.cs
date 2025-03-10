using UnityEngine;
using UnityEngine.UI;

public class Quitter : MonoBehaviour
{
    
    public Button ValidateButton;

    void Start()
    {
        ValidateButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        EnigmeManager.Instance.Quit(1);
    }
}