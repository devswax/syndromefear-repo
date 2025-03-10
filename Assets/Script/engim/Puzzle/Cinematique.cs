using UnityEngine;
using UnityEngine.Serialization;

public class Cinematique : MonoBehaviour
{

    public GameObject TitlePage;
    public float durationBeforeHide = 3.0f;
    public bool Finished = false;
    
    void Start()
    {
        if (TitlePage != null) {
            TitlePage.SetActive(true);
            Invoke("Hide", durationBeforeHide);
        }

        else
        {
            Debug.LogWarning("Cinematique n'existe pas");
        }

    }

    void Hide()
    {
        if (TitlePage != null)
        {
            TitlePage.SetActive(false);
            Finished = true;
        }
    }
    
}
