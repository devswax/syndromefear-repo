using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public Slider volumeSlider;  // Référence au slider
    public AudioSource audioSource;  // Référence à l'AudioSource
    public AudioSource audioSource2; 

    public GameObject Coche1;

    public GameObject Coche2;

    void Start()
    {
        // Initialiser le slider avec le volume actuel de l'AudioSource
        volumeSlider.value = audioSource.volume;

        // Ajouter un listener pour changer le volume lorsque le slider est déplacé
        volumeSlider.onValueChanged.AddListener(SetVolume);
        
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

    void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
