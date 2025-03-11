//Que fait il :
//  - Gère les tps entre chaque salle.

//Dépendence :
using UnityEngine;
using System.Collections.Generic;


public class Interact12 : MonoBehaviour
{
    // Variable :
    private Collider2D z_Collider;
    [SerializeField]
    private ContactFilter2D z_Filter;
    private List<Collider2D> z_CollidedObjects =  new List<Collider2D>(1);

    public GameObject menu;

    public Rigidbody2D rb;
    public float fx;
    public float fy;
    Vector2 vmoov;

    // Initialise z_Collider comme étant la Collider de l'objet (le téléporteur).
    private void Start()
    {
        z_Collider = GetComponent<Collider2D>();
    }

    //Répétition :
    private void Update()
    {
        // Récupére les objets en colisions avec le téléporteur en fonction des filtres rentré dans z_Filter et stock les objets dans z_CollidedObjects.
        z_Collider.Overlap(z_Filter, z_CollidedObjects);
        // Parcourt cette liste, afin de récupérer le 1er élément (notre joueur théoriquement au vue des filtres rentrée), et le déplace au coordonée voulu.
        foreach(var z in z_CollidedObjects)
        {
            menu.SetActive(false);
            rb.position = new Vector3(fx, fy);
            break;
        }
        
    }
}
