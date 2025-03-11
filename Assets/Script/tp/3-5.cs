using UnityEngine;
using System.Collections.Generic;


public class Interact35 : MonoBehaviour
{
    private Collider2D z_Collider;
    [SerializeField]
    private ContactFilter2D z_Filter;
    private List<Collider2D> z_CollidedObjects =  new List<Collider2D>(1);

    [SerializeField] private GameObject menu;

    public Rigidbody2D rb;
    Vector2 vmoov;

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
            Debug.Log("testttttttt");
            rb.position = new Vector3(55.48f, -22.33f, 0f);
            break;
        }
        
    }
}
