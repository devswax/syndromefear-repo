using UnityEngine;
using UnityEngine.UI;

public class Valider : MonoBehaviour
{
    
    public Button ValidateButton;

    void Start()
    {
        ValidateButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        EnigmeManager.Instance.Validate();
    }
}
