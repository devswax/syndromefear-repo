//Type :
//  - v = Vector
//
//Que fait il :
//  - Gère les déplacement du personnage jouable.

//Dépendence :
using UnityEngine;

public class Player : MonoBehaviour
{
    
    //Initialisation :
    public Rigidbody2D rb;
    public float fspeed = 5f;
    Vector2 vmoov;
    public Animator animator;

    //Répétition :
    void Update()
    {
        //Gére les déplacement :
        vmoov.x = Input.GetAxisRaw("Horizontal");
        vmoov.y = Input.GetAxisRaw("Vertical");
        if (vmoov.x != 0 && vmoov.y != 0)
        {
            vmoov.y = 0;
        }
        rb.MovePosition(rb.position + vmoov * fspeed * Time.deltaTime);
        //  Gére l'animation :
        animator.SetFloat("Horizontal", vmoov.x);
        animator.SetFloat("Vertical", vmoov.y);
        animator.SetFloat("fspeed", vmoov.magnitude);
        
    }
}