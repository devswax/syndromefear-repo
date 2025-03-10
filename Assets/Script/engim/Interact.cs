using UnityEngine;
using System.Collections.Generic;


public class Interact : MonoBehaviour
{
    private Collider2D z_Collider;
    [SerializeField]
    private ContactFilter2D z_Filter;
    private List<Collider2D> z_CollidedObjects =  new List<Collider2D>(1);
    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject menu;


    private void Start()
    {
        z_Collider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        z_Collider.Overlap(z_Filter, z_CollidedObjects);
        foreach(var z in z_CollidedObjects)
        {
            menu.SetActive(false);
            gameManager.JouerEnigme();
            break;
        }
        
    }
}
