using UnityEngine;

public class DisableMainCamera : MonoBehaviour
{
    void Start()
    {
        if (Camera.main != null)
        {
            Camera.main.gameObject.SetActive(false); 
        }
    }
}

