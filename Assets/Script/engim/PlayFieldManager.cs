using System.Collections;
using UnityEngine;

public class PlayFieldManager : MonoBehaviour
{
    private Canvas playFieldCanvas;

    private int SortingDerrière = -1;
    private int SortingDevant = 10;

    public void Show()
    {
        Debug.Log("Le show");
        playFieldCanvas = GameObject.Find("PlayField").GetComponentInParent<Canvas>();

        if (playFieldCanvas == null)
        {
            Debug.LogError("❌ Canvas non trouvé !");
            return;
        }

        playFieldCanvas.sortingOrder = SortingDerrière; // Derrière les autres
        StartCoroutine(BringToFront(SortingDevant));
    }

    IEnumerator BringToFront(int s)
    {
        yield return new WaitForSeconds(3f);
        playFieldCanvas.sortingOrder = s; // Devant les autres
    }
    
    public void Hide()
    {
        Debug.Log("Le hide");
        playFieldCanvas = GameObject.Find("PlayField").GetComponentInParent<Canvas>();

        if (playFieldCanvas == null)
        {
            Debug.LogError("❌ Canvas non trouvé !");
            return;
        }

        playFieldCanvas.sortingOrder = SortingDerrière; // Derrière les autres
    }

    public void Toggle()
    {
        playFieldCanvas = GameObject.Find("PlayField").GetComponentInParent<Canvas>();

        if (playFieldCanvas.sortingOrder == SortingDerrière)
        {
            playFieldCanvas.sortingOrder = SortingDevant;
        }
        else
        {
            playFieldCanvas.sortingOrder = SortingDerrière;
        }
    }
}