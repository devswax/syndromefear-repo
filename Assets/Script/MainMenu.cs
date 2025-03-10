//Que fait il :
//  - Gère les boutons du main menu.

//Dépendence :
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;

public class ChangeScene : MonoBehaviour
{
    public GameObject menu;
    public GameObject MultMenu;
    public GameObject CredMenu;
    public GameObject OptionMenu;

    
    public AudioSource audioSource;
    public AudioSource audioSource2;

    //Permet de changer de scène. 
    public void Scene(string mult)
    {
        Debug.Log("test");
        menu.SetActive(false);
        MultMenu.SetActive(false);
        CredMenu.SetActive(false);
        OptionMenu.SetActive(false);
        audioSource.Play();
        audioSource2.Stop();
        Application.targetFrameRate = 60;
        Debug.Log("test2");
        if (mult == "1") NetworkManager.Singleton.StartHost();
        else if (mult == "2") NetworkManager.Singleton.StartClient();
        Time.timeScale = 1f;
    }

    public void mult()
    {
        MultMenu.SetActive(true);
        menu.SetActive(false);
        OptionMenu.SetActive(false);
        CredMenu.SetActive(false);
    }

    public void cred()
    {
        MultMenu.SetActive(false);
        menu.SetActive(false);
        OptionMenu.SetActive(false);
        CredMenu.SetActive(true);
    }

    public void option()
    {
        MultMenu.SetActive(false);
        menu.SetActive(false);
        OptionMenu.SetActive(true);
        CredMenu.SetActive(false);
    }

    public void exit()
    {
        MultMenu.SetActive(false);
        CredMenu.SetActive(false);
        OptionMenu.SetActive(false);
        menu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Web()
    {
        Application.OpenURL("http://syndromefear.chefmine.me:16385/");
    }
    
    public void save()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }
}
