using UnityEngine;

public class mute : MonoBehaviour
{
    public AudioSource audioSource;  // Référence à l'AudioSource
    public AudioSource audioSource2; 

    public GameObject Coche1;

    public GameObject Coche2;

    public void Start()
    {
        if (audioSource.mute && audioSource2.mute)
        {
            Coche1.SetActive(true);
            Coche2.SetActive(false);
        }
        else
        {
            Coche1.SetActive(false);
            Coche2.SetActive(true);
        }
    }

    public void Update()
    {
        if (audioSource.mute && audioSource2.mute)
        {
            Coche1.SetActive(true);
            Coche2.SetActive(false);
        }
        else
        {
            Coche1.SetActive(false);
            Coche2.SetActive(true);
        }
    }

    public void clique()
    {
        audioSource.mute = true;
        audioSource2.mute = true;
        Coche1.SetActive(true);
        Coche2.SetActive(false);
    }

    public void clique2()
    {
        audioSource.mute = false;
        audioSource2.mute = false;

        if (audioSource.mute && audioSource2.mute)
        {
            Coche1.SetActive(true);
            Coche2.SetActive(false);
        }
        else
        {
            Coche1.SetActive(false);
            Coche2.SetActive(true);
        }
    }
}
