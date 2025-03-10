using UnityEngine;

public class Démarage : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSource2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.Play();
        audioSource2.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
