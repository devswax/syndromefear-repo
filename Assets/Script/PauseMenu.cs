using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas; // Assigner le Canvas dans l'inspecteur
    public GameObject Inventory;
    public GameObject Save;
    public GameObject Options;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        
        Inventory.SetActive(true);
        Save.SetActive(false);
        Options.SetActive(false);
        isPaused = !isPaused;
        pauseMenuCanvas.SetActive(isPaused);
        
        
        if (isPaused)
        {
            Time.timeScale = 0f; // Met le jeu en pause
        }
        else
        {
            Time.timeScale = 1f; // Reprend le jeu
        }
    }

    public void inv()
    {
        Inventory.SetActive(true);
        Save.SetActive(false);
        Options.SetActive(false);
    }

    public void save()
    {
        Inventory.SetActive(false);
        Save.SetActive(true);
        Options.SetActive(false);
    }

    public void option()
    {
        Inventory.SetActive(false);
        Save.SetActive(false);
        Options.SetActive(true);
    }
}
