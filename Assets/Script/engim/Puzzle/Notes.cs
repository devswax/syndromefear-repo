using System;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    public Button NotesButton;
    public Button ClearButton;
    public GameObject notesPanel;
    private DrawManager drawManager;

    void Start()
    {
        NotesButton.onClick.AddListener(OnButtonClick);
        drawManager = notesPanel.GetComponentInChildren<DrawManager>();
        notesPanel.SetActive(false);
        ClearButton.gameObject.SetActive(false);
        ClearButton.onClick.AddListener(ClearNotes);
    }

    void OnButtonClick()
    {
        Debug.Log("Open the notes page");
        bool isActive = !notesPanel.activeSelf;
        notesPanel.SetActive(isActive);
        ClearButton.gameObject.SetActive(isActive);
        EnigmeManager.PlayFieldManager.Toggle();

        if (!isActive)
            drawManager.SaveDrawing();
    }
    
    private void ClearNotes()
    {
        drawManager.ClearScreen();
    }
}
